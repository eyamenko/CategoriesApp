;
(function(App, Backbone) {

    App.CategoriesListItemView = Backbone.View.extend({
        className: "categories-list-item-view",
        template: App.Templates.CategoriesListItemTemplate,

        events: {
            "click .edit": "edit",
            "click .delete": "delete"
        },

        initialize: function() {
            this.listenTo(this.model, "destroy", this.remove);
        },

        edit: function() {

        },

        delete: function() {
            this.model.destroy();
        },

        render: function() {
            this.$el.html(this.template(this.model.toJSON()));
            return this;
        }
    });

    App.CategoriesListView = Backbone.View.extend({
        className: "categories-list-view",

        initialize: function() {
            
        },

        render: function() {
            
        }
    });

})(Categories, Backbone);