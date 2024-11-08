using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuKiemKeDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public PhieuKiemKeDAL() { }
        public List<PhieuKiemKe> GetListPhieuKiemKe()
        {
            var listPhieuKiemKe = db.PhieuKiemKes.ToList<PhieuKiemKe>();
            return listPhieuKiemKe;
        }
        public bool InsertPhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            try
            {
                db.PhieuKiemKes.InsertOnSubmit(phieuKiemKe);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
