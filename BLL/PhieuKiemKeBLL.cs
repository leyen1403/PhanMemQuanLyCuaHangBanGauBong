using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhieuKiemKeBLL
    {
        PhieuKiemKeDAL phieuKiemKeDAL = new PhieuKiemKeDAL();
        public PhieuKiemKeBLL() { }
        public List<PhieuKiemKe> GetListPhieuKiemKe()
        {
            return phieuKiemKeDAL.GetListPhieuKiemKe();
        }
        public bool InsertPhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            return phieuKiemKeDAL.InsertPhieuKiemKe(phieuKiemKe);
        }
        public bool UpdatePhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            return phieuKiemKeDAL.UpdatePhieuKiemKe(phieuKiemKe);
        }
        public PhieuKiemKe GetPhieuKiemKeById(string id)
        {
            return phieuKiemKeDAL.GetPhieuKiemKeById(id);
        }

        public bool UpdateGhiChu(string maPhieuKiemKe, string ghiChu)
        {
            return phieuKiemKeDAL.UpdateGhiChu(maPhieuKiemKe, ghiChu);
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return phieuKiemKeDAL.GetListPhieuKiemKeByDate(ngayBatDau, ngayKetThuc);
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByNhanVien(string maNhanVien)
        {
            return phieuKiemKeDAL.GetListPhieuKiemKeByNhanVien(maNhanVien);
        }
    }
}
