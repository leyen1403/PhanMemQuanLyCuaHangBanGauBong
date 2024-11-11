using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

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

    }
}
