using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamKichThuocBLL
    {
        private SanPhamKichThuocDAL dal = new SanPhamKichThuocDAL();

        public bool AddProductSize(string maSanPham, string maKichThuoc)
        {
            return dal.AddProductSize(maSanPham, maKichThuoc);
        }

        public bool UpdateProductSize(string maSanPham, string oldMaKichThuoc, string newMaKichThuoc)
        {
            return dal.UpdateProductSize(maSanPham, oldMaKichThuoc, newMaKichThuoc);
        }

        public bool DeleteProductSize(string maSanPham, string maKichThuoc)
        {
            return dal.DeleteProductSize(maSanPham, maKichThuoc);
        }

        public string GetOldSize(string maSanPham)
        {
            return dal.GetOldProductSize(maSanPham);
        }
    }
}
