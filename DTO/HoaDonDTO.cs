using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        public string MaHoaDon { get; set; }
        public DateTime? NgayLap { get; set; }
        public int? TongSanPham { get; set; }
        public decimal? TongTien { get; set; }
        public decimal? DiemCongTichLuy { get; set; }
        public decimal? DiemTichLuy { get; set; }
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
    }
}
