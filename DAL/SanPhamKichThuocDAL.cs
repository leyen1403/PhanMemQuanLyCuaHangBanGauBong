using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class SanPhamKichThuocDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        // Thêm mới kích thước cho sản phẩm
        public bool AddProductSize(string maSanPham, string maKichThuoc)
        {
            try
            {
                SanPham_KichThuoc spKichThuoc = new SanPham_KichThuoc
                {
                    MaSanPham = maSanPham,
                    MaKichThuoc = maKichThuoc
                };
                db.SanPham_KichThuocs.InsertOnSubmit(spKichThuoc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Sửa kích thước của sản phẩm (thay đổi mã kích thước)
        public bool UpdateProductSize(string maSanPham, string oldMaKichThuoc, string newMaKichThuoc)
        {
            try
            {
                var spKichThuoc = db.SanPham_KichThuocs.FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaKichThuoc == oldMaKichThuoc);
                if (spKichThuoc != null)
                {
                    spKichThuoc.MaKichThuoc = newMaKichThuoc;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        // Xóa kích thước của sản phẩm
        public bool DeleteProductSize(string maSanPham, string maKichThuoc)
        {
            try
            {
                var spKichThuoc = db.SanPham_KichThuocs
                    .FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaKichThuoc == maKichThuoc);
                if (spKichThuoc != null)
                {
                    db.SanPham_KichThuocs.DeleteOnSubmit(spKichThuoc);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Lấy danh sách kích thước của sản phẩm
        public List<SanPham_KichThuoc> GetProductSizes(string maSanPham)
        {
            return db.SanPham_KichThuocs.Where(s => s.MaSanPham == maSanPham).ToList();
        }
    }
}
