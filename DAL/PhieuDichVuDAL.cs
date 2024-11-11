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

        // Lưu phiếu dịch vụ vào cơ sở dữ liệu
        public string SavePhieuDichVu(PhieuDichVu phieuDichVu)
        {
            try
            {
                db.PhieuDichVus.InsertOnSubmit(phieuDichVu);
                db.SubmitChanges();
                return "Success";  // Trả về chuỗi xác nhận nếu thành công
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;  // Trả về chuỗi lỗi nếu có lỗi xảy ra
            }
        }

    }
}
