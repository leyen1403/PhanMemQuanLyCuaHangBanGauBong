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

    }
}
