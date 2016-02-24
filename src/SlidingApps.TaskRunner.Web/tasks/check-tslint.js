module.exports = (gulp, directory, configuration) => () => {
  const path = require('path');
  const tslint = require('gulp-tslint');

  return gulp.src([
    path.join(directory, '**', '*.ts'),
    path.join('!', directory, 'vendor', '**.ts'),
    path.join('!', directory, 'typings.d.ts')
  ])
  .pipe(tslint({
    configuration: require(configuration)
  }))
  .pipe(tslint.report('verbose'));
};
