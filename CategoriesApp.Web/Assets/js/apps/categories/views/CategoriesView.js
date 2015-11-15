;
(function(App, Backbone) {

    App.Views.CategoriesView = Backbone.View.extend({
        className: "categories-view",
        template: App.Templates.CategoriesTemplate,

        ui: {
            categories: ".categories-viewpart"
        },

        renderCategoriesList: function() {
            var collection = new Categories.Collections.CategoriesCollection();
            var view = new Categories.Views.CategoriesListView({ collection: collection });
            this.$el.find(this.ui.categories).html(view.render().el);
        },

        render: function() {
            this.$el.html(this.template());
            this.renderCategoriesList();

            return this;
        }
    });

})(Categories, Backbone);