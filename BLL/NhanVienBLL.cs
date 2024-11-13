using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL nhanVienDAL = new NhanVienDAL();
        public NhanVienBLL() { }
        public NhanVien GetNhanVienById(string id)
        {
            return nhanVienDAL.GetNhanVienById(id);
        }
        public string GetEmployeeByCode(string maNV)
        {
            return nhanVienDAL.GetEmployeeByCode(maNV);
        }
        public List<NhanVien> getAllNhanVien()
        {
            return nhanVienDAL.GetListNhanVien();
        }
        public string GetEmployeeIdFromName(string employeeName)
        {
            var nhanVien = nhanVienDAL.GetNhanVienByName(employeeName);
            if (nhanVien != null)
            {
                return nhanVien.MaNhanVien; // Assuming 'MaNhanVien' is the ID field
            }
            return null; // Or throw an exception if the employee is not found
        }
        public List<NhanVien> SearchNhanVien(string keyword)
        {
           return nhanVienDAL.SearchNhanVien(keyword);
        }
        public List<NhanVien> SearchNhanVienByTinhTrang(bool tinhTrang)
        {
            return nhanVienDAL.SearchNhanVienByTinhTrang(tinhTrang);
        }

        public bool AddNhanVien(NhanVien newNhanVien)
        {
            if (newNhanVien != null && ValidateProduct(newNhanVien))
            {
                return nhanVienDAL.AddNhanVien(newNhanVien);
            }
            return false;
        }
        public bool DeleteEmployee(string maNhanVien)
        {
           
            return nhanVienDAL.DeleteEmployee(maNhanVien);
        }
        public bool UpdateEmployee(NhanVien nhanVien)
        {

            return nhanVienDAL.UpdateEmployee(nhanVien);
        }
        private bool ValidateProduct(NhanVien nhanVien)
        {
            return !string.IsNullOrEmpty(nhanVien.MaNhanVien);
        }
    }
}
