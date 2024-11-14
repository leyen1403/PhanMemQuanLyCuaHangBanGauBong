using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public PhieuNhapDAL() { }
        public List<PhieuNhap> GetListPhieuNhap()
        {
            return db.PhieuNhaps.ToList();
        }
        
    }
}
