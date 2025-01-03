﻿using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Collections.Generic;
using DevExpress.XtraEditors.Filtering.Templates;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace GUI
{
    public partial class frm_quanLyKhoHang : Form
    {
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        MauSacBLL _mauSacBLL = new MauSacBLL();
        KichThuocBLL _kichThuocBLL = new KichThuocBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        SanPhamKichThuocBLL _sanPhamKichThuocBLL = new SanPhamKichThuocBLL();
        SanPhamMauSacBLL _sanPhamMauSacBll = new SanPhamMauSacBLL();

        private bool flagSanPham = false;
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            loadSanPham();
            LoadComBoBoxTrangThai();
            this.Load += Frm_quanLyKhoHang_Load;
            btn_luuSanPham.Enabled = false;
        }
        private void LoadComBoBoxTrangThai()
        {
            cbo_trangThai.Items.Add("Hoạt động");
            cbo_trangThai.Items.Add("Không hoạt động");
            cbo_trangThai.SelectedIndex = 0;
        }
        private void LoadImageToPictureBox(string imageName)
        {
            try
            {
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
                if (File.Exists(resourcePath))
                {
                    img_sanPham.Image = Image.FromFile(resourcePath);
                    img_sanPham.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    img_sanPham.Image = Properties.Resources.gaucute;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSanPham()
        {
            dgv_dsSanPham.DataSource = null;
            try
            {
                List<SanPham> dsSanPham = _sanPhamBLL.GetProductList();
                if (dsSanPham != null)
                {
                    dgv_dsSanPham.DataSource = dsSanPham;
                    dgv_dsSanPham.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                    dgv_dsSanPham.Columns["TenSanPham"].HeaderText = "Tên Sản Phẩm";
                    dgv_dsSanPham.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
                    dgv_dsSanPham.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
                    dgv_dsSanPham.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgv_dsSanPham.Columns["GiaBan"].HeaderText = "Giá Bán";
                    dgv_dsSanPham.Columns["MoTa"].HeaderText = "Mô Tả";
                    dgv_dsSanPham.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                    dgv_dsSanPham.Columns["NgayCapNhat"].HeaderText = "Ngày Cập Nhật";
                    dgv_dsSanPham.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
                    dgv_dsSanPham.Columns["SoLuongToiThieu"].HeaderText = "Số Lượng Tối Thiểu";
                    dgv_dsSanPham.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    foreach (DataGridViewColumn column in dgv_dsSanPham.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt kiểu chữ cho tiêu đề (tuỳ chọn)
                    }
                    foreach (DataGridViewRow row in dgv_dsSanPham.Rows)
                    {
                        bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                        if (!trangThai)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink; 
                        }
                    }

                    dgv_dsSanPham.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near, // Căn trái
                LineAlignment = System.Drawing.StringAlignment.Center // Giữa theo chiều dọc
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }

        // Method to load ComboBox for Product Types
        private void loadComBoBoxLoaiSanPhamAdd()
        {
            try
            {
                List<LoaiSanPham> dsLoai = _loaiSanPhamBLL.GetAll();
                if (dsLoai != null && dsLoai.Count > 0)
                {
                    cbo_loaiSanPhamAdd.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbo_loaiSanPhamAdd.DataSource = dsLoai;
                    cbo_loaiSanPhamAdd.ValueMember = "MaLoai";
                    cbo_loaiSanPhamAdd.DisplayMember = "TenLoai";
                }
                else
                {
                    MessageBox.Show("Không có loại sản phẩm nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm.");
            }
        }

        private void loadComBoBoxLoaiSanPham()
        {
            try
            {
                List<LoaiSanPham> dsLoai = _loaiSanPhamBLL.GetAll();
                if (dsLoai != null && dsLoai.Count > 0)
                {
                    cbo_loaiSanPham.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbo_loaiSanPham.DataSource = dsLoai;
                    cbo_loaiSanPham.ValueMember = "MaLoai";
                    cbo_loaiSanPham.DisplayMember = "TenLoai";
                }
                else
                {
                    MessageBox.Show("Không có loại sản phẩm nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách loại sản phẩm.");
            }
        }
        private void loadComboBoxMauSac()
        {
            try
            {
                List<MauSac> dsMauSac = _mauSacBLL.GetAllMauSac();
                if (dsMauSac != null && dsMauSac.Count > 0)
                {
                    cbo_tenMauSac.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbo_tenMauSac.DataSource = dsMauSac;
                    cbo_tenMauSac.DisplayMember = "TenMau";
                    cbo_tenMauSac.ValueMember = "MaMau";
                }
                else
                {
                    MessageBox.Show("Không có màu sắc nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách màu sắc.");
            }
        }

        private void loadComboBoxCbMauSac()
        {
            try
            {
                List<MauSac> dsMauSac = _mauSacBLL.GetAllMauSac();
                if (dsMauSac != null && dsMauSac.Count > 0)
                {
                    cb_tenMauSac.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cb_tenMauSac.DataSource = dsMauSac;
                    cb_tenMauSac.DisplayMember = "TenMau";
                    cb_tenMauSac.ValueMember = "MaMau";
                }
                else
                {
                    MessageBox.Show("Không có màu sắc nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách màu sắc.");
            }
        }
        private void loadComboBoxKichThuoc()
        {
            try
            {
                List<KichThuoc> dsKichThuoc = _kichThuocBLL.GetAll();
                if (dsKichThuoc != null && dsKichThuoc.Count > 0)
                {
                    cbo_tenKichThuoc.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbo_tenKichThuoc.DataSource = dsKichThuoc;
                    cbo_tenKichThuoc.DisplayMember = "TenKichThuoc";
                    cbo_tenKichThuoc.ValueMember = "MaKichThuoc";
                }
                else
                {
                    MessageBox.Show("Không có kích thước nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách kích thước.");
            }
        }

        private void loadComboBoxCbKichThuoc()
        {
            try
            {
                List<KichThuoc> dsKichThuoc = _kichThuocBLL.GetAll();
                if (dsKichThuoc != null && dsKichThuoc.Count > 0)
                {
                    cb_kichThuoc.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cb_kichThuoc.DataSource = dsKichThuoc;
                    cb_kichThuoc.DisplayMember = "TenKichThuoc";
                    cb_kichThuoc.ValueMember = "MaKichThuoc";
                }
                else
                {
                    MessageBox.Show("Không có kích thước nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách kích thước.");
            }
        }

        private void LoadKichThuocAndMauSac(string maSanPham)
        {
            try
            {
                // Lấy thông tin Kích thước và Màu sắc dựa trên mã sản phẩm
                var kichThuocs = _sanPhamBLL.GetKichThuocByProductCode(maSanPham);
                var mauSacs = _sanPhamBLL.GetMauSacByProductCode(maSanPham);

                // Gán vào ComboBox kích thước
                cb_kichThuoc.DataSource = kichThuocs;
                cb_kichThuoc.DisplayMember = "TenKichThuoc";  // Hiển thị tên kích thước
                cb_kichThuoc.ValueMember = "MaKichThuoc";    // Lưu giá trị mã kích thước

                // Gán vào ComboBox màu sắc
                cbo_tenMauSac.DataSource = mauSacs;
                cbo_tenMauSac.DisplayMember = "TenMau";  // Hiển thị tên màu sắc
                cbo_tenMauSac.ValueMember = "MaMau";    // Lưu giá trị mã màu sắc
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin kích thước và màu sắc: " + ex.Message);
            }
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {
            loadSanPham();
            loadComboBoxKichThuoc();
            loadComboBoxCbKichThuoc();
            loadComBoBoxLoaiSanPham();
            loadComBoBoxLoaiSanPhamAdd();
            loadComboBoxCbMauSac();
            loadComboBoxMauSac();
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_themAnh.Click += Btn_themAnh_Click;
            btn_themSanPham.Click += Btn_themSanPham_Click;
            btn_suaSanPham.Click += Btn_suaSanPham_Click;
            btn_xoaSanPham.Click += Btn_xoaSanPham_Click;
            btn_luuSanPham.Click += Btn_luuSanPham_Click;
            txt_maSanPham.Enabled=false;
            btn_luuSanPham.Enabled = false;
            txt_soLuongTon.Enabled=txt_ngayTao.Enabled=txt_ngayCapNhat.Enabled=txt_duongDan.Enabled= false;
            btn_clear.Click += Btn_clear_Click;
            txt_ngayTao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txt_ngayCapNhat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            GetCurrentRowData();
            btn_timDK.Click += Btn_timDK_Click;
            btn_load.Click += Btn_load_Click;
            PlaceHolder.SetPlaceholder(txt_timSanPham, "Nhập mã hoặc tên sản phẩm");
            PlaceHoverButton();
            // chi chi chon combobox
            cbo_loaiSanPhamAdd.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_tenMauSac.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_kichThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_loaiSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_tenMauSac.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo_tenKichThuoc.DropDownStyle = ComboBoxStyle.DropDownList;
            txt_donViTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadComBoBoxDonViTinh();
        }

        // load chọn đơn vị tính
        private void LoadComBoBoxDonViTinh()
        {
            txt_donViTinh.Items.Add("Cái");
            txt_donViTinh.Items.Add("Con");
            txt_donViTinh.Items.Add("Bộ");
            txt_donViTinh.SelectedIndex = 0;
        }

        // Đặt tất cả các button với màu nền và viền mặc định khi load form
        private void PlaceHoverButton()
        {
            // Duyệt qua tất cả các điều khiển trong form để tìm button
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    Button btn = (Button)control;
                    // Cài đặt màu nền và viền mặc định cho button
                    btn.BackColor = Color.Navy;  // Màu nền ban đầu
                    btn.ForeColor = Color.White; // Màu chữ ban đầu
                    btn.FlatStyle = FlatStyle.Flat;  // Đặt FlatStyle để có thể kiểm soát viền
                    btn.FlatAppearance.BorderSize = 2;  // Đặt độ dày viền
                    btn.FlatAppearance.BorderColor = Color.Navy; // Màu viền ban đầu

                    // Đảm bảo rằng sự kiện hover được thêm vào mỗi button
                    btn.MouseEnter += Button_MouseEnter;
                    btn.MouseLeave += Button_MouseLeave;
                }
            }
        }

        // Sự kiện khi di chuột vào button (hover)
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;  // Màu nền khi hover
            btn.ForeColor = Color.Navy;   // Màu chữ khi hover
            btn.FlatAppearance.BorderColor = Color.White; // Màu viền khi hover
        }

        // Sự kiện khi chuột rời khỏi button
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.Navy;   // Màu nền ban đầu khi không hover
            btn.ForeColor = Color.White;  // Màu chữ khi không hover
            btn.FlatAppearance.BorderColor = Color.Navy; // Màu viền ban đầu
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            loadSanPham();
        }

        private void Btn_timDK_Click(object sender, EventArgs e)
        {
            dgv_dsSanPham.DataSource = null;
            string maLoai = cbo_loaiSanPham.SelectedValue != null ? cbo_loaiSanPham.SelectedValue.ToString() : string.Empty;
            string maMau = cb_tenMauSac.SelectedValue != null ? cb_tenMauSac.SelectedValue.ToString() : string.Empty;
            string maKichThuoc = cbo_tenKichThuoc.SelectedValue != null ? cbo_tenKichThuoc.SelectedValue.ToString() : string.Empty;
            List<SanPham> dsSanPham = _sanPhamBLL.SearchProducts(maLoai, maMau, maKichThuoc);
            dgv_dsSanPham.DataSource = dsSanPham;
        }

        private void Btn_luuSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = txt_maSanPham.Text.Trim();
                string tenSanPham = txt_tenSanPham.Text.Trim();
                string donViTinh = txt_donViTinh.Text.Trim();

                // Kiểm tra các trường thông tin đầu vào
                if (string.IsNullOrEmpty(maSanPham) || string.IsNullOrEmpty(tenSanPham) || string.IsNullOrEmpty(donViTinh))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin sản phẩm.");
                    return;
                }

                // Kiểm tra số lượng tối thiểu
                if (!int.TryParse(txt_soLuongToiThieu.Text.Trim(), out int soLuongToiThieu))
                {
                    MessageBox.Show("Số lượng tối thiểu không hợp lệ!");
                    return;
                }

                string giaNhapText = txt_giaNhap.Text;
                string giaBanText = txt_giaBan.Text;
                giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();

                // Kiểm tra giá nhập và giá bán
                if (!decimal.TryParse(giaNhapText, out decimal giaNhap))
                {
                    MessageBox.Show("Giá nhập không hợp lệ!");
                    return;
                }
                if (!decimal.TryParse(giaBanText, out decimal giaBan))
                {
                    MessageBox.Show("Giá bán không hợp lệ!");
                    return;
                }

                string moTa = txt_moTa.Text.Trim();

                // Kiểm tra các lựa chọn loại, màu sắc và kích thước
                if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_tenMauSac.SelectedValue == null || cb_kichThuoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                    return;
                }

                string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                string maMauCu = _sanPhamMauSacBll.GetOldProductColor(maSanPham);
                string maKichThuocCuu = _sanPhamKichThuocBLL.GetOldSize(maSanPham);
                string maMau = cbo_tenMauSac.SelectedValue.ToString();
                string maKichThuoc = cb_kichThuoc.SelectedValue.ToString();
                string hinhanh = txt_duongDan.Text.Trim();
                //lấy mã màu sắc và kích thước từ sản phẩm hiện tại
                string tenMau = (MauSac)cbo_tenMauSac.SelectedItem != null ? ((MauSac)cbo_tenMauSac.SelectedItem).MaMau : string.Empty;
                string tenKichThuoc = (KichThuoc)cb_kichThuoc.SelectedItem != null ? ((KichThuoc)cb_kichThuoc.SelectedItem).MaKichThuoc : string.Empty;
                string giaTriTrangThai = cbo_trangThai.Text;
                bool trangThai = giaTriTrangThai == "Hoạt động";

                // Kiểm tra sản phẩm đã tồn tại chưa
                string existingProductCode = _sanPhamBLL.GetProductCodesByNameColorSize(tenSanPham, tenMau, tenKichThuoc);
                if (existingProductCode != null)
                {
                    MessageBox.Show("Sản phẩm với tên, màu sắc và kích thước này đã tồn tại.");
                    return;
                }

                // Tạo đối tượng sản phẩm mới
                SanPham updatedProduct = new SanPham
                {
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    DonViTinh = donViTinh,
                    GiaNhap = giaNhap,
                    GiaBan = giaBan,
                    MoTa = moTa,
                    SoLuongToiThieu = soLuongToiThieu,
                    MaLoai = maLoai,
                    HinhAnh = hinhanh,
                    TrangThai = trangThai,
                    NgayCapNhat = DateTime.Now
                };

                // Hỏi xác nhận người dùng trước khi lưu
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = _sanPhamBLL.UpdateProductInList(updatedProduct);
                    bool capNhatMauSac = _sanPhamMauSacBll.UpdateProductColor(maSanPham, maMauCu, maMau);
                    bool capNhatKichThuoc = _sanPhamKichThuocBLL.UpdateProductSize(maSanPham, maKichThuocCuu, maKichThuoc);

                    if (result && capNhatMauSac && capNhatKichThuoc)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công.");
                        btn_luuSanPham.BackColor = Color.Navy;
                        btn_luuSanPham.Enabled = false;
                        loadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại. Vui lòng kiểm tra lại thông tin.");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không làm gì cả
                    MessageBox.Show("Cập nhật sản phẩm đã bị hủy.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message);
            }
        }

        private void Btn_xoaSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sản phẩm từ giao diện (hoặc từ nơi bạn đang lưu trữ mã sản phẩm cần xóa)
                string maSanPham = txt_maSanPham.Text;
                string maMau = cbo_tenMauSac.SelectedValue.ToString();
                string maKichThuoc = cb_kichThuoc.SelectedValue.ToString();

                if (string.IsNullOrEmpty(maSanPham))
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
                    return;
                }
                if (string.IsNullOrEmpty(maMau) || string.IsNullOrEmpty(maKichThuoc))
                {
                    return;
                }

                // Hỏi xác nhận người dùng trước khi xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    // Gọi DAL để xóa các liên kết kích thước, màu sắc của sản phẩm
                    bool isSizeDeleted = _sanPhamKichThuocBLL.DeleteProductSize(maSanPham, maKichThuoc);
                    bool isColorDeleted = _sanPhamMauSacBll.DeleteProductColor(maSanPham, maMau);

                    // Gọi DAL để xóa sản phẩm
                    bool isProductDeleted = _sanPhamBLL.DeleteProduct(maSanPham);

                    // Kiểm tra kết quả và hiển thị thông báo
                    if (isSizeDeleted && isColorDeleted && isProductDeleted)
                    {
                        MessageBox.Show("Sản phẩm đã được xóa thành công!");
                        loadSanPham(); // Tải lại danh sách sản phẩm
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi xóa sản phẩm. Vui lòng thử lại.");
                    }
                }
                else
                {
                    // Nếu người dùng chọn "No", không làm gì cả
                    MessageBox.Show("Hành động xóa sản phẩm đã bị hủy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Btn_suaSanPham_Click(object sender, EventArgs e)
        {
            btn_luuSanPham.Enabled = true;
            btn_themSanPham.Enabled=true;
            btn_xoaSanPham.Enabled =true ;
            btn_luuSanPham.BackColor = Color.White;
        }
        private string taoMaSanPham()
        {
            string maSanPham = "";
            int soLuongSanPham = _sanPhamBLL.GetProductList().Count;
            if (soLuongSanPham == 0)
            {
                maSanPham = "SP001";
            }
            else
            {
                maSanPham = "SP" + (soLuongSanPham + 1).ToString("000");
            }
            return maSanPham;
        }
        private void ClearFields()
        {
            // Xóa các giá trị trong các TextBox
            txt_maSanPham.Clear();
            txt_tenSanPham.Clear();
            txt_donViTinh.SelectedIndex = -1;
            txt_soLuongTon.Clear();
            txt_giaNhap.Clear();
            txt_giaBan.Clear();
            txt_moTa.Clear();
            txt_ngayTao.Clear();
            txt_ngayCapNhat.Clear();
            txt_soLuongTon.Clear();
            txt_soLuongToiThieu.Clear();
            txt_duongDan.Clear();
            loadComBoBoxLoaiSanPhamAdd();
            loadComboBoxCbKichThuoc();
            loadComboBoxMauSac();
            img_sanPham.Image = null; 
            txt_tenSanPham.Focus();
        }

        private void GetCurrentRowData()
        {
            try
            {
                if (dgv_dsSanPham.CurrentRow != null)
                {
                    DataGridViewRow currentRow = dgv_dsSanPham.CurrentRow;
                    txt_maSanPham.Text = currentRow.Cells["MaSanPham"].Value.ToString();
                    txt_tenSanPham.Text = currentRow.Cells["TenSanPham"].Value.ToString();
                    //load combox đơn vị tính
                    txt_donViTinh.Text = currentRow.Cells["DonViTinh"].Value.ToString();
                    txt_soLuongTon.Text = Convert.ToInt32(currentRow.Cells["SoLuongTon"].Value).ToString();
                    decimal giaNhap = Convert.ToDecimal(currentRow.Cells["GiaNhap"].Value);
                    decimal giaBan = Convert.ToDecimal(currentRow.Cells["GiaBan"].Value);
                    txt_giaNhap.Text = giaNhap.ToString("N0");
                    txt_giaBan.Text = giaBan.ToString("N0");
                    txt_moTa.Text = currentRow.Cells["MoTa"].Value.ToString();
                    txt_ngayTao.Text = Convert.ToDateTime(currentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
                    txt_ngayCapNhat.Text = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value).ToString("dd/MM/yyyy");
                    txt_soLuongToiThieu.Text = Convert.ToInt32(currentRow.Cells["SoLuongToiThieu"].Value).ToString();
                    txt_duongDan.Text = currentRow.Cells["HinhAnh"].Value?.ToString();
                    string hinhanh = currentRow.Cells["HinhAnh"].Value?.ToString();
                   // LoadKichThuocAndMauSac(txt_maSanPham.Text = currentRow.Cells["MaSanPham"].Value.ToString());

                    //hiện loại sản phẩm lên combobox
                    string maLoai = currentRow.Cells["MaLoai"].Value.ToString();
                    cbo_loaiSanPhamAdd.SelectedValue = maLoai;

                    //lấy mã màu sắc và kích thước từ sản phẩm hiện tại
                    string maMau = _sanPhamMauSacBll.GetOldProductColor(txt_maSanPham.Text);
                    string maKichThuoc = _sanPhamKichThuocBLL.GetOldSize(txt_maSanPham.Text);
                    //hiện màu sắc lên combobox
                    //string maMau = currentRow.Cells["MaMau"].Value.ToString();
                    cbo_tenMauSac.SelectedValue = maMau;
                    //hiện kích thước sản phẩm lên combobox
                    //string maKichThuoc = currentRow.Cells["MaKichThuoc"].Value.ToString();
                    cb_kichThuoc.SelectedValue = maKichThuoc;
                    if (!string.IsNullOrEmpty(hinhanh))
                    {
                        LoadImageToPictureBox(hinhanh);
                    }
                    else
                    {
                        img_sanPham.Image = null;
                    }

                    string trangThai = currentRow.Cells["TrangThai"].Value?.ToString(); // Sử dụng dấu hỏi (?) để kiểm tra null
                    if (string.IsNullOrEmpty(trangThai))
                    {
                        cbo_trangThai.Text = "Không xác định"; // Hoặc giá trị mặc định khi null
                    }
                    else
                    {
                        cbo_trangThai.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                    }
                }
                else
                {
                    Console.Write("Không có dòng nào được chọn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ dòng hiện tại: " + ex.Message);
            }

        }

        private void Btn_themSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (flagSanPham)
                {
                    // Lần nhấn đầu tiên, thực hiện thêm sản phẩm

                    string maSanPham = taoMaSanPham();
                    string tenSanPham = txt_tenSanPham.Text;
                    string donViTinh = txt_donViTinh.Text;
                    string giaNhapText = txt_giaNhap.Text;
                    string giaBanText = txt_giaBan.Text;

                    giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                    giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();

                    if (!decimal.TryParse(giaNhapText, out decimal giaNhap))
                    {
                        MessageBox.Show("Giá nhập không hợp lệ!");
                        return;
                    }
                    if (!decimal.TryParse(giaBanText, out decimal giaBan))
                    {
                        MessageBox.Show("Giá bán không hợp lệ!");
                        return;
                    }

                    int soLuongToiThieu = 10;
                    string moTa = txt_moTa.Text;
                    string hinhAnh = txt_duongDan.Text;

                    if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_tenMauSac.SelectedValue == null || cb_kichThuoc.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                        return;
                    }

                    string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                    string mauSac = cbo_tenMauSac.SelectedValue.ToString();
                    string kichThuoc = cb_kichThuoc.SelectedValue.ToString();

                    string tenMauSac = cbo_tenMauSac.SelectedItem != null
                        ? ((DTO.MauSac)cbo_tenMauSac.SelectedItem).TenMau
                        : string.Empty;

                    string tenKichThuoc = cb_kichThuoc.SelectedItem != null
                        ? ((DTO.KichThuoc)cb_kichThuoc.SelectedItem).TenKichThuoc
                        : string.Empty;

                    string maDaCo = _sanPhamBLL.GetProductCodesByNameColorSize(tenSanPham, tenMauSac, tenKichThuoc);
                    if (maDaCo != null)
                    {
                        MessageBox.Show("Đã có sản phẩm này rồi !");
                        return;
                    }

                    // Tạo mới sản phẩm
                    SanPham newProduct = new SanPham
                    {
                        MaSanPham = maSanPham,
                        TenSanPham = tenSanPham,
                        MaLoai = maLoai,
                        DonViTinh = donViTinh,
                        SoLuongTon = 0,
                        SoLuongToiThieu = soLuongToiThieu,
                        GiaNhap = giaNhap,
                        GiaBan = giaBan,
                        MoTa = moTa,
                        HinhAnh = hinhAnh,
                        TrangThai = true,
                        NgayTao = DateTime.Now,
                        NgayCapNhat = DateTime.Now
                    };

                    bool isSuccess = _sanPhamBLL.AddProduct(newProduct);
                    bool themMauSac = _sanPhamMauSacBll.AddProductColor(maSanPham, mauSac);
                    bool themKichThuoc = _sanPhamKichThuocBLL.AddProductSize(maSanPham, kichThuoc);

                    if (isSuccess && themMauSac && themKichThuoc)
                    {
                        MessageBox.Show("Sản phẩm đã được thêm thành công!");
                        loadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm sản phẩm. Vui lòng thử lại.");
                    }

                    // Cập nhật cờ và hình ảnh
                    flagSanPham = false;
                    btn_xoaSanPham.Enabled = true;
                    btn_luuSanPham.Enabled = true;
                    // Cập nhật hình ảnh nếu cần
                    // Ví dụ: nếu flagSanPham = true, thay đổi trạng thái của hình ảnh hoặc nút
                    btn_themSanPham.Image = Properties.Resources.icons8_add_35;
                }
                else
                {
                    // Nếu cờ là false, thực hiện hành động khác (nếu cần)
                    // Ví dụ: chỉ thay đổi trạng thái hình ảnh mà không thêm sản phẩm.
                    btn_xoaSanPham.Enabled = false;
                    btn_luuSanPham.Enabled = false;
                    LoadComBoBoxTrangThai();
                    ClearFields();
                    btn_themSanPham.Image = Properties.Resources.icons8_tick_32;
                    flagSanPham = true;  // Cập nhật lại cờ nếu cần
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private bool SaveImageToResources(string imagePath, string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
                File.Copy(imagePath, resourcePath, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void Btn_themAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{txt_maSanPham.Text}_{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return; 
                        }
                    }

                    txt_duongDan.Text = newImageName;
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBox(newImageName);
                    }
                }
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            string search = txt_timSanPham.Text;
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm");
            }
            List<SanPham> dsSanPham = _sanPhamBLL.SearchProducts(search);
            if (dsSanPham != null)
            {
                dgv_dsSanPham.DataSource = dsSanPham;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào");
                loadSanPham();
            }
        }

        private void PlaceHover(TextBox textBox, string textToShow)
        {
            textBox.MouseEnter += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  
                {
                    textBox.Text = "";  
                    textBox.ForeColor = System.Drawing.Color.Black; 
                }
            };

            textBox.MouseLeave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  
                {
                    textBox.Text = textToShow;  
                    textBox.ForeColor = System.Drawing.Color.Gray; 
                }

            };

            textBox.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  
                {
                    textBox.Text = ""; 
                    textBox.ForeColor = System.Drawing.Color.Black; 
                }
            };
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_dsSanPham_SelectionChanged(object sender, EventArgs e)
        {
            GetCurrentRowData();
        }

        private void btn_themSanPham_Click_1(object sender, EventArgs e)
        {

        }

        private void dgv_dsSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_themAnh_Click_1(object sender, EventArgs e)
        {

        }
    }
}
