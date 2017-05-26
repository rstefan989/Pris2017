/// <binding BeforeBuild='minJs' />
"use strict";

var gulp = require("gulp"),
    concat = require("gulp-concat"),
 //   rimraf = require("rimraf"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./"
};

paths.js = paths.webroot + "scripts/pages/demo/**/*.js";

paths.concatJsDest = paths.webroot + "scripts/demo.min.js";

//gulp.task("cleanJs", function (cb) {
//    rimraf(paths.concatJsDest, cb);
//});

gulp.task("minJs", function () {
    gulp.src([paths.js], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});


