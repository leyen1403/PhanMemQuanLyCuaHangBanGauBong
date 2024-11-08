using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuKiemKeBLL
    {
        public ChiTietPhieuKiemKeBLL() { }
        public bool InsertChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().InsertChiTietPhieuKiemKe(chiTietPhieuKiemKe);
        }
        public List<ChiTietPhieuKiemKe> chiTietPhieuKiemKes(string maPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().chiTietPhieuKiemKes(maPhieuKiemKe);
        }
        public bool UpdateChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().UpdateChiTietPhieuKiemKe(chiTietPhieuKiemKe);
        }
    }
}
