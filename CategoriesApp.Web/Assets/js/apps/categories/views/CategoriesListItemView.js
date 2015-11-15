;
(function(App, Backbone, _) {

    App.Views.CategoriesListItemView = Backbone.View.extend({
        className: "categories-list-item-view",
        template: App.Templates.CategoriesListItemTemplate,

        ui: {
            delete: ".delete",
            select: ".select",
            category: ".category",
            categories: ".categories-viewpart",
            categoryContainer: ".category-container"
        },

        initialize: function(options) {
            this.model = options.model;
            this.category = options.category;
            this.children = new App.Collections.CategoriesCollection({ parentId: this.model.get("id") });

            this.listenTo(this.model, "destroy", this.remove);
            this.listenTo(this.children, "sync", this.toggleParent);
            this.listenTo(this.children, "sync", this.renderChildren);
            this.listenTo(this.children, "destroy", this.toggleParent);
            this.listenTo(this.category, "change:parentId", this.toggleSelected);

            this.children.fetch();
        },

        delete: function() {
            if (confirm("Do you really want to delete " + this.model.get("name") + "?"))
                this.model.destroy();
        },

        expand: function() {
            if (!this.$el.find(this.ui.categoryContainer).first().hasClass("parent"))
                return;

            this.$el.find(this.ui.categories).first().slideToggle();
            this.$el.find(this.ui.categoryContainer).first().toggleClass("open");
        },

        select: function() {
            this.category.set("parentId", this.model.get("id"));
        },

        toggleSelected: function(category) {
            if (this.model.get("id") === category.get("parentId"))
                this.$el.find(this.ui.categoryContainer).first().addClass("selected");
            else
                this.$el.find(this.ui.categoryContainer).first().removeClass("selected");
        },

        toggleParent: function() {
            if (this.children.length
                && !(this.children.length === 1
                    && this.children.get(this.category)))
                this.$el.find(this.ui.categoryContainer).first().addClass("parent");
            else
                this.$el.find(this.ui.categoryContainer).first().removeClass("parent");
        },

        renderChildren: function() {
            var view = new App.Views.CategoriesListView({ collection: this.children, category: this.category });
            this.$el.find(this.ui.categories).html(view.render().el);
        },

        render: function() {
            this.$el.html(this.template(_.extend(this.model.toJSON(), { category: this.category })));
            this.$el.find(this.ui.delete).first().click(this.delete.bind(this));
            this.$el.find(this.ui.select).first().click(this.select.bind(this));
            this.$el.find(this.ui.category).first().click(this.expand.bind(this));

            if (this.category)
                this.toggleSelected(this.category);

            return this;
        }
    });

})(Categories, Backbone, _);