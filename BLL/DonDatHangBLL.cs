using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DonDatHangBLL
    {
        public DonDatHangBLL()
        {
        }
        DonDatHangDAL ddhDAL = new DonDatHangDAL();
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return ddhDAL.LayDanhSachDonDatHang();
        }
        public bool ThemDonDatHang(DonDatHang ddh)
        {
            return ddhDAL.ThemDonDatHang(ddh);
        }
    }
}
