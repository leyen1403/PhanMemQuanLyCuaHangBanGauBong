using System;
using System.Collections.Generic;
using DAL; // Đảm bảo bạn đã thêm tham chiếu đến lớp DAL
using DTO; // Đảm bảo bạn đã thêm tham chiếu đến lớp DTO

namespace BLL
{
    public class LoaiSanPhamBLL
    {
        private LoaiSanPhamDAL _loaiSanPhamDAL;

        // Constructor để khởi tạo đối tượng LoaiSanPhamDAL
        public LoaiSanPhamBLL()
        {
            _loaiSanPhamDAL = new LoaiSanPhamDAL(); // Khởi tạo DAL
        }

        // Phương thức thêm loại sản phẩm mới
        public bool Add(LoaiSanPham loaiSanPham)
        {
            // Kiểm tra điều kiện trước khi thêm (ví dụ: kiểm tra xem loại sản phẩm đã tồn tại chưa)
            if (loaiSanPham == null || string.IsNullOrEmpty(loaiSanPham.MaLoai))
            {
                Console.WriteLine("Invalid data!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện thêm
            return _loaiSanPhamDAL.Add(loaiSanPham);
        }

        // Phương thức xóa loại sản phẩm theo Id
        public bool Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Invalid ID!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện xóa
            return _loaiSanPhamDAL.Delete(id);
        }

        // Phương thức sửa thông tin loại sản phẩm
        public bool Update(LoaiSanPham updatedLoaiSanPham)
        {
            if (updatedLoaiSanPham == null || string.IsNullOrEmpty(updatedLoaiSanPham.MaLoai))
            {
                Console.WriteLine("Invalid data!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện sửa
            return _loaiSanPhamDAL.Update(updatedLoaiSanPham);
        }

        // Phương thức lấy tất cả loại sản phẩm
        public List<LoaiSanPham> GetAll()
        {
            return _loaiSanPhamDAL.GetAll();
        }

        // Phương thức tìm kiếm loại sản phẩm theo mã hoặc tên
        public List<LoaiSanPham> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("Search keyword is required.");
                return new List<LoaiSanPham>();
            }

            return _loaiSanPhamDAL.Search(keyword);
        }
    }
}
