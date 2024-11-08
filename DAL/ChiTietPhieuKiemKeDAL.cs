﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietPhieuKiemKeDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public ChiTietPhieuKiemKeDAL() { }
        public bool InsertChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            try
            {
                db.ChiTietPhieuKiemKes.InsertOnSubmit(chiTietPhieuKiemKe);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<ChiTietPhieuKiemKe> chiTietPhieuKiemKes(string maPhieuKiemKe)
        {
            return db.ChiTietPhieuKiemKes.Where(ct => ct.MaPhieuKiemKe == maPhieuKiemKe).ToList<ChiTietPhieuKiemKe>();
        }
        public bool UpdateChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            var ct = db.ChiTietPhieuKiemKes.FirstOrDefault(c => c.MaPhieuKiemKe == chiTietPhieuKiemKe.MaPhieuKiemKe && c.MaSanPham == chiTietPhieuKiemKe.MaSanPham);
            if (ct != null)
            {
                ct.SoLuongThucTe = chiTietPhieuKiemKe.SoLuongThucTe;
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}