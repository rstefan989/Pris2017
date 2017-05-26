using System.Web;
using System.Web.Optimization;

namespace IRS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
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
                      "~/Content/site.css",
                      "~/Content/jquery.growl.css"));

            bundles.Add(new ScriptBundle("~/bundles/masterlayout").Include(
                      "~/Scripts/dataTables/jquery.dataTables.min.js",
                      "~/Scripts/dataTables/dataTables.bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/masterlayout").Include(
                      "~/Content/DataTables/dataTables.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                      "~/Scripts/knockout-*",
                      "~/Scripts/knockout.mapping*"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                      "~/Scripts/app/app.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/jquery.growl.js",
                      "~/Scripts/typescript.js",
                      "~/Scripts/pages/layout.js"));


            bundles.Add(new ScriptBundle("~/bundles/changepasswordjs").Include(
                      "~/Scripts/pages/operator/change-password.js"));

            bundles.Add(new ScriptBundle("~/bundles/editprofilejs").Include(
                      "~/Scripts/pages/operator/edit-profile.js"));

            bundles.Add(new ScriptBundle("~/bundles/usersoverviewjs").Include(
                      "~/Scripts/pages/teamlead/users-overview.js"));
            
            BundleTable.EnableOptimizations = false;
        }
    }
}
