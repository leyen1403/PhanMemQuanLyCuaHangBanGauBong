using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO; // Giả sử bạn có DTO trong dự án của mình

namespace DAL
{
    public class KichThuocDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public KichThuocDAL() { }

        // Phương thức thêm kích thước mới
        public void Add(KichThuoc kichThuoc)
        {
            try
            {
                db.KichThuocs.InsertOnSubmit(kichThuoc);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error adding size: " + ex.Message);
            }
        }

        // Phương thức xóa kích thước theo Id
        public void Delete(string id)
        {
            try
            {
                var kichThuoc = db.KichThuocs.FirstOrDefault(k => k.MaKichThuoc == id);
                if (kichThuoc != null)
                {
                    db.KichThuocs.DeleteOnSubmit(kichThuoc);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error deleting size: " + ex.Message);
            }
        }

        // Phương thức sửa thông tin kích thước
        public void Update(KichThuoc updatedKichThuoc)
        {
            try
            {
                var kichThuoc = db.KichThuocs.FirstOrDefault(k => k.MaKichThuoc == updatedKichThuoc.MaKichThuoc);
                if (kichThuoc != null)
                {
                    kichThuoc.MaKichThuoc = updatedKichThuoc.MaKichThuoc;
                    kichThuoc.TenKichThuoc = updatedKichThuoc.TenKichThuoc;
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error updating size: " + ex.Message);
            }
        }

        // Phương thức lấy tất cả kích thước
        public List<KichThuoc> GetAll()
        {
            try
            {
                return db.KichThuocs.ToList();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error fetching all sizes: " + ex.Message);
                return new List<KichThuoc>(); // Trả về danh sách rỗng khi có lỗi
            }
        }

        // Phương thức tìm kiếm kích thước theo mã hoặc tên
        public List<KichThuoc> Search(string keyword)
        {
            try
            {
                return db.KichThuocs
                        .Where(k => k.MaKichThuoc.Contains(keyword) || k.TenKichThuoc.Contains(keyword))
                        .ToList();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error searching size: " + ex.Message);
                return new List<KichThuoc>(); // Trả về danh sách rỗng khi có lỗi
            }
        }
    }
}
