using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class SanPhamMauSacBLL
    {
        private SanPhamMauSacDAL dal = new SanPhamMauSacDAL();

        public bool AddProductColor(string maSanPham, string maMau)
        {
            return dal.AddProductColor(maSanPham, maMau);
        }

        public bool UpdateProductColor(string maSanPham, string oldMaMau, string newMaMau)
        {
            return dal.UpdateProductColor(maSanPham, oldMaMau, newMaMau);
        }

        public bool DeleteProductColor(string maSanPham, string maMau)
        {
            return dal.DeleteProductColor(maSanPham, maMau);
        }
        public string GetOldProductColor(string maSanPham)
        {
            return dal.GetOldProductColor(maSanPham);
        }
    }
}
