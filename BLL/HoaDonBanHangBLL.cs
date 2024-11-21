using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace BLL
{
    public class HoaDonBanHangBLL
    {
        private readonly HoaDonBanHangDAL _hoaDonBanHangDAL;

        public HoaDonBanHangBLL()
        {
            _hoaDonBanHangDAL = new HoaDonBanHangDAL();
        }
        public bool AddHoaDonBanHang(HoaDonBanHang hoaDon)
        {
            try
            {
                return _hoaDonBanHangDAL.AddHoaDonBanHang(hoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm hóa đơn: " + ex.Message);
                return false;
            }
        }

        public string GetLatestHoaDonBanHangId()
        {
            try
            {
                return _hoaDonBanHangDAL.GetLatestHoaDonBanHangId();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy mã hóa đơn mới nhất: " + ex.Message);
                return null;
            }
        }

        public List<HoaDonBanHang> GetAllHoaDonBanHang()
        {
            try
            {
                return _hoaDonBanHangDAL.GetAllHoaDonBanHang();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tất cả hóa đơn bán hàng: " + ex.Message);
                return null;
            }
        }

        public List<HoaDonBanHang> GetHoaDonByMaKhachHang(string maKhachHang)
        {
            if (string.IsNullOrWhiteSpace(maKhachHang))
            {
                Console.WriteLine("Mã khách hàng không được để trống.");
                return new List<HoaDonBanHang>();
            }

            return _hoaDonBanHangDAL.GetHoaDonByMaKhachHang(maKhachHang);
        }

        public List<HoaDonBanHang> GetHoaDonByMaNhanVien(string maNhanVien)
        {
            if (string.IsNullOrWhiteSpace(maNhanVien))
            {
                Console.WriteLine("Mã nhân viên không được để trống.");
                return new List<HoaDonBanHang>();
            }

            return _hoaDonBanHangDAL.GetHoaDonByMaNhanVien(maNhanVien);
        }

        public List<HoaDonBanHang> GetHoaDonByMaHoaDon(string maHoaDon)
        {
            if (string.IsNullOrWhiteSpace(maHoaDon))
            {
                Console.WriteLine("Mã hóa đơn không được để trống.");
                return new List<HoaDonBanHang>();
            }

            return _hoaDonBanHangDAL.GetHoaDonByMaHoaDon(maHoaDon);
        }

        public List<HoaDonBanHang> GetHoaDonByDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("Ngày bắt đầu không thể lớn hơn ngày kết thúc.");
                return new List<HoaDonBanHang>();
            }

            return _hoaDonBanHangDAL.GetHoaDonByDateRange(startDate, endDate);
        }
        public bool UpdateHoaDonBanHang(HoaDonBanHang hoaDon)
        {
            return _hoaDonBanHangDAL.UpdateHoaDonBanHang(hoaDon);
        }

        //Nam viết thêm 
        public DataTable GetTongTienTheoNgayDataTable(DateTime startDate, DateTime endDate)
        {
            return _hoaDonBanHangDAL.GetTongTienTheoNgayDataTable(startDate, endDate);
        }

        public DataTable GetTongTienTheoNgayDataTable()
        {
            return _hoaDonBanHangDAL.GetTongTienTheoNgayDataTable();
        }

        public List<PhieuBaoCao> LayPhieuBaoCaoTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return _hoaDonBanHangDAL.LayPhieuBaoCaoTheoKhoangThoiGian(ngayBatDau, ngayKetThuc);
        }

    }
}
