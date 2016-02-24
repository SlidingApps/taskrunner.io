module.exports = (gulp, source, destination) => (done) => {
    const exec = require('child_process').exec;
    const chalk = require('chalk');
    const util = require('gulp-util');
    
    const cmd = 'jspm bundle-sfx '  + source + ' ' + destination + ' --skip-source-maps --minify';
    exec(cmd, 
        (err, stdout, stderr) => {
            if (stdout.length > 0) util.log(stdout);
            if (stderr.length > 0) throw new util.PluginError({ message: stderr.toString() });
            util.log(stderr.length === 0 ? chalk.green('[SUCCESS] ' + cmd) : chalk.red('[FAILED] ' + cmd));
            
            done(err);
        }
    ); 
};