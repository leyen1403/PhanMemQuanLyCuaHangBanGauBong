using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAL nccDAL = new NhaCungCapDAL();
        public NhaCungCapBLL()
        {
        }
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return nccDAL.LayDanhSachNhaCungCap();
        }
        public NhaCungCap LayNhaCungCapTheoMa(string maNhaCungCap)
        {
            return LayDanhSachNhaCungCap().Where(ncc => ncc.MaNhaCungCap == maNhaCungCap).FirstOrDefault();
        }
    }
}
