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
            cb_TimKiem.SelectedIndexChanged += cb_TimKiem_SelectedIndexChanged;
            // Thêm các lựa chọn vào ComboBox
            cb_TimKiem.Items.Add("Mã Hóa Đơn");
            cb_TimKiem.Items.Add("Ngày Lập");
            cb_TimKiem.Items.Add("Mã Khách Hàng");
            cb_TimKiem.Items.Add("Mã Nhân Viên");

            cb_TimKiem.SelectedIndex = 0;
            cb_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        // Phương thức kiểm tra số điện thoại
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string pattern = @"^\d{10,11}$";
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool IsValidTotalAmount(string totalAmount)
        {
            decimal tongTien;
            if (!decimal.TryParse(totalAmount, out tongTien) || tongTien <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ hoặc không được nhỏ hơn hoặc bằng 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                DateTime ngayLapHoaDon = Convert.ToDateTime(dgv_HoaDon.CurrentRow.Cells["NgayLap"].Value);
                int soNgay = (DateTime.Now - ngayLapHoaDon).Days;
                if (soNgay > 90)
                {
                    MessageBox.Show("Số ngày mua vượt quá 90, không thể sử dụng dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ResetTextBoxes();  
                }
                else
                {
                    LoadChiTietHoaDonData(maHoaDon);
                    LoadKhachHangInfo(maHoaDon);
                }
            }
        }
        private void LoadKhachHangInfo(string maHoaDon)
        {
            var hoaDon = HoaDons.FirstOrDefault(hd => hd.MaHoaDonBanHang == maHoaDon);
            if (hoaDon != null)
            {
                string maKhachHang = hoaDon.MaKhachHang;
                if (khachHangs.Count == 0)
                {
                    khachHangs = khachHangBll.GetAllKhachHangs(); 
                }
                var khachHang = khachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
                if (khachHang != null)
                {
                    txt_MaKH.Text = khachHang.MaKhachHang;
                    txt_TenKH.Text = khachHang.TenKhachHang;
                    txt_SDT.Text = khachHang.SoDienThoai;
                }
                else
                {
                    txt_MaKH.Text = "Không tìm thấy";
                    txt_TenKH.Text = "Không tìm thấy";
                    txt_SDT.Text = "Không tìm thấy";
                }
            }
        }
        private void Frm_lapPhieuDichVu_Load(object sender, EventArgs e)
        {
            
            LoadSanPhamData(); 
            LoadHoaDonData();
            txt_MaNV.Text = "NV001";
            LoadEmployeeName("NV001"); 
        }

        private void LoadSanPhamData()
        {
            sanPhams = sanPhamBll.GetProductList(); 
            if (sanPhams.Count == 0)
            {
                MessageBox.Show("Danh sách sản phẩm trống!");
            }
        }

        private void LoadHoaDonData()
        {
            dgv_HoaDon.DataSource = HoaDons; 
            dgv_HoaDon.Columns["MaHoaDonBanHang"].HeaderText = "Mã Hóa Đơn";
            dgv_HoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dgv_HoaDon.Columns["TongSanPham"].HeaderText = "Tổng Sản Phẩm";
            dgv_HoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgv_HoaDon.Columns["DiemCongTichLuy"].HeaderText = "Điểm Cộng Tích Lũy";
            dgv_HoaDon.Columns["DiemTichLuy"].HeaderText = "Điểm Tích Lũy";
            dgv_HoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dgv_HoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";

            if (dgv_HoaDon.Columns.Contains("KhachHang"))
                dgv_HoaDon.Columns["KhachHang"].Visible = false;

            if (dgv_HoaDon.Columns.Contains("NhanVien"))
                dgv_HoaDon.Columns["NhanVien"].Visible = false;
        }


        private void LoadChiTietHoaDonData(string maHoaDon)
        {
            var chiTietHoaDons = chiTietHoaDonBanHangBLL.GetChiTietHoaDonByMaHoaDon(maHoaDon); 
            dgv_ChiTietHoaDon.DataSource = chiTietHoaDons;

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
                string.IsNullOrEmpty(txt_GhiChu.Text) ||
                string.IsNullOrEmpty(txt_TongTien.Text) ||
                string.IsNullOrEmpty(txt_NgayLap.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
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
            txt_TongTien.Text = "";
            txt_GhiChu.Text = "";
            txt_TenKH.Text = "";
            txt_SDT.Text = "";
            txt_TenSP.Text = "";
            txt_DiaChi.Text = "";
            txt_LanDichVu.Text = "";
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            List<HoaDonBanHang> filteredHoaDons = new List<HoaDonBanHang>();
            string searchCriteria = cb_TimKiem.SelectedItem.ToString(); 
            string searchValue = txt_TimKiem.Text.Trim(); 

            if (string.IsNullOrEmpty(searchValue) && searchCriteria != "Ngày Lập")
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (searchCriteria)
            {
                case "Mã Hóa Đơn":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaHoaDonBanHang.Contains(searchValue)).ToList();
                    break;

                case "Mã Khách Hàng":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaKhachHang.Contains(searchValue)).ToList();
                    break;

                case "Mã Nhân Viên":
                    filteredHoaDons = HoaDons.Where(hd => hd.MaNhanVien.Contains(searchValue)).ToList();
                    break;

                case "Ngày Lập":
                    // Kiểm tra nếu dtpTuNgay lớn hơn hoặc bằng dtpDenNgay
                    if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng việc tìm kiếm
                    }
                    DateTime fromDate = dtpTuNgay.Value.Date;
                    DateTime toDate = dtpDenNgay.Value.Date;

                    filteredHoaDons = HoaDons.Where(hd => hd.NgayLap >= fromDate && hd.NgayLap <= toDate).ToList();
                    break;

                default:
                    MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            if (filteredHoaDons.Count > 0)
            {
                dgv_HoaDon.DataSource = filteredHoaDons;
                dgv_HoaDon.Columns["KhachHang"].Visible = false;
                dgv_HoaDon.Columns["NhanVien"].Visible = false;
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv_HoaDon.DataSource = null; // Xóa dữ liệu nếu không tìm thấy kết quả
            }
        }


        private void cb_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TimKiem.SelectedItem.ToString() == "Ngày Lập")
            {
                dtpTuNgay.Enabled = true;
                dtpDenNgay.Enabled = true;
                txt_TimKiem.Enabled = false;

            }
            else
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
                txt_TimKiem.Enabled = true;


            }
        }

        private void btn_LuuPDV_Click(object sender, EventArgs e)
        {
            if (!ValidateFormData())
            {
                return;
            }
            if (txt_LanDichVu.Text == "3")
            {
                MessageBox.Show("Không thể lưu phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng việc lưu
            }

            string employeeName = txt_MaNV.Text;
            string employeeId = new NhanVienBLL().GetEmployeeIdFromName(employeeName);
            string errorMessage;
            PhieuDichVu phieuDichVu = new PhieuDichVu
            {
                MaPhieuDichVu = txt_MPDV.Text.Length > 10 ? txt_MPDV.Text.Substring(0, 10) : txt_MPDV.Text,
                NgayLap = DateTime.Parse(txt_NgayLap.Text),
                TongTien = decimal.Parse(txt_TongTien.Text),
                MaKhachHang = txt_MaKH.Text.Length > 10 ? txt_MaKH.Text.Substring(0, 10) : txt_MaKH.Text,
                MaNhanVien = employeeId, 
                GhiChu = txt_GhiChu.Text.Length > 255 ? txt_GhiChu.Text.Substring(0, 255) : txt_GhiChu.Text,
                TrangThai = false,
                NgayTao = DateTime.Now,
                NgayCapNhat = DateTime.Now
            };



            bool isSaved = new PhieuDichVuBLL().SavePhieuDichVu(phieuDichVu, out errorMessage);
            if (isSaved)
            {
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
            if (!ValidateFormData())
            {
                // Nếu hàm ValidateFormData trả về false (dữ liệu không hợp lệ), dừng lại
                return;
            }
            if (txt_LanDichVu.Text == "3")
            {
                // Hiển thị thông báo lỗi và ngừng thực hiện in
                MessageBox.Show("Không thể in phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Ngừng việc in
            }
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

        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            List<HoaDonBanHang> filteredHoaDons = new List<HoaDonBanHang>();
            filteredHoaDons = HoaDons.ToList(); 
            dgv_HoaDon.DataSource = filteredHoaDons;
        }
        private void LoadEmployeeName(string maNV)
        {
            var nhanVien = new NhanVienBLL().GetNhanVienById(maNV);

            if (nhanVien != null)
            {
                txt_MaNV.Text = nhanVien.HoTen;
            }
            else
            {
                txt_MaNV.Text = "Không tìm thấy nhân viên";
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txt_LanDichVu_TextChanged(object sender, EventArgs e)
        {
            if (txt_LanDichVu.Text == "3")
            {
                MessageBox.Show("Đã đạt 3 lần dịch vụ, không thể thêm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txt_TongTien_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidTotalAmount(txt_TongTien.Text))
            {
                e.Cancel = true; 
            }
        }

        private void txt_SDT_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!IsValidPhoneNumber(txt_SDT.Text))
            {
                e.Cancel = true; 
            }
        }
    }
}
