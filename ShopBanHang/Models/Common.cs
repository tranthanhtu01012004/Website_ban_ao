using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShopBanHang.Controllers;
namespace ShopBanHang.Models
{
    public class Common
    {
        static DbContext cn = new DbContext("name=BanHangEntities1");
        public static List<San_Pham> getProduct()
        {
            List<San_Pham> l = new List<San_Pham>();
            //--- Khai báo 1 đối tượng đại diện cho Database
             DbContext cn = new DbContext("name=BanHangEntities1");
            l = cn.Set<San_Pham>().ToList<San_Pham>();
            return l;
        }
        ///<summary>Hàng lấy theo danh sách tất cả các sản phẩm </summary>
        public static List<San_Pham> getProductByLoaiSanPham(int maLoai)
        {
            List<San_Pham> l = new List<San_Pham>();
            //--- Khai báo 1 đối tượng đại diện cho Database 
            DbContext cn = new DbContext("name=BanHangEntities1");
            //--- Lấy dữ liệu
            l = cn.Set<San_Pham>().Where(x => x.maLoai == maLoai).OrderByDescending(z => z.ngayDang).ToList<San_Pham>();
            return l;
        }
        ///<summary>hàm cho phép lấy ra danh sách các chủng loại sản phẩm
        public static List<LoaiSanPham> getCategories()
        {
            return new DbContext("name=BanHangEntities1").Set<LoaiSanPham>().ToList<LoaiSanPham>();
        }
        ///<summary> Lấy ra n bài viết mới nhất từ Database
        public static List<BaiViet> getArticles(int n)
        {
            List<BaiViet> l = new List<BaiViet>();
            BanHangEntities1 db = new BanHangEntities1();
            l = db.BaiViets.Where(m => m.daDuyet == true).OrderByDescending(bv => bv.ngayDang).Take(n).ToList<BaiViet>();
            return l;
        }
        public static LoaiSanPham GetLoaiSanPhamById(String maLoai)
        {
            DbContext cn = new DbContext("name=BanHangEntities1");
            return cn.Set<LoaiSanPham>().Find(maLoai);
        }
        /// <summary>
        ///  Phương thức cho phép lấy thông tin của một sản phẩm dựa vào mã của sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns> Đối tượng sản phẩm lấy được từ Data Model</returns>
        public static San_Pham GetProductById(String maSP)
        {
            return cn.Set<San_Pham>().Find(maSP);
        }
        /// <summary>
        /// Lấy tên sản phẩm dựa vào mã 
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string GetNameOfProductByID(string maSP)
        {
            return cn.Set<San_Pham>().Find(maSP).tenSP;
        }
        /// <summary>
        /// Lấy đường dẫn hình đại diện dựa vào mã sản phẩm
        /// </summary>
        /// <param name="maSP"></param>
        /// <returns></returns>
        public static string GetIamgeOfProductByID(string maSP)
        {
            return cn.Set<San_Pham>().Find(maSP).hinhDD;
        }

    }
}
