using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public PhieuNhapDAL() { }
        public List<PhieuNhap> GetListPhieuNhap()
        {
            return db.PhieuNhaps.ToList();
        }
        public bool AddPhieuNhap(PhieuNhap newPhieuNhap)
        {
            try
            {
                db.PhieuNhaps.InsertOnSubmit(newPhieuNhap);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<PhieuNhap> GetListPhieuNhapByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            var listPhieuNhap = db.PhieuNhaps.Where(x => x.NgayLap >= ngayBatDau && x.NgayLap <= ngayKetThuc).ToList();
            return listPhieuNhap;
        }
        public List<PhieuNhap> GetListPhieuNhapByNhanVien(string maNhanVien)
        {
            return db.PhieuNhaps.Where(x => x.MaNhanVien == maNhanVien).ToList();
        }
        public bool UpdateTongTien(string maPN, decimal tongTien)
        {
            try
            {
                var phieuNhap = db.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieuNhap == maPN);
                if (phieuNhap != null)
                {
                    phieuNhap.TongTien = tongTien;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public bool DeletePhieuNhap(string maPhieuNhap)
        {
            try
            {
                // Tìm phiếu nhập cần xóa
                var phieuNhapToDelete = db.PhieuNhaps.FirstOrDefault(pn => pn.MaPhieuNhap == maPhieuNhap);

                if (phieuNhapToDelete != null)
                {
                    // Lấy danh sách chi tiết phiếu nhập liên quan
                    var chiTietPhieuNhapsToDelete = db.ChiTietPhieuNhaps.Where(ct => ct.MaPhieuNhap == maPhieuNhap).ToList();

                    // Xóa tất cả các chi tiết phiếu nhập liên quan
                    if (chiTietPhieuNhapsToDelete.Any())
                    {
                        db.ChiTietPhieuNhaps.DeleteAllOnSubmit(chiTietPhieuNhapsToDelete);
                    }
                    // Xóa phiếu nhập
                    db.PhieuNhaps.DeleteOnSubmit(phieuNhapToDelete);
                    db.SubmitChanges();
                    return true; 
                }
                else
                {
                    Console.WriteLine("Không tìm thấy phiếu nhập với mã: " + maPhieuNhap);
                    return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa phiếu nhập: " + ex.Message);
                return false; // Xóa thất bại
            }
        }



    }
}
