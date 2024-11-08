using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class SanPhamDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public SanPhamDAL() { }
        public List<SanPham> GetProductList()
        {
            var productList = db.SanPhams.ToList<SanPham>();
            return productList;
        }
        public SanPham GetProductById(string id)
        {
            return db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);
        }
        public List<SanPham> GetProductByName(string name)
        {
            return db.SanPhams.Where(sp => sp.TenSanPham == name).ToList<SanPham>();
        }
        public List<SanPham> GetProductByType(string typeId)
        {
            return db.SanPhams.Where(sp => sp.MaLoai == typeId).ToList<SanPham>();
        }
        public bool UpdateProduct(SanPham sanPham)
        {
            try
            {
                SanPham sp = db.SanPhams.FirstOrDefault(s => s.MaSanPham == sanPham.MaSanPham);
                sp.SoLuongTon = sanPham.SoLuongTon;
                sp.NgayCapNhat = sanPham.NgayCapNhat;
                sp.SoLuongToiThieu = sanPham.SoLuongToiThieu;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //hoàng quân 
        // Phương thức tìm kiếm theo bất kỳ tiêu chí
        public List<SanPham> SearchProducts(string keyword)
        {
            return db.SanPhams.Where(sp =>
                sp.MaSanPham.Contains(keyword) ||
                sp.TenSanPham.Contains(keyword) ||
                sp.MaLoai.Contains(keyword) ||
                sp.MoTa.Contains(keyword)
            ).ToList();
        }

        // Phương thức thêm sản phẩm mới
        public bool AddProduct(SanPham newProduct)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(newProduct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Phương thức sửa thông tin sản phẩm
        public bool UpdateProductInList(SanPham updatedProduct)
        {
            try
            {
                var product = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == updatedProduct.MaSanPham);
                if (product != null)
                {
                    product.TenSanPham = updatedProduct.TenSanPham;
                    product.DonViTinh = updatedProduct.DonViTinh;
                    product.SoLuongTon = updatedProduct.SoLuongTon;
                    product.SoLuongToiThieu = updatedProduct.SoLuongToiThieu;
                    product.GiaNhap = updatedProduct.GiaNhap;
                    product.GiaBan = updatedProduct.GiaBan;
                    product.MoTa = updatedProduct.MoTa;
                    product.HinhAnh = updatedProduct.HinhAnh;
                    product.TrangThai = updatedProduct.TrangThai;
                    product.NgayCapNhat = DateTime.Now;
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
        public void UpdateTrangThaiSanPham(string maSanPham, bool trangThai)
        {
            try
            {
                var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == maSanPham);
                if (sanPham != null)
                {
                    sanPham.TrangThai = trangThai;  // Cập nhật trạng thái sản phẩm (0 = xóa, 1 = khôi phục)
                    sanPham.NgayCapNhat = DateTime.Now; // Cập nhật thời gian chỉnh sửa
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật trạng thái sản phẩm: " + ex.Message);
            }
        }
    }
}

