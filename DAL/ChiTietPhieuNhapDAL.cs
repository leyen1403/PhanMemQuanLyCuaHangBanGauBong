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
                // Lấy danh sách các chi tiết phiếu nhập hiện tại từ cơ sở dữ liệu
                var existingDetails = db.ChiTietPhieuNhaps
                    .Where(ct => ct.MaPhieuNhap == maPN)
                    .ToList();

                // Tạo HashSet chứa các mã chi tiết từ danh sách mới (để so sánh)
                var updatedIds = new HashSet<string>(updatedList.Select(item => item.MaChiTietPhieuNhap));

                // Xác định các mục cần xóa (có trong CSDL nhưng không có trong danh sách mới)
                var itemsToDelete = existingDetails
                    .Where(dbItem => !updatedIds.Contains(dbItem.MaChiTietPhieuNhap))
                    .ToList();

                // Xóa các mục trong CSDL
                if (itemsToDelete.Any())
                {
                    db.ChiTietPhieuNhaps.DeleteAllOnSubmit(itemsToDelete);
                }

                // Duyệt qua danh sách mới để cập nhật hoặc thêm mới
                foreach (var updatedItem in updatedList)
                {
                    var existingItem = existingDetails
                        .FirstOrDefault(dbItem => dbItem.MaChiTietPhieuNhap == updatedItem.MaChiTietPhieuNhap);

                    if (existingItem != null)
                    {
                        // Nếu tồn tại, cập nhật dữ liệu
                        existingItem.DonViTinh = updatedItem.DonViTinh;
                        existingItem.SoLuong = updatedItem.SoLuong;
                        existingItem.DonGia = updatedItem.DonGia;
                        existingItem.ThanhTien = updatedItem.ThanhTien;
                        existingItem.TrangThai = updatedItem.TrangThai;
                        existingItem.GhiChu = updatedItem.GhiChu;
                    }
                    else
                    {
                        // Nếu chưa tồn tại, thêm mới
                        db.ChiTietPhieuNhaps.InsertOnSubmit(updatedItem);
                    }
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc hiển thị thông báo
                Console.WriteLine("Lỗi khi cập nhật danh sách ChiTietPhieuNhap: " + ex.Message);
                return false;
            }




        }

        public bool DeleteChiTietPhieuNhap(string maChiTietPhieuNhap)
        {
            try
            {
                var chiTietPhieuNhap = db.ChiTietPhieuNhaps.FirstOrDefault(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
                if (chiTietPhieuNhap != null)
                {
                    db.ChiTietPhieuNhaps.DeleteOnSubmit(chiTietPhieuNhap);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public bool UpdateAndDeleteChiTietPhieuNhap(List<ChiTietPhieuNhap> updatedList, List<ChiTietPhieuNhap> deletedItems,string maPN)
        {
            try
            {
                using (var transaction = db.Connection.BeginTransaction())
                {
                    // Xóa các mục trong deletedItems
                    foreach (var item in deletedItems)
                    {
                        var dbItem = db.ChiTietPhieuNhaps
                            .FirstOrDefault(ct => ct.MaChiTietPhieuNhap == item.MaChiTietPhieuNhap);
                        if (dbItem != null)
                        {
                            db.ChiTietPhieuNhaps.DeleteOnSubmit(dbItem);
                        }
                    }

                    // Cập nhật hoặc thêm mới các mục trong updatedList
                    foreach (var updatedItem in updatedList)
                    {
                        var dbItem = db.ChiTietPhieuNhaps
                            .FirstOrDefault(ct => ct.MaChiTietPhieuNhap == updatedItem.MaChiTietPhieuNhap);

                        if (dbItem != null)
                        {
                            // Cập nhật
                            dbItem.DonViTinh = updatedItem.DonViTinh;
                            dbItem.SoLuong = updatedItem.SoLuong;
                            dbItem.DonGia = updatedItem.DonGia;
                            dbItem.ThanhTien = updatedItem.ThanhTien;
                            dbItem.TrangThai = updatedItem.TrangThai;
                            dbItem.GhiChu = updatedItem.GhiChu;
                        }
                        else
                        {
                            // Thêm mới
                            db.ChiTietPhieuNhaps.InsertOnSubmit(updatedItem);
                        }
                    }

                    // Lưu thay đổi
                    db.SubmitChanges();
                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return false;
            }
        }

    }

}
