using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhieuKiemKeDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public PhieuKiemKeDAL() { }
        public List<PhieuKiemKe> GetListPhieuKiemKe()
        {
            return db.PhieuKiemKes.OrderByDescending(x => x.MaPhieuKiemKe).ToList();
        }
        public bool InsertPhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            try
            {
                db.PhieuKiemKes.InsertOnSubmit(phieuKiemKe);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdatePhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            try
            {
                var phieuKiemKeUpdate = db.PhieuKiemKes.Single(x => x.MaPhieuKiemKe == phieuKiemKe.MaPhieuKiemKe);
                phieuKiemKeUpdate.NgayLap = phieuKiemKe.NgayLap;
                phieuKiemKeUpdate.GhiChu = phieuKiemKe.GhiChu;
                phieuKiemKeUpdate.MaNhanVien = phieuKiemKe.MaNhanVien;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public PhieuKiemKe GetPhieuKiemKeById(string id)
        {
            var phieuKiemKe = db.PhieuKiemKes.Single(x => x.MaPhieuKiemKe == id);
            return phieuKiemKe;
        }

        public bool UpdateGhiChu(string maPhieuKiemKe, string ghiChu)
        {
            try
            {
                var phieuKiemKeUpdate = db.PhieuKiemKes.Single(x => x.MaPhieuKiemKe == maPhieuKiemKe);
                phieuKiemKeUpdate.GhiChu = ghiChu;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var ListPhieuKiemKe = db.PhieuKiemKes.Where(x => x.NgayLap >= ngayBatDau && x.NgayLap <= ngayKetThuc).ToList();
            return ListPhieuKiemKe;
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByNhanVien(string maNhanVien)
        {
            return db.PhieuKiemKes.Where(x => x.MaNhanVien == maNhanVien).ToList();
        }
    }
}
