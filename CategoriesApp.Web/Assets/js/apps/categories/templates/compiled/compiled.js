this["Categories"] = this["Categories"] || {};
this["Categories"]["Templates"] = this["Categories"]["Templates"] || {};
this["Categories"]["Templates"]["CategoriesListItemTemplate"] = Handlebars.template({"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    var helper;

  return "<div class=\"category-container\">\r\n    <div class=\"category\">"
    + this.escapeExpression(((helper = (helper = helpers.name || (depth0 != null ? depth0.name : depth0)) != null ? helper : helpers.helperMissing),(typeof helper === "function" ? helper.call(depth0,{"name":"name","hash":{},"data":data}) : helper)))
    + "</div>\r\n    <div class=\"buttons-container\">\r\n        <button class=\"btn edit\">Edit</button>\r\n        <button class=\"btn delete\">&times;</button>\r\n    </div>\r\n</div>\r\n<div class=\"categories-viewpart\"></div>";
},"useData":true});