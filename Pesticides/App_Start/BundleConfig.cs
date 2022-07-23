using System.Web;
using System.Web.Optimization;

namespace Pesticides
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
            "~/Scripts/jquery-{version}.js",
            "~/Scripts/bootstrap.js",
            "~/Scripts/DataTables/jquery.datatables.js",
            "~/Scripts/DataTables/datatables.bootstrap.js",
            "~/Scripts/DataTables/buttons.print.js",
                        "~/Scripts/DataTables/buttons.bootstrap.js",
                        "~/Scripts/DataTables/buttons.jqueryui.js",
                        "~/Scripts/DataTables/datatables.buttons.js",
                        "~/Scripts/DataTables/buttons.html5.js",
                        "~/Scripts/DataTables/buttons.flash.js",
                        "~/Scripts/DataTables/pdfmake.min.js",
                        "~/Scripts/DataTables/vfs_fonts.js",
                        "~/Scripts/jquery_cookie.js"
            ));
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //           "~/Scripts/jquery-ui-1.12.1.js*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-rtl.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/DataTables/css/buttons.dataTables.css",
                      "~/Content/DataTables/css/buttons.bootstrap.css",
                      "~/Content/DataTables/css/buttons.jqueryui.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/Site.css"));
        }
    }
}
