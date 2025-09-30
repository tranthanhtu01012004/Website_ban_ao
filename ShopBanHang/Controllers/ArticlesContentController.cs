using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class ArticlesContentController : Controller
    {
        // GET: ArticlesContent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index(string maBV)
        {
            BanHangEntities1 db = new BanHangEntities1();
            BaiViet s = db.BaiViets.Where(z => z.maBV == maBV).First<BaiViet>();
            ViewData["SPCanxem"] = s;
            return View();
        }
    }
}