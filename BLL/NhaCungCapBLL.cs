using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Security.Policy;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAL nccDAL = new NhaCungCapDAL();
        public NhaCungCapBLL()
        {
        }
        public bool isEmailExits(string email)
        {
            return nccDAL.isEmailExits(email);
        }
        public bool isPhoneExits(string phone)
        {
            return nccDAL.isPhoneExits(phone);
        }
        public List<NhaCungCap> LayDanhSachNhaCungCap()
        {
            return nccDAL.LayDanhSachNhaCungCap();
        }
        public NhaCungCap LayNhaCungCapTheoMa(string maNhaCungCap)
        {
            return LayDanhSachNhaCungCap().Where(ncc => ncc.MaNhaCungCap == maNhaCungCap).FirstOrDefault();
        }
        public string ThemNhaCungCap(NhaCungCap cap) {
            return nccDAL.Add(cap);
        }

        public string SuaNhaCungCap(string mancc,NhaCungCap nhaCungCap)
        {
            return nccDAL.updateNCC(mancc,nhaCungCap);
        }
        public string XoaNhaCungCap(string mancc)
        {
            return nccDAL.deleteNCC(mancc);
        }
    }
}
