const gulp = require('gulp');
const path = require('path');

const config = {
    projectDir: __dirname,
    configDir: path.join(__dirname, 'config'),
    taskDir: path.join(__dirname, 'tasks'),
    appDir: path.join(__dirname, 'app'),
    distDir: path.join(__dirname, 'dist'),
    tsLintAppConf: path.join(__dirname, 'tslint.json'),
    watchDir: path.join(__dirname, 'src')
};

gulp.task('clean:dist', require('./tasks/clean')(gulp, config.distDir));
gulp.task('clean', ['clean:dist']);

gulp.task('check:tslint', ['check:tslint:app']);
gulp.task('check:tslint:app', require('./tasks/check-tslint')(gulp, config.appDir, config.tsLintAppConf));
gulp.task('check', require('./tasks/check')());

gulp.task('build:application', ['check'], require('./tasks/build-jspm')(gulp, 'app/bootstrap', 'dist/application.min.js'));
gulp.task('build', ['clean'], require('./tasks/build')());

gulp.task('default', require('./tasks/default')());