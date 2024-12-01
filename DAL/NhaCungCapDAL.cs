using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCapDAL
    {
        public NhaCungCapDAL()
        {
        }
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return db.NhaCungCaps.ToList();
        }
        public bool isEmailExits(string email)
        {
            try
            {
                // Kiểm tra email có tồn tại trong cơ sở dữ liệu hay không
                var khachHang = db.NhaCungCaps.FirstOrDefault(kh => kh.Email == email);

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
                var khachHang = db.NhaCungCaps.FirstOrDefault(kh => kh.SoDienThoai == phone);

                // Nếu khachHang là null thì email không tồn tại, ngược lại email đã tồn tại
                return khachHang != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false; // Nếu có lỗi, trả về false
            }
        }
        public string newID()
        {
            // Lấy số lượng khách hàng hiện tại trong cơ sở dữ liệu
            int count = db.NhaCungCaps.Count();

            // Tạo mã ID mới, KH + số đếm + đệm 0 phía trước nếu cần để có 3 chữ số
            string newID = "NCC" + (count + 1).ToString().PadLeft(3, '0');

            return newID;
        }
        public string Add(NhaCungCap ncc)
        {
            try
            {
                ncc.MaNhaCungCap = newID();
                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return "Thêm thành công";
            }
            catch (Exception ex) { 
                return ex.Message;
            }
          
        }
        public string updateNCC(string mancc,NhaCungCap ncc)
        {
            try {
                // Check if the khachHang parameter is valid
                if (ncc == null)
                {
                    throw new ArgumentNullException(nameof(NhaCungCap), "Customer data cannot be null.");
                }

                // Assume you have a collection of KhachHang, like a List<KhachHang>
                var existNCC = db.NhaCungCaps.FirstOrDefault(kh => kh.MaNhaCungCap == mancc);

                // If the customer doesn't exist, throw an exception or handle it
                if (existNCC == null)
                {
                    throw new InvalidOperationException("Customer not found.");
                }

                // Update the properties of the existing customer with the new data
                existNCC.TenNhaCungCap = ncc.TenNhaCungCap;
                existNCC.NgayCapNhat = DateTime.Now;
                existNCC.DiaChi = ncc.DiaChi;
                existNCC.Email = ncc.Email;
                existNCC.SoDienThoai = ncc.SoDienThoai;
                existNCC.NguoiDaiDien = ncc.NguoiDaiDien;
                existNCC.TrangThai = ncc?.TrangThai;
                db.SubmitChanges();
                return "Câp nhật thành công";
            }
            catch (Exception ex) {
                return ex.Message;
            }
           
        }
        public string deleteNCC(string mancc)
        {
            try
            {
                var ncc = db.NhaCungCaps.FirstOrDefault(kh => kh.MaNhaCungCap== mancc);
                if (ncc!= null)
                {
                    db.NhaCungCaps.DeleteOnSubmit(ncc);
                    db.SubmitChanges();
                    return "Xóa thành công";
                }
                else
                {
                    return "Không tìm thấy khách hàng";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}
