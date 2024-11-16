using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DangNhapBLL
    {
        DangNhapDAL dangNhapDAL = new DangNhapDAL();
        public NhanVien kiemTraDangNhap(string taiKhoan, string matKhau)
        {
            return dangNhapDAL.kiemTraDangNhap(taiKhoan, matKhau);
        }
    }
}
