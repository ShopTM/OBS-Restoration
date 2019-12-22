let gulp = require('gulp'),
    sass = require('gulp-sass'),
    browserSync = require('browser-sync'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    rename = require('gulp-rename'),
    del = require('del'),
    autoprefixer = require('gulp-autoprefixer'),
	svgSprite = require('gulp-svg-sprite'),
	svgmin = require('gulp-svgmin'),
	cheerio = require('gulp-cheerio'),
	replace = require('gulp-replace');


gulp.task('clean', async function(){
  del.sync('dist')
})

gulp.task('scss', function(){
  return gulp.src('Gulp/app/scss/**/*.scss')
    .pipe(sass({outputStyle: 'compressed'}))
    .pipe(autoprefixer({
      overrideBrowserslist:['last 8 versions']
    }))
    .pipe(rename({suffix: '.min'}))
    .pipe(gulp.dest('Gulp/app/css'))
    .pipe(browserSync.reload({stream: true}))
});

gulp.task('css', function(){
  return gulp.src([
    'node_modules/normalize.css/normalize.css'  
  ])
    .pipe(concat('_libs.scss'))
    .pipe(gulp.dest('app/scss'))
    .pipe(browserSync.reload({stream: true}))
});

gulp.task('cshtml', function(){
  return gulp.src('Gulp/app/*.cshtml')
  .pipe(browserSync.reload({stream: true}))
});

gulp.task('script', function(){
  return gulp.src('Gulp/app/js/*.js')
  .pipe(browserSync.reload({stream: true}))
});

gulp.task('js', function(){
  return gulp.src([
      'Gulp/app/js/*.js'
  ])
    .pipe(concat('libs.min.js'))
    .pipe(uglify())
    .pipe(gulp.dest('app/js'))
    .pipe(browserSync.reload({stream: true}))
});

gulp.task('browser-sync', function() {
  browserSync.init({
      server: {
          baseDir: "app/"
      }
  });
});

//SVG TASK
gulp.task('svg', function(){
	return gulp.src('Gulp/app/svg/*.svg')
        .pipe(svgmin({
            js2svg: {
                pretty: true
            }
        }))
	.pipe(cheerio({
			run: function ($) {
				$('[fill]').removeAttr('fill');
				$('[stroke]').removeAttr('stroke');
				$('[style]').removeAttr('style');
			},
			parserOptions: {xmlMode: true}
		}))
		// cheerio plugin create unnecessary string '&gt;', so replace it.
		.pipe(replace('&gt;', '>'))
		// build svg sprite
		.pipe(svgSprite({
			mode: {
				symbol: {
                    sprite: "sprite.svg",
                    render: {
                        scss: {
                            dest: '../../../sass/_sprite.scss',
                            
                        }
                    }
					
				}
			}
		}))
        .pipe(gulp.dest('Gulp/app/svg/spites'));

});


gulp.task('export', async function(){
///  let buildHtml = gulp.src('Gulp/app/**/*.cshtml')
 ///   .pipe(gulp.dest('Content'));

  let BuildCss = gulp.src('Gulp/app/css/**/*.css')
    .pipe(gulp.dest('Content/Css/Custom'));

 /// let BuildJs = gulp.src('Gulp/app/js/**/*.js')
 ///   .pipe(gulp.dest('Content/Js/Custom'));
    
  ///let BuildFonts = gulp.src('Gulp/app/fonts/**/*.*')
   ///     .pipe(gulp.dest('Content/Fonts'));

   let BuildSvg = gulp.src('Gulp/app/svg/spites/symbol/**/*.*')
       .pipe(gulp.dest('Content/Svg/spites/symbol'));

    let BuildSass = gulp.src('Gulp/app/sass/**/*.*')
        .pipe(gulp.dest('Content/sass'));

 /// let BuildImg = gulp.src('Gulp/app/Images/**/*.*')
 ///   .pipe(gulp.dest('Content/Images'));   

});

gulp.task('watch', function(){
  gulp.watch('Gulp/app/scss/**/*.scss', gulp.parallel('scss'));
  gulp.watch('Gulp/app/*.cshtml', gulp.parallel('cshtml'))
    gulp.watch('Gulp/app/js/*.js', gulp.parallel('script'))
   

});




gulp.task('build', gulp.series('clean', 'export'))

gulp.task('default', gulp.parallel('svg', 'css' ,'scss', 'js', 'browser-sync', 'watch'));