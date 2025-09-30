using System;
using System.Data.Entity.Infrastructure;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace ShopBanHang.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //--- 
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                                                         "~/Content/bootstrap3/animate.css",
                                                         "~/Content/bootstrap3/bootstrap.min.css",
                                                         "~/Content/bootstrap3/font-awesome.min.css", 
                                                         "~/Content/bootstrap3/main.css", 
                                                         "~/Content/bootstrap3/prettyPhoto.css",
                                                        "~/Content/bootstrap3/price-range.css",
                                                         "~/Content/bootstrap3/responsive.css"));

            bundles.Add(new StyleBundle("~/bundles/css1").Include(
                                                "~/Content/bootstrap/bootstrap.min.css",
                                                 "~/Content/bootstrap/flex-slider.css",
                                                "~/Content/bootstrap/font-awesome.css",
                                                "~/Content/bootstrap/lightbox.css",
                                                 "~/Content/bootstrap/owl-carousel.css",
                                                 "~/Content/bootstrap/templatemo-hexashop.css",
                                                 "~/Content/bootstrap2/bootstrap.min.css",
                                                 "~/Content/bootstrap2/tiny-slider.css",
                                                 "~/Content/bootstrap2/tystyle.css"));

            bundles.Add(new StyleBundle("~/bundles/css2").Include(
                                          "~/Content/bootstrap2/bootstrap.min.css",
                                             "~/Content/bootstrap2/tiny-slider.css",
                                             "~/Content/bootstrap2/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/scripts1").Include(
                                         "~/Scripts/jquery-2.1.0.min.js",
                                        "~/Scripts/popper.js",
                                         "~/Scripts/bootstrap.min.js",
                                        "~/Scripts/owl-carousel.js",
                                        "~/Scripts/accordions.js",
                                         "~/Scripts/datepicker.js",
                                        "~/Scripts/scrollreveal.min.js",
                                        "~/Scripts/waypoints.min.js",
                                        "~/Scripts/jquery.counterup.min.js",
                                        "~/Scripts/imgfix.min.js",
                                        "~/Scripts/slick.js",
                                        "~/Scripts/lightbox.js",
                                         "~/Scripts/isotope.js",
                                        "~/Scripts/custom.js"
                                        ));

            bundles.Add(new ScriptBundle("~/bundles/scripts2").Include(
                                        "~/Scripts/Script/bootstrap.bundle.min.js",
                                        "~/Scripts/Script/tiny-slider.js",
                                        "~/Scripts/Script/custom.js",
                                        //--- Giỏ hàng
                                        "~/Scripts/Script/bootstrap.min.js",
                                        "~/Scripts/Script/contact.js",
                                        "~/Scripts/Script/gmaps.js",
                                        "~/Scripts/Script/jquery.js",
                                        "~/Scripts/Script/html5shiv.js",
                                        "~/Scripts/Script/jquery.prettyPhoto.js",
                                        "~/Scripts/Script/jquery.scrollUp.min.js",
                                        "~/Scripts/Script/main.js",
                                        "~/Scripts/Script/price-range.js"));
            bundles.Add(new ScriptBundle("~/bundles/moder").Include("~/Scripts/modernizr-2.6.2.js"));
                                                            
                                                            
        }

    }
}