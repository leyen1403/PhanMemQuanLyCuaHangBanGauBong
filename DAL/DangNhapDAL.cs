using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DangNhapDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public NhanVien kiemTraDangNhap(string taiKhoan, string matKhau)
        {
            return db.NhanViens.Where(nv => nv.TaiKhoan == taiKhoan && nv.MatKhau == matKhau).FirstOrDefault();
        }

    }
}
