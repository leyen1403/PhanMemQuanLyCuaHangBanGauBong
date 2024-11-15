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
    }
}
