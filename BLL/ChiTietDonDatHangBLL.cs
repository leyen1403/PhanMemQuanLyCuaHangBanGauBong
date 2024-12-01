using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ChiTietDonDatHangBLL
    {
        public ChiTietDonDatHangBLL()
        {
        }
        ChiTietDonDatHangDAL ctdhDAL = new ChiTietDonDatHangDAL();
        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDonDatHang(string id)
        {
            return ctdhDAL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(id);
        }
        public string GetMaCTDDHByMaSanPham(string maSP)
        {
            return ctdhDAL.GetMaCTDDHByMaSanPham(maSP);
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return ctdhDAL.LayDanhSachChiTietDonDatHang();
        }

        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            return ctdhDAL.ThemChiTietDonDatHang(ctdh);
        }
        public bool XoaChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            return ctdhDAL.XoaChiTietDonDatHang(ctddh);
        }
        public bool CapNhatChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            return ctdhDAL.CapNhatChiTietDonDatHang(ctddh);
        }

        public string LayMaChiTietDonDatHangCuoi()
        {
            var danhSachChiTiet = ctdhDAL.LayDanhSachChiTietDonDatHang();
            if (!danhSachChiTiet.Any())
            {
                return null; // Or handle it in another appropriate way
            }
            return danhSachChiTiet.Last().MaChiTietDonDatHang;
        }

        public ChiTietDonDatHang LayChiTietDOnDatHangBangMaCTDDH(string maCTDDH)
        {
            return ctdhDAL.LayDanhSachChiTietDonDatHang().Where(ct => ct.MaChiTietDonDatHang == maCTDDH).FirstOrDefault();
        }
    }
}
