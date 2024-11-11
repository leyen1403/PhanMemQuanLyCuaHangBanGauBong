using System;
using System.Collections.Generic;
using DTO;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        private readonly KhachHangDAL _khachHangDAL;

        public KhachHangBLL()
        {
            _khachHangDAL = new KhachHangDAL();
        }

        public bool ThemKhachHang(KhachHang khachHang)
        {
            if (khachHang == null || string.IsNullOrEmpty(khachHang.MaKhachHang) || string.IsNullOrEmpty(khachHang.TenKhachHang))
            {
                throw new ArgumentException("Thông tin khách hàng không hợp lệ.");
            }

            return _khachHangDAL.AddKhachHang(khachHang);
        }

        public KhachHang GetKhachHang(string maKhachHang = null, string tenKhachHang = null, string soDienThoai = null)
        {
            if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(soDienThoai))
            {
                throw new ArgumentException("Ít nhất một điều kiện tìm kiếm phải được cung cấp.");
            }

            return _khachHangDAL.GetKhachHang(maKhachHang, tenKhachHang, soDienThoai);
        }
        public List<KhachHang> GetAllKhachHangs()
        {
            return _khachHangDAL.GetAllKhachHangs();
        }
        public bool AddDiemCongTichLuy(string maKhachHang, decimal diemCong)
        {
            return _khachHangDAL.AddDiemCongTichLuy(maKhachHang, diemCong);
        }
    }
}
