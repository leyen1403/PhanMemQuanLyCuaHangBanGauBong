using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;


namespace GUI
{
    public partial class frm_lapPhieuDichVu : Form
    {
        List<SanPham> sanPhams = new List<SanPham>();
        SanPhamBLL sanPhamBll = new SanPhamBLL();

        List<HoaDonBanHang> HoaDons = new List<HoaDonBanHang>();
        HoaDonBanHangBLL hoaDonBanHangBll = new HoaDonBanHangBLL();

        List<KhachHang> khachHangs = new List<KhachHang>();  // Danh sách khách hàng
        KhachHangBLL khachHangBll = new KhachHangBLL();

        List<ChiTietHoaDonBanHang> chiTietHoaDonBanHangs = new List<ChiTietHoaDonBanHang>();  // Danh sách khách hàng
        ChiTietHoaDonBanHangBLL chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL();

        public frm_lapPhieuDichVu()
        {
            InitializeComponent();
            HoaDons = hoaDonBanHangBll.GetAllHoaDonBanHang();
            txt_NgayLap.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txt_MPDV.Text = new PhieuDichVuBLL().GetLatestMaPhieuDichVu();
            txt_MPDV.ReadOnly = true;
            txt_MaKH.ReadOnly = true;
            txt_TenKH.ReadOnly = true;
            txt_LanDichVu.ReadOnly = true;
            txt_TenSP.ReadOnly = true;
            this.Load += Frm_lapPhieuDichVu_Load;
            dgv_HoaDon.SelectionChanged += Dgv_HoaDon_SelectionChanged;
            dgv_ChiTietHoaDon.CellClick += Dgv_ChiTietHoaDon_CellClick;

            // Thêm các lựa chọn vào ComboBox
            cb_TimKiem.Items.Add("Mã Hóa Đơn");
            cb_TimKiem.Items.Add("Ngày Lập");
            cb_TimKiem.Items.Add("Mã Khách Hàng");
            cb_TimKiem.Items.Add("Mã Nhân Viên");

            cb_TimKiem.SelectedIndex = 0;


        }

        // Phương thức kiểm tra số điện thoại
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Kiểm tra nếu số điện thoại rỗng
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Dùng regex để kiểm tra số điện thoại (10 hoặc 11 chữ số)
            string pattern = @"^\d{10,11}$";  // Điều kiện: chỉ chứa số và có độ dài 10 hoặc 11 ký tự
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Nếu số điện thoại hợp lệ
            return true;
        }
        private void Dgv_ChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string maSanPham = dgv_ChiTietHoaDon.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();
                string maChiTietHoaDon = dgv_ChiTietHoaDon.Rows[e.RowIndex].Cells["MaChiTietHoaDonBanHang"].Value.ToString();

                var sanPham = sanPhams.FirstOrDefault(sp => sp.MaSanPham == maSanPham);
                txt_TenSP.Text = sanPham?.TenSanPham ?? "Không tìm thấy sản phẩm";

                // Lấy lần dịch vụ tiếp theo và hiển thị trên txt_LanDichVu
                int nextLanDichVu = new NhatKyDichVuBLL().GetLatestLanDichVu(maChiTietHoaDon);
                txt_LanDichVu.Text = nextLanDichVu.ToString();
            }
        }


        private void Dgv_HoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_HoaDon.CurrentRow != null)
            {
                string maHoaDon = dgv_HoaDon.CurrentRow.Cells["MaHoaDonBanHang"].Value.ToString();
                LoadChiTietHoaDonData(maHoaDon);
                LoadKhachHangInfo(maHoaDon);
            }
        }
        private void LoadKhachHangInfo(string maHoaDon)
        {
            // Lấy mã khách hàng từ hóa đơn
            var hoaDon = HoaDons.FirstOrDefault(hd => hd.MaHoaDonBanHang == maHoaDon);
            if (hoaDon != null)
            {
                string maKhachHang = hoaDon.MaKhachHang;

                // Kiểm tra xem danh sách khách hàng có dữ liệu không
                if (khachHangs.Count == 0)
                {
                    khachHangs = khachHangBll.GetAllKhachHangs();  // Lấy danh sách khách hàng từ BLL
                }

                // Tìm thông tin khách hàng từ mã khách hàng
                var khachHang = khachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang != null)
                {
                    // Hiển thị thông tin khách hàng lên các textbox
                    txt_MaKH.Text = khachHang.MaKhachHang;
                    txt_TenKH.Text = khachHang.TenKhachHang;
                    txt_SDT.Text = khachHang.SoDienThoai;
                }
                else
                {
                    // Nếu không tìm thấy khách hàng
                    txt_MaKH.Text = "Không tìm thấy";
                    txt_TenKH.Text = "Không tìm thấy";
                    txt_SDT.Text = "Không tìm thấy";
                }
            }
        }
        private void Frm_lapPhieuDichVu_Load(object sender, EventArgs e)
        {
            LoadSanPhamData(); // Đảm bảo sanPhams được nạp dữ liệu
            LoadHoaDonData();
            txt_MaNV.Text = "NV001";
            LoadEmployeeName("NV001"); // Lấy tên nhân viên cho MaNV mặc định
        }

        private void LoadSanPhamData()
        {
            sanPhams = sanPhamBll.GetProductList(); // Nạp danh sách sản phẩm

            // Kiểm tra xem sanPhams có dữ liệu hay không
            if (sanPhams.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống!");
            }
        }

        private void LoadHoaDonData()
        {
            dgv_HoaDon.DataSource = HoaDons;

            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();

            dgv_HoaDon.Columns["MaHoaDonBanHang"].HeaderText = "Mã Hóa Đơn";
            dgv_HoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dgv_HoaDon.Columns["TongSanPham"].HeaderText = "Tổng Sản Phẩm";
            dgv_HoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgv_HoaDon.Columns["DiemCongTichLuy"].HeaderText = "Điểm Cộng Tích Lũy";
            dgv_HoaDon.Columns["DiemTichLuy"].HeaderText = "Điểm Tích Lũy";
            dgv_HoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dgv_HoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";

            dgv_HoaDon.Columns["KhachHang"].Visible = false;
            dgv_HoaDon.Columns["NhanVien"].Visible = false;
        }

        private void LoadChiTietHoaDonData(string maHoaDon)
        {
            var chiTietHoaDons = chiTietHoaDonBanHangBLL.GetChiTietHoaDonByMaHoaDon(maHoaDon); // Lấy theo mã hóa đơn
            dgv_ChiTietHoaDon.DataSource = chiTietHoaDons;

            // Định dạng cột và ẩn các cột không cần thiết
            dgv_ChiTietHoaDon.Columns["MaChiTietHoaDonBanHang"].HeaderText = "Mã Chi Tiết HĐ";
            dgv_ChiTietHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
            dgv_ChiTietHoaDon.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
            dgv_ChiTietHoaDon.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgv_ChiTietHoaDon.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgv_ChiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dgv_ChiTietHoaDon.Columns["GhiChu"].HeaderText = "Ghi Chú";

            // Ẩn các cột không cần thiết
            dgv_ChiTietHoaDon.Columns["SanPham"].Visible = false;
            dgv_ChiTietHoaDon.Columns["HoaDonBanHang"].Visible = false;
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_NgayLap_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_lapPhieuDichVu_Load_1(object sender, EventArgs e)
        {

        }
        private bool ValidateFormData()
        {
            if (string.IsNullOrEmpty(txt_MPDV.Text) ||
                string.IsNullOrEmpty(txt_MaKH.Text) ||
                string.IsNullOrEmpty(txt_MaNV.Text) ||
                string.IsNullOrEmpty(txt_DiaChi.Text) ||
                string.IsNullOrEmpty(txt_GhiChu.Text) ||
                string.IsNullOrEmpty(txt_TongTien.Text) ||
                string.IsNullOrEmpty(txt_NgayLap.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return false;
            }

            decimal tongTien;
            if (!decimal.TryParse(txt_TongTien.Text, out tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ!");
                return false;
            }

            DateTime ngayLap;
            if (!DateTime.TryParse(txt_NgayLap.Text, out ngayLap))
            {
                MessageBox.Show("Ngày lập không hợp lệ!");
                return false;
            }

            return true;
        }
        private string GenerateNewMaPhieuDichVu()
        {
            var phieuDichVuBll = new PhieuDichVuBLL();
            string lastMaPhieuDichVu = phieuDichVuBll.GetLatestMaPhieuDichVu();

            if (!string.IsNullOrEmpty(lastMaPhieuDichVu) && lastMaPhieuDichVu.StartsWith("PDV"))
            {
                int number = int.Parse(lastMaPhieuDichVu.Substring(3)) + 0;
                return $"PDV{number:D3}";
            }
            else
            {
                return "PDV001";
            }
        }


        private void ResetTextBoxes()
        {
            txt_MPDV.Text = GenerateNewMaPhieuDichVu(); // Hoặc tự động tạo mã mới
            txt_NgayLap.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Đặt lại ngày giờ hiện tại
            txt_MaKH.Text = "";
            txt_MaNV.Text = "";
            txt_TongTien.Text = "";
            txt_GhiChu.Text = "";
            txt_TenKH.Text = "";
            txt_SDT.Text = "";
            txt_TenSP.Text = "";
            txt_DiaChi.Text = "";
            txt_LanDichVu.Text = "";
        }
        private void btn_LuuPDV_Click(object sender, EventArgs e)
        {
            string sdt = txt_SDT.Text.Trim();  // Lấy giá trị số điện thoại từ textbox

            // Gọi phương thức kiểm tra số điện thoại
            if (!IsValidPhoneNumber(sdt))
            {
                // Nếu số điện thoại không hợp lệ, dừng lại
                return;
            }

            if (!ValidateFormData()) return;

            string employeeId = new NhanVienBLL().GetEmployeeIdFromName(txt_MaNV.Text); // Get employee ID by name
            if (employeeId == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên!");
                return;
            }

            string errorMessage;
            PhieuDichVu phieuDichVu = new PhieuDichVu
            {
                MaPhieuDichVu = txt_MPDV.Text,
                NgayLap = DateTime.Parse(txt_NgayLap.Text),
                TongTien = decimal.Parse(txt_TongTien.Text),
                MaKhachHang = txt_MaKH.Text,
                MaNhanVien = employeeId, // Use employee ID here
                GhiChu = txt_GhiChu.Text,
                TrangThai = true,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now
            };

            bool isSaved = new PhieuDichVuBLL().SavePhieuDichVu(phieuDichVu, out errorMessage);
            if (isSaved)
            {
                // Tạo bản ghi Nhật ký dịch vụ
                var maChiTietHoaDon = dgv_ChiTietHoaDon.CurrentRow.Cells["MaChiTietHoaDonBanHang"].Value.ToString();
                var lanDichVu = new NhatKyDichVuBLL().GenerateLanDichVu(maChiTietHoaDon);

                NhatKyDichVu nhatKyDichVu = new NhatKyDichVu
                {
                    Landichvu = lanDichVu,
                    MaChiTietHoaDonBanHang = maChiTietHoaDon,
                    MaPhieuDichVu = txt_MPDV.Text
                };

                bool isLogSaved = new NhatKyDichVuBLL().SaveNhatKyDichVu(nhatKyDichVu, out errorMessage);
                if (isLogSaved)
                {
                    MessageBox.Show("Lưu thành công!");
                    ResetTextBoxes(); // Reset các ô TextBox sau khi lưu thành công
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu Nhật ký dịch vụ: " + errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu Phiếu Dịch Vụ: " + errorMessage);
            }
        }

        private void btn_InPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo ứng dụng Word
                Word.Application wordApp = new Word.Application();
                Word.Document document = wordApp.Documents.Add();

                // Thêm tiêu đề chính cho phiếu dịch vụ
                Word.Paragraph title = document.Content.Paragraphs.Add();
                title.Range.Text = "PHIẾU DỊCH VỤ";
                title.Range.Font.Size = 26;
                title.Range.Font.Name = "Calibri";
                title.Range.Font.Bold = 1;
                title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                // Thông tin công ty (tên công ty, địa chỉ, điện thoại)
                Word.Paragraph companyInfo = document.Content.Paragraphs.Add();
                companyInfo.Range.Text = "Cửa hàng Gấu Bông\nĐịa chỉ: 123 Đường ABC, TP. HCM\nSố điện thoại: 0901234567";
                companyInfo.Range.Font.Size = 12;
                companyInfo.Range.Font.Name = "Arial";
                companyInfo.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                companyInfo.Range.InsertParagraphAfter();

                // Đoạn văn bản ngắn tóm tắt về phiếu dịch vụ
                Word.Paragraph description = document.Content.Paragraphs.Add();
                description.Range.Text = "Phiếu dịch vụ này xác nhận việc cung cấp dịch vụ cho khách hàng theo yêu cầu. Vui lòng kiểm tra thông tin dưới đây.";
                description.Range.Font.Size = 12;
                description.Range.Font.Name = "Arial";
                description.Range.Italic = 1;
                description.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                description.Range.InsertParagraphAfter();

                // Thêm đường phân cách giữa các phần
                Word.Paragraph separator = document.Content.Paragraphs.Add();
                separator.Range.Text = new string('-', 80); // Dòng phân cách dài
                separator.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                separator.Range.InsertParagraphAfter();

                // Thêm phần "Thông Tin Phiếu Dịch Vụ"
                Word.Paragraph sectionTitle1 = document.Content.Paragraphs.Add();
                sectionTitle1.Range.Text = "Thông Tin Phiếu Dịch Vụ";
                sectionTitle1.Range.Font.Size = 14;
                sectionTitle1.Range.Font.Bold = 1;
                sectionTitle1.Range.Font.Name = "Calibri";
                sectionTitle1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                sectionTitle1.Range.InsertParagraphAfter();

                // Thêm thông tin phiếu dịch vụ dưới dạng văn bản
                Word.Paragraph info1 = document.Content.Paragraphs.Add();
                info1.Range.Text = $"Mã Phiếu Dịch Vụ: {txt_MPDV.Text}";
                info1.Range.Font.Size = 12;
                info1.Range.Font.Name = "Arial";
                info1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info1.Range.InsertParagraphAfter();

                Word.Paragraph info2 = document.Content.Paragraphs.Add();
                info2.Range.Text = $"Mã Nhân Viên: {txt_MaNV.Text}";
                info2.Range.Font.Size = 12;
                info2.Range.Font.Name = "Arial";
                info2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info2.Range.InsertParagraphAfter();

                Word.Paragraph info3 = document.Content.Paragraphs.Add();
                info3.Range.Text = $"Ngày Lập: {txt_NgayLap.Text}";
                info3.Range.Font.Size = 12;
                info3.Range.Font.Name = "Arial";
                info3.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info3.Range.InsertParagraphAfter();

                Word.Paragraph info4 = document.Content.Paragraphs.Add();
                info4.Range.Text = $"Lần Dịch Vụ: {txt_LanDichVu.Text}";
                info4.Range.Font.Size = 12;
                info4.Range.Font.Name = "Arial";
                info4.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info4.Range.InsertParagraphAfter();

                Word.Paragraph info5 = document.Content.Paragraphs.Add();
                info5.Range.Text = $"Ghi Chú: {txt_GhiChu.Text}";
                info5.Range.Font.Size = 12;
                info5.Range.Font.Name = "Arial";
                info5.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info5.Range.InsertParagraphAfter();

                // Thêm đường phân cách
                Word.Paragraph separator2 = document.Content.Paragraphs.Add();
                separator2.Range.Text = new string('-', 80); // Dòng phân cách dài
                separator2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                separator2.Range.InsertParagraphAfter();

                // Thêm phần "Thông Tin Khách Hàng"
                Word.Paragraph sectionTitle2 = document.Content.Paragraphs.Add();
                sectionTitle2.Range.Text = "Thông Tin Khách Hàng";
                sectionTitle2.Range.Font.Size = 14;
                sectionTitle2.Range.Font.Bold = 1;
                sectionTitle2.Range.Font.Name = "Calibri";
                sectionTitle2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                sectionTitle2.Range.InsertParagraphAfter();

                // Thêm thông tin khách hàng dưới dạng văn bản
                Word.Paragraph info6 = document.Content.Paragraphs.Add();
                info6.Range.Text = $"Tên Khách Hàng: {txt_TenKH.Text}";
                info6.Range.Font.Size = 12;
                info6.Range.Font.Name = "Arial";
                info6.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info6.Range.InsertParagraphAfter();

                Word.Paragraph info7 = document.Content.Paragraphs.Add();
                info7.Range.Text = $"Mã Khách Hàng: {txt_MaKH.Text}";
                info7.Range.Font.Size = 12;
                info7.Range.Font.Name = "Arial";
                info7.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info7.Range.InsertParagraphAfter();

                Word.Paragraph info8 = document.Content.Paragraphs.Add();
                info8.Range.Text = $"Số Điện Thoại: {txt_SDT.Text}";
                info8.Range.Font.Size = 12;
                info8.Range.Font.Name = "Arial";
                info8.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info8.Range.InsertParagraphAfter();

                Word.Paragraph info9 = document.Content.Paragraphs.Add();
                info9.Range.Text = $"Địa Chỉ: {txt_DiaChi.Text}";
                info9.Range.Font.Size = 12;
                info9.Range.Font.Name = "Arial";
                info9.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info9.Range.InsertParagraphAfter();

                Word.Paragraph info10 = document.Content.Paragraphs.Add();
                info10.Range.Text = $"Tổng Tiền: {txt_TongTien.Text}";
                info10.Range.Font.Size = 12;
                info10.Range.Font.Name = "Arial";
                info10.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                info10.Range.InsertParagraphAfter();

                // Thêm lời cảm ơn hoặc ghi chú cuối cùng
                Word.Paragraph footer = document.Content.Paragraphs.Add();
                footer.Range.Text = "Cảm ơn quý khách đã sử dụng dịch vụ của chúng tôi!";
                footer.Range.Font.Size = 12;
                footer.Range.Font.Name = "Arial";
                footer.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                footer.Range.InsertParagraphAfter();

                // Hiển thị ứng dụng Word
                wordApp.Visible = true;

                // Giải phóng tài nguyên
                document = null;
                wordApp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo tài liệu Word: " + ex.Message);
            }
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string searchValue = txt_TimKiem.Text.Trim();
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!");
                return;
            }

            string searchCriteria = cb_TimKiem.SelectedItem.ToString();
            SearchHoaDonData(searchCriteria, searchValue);
        }
        private void SearchHoaDonData(string searchCriteria, string searchValue)
        {
            // Lọc danh sách hóa đơn dựa trên tiêu chí tìm kiếm và giá trị tìm kiếm
            List<HoaDonBanHang> filteredHoaDons = new List<HoaDonBanHang>();

            switch (searchCriteria)
            {
                case "Mã Hóa Đơn":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaHoaDonBanHang.Contains(searchValue)).ToList();
                    break;
                case "Ngày Lập":
                    DateTime ngayLap;
                    if (DateTime.TryParse(searchValue, out ngayLap))
                    {
                        filteredHoaDons = HoaDons
                            .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Date == ngayLap.Date)
                            .ToList();
                    }
                    else
                    {
                        MessageBox.Show("Ngày lập không hợp lệ. Vui lòng nhập lại!");
                        return;
                    }
                    break;
                case "Mã Khách Hàng":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaKhachHang.Contains(searchValue)).ToList();
                    break;
                case "Mã Nhân Viên":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaNhanVien.Contains(searchValue)).ToList();
                    break;
                default:
                    MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ.");
                    return;
            }

            // Hiển thị danh sách hóa đơn đã lọc lên DataGridView
            dgv_HoaDon.DataSource = filteredHoaDons;

            if (filteredHoaDons.Count == 0)
            {
                MessageBox.Show("Không tìm thấy.");
            }
        }

        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            // Lọc danh sách hóa đơn dựa trên tiêu chí tìm kiếm và giá trị tìm kiếm
            List<HoaDonBanHang> filteredHoaDons = new List<HoaDonBanHang>();
            // Giả sử 'HoaDons' là danh sách chứa tất cả hóa đơn
            filteredHoaDons = HoaDons.ToList(); // Đưa toàn bộ hóa đơn vào danh sách hiển thị
            dgv_HoaDon.DataSource = filteredHoaDons;
        }
        private void LoadEmployeeName(string maNV)
        {
            // Lấy thông tin nhân viên từ BLL
            var nhanVien = new NhanVienBLL().GetNhanVienById(maNV);

            if (nhanVien != null)
            {
                // Hiển thị tên nhân viên vào TextBox txt_TenNV
                txt_MaNV.Text = nhanVien.HoTen; // Giả sử 'TenNhanVien' là trường chứa tên nhân viên
            }
            else
            {
                // Nếu không tìm thấy nhân viên
                txt_MaNV.Text = "Không tìm thấy nhân viên";
            }
        }

    }
}
