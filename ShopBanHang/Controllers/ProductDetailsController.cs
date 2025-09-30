using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanHang.Models;

namespace ShopBanHang.Controllers
{
    public class ProductDetailsController : Controller
    {
        // GET: ProductDetails
        public ActionResult Index(string maSP)
        {
            BanHangEntities1 db = new BanHangEntities1();
            San_Pham s = db.San_Pham.Where(sp => sp.maSP.Equals(maSP)).First<San_Pham>();
            ViewData["SpCanXem"] = s;
            return View();
            
        }


    }
}