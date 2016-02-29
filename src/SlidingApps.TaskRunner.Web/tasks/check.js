module.exports = () => () => require('run-sequence')('check:tslint', (error) => {
    
    const chalk = require('chalk');
    const util = require('gulp-util');
    
    if (error) {
        var exitcode = 2;
        util.log(chalk.green('[ERROR] gulp tslint task failed: ' + exitcode));
                
        return process.exit(exitcode);
    }
});
