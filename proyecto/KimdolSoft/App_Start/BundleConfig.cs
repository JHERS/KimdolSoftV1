﻿using System.Web;
using System.Web.Optimization;

namespace KimdolSoft
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/scriptsJquery").Include(
               "~/Scripts/jquery-2.1.4.min.js*"
               ));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-table.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-table.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/datatable/js").Include(
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.responsive.min.js"
                 ));
            bundles.Add(new StyleBundle("~/datatable/css").Include(
                "~/Content/DataTables/css/jquery.dataTables.min.css",
                "~/Content/DataTables/css/responsive.dataTables.min.css"
                ));
            
            bundles.Add(new StyleBundle("~/Content/css/select2").Include(
                "~/Content/Css/select2.min.css"));

            bundles.Add(new ScriptBundle("~/scripts/select2").Include(
                "~/Scripts/select2.min.js"
                ));
           


        }
    }
}
