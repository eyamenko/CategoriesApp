namespace CategoriesApp.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css/lib").Include(
                "~/Assets/css/lib/bootstrap.min.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/lib").Include(
                "~/Assets/js/lib/jquery.min.js",
                "~/Assets/js/lib/bootstrap.min.js",
                "~/Assets/js/lib/underscore-min.js",
                "~/Assets/js/lib/handlebars.runtime.min.js",
                "~/Assets/js/lib/backbone-min.js",
                "~/Assets/js/lib/backbone.stickit.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/shared").Include(
                "~/Assets/js/apps/shared/ns.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js/categories").Include(
                "~/Assets/js/apps/categories/ns.js"
                ));
        }
    }
}