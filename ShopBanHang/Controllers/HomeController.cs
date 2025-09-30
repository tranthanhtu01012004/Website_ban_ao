using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            string testMk = MaHoa.encryptSHA256("admin");
            return View();

            List<San_Pham> l = Common.getProductByLoaiSanPham(4);
            return View(l);
        }
       
    }
}