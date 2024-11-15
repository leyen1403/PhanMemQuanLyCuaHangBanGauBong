using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuNhapBLL
    {
        ChiTietPhieuNhapDAL chiTietPhieuNhapDAL = new ChiTietPhieuNhapDAL();
        public List<ChiTietPhieuNhap> getAllChiTietPhieuNhap()
        {
            return chiTietPhieuNhapDAL.GetListChiTietPhieuNhap();
        }
        public List<ChiTietPhieuNhap> GetChiTietPhieuNhapByMaPN(string maPN)
        {
            return chiTietPhieuNhapDAL.SearchCTPhieuNhapByMaPN(maPN);
        }
        public string GetProductNameByMaCTDDH(string maCTDDH)
        {
            return chiTietPhieuNhapDAL.LayProductNameByMaCTDDH(maCTDDH);
        }
        public string GetChiTietPhieuNhapByCode(string maCTPN)
        {
            return chiTietPhieuNhapDAL.GetChiTietPhieuNhapByCode(maCTPN);
        }

        public bool AddChiTietPhieuNhap(ChiTietPhieuNhap maCTPN)
        {
            return chiTietPhieuNhapDAL.AddChiTietPhieuNhap(maCTPN);
        }



    }
}
