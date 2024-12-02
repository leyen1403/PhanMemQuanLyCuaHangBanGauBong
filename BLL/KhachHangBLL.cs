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
        public bool UpdateDiemTichLuy(string maKhachHang, decimal diemTichLuyMoi)
        {
            return _khachHangDAL.UpdateDiemTichLuy(maKhachHang, diemTichLuyMoi);
        }

        public string CreateKhachHang(KhachHang kh)
        {
            return _khachHangDAL.CreateKhachHang(kh);
        }

        public bool isEmailExits(string email) { 
            return _khachHangDAL.isEmailExits(email);
        }
        public bool isPhoneExits(string phone) { 
            return _khachHangDAL.isPhoneExits(phone);
        }
        public bool isTaiKhoanExits(string taiKhoan) {
            return _khachHangDAL.isTaiKhoanExits(taiKhoan);
        }

        public string deleteKhachHang(string maKhachHang) { 
            return _khachHangDAL.deleteKhachHang(maKhachHang);
        }
        public void updateKhachHang(KhachHang kh)
        {
            _khachHangDAL.updateKhachHang(kh.MaKhachHang,kh);
        }
    }
}
