;
(function(App, Backbone) {

    App.Views.CategoryView = Backbone.View.extend({
        className: "category-view",
        template: App.Templates.CategoryTemplate,

        ui: {
            makeRoot: ".make-root",
            categories: ".categories-viewpart",
            parentCategoryGroup: ".parent-category-group"
        },

        events: {
            "submit form": "submit",
            "click .cancel": "redirect",
            "click .make-root": "makeRoot"
        },

        bindings: {
            ".name": "name"
        },

        initialize: function(options) {
            this.model = options.model;
            this.collection = new Categories.Collections.CategoriesCollection();

            this.listenTo(this.model, "sync", this.redirect);
            this.listenTo(this.model, "change:parentId", this.toggleMakeRoot);
            this.listenTo(this.collection, "sync", this.renderCategoriesList);

            this.collection.fetch();
        },

        submit: function(e) {
            e.preventDefault();

            if (!this.model.isValid()) {
                alert(this.model.validationError);
                return;
            }

            this.model.save();
        },

        redirect: function() {
            window.location.href = "/";
        },

        makeRoot: function() {
            this.model.set("parentId", null);
        },

        renderCategoriesList: function() {
            if (!this.collection.length || (this.collection.length === 1 && this.collection.get(this.model)))
                return;

            var view = new Categories.Views.CategoriesListView({ collection: this.collection, category: this.model });
            this.$el.find(this.ui.categories).html(view.render().el);
            this.$el.find(this.ui.parentCategoryGroup).show();
        },

        toggleMakeRoot: function() {
            if (this.model.get("parentId"))
                this.$el.find(this.ui.makeRoot).show();
            else
                this.$el.find(this.ui.makeRoot).hide();
        },

        render: function() {
            this.$el.html(this.template(this.model.toJSON()));
            this.toggleMakeRoot();
            this.stickit();

            return this;
        }
    });

})(Categories, Backbone);