using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

        public bool AddChiTietPhieuNhap(ChiTietPhieuNhap newCTPhieuNhap)
        {
            try
            {
                db.ChiTietPhieuNhaps.InsertOnSubmit(newCTPhieuNhap);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetChiTietPhieuNhapByCode(string maCTPN)
        {
            using (var db = new db_QLCHBGBDataContext())
            {
                
                var CTPN = db.ChiTietPhieuNhaps.FirstOrDefault(nv => nv.MaChiTietPhieuNhap == maCTPN);
                return CTPN != null ? CTPN.MaChiTietPhieuNhap : null;
            }
        }


        public List<ChiTietPhieuNhap> SearchCTPhieuNhapByMaPN(string maPN)
        {
            try
            {
                // Kiểm tra nếu mã phiếu nhập hợp lệ
                if (string.IsNullOrEmpty(maPN))
                {
                  
                    return new List<ChiTietPhieuNhap>(); 
                }

                var chiTietPhieuNhaps = db.ChiTietPhieuNhaps
                                            .Where(ct => ct.MaPhieuNhap == maPN)
                                            .ToList();

             
                if (chiTietPhieuNhaps.Count == 0)
                {
                    return new List<ChiTietPhieuNhap>();
                }

                return chiTietPhieuNhaps;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public string LayProductNameByMaCTDDH(string maCTDDH)
        {
            try
            {
                // Thực hiện join để lấy tên sản phẩm
                var productName = (from ctdh in db.ChiTietDonDatHangs
                                   join sp in db.SanPhams on ctdh.MaSanPham equals sp.MaSanPham
                                   where ctdh.MaChiTietDonDatHang == maCTDDH
                                   select sp.TenSanPham).FirstOrDefault();

                return productName ?? "Unknown"; // Trả về "Unknown" nếu không tìm thấy sản phẩm
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn tên sản phẩm: " + ex.Message);
            }
        }
    }

}
