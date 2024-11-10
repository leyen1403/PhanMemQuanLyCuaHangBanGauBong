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
            if (hoaDon == null)
            {
                throw new ArgumentNullException(nameof(hoaDon), "Hóa đơn không thể là null.");
            }

            try
            {
                db.HoaDonBanHangs.InsertOnSubmit(hoaDon);
                db.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // In thông báo lỗi
                return false; // Trả về false nếu có lỗi
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
                var hoaDonList = db.HoaDonBanHangs.ToList();
                // Đảm bảo trả về danh sách trống nếu không có dữ liệu
                return hoaDonList ?? new List<HoaDonBanHang>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<HoaDonBanHang>(); // Trả về danh sách trống khi có lỗi
            }
        }
    }
}
