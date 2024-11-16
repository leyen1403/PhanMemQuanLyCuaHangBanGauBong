using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuDoiTraDTO
    {
        public string MaChiTietHD { get; set; }
        public string MaNhanVien { get; set; }
        public string LyDoDoiTra { get; set; }
        public string TinhTrangSanPham { get; set; }
        public int? SoLuongDoi { get; set; }
        public decimal? TongTienHoan { get; set; }
        public string GhiChu { get; set; }
    }
}
