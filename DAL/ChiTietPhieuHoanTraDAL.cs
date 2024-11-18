using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPhieuHoanTraDAL
    {
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();


        // Lấy danh sách chi tiết phiếu hoàn trả
        public List<ChiTietPhieuHoanTra> GetChiTietPhieuHoanTra(string maPhieuHoanTra)
        {
            return db.ChiTietPhieuHoanTras
                .Where(c => c.MaPhieuHoanTra == maPhieuHoanTra)
                .ToList();
        }

        // Thêm chi tiết phiếu hoàn trả mới
        public void AddChiTietPhieuHoanTra(ChiTietPhieuHoanTra chiTietPhieuHoanTra)
        {
            db.ChiTietPhieuHoanTras.InsertOnSubmit(chiTietPhieuHoanTra);
            db.SubmitChanges();
        }

        // Cập nhật chi tiết phiếu hoàn trả
        public void UpdateChiTietPhieuHoanTra(ChiTietPhieuHoanTra chiTietPhieuHoanTra)
        {
            var existingChiTiet = db.ChiTietPhieuHoanTras
                .FirstOrDefault(c => c.MaPhieuHoanTra == chiTietPhieuHoanTra.MaPhieuHoanTra &&
                                     c.MaChiTietPhieuNhap == chiTietPhieuHoanTra.MaChiTietPhieuNhap);

            if (existingChiTiet != null)
            {
                existingChiTiet.SoLuong = chiTietPhieuHoanTra.SoLuong;
                existingChiTiet.LyDo = chiTietPhieuHoanTra.LyDo;
                db.SubmitChanges();
            }
        }

        // Xóa chi tiết phiếu hoàn trả
        public void DeleteChiTietPhieuHoanTra(string maPhieuHoanTra, string maChiTietPhieuNhap)
        {
            var chiTiet = db.ChiTietPhieuHoanTras
                .FirstOrDefault(c => c.MaPhieuHoanTra == maPhieuHoanTra && c.MaChiTietPhieuNhap == maChiTietPhieuNhap);

            if (chiTiet != null)
            {
                db.ChiTietPhieuHoanTras.DeleteOnSubmit(chiTiet);
                db.SubmitChanges();
            }
        }
    }
}
