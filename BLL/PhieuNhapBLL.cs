using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuNhapBLL
    {
        PhieuNhapDAL phieuNhapDAL = new PhieuNhapDAL();
        public List<PhieuNhap> getAllPhieuNhap()
        {
            return phieuNhapDAL.GetListPhieuNhap();
        }

        public bool AddPhieuNhap(PhieuNhap phieuNhap)
        {
            return phieuNhapDAL.AddPhieuNhap(phieuNhap);
        }
       
    }
}
