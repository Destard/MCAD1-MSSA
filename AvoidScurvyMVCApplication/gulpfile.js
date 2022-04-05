var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');

gulp.task('concatAndMinifyMyFiles', function () {
    return gulp.src(['wwwroot/js/site.js'])
        .pipe(uglify())
        .pipe(gulp.src([
        'wwwroot/lib/bootstrap/dist/js/bootstrap.bundle.min.js',
        'wwwroot/lib/jquery/dist/jquery.min.js',]))
        .pipe(concat("all.js"))
        .pipe(gulp.dest('wwwroot/js/'))
});
gulp.task("js-watcher", function () {
    gulp.watch('wwwroot/js/site.js', gulp.series("concatAndMinifyMyFiles"));
});