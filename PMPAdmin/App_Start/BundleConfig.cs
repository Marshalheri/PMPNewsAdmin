using System.Web;
using System.Web.Optimization;

namespace PMPAdmin
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //Admin lte styles and scripts...
            bundles.Add(new ScriptBundle("~/admin-lte/script").Include(
               // "~/Scripts/jquery-1.10.2.min.js",
                //"~/Scripts/jquery-3.4.1.min.js",
                //"~/admin-lte/plugins/jquery/jquery.min.js",
                "~/admin-lte/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/admin-lte/dist/js/adminlte.js",
                "~/admin-lte/plugins/datatables/jquery.dataTables.js",
                "~/admin-lte/plugins/datatables-bs4/js/dataTables.bootstrap4.js",
                "~/admin-lte/plugins/bootstrap/js/bootstrap.bundle.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/admin-lte/css").Include(
                "~/admin-lte/dist/css/adminlte.min.css",
                "~/admin-lte/plugins/fontawesome-free/css/all.min.css",
                "~/admin-lte/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                "~/admin-lte/plugins/datatables-bs4/css/dataTables.bootstrap4.css",
                "~/admin-lte/plugins/select2/css/select2.min.css",
                "~/admin-lte/plugins/select2-bootstrap4-theme/select2-bootstrap4.min.css",
                "~/Content/MyCss.css"));
        }
    }
}
