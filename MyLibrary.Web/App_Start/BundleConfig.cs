using System.Web;
using System.Web.Optimization;

namespace MyLibrary.Web
{
     public class BundleConfig
     {
          // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
          public static void RegisterBundles(BundleCollection bundles)
          {              
               bundles.Add(new StyleBundle("~/bundles/fevicon/css").Include(
                        "~/Vendor/images/favicon.ico"));
               
               bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                        "~/Vendor/css/font-awesome.min.css"));

               bundles.Add(new StyleBundle("~/bundles/menu/css").Include(
                        "~/Vendor/css/mmenu.css"));

               bundles.Add(new StyleBundle("~/bundles/menu.positioning/css").Include(
                        "~/Vendor/css/mmenu.positioning.css"));


               bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                        "~/Vendor/css/style.css"));

               bundles.Add(new StyleBundle("~/bundles/responsivetable/css").Include(
                        "~/Vendor/css/responsivetable.css"));


               bundles.Add(new StyleBundle("~/bundles/jquery.accordion/css").Include(
                        "~/Vendor/css/jquery.accordion.css"));

               bundles.Add(new ScriptBundle("~/bundles/jquery-1.12.4.min.js").Include(
                     "~/Vendor/js/jquery-1.12.4.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/jquery-ui.min.js").Include(
                     "~/Vendor/js/jquery-ui.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/jquery.easing.1.3.js").Include(
                     "~/Vendor/js/jquery.easing.1.3.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/bootstrap.min.js").Include(
                     "~/Vendor/js/bootstrap.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/mmenu.min.js").Include(
                     "~/Vendor/js/mmenu.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/harvey.min.js").Include(
                     "~/Vendor/js/harvey.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/waypoints.min.js").Include(
                        "~/Vendor/js/waypoints.min.js"));


               bundles.Add(new ScriptBundle("~/bundles/js/facts.counter.min.js").Include(
                        "~/Vendor/js/facts.counter.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/mixitup.min.js").Include(
                        "~/Vendor/js/mixitup.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/owl.carousel.min.js").Include(
                        "~/Vendor/js/owl.carousel.min.js"));

               bundles.Add(new ScriptBundle("~/bundles/js/accordion.min.js").Include(
                        "~/Vendor/js/accordion.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                   "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/responsive.tabs.min.js").Include(
                        "~/Vendor/js/responsive.tabs.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/responsive.table.min.js").Include(
                        "~/Vendor/js/responsive.table.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/masonry.min.js").Include(
                        "~/Vendor/js/masonry.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/carousel.swipe.min.js").Include(
                        "~/Vendor/js/carousel.swipe.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/bxslider.min.js").Include(
                        "~/Vendor/js/bxslider.min.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/main.js").Include(
                        "~/Vendor/js/main.js"));
               bundles.Add(new ScriptBundle("~/bundles/js/google.map.js").Include(
                        "~/Vendor/js/google.map.js"));
          }
     }
}
