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

        // Tìm kiếm sản phẩm dựa vào loại sản phẩm, màu sắc, kích thước
        public List<SanPham> SearchProducts(string maLoaiSanPham = null, string maMau = null, string maKichThuoc = null)
        {
            try
            {
                var query = from sp in db.SanPhams
                            join spMauSac in db.SanPham_MauSacs on sp.MaSanPham equals spMauSac.MaSanPham into spMauSacJoin
                            from spMauSac in spMauSacJoin.DefaultIfEmpty()
                            join mau in db.MauSacs on spMauSac.MaMau equals mau.MaMau into mauJoin
                            from mau in mauJoin.DefaultIfEmpty()
                            join spKichThuoc in db.SanPham_KichThuocs on sp.MaSanPham equals spKichThuoc.MaSanPham into spKichThuocJoin
                            from spKichThuoc in spKichThuocJoin.DefaultIfEmpty()
                            join kichThuoc in db.KichThuocs on spKichThuoc.MaKichThuoc equals kichThuoc.MaKichThuoc into kichThuocJoin
                            from kichThuoc in kichThuocJoin.DefaultIfEmpty()
                            where (string.IsNullOrEmpty(maLoaiSanPham) || sp.MaLoai == maLoaiSanPham)
                               && (string.IsNullOrEmpty(maMau) || spMauSac.MaMau == maMau)
                               && (string.IsNullOrEmpty(maKichThuoc) || spKichThuoc.MaKichThuoc == maKichThuoc)
                            select sp;

                return query.Distinct().ToList();
            }
            catch
            {
                return new List<SanPham>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        // Hàm tìm kiếm sản phẩm dựa trên thông tin trong bảng SanPham
        public List<SanPham> SearchProductsOnList(string searchText)
        {
            try
            {
                var query = from sp in db.SanPhams
                            where (string.IsNullOrEmpty(searchText) ||
                                sp.MaSanPham.Contains(searchText) || // Tìm theo mã sản phẩm
                                sp.TenSanPham.Contains(searchText) || // Tìm theo tên sản phẩm
                                sp.MaLoai.Contains(searchText)|| sp.MoTa.Contains(searchText)) // Tìm theo mã loại sản phẩm mô tả
                            select sp;

                return query.Distinct().ToList();
            }
            catch (Exception ex)
            {
                // Ghi log hoặc xử lý lỗi nếu cần
                Console.WriteLine(ex.Message);
                return new List<SanPham>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }

        // xử lý hoá đơn
        // Phương thức lấy tất cả sản phẩm không trùng tên
        public List<SanPham> GetUniqueProducts()
        {
            try
            {
                // Lấy tất cả sản phẩm từ cơ sở dữ liệu
                var allProducts = db.SanPhams.Where(sp => sp.TrangThai==true).ToList();

                // Lọc ra các sản phẩm, nếu có nhiều sản phẩm trùng tên thì chỉ lấy một sản phẩm trong nhóm đó
                var uniqueProducts = allProducts
                    .GroupBy(sp => sp.TenSanPham)  // Nhóm theo tên sản phẩm
                    .Select(g => g.First())        // Lấy sản phẩm đầu tiên trong mỗi nhóm (ngay cả khi có nhiều sản phẩm trùng tên)
                    .ToList();

                return uniqueProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm không trùng tên: " + ex.Message);
                return new List<SanPham>();  // Trả về danh sách rỗng nếu có lỗi
            }
        }

        public List<KichThuoc> GetAllSizesByProductName(string productName)
        {
            try
            {
                // Truy vấn kết hợp giữa SanPham và SanPham_KichThuoc
                var sizes = from sp in db.SanPhams
                            join spKichThuoc in db.SanPham_KichThuocs on sp.MaSanPham equals spKichThuoc.MaSanPham
                            join kichThuoc in db.KichThuocs on spKichThuoc.MaKichThuoc equals kichThuoc.MaKichThuoc
                            where sp.TenSanPham == productName  // Lọc theo tên sản phẩm
                            select kichThuoc;  // Chọn kích thước tương ứng

                return sizes.Distinct().ToList();  // Trả về danh sách kích thước không trùng lặp
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy kích thước sản phẩm: " + ex.Message);
                return new List<KichThuoc>();  // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public List<MauSac> GetAllColorsByProductName(string productName)
        {
            try
            {
                // Truy vấn kết hợp giữa SanPham và SanPham_MauSac
                var colors = from sp in db.SanPhams
                             join spMauSac in db.SanPham_MauSacs on sp.MaSanPham equals spMauSac.MaSanPham
                             join mauSac in db.MauSacs on spMauSac.MaMau equals mauSac.MaMau
                             where sp.TenSanPham == productName  // Lọc theo tên sản phẩm
                             select mauSac;  // Chọn màu sắc tương ứng

                return colors.Distinct().ToList();  // Trả về danh sách màu sắc không trùng lặp
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy màu sắc sản phẩm: " + ex.Message);
                return new List<MauSac>();  // Trả về danh sách rỗng nếu có lỗi
            }
        }
        // Phương thức tìm mã sản phẩm theo tên, màu sắc và kích thước
        public string GetProductCodesByNameColorSize(string productName, string color, string size)
        {
            try
            {
                var query = from sp in db.SanPhams
                            join spMauSac in db.SanPham_MauSacs on sp.MaSanPham equals spMauSac.MaSanPham into spMauSacJoin
                            from spMauSac in spMauSacJoin.DefaultIfEmpty()
                            join mau in db.MauSacs on spMauSac.MaMau equals mau.MaMau into mauJoin
                            from mau in mauJoin.DefaultIfEmpty()
                            join spKichThuoc in db.SanPham_KichThuocs on sp.MaSanPham equals spKichThuoc.MaSanPham into spKichThuocJoin
                            from spKichThuoc in spKichThuocJoin.DefaultIfEmpty()
                            join kichThuoc in db.KichThuocs on spKichThuoc.MaKichThuoc equals kichThuoc.MaKichThuoc into kichThuocJoin
                            from kichThuoc in kichThuocJoin.DefaultIfEmpty()
                            where (string.IsNullOrEmpty(productName) || sp.TenSanPham.Contains(productName))
                                  && (string.IsNullOrEmpty(color) || (mau != null && mau.TenMau.Contains(color)))
                                  && (string.IsNullOrEmpty(size) || (kichThuoc != null && kichThuoc.TenKichThuoc.Contains(size)))
                            select sp.MaSanPham;

                // Trả về mã sản phẩm đầu tiên, hoặc có thể sử dụng ToList() nếu cần tất cả mã sản phẩm
                return query.Distinct().FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm mã sản phẩm: " + ex.Message);
                return null;  // Trả về null nếu có lỗi
            }
        }

        // Phương thức lấy giá bán của sản phẩm dựa trên mã sản phẩm
        public decimal GetProductPriceByCode(string productCode)
        {
            try
            {
                var product = db.SanPhams
                                .FirstOrDefault(sp => sp.MaSanPham == productCode);

                if (product != null)
                {
                    return product.GiaBan ?? 0;  // Trả về 0 nếu GiaBan là null
                }
                else
                {
                    return 0;  // Trả về giá 0 nếu không tìm thấy sản phẩm
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy giá sản phẩm: " + ex.Message);
                return 0;  // Trả về 0 nếu có lỗi
            }
        }

        // Phương thức lấy danh sách sản phẩm không trùng tên theo mã loại
        public List<SanPham> GetUniqueProductsByCategory(string maLoai)
        {
            try
            {
                // Lấy tất cả sản phẩm từ cơ sở dữ liệu theo mã loại và trạng thái
                var allProducts = db.SanPhams
                    .Where(sp => sp.TrangThai == true && sp.MaLoai == maLoai)
                    .ToList();

                // Lọc ra các sản phẩm không trùng tên
                var uniqueProducts = allProducts
                    .GroupBy(sp => sp.TenSanPham)  // Nhóm theo tên sản phẩm
                    .Select(g => g.First())        // Lấy sản phẩm đầu tiên trong mỗi nhóm
                    .ToList();

                return uniqueProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm không trùng tên: " + ex.Message);
                return new List<SanPham>();  // Trả về danh sách rỗng nếu có lỗi
            }
        }

        public List<SanPham> GetUniqueProducts(string searchKeyword = "")
        {
            try
            {
                var allProducts = db.SanPhams
                    .Where(sp => sp.TrangThai == true)
                    .AsQueryable(); 

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    allProducts = allProducts
                        .Where(sp => sp.TenSanPham.Contains(searchKeyword) || sp.MaSanPham.Contains(searchKeyword));
                }

                var uniqueProducts = allProducts
                    .GroupBy(sp => sp.TenSanPham)  
                    .Select(g => g.First())        
                    .ToList();

                return uniqueProducts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy danh sách sản phẩm không trùng tên: " + ex.Message);
                return new List<SanPham>();  
            }
        }
        public List<SanPham> GetSanPhamByMaSP(string maSanPham)
        {
            try
            {
                // Truy vấn cơ sở dữ liệu để lấy danh sách sản phẩm theo mã sản phẩm
                var sanPhams = db.SanPhams
                                 .Where(sp => sp.MaSanPham == maSanPham && sp.TrangThai == true)
                                 .ToList();

                return sanPhams;
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có
                Console.WriteLine("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
                return new List<SanPham>(); // Trả về danh sách rỗng nếu có lỗi
            }
        }
        public SanPhamGioHangDTO GetSanPhamByMaSanPham(string maSanPham)
        {
            var query = (from sp in db.SanPhams
                         join sp_mauSac in db.SanPham_MauSacs on sp.MaSanPham equals sp_mauSac.MaSanPham
                         join mauSac in db.MauSacs on sp_mauSac.MaMau equals mauSac.MaMau
                         join sp_kichThuoc in db.SanPham_KichThuocs on sp.MaSanPham equals sp_kichThuoc.MaSanPham
                         join kichThuoc in db.KichThuocs on sp_kichThuoc.MaKichThuoc equals kichThuoc.MaKichThuoc
                         where sp.MaSanPham == maSanPham && sp.TrangThai == true
                         select new SanPhamGioHangDTO
                         {
                             MaSanPham = sp.MaSanPham,
                             TenSanPham = sp.TenSanPham,
                             MauSac = mauSac.TenMau,
                             KichThuoc = kichThuoc.TenKichThuoc,
                             GiaBan = (decimal)sp.GiaBan  // Ép kiểu về decimal nếu cần
                         }).FirstOrDefault();

            return query;
        }

    }
}

