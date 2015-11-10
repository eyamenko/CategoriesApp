;
(function(App, Backbone) {

    App.Models.CategoryModel = Backbone.Model.extend({
        urlRoot: "/api/categories"
    });

})(Categories, Backbone);