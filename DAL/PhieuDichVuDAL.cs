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
                db.PhieuDichVus.InsertOnSubmit(phieuDichVu);
                db.SubmitChanges();

                var khachHang = db.KhachHangs.Where(kh => kh.MaKhachHang == phieuDichVu.MaKhachHang).FirstOrDefault();

                if (khachHang != null)
                {
                    decimal tongTien = phieuDichVu.TongTien ?? 0;

                    // Tính toán điểm tích lũy: DiemTichLuy = TongTien * 0.1
                    khachHang.DiemTichLuy = khachHang.DiemTichLuy + tongTien * 0.01m;  
                    db.SubmitChanges();
                }

                return "Success";  
            }
            catch (Exception ex)
            {
                return "Lỗi khi lưu phiếu dịch vụ và cập nhật điểm tích lũy: " + ex.Message;
            }

        }

        public string UpdatePhieuDichVu(PhieuDichVu phieuDichVu)
        {
            try
            {
                var existingPhieuDichVu = db.PhieuDichVus.FirstOrDefault(pdv => pdv.MaPhieuDichVu == phieuDichVu.MaPhieuDichVu);

                if (existingPhieuDichVu != null)
                {
                    existingPhieuDichVu.TrangThai = phieuDichVu.TrangThai;
                    existingPhieuDichVu.NgayCapNhat = phieuDichVu.NgayCapNhat;  // Cập nhật ngày hiện tại

                    db.SubmitChanges();
                    return "Success";
                }
                else
                {
                    return "Phiếu dịch vụ không tồn tại.";
                }
            }
            catch (Exception ex)
            {
                return "Lỗi khi cập nhật phiếu dịch vụ: " + ex.Message;
            }
        }




    }
}
