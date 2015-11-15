;
(function(App, Backbone) {

    App.Collections.CategoriesCollection = Backbone.Collection.extend({
        model: App.Models.CategoryModel,

        url: function() {
            var url = "/api/categories";

            if (this.parentId)
                url += "/" + this.parentId + "/children";

            return url;
        },

        initialize: function(options) {
            this.parentId = options && options.parentId;

            this.on("sync", function() {
                this._loaded = true;
            }.bind(this));
        },

        isLoaded: function() {
            return this._loaded;
        }
    });

})(Categories, Backbone);