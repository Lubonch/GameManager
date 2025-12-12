#!/usr/bin/env node

/**
 * glob-cli-fixed - A secure CLI tool for finding files matching glob patterns
 * and executing commands on the matched files.
 * 
 * SECURITY FIX: This version properly handles the -c/--cmd flag without
 * command injection vulnerabilities by avoiding shell:true
 */

const { spawn } = require('child_process');
const { glob } = require('glob');
const { program } = require('commander');

program
  .version('1.0.0')
  .description('Find files matching glob patterns and execute commands on them')
  .argument('<pattern>', 'Glob pattern to match files')
  .option('-c, --cmd <command>', 'Command to execute for each matched file (use {} as placeholder for filename)')
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
        // SECURITY FIX: Parse the command properly and avoid shell:true
        // NOTE: This simple split doesn't handle quoted arguments with spaces
        // (e.g., 'cat "file with spaces.txt"'). For production use, consider
        // a proper shell argument parser or document this limitation.
        const cmdParts = options.cmd.split(/\s+/);
        const executable = cmdParts[0];
        
        // Replace {} placeholder with the file path in each argument
        const args = cmdParts.slice(1).map(arg => arg.replace('{}', file));
        
        console.log(`\nRunning: ${executable} ${args.join(' ')}`);
        
        // SECURE: Execute without shell interpretation
        // This prevents command injection because shell metacharacters
        // are not interpreted (no ;, &&, ||, |, etc.)
        const child = spawn(executable, args, {
          stdio: 'inherit'
        });
        
        await new Promise((resolve, reject) => {
          child.on('exit', (code) => {
            if (code !== 0) {
              console.error(`Command exited with code ${code}`);
            }
            resolve();
          });
          child.on('error', (error) => {
            console.error(`Failed to execute command: ${error.message}`);
            reject(error);
          });
        });
      }
    }
  } catch (error) {
    console.error('Error:', error.message);
    process.exit(1);
  }
}

main();
