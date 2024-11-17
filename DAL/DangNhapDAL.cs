using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
        public List<string> LayDanhSachQuyen(string maNhanVien)
        {

            var danhSachManHinh = (from nv_mh in db.NhanVien_ManHinhs
                                   join mh in db.ManHinhs on nv_mh.MaManHinh equals mh.MaManHinh
                                   where nv_mh.MaNhanVien == maNhanVien
                                   select mh.MaManHinh).ToList();

            return danhSachManHinh;
        }

    }
}
