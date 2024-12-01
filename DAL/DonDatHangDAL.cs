using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DonDatHangDAL
    {
        public DonDatHangDAL()
        {
        }
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return db.DonDatHangs.OrderByDescending(ddh => ddh.MaDonDatHang).ToList();
        }
        public List<DonDatHang> LayDanhSachDonDatHang2()
        {
            return db.DonDatHangs.ToList();
        }

        public bool ThemDonDatHang(DonDatHang ddh)
        {
            try
            {
                db.DonDatHangs.InsertOnSubmit(ddh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DonDatHang LayDonDatHang(string maDonDatHang)
        {
            return db.DonDatHangs.Where(ddh => ddh.MaDonDatHang == maDonDatHang).FirstOrDefault();
        }

        public bool CapNhatDonDatHang(DonDatHang ddh)
        {
            try
            {
                DonDatHang ddhNew = db.DonDatHangs.Where(d => d.MaDonDatHang == ddh.MaDonDatHang).FirstOrDefault();
                ddhNew.NgayDat = ddh.NgayDat;
                ddhNew.TongTien = ddh.TongTien;
                ddhNew.TrangThai = ddh.TrangThai;
                ddhNew.NgayTao = ddh.NgayTao;
                ddhNew.NgayCapNhat = ddh.NgayCapNhat;
                ddhNew.MaNhanVien = ddh.MaNhanVien;
                ddhNew.MaNhaCungCap = ddh.MaNhaCungCap;
                ddhNew.MaNhanVien = ddh.MaNhanVien;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaDonDatHang(string maDonDatHang)
        {
            DonDatHang ddh = db.DonDatHangs.Where(d => d.MaDonDatHang == maDonDatHang).FirstOrDefault();
            if (ddh != null)
            {
                List<ChiTietDonDatHang> lstCTDDH = db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == maDonDatHang).ToList();
                foreach (ChiTietDonDatHang ct in lstCTDDH)
                {
                    var relatedRecords = db.ChiTietPhieuNhaps.Where(pn => pn.MaChiTietDonDatHang == ct.MaChiTietDonDatHang).ToList();
                    db.ChiTietPhieuNhaps.DeleteAllOnSubmit(relatedRecords);
                    db.ChiTietDonDatHangs.DeleteOnSubmit(ct);
                }
                // Ensure related records in PhieuNhap are handled
                var phieuNhapRecords = db.PhieuNhaps.Where(pn => pn.MaDonDatHang == maDonDatHang).ToList();
                db.PhieuNhaps.DeleteAllOnSubmit(phieuNhapRecords);

                db.DonDatHangs.DeleteOnSubmit(ddh);
                db.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
