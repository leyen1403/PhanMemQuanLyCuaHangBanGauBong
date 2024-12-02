using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public KhachHangDAL() { }

        public bool AddKhachHang(KhachHang khachHang)
        {
            try
            {
                khachHang.MaKhachHang = newID();
                db.KhachHangs.InsertOnSubmit(khachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public KhachHang GetKhachHangByMa(string maKhachHang)
        {
            return db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
        }

        public List<KhachHang> GetKhachHangByTen(string tenKhachHang)
        {
            return db.KhachHangs.Where(kh => kh.TenKhachHang.Contains(tenKhachHang)).ToList();
        }

        public KhachHang GetKhachHangBySoDienThoai(string soDienThoai)
        {
            return db.KhachHangs.FirstOrDefault(kh => kh.SoDienThoai == soDienThoai);
        }
        public KhachHang GetKhachHang(string maKhachHang = null, string tenKhachHang = null, string soDienThoai = null)
        {
            var query = db.KhachHangs.AsQueryable();
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                query = query.Where(kh => kh.MaKhachHang == maKhachHang);
            }
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                query = query.Where(kh => kh.TenKhachHang.Contains(tenKhachHang));
            }
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                query = query.Where(kh => kh.SoDienThoai == soDienThoai);
            }
            return query.FirstOrDefault();
        }
        public List<KhachHang> GetAllKhachHangs()
        {
            try
            {
                return db.KhachHangs.ToList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<KhachHang>(); 
            }
        }
        public bool UpdateDiemTichLuy(string maKhachHang, decimal diemTichLuyMoi)
        {
            try
            {
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang == null) return false;

                khachHang.DiemTichLuy = diemTichLuyMoi;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }


        public string CreateKhachHang(KhachHang kh)
        {
            try
            {
                kh.MaKhachHang = newID();
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return "Thêm thành công";
            }
            catch (Exception ex) { 
                return ex.Message;
            }
         

        }
        public bool isEmailExits(string email)
        {
            try
            {
                // Kiểm tra email có tồn tại trong cơ sở dữ liệu hay không
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.Email == email);

                // Nếu khachHang là null thì email không tồn tại, ngược lại email đã tồn tại
                return khachHang != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Nếu có lỗi, trả về false
            }
        }
        public bool isPhoneExits(string phone)
        {
            try
            {
                // Kiểm tra email có tồn tại trong cơ sở dữ liệu hay không
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.SoDienThoai == phone);

                // Nếu khachHang là null thì email không tồn tại, ngược lại email đã tồn tại
                return khachHang != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Nếu có lỗi, trả về false
            }
        }
        public bool isTaiKhoanExits(string TaiKhoan)
        {
            try
            {
                // Kiểm tra email có tồn tại trong cơ sở dữ liệu hay không
                var khachHang = db.KhachHangs.FirstOrDefault(kh => kh.TaiKhoan == TaiKhoan);

                // Nếu khachHang là null thì email không tồn tại, ngược lại email đã tồn tại
                return khachHang != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Nếu có lỗi, trả về false
            }
        }

        public string deleteKhachHang(string makh)
        {
            try{
                var khachhang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == makh);
                if (khachhang != null)
                {
                    khachhang.TrangThai = false;
                    db.SubmitChanges();
                    return "Cập nhật thành công";
                }
                else
                {
                    return "Không tìm thấy khách hàng";
                }
            }
            catch (Exception e){
                return e.Message;
            }
           
        }

        public void updateKhachHang(string MaKh,KhachHang khachHang)
        {
            // Check if MaKh is not null or empty
            if (string.IsNullOrEmpty(MaKh))
            {
                throw new ArgumentException("Customer ID (MaKh) cannot be null or empty.");
            }

            // Check if the khachHang parameter is valid
            if (khachHang == null)
            {
                throw new ArgumentNullException(nameof(khachHang), "Customer data cannot be null.");
            }

            // Assume you have a collection of KhachHang, like a List<KhachHang>
            var existingKhachHang = db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == MaKh);

            // If the customer doesn't exist, throw an exception or handle it
            if (existingKhachHang == null)
            {
                throw new InvalidOperationException("Customer not found.");
            }

            // Update the properties of the existing customer with the new data
            existingKhachHang.TenKhachHang = khachHang.TenKhachHang; 
            existingKhachHang.DiaChi = khachHang.DiaChi;
            existingKhachHang.SoDienThoai = khachHang.SoDienThoai; 
            existingKhachHang.HinhAnh = khachHang.HinhAnh;
            existingKhachHang.TaiKhoan = khachHang.TaiKhoan;
            existingKhachHang.MatKhau = khachHang.MatKhau;
            existingKhachHang.GioiTinh = khachHang.GioiTinh;
            existingKhachHang.ThanhVien = khachHang.ThanhVien;
            existingKhachHang.TrangThai = khachHang.TrangThai;
            db.SubmitChanges();
        }
        public string newID()
        {
            // Lấy số lượng khách hàng hiện tại trong cơ sở dữ liệu
            int count = db.KhachHangs.Count();

            // Tạo mã ID mới, KH + số đếm + đệm 0 phía trước nếu cần để có 3 chữ số
            string newID = "KH" + (count + 1).ToString().PadLeft(3, '0');

            return newID;
        }
    }
}
