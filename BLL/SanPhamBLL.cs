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


    }
}
