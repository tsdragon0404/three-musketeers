﻿using System.Web.Optimization;

namespace SMS.MvcApplication
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/corejs").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/global.js",
                        "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerytmpl").Include(
                        "~/Scripts/jquery.tmpl.js",
                        "~/Scripts/jquery.tmplPlus.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/css/gumby.css",
                        "~/Content/css/site.css",
                        "~/Content/themes/base/jquery.ui.structure.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.structure.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}