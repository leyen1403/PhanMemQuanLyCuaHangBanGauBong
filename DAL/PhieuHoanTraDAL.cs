using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuHoanTraDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        // Lấy danh sách phiếu hoàn trả
        public List<PhieuHoanTra> GetPhieuHoanTra()
        {
            return db.PhieuHoanTras.ToList();
        }

        // Thêm phiếu hoàn trả mới
        public void AddPhieuHoanTra(PhieuHoanTra phieuHoanTra)
        {
            db.PhieuHoanTras.InsertOnSubmit(phieuHoanTra);
            db.SubmitChanges();
        }

        // Cập nhật phiếu hoàn trả
        public void UpdatePhieuHoanTra(PhieuHoanTra phieuHoanTra)
        {
            var existingPhieu = db.PhieuHoanTras
                .FirstOrDefault(p => p.MaPhieuHoanTra == phieuHoanTra.MaPhieuHoanTra);

            if (existingPhieu != null)
            {
                existingPhieu.NgayLap = phieuHoanTra.NgayLap;
                existingPhieu.TongSoLuong = phieuHoanTra.TongSoLuong;
                existingPhieu.TinhTrang = phieuHoanTra.TinhTrang;
                existingPhieu.MaNhanVien = phieuHoanTra.MaNhanVien;
                db.SubmitChanges();
            }
        }

        // Xóa phiếu hoàn trả
        public bool DeletePhieuHoanTra(string maPhieuHoanTra)
        {
            var phieuHoanTra = db.PhieuHoanTras
                .FirstOrDefault(p => p.MaPhieuHoanTra == maPhieuHoanTra);

            if (phieuHoanTra != null)
            {
                db.PhieuHoanTras.DeleteOnSubmit(phieuHoanTra);
                db.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
