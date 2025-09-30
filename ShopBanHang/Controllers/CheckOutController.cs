using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;

using ShopBanHang.Models;

namespace ShopBanHang.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        [HttpGet]
        public ActionResult Index()
        {
            //--- Tạo đối tượng khách hàng với thông tin mới truyền ra cho View
            KhachHang s = new KhachHang();
            //--- Lấy thông tin đã mua hàng từ Sesstion và truyền cho View thông qua ViewData
            //--- Lấy giỏ hàng từ Sesstion
            CartShop gh = Session["GioHang"] as CartShop;
            // Nếu CartShop là null, tạo một phiên bản mới
            if (gh == null)
            {
                gh = new CartShop();
                Session["GioHang"] = gh;
            }
            ViewData["Cart"] = gh;
            return View(s);
        }
        [HttpPost]
        public ActionResult SaveToDataBase(KhachHang s)
        {
            using (var context = new BanHangEntities1())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        //--- 1.1 [table KhachHang]
                        //--- 1.2 Update customer info to KhachHang object
                        s.maKH = s.soDT;
                        //-- 1.3 
                        context.KhachHangs.Add(s);
                        //--- 1.4
                        context.SaveChanges();
                        //-- 2.1
                        Don_Hang d = new Don_Hang();
                        //-- 2.2
                        d.soDH = string.Format("{0:yyMMddhhmm}", DateTime.Now);
                        d.maKH = s.maKH;
                        d.ngayGH = DateTime.Now;
                        d.ngayGH = DateTime.Now.AddDays(2);
                        d.taiKhoan = "admin";
                        d.diaChiGH = s.diaChi;
                        //--- 2.3
                        context.Don_Hang.Add(d);
                        //-- 2.4
                        context.SaveChanges();
                        //--- 3.1
                        CartShop gh = Session["GioHang"] as CartShop;
                        //-- 3.2
                        foreach (ChiTietDonHang i in gh.SanPhamDC.Values)
                            i.soDH = d.soDH;
                        context.ChiTietDonHangs.AddRange(gh.SanPhamDC.Values);
                        //--- 3.3 
                        context.SaveChanges();
                        //--- 4
                        trans.Commit();
                        //return RedirectToAction("Index", "Home");
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                    }
                }
            }
            //-- Nếu bị lỗi chuyển về CheckOut
            return RedirectToAction("Index", "Home");
        }
    }
}