using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCapDAL
    {
        public NhaCungCapDAL()
        {
        }
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return db.NhaCungCaps.ToList();
        }
        
    }
}
