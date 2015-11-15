;
(function(App, Backbone) {

    App.Views.CategoriesListItemView = Backbone.View.extend({
        className: "categories-list-item-view",
        template: App.Templates.CategoriesListItemTemplate,

        ui: {
            delete: ".delete",
            category: ".category",
            categories: ".categories-viewpart",
            categoryContainer: ".category-container"
        },

        initialize: function(options) {
            this.model = options.model;
            this.children = new App.Collections.CategoriesCollection({ parentId: this.model.get("id") });

            this.listenTo(this.model, "destroy", this.remove);
            this.listenTo(this.children, "sync", this.renderChildren);

            this.children.fetch();
        },

        delete: function() {
            if (confirm("Do you really want to delete " + this.model.get("name") + "?"))
                this.model.destroy();
        },

        expand: function() {
            if (!this.children.length)
                return;

            this.$el.find(this.ui.categories).first().slideToggle();
            this.$el.find(this.ui.categoryContainer).first().toggleClass("open");
        },

        renderChildren: function() {
            if (!this.children.length)
                return;

            var view = new App.Views.CategoriesListView({ collection: this.children });
            this.$el.find(this.ui.categoryContainer).first().addClass("parent");
            this.$el.find(this.ui.categories).html(view.render().el);
        },

        render: function() {
            this.$el.html(this.template(this.model.toJSON()));
            this.$el.find(this.ui.delete).first().click(this.delete.bind(this));
            this.$el.find(this.ui.category).first().click(this.expand.bind(this));

            return this;
        }
    });

    App.Views.CategoriesListView = Backbone.View.extend({
        className: "categories-list-view",

        initialize: function(options) {
            this.collection = options.collection;

            this.listenTo(this.collection, "sync", this.render);

            if (!this.collection.isLoaded())
                this.collection.fetch();
        },

        addOne: function(model) {
            var view = new App.Views.CategoriesListItemView({ model: model });
            this.$el.append(view.render().el);
        },

        render: function() {
            if (!this.collection.isLoaded())
                this.$el.html("Loading...");
            else {
                this.$el.empty();
                this.collection.map(this.addOne.bind(this));
            }

            return this;
        }
    });

})(Categories, Backbone);