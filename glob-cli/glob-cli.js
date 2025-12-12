#!/usr/bin/env node

/**
 * glob-cli - A simple CLI tool for finding files matching glob patterns
 * and optionally executing commands on the matched files.
 * 
 * SECURITY ISSUE: This version has a command injection vulnerability
 * when using the -c/--cmd flag with shell:true
 */

const { spawn } = require('child_process');
const { glob } = require('glob');
const { program } = require('commander');

program
  .version('1.0.0')
  .description('Find files matching glob patterns and execute commands on them')
  .argument('<pattern>', 'Glob pattern to match files')
  .option('-c, --cmd <command>', 'Command to execute for each matched file')
  .parse(process.argv);

const options = program.opts();
const pattern = program.args[0];

async function main() {
  try {
    // Find files matching the glob pattern
    const files = await glob(pattern);
    
    if (files.length === 0) {
      console.log('No files matched the pattern');
      return;
    }
    
    console.log(`Found ${files.length} file(s):`);
    files.forEach(file => console.log(`  ${file}`));
    
    // If command is specified, execute it for each file
    if (options.cmd) {
      console.log(`\nExecuting command for each file: ${options.cmd}`);
      
      for (const file of files) {
        // VULNERABILITY: Using shell:true with user-provided command
        // This allows command injection attacks
        const command = options.cmd.replace('{}', file);
        
        console.log(`\nRunning: ${command}`);
        
        // This is the vulnerable code - it executes the command with shell:true
        const child = spawn(command, {
          shell: true,  // DANGEROUS: Allows shell metacharacters and command injection
          stdio: 'inherit'
        });
        
        await new Promise((resolve, reject) => {
          child.on('exit', (code) => {
            if (code !== 0) {
              console.error(`Command exited with code ${code}`);
            }
            resolve();
          });
          child.on('error', reject);
        });
      }
    }
  } catch (error) {
    console.error('Error:', error.message);
    process.exit(1);
  }
}

main();
