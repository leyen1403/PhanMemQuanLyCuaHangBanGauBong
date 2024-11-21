using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class HoaDonBanHangDAL
    {
        // Giả sử bạn có một context của Entity Framework hoặc một đối tượng db liên kết với cơ sở dữ liệu
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public HoaDonBanHangDAL()
        {
           
        }

        // 1. Thêm hóa đơn bán hàng
        public bool AddHoaDonBanHang(HoaDonBanHang hoaDon)
        {
            try
            {
                if (hoaDon == null)
                {
                    throw new ArgumentNullException(nameof(hoaDon), "Hóa đơn không thể là null.");
                }

                // Kiểm tra xem db có dữ liệu không
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có kết nối đến cơ sở dữ liệu.");
                }

                // Thêm hóa đơn vào bảng HoaDonBanHangs
                db.HoaDonBanHangs.InsertOnSubmit(hoaDon);
                db.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); // In thông báo lỗi
                return false; // Trả về false nếu có lỗi
            }
        }

        // 5. Lấy mã hóa đơn bán hàng mới nhất
        public string GetLatestHoaDonBanHangId()
        {
            try
            {
                // Giả định mã hóa đơn có dạng "HD0001", "HD0002", ...
                var latestHoaDon = db.HoaDonBanHangs
                    .OrderByDescending(hd => int.Parse(hd.MaHoaDonBanHang.Substring(2))) // Lấy phần số từ mã hóa đơn
                    .Select(hd => hd.MaHoaDonBanHang)
                    .FirstOrDefault();

                return latestHoaDon;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy mã hóa đơn mới nhất: " + ex.Message);
                return null; // Trả về null nếu có lỗi
            }
        }



        // 4. Lấy tất cả hóa đơn bán hàng
        public List<HoaDonBanHang> GetAllHoaDonBanHang()
        {
            try
            {
                if (db == null)
                {
                    throw new InvalidOperationException("Chưa có dữ liệu");
                }

                var hoaDonList = db.HoaDonBanHangs.ToList();
                return hoaDonList ?? new List<HoaDonBanHang>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<HoaDonBanHang>();
            }
        }
        // 2. Lọc hóa đơn theo mã khách hàng
        public List<HoaDonBanHang> GetHoaDonByMaKhachHang(string maKhachHang)
        {
            try
            {
                return db.HoaDonBanHangs
                    .Where(hd => hd.MaKhachHang == maKhachHang)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo mã khách hàng: " + ex.Message);
                return new List<HoaDonBanHang>();
            }
        }

        public List<HoaDonBanHang> GetHoaDonByMaNhanVien(string maNhanVien)
        {
            try
            {
                return db.HoaDonBanHangs
                    .Where(hd => hd.MaNhanVien == maNhanVien)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo mã nhân viên: " + ex.Message);
                return new List<HoaDonBanHang>();
            }
        }

        public List<HoaDonBanHang> GetHoaDonByMaHoaDon(string maHoaDon)
        {
            try
            {
                return db.HoaDonBanHangs
                    .Where(hd => hd.MaHoaDonBanHang == maHoaDon)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo mã hóa đơn: " + ex.Message);
                return new List<HoaDonBanHang>();
            }
        }
        public List<HoaDonBanHang> GetHoaDonByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return db.HoaDonBanHangs
                    .Where(hd => hd.NgayLap >= startDate && hd.NgayLap <= endDate)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy hóa đơn theo khoảng thời gian: " + ex.Message);
                return new List<HoaDonBanHang>();
            }
        }
        public bool UpdateHoaDonBanHang(HoaDonBanHang hoaDon)
        {
            try
            {
                var existingHoaDon = db.HoaDonBanHangs.FirstOrDefault(hd => hd.MaHoaDonBanHang == hoaDon.MaHoaDonBanHang);
                if (existingHoaDon == null)
                {
                    Console.WriteLine("Không tìm thấy hóa đơn để cập nhật.");
                    return false;
                }

                existingHoaDon.MaKhachHang = hoaDon.MaKhachHang;
                existingHoaDon.MaNhanVien = hoaDon.MaNhanVien;
                existingHoaDon.TongSanPham = hoaDon.TongSanPham;
                existingHoaDon.DiemCongTichLuy= hoaDon.DiemCongTichLuy;
                existingHoaDon.DiemTichLuy = hoaDon.DiemTichLuy;
                existingHoaDon.TongTien = hoaDon.TongTien;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hóa đơn: " + ex.Message);
                return false;
            }
        }

        public DataTable GetTongTienTheoNgayDataTable()
        {
            // Lấy dữ liệu nhóm theo ngày
            var tongTienTheoNgay = db.HoaDonBanHangs
                .Where(hd => hd.NgayLap.HasValue) // Chỉ lấy các hóa đơn có NgayLap
                .GroupBy(hd => hd.NgayLap.Value.Date) // Nhóm theo ngày
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongTien = g.Sum(hd => hd.TongTien)
                }).ToList();

            // Tạo DataTable để trả về
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            // Thêm dữ liệu vào DataTable
            foreach (var item in tongTienTheoNgay)
            {
                dataTable.Rows.Add(item.Ngay, item.TongTien);
            }

            return dataTable;
        }


        // Nam viết thêm
        public DataTable GetTongTienTheoNgayDataTable(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Lấy dữ liệu nhóm theo ngày
            var tongTienTheoNgay = db.HoaDonBanHangs
                .Where(hd => hd.NgayLap.HasValue && // Lọc các hóa đơn có NgayLap
                             hd.NgayLap.Value >= ngayBatDau &&
                             hd.NgayLap.Value <= ngayKetThuc)
                .GroupBy(hd => hd.NgayLap.Value.Date) // Nhóm theo ngày
                .Select(g => new
                {
                    Ngay = g.Key,
                    TongTien = g.Sum(hd => hd.TongTien)
                }).ToList();

            // Tạo DataTable để trả về
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Ngày", typeof(DateTime));
            dataTable.Columns.Add("Tổng tiền", typeof(decimal));

            foreach (var item in tongTienTheoNgay)
            {
                dataTable.Rows.Add(item.Ngay, item.TongTien);
            }

            return dataTable;
        }


        public List<PhieuBaoCao> LayPhieuBaoCaoTheoKhoangThoiGian(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            // Lọc các hóa đơn bán hàng trong khoảng thời gian từ ngày bắt đầu đến ngày kết thúc
            var donHangs = db.HoaDonBanHangs
                .Where(dh => dh.NgayLap.HasValue
                             && dh.NgayLap.Value >= ngayBatDau.Date
                             && dh.NgayLap.Value < ngayKetThuc.Date.AddDays(1)) // so sánh ngày kết thúc với 23:59:59
                .ToList();

            Console.WriteLine($"Số hóa đơn bán hàng trong khoảng thời gian: {donHangs.Count}");  // Thêm log kiểm tra

            List<PhieuBaoCao> danhSachPhieuBaoCao = new List<PhieuBaoCao>();
            int i = 1;

            foreach (var donHang in donHangs)
            {
                // Lọc chi tiết đơn hàng cho từng hóa đơn
                var chiTietDonHangs = db.ChiTietHoaDonBanHangs
                    .Where(ct => ct.MaHoaDon == donHang.MaHoaDonBanHang)
                    .ToList();

                Console.WriteLine($"Số chi tiết đơn hàng trong hóa đơn {donHang.MaHoaDonBanHang}: {chiTietDonHangs.Count}");

                foreach (var chiTiet in chiTietDonHangs)
                {
                    // Lấy thông tin sản phẩm
                    var sanPham = db.SanPhams
                        .FirstOrDefault(sp => sp.MaSanPham == chiTiet.MaSanPham);

                    if (sanPham != null)
                    {
                        // Tính thành tiền
                        decimal thanhTien = (chiTiet.SoLuong ?? 0) * (sanPham.GiaBan ?? 0);

                        // Tạo báo cáo
                        PhieuBaoCao pbc = new PhieuBaoCao
                        {
                            STT = i.ToString(),
                            MASANPHAM = sanPham.MaSanPham,
                            TENSANPHAM = sanPham.TenSanPham,
                            SOLUONG = chiTiet.SoLuong ?? 0,
                            DONGIA = sanPham.GiaBan ?? 0,
                            THANHTIEN = thanhTien,
                            NGAY = donHang.NgayLap ?? DateTime.MinValue
                        };

                        danhSachPhieuBaoCao.Add(pbc);
                        i++;
                    }
                }
            }

            Console.WriteLine($"Số phiếu báo cáo: {danhSachPhieuBaoCao.Count}");

            return danhSachPhieuBaoCao;
        }







    }

}

