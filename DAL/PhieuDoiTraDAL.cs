using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuDoiTraDAL
    {
        db_QLCHBGBDataContext _context;

        public PhieuDoiTraDAL()
        {
            _context = new db_QLCHBGBDataContext();
        }

        public HoaDonBanHang TimHoaDonTheoMa(string maHD)
        {
            return _context.HoaDonBanHangs.FirstOrDefault(hd => hd.MaHoaDonBanHang == maHD);
        }

        public KhachHang TimKhachHangTheoMa(string maKH)
        {
            return _context.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKH);
        }

        public NhanVien TimNhanVienTheoMa(string maNV)
        {
            return _context.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
        }

        public IEnumerable<ChiTietHoaDonBanHang> LayDSChiTietHD(string maHD)
        {
            return _context.ChiTietHoaDonBanHangs.Where(ct => ct.MaHoaDon == maHD).ToList();
        }

        public SanPham TimSanPhamTheoMa(string maSP)
        {
            return _context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSP);
        }

        public ChiTietHoaDonBanHang TimChiTietHDTheoMa(string maCTHD)
        {
            return _context.ChiTietHoaDonBanHangs.FirstOrDefault(sp => sp.MaChiTietHoaDonBanHang == maCTHD);
        }

        public int TaoPhieuDoiTra(PhieuDoiTra phieuDoiTra)
        {
            try
            {
                //Tao phieu doi tra
                _context.PhieuDoiTras.InsertOnSubmit(phieuDoiTra);

                //Cap nhap so luong ton cua san pham theo so luong hoan
                string maSP = _context.ChiTietHoaDonBanHangs.FirstOrDefault(ct => ct.MaChiTietHoaDonBanHang == phieuDoiTra.MaChiTietDonBanHang).MaSanPham;
                var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == maSP);
                sanPham.SoLuongTon += phieuDoiTra.SoLuong;

                //Cap nhap so luong mua, thanh tien cua chi tiet hoa don
                //Cap nhap tong tien cua hoa don

                _context.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public string TaoMaPhieuDoiTra()
        {
            var phieuDoiTra = _context.PhieuDoiTras.OrderByDescending(pdt => pdt.MaPhieuDoiTra).FirstOrDefault();

            if (phieuDoiTra != null)
            {
                int index = int.Parse(phieuDoiTra.MaPhieuDoiTra.Substring(3));
                return "PDT" + (index + 1).ToString("D4");    //D4 => PTD000[index]
            }

            return "PDT0001";
        }

        public IEnumerable<PhieuDoiTra> LayDSPhieuDoiTra()
        {
            return _context.PhieuDoiTras.ToList();
        }

        public int Update(PhieuDoiTraUpdate update)
        {
            try
            {
                var phieuDoiTra = _context.PhieuDoiTras.FirstOrDefault(pdt => pdt.MaPhieuDoiTra == update.MaPhieu);
                if (phieuDoiTra != null)
                {
                    phieuDoiTra.LyDoDoiTra = update.LyDoDoiTra;
                    phieuDoiTra.TinhTrangSanPham = update.TinhTrangSanPham;
                    phieuDoiTra.GhiChuThem = update.GhiChu;
                    phieuDoiTra.NgayCapNhat = DateTime.Now;

                    _context.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Delete(string maPhieu)
        {
            try
            {
                var phieuDoiTra = _context.PhieuDoiTras.FirstOrDefault(pdt => pdt.MaPhieuDoiTra == maPhieu);
                if (phieuDoiTra != null)
                {
                    _context.PhieuDoiTras.DeleteOnSubmit(phieuDoiTra);
                    _context.SubmitChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
