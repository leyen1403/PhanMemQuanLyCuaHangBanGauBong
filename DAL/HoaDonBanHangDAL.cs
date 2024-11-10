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
        // 5. Lấy mã hóa đơn bán hàng mới nhất
        public string GetLatestHoaDonBanHangId()
        {
            try
            {
                // Giả định mã hóa đơn có dạng "HD0001", "HD0002", ...
                var latestHoaDon = db.HoaDonBanHangs
                    .OrderByDescending(hd => int.Parse(hd.MaHoaDonBanHang.Substring(2))) // Lấy phần số từ mã hóa đơn
                    .Select(hd => hd.MaHoaDonBanHang)
                    .FirstOrDefault();

                return latestHoaDon;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy mã hóa đơn mới nhất: " + ex.Message);
                return null; // Trả về null nếu có lỗi
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
