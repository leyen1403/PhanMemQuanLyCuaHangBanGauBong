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
        public bool UpdateProductColor(string maSanPham, string oldMaMau, string newMaMau)
        {
            try
            {
                // Check if the old color and new color are the same
                if (oldMaMau == newMaMau)
                {
                    return true; // No need to update if the color is the same
                }

                // Ensure the old color exists for the product
                var spMauSac = db.SanPham_MauSacs.FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaMau == oldMaMau);

                // Check if the product and old color were found
                if (spMauSac != null)
                {
                    // Remove the old color from the product
                    db.SanPham_MauSacs.DeleteOnSubmit(spMauSac);

                    // Ensure the new color is not already set for this product
                    var existingColor = db.SanPham_MauSacs.FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaMau == newMaMau);
                    if (existingColor != null)
                    {
                        // If the new color already exists for this product, return false
                        return false;
                    }

                    // Add the new color for the product
                    var newSpMauSac = new SanPham_MauSac
                    {
                        MaSanPham = maSanPham,
                        MaMau = newMaMau
                    };
                    db.SanPham_MauSacs.InsertOnSubmit(newSpMauSac);

                    // Commit changes to the database
                    db.SubmitChanges();
                    return true;
                }

                return false; // Product or old color not found
            }
            catch (Exception ex)
            {
                // Log the exception message for better debugging
                Console.WriteLine(ex.Message);
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
        // Lấy tên màu sắc của sản phẩm dựa trên mã sản phẩm
        public string GetOldProductColor(string maSanPham)
        {
            try
            {
                var colorName = (from spMauSac in db.SanPham_MauSacs
                                 join mauSac in db.MauSacs on spMauSac.MaMau equals mauSac.MaMau
                                 where spMauSac.MaSanPham == maSanPham
                                 select mauSac.MaMau).FirstOrDefault();

                return colorName; // Trả về tên màu hoặc null nếu không tìm thấy
            }
            catch
            {
                return null; // Trả về null trong trường hợp lỗi
            }
        }

    }
}
