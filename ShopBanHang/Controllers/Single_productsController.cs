using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShopBanHang.Models;
namespace ShopBanHang.Controllers
{
    public class Single_productsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            CartShop gh = Session["GioHang"] as CartShop;
            // Nếu CartShop là null, tạo một phiên bản mới
            if (gh == null)
            {
                gh = new CartShop();
                Session["GioHang"] = gh;
            }
            ViewData["Cart"] = gh;
            return View();
        }

        /// <summary>
        /// Tăng số lượng của một sản phẩm trong giỏ hàng.
        /// </summary>
        /// <param name="maSP">ID của sản phẩm cần tăng số lượng.</param>
        /// <returns>Trả về chế độ xem Index sau khi cập nhật giỏ hàng.</returns>
        public ActionResult Increase(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            if (gh == null)
            {
                gh = new CartShop();
            }
            gh.addItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Giảm số lượng của một sản phẩm trong giỏ hàng.
        /// </summary>
        /// <param name="maSP">ID của sản phẩm cần giảm số lượng.</param>
        /// <returns>Trả về chế độ xem Index sau khi cập nhật giỏ hàng.</returns>

        public ActionResult Decrease(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            if (gh == null)
            {
                gh = new CartShop();
            }
            gh.decrease(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
        public ActionResult RemoveItem(string maSP)
        {
            CartShop gh = Session["GioHang"] as CartShop;
            gh.deleteItem(maSP);
            Session["GioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}