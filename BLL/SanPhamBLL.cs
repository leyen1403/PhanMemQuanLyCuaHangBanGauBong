using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class SanPhamBLL
    {
        SanPhamDAL sanPhamDal = new SanPhamDAL();
        public SanPhamBLL() { }
        public List<SanPham> GetProductList()
        {
            return sanPhamDal.GetProductList();
        }
        public SanPham GetProductById(string id)
        {
            return sanPhamDal.GetProductById(id);
        }
        public List<SanPham> GetProductByName(string name)
        {
            return sanPhamDal.GetProductByName(name);
        }
        public List<SanPham> GetProductByType(string typeId)
        {
            return sanPhamDal.GetProductByType(typeId);
        }
        public bool UpdateProduct(SanPham sanPham)
        {
           return sanPhamDal.UpdateProduct(sanPham);
        }
        //hoàng quân
        // Tìm kiếm sản phẩm theo từ khóa bất kỳ
        public List<SanPham> SearchProducts(string keyword)
        {
            return sanPhamDal.SearchProducts(keyword);
        }

        // Thêm mới sản phẩm
        public bool AddProduct(SanPham newProduct)
        {
            if (newProduct != null && ValidateProduct(newProduct))
            {
                return sanPhamDal.AddProduct(newProduct);
            }
            return false;
        }

        // Sửa sản phẩm
        public bool EditProduct(SanPham updatedProduct)
        {
            if (updatedProduct != null && ValidateProduct(updatedProduct))
            {
                return sanPhamDal.UpdateProductInList(updatedProduct);
            }
            return false;
        }
        // Kiểm tra thông tin sản phẩm hợp lệ
        private bool ValidateProduct(SanPham product)
        {
            return !string.IsNullOrEmpty(product.MaSanPham) &&
                   !string.IsNullOrEmpty(product.TenSanPham) &&
                   product.GiaBan >= 0 &&
                   product.SoLuongTon >= 0;
        }

        // Sửa thông tin sản phẩm
        public bool UpdateProductInList(SanPham updatedProduct)
        {
            return sanPhamDal.UpdateProductInList(updatedProduct);
        }

        // Cập nhật trạng thái sản phẩm
        public void UpdateTrangThaiSanPham(string maSanPham, bool trangThai)
        {
            sanPhamDal.UpdateTrangThaiSanPham(maSanPham, trangThai);
        }

        // Lấy danh sách sản phẩm còn hoạt động
        public List<SanPham> GetActiveProductList()
        {
            return GetProductList().Where(sp => sp.TrangThai == true).ToList();
        }
        public List<SanPham> SearchProducts(string maLoaiSanPham = null, string maMau = null, string maKichThuoc = null)
        {
            return sanPhamDal.SearchProducts(maLoaiSanPham, maMau, maKichThuoc);
        }
        public List<SanPham> SearchProductsOnList(string searchText)
        {
            return sanPhamDal.SearchProductsOnList(searchText);
        }
        public List<SanPham> GetUniqueProducts()
        {
            return sanPhamDal.GetUniqueProducts();
        }

        public List<KichThuoc> GetAllSizesByProductName(string productName)
        {
            return sanPhamDal.GetAllSizesByProductName(productName);
        }
        public List<MauSac> GetAllColorsByProductName(string productName)
        {
            return sanPhamDal.GetAllColorsByProductName(productName);
        }
        public string GetProductCodesByNameColorSize(string productName, string color, string size)
        {
            return sanPhamDal.GetProductCodesByNameColorSize(productName, color, size);
        }
        public decimal GetProductPriceByCode(string productCode)
        {
            return sanPhamDal.GetProductPriceByCode(productCode);
        }
        public List<SanPham> GetUniqueProductsByCategory(string maLoai)
        {
            return sanPhamDal.GetUniqueProductsByCategory(maLoai);
        }
        public List<SanPham> GetUniqueProducts(string searchKeyword = "")
        {
            return sanPhamDal.GetUniqueProducts(searchKeyword);
        }
        public List<SanPham> GetSanPhamByMaSP(string maSanPham)
        {
            return sanPhamDal.GetSanPhamByMaSP((string) maSanPham);
        }
        public IQueryable<object> GetSanPhamWithMauSacKichThuocByMaSanPham(string maSanPham)
        {
            return sanPhamDal.GetSanPhamWithMauSacKichThuocByMaSanPham(maSanPham);
        }
    }
}
