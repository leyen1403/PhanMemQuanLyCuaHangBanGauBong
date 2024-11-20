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
                var productName = (from ctdh in db.ChiTietDonDatHangs
                                   join sp in db.SanPhams on ctdh.MaSanPham equals sp.MaSanPham
                                   where ctdh.MaChiTietDonDatHang == maCTDDH
                                   select sp.TenSanPham).FirstOrDefault();

                return productName ?? "Unknown";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn tên sản phẩm: " + ex.Message);
            }
        }
        public string LayProductIdByMaCTDDH(string maCTDDH)
        {
            try
            {
                var productName = (from ctdh in db.ChiTietDonDatHangs
                                   join sp in db.SanPhams on ctdh.MaSanPham equals sp.MaSanPham
                                   where ctdh.MaChiTietDonDatHang == maCTDDH
                                   select sp.MaSanPham).FirstOrDefault();

                return productName ?? "Unknown";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn tên sản phẩm: " + ex.Message);
            }
        }


        public bool IsExist(string maCTPN)
        {
            return db.ChiTietPhieuNhaps.Any(ctpn => ctpn.MaChiTietPhieuNhap == maCTPN);
        }


        public string LayProductIdByMaDDH(string maDDH)
        {
            try
            {
                var productId = (from ctdh in db.ChiTietDonDatHangs
                                 join sp in db.SanPhams on ctdh.MaSanPham equals sp.MaSanPham
                                 join ddh in db.DonDatHangs on ctdh.MaDonDatHang equals ddh.MaDonDatHang
                                 where ddh.MaDonDatHang == maDDH
                                 select sp.MaSanPham).FirstOrDefault();

                return productId ?? "Unknown";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn mã sản phẩm: " + ex.Message);
            }
        }

        public bool UpdateChiTietPhieuNhapList(List<ChiTietPhieuNhap> updatedList, string maPN)
        {
            try
            {
                var existingDetails = db.ChiTietPhieuNhaps.Where(ct => ct.MaPhieuNhap == maPN).ToList();

                // Tạo HashSet cho các MaChiTietPhieuNhap trong updatedList
                var updatedIds = new HashSet<string>(updatedList.Select(item => item.MaChiTietPhieuNhap));

                // Xóa các mục không còn trong updatedList
                var itemsToDelete = existingDetails
                    .Where(dbItem => !updatedIds.Contains(dbItem.MaChiTietPhieuNhap))
                    .ToList();

                foreach (var item in itemsToDelete)
                {
                    db.ChiTietPhieuNhaps.DeleteOnSubmit(item);
                }

                // Cập nhật hoặc thêm mới các mục
                foreach (var updatedItem in updatedList)
                {
                    var existingItem = existingDetails
                        .FirstOrDefault(dbItem => dbItem.MaChiTietPhieuNhap == updatedItem.MaChiTietPhieuNhap);

                    if (existingItem != null)
                    {
                        // Cập nhật
                        existingItem.DonViTinh = updatedItem.DonViTinh;
                        existingItem.SoLuong = updatedItem.SoLuong;
                        existingItem.DonGia = updatedItem.DonGia;
                        existingItem.ThanhTien = updatedItem.ThanhTien;
                        existingItem.TrangThai = updatedItem.TrangThai;
                        existingItem.GhiChu = updatedItem.GhiChu;
                    }
                    else
                    {
                        // Thêm mới
                        db.ChiTietPhieuNhaps.InsertOnSubmit(updatedItem);
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật danh sách ChiTietPhieuNhap: " + ex.Message);
                return false;
            }




        }
    }

}
