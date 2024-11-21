using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietPN
    {
        public int STT { get; set; }
        public string MaSanPham { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // Hàm khởi tạo
        public ChiTietPN(ChiTietPhieuNhap ct, int stt, db_QLCHBGBDataContext db)
        {
            this.STT = stt;
            this.SoLuong = ct.SoLuong ?? 0;
            this.DonGia = ct.DonGia ?? 0;
            this.ThanhTien = ct.ThanhTien ?? 0;

            // Lấy mã sản phẩm từ ChiTietDonDatHang
            var chiTietDonDatHang = db.ChiTietDonDatHangs.FirstOrDefault(c => c.MaChiTietDonDatHang == ct.MaChiTietDonDatHang);
            if (chiTietDonDatHang != null)
            {
                this.MaSanPham = chiTietDonDatHang.MaSanPham; 

                // Lấy tên sản phẩm từ bảng SanPhams
                var sanPham = db.SanPhams.FirstOrDefault(s => s.MaSanPham == chiTietDonDatHang.MaSanPham);
                this.TenSP = sanPham?.TenSanPham ?? "Không xác định"; 
            }
            else
            {
                this.MaSanPham = "Không xác định";
                this.TenSP = "Không xác định";
            }
        }
    }



}
