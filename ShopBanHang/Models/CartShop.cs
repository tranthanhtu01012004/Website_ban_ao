using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{
    public class CartShop
    {
        public string MaKH {  get; set; }

        public string TaiKhoan { get; set; }

        public DateTime NgayDat { get; set; }

        public DateTime NgayGiao { get; set; }

        public string DiaChi { get; set; }
        //--- SortedList; ... <key> - <Value>
        public SortedList<string, ChiTietDonHang> SanPhamDC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CartShop()
        {
            this.MaKH = ""; this.TaiKhoan = ""; this.DiaChi = "";
            this.NgayDat = DateTime.Now; this.NgayGiao = DateTime.Now.AddDays(2);
            this.SanPhamDC = new SortedList<string, ChiTietDonHang>();
        }
         /// <summary>
         /// phương thức trả về true nếu không có sản phẩm nào đã chọn mua trong hệ thống
         /// </summary>
         /// <returns></returns>
        public bool IsEmpty()
        {
            return (SanPhamDC.Keys.Count == 0);
        }
        /// <summary>
        ///  Phương thức thêm một sản phẩm đã chọn mua vào trong giỏ hàng
        ///  Có 2 tình huống
        /// </summary>
        /// <param name="maSP"></param>
        public void addItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                //  Lấy dữ liệu từ trong giỏ hàng
                ChiTietDonHang s = SanPhamDC.Values[SanPhamDC.IndexOfKey(maSP)];
                //  Tăng số lượng lên 1
                s.soLuong++;
                //  trả lại giỏ hàng sau khi đã cập nhật số lượng
                updateOneItem(s);
            } 
            else
            {
                // Tạo object chi tiết cho đơn hàng mới
                ChiTietDonHang i = new ChiTietDonHang();
                // Cập nhật thông tin hiện hành từ hệ thống cho đối tượng đó
                i.maSP = maSP;
                i.soLuong = 1;
                // Lấy giá bán; Lấy giảm giá từ Table SanPham
                San_Pham z = Common.GetProductById(maSP);
                i.giaBan = z.giaBan;
                i.giamGia = z.giamGia;
                // Bỏ vào danh sách các sản phẩm đã chọn mua trong giỏ hàng của mình
                SanPhamDC.Add(maSP, i);

            }
        }
        /// <summary>
        /// Viết thêm 1 hàm cập nhật dựa vào việc xóa thằng cũ đi, rồi nó thêm trở lại
        /// </summary>
        /// <param name="s"></param>
        public void updateOneItem(ChiTietDonHang s)
        {
            this.SanPhamDC.Remove(s.maSP);
            this.SanPhamDC.Add(s.maSP, s);
        }
        /// <summary>
        ///  Xóa 1 sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void deleteItem(string maSP)
        {
            if (SanPhamDC.Keys.Contains (maSP))
            {
                SanPhamDC.Remove(maSP);
            }    
        }
        /// <summary>
        ///  Cho phép giảm số lượng hoặc xóa sản phẩm đã chọn khỏi danh sách khỏi giỏ hàng
        /// </summary>
        /// <param name="maSP"></param>
        public void decrease(string maSP)
        {
            if (SanPhamDC.Keys.Contains(maSP))
            {
                ChiTietDonHang s = SanPhamDC.Values[SanPhamDC.IndexOfKey (maSP)];
                if (s.soLuong > 1)
                {
                    s.soLuong--;
                    updateOneItem(s);
                }
                else
                    deleteItem(maSP);
            }    
        }
        /// <summary>
        /// Tính trị giá tiền của 1 mặt hàng trong giỏ hàng 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long monneyOfOneProduct(ChiTietDonHang s)
        {
            if (s.giaBan.HasValue && s.soLuong.HasValue)
            {
                long result = (long)(s.giaBan.Value * s.soLuong.Value);
                return result;
            }
            else
            {
                // Handle the case where at least one of the properties is null
                // This might involve returning a default value, throwing an exception, or taking alternative actions based on your requirements.
                // For example:
                throw new InvalidOperationException("One or more properties contain null values. Cannot perform the calculation.");
            }
        }
        /// <summary>
        /// Tính tổng thành tiền cho toàn bộ giả hàng
        /// </summary>
        /// <returns></returns>
        public long totalOfCartShop()
        {
            long kp = 0;
            foreach (ChiTietDonHang i in SanPhamDC.Values)
                kp += monneyOfOneProduct(i);
            return kp;
        }
        
    }
}