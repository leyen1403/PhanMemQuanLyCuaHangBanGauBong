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
                // Kiểm tra các giá trị đầu vào
                if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(oldMaKichThuoc) || string.IsNullOrEmpty(newMaKichThuoc))
                {
                    return false; // Nếu một trong các giá trị đầu vào là rỗng hoặc null, trả về false
                }

                // Tìm sản phẩm kích thước cũ từ cơ sở dữ liệu
                var spKichThuoc = db.SanPham_KichThuocs.FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaKichThuoc == oldMaKichThuoc);

                // Kiểm tra nếu tìm thấy sản phẩm kích thước
                if (spKichThuoc != null)
                {
                    // Xóa bản ghi cũ
                    db.SanPham_KichThuocs.DeleteOnSubmit(spKichThuoc);

                    // Tạo đối tượng mới với mã kích thước mới
                    SanPham_KichThuoc newSize = new SanPham_KichThuoc
                    {
                        MaSanPham = maSanPham,
                        MaKichThuoc = newMaKichThuoc,
                        // Thêm các thuộc tính khác nếu cần thiết
                    };

                    // Thêm bản ghi mới vào cơ sở dữ liệu
                    db.SanPham_KichThuocs.InsertOnSubmit(newSize);

                    // Lưu thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges();
                    return true; // Trả về true nếu cập nhật thành công
                }
                else
                {
                    return false; // Trả về false nếu không tìm thấy sản phẩm với mã kích thước cũ
                }
            }
            catch (Exception ex)
            {
                // Ghi lại lỗi chi tiết trong trường hợp có exception
                Console.WriteLine("Lỗi khi cập nhật kích thước: " + ex.Message);
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }
        // Xóa kích thước của sản phẩm
        public bool DeleteProductSize(string maSanPham, string maKichThuoc)
        {
            try
            {
                // Kiểm tra xem sản phẩm và kích thước có tồn tại trong cơ sở dữ liệu không
                var spKichThuoc = db.SanPham_KichThuocs
                    .FirstOrDefault(s => s.MaSanPham == maSanPham && s.MaKichThuoc == maKichThuoc);

                if (spKichThuoc != null)
                {
                    db.SanPham_KichThuocs.DeleteOnSubmit(spKichThuoc);

                    // Kiểm tra nếu có thay đổi trước khi gọi SubmitChanges
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    Console.WriteLine("Không tìm thấy bản ghi cần xóa.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa kích thước sản phẩm: " + ex.Message);
                return false;
            }
        }

        // Lấy danh sách kích thước của sản phẩm
        public List<SanPham_KichThuoc> GetProductSizes(string maSanPham)
        {
            return db.SanPham_KichThuocs.Where(s => s.MaSanPham == maSanPham).ToList();
        }
        // Lấy tên kích thước của sản phẩm dựa trên mã sản phẩm
        public string GetOldProductSize(string maSanPham)
        {
            try
            {
                var sizeName = (from spKichThuoc in db.SanPham_KichThuocs
                                join kichThuoc in db.KichThuocs on spKichThuoc.MaKichThuoc equals kichThuoc.MaKichThuoc
                                where spKichThuoc.MaSanPham == maSanPham
                                select kichThuoc.MaKichThuoc).FirstOrDefault();

                return sizeName; // Trả về tên kích thước hoặc null nếu không tìm thấy
            }
            catch
            {
                return null; // Hoặc có thể trả về một giá trị khác nếu cần
            }
        }
    }
}
