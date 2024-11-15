using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChiTietPhieuNhapDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public ChiTietPhieuNhapDAL() { }
        public List<ChiTietPhieuNhap> GetListChiTietPhieuNhap()
        {
            return db.ChiTietPhieuNhaps.ToList();
        }
        public List<ChiTietPhieuNhap> SearchCTPhieuNhapByMaPN(string maPN)
        {
            try
            {
                // Kiểm tra nếu mã phiếu nhập hợp lệ
                if (string.IsNullOrEmpty(maPN))
                {
                    throw new ArgumentException("Mã phiếu nhập không được để trống.");
                }
                var chiTietPhieuNhaps = db.ChiTietPhieuNhaps
                                           .Where(ct => ct.MaPhieuNhap == maPN)
                                           .ToList();
                if (chiTietPhieuNhaps.Count == 0)
                {
                    throw new Exception("Không tìm thấy chi tiết phiếu nhập cho mã phiếu nhập này.");
                }

                return chiTietPhieuNhaps;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn chi tiết phiếu nhập: " + ex.Message);
            }
        }
    }
}
