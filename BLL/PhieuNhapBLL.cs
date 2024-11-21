using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL phieuNhapDAL = new PhieuNhapDAL();
        public List<PhieuNhap> getAllPhieuNhap()
        {
            return phieuNhapDAL.GetListPhieuNhap();
        }
        public List<string> GetAllMaPhieuNhap()
        {
            List<PhieuNhap> danhSachPhieuNhap = getAllPhieuNhap();

            // Trích xuất danh sách mã phiếu nhập
            List<string> danhSachMaPN = danhSachPhieuNhap
                .Select(pn => pn.MaPhieuNhap) 
                .ToList();

            return danhSachMaPN;
        }


        public bool AddPhieuNhap(PhieuNhap phieuNhap)
        {
            return phieuNhapDAL.AddPhieuNhap(phieuNhap);
        }
        public List<PhieuNhap> GetListPhieuNhapByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return phieuNhapDAL.GetListPhieuNhapByDate(ngayBatDau, ngayKetThuc);
        }
        public List<PhieuNhap> GetListPhieuNhapByNhanVien(string maNV)
        {
            return phieuNhapDAL.GetListPhieuNhapByNhanVien(maNV);
        }
        public List<PhieuNhap> GetListPhieuNhapByDonDatHang(string maDDH)
        {
            return phieuNhapDAL.GetListPhieuNhapByDonDatHang(maDDH);
        }
        public bool UpdateTongTien(string maPN, decimal tongTien)
        {
            return phieuNhapDAL.UpdateTongTien(maPN, tongTien);
        }
        public bool DeletePhieuNhap(string maPN)
        {
            return phieuNhapDAL.DeletePhieuNhap(maPN);
        }
    }
}
