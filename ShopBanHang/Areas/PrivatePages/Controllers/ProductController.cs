using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.PrivatePages.Controllers
{
    public class ProductController : Controller
    {
        // GET: PrivatePages/Product
        public ActionResult Index()
        {
            return View();
        }
        
    }
}