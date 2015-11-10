var apps = [
    "Shared",
    "Categories"
];

var paths = {
    styles: "css/apps",
    scripts: "js/apps"
};

var exts = {
    styles: "less",
    templates: "handlebars"
};

var tasks = [];
var nsRoot = "";
var nsConcerns = ["Collections", "Models", "Views", "Utils"];

var fs = require("fs");
var gulp = require("gulp");
var less = require("gulp-less");
var wrap = require("gulp-wrap");
var concat = require("gulp-concat");
var declare = require("gulp-declare");
var stripBom = require("gulp-stripbom");
var minifyCSS = require("gulp-minify-css");
var handlebars = require("gulp-handlebars");
var autoprefixer = require("gulp-autoprefixer");

apps.forEach(function(app) {
    var ns = (nsRoot ? nsRoot + "." : "") + app + ".";
    var buildStyles = "build:" + app.toLowerCase() + ":styles";
    var buildTemplates = "build:" + app.toLowerCase() + ":templates";

    gulp.task(buildTemplates, function() {
        return gulp.src(paths.scripts + "/" + app.toLowerCase() + "/templates/*." + exts.templates)
            .pipe(stripBom({
                showLog: false
            }))
            .pipe(handlebars())
            .pipe(wrap("Handlebars.template(<%= contents %>)"))
            .pipe(declare({
                noRedeclare: true,
                namespace: ns + "Templates"
            }))
            .pipe(concat("compiled.js"))
            .pipe(gulp.dest(paths.scripts + "/" + app.toLowerCase() + "/templates/compiled"));
    });

    gulp.task(buildStyles, function() {
        return gulp.src(paths.styles + "/" + app.toLowerCase() + "/*." + exts.styles)
            .pipe(less())
            .pipe(autoprefixer({
                browsers: ["last 2 versions"]
            }))
            .pipe(minifyCSS())
            .pipe(concat("compiled.css"))
            .pipe(gulp.dest(paths.styles + "/" + app.toLowerCase() + "/compiled"));
    });

    gulp.watch(paths.styles + "/" + app.toLowerCase() + "/*." + exts.styles, [buildStyles]);
    gulp.watch(paths.scripts + "/" + app.toLowerCase() + "/templates/*." + exts.templates, [buildTemplates]);

    tasks.push(buildStyles, buildTemplates);

    fs.writeFile(paths.scripts + "/" + app.toLowerCase() + "/ns.js", nsConcerns.map(function(concern) {
        return require("nsdeclare")(ns + concern);
    }).join("\n"));
});

gulp.task("default", tasks);