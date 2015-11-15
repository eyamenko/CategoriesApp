;
(function(App, Backbone) {

    App.Views.CategoriesListView = Backbone.View.extend({
        className: "categories-list-view",
        template: function() { return ""; },

        initialize: function(options) {
            this.category = options.category;
            this.collection = options.collection;

            this.listenTo(this.collection, "sync", this.render);

            if (!this.collection.isLoaded())
                this.collection.fetch();
        },

        addOne: function(model) {
            if (this.category && this.category.get("id") === model.get("id"))
                return;

            var view = new App.Views.CategoriesListItemView({ model: model, category: this.category });
            this.$el.append(view.render().el);
        },

        render: function() {
            if (!this.collection.isLoaded()) {
                this.$el.html("Loading...");
                return this;
            }

            this.$el.html(this.template());
            this.collection.map(this.addOne.bind(this));

            return this;
        }
    });

})(Categories, Backbone);