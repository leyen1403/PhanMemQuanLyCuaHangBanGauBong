using System;
using System.Collections.Generic;
using DAL; // Đảm bảo bạn đã thêm tham chiếu đến lớp DAL
using DTO; // Đảm bảo bạn đã thêm tham chiếu đến lớp DTO

namespace BLL
{
    public class KichThuocBLL
    {
        private KichThuocDAL _kichThuocDAL;

        // Constructor để khởi tạo đối tượng KichThuocDAL
        public KichThuocBLL()
        {
            _kichThuocDAL = new KichThuocDAL(); // Khởi tạo DAL
        }

        // Phương thức thêm kích thước mới
        public bool Add(KichThuoc kichThuoc)
        {
            // Kiểm tra điều kiện trước khi thêm (ví dụ: kiểm tra xem kích thước đã tồn tại chưa)
            if (kichThuoc == null || string.IsNullOrEmpty(kichThuoc.MaKichThuoc))
            {
                Console.WriteLine("Invalid data!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện thêm
            return _kichThuocDAL.Add(kichThuoc);
        }

        // Phương thức xóa kích thước theo Id
        public bool Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("Invalid ID!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện xóa
            return _kichThuocDAL.Delete(id);
        }

        // Phương thức sửa thông tin kích thước
        public bool Update(KichThuoc updatedKichThuoc)
        {
            if (updatedKichThuoc == null || string.IsNullOrEmpty(updatedKichThuoc.MaKichThuoc))
            {
                Console.WriteLine("Invalid data!");
                return false;
            }

            // Gọi phương thức DAL để thực hiện sửa
            return _kichThuocDAL.Update(updatedKichThuoc);
        }

        // Phương thức lấy tất cả kích thước
        public List<KichThuoc> GetAll()
        {
            return _kichThuocDAL.GetAll();
        }

        // Phương thức tìm kiếm kích thước theo mã hoặc tên
        public List<KichThuoc> Search(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
            {
                Console.WriteLine("Search keyword is required.");
                return new List<KichThuoc>();
            }

            return _kichThuocDAL.Search(keyword);
        }
    }
}
