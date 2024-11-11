using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhatKyDichVuDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public NhatKyDichVuDAL() { }

        // Lấy danh sách nhật ký dịch vụ
        public List<NhatKyDichVu> GetNhatKyDichVuList()
        {
            return db.NhatKyDichVus.ToList();
        }

        // Lưu nhật ký dịch vụ vào cơ sở dữ liệu
        public string SaveNhatKyDichVu(NhatKyDichVu nhatKyDichVu)
        {
            try
            {
                db.NhatKyDichVus.InsertOnSubmit(nhatKyDichVu);
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