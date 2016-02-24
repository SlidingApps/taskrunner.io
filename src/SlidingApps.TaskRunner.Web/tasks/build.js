module.exports = () => () => require('run-sequence')('build:application', (error) => {
    const exec = require('child_process').exec;
    const chalk = require('chalk');
    const util = require('gulp-util');
    
    if (error) {
        var exitcode = 2;
        
        util.log(chalk.red('[FAILED] ' + exitcode));
        util.log(chalk.red('[FAILED] ' + error));
        
        return process.exit(exitcode);
      }
});