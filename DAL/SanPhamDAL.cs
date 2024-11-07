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
            return db.SanPhams.Where(sp=>sp.MaLoai == typeId).ToList<SanPham>();
        }
    }
}
