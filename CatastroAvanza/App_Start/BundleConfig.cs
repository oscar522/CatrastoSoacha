using System.Web.Optimization;

namespace CatastroAvanza
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js",
                      "~/Scripts/jquery.validate.min",
                      "~/Scripts/jquery.validate.unobtrusive.min"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalidation").Include(                      
                      "~/Scripts/jquery.validate.min.js",
                      "~/Scripts/jquery.validate.unobtrusive.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(                      
                      "~/Scripts/popper.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap.bundle.min.js",                      
                      "~/Scripts/ScriptConceptos/Validaciones.js",
                      "~/Scripts/addons/datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-fileinput").Include(
                      "~/Scripts/plugins/piexif.min.js",
                      "~/Scripts/plugins/sortable.min.js",                      
                      "~/Scripts/fileinput.min.js",
                      "~/Scripts/locales/es.js",
                      "~/Content/bootstrap-fileinput/themes/explorer-fa/theme.min.js",
                      "~/Content/bootstrap-fileinput/themes/fa/theme.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryLogin").Include(
                        "~/Content/login/vendor/jquery/jquery-{version}.min.js",
                        "~/Content/login/vendor/animsition/js/animsition.min.js",
                        "~/Content/login/vendor/bootstrap/js/popper.js",
                        "~/Content/login/vendor/bootstrap/js/bootstrap.min.js",
                        "~/Content/login/vendor/select2/select2.min.js",
                        "~/Content/login/vendor/daterangepicker/moment.min.js",
                        "~/Content/login/vendor/daterangepicker/daterangepicker.js",
                        "~/Content/login/vendor/countdowntime/countdowntime.js",
                        "~/Content/login/js/main.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",                      
                      "~/Content/style.css",
                      "~/Content/addons/datatables.min.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-fileinput").Include(
                    "~/Content/bootstrap-fileinput/css/fileinput.min.css",
                    "~/Content/bootstrap-fileinput/themes/explorer-fa/theme.min.css"));

            bundles.Add(new StyleBundle("~/Content/cssLogin").Include(
                      "~/Content/login/vendor/bootstrap/css/bootstrap.min.css",
                      "~/Content/login/fonts/font-awesome-4.7.0/css/font-awesome.min.css",
                      "~/Content/login/fonts/iconic/css/material-design-iconic-font.min.css",
                      "~/Content/login/vendor/animate/animate.css",
                      "~/Content/login/vendor/css-hamburgers/hamburgers.min.css",
                      "~/Content/login/vendor/animsition/css/animsition.min.css",
                      "~/Content/login/vendor/select2/select2.min.css",
                      "~/Content/login/vendor/daterangepicker/daterangepicker.css",
                      "~/Content/login/css/util.css",
                      "~/Content/login/css/main.css"));
        }
    }
}
