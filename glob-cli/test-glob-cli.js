/**
 * Test file to demonstrate the command injection vulnerability
 * and verify the fix works correctly
 */

const { spawn } = require('child_process');
const fs = require('fs');
const path = require('path');

// Create test files
console.log('Setting up test files...');
const testDir = path.join(__dirname, 'test-files');
if (!fs.existsSync(testDir)) {
  fs.mkdirSync(testDir);
}

// Create some test files
fs.writeFileSync(path.join(testDir, 'test1.txt'), 'Test content 1\n');
fs.writeFileSync(path.join(testDir, 'test2.txt'), 'Test content 2\n');
fs.writeFileSync(path.join(testDir, 'test3.txt'), 'Test content 3\n');

console.log('Test files created.\n');

// Test 1: Normal usage (should work for both versions)
console.log('=== Test 1: Normal Usage ===');
console.log('Command: node glob-cli.js "test-files/*.txt" -c "cat {}"');
console.log('Expected: Should display contents of all test files\n');

// Test 2: Command injection attempt with vulnerable version
console.log('=== Test 2: Command Injection Attack (Vulnerable Version) ===');
console.log('Command: node glob-cli.js "test-files/*.txt" -c "cat {} ; echo \\"INJECTED COMMAND EXECUTED\\" > test-files/hacked.txt"');
console.log('Expected with VULNERABLE version: Creates hacked.txt file (SECURITY BREACH!)');
console.log('Expected with FIXED version: Fails to execute (SECURE)\n');

// Test 3: Try to execute arbitrary commands
console.log('=== Test 3: Arbitrary Command Execution Attempt ===');
console.log('Command: node glob-cli.js "test-files/*.txt" -c "cat {} && echo \\"System compromised\\""');
console.log('Expected with VULNERABLE version: Executes both commands (SECURITY BREACH!)');
console.log('Expected with FIXED version: Fails to execute the second command (SECURE)\n');

// Run automated tests
console.log('=== Running Automated Tests ===\n');

async function runTest(name, script, args, shouldSucceed) {
  return new Promise((resolve) => {
    console.log(`Running: ${name}`);
    const child = spawn('node', [script, ...args]);
    
    let output = '';
    child.stdout?.on('data', (data) => {
      output += data.toString();
    });
    child.stderr?.on('data', (data) => {
      output += data.toString();
    });
    
    child.on('exit', (code) => {
      const success = shouldSucceed ? code === 0 : code !== 0;
      console.log(`  Result: ${success ? 'PASS' : 'FAIL'} (exit code: ${code})`);
      console.log(`  Output preview: ${output.substring(0, 100)}...`);
      resolve(success);
    });
    
    child.on('error', () => {
      console.log(`  Result: ${!shouldSucceed ? 'PASS' : 'FAIL'} (command failed to start)`);
      resolve(!shouldSucceed);
    });
  });
}

async function runAllTests() {
  const results = [];
  
  // Test normal operation with vulnerable version
  results.push(await runTest(
    'Test 1a: Normal operation (vulnerable)',
    'glob-cli.js',
    ['test-files/*.txt', '-c', 'cat {}'],
    true
  ));
  
  // Test normal operation with fixed version
  results.push(await runTest(
    'Test 1b: Normal operation (fixed)',
    'glob-cli-fixed.js',
    ['test-files/*.txt', '-c', 'cat {}'],
    true
  ));
  
  // Test command injection with vulnerable version
  console.log('\n--- Testing Command Injection ---');
  results.push(await runTest(
    'Test 2a: Injection attempt (vulnerable) - will create hacked.txt',
    'glob-cli.js',
    ['test-files/*.txt', '-c', 'cat {} ; echo "HACKED" > test-files/hacked.txt'],
    true  // Unfortunately succeeds with vulnerable version
  ));
  
  // Check if hacked.txt was created (indicates vulnerability)
  const hackedFileExists = fs.existsSync(path.join(testDir, 'hacked.txt'));
  if (hackedFileExists) {
    console.log('  ⚠️  WARNING: hacked.txt was created - COMMAND INJECTION SUCCESSFUL!');
    fs.unlinkSync(path.join(testDir, 'hacked.txt')); // Clean up
    results.push(false); // This is actually a security failure
  } else {
    console.log('  ✓ No injection occurred');
    results.push(true);
  }
  
  // Test command injection with fixed version
  results.push(await runTest(
    'Test 2b: Injection attempt (fixed) - should NOT create hacked.txt',
    'glob-cli-fixed.js',
    ['test-files/*.txt', '-c', 'cat {} ; echo "HACKED" > test-files/hacked.txt'],
    false  // Should fail with fixed version
  ));
  
  // Verify hacked.txt was NOT created
  const hackedFileExists2 = fs.existsSync(path.join(testDir, 'hacked.txt'));
  if (!hackedFileExists2) {
    console.log('  ✓ Injection blocked - hacked.txt was NOT created');
    results.push(true);
  } else {
    console.log('  ✗ SECURITY ISSUE: hacked.txt was created!');
    fs.unlinkSync(path.join(testDir, 'hacked.txt')); // Clean up
    results.push(false);
  }
  
  console.log('\n=== Test Summary ===');
  const passed = results.filter(r => r).length;
  const total = results.length;
  console.log(`Tests passed: ${passed}/${total}`);
  
  if (passed === total) {
    console.log('✓ All tests passed!');
  } else {
    console.log('✗ Some tests failed');
  }
  
  // Cleanup
  console.log('\nCleaning up test files...');
  fs.rmSync(testDir, { recursive: true, force: true });
  console.log('Done.');
}

runAllTests().catch(console.error);
