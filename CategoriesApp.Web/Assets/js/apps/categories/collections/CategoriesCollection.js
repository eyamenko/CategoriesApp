;
(function(App, Backbone) {

    App.Collections.CategoriesCollection = Backbone.Collection.extend({
        model: App.Models.Category,

        url: function() {
            var url = "/api/categories";

            if (this.options.parentId)
                url += "/" + this.options.parentId;

            return url;
        }
    });

})(Categories, Backbone);