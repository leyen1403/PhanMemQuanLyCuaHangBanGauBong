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

        public bool IsExist(string maCTPN)
        {
            return chiTietPhieuNhapDAL.IsExist(maCTPN);
        }

        public List<string> GetAllMaCTPhieuNhap()
        {
            List<ChiTietPhieuNhap> danhSachCTPhieuNhap = getAllChiTietPhieuNhap();

            // Trích xuất danh sách mã phiếu nhập
            List<string> danhSachCTMaPN = danhSachCTPhieuNhap
                .Select(pn => pn.MaChiTietPhieuNhap)
                .ToList();

            return danhSachCTMaPN;
        }
        public List<ChiTietPhieuNhap> GetChiTietPhieuNhapByMaPN(string maPN)
        {
            return chiTietPhieuNhapDAL.SearchCTPhieuNhapByMaPN(maPN);
        }
        public string GetProductNameByMaCTDDH(string maCTDDH)
        {
            return chiTietPhieuNhapDAL.LayProductNameByMaCTDDH(maCTDDH);
        }
        public string GetProductIdByMaCTDDH(string maCTDDH)
        {
            return chiTietPhieuNhapDAL.LayProductIdByMaCTDDH(maCTDDH);
        }
        public string GetProductIdByMaDDH(string maDDH)
        {
            return chiTietPhieuNhapDAL.LayProductIdByMaDDH(maDDH);
        }
        public string GetChiTietPhieuNhapByCode(string maCTPN)
        {
            return chiTietPhieuNhapDAL.GetChiTietPhieuNhapByCode(maCTPN);
        }

        public bool AddChiTietPhieuNhap(ChiTietPhieuNhap maCTPN)
        {
            return chiTietPhieuNhapDAL.AddChiTietPhieuNhap(maCTPN);
        }
        public bool UpdateChiTietPhieuNhapList(List<ChiTietPhieuNhap> updatedList, string maPN)
        {
            return chiTietPhieuNhapDAL.UpdateChiTietPhieuNhapList(updatedList, maPN);
        }



    }
}
