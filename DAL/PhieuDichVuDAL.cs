using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuDichVuDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public PhieuDichVuDAL() { }

        // Lấy danh sách phiếu dịch vụ
        public List<PhieuDichVu> GetPhieuDichVuList()
        {
            return db.PhieuDichVus.ToList<PhieuDichVu>();
        }

        // Lấy phiếu dịch vụ theo mã
        public PhieuDichVu GetPhieuDichVuById(string id)
        {
            return db.PhieuDichVus.FirstOrDefault(pdv => pdv.MaPhieuDichVu == id);
        }

        // Phương thức lưu phiếu dịch vụ và cập nhật điểm tích lũy
        public string SavePhieuDichVu(PhieuDichVu phieuDichVu)
        {
            try
            {
                // Lưu phiếu dịch vụ vào bảng PhieuDichVu
                db.PhieuDichVus.InsertOnSubmit(phieuDichVu);
                db.SubmitChanges();

                // Cập nhật điểm tích lũy cho khách hàng
                var khachHang = db.KhachHangs.Where(kh => kh.MaKhachHang == phieuDichVu.MaKhachHang).FirstOrDefault();

                if (khachHang != null)
                {
                    // Kiểm tra nếu TongTien có giá trị null, nếu có thì thay thế bằng 0
                    decimal tongTien = phieuDichVu.TongTien ?? 0;  // Sử dụng 0 nếu TongTien null

                    // Tính toán điểm tích lũy: DiemTichLuy = TongTien * 0.1
                    khachHang.DiemTichLuy = khachHang.DiemTichLuy + tongTien * 0.01m;  // sử dụng 0.1m để đảm bảo kiểu decimal

                    // Cập nhật bảng KhachHang với điểm tích lũy mới
                    db.SubmitChanges();
                }

                return "Success";  // Trả về thông báo thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                return "Lỗi khi lưu phiếu dịch vụ và cập nhật điểm tích lũy: " + ex.Message;
            }

        }




    }
}
