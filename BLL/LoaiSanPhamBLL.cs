using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LoaiSanPhamBLL
    {
        LoaiSanPhamDAL loaiSanPhamDal = new LoaiSanPhamDAL();
        public LoaiSanPhamBLL() { }
        public List<LoaiSanPham> GetAll()
        {
            return loaiSanPhamDal.GetAll();
        }
    }
}
