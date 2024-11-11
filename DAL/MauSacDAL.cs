using System;
using System.Collections.Generic;
using System.Linq;
using DTO; // Giả sử bạn có DTO trong dự án của mình

namespace DAL
{
    public class MauSacDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public MauSacDAL() { }

        // Phương thức thêm màu sắc mới
        public bool Add(MauSac mauSac)
        {
            try
            {
                db.MauSacs.InsertOnSubmit(mauSac);
                db.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding color: " + ex.Message);
                return false; // Trả về false nếu gặp lỗi
            }
        }

        // Phương thức xóa màu sắc theo Id
        public bool Delete(string id)
        {
            try
            {
                var mauSac = db.MauSacs.FirstOrDefault(ms => ms.MaMau == id);
                if (mauSac != null)
                {
                    db.MauSacs.DeleteOnSubmit(mauSac);
                    db.SubmitChanges();
                    return true; // Trả về true nếu xóa thành công
                }
                return false; // Trả về false nếu không tìm thấy
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting color: " + ex.Message);
                return false; // Trả về false nếu gặp lỗi
            }
        }

        // Phương thức sửa thông tin màu sắc
        public bool Update(MauSac updatedMauSac)
        {
            try
            {
                var mauSac = db.MauSacs.FirstOrDefault(ms => ms.MaMau == updatedMauSac.MaMau);
                if (mauSac != null)
                {
                    mauSac.MaMau = updatedMauSac.MaMau;
                    mauSac.TenMau = updatedMauSac.TenMau;
                    mauSac.MoTa=updatedMauSac.MoTa;
                    mauSac.HinhAnh = updatedMauSac.HinhAnh;
                    db.SubmitChanges();
                    return true; // Trả về true nếu cập nhật thành công
                }
                return false; // Trả về false nếu không tìm thấy
            }
            catch (Exception ex)
            {
                Console.WriteLine("không thể cập nhât " + ex.Message);
                return false; // Trả về false nếu gặp lỗi
            }
        }

        // Phương thức lấy tất cả màu sắc
        public List<MauSac> GetAll()
        {
            try
            {
                return db.MauSacs.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không tìm thấy màu nào: " + ex.Message);
                return new List<MauSac>(); // Trả về danh sách rỗng nếu gặp lỗi
            }
        }

        // Phương thức lấy màu sắc theo mã
        public List<MauSac> GetByMaMau(string keyword)
        {
            try
            {
                return db.MauSacs
                         .Where(ms => ms.MaMau.Contains(keyword) || ms.TenMau.Contains(keyword))
                         .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error searching color: " + ex.Message);
                return new List<MauSac>();
            }
        }

    }
}
