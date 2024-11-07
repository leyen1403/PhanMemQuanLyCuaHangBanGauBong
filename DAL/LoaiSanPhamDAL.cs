using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO; // Giả sử bạn có DTO trong dự án của mình

namespace DAL
{
    public class LoaiSanPhamDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public LoaiSanPhamDAL() { }

        // Phương thức thêm loại sản phẩm mới
        public bool Add(LoaiSanPham loaiSanPham)
        {
            try
            {
                db.LoaiSanPhams.InsertOnSubmit(loaiSanPham);
                db.SubmitChanges();
                return true; // Thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error adding product category: " + ex.Message);
                return false; // Thêm thất bại
            }
        }

        // Phương thức xóa loại sản phẩm theo Id
        public bool Delete(string id)
        {
            try
            {
                var loaiSanPham = db.LoaiSanPhams.FirstOrDefault(lsp => lsp.MaLoai == id);
                if (loaiSanPham != null)
                {
                    db.LoaiSanPhams.DeleteOnSubmit(loaiSanPham);
                    db.SubmitChanges();
                    return true; // Xóa thành công
                }
                return false; // Không tìm thấy loại sản phẩm để xóa
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error deleting product category: " + ex.Message);
                return false; // Xóa thất bại
            }
        }

        // Phương thức sửa thông tin loại sản phẩm
        public bool Update(LoaiSanPham updatedLoaiSanPham)
        {
            try
            {
                var loaiSanPham = db.LoaiSanPhams.FirstOrDefault(lsp => lsp.MaLoai == updatedLoaiSanPham.MaLoai);
                if (loaiSanPham != null)
                {
                    loaiSanPham.MaLoai = updatedLoaiSanPham.MaLoai;
                    loaiSanPham.TenLoai = updatedLoaiSanPham.TenLoai;
                    db.SubmitChanges();
                    return true; // Cập nhật thành công
                }
                return false; // Không tìm thấy loại sản phẩm để sửa
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error updating product category: " + ex.Message);
                return false; // Cập nhật thất bại
            }
        }

        // Phương thức lấy tất cả loại sản phẩm
        public List<LoaiSanPham> GetAll()
        {
            try
            {
                return db.LoaiSanPhams.ToList();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error fetching all product categories: " + ex.Message);
                return new List<LoaiSanPham>(); // Trả về danh sách rỗng khi có lỗi
            }
        }

        // Phương thức tìm kiếm loại sản phẩm theo mã hoặc tên
        public List<LoaiSanPham> Search(string keyword)
        {
            try
            {
                return db.LoaiSanPhams
                        .Where(lsp => lsp.MaLoai.Contains(keyword) || lsp.TenLoai.Contains(keyword))
                        .ToList();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                Console.WriteLine("Error searching product category: " + ex.Message);
                return new List<LoaiSanPham>(); // Trả về danh sách rỗng khi có lỗi
            }
        }
    }
}
