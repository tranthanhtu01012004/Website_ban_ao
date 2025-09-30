using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShopBanHang.Models;
namespace ShopBanHang.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Acc, string Pass)
        {
            //--- Đọc thông tin tài khoản từ Database thông qua Data model để xét có đúng tài khoản và mật khẩu không 
            TaiKhoan ttdn = new BanHangEntities1()
                                    .TaiKhoans.Where( s => s.taiKhoan1.Equals(Acc.ToLower().Trim()) && s.matKhau.Equals(Pass))
                                    .First<TaiKhoan>();
            //--- Lấy được thông tin từ Database và đúng ... thì cho phép vào Private Pages
            bool isAuthentic = ttdn != null && ttdn.taiKhoan1.Equals(Acc.ToLower().Trim()) && ttdn.matKhau.Equals(Pass);
            if (isAuthentic)
            {
                Session["TtDangNhap"] = ttdn;
                return RedirectToAction("Index", "Dashboard", new { Area = "PrivatePages" });
            }
            return View();
        }
    }
}