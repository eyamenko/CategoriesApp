this["Categories"] = this["Categories"] || {};
this["Categories"]["Templates"] = this["Categories"]["Templates"] || {};
this["Categories"]["Templates"]["CategoriesListItemTemplate"] = Handlebars.template({"1":function(depth0,helpers,partials,data) {
    return "        <button type=\"button\" class=\"btn btn-default select\">Select</button>\r\n";
},"3":function(depth0,helpers,partials,data) {
    var helper;

  return "        <a href=\"/categories/edit?id="
    + this.escapeExpression(((helper = (helper = helpers.id || (depth0 != null ? depth0.id : depth0)) != null ? helper : helpers.helperMissing),(typeof helper === "function" ? helper.call(depth0,{"name":"id","hash":{},"data":data}) : helper)))
    + "\" class=\"btn btn-default\">Edit</a>\r\n        <button class=\"btn btn-danger delete\">&times;</button>\r\n";
},"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    var stack1, helper;

  return "<div class=\"category-container\">\r\n    <div class=\"category\">"
    + this.escapeExpression(((helper = (helper = helpers.name || (depth0 != null ? depth0.name : depth0)) != null ? helper : helpers.helperMissing),(typeof helper === "function" ? helper.call(depth0,{"name":"name","hash":{},"data":data}) : helper)))
    + "</div>\r\n    <div class=\"buttons-container\">\r\n"
    + ((stack1 = helpers['if'].call(depth0,(depth0 != null ? depth0.category : depth0),{"name":"if","hash":{},"fn":this.program(1, data, 0),"inverse":this.program(3, data, 0),"data":data})) != null ? stack1 : "")
    + "    </div>\r\n</div>\r\n<div class=\"categories-viewpart\"></div>";
},"useData":true});
this["Categories"]["Templates"]["CategoriesTemplate"] = Handlebars.template({"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    return "<div class=\"new-category\">\r\n	<a class=\"btn btn-default\" href=\"/categories/new\">Create New</a>\r\n</div>\r\n<div class=\"categories-viewpart\"></div>";
},"useData":true});
this["Categories"]["Templates"]["CategoryTemplate"] = Handlebars.template({"compiler":[6,">= 2.0.0-beta.1"],"main":function(depth0,helpers,partials,data) {
    return "<form>\r\n    <div class=\"form-group\">\r\n        <label>Name</label>\r\n        <input class=\"name form-control\" type=\"text\" required />\r\n    </div>\r\n    <div class=\"form-group parent-category-group\">\r\n        <label>Parent Category</label>\r\n        <button type=\"button\" class=\"btn btn-default make-root\">Make root</button>\r\n        <div class=\"categories-viewpart\"></div>\r\n    </div>\r\n    <div class=\"buttons-viewpart\">\r\n        <button type=\"button\" class=\"btn btn-danger cancel\">Cancel</button>\r\n        <button type=\"submit\" class=\"btn btn-success\">Save</button>\r\n    </div>\r\n</form>";
},"useData":true});