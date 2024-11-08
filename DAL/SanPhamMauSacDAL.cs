using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class SanPhamMauSacDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        // Thêm mới màu sắc cho sản phẩm
        public bool AddProductColor(string maSanPham, string maMau)
        {
            try
            {
                SanPham_MauSac spMauSac = new SanPham_MauSac
                {
                    MaSanPham = maSanPham,
                    MaMau = maMau
                };
                db.SanPham_MauSacs.InsertOnSubmit(spMauSac);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Sửa màu sắc của sản phẩm (thay đổi mã màu)
        public bool UpdateProductColor(string maSanPham, string oldMaMau, string newMaMau)
        {
            try
            {
                var spMauSac = db.SanPham_MauSacs.FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaMau == oldMaMau);
                if (spMauSac != null)
                {
                    spMauSac.MaMau = newMaMau;
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
        // Xóa màu sắc của sản phẩm
        public bool DeleteProductColor(string maSanPham, string maMau)
        {
            try
            {
                var spMauSac = db.SanPham_MauSacs
                    .FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaMau == maMau);
                if (spMauSac != null)
                {
                    db.SanPham_MauSacs.DeleteOnSubmit(spMauSac);
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

        // Lấy danh sách màu sắc của sản phẩm
        public List<SanPham_MauSac> GetProductColors(string maSanPham)
        {
            return db.SanPham_MauSacs.Where(s => s.MaSanPham == maSanPham).ToList();
        }
    }
}
