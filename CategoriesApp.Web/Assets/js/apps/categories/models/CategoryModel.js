;
(function(App, Backbone) {

    App.Models.CategoryModel = Backbone.Model.extend({
        urlRoot: "/api/categories",

        defaults: {
            name: "",
            parentId: null
        },

        initialize: function() {
            this.on("sync", function() {
                this._loaded = true;
            }.bind(this));
        },

        isLoaded: function() {
            return this._loaded;
        },

        validate: function(attrs) {
            if (!attrs.name)
                return "Name must be provided.";
        }
    });

})(Categories, Backbone);