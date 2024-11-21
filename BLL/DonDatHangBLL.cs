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
        public List<DonDatHang> LayDanhSachDonDatHang2()
        {
            return ddhDAL.LayDanhSachDonDatHang2();
        }
        public bool ThemDonDatHang(DonDatHang ddh)
        {
            return ddhDAL.ThemDonDatHang(ddh);
        }

        public DonDatHang LayDonDayHang(string maDonDatHang)
        {
            return ddhDAL.LayDonDatHang(maDonDatHang);
        }

        public bool CapNhatDonDatHang(DonDatHang ddh)
        {
            return ddhDAL.CapNhatDonDatHang(ddh);
        }

        public bool XoaDonDatHang(string maDonDatHang)
        {
            return ddhDAL.XoaDonDatHang(maDonDatHang);
        }
    }
}
