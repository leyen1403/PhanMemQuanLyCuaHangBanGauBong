using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using UC;
using DTO;
using BLL;
using System.Collections.Generic;
using System.IO;

namespace GUI
{
    public partial class frm_lapHoaDon : Form
    {
        ProductItem productSelected = null;
        public string _maNhanVien { get; set; }
        //    public string maNV = "NV001";
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        KhachHangBLL _khachHangBLL= new KhachHangBLL();
        HoaDonBanHangBLL _hoaDonBanHangBLL = new HoaDonBanHangBLL();
        ChiTietHoaDonBanHangBLL _chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL() ;
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        int currentPage = 1;
        int pageSize = 15;
        int totalRecords;

        private string _maHD=string.Empty;
        public frm_lapHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_lapHoaDon_Load;
            loadNgayHT();
            txt_tenSanPham.Text = "Nhập thông tin sản phẩm";
            txt_tenSanPham.ForeColor = Color.Black;
            txt_TongSL.Enabled = txt_tongTien.Enabled = txt_diemTichLuy.Enabled = false;
            dsSanPham.AutoScroll = true;
            loadComBoxLoai();
            txt_soLuong.Minimum = 1;
            txt_soLuong.Maximum = 100;
            txt_soLuong.Value = 1;
            LoadComBoxSanPham();
            LoadHinhThucGiaoHang();
            LoadComBoBoxLoaiKhachHang();
            LoadHinhThucThanhToan();
            // Gán sự kiện trong phần khởi tạo
            txt_soDienThoai.KeyPress += Txt_soDienThoai_KeyPress;
            txt_soDienThoai.TextChanged += Txt_soDienThoai_TextChanged;
        }
        private void Frm_lapHoaDon_Load(object sender, EventArgs e)
        {
            LoadSanPhamPage();
            InitializeDataGridView();
            this.txt_tenSanPham.Enter += Txt_tenSanPham_Enter;
            this.txt_tenSanPham.Leave += Txt_tenSanPham_Leave;
            this.btn_timSanPham.Click += Btn_timSanPham_Click;
            this.btn_addCart.Click += Btn_addCart_Click;
            this.btn_timKhachHang.Click += Btn_timKhachHang_Click;
            this.btn_Clear.Click += Btn_Clear_Click;
            this.btn_inHoaDon.Click += Btn_inHoaDon_Click;
            this.btn_luuHoaDon.Click += Btn_luuHoaDon_Click;
            this.btn_keTiep.Click += Btn_keTiep_Click;
            this.btn_troLai.Click += Btn_troLai_Click;
            this.btn_trangDau.Click += Btn_trangDau_Click;
            this.btn_trangCuoi.Click += Btn_trangCuoi_Click;
            cbo_loaiKhachHang.SelectedIndexChanged += Cbo_loaiKhachHang_SelectedIndexChanged;
            // sự kiện chọn radio button
            rdo_diaChiHienTai.CheckedChanged += Rdo_diaChiHienTai_CheckedChanged;
            rdo_diaChiMoi.CheckedChanged += Rdo_diaChiMoi_CheckedChanged;
            chkSuDungDiemTichLuy.CheckedChanged += chkSuDungDiemTichLuy_CheckedChanged;
            // Gán sự kiện trong phần khởi tạo
            txt_tenKhachHang.KeyPress += Txt_tenKhachHang_KeyPress;
            txt_tenKhachHang.TextChanged += Txt_tenKhachHang_TextChanged;

        }
        private void Txt_tenKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập chữ cái, khoảng trắng và dấu gạch ngang
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui lòng chỉ nhập chữ cái, khoảng trắng hoặc dấu gạch ngang.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Txt_tenKhachHang_TextChanged(object sender, EventArgs e)
        {
            // Loại bỏ ký tự không hợp lệ
            string allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ -";
            string input = txt_tenKhachHang.Text;
            string filtered = new string(input.Where(c => allowedCharacters.Contains(c)).ToArray());

            if (input != filtered)
            {
                MessageBox.Show("Họ tên không được chứa số hoặc ký tự đặc biệt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tenKhachHang.Text = filtered;
                txt_tenKhachHang.SelectionStart = txt_tenKhachHang.Text.Length; // Đưa con trỏ về cuối
            }
        }

        private void Txt_soDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím Backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
                MessageBox.Show("Vui lòng chỉ nhập số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Txt_soDienThoai_TextChanged(object sender, EventArgs e)
        {
            // Giới hạn tối đa 12 ký tự
            if (txt_soDienThoai.Text.Length > 12)
            {
                MessageBox.Show("Số điện thoại không được vượt quá 12 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soDienThoai.Text = txt_soDienThoai.Text.Substring(0, 12); // Giữ lại 12 ký tự đầu tiên
                txt_soDienThoai.SelectionStart = txt_soDienThoai.Text.Length; // Đưa con trỏ về cuối
            }
        }
        //sự kiện check box kiểm tra khách hàng có phải là thành viên
        private void chkSuDungDiemTichLuy_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu CheckBox được chọn
            if (chkSuDungDiemTichLuy.Checked)
            {
                // Lấy mã khách hàng từ TextBox hoặc biến hiện tại
                string maKhachHang = txt_maKhachHang.Text;

                // Kiểm tra mã khách hàng có hợp lệ không
                if (string.IsNullOrEmpty(maKhachHang))
                {
                    MessageBox.Show("Vui lòng nhập mã khách hàng.");
                    chkSuDungDiemTichLuy.Checked = false; // Bỏ chọn CheckBox
                    return;
                }

                // Lấy thông tin khách hàng từ cơ sở dữ liệu
                var kh = _khachHangBLL.GetKhachHang(maKhachHang);

                // Kiểm tra nếu khách hàng không tồn tại hoặc không phải là thành viên
                if (kh == null || kh.ThanhVien==true)
                {
                    MessageBox.Show("Chỉ khách hàng thành viên mới có thể sử dụng điểm tích lũy.");
                    chkSuDungDiemTichLuy.Checked = false; // Bỏ chọn CheckBox
                    return;
                }

                // Nếu là thành viên, cho phép sử dụng điểm tích lũy
                MessageBox.Show($"Khách hàng {kh.TenKhachHang} có thể sử dụng điểm tích lũy.");
            }
        }


        // sự kiện chọn radio button
        private void Rdo_diaChiMoi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_diaChiMoi.Checked)
            {
                // Bật các trường thông tin để nhập mới
                txt_tenKhachHang.Enabled = true;
                txt_soDienThoai.Enabled = true;
                txt_diaChi.Enabled = true;
            }
        }
        private void Rdo_diaChiHienTai_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_diaChiHienTai.Checked)
            {
                txt_maKhachHang.Enabled = false;
                txt_tenKhachHang.Enabled = false;
                txt_soDienThoai.Enabled = false;
                txt_diaChi.Enabled = false;
            }
        }
        private void Cbo_loaiKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy loại khách hàng đã chọn
            string loaiKhachHang = cbo_loaiKhachHang.SelectedItem?.ToString();

            if (loaiKhachHang == "Khách hàng thành viên")
            {
                ResetControls(true);
                MessageBox.Show("Tìm thông tin thành viên theo mã hoặc tên, SDT");
                txt_diemDung.Enabled = true;
                chkSuDungDiemTichLuy.Enabled = true;
                btn_timKhachHang.Enabled = true;
                rdo_diaChiHienTai.Checked= true;
                rdo_diaChiMoi.Checked = false;
                rdo_diaChiHienTai.Enabled= true;
                rdo_diaChiMoi.Enabled = true;
            }
            else if (loaiKhachHang == "Khách hàng đăng kí thành viên")
            {
                ResetControls(true);
                txt_maKhachHang.Text = taoMaKhachHang(); // Tự động tạo mã
                txt_maKhachHang.Enabled = false;
                txt_diemDung.Enabled = false;
                chkSuDungDiemTichLuy.Enabled = false;
                btn_timKhachHang.Enabled = false;
                rdo_diaChiHienTai.Checked = true;
                rdo_diaChiMoi.Checked = false;
                rdo_diaChiHienTai.Enabled = true;
                rdo_diaChiMoi.Enabled = false;
            }
            else
            {
                ResetControls(false); // Vô hiệu hóa tất cả các điều khiển
                btn_timKhachHang.Enabled = false;
                rdo_diaChiHienTai.Checked = true;
                rdo_diaChiMoi.Checked = false;
                rdo_diaChiHienTai.Enabled = true;
                rdo_diaChiMoi.Enabled = false;
            }
        }
        private void ResetControls(bool isEnabled)
        {
            txt_maKhachHang.Text = string.Empty;
            txt_tenKhachHang.Text = string.Empty;
            txt_soDienThoai.Text = string.Empty;
            txt_diaChi.Text = string.Empty;

            txt_maKhachHang.Enabled = isEnabled;
            txt_tenKhachHang.Enabled = isEnabled;
            txt_soDienThoai.Enabled = isEnabled;
            txt_diaChi.Enabled = isEnabled;
            cbo_giaoHang.Enabled = isEnabled;
            rdo_diaChiHienTai.Enabled = isEnabled;
            rdo_diaChiMoi.Enabled = isEnabled;
            txt_diemDung.Enabled = isEnabled;
            chkSuDungDiemTichLuy.Enabled = isEnabled;
        }
        private void Btn_trangCuoi_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage = totalPages;
                LoadSanPhamPage();
            }
        }
        private void Btn_trangDau_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage = 1;
                LoadSanPhamPage();
            }
        }

        private void Btn_keTiep_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadSanPhamPage();
            }
        }

        private void Btn_troLai_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadSanPhamPage();
            }
        }

        private void Btn_luuHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra giỏ hàng
                if (dgvCart.Rows.Count == 0 || dgvCart.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
                {
                    MessageBox.Show("Giỏ hàng không có sản phẩm. Vui lòng thêm sản phẩm trước khi lưu hóa đơn.");
                    return;
                }

                // 2. Lấy thông tin khách hàng từ ComboBox
                string loaiKhachHang = cbo_loaiKhachHang.SelectedItem?.ToString(); // Giá trị từ ComboBox
                string maKhachHang = txt_maKhachHang.Text;
                string tenKhachHang = txt_tenKhachHang.Text;
                string sdt = txt_soDienThoai.Text;
                string diaChi = txt_diaChi.Text;
                string maNV = _maNhanVien;
                string hinhThucGiaoHang = cbo_giaoHang.SelectedItem?.ToString();
                string hinhThucThanhToan = cbo_hinhThucThanhToan.SelectedItem?.ToString();
                string trangThaiDonHang=string.Empty;
                decimal diemTichLuyCong = 0;
                decimal diemSuDung = 0;
                decimal diemTichLuyMoi = 0;

                if (string.IsNullOrEmpty(hinhThucGiaoHang) || string.IsNullOrEmpty(hinhThucThanhToan))
                {
                    MessageBox.Show("Vui lòng chọn hình thức giao hàng và thanh toán.");
                    return;
                }
                else
                {
                    if(hinhThucGiaoHang == "Giao hàng tận nơi")
                    {
                        trangThaiDonHang = "Đang giao hàng";
                    }
                    else
                    {
                        trangThaiDonHang = "Đã nhận hàng";
                    }
                }

                // Kiểm tra thông tin nhân viên
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng đăng nhập để thực hiện chức năng này.");
                    return;
                }
                // cập nhật địa chỉ khách hàng
                if (rdo_diaChiMoi.Checked)
                {
                    // Bật các trường thông tin để nhập mới
                    txt_tenKhachHang.Enabled = true;
                    txt_soDienThoai.Enabled = true;
                    txt_diaChi.Enabled = true;

                    // Kiểm tra và lưu thông tin khách hàng nếu các trường không rỗng
                    if (!string.IsNullOrEmpty(txt_tenKhachHang.Text) &&
                        !string.IsNullOrEmpty(txt_soDienThoai.Text) &&
                        !string.IsNullOrEmpty(txt_diaChi.Text))
                    {
                        // Tạo đối tượng khách hàng mới
                        KhachHang khachHangMoi = new KhachHang
                        {
                            MaKhachHang = txt_maKhachHang.Text, // Nếu có mã khách hàng hiện tại
                            TenKhachHang = txt_tenKhachHang.Text,
                            SoDienThoai = txt_soDienThoai.Text,
                            DiaChi = txt_diaChi.Text,
                            TrangThai = true, // Đang hoạt động
                            NgayCapNhat = DateTime.Now
                        };

                        try
                        {
                            // Cập nhật thông tin khách hàng vào cơ sở dữ liệu
                            _khachHangBLL.updateKhachHang(khachHangMoi);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng mới.");
                    }
                }

                // 3. Xử lý khách hàng dựa trên loại khách hàng được chọn
                KhachHang kh = null;
                if (loaiKhachHang == "Khách hàng vãng lai")
                {
                    // Không lưu thông tin khách hàng
                    kh = null;
                }
                else if (loaiKhachHang == "Khách hàng đăng kí thành viên")
                {
                    if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diaChi))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng để đăng ký thành viên.");
                        return;
                    }

                    // Tạo khách hàng mới
                    kh = new KhachHang
                    {
                        MaKhachHang = taoMaKhachHang(),
                        TenKhachHang = tenKhachHang,
                        SoDienThoai = sdt,
                        DiaChi = diaChi,
                        TrangThai = true,
                        ThanhVien = true,
                        NgayTao= DateTime.Now,
                        NgayCapNhat = DateTime.Now,
                        DiemTichLuy = 0
                    };

                    // Lưu vào cơ sở dữ liệu
                    bool isAdded = _khachHangBLL.ThemKhachHang(kh);
                    if (!isAdded)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng đăng ký thành viên.");
                        return;
                    }

                    maKhachHang = kh.MaKhachHang; // Cập nhật mã khách hàng
                }
                else if (loaiKhachHang == "Khách hàng thành viên")
                {
                    if (string.IsNullOrEmpty(maKhachHang))
                    {
                        MessageBox.Show("Vui lòng nhập hoặc chọn mã khách hàng.");
                        return;
                    }

                    kh = _khachHangBLL.GetKhachHang(maKhachHang, null, null);
                    if (kh == null)
                    {
                        MessageBox.Show("Khách hàng không tồn tại.");
                        return;
                    }
                }

                // 4. Tính toán tổng tiền và điểm tích lũy
                decimal tongTien = CalculateTotalAmount();

                if (chkSuDungDiemTichLuy.Checked && kh?.ThanhVien == true)
                {
                    // Kiểm tra điểm sử dụng hợp lệ
                    if (!decimal.TryParse(txt_diemDung.Text, out diemSuDung) || diemSuDung < 0)
                    {
                        MessageBox.Show("Điểm sử dụng không hợp lệ.");
                        return;
                    }

                    // Lấy điểm tích lũy hiện tại của khách hàng
                    decimal diemKhachHangHienTai = _khachHangBLL.GetKhachHang(maKhachHang)?.DiemTichLuy ?? 0;

                    // Kiểm tra nếu điểm sử dụng vượt quá điểm tích lũy hiện tại
                    if (diemSuDung > diemKhachHangHienTai)
                    {
                        MessageBox.Show($"Điểm sử dụng vượt quá số điểm tích lũy hiện tại ({diemKhachHangHienTai}).");
                        return;
                    }

                    // Tính điểm tích lũy cộng thêm từ hóa đơn
                    diemTichLuyCong = CalculateDiemTichLuy(tongTien);

                    // Trừ điểm sử dụng từ tổng tiền và tính tổng tiền còn lại
                    tongTien -= diemSuDung;

                    // Tính toán điểm tích lũy mới sau khi trừ và cộng
                    diemTichLuyMoi = diemKhachHangHienTai - diemSuDung + diemTichLuyCong;

                    // Ghi nhận điểm tích lũy mới vào hệ thống
                    bool isUpdated = _khachHangBLL.UpdateDiemTichLuy(maKhachHang, diemTichLuyMoi);

                    // Hiển thị thông báo nếu có lỗi xảy ra khi cập nhật
                    if (!isUpdated)
                    {
                        MessageBox.Show("Có lỗi xảy ra khi cập nhật điểm tích lũy.");
                        return;
                    }
                }
                else
                {
                    diemTichLuyCong = CalculateDiemTichLuy(tongTien);
                    decimal diemKhachHangHienTai = _khachHangBLL.GetKhachHang(maKhachHang)?.DiemTichLuy ?? 0;
                    diemTichLuyMoi = diemKhachHangHienTai+diemTichLuyCong;
                }

                if (tongTien <= 0)
                {
                    MessageBox.Show("Tổng tiền không hợp lệ.");
                    return;
                }


                // 5. Lưu hóa đơn
                HoaDonBanHang hoaDon = new HoaDonBanHang
                {
                    MaHoaDonBanHang = taoMaHoaDon(),
                    NgayLap = DateTime.Now,
                    MaKhachHang = kh?.MaKhachHang, // Lưu mã khách hàng nếu có
                    MaNhanVien = maNV,
                    TongSanPham = CalculateTotalProducts(),
                    TongTien = tongTien,
                    DiemCongTichLuy = diemTichLuyCong,
                    DiemTichLuy = diemTichLuyMoi,
                    //HinhThucGiaoHang = hinhThucGiaoHang,
                    //PhuongThucThanhToan = hinhThucThanhToan,
                    //TrangThaiDonHang = trangThaiDonHang
                };

                bool isHoaDonAdded = _hoaDonBanHangBLL.AddHoaDonBanHang(hoaDon);
                if (!isHoaDonAdded)
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu hóa đơn.");
                    return;
                }
                _maHD = hoaDon.MaHoaDonBanHang;

                // 6. Lưu chi tiết hóa đơn
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var chiTietHoaDon = new ChiTietHoaDonBanHang
                        {
                            MaChiTietHoaDonBanHang = taoCTHD(),
                            MaHoaDon = hoaDon.MaHoaDonBanHang,
                            MaSanPham = row.Cells["MaSP"].Value.ToString(),
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            DonGia = Convert.ToDecimal(row.Cells["Gia"].Value),
                            ThanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value),
                        };

                        _chiTietHoaDonBanHangBLL.AddChiTietHoaDon(chiTietHoaDon);
                    }
                }
                var dsChiTietHoaDon = _chiTietHoaDonBanHangBLL.GetChiTietHoaDonByMaHoaDon(hoaDon.MaHoaDonBanHang);
                UpdateProductStock(dsChiTietHoaDon);
                MessageBox.Show("Hóa đơn đã được lưu thành công!");
                dgvCart.Rows.Clear();
                clearAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                MessageBox.Show($"Có lỗi xảy ra khi lưu hóa đơn: {ex.Message}");
            }
        }

        private void Btn_inHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
            label_xuaHD.Visible = false;
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
           clearAll();
        }

        private void Btn_timKhachHang_Click(object sender, EventArgs e)
        {
            string maKhachHang = txt_maKhachHang.Text;
            string tenKhachHang = txt_tenKhachHang.Text;
            string sdt = txt_soDienThoai.Text;
            if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một trong các thông tin: Mã khách hàng, Tên khách hàng hoặc Số điện thoại.");
                return; 
            }
            KhachHang kh = _khachHangBLL.GetKhachHang(maKhachHang, tenKhachHang, sdt);

            if (kh != null)
            {
                txt_maKhachHang.Text = kh.MaKhachHang;
                txt_tenKhachHang.Text = kh.TenKhachHang;
                txt_soDienThoai.Text = kh.SoDienThoai;
                txt_diaChi.Text = kh.DiaChi;
                if (kh.DiemTichLuy.HasValue)
                {
                    txt_diemTichLuy.Text = kh.DiemTichLuy.Value.ToString("0.##"); 
                }
                else
                {
                    txt_diemTichLuy.Text = "0";  
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng.");
            }

        }

        private void Btn_addCart_Click(object sender, EventArgs e)
        {
            if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            {
                string tenSanPham = productSelected?.TenSanPham; // Sử dụng toán tử null conditional để tránh NullReferenceException
                if (string.IsNullOrEmpty(tenSanPham))
                {
                    MessageBox.Show("Sản phẩm chưa được chọn.");
                    return;
                }
                string mauSac = cbo_mauSac.SelectedItem?.ToString();
                string kichThuoc = cbo_kichThuoc.SelectedItem?.ToString();
                string maSanPham = _sanPhamBLL?.GetProductCodesByNameColorSize(tenSanPham, mauSac, kichThuoc);
                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Mã sản phẩm không hợp lệ. Vui lòng kiểm tra lại thông tin sản phẩm.");
                    return;
                }
                int soLuong = (int)txt_soLuong.Value;
                if (soLuong <= 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng sản phẩm lớn hơn 0.");
                    return;
                }
                var sanPham = _sanPhamBLL?.GetSanPhamByMaSanPham(maSanPham);
                if (sanPham != null)
                {
                    string _tenSanPham = sanPham.TenSanPham;
                    string tenMau = sanPham.MauSac;
                    string tenKichThuoc = sanPham.KichThuoc;
                    decimal giaBan = sanPham.GiaBan;
                    decimal thanhTien = giaBan * soLuong;
                    bool sanPhamDaCo = false;
                    foreach (DataGridViewRow row in dgvCart.Rows)
                    {
                        if (row.Cells["MaSP"].Value?.ToString() == maSanPham &&
                            row.Cells["MauSac"].Value?.ToString() == tenMau &&
                            row.Cells["KichThuoc"].Value?.ToString() == tenKichThuoc)
                        {
                            int currentQuantity = (int)row.Cells["SoLuong"].Value;
                            row.Cells["SoLuong"].Value = currentQuantity + soLuong;
                            row.Cells["ThanhTien"].Value = giaBan * (currentQuantity + soLuong);
                            sanPhamDaCo = true;
                            break;
                        }
                    }

                    if (!sanPhamDaCo)
                    {
                        dgvCart.Rows.Add(maSanPham, _tenSanPham, tenMau, tenKichThuoc, soLuong, giaBan, thanhTien);
                    }
                }
                else
                {
                    MessageBox.Show("Sản phẩm không tìm thấy.");
                }
                txt_tongTien.Text = CalculateTotalAmount().ToString("N0");
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn màu sắc và kích thước sản phẩm.");
            }
        }

        private void Btn_timSanPham_Click(object sender, EventArgs e)
        {
            string ttSanPham = txt_tenSanPham.Text;
            if (ttSanPham != null)
            {
                currentPage = 1;  // Quay lại trang đầu
                loadSanPham(_sanPhamBLL.GetUniqueProductsByCategoryWithPagination("", ttSanPham, currentPage, pageSize,out totalRecords));
                UpdatePaginationButtons();  // Cập nhật trạng thái các nút phân trang
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm");
            }
        }

        private void MyControl_BamChuot(object sender, EventArgs e)
        {
            var clickItem = sender as ProductItem;
            if (clickItem != null)
            {
                if (productSelected != null && productSelected != clickItem)
                {
                    productSelected.IsSelected = false; // Bỏ chọn sản phẩm đã chọn
                }
                productSelected = clickItem;
                productSelected.IsSelected = true; // Đánh dấu sản phẩm hiện tại là được chọn
                string tensp = productSelected.TenSanPham;
                LoadColorsAndSizes(tensp);
                LoadProductPrice();
            }
        }

        private void MyControl_MouseLeave(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.White;
            }
        }

        private void MyControl_MouseEnter(object sender, EventArgs e)
        {
            var hoverItem = sender as ProductItem;
            if (hoverItem != null && !hoverItem.IsSelected) // Chỉ thay đổi màu nếu không được chọn
            {
                hoverItem.BackColor = Color.LightCyan;
            }
        }

        private void MyControl_Click(object sender, EventArgs e)
        {
            var clickItem = sender as ProductItem;
            if (clickItem != null)
            {
                if (productSelected != null && productSelected != clickItem)
                {
                    productSelected.IsSelected = false; // Bỏ chọn sản phẩm đã chọn
                }
                productSelected = clickItem;
                productSelected.IsSelected = true; // Đánh dấu sản phẩm hiện tại là được chọn
                string tensp = productSelected.TenSanPham;
                LoadColorsAndSizes(tensp);
                LoadProductPrice();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            loadNgayHT();
        }
        private void Txt_tenSanPham_Enter(object sender, EventArgs e)
        {
            if (txt_tenSanPham.Text == "Nhập thông tin sản phẩm")
            {
                txt_tenSanPham.Text = string.Empty;
                txt_tenSanPham.ForeColor = Color.Black;
            }
        }

        private void Txt_tenSanPham_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_tenSanPham.Text))
            {
                txt_tenSanPham.Text = "Nhập thông tin sản phẩm";
                txt_tenSanPham.ForeColor = Color.Gray;
            }
        }
        public void PlaceHoder(TextBox textBox,string noiDung)
        {
            if (textBox.Text == noiDung)
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = noiDung;
                textBox.ForeColor = Color.Gray;
            }
        }
        private void LoadProductPrice()
        {
            // Kiểm tra xem người dùng đã chọn đủ thông tin chưa
            if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            {
                string tenSanPham = productSelected.TenSanPham; // Giả sử ProductItem có thuộc tính TenSanPham
                string mauSac = cbo_mauSac.SelectedItem.ToString(); // Lấy màu sắc đã chọn
                string kichThuoc = cbo_kichThuoc.SelectedItem.ToString(); // Lấy kích thước đã chọn
                string maSP = _sanPhamBLL.GetProductCodesByNameColorSize(tenSanPham, mauSac, kichThuoc);
                decimal? giaSanPham = _sanPhamBLL.GetProductPriceByCode(maSP);

                int slTon = _sanPhamBLL.GetSanPhamByMaSP(maSP).FirstOrDefault()?.SoLuongTon ?? 0;
                if (slTon <= 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng.");
                    return;
                }
                else
                {
                    txt_SLTon.Text = slTon.ToString();
                    txt_soLuong.Maximum = slTon;
                }
                if (giaSanPham.HasValue)
                {
                    txt_giaBan.Text = giaSanPham.Value.ToString("N0"); // "N0" sẽ định dạng giá theo kiểu số, không có phần thập phân
                }
                else
                {
                    txt_giaBan.Text = "Giá không có sẵn"; // Nếu không tìm thấy giá, hiển thị thông báo
                }
            }
            else
            {
                txt_giaBan.Clear(); // Nếu chưa chọn đủ thông tin, xóa giá trong TextBox
            }

        }
        private void cbo_mauSac_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductPrice();
        }
        private void cbo_kichThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProductPrice();
        }

        private void cbo_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_loai.SelectedItem != null)
            {
                var selectedLoai = (LoaiSanPham)cbo_loai.SelectedItem;
                string maLoai= selectedLoai.MaLoai;

                if (selectedLoai.MaLoai == "ALL")
                {
                    currentPage = 1;
                    LoadSanPhamPage();
                }
                else
                {
                    currentPage = 1;  // Quay lại trang đầu
                    loadSanPham(_sanPhamBLL.GetUniqueProductsByCategoryWithPagination(maLoai, "", currentPage, pageSize, out totalRecords));
                    UpdatePaginationButtons();  // Cập nhật trạng thái các nút phân trang
                }
            }
        }

        private void txt_tenSanPham_TextChanged(object sender, EventArgs e)
        {
            string ttSanPham = txt_tenSanPham.Text;
            if (ttSanPham != null)
            {
                loadSanPham(_sanPhamBLL.GetUniqueProducts(ttSanPham));
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm");
            }
        }

        private void txt_soLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)  
            {
                e.Handled = true; 
            }
            string tongTien = CalculateTotalAmount().ToString();
            txt_tongTien.Text = tongTien;
            txt_TongSL.Text = CalculateTotalProducts().ToString();

        }

        private void dgvCart_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["SoLuong"].Index) // Kiểm tra nếu người dùng đang chỉnh sửa cột "Số Lượng"
            {
                string inputValue = dgvCart.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!int.TryParse(inputValue, out int soLuong) || soLuong < 1 || soLuong > 100)
                {
                    e.Cancel = true; 
                }
                string tongTien = CalculateTotalAmount().ToString();
                txt_tongTien.Text = tongTien;
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
        }

        private void dgvCart_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCart.Columns["SoLuong"].Index)
            {
                // Lấy số lượng và giá bán
                var row = dgvCart.Rows[e.RowIndex];
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal giaBan = Convert.ToDecimal(row.Cells["Gia"].Value);

                decimal thanhTien = giaBan * soLuong;
                row.Cells["ThanhTien"].Value = thanhTien;
            }

            txt_tongTien.Text = CalculateTotalAmount().ToString("N0");
            txt_TongSL.Text = CalculateTotalProducts().ToString();
        }

        private void dgvCart_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn vào cột Xóa (cột có tên là "Xoa")
            if (e.ColumnIndex == dgvCart.Columns["Xoa"].Index && e.RowIndex >= 0)
            {
                // Xác nhận trước khi xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // Xóa sản phẩm tại dòng hiện tại
                    dgvCart.Rows.RemoveAt(e.RowIndex);
                }
                string tongTien = CalculateTotalAmount().ToString();
                txt_tongTien.Text = tongTien;
                txt_TongSL.Text = CalculateTotalProducts().ToString();
            }
        }


        //hàm ở dưới 
        //cập nhật số lượng tồn sản phẩm sau khi mua xong
        private void UpdateProductStock(List<ChiTietHoaDonBanHang> chiTietHoaDonList)
        {
            try
            {
                // Lặp qua từng sản phẩm trong danh sách chi tiết hóa đơn
                foreach (var chiTiet in chiTietHoaDonList)
                {
                    string maSanPham = chiTiet.MaSanPham;
                    int soLuongBan = chiTiet.SoLuong??0;

                    // Lấy thông tin sản phẩm từ cơ sở dữ liệu
                    var sanPham = _sanPhamBLL.GetProductById(maSanPham);

                    if (sanPham != null)
                    {
                        // Trừ số lượng bán từ số lượng tồn
                        sanPham.SoLuongTon -= soLuongBan;

                        // Kiểm tra nếu số lượng tồn âm (cảnh báo)
                        if (sanPham.SoLuongTon < 0)
                        {
                            MessageBox.Show($"Sản phẩm {sanPham.TenSanPham} không đủ hàng trong kho.");
                            sanPham.SoLuongTon = 0; // Đảm bảo không để số lượng tồn âm
                        }

                        // Cập nhật sản phẩm vào cơ sở dữ liệu
                        _sanPhamBLL.UpdateProduct(sanPham);
                    }
                    else
                    {
                        MessageBox.Show($"Sản phẩm với mã {maSanPham} không tồn tại.");
                    }
                }

                MessageBox.Show("Cập nhật tồn kho sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật tồn kho: {ex.Message}");
                MessageBox.Show($"Có lỗi xảy ra khi cập nhật tồn kho: {ex.Message}");
            }
        }

        //loadcombo hình thức thành toán
        private void LoadHinhThucThanhToan()
        {
            cbo_hinhThucThanhToan.Items.Add("Tiền mặt");
            cbo_hinhThucThanhToan.Items.Add("Chuyển khoản");
            cbo_hinhThucThanhToan.SelectedIndex = 0;
        }
        //load combobox sản phẩm
        private void LoadComBoxSanPham()
        {
            // Lấy danh sách sản phẩm
            List<SanPham> sanPhams = _sanPhamBLL.GetUniqueProducts("");

            // Tạo danh sách hiển thị
            List<LuaChonHienThi> luaChonHienThis = sanPhams.Select(sanPham => new LuaChonHienThi
            {
                TenHienThi = sanPham.TenSanPham, // Thuộc tính tên sản phẩm
                MaHienThi = sanPham.MaSanPham    // Thuộc tính mã sản phẩm
            }).ToList();

            // Gán danh sách hiển thị vào ComboBox
            txt_tenSanPham.DataSource = luaChonHienThis;
            txt_tenSanPham.DisplayMember = "TenHienThi"; // Hiển thị tên sản phẩm
            txt_tenSanPham.ValueMember = "MaHienThi";   // Giá trị là mã sản phẩm

            // Cấu hình AutoComplete cho ComboBox
            txt_tenSanPham.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_tenSanPham.AutoCompleteSource = AutoCompleteSource.ListItems;

            // Chọn mặc định là không có sản phẩm nào
            txt_tenSanPham.SelectedIndex = -1;
            // không cho bấm nút xổ xuống combobox
            txt_tenSanPham.DropDown += Txt_tenSanPham_DropDown;
        }

        private void Txt_tenSanPham_DropDown(object sender, EventArgs e)
        {
            ((ComboBox)sender).DroppedDown = false;
        }

        private void ConfigureComboBox(ComboBox comboBox)
        {
            comboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        //load combobox hình thức giao hàng
        private void LoadHinhThucGiaoHang()
        {
            cbo_giaoHang.Items.Add("Nhận hàng tại cửa hàng");
            cbo_giaoHang.Items.Add("Giao hàng tận nơi");
            cbo_giaoHang.SelectedIndex = 0;
        }
        // load combobox loại khách hàng
        private void LoadComBoBoxLoaiKhachHang()
        {
            cbo_loaiKhachHang.Items.Add("Khách hàng thành viên");
            cbo_loaiKhachHang.Items.Add("Khách hàng đăng kí thành viên");
            cbo_loaiKhachHang.Items.Add("Khách hàng vãng lai");
            cbo_loaiKhachHang.SelectedIndex = 0;
        }
        // Cập nhật các nút phân trang
        private void UpdatePaginationButtons()
        {
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            btn_troLai.Enabled = currentPage > 1;
            btn_keTiep.Enabled = currentPage < totalPages;
            btn_trangDau.Enabled = currentPage > 1;
            btn_trangCuoi.Enabled = currentPage < totalPages;
        }
        private void InitializeDataGridView()
        {
            // Xóa cột cũ nếu có
            dgvCart.Columns.Clear();

            // Thêm các cột vào DataGridView
            dgvCart.Columns.Add("MaSP", "Mã Sản Phẩm");
            dgvCart.Columns.Add("TenSanPham", "Tên Sản Phẩm");
            dgvCart.Columns.Add("MauSac", "Màu Sắc");
            dgvCart.Columns.Add("KichThuoc", "Size");

            // Cột Số Lượng
            DataGridViewTextBoxColumn colSoLuong = new DataGridViewTextBoxColumn();
            colSoLuong.Name = "SoLuong";
            colSoLuong.HeaderText = "SL";  // Tiêu đề cột
            colSoLuong.ValueType = typeof(int);  // Kiểu dữ liệu số nguyên
            colSoLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải cho số lượng
            dgvCart.Columns.Add(colSoLuong);

            // Cột Giá
            dgvCart.Columns.Add("Gia", "Giá");

            // Cột Thành Tiền
            dgvCart.Columns.Add("ThanhTien", "Thành Tiền");

            // Cột Xóa (với hình ảnh)
            DataGridViewImageColumn btnXoa = new DataGridViewImageColumn();
            btnXoa.Name = "Xoa";
            btnXoa.HeaderText = "Xóa";
            btnXoa.Image = Properties.Resources.icons8_delete_35;  // Đảm bảo hình ảnh đã được thêm vào Resources
            btnXoa.ImageLayout = DataGridViewImageCellLayout.Zoom;  // Hình ảnh sẽ thu nhỏ vừa vặn với ô
            dgvCart.Columns.Add(btnXoa);

            // Đặt thuộc tính ReadOnly cho các cột không muốn chỉnh sửa
            dgvCart.Columns["MaSP"].ReadOnly = true;
            dgvCart.Columns["TenSanPham"].ReadOnly = true;
            dgvCart.Columns["MauSac"].ReadOnly = true;
            dgvCart.Columns["KichThuoc"].ReadOnly = true;
            dgvCart.Columns["Gia"].ReadOnly = true;
            dgvCart.Columns["ThanhTien"].ReadOnly = true;

            // Đặt chiều rộng của các cột đã có
            dgvCart.Columns["MaSP"].Width = 45;  // Đặt chiều rộng cột Mã Sản Phẩm là 70
            dgvCart.Columns["SoLuong"].Width = 30;  // Đặt chiều rộng cột Số Lượng là 30
            dgvCart.Columns["KichThuoc"].Width = 50;  // Đặt chiều rộng cột Kích Thước là 50

            // Đặt lại kiểu font cho tiêu đề cột
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            dgvCart.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Cập nhật lại bảng
            dgvCart.Refresh();

            // Thêm chức năng tự động thay đổi kích thước cột
            dgvCart.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvCart.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // tự động xuống hàng khi text quá dài
            dgvCart.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            // tăng chiều cao của hàng
            dgvCart.RowTemplate.Height = 50;
            // Ngăn không cho tạo thêm cột mới
            dgvCart.AllowUserToAddRows = false;
        }
        private decimal CalculateDiemTichLuy(decimal totalAmount)
        {
            decimal diemTichLuy = totalAmount * 0.05m;

            return diemTichLuy;
        }
        private string taoMaKhachHang()
        {
            string maKhachHang = "";
            int soLuongKH = _khachHangBLL.GetAllKhachHangs().Count;
            if (soLuongKH == 0)
            {
                maKhachHang = "KH001";
            }
            else
            {
                maKhachHang = "KH" + (soLuongKH + 1).ToString("000");
            }
            return maKhachHang;
        }
        private string taoCTHD()
        {
            string maCTHD = "";
            int soLuongCTHD = _chiTietHoaDonBanHangBLL.GetAllChiTietHoaDonBanHang().Count;
            if (soLuongCTHD == 0)
            {
                maCTHD = "CTHD001";
            }
            else
            {
                maCTHD = "CTHD" + (soLuongCTHD + 1).ToString("000");
            }
            return maCTHD;
        }
        private int CalculateTotalProducts()
        {
            int totalProducts = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    totalProducts += quantity;
                }
            }

            return totalProducts;
        }
        private decimal CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                if (!row.IsNewRow)
                {
                    decimal thanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value ?? 0);
                    totalAmount += thanhTien;
                }
            }

            return totalAmount;
        }
        private string taoMaHoaDon()
        {
            string maHoaDon = "";

            if (_hoaDonBanHangBLL == null)
            {
                throw new InvalidOperationException("_hoaDonBanHangBLL is not initialized.");
            }

            var hoaDonList = _hoaDonBanHangBLL.GetAllHoaDonBanHang();
            if (hoaDonList == null)
            {
                throw new InvalidOperationException("GetAllHoaDonBanHang returned null.");
            }

            int soLuongHD = hoaDonList.Count;

            if (soLuongHD == 0)
            {
                maHoaDon = "HD001";
            }
            else
            {
                maHoaDon = "HD" + (soLuongHD + 1).ToString("000");
            }

            return maHoaDon;
        }
        private void XuatHoaDon()
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất file Word?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "Hoa-Don-(" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ").docx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mở tài liệu Word mẫu sẵn
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        string url = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        var document = wordApp.Documents.Open(url + @"\Resources\hoa-don-ban-hang-file-word.docx");
                        string maHoaDon = _maHD;
                        HoaDonBanHang hd = _hoaDonBanHangBLL.GetHoaDonByMaHoaDon(maHoaDon).FirstOrDefault();
                        if (hd == null)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        KhachHang kh = _khachHangBLL.GetKhachHang(hd.MaKhachHang, string.Empty, string.Empty);
                        NhanVien nv = _nhanVienBLL.GetNhanVienById(hd.MaNhanVien);
                        if (kh == null || nv == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin khách hàng hoặc nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string tenNhanVien = nv.HoTen;
                        string tenKhachHang = kh.TenKhachHang;
                        string DiaChi = kh.DiaChi;
                        string soDienThoai = kh.SoDienThoai;

                        // Thay thế các thông tin trong tài liệu Word
                        document.Bookmarks["NgayLap"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        document.Bookmarks["TenNhanVien"].Range.Text = tenNhanVien;
                        document.Bookmarks["MaHoaDonBanHang"].Range.Text = maHoaDon;
                        document.Bookmarks["TenKhachHang"].Range.Text = tenKhachHang;
                        document.Bookmarks["DiaChi"].Range.Text = DiaChi;
                        document.Bookmarks["SDT"].Range.Text = soDienThoai;

                        // Lấy bảng đầu tiên trong tài liệu (giả sử bảng đã được định dạng sẵn)
                        var table = document.Tables[1];

                        var lstCTHD = from cthd in new ChiTietHoaDonBanHangBLL().GetChiTietHoaDonByMaHoaDon(maHoaDon)
                                      select new
                                      {
                                          cthd.SanPham.TenSanPham,
                                          cthd.SoLuong,
                                          cthd.DonGia,
                                          cthd.ThanhTien
                                      };

                        DataGridView dgvTemp = new DataGridView();
                        dgvTemp.Name = "dgvTemp";
                        dgvTemp.DataSource = lstCTHD.ToList();
                        this.Controls.Add(dgvTemp);
                        for (int i = 0; i < dgvTemp.Rows.Count; i++)
                        {
                            var newRow = table.Rows.Add();
                            newRow.Cells[1].Range.Text = (i + 1).ToString();
                            newRow.Cells[2].Range.Text = dgvTemp.Rows[i].Cells["TenSanPham"].Value.ToString();
                            newRow.Cells[3].Range.Text = dgvTemp.Rows[i].Cells["SoLuong"].Value.ToString();
                            newRow.Cells[4].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["DonGia"].Value).ToString("N0") + " VNĐ";
                            newRow.Cells[5].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["ThanhTien"].Value).ToString("N0") + " VNĐ";
                        }
                        var tongTien = (decimal)lstCTHD.Sum(x => x.ThanhTien);
                        document.Bookmarks["TongTien"].Range.Text = tongTien.ToString("N0") + " VNĐ";
                        // Lưu tài liệu sau khi thêm dữ liệu
                        document.SaveAs2(saveFileDialog.FileName);
                        document.Close();
                        wordApp.Quit();
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Controls.Remove(dgvTemp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void clearAll()
        {
            txt_maKhachHang.Text = "";
            txt_tenKhachHang.Text = "";
            txt_soDienThoai.Text = "";
            txt_diaChi.Text = "";
            txt_diemDung.Text = "";
            txt_diemTichLuy.Text = "";
            txt_soLuong.Text = "";
            txt_tongTien.Text = "";
            txt_TongSL.Text = "";
        }
        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            txt_tongTien.Text = totalAmount.ToString("N0");  // Định dạng theo kiểu tiền tệ
        }
        private void loadComBoxLoai()
        {
            var dsLoai = _loaiSanPhamBLL.GetAll();
            var allItems = new List<LoaiSanPham>();
            allItems.Add(new LoaiSanPham { MaLoai = "ALL", TenLoai = "Tất cả" });
            if (dsLoai != null && dsLoai.Count > 0)
            {
                allItems.AddRange(dsLoai);
            }
            cbo_loai.DataSource = null;
            cbo_loai.Items.Clear();
            cbo_loai.DataSource = allItems;
            cbo_loai.DisplayMember = "TenLoai";
            cbo_loai.ValueMember = "MaLoai";
            cbo_loai.SelectedIndex = 0;
        }
        private void LoadColorsAndSizes(string tenSanPham)
        {
            var colors = _sanPhamBLL.GetAllColorsByProductName(tenSanPham); // Lấy danh sách màu sắc
            var sizes = _sanPhamBLL.GetAllSizesByProductName(tenSanPham);   // Lấy danh sách kích thước
            cbo_mauSac.Items.Clear(); // Xóa các mục cũ
            cbo_kichThuoc.Items.Clear();  // Xóa các mục cũ
            foreach (var color in colors)
            {
                cbo_mauSac.Items.Add(color.TenMau); // Thêm tên màu sắc vào cbo_mauSac
            }
            foreach (var size in sizes)
            {
                cbo_kichThuoc.Items.Add(size.TenKichThuoc); // Thêm tên kích thước vào cbo_kichThuoc
            }
            if (cbo_mauSac.Items.Count > 0)
                cbo_mauSac.SelectedIndex = 0;  // Chọn màu đầu tiên nếu có
            if (cbo_kichThuoc.Items.Count > 0)
                cbo_kichThuoc.SelectedIndex = 0;   // Chọn kích thước đầu tiên nếu có
        }
        private void loadSanPhamTheoMa()
        {
            dsSanPham.Controls.Clear();
            string maLoai = cbo_loai.SelectedValue.ToString();
            List<SanPham> ListSanPham = _sanPhamBLL.GetUniqueProductsByCategory(maLoai);

            int controlWidth = 165;
            int controlHeight = 170;
            int spacing = 15;
            int panelWidth = dsSanPham.ClientSize.Width;

            int currentX = 10; // Vị trí X bắt đầu
            int currentY = 10; // Vị trí Y bắt đầu

            foreach (var sp in ListSanPham)
            {
                ProductItem myControl = new ProductItem();
                myControl.TenSanPham = sp.TenSanPham;  // Gán tên sản phẩm vào Label
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);
                PictureBox anhSanPham = myControl.Controls.Find("anhSanPham", true).FirstOrDefault() as PictureBox;
                if (anhSanPham != null)
                {
                    LoadImageToPictureBox(sp.HinhAnh, anhSanPham);  // Thay thế sp.HinhAnh với đường dẫn hình ảnh
                }

                dsSanPham.Controls.Add(myControl);
                currentX += controlWidth + spacing;
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }

            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
        }
        public void loadNgayHT()
        {
            DateTime currentDateTime = DateTime.Now;
            string formattedDate = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            label_ngayHT.Text = formattedDate;
        }
        private void LoadImageToPictureBox(string imageName, PictureBox pictureBox)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                if (File.Exists(resourcePath))
                {
                    pictureBox.Image = Image.FromFile(resourcePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh ảnh để vừa vặn trong PictureBox
                }
                else
                {
                    pictureBox.Image = Properties.Resources.gaucute; // Thay thế với ảnh mặc định của bạn
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void LoadSanPhamPage()
        {
            currentPage = 1;  // Quay lại trang đầu
            loadSanPham(_sanPhamBLL.GetUniqueProductsByCategoryWithPagination("", "", currentPage, pageSize, out totalRecords));
            UpdatePaginationButtons();  // Cập nhật trạng thái các nút phân trang
        }
        private void loadSanPham(List<SanPham> ListSanPham)
        {
            dsSanPham.Controls.Clear();  // Xóa tất cả các điều khiển cũ
            int controlWidth = 165;
            int controlHeight = 170;
            int spacing = 15;
            int panelWidth = dsSanPham.ClientSize.Width;
            int currentX = 10; // Vị trí X bắt đầu
            int currentY = 10; // Vị trí Y bắt đầu

            foreach (var sp in ListSanPham)
            {
                ProductItem myControl = new ProductItem();
                myControl.TenSanPham = sp.TenSanPham;  // Gán tên sản phẩm vào Label
                myControl.BamChuot += MyControl_BamChuot;
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);
                PictureBox anhSanPham = myControl.Controls.Find("anhSanPham", true).FirstOrDefault() as PictureBox;
                if (anhSanPham != null)
                {
                    LoadImageToPictureBox(sp.HinhAnh, anhSanPham);  // Thay thế sp.HinhAnh với đường dẫn hình ảnh
                }
                if(sp.SoLuongTon <= 0)
                {
                    anhSanPham.Image = Properties.Resources.hethang;
                }

                dsSanPham.Controls.Add(myControl);
                currentX += controlWidth + spacing;
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }

            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
        }

    }
}
