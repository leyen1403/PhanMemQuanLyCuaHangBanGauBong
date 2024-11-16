using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhieuDoiTraBLL
    {
        PhieuDoiTraDAL dal;

        public PhieuDoiTraBLL()
        {
            dal = new PhieuDoiTraDAL();
        }

        public HoaDonDTO TimHoaDonTheoMa(string maHD)
        {
            var hoaDon = dal.TimHoaDonTheoMa(maHD);

            if (hoaDon != null)
            {
                var khachHang = dal.TimKhachHangTheoMa(hoaDon.MaKhachHang);
                var nhanVien = dal.TimNhanVienTheoMa(hoaDon.MaNhanVien);

                var hoaDonDTO = new HoaDonDTO();
                hoaDonDTO.MaHoaDon = hoaDon.MaHoaDonBanHang;
                hoaDonDTO.NgayLap = hoaDon.NgayLap;
                hoaDonDTO.TongSanPham = hoaDon.TongSanPham;
                hoaDonDTO.TongTien = hoaDon.TongTien;
                hoaDonDTO.DiemCongTichLuy = hoaDon.DiemCongTichLuy;
                hoaDonDTO.DiemTichLuy = hoaDon.DiemTichLuy;
                hoaDonDTO.MaKhachHang = hoaDon.MaKhachHang;
                hoaDonDTO.TenKhachHang = khachHang.TenKhachHang;
                hoaDonDTO.MaNhanVien = hoaDon.MaNhanVien;
                hoaDonDTO.TenNhanVien = nhanVien.HoTen;

                return hoaDonDTO;
            }

            return null;
        }

        public List<ChiTietHoaDonDTO> LayDSChiTietHD(string maHD)
        {
            var cthd = dal.LayDSChiTietHD(maHD);

            if (cthd.Any())
            {
                List<ChiTietHoaDonDTO> chiTietHoaDonDTOs = new List<ChiTietHoaDonDTO>();
                ChiTietHoaDonDTO chiTietHDDTO;
                foreach (var ct in cthd)
                {
                    var sanPham = dal.TimSanPhamTheoMa(ct.MaSanPham);
                    chiTietHDDTO = new ChiTietHoaDonDTO();

                    chiTietHDDTO.MaChiTietHD = ct.MaChiTietHoaDonBanHang;
                    chiTietHDDTO.MaSanPham = ct.MaSanPham;
                    chiTietHDDTO.TenSanPham = sanPham.TenSanPham;
                    chiTietHDDTO.SoLuong = ct.SoLuong;
                    chiTietHDDTO.DonGia = ct.DonGia;
                    chiTietHDDTO.ThanhTien = ct.ThanhTien;
                    chiTietHDDTO.GhiChu = ct.GhiChu;

                    chiTietHoaDonDTOs.Add(chiTietHDDTO);
                }
                return chiTietHoaDonDTOs;
            }

            return null;
        }

        public int TaoPhieuDoiTra(PhieuDoiTraDTO dto)
        {
            string maHD = dal.TaoMaPhieuDoiTra();
            var phieuDoiTra = new PhieuDoiTra()
            {
                MaPhieuDoiTra = dal.TaoMaPhieuDoiTra(),
                NgayLap = DateTime.Now,
                LyDoDoiTra = dto.LyDoDoiTra,
                TinhTrangSanPham = dto.TinhTrangSanPham,
                SoLuong = dto.SoLuongDoi,
                TongTienHoanLai = dto.TongTienHoan,
                GhiChuThem = dto.GhiChu,
                MaNhanVien = dto.MaNhanVien,
                MaChiTietDonBanHang = dto.MaChiTietHD
            };

            return dal.TaoPhieuDoiTra(phieuDoiTra);
        }
    }
}
