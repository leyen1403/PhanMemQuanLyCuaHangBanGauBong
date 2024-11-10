using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietDonDatHangDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public ChiTietDonDatHangDAL()
        {
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return db.ChiTietDonDatHangs.ToList();
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDonDatHang(string id)
        {
            return db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == id).ToList();
        }
       
        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            try
            {
                string maddh = ctdh.MaDonDatHang;
                string masp = ctdh.MaSanPham;
                ChiTietDonDatHang ctdh1 = db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == maddh && ct.MaSanPham == masp).FirstOrDefault();
                if (ctdh1 != null)
                {
                    ctdh1.SoLuongYeuCau = ctdh.SoLuongYeuCau;
                    ctdh1.ThanhTien = ctdh.ThanhTien;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.ChiTietDonDatHangs.InsertOnSubmit(ctdh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool XoaChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            try
            {
                ChiTietDonDatHang ctdh = db.ChiTietDonDatHangs.Where(ct => ct==ctddh).FirstOrDefault();
                db.ChiTietDonDatHangs.DeleteOnSubmit(ctdh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public ChiTietDonDatHang layMotChiTietDonDatHang(string maddh, string masp)
        {
            return db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == maddh && ct.MaSanPham == masp).FirstOrDefault();
        }
        public bool CapNhatChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            try
            {
                // Tìm bản ghi cần cập nhật dựa trên MaDonDatHang và MaSanPham
                ChiTietDonDatHang ct = db.ChiTietDonDatHangs
                    .Where(ct1 => ct1.MaDonDatHang == ctddh.MaDonDatHang && ct1.MaSanPham == ctddh.MaSanPham)
                    .FirstOrDefault();

                if (ct != null)
                {
                    // Cập nhật các thuộc tính của bản ghi
                    ct.SoLuongYeuCau = ctddh.SoLuongYeuCau;
                    ct.SoLuongCungCap = ctddh.SoLuongCungCap;
                    ct.SoLuongThieu = ctddh.SoLuongThieu;
                    ct.DonGia = ctddh.DonGia;
                    ct.TrangThai = ctddh.TrangThai;
                    ct.ThanhTien = ctddh.ThanhTien;

                    // Thử lưu các thay đổi vào cơ sở dữ liệu
                    db.SubmitChanges(ConflictMode.ContinueOnConflict);
                    return true;
                }

                return false;
            }
            catch (ChangeConflictException)
            {
                // Xử lý xung đột thay đổi nếu xảy ra
                foreach (ObjectChangeConflict conflict in db.ChangeConflicts)
                {
                    conflict.Resolve(RefreshMode.KeepChanges);
                }

                try
                {
                    // Cố gắng lưu thay đổi lần nữa sau khi xử lý xung đột
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    // Nếu vẫn gặp lỗi, trả về false
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật ChiTietDonDatHang: " + ex.Message);
                return false;
            }
        }

    }
}
