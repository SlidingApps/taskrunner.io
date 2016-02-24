module.exports = () => () => require('run-sequence')('check:tslint', (error) => {
    if (error) {
        var exitcode = 2;
        console.log('[ERROR] gulp build task failed', error);
        console.log('[FAIL] gulp build task failed - exiting with code ' + exitcode);
        
        return process.exit(exitCode);
      }
});
