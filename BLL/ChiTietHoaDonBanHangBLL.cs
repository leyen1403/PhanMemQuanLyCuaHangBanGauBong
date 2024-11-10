using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ChiTietHoaDonBanHangBLL
    {
        private readonly ChiTietHoaDonBanHangDAL _chiTietHoaDonBanHangDAL;

        public ChiTietHoaDonBanHangBLL()
        {
            _chiTietHoaDonBanHangDAL = new ChiTietHoaDonBanHangDAL();
        }

        public bool AddChiTietHoaDon(ChiTietHoaDonBanHang chiTietHoaDon)
        {
            try
            {
                if (chiTietHoaDon == null)
                    throw new ArgumentNullException(nameof(chiTietHoaDon), "Chi tiết hóa đơn không được để trống.");

                bool isAdded = _chiTietHoaDonBanHangDAL.AddChiTietHoaDon(chiTietHoaDon);
                if (!isAdded)
                {
                    throw new Exception("Thêm chi tiết hóa đơn không thành công.");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }

        public List<ChiTietHoaDonBanHang> GetChiTietHoaDonByMaHoaDon(string maHoaDon)
        {
            try
            {
                if (string.IsNullOrEmpty(maHoaDon))
                    throw new ArgumentException("Mã hóa đơn không hợp lệ.", nameof(maHoaDon));

                return _chiTietHoaDonBanHangDAL.GetChiTietHoaDonByMaHoaDon(maHoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy chi tiết hóa đơn theo mã hóa đơn: " + ex.Message);
                return new List<ChiTietHoaDonBanHang>(); // Trả về danh sách trống nếu gặp lỗi
            }
        }

        public ChiTietHoaDonBanHang GetChiTietHoaDonByMaChiTiet(string maChiTietHoaDon)
        {
            try
            {
                if (string.IsNullOrEmpty(maChiTietHoaDon))
                    throw new ArgumentException("Mã chi tiết hóa đơn không hợp lệ.", nameof(maChiTietHoaDon));

                return _chiTietHoaDonBanHangDAL.GetChiTietHoaDonByMaChiTiet(maChiTietHoaDon);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}