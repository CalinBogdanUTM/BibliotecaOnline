using System.Web;
using System.Web.Optimization;

namespace MyLibrary.Web
{
     public class BundleConfig
     {
          // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
          public static void RegisterBundles(BundleCollection bundles)
          {
            bundles.Add(new StyleBundle("~/bundles/vendorcss")
                .Include("~/Vendor/css/authstyle.css")
                .Include("~/Vendor/css/font-awesome.min.css")
                .Include("~/Vendor/css/jquery.accordion.css")
                .Include("~/Vendor/css/mmenu.css")
                .Include("~/Vendor/css/mmenu.positioning.css")
                .Include("~/Vendor/css/responsivetable.css")
                .Include("~/Vendor/css/style.css")
            );


            bundles.Add(new ScriptBundle("~/bundles/vendorjs")
                .Include("~/Vendor/js/accordion.min.js")
                .Include("~/Vendor/js/bootstrap.min.js")
                .Include("~/Vendor/js/bxslider.min.js")
                .Include("~/Vendor/js/carousel.swipe.min.js")
                .Include("~/Vendor/js/facts.counter.min.js")
                .Include("~/Vendor/js/google.map.js")
                .Include("~/Vendor/js/harvey.min.js")
                .Include("~/Vendor/js/jquery-1.12.4.min.js")
                .Include("~/Vendor/js/jquery-ui.min.js")
                .Include("~/Vendor/js/jquery.easing.1.3.js")
                .Include("~/Vendor/js/lgscript.js")
                .Include("~/Vendor/js/main.js")
                .Include("~/Vendor/js/masonry.min.js")
                .Include("~/Vendor/js/meniu.js")
                .Include("~/Vendor/js/mixitup.min.js")
                .Include("~/Vendor/js/owl.carousel.min.js")
                .Include("~/Vendor/js/responsive.table.min.js")
                .Include("~/Vendor/js/responsive.tabs.min.js")
                .Include("~/Vendor/js/waypoints.min.js")
            );
        }
     }
}
