using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonDatHangDAL
    {
        public DonDatHangDAL()
        {
        }
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return db.DonDatHangs.ToList();
        }
        public bool ThemDonDatHang(DonDatHang ddh)
        {
            try
            {
                db.DonDatHangs.InsertOnSubmit(ddh);
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
