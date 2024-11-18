using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

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

        public ChiTietHoaDonBanHang TimChiTietHDTheoMa(string maCTHD)
        {
            return dal.TimChiTietHDTheoMa(maCTHD);
        }

        public NhanVien TimNhanVienTheoMa(string maNV)
        {
            return dal.TimNhanVienTheoMa(maNV);
        }

        public SanPham TimSanPhamTheoMa(string maSP)
        {
            return dal.TimSanPhamTheoMa(maSP);
        }

        public IEnumerable<PhieuDoiTra> LayDSPhieuDoiTra()
        {
            //var phieuDoiTras = dal.LayDSPhieuDoiTra();
            //if (phieuDoiTras.Any())
            //{
            //    List<DanhSachPhieuDoiTraDTO> phieuDoiTraDTOs = new List<DanhSachPhieuDoiTraDTO>();
            //    DanhSachPhieuDoiTraDTO dto;
            //    foreach (var item in phieuDoiTras)
            //    {
            //        dto = new DanhSachPhieuDoiTraDTO();
            //        dto.MaPhieu = item.MaPhieuDoiTra;
            //        dto.MaChiTietHD = item.MaChiTietDonBanHang;

            //        //Tim cthd theo ma
            //        var cthd = dal.TimChiTietHDTheoMa(item.MaChiTietDonBanHang);
            //        var sanPham = dal.TimSanPhamTheoMa(cthd.MaSanPham);

            //        dto.MaSanPham = sanPham.MaSanPham;
            //        dto.TenSanPham = sanPham.TenSanPham;
            //        dto.LyDoDoiTra = item.LyDoDoiTra;
            //        dto.TinhTrangSanPham = item.TinhTrangSanPham;
            //        dto.SoLuongDoi = item.SoLuong;
            //        dto.TongTienHoan = item.TongTienHoanLai;
            //        dto.GhiChu = item.GhiChuThem;
            //    }
            //}

            return dal.LayDSPhieuDoiTra();
        }

        public int SuaPhieuDoiTra(PhieuDoiTraUpdate pdt)
        {
            try
            {
                return dal.Update(pdt);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int XoaPhieuDoiTra(string maPhieu)
        {
            try
            {
                return dal.Delete(maPhieu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
