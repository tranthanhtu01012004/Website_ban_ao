using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopBanHang.Models;


namespace ShopBanHang.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        public ActionResult Details(string maSP)
        {
            BanHangEntities1 db = new BanHangEntities1();
            San_Pham san_Pham = db.San_Pham.Include(San_Pham => San_Pham.LoaiSanPham).FirstOrDefault(x => x.maSP == maSP);
            return View(san_Pham);
        }


    }
}