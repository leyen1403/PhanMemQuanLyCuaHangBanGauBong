using DTO;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public NhanVienDAL() { }
        public List<NhanVien> GetListNhanVien()
        {
            return db.NhanViens.ToList();
        }
        public NhanVien GetNhanVienById(string id)
        {
            return db.NhanViens.Where(nv => nv.MaNhanVien == id).FirstOrDefault();
        }
        public NhanVien GetNhanVienByName(string name)
        {
            return db.NhanViens.Where(nv => nv.HoTen == name).FirstOrDefault();
        }

        public List<NhanVien> SearchNhanVien(string keyword)
        {
            return db.NhanViens.Where(nv =>
                nv.MaNhanVien.Contains(keyword) ||
                nv.HoTen.Contains(keyword) ||
                nv.TaiKhoan.Contains(keyword) ||
                nv.SoDienThoai.Contains(keyword)
            ).ToList();
        }
        public List<NhanVien> SearchNhanVienByTinhTrang(bool tinhTrang)
        {
            return db.NhanViens.Where(nv => nv.TrangThai == tinhTrang).ToList();
        }
        public bool AddNhanVien(NhanVien newNhanVien)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(newNhanVien);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetEmployeeByCode(string maNhanVien)
        {
            using (var db = new db_QLCHBGBDataContext())
            {
                // Tìm nhân viên có mã khớp với maNhanVien và lấy mã nếu có
                var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);
                return nhanVien != null ? nhanVien.MaNhanVien : null;
            }
        }

        public bool DeleteEmployee(string maNhanVien)
        {
            try
            {
                var employeeToDelete = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNhanVien);

                
                if (employeeToDelete != null)
                {
                    
                    db.NhanViens.DeleteOnSubmit(employeeToDelete);
                    db.SubmitChanges();
                    return true; 
                }
                else
                {
                    Console.WriteLine("Không tìm thấy nhân viên với mã: " + maNhanVien);
                    return false; 
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
                return false; 
            }
        }
        public bool UpdateEmployee(NhanVien updatedEmployee)
        {
            try
            {
              
                var employee = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == updatedEmployee.MaNhanVien);

             
                if (employee != null)
                {
                   
                    employee.HoTen = updatedEmployee.HoTen;
                    employee.ChucVu = updatedEmployee.ChucVu;
                    employee.NgaySinh = updatedEmployee.NgaySinh;
                    employee.GioiTinh = updatedEmployee.GioiTinh;
                    employee.SoDienThoai = updatedEmployee.SoDienThoai;
                    employee.Email = updatedEmployee.Email;
                    employee.TaiKhoan = updatedEmployee.TaiKhoan;
                    employee.MatKhau = updatedEmployee.MatKhau;
                    employee.HinhAnh = updatedEmployee.HinhAnh;
                    employee.TrangThai = updatedEmployee.TrangThai;  
                    employee.NgayCapNhat = DateTime.Now; 
                    employee.DiaChi = updatedEmployee.DiaChi;

                 
                    db.SubmitChanges();
                    return true; 
                }

            
                return false;
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi xảy ra
            }
        }

        public string GetTenNhanVienByMaNhanVien(string maNhanVien)
        {
            // Sử dụng LINQ để tìm tên nhân viên dựa trên mã nhân viên
            var nhanVien = db.NhanViens
                .Where(nv => nv.MaNhanVien == maNhanVien)
                .Select(nv => nv.HoTen)
                .FirstOrDefault(); // Trả về tên nhân viên đầu tiên hoặc null nếu không tìm thấy

            return nhanVien; // Trả về tên nhân viên (hoặc null nếu không tìm thấy)
        }


        public string GetSDTNhanVienByMaNhanVien(string maNhanVien)
        {
            // Sử dụng LINQ để tìm tên nhân viên dựa trên mã nhân viên
            var nhanVien = db.NhanViens
                .Where(nv => nv.MaNhanVien == maNhanVien)
                .Select(nv => nv.SoDienThoai)
                .FirstOrDefault(); // Trả về tên nhân viên đầu tiên hoặc null nếu không tìm thấy

            return nhanVien; // Trả về tên nhân viên (hoặc null nếu không tìm thấy)
        }

        public string GetDiaChiByMaNhanVien(string maNhanVien)
        {
            // Sử dụng LINQ để tìm tên nhân viên dựa trên mã nhân viên
            var nhanVien = db.NhanViens
                .Where(nv => nv.MaNhanVien == maNhanVien)
                .Select(nv => nv.DiaChi)
                .FirstOrDefault(); // Trả về tên nhân viên đầu tiên hoặc null nếu không tìm thấy

            return nhanVien; // Trả về tên nhân viên (hoặc null nếu không tìm thấy)
        }


    }
}
