;
(function(App, Backbone) {

    App.Models.CategoryModel = Backbone.Model.extend({
        urlRoot: "/api/categories",

        initialize: function() {
            this.on("sync", function() {
                this._loaded = true;
            }.bind(this));
        },

        isLoaded: function() {
            return this._loaded;
        }
    });

})(Categories, Backbone);