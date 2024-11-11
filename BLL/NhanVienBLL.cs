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
    }
}
