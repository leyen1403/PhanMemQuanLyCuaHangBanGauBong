using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhieuKiemKeBLL
    {
        PhieuKiemKeDAL phieuKiemKeDAL = new PhieuKiemKeDAL();
        public PhieuKiemKeBLL() { }
        public List<PhieuKiemKe> GetListPhieuKiemKe()
        {
            return phieuKiemKeDAL.GetListPhieuKiemKe();
        }
        public bool InsertPhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            return phieuKiemKeDAL.InsertPhieuKiemKe(phieuKiemKe);
        }
    }
}
