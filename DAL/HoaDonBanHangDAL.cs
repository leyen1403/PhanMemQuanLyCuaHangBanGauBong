using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class HoaDonBanHangDAL
    {
        // Giả sử bạn có một context của Entity Framework hoặc một đối tượng db liên kết với cơ sở dữ liệu
        private readonly db_QLCHBGBDataContext db;

        public HoaDonBanHangDAL()
        {
           
        }

        // 1. Thêm hóa đơn bán hàng
        public bool AddHoaDonBanHang(HoaDonBanHang hoaDon)
        {
            try
            {
                db.HoaDonBanHangs.InsertOnSubmit(hoaDon); // Thêm vào bảng HoaDonBanHang
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
        }

       
        // 4. Lấy tất cả hóa đơn bán hàng
        public List<HoaDonBanHang> GetAllHoaDonBanHang()
        {
            try
            {
                return db.HoaDonBanHangs.ToList(); // Lấy tất cả các hóa đơn bán hàng
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tất cả hóa đơn: " + ex.Message);
                return null;
            }
        }
    }
}
