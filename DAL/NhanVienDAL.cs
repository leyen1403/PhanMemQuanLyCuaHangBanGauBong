using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    }
}
