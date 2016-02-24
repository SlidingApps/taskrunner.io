module.exports = (gulp, dir) => () => {
  const del = require('del');
  const path = require('path');

  return del([
    path.join(dir, '**', '*.js'),
    path.join('!', dir, '*.conf.js'),
    path.join('!', dir, 'vendor', '*.js'),
    path.join(dir, '**', '*.js.map'),
    path.join('!', dir, 'vendor', '*.js.map'),
  ]);
};
