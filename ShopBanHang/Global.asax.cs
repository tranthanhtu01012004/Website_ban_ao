using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using ShopBanHang.App_Start;
using ShopBanHang.Models;

namespace ShopBanHang
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleCollection bundles = BundleTable.Bundles;
            BundleConfig.RegisterBundles(bundles);

            /*FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);*/
        }
        public void Session_Start(object sender, EventArgs e)
        {
            Session["TtDangNhap"] = null;
            Session["GioHang"] = new CartShop();
        }
    }
}
