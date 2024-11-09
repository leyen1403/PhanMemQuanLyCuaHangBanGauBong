using System;
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
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            loadSanPham();
            this.Load += Frm_quanLyKhoHang_Load;
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

                    // Đặt tên các cột cho DataGridView
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

                    // Căn giữa tiêu đề cột và định dạng tiêu đề
                    foreach (DataGridViewColumn column in dgv_dsSanPham.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt kiểu chữ cho tiêu đề (tuỳ chọn)
                    }

                    // Duyệt qua các dòng và thay đổi màu nền nếu trạng thái là "đã xóa" (TrangThai = false)
                    foreach (DataGridViewRow row in dgv_dsSanPham.Rows)
                    {
                        // Kiểm tra trạng thái sản phẩm, nếu trạng thái là false (đã xóa)
                        bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                        if (!trangThai)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink; // Bôi màu đỏ cho dòng
                        }
                    }
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
            btn_khoiPhuc.Click += Btn_khoiPhuc_Click;
            btn_luuSanPham.Visible = false;
            txt_ngayTao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            txt_ngayCapNhat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            GetCurrentRowData();
            btn_timDK.Click += Btn_timDK_Click;
            btn_load.Click += Btn_load_Click;
            //PlaceHover(txt_timSanPham, "Nhập thông tin cần tìm");

        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            loadSanPham();
        }

        private void Btn_timDK_Click(object sender, EventArgs e)
        {
            dgv_dsSanPham.DataSource = null;
            // Kiểm tra nếu ComboBox có giá trị được chọn
            string maLoai = cbo_loaiSanPham.SelectedValue != null ? cbo_loaiSanPham.SelectedValue.ToString() : string.Empty;
            string maMau = cb_tenMauSac.SelectedValue != null ? cb_tenMauSac.SelectedValue.ToString() : string.Empty;
            string maKichThuoc = cbo_tenKichThuoc.SelectedValue != null ? cbo_tenKichThuoc.SelectedValue.ToString() : string.Empty;
            List<SanPham> dsSanPham = _sanPhamBLL.SearchProducts(maLoai, maMau, maKichThuoc);
            dgv_dsSanPham.DataSource = dsSanPham;
        }

        private void Btn_khoiPhuc_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = string.Empty;

                // Kiểm tra xem mã sản phẩm có được nhập vào TextBox không
                if (!string.IsNullOrEmpty(txt_maSanPham.Text))
                {
                    maSanPham = txt_maSanPham.Text;
                }
                // Nếu không có mã sản phẩm trong TextBox, lấy từ DataGridView
                else if (dgv_dsSanPham.CurrentRow != null)
                {
                    maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần khôi phục hoặc nhập mã sản phẩm.");
                    return;
                }

                // Gọi phương thức UpdateTrangThaiSanPham từ BLL để cập nhật trạng thái sản phẩm thành "đã xóa"
                _sanPhamBLL.UpdateTrangThaiSanPham(maSanPham, true);

                // Tải lại danh sách sản phẩm
                loadSanPham();
                MessageBox.Show("Sản phẩm đã được khôi phục.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi khôi phục sản phẩm: " + ex.Message);
            }
        }

        private void Btn_luuSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các TextBox (hoặc các control tương ứng) để tạo đối tượng sản phẩm
                string maSanPham = txt_maSanPham.Text; // Giả sử bạn có TextBox txt_maSanPham để lấy mã sản phẩm
                string tenSanPham = txt_tenSanPham.Text; // TextBox cho tên sản phẩm
                string donViTinh = txt_donViTinh.Text; // TextBox cho đơn vị tính

                // Kiểm tra giá trị số lượng tồn
                if (!int.TryParse(txt_soLuongToiThieu.Text, out int soLuongToiThieu))
                {
                    MessageBox.Show("Số lượng tối thiểu không hợp lệ!");
                    return;
                }

                // Kiểm tra và xử lý giá nhập và giá bán
                string giaNhapText = txt_giaNhap.Text;
                string giaBanText = txt_giaBan.Text;

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

                string moTa = txt_moTa.Text; // TextBox cho mô tả

                // Kiểm tra các ComboBox
                if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_tenMauSac.SelectedValue == null || cb_kichThuoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                    return;
                }

                // Lấy giá trị từ ComboBox
                string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                string maMauCu = _sanPhamMauSacBll.GetOldProductColor(maSanPham);
                string maKichThuocCuu = _sanPhamKichThuocBLL.GetOldSize(maSanPham);
                string maMau = cbo_tenMauSac.SelectedValue.ToString();
                string maKichThuoc = cb_kichThuoc.SelectedValue.ToString();
                string hinhanh = txt_duongDan.Text;

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
                    NgayCapNhat = DateTime.Now // Cập nhật ngày giờ hiện tại
                };

                // Gọi BLL để lưu thông tin sản phẩm
                bool result = _sanPhamBLL.UpdateProductInList(updatedProduct); // Giả sử bạn có phương thức UpdateProductInList trong BLL
                bool capNhatMauSac = _sanPhamMauSacBll.UpdateProductColor(maSanPham, maMauCu, maMau);
                bool capNhatKichThuoc = _sanPhamKichThuocBLL.UpdateProductSize(maSanPham, maKichThuocCuu, maKichThuoc);

                // Kiểm tra xem tất cả các thao tác có thành công không
                if (result && capNhatMauSac && capNhatKichThuoc)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công.");

                    // Ẩn nút Lưu sau khi cập nhật thành công
                    btn_luuSanPham.Visible = false;

                    // Tải lại danh sách sản phẩm
                    loadSanPham();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại. Vui lòng kiểm tra lại thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu sản phẩm: " + ex.Message);
            }

        }

        private void Btn_xoaSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                string maSanPham = string.Empty;

                // Kiểm tra xem mã sản phẩm có được nhập vào TextBox không
                if (!string.IsNullOrEmpty(txt_maSanPham.Text))
                {
                    maSanPham = txt_maSanPham.Text;
                }
                // Nếu không có mã sản phẩm trong TextBox, lấy từ DataGridView
                else if (dgv_dsSanPham.CurrentRow != null)
                {
                    maSanPham = dgv_dsSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa hoặc nhập mã sản phẩm.");
                    return;
                }

                // Gọi phương thức UpdateTrangThaiSanPham từ BLL để cập nhật trạng thái sản phẩm thành "đã xóa"
                _sanPhamBLL.UpdateTrangThaiSanPham(maSanPham, false);

                // Tải lại danh sách sản phẩm
                loadSanPham();
                MessageBox.Show("Sản phẩm đã được xóa.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
        }

        private void Btn_suaSanPham_Click(object sender, EventArgs e)
        {
            btn_luuSanPham.Visible = true;
            btn_khoiPhuc.Visible = true;
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
        private void GetCurrentRowData()
        {
            try
            {
                // Kiểm tra xem có dòng hiện tại nào được chọn không
                if (dgv_dsSanPham.CurrentRow != null)
                {
                    // Lấy dòng hiện tại
                    DataGridViewRow currentRow = dgv_dsSanPham.CurrentRow;

                    // Lấy giá trị của các cột trong dòng hiện tại và gán vào các TextBox
                    txt_maSanPham.Text = currentRow.Cells["MaSanPham"].Value.ToString();
                    txt_tenSanPham.Text = currentRow.Cells["TenSanPham"].Value.ToString();
                    txt_donViTinh.Text = currentRow.Cells["DonViTinh"].Value.ToString();
                    txt_soLuongTon.Text = Convert.ToInt32(currentRow.Cells["SoLuongTon"].Value).ToString();
                    // Lấy giá trị từ các ô và chuyển đổi thành decimal
                    decimal giaNhap = Convert.ToDecimal(currentRow.Cells["GiaNhap"].Value);
                    decimal giaBan = Convert.ToDecimal(currentRow.Cells["GiaBan"].Value);

                    // Định dạng giá trị theo Tiền Việt Nam (VND) và hiển thị trong TextBox
                    txt_giaNhap.Text = giaNhap.ToString();
                    txt_giaBan.Text = giaBan.ToString();
                    txt_moTa.Text = currentRow.Cells["MoTa"].Value.ToString();
                    txt_ngayTao.Text = Convert.ToDateTime(currentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");
                    txt_ngayCapNhat.Text = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value).ToString("dd/MM/yyyy");
                    txt_soLuongToiThieu.Text = Convert.ToInt32(currentRow.Cells["SoLuongToiThieu"].Value).ToString();
                    txt_duongDan.Text = currentRow.Cells["HinhAnh"].Value?.ToString();
                    string hinhanh = currentRow.Cells["HinhAnh"].Value?.ToString();
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
                        txt_trangThai.Text = "Không xác định"; // Hoặc giá trị mặc định khi null
                    }
                    else
                    {
                        txt_trangThai.Text = trangThai == "True" ? "Hoạt động" : "Không hoạt động";
                    }


                }
                else
                {
                    MessageBox.Show("Không có dòng nào được chọn.");
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
                string maSanPham = taoMaSanPham();
                string tenSanPham = txt_tenSanPham.Text;
                string donViTinh = txt_donViTinh.Text;
                string giaNhapText = txt_giaNhap.Text;
                string giaBanText = txt_giaBan.Text;

                // Loại bỏ các ký tự không hợp lệ như dấu phân cách (ví dụ: dấu ',' hoặc ký hiệu tiền tệ "₫")
                giaNhapText = giaNhapText.Replace(",", "").Replace("₫", "").Trim();
                giaBanText = giaBanText.Replace(",", "").Replace("₫", "").Trim();

                // Kiểm tra và ép kiểu số liệu từ các TextBox
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


                // Kiểm tra và ép kiểu số liệu từ các TextBox
                if (!int.TryParse(txt_soLuongTon.Text, out int soLuongTon))
                {
                    MessageBox.Show("Số lượng tồn không hợp lệ!");
                    return;
                }

                int soLuongToiThieu = 10;
                string moTa = txt_moTa.Text;
                string hinhAnh = txt_duongDan.Text;

                // Kiểm tra ComboBox có giá trị được chọn hay không
                if (cbo_loaiSanPhamAdd.SelectedValue == null || cbo_tenMauSac.SelectedValue == null || cb_kichThuoc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Loại, Màu Sắc và Kích Thước.");
                    return;
                }

                // Lấy giá trị từ các ComboBox
                string maLoai = cbo_loaiSanPhamAdd.SelectedValue.ToString();
                string mauSac = cbo_tenMauSac.SelectedValue.ToString();
                string kichThuoc = cb_kichThuoc.SelectedValue.ToString();

                // Tạo đối tượng SanPham mới
                SanPham newProduct = new SanPham
                {
                    MaSanPham = maSanPham,
                    TenSanPham = tenSanPham,
                    MaLoai = maLoai,  // Mã loại lấy từ ComboBox
                    DonViTinh = donViTinh,
                    SoLuongTon = soLuongTon,
                    SoLuongToiThieu = soLuongToiThieu,
                    GiaNhap = giaNhap,
                    GiaBan = giaBan,
                    MoTa = moTa,
                    HinhAnh = hinhAnh,
                    TrangThai = true,  // Trạng thái mặc định là sản phẩm còn hoạt động
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now
                };

                // Gọi phương thức thêm sản phẩm từ BLL
                bool isSuccess = _sanPhamBLL.AddProduct(newProduct);

                // Gọi thêm màu sắc và kích thước cho sản phẩm
                bool themMauSac = _sanPhamMauSacBll.AddProductColor(maSanPham, mauSac);
                bool themKichThuoc = _sanPhamKichThuocBLL.AddProductSize(maSanPham, kichThuoc);

                // Kiểm tra xem tất cả các thao tác có thành công không
                if (isSuccess && themMauSac && themKichThuoc)
                {
                    MessageBox.Show("Sản phẩm đã được thêm thành công!");
                    loadSanPham();  // Làm mới danh sách sản phẩm (nếu cần)
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm sản phẩm. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private bool SaveImageToResources(string imagePath, string imageName)
        {
            try
            {
                // Đường dẫn lưu ảnh trong thư mục Resources của ứng dụng
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Tạo thư mục Resources nếu chưa tồn tại
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Sao chép ảnh vào thư mục Resources
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

                    // Đổi tên ảnh dựa trên mã loại sản phẩm hoặc tên khác
                    string newImageName = $"{txt_maSanPham.Text}_{Path.GetFileName(selectedImagePath)}";

                    // Đường dẫn lưu ảnh trong thư mục Resources của ứng dụng
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);

                    // Kiểm tra xem ảnh đã tồn tại chưa
                    if (File.Exists(resourcePath))
                    {
                        // Hỏi người dùng có muốn ghi đè ảnh cũ không
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return; // Dừng lại nếu người dùng không muốn ghi đè
                        }
                    }

                    // Cập nhật đường dẫn mới vào TextBox hiển thị đường dẫn
                    txt_duongDan.Text = newImageName;

                    // Lưu ảnh vào thư mục Resources
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        // Hiển thị hình ảnh đã lưu vào PictureBox
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
            // Di chuột vào TextBox
            textBox.MouseEnter += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  // Kiểm tra nếu TextBox trống thì ẩn chữ mẫu
                {
                    textBox.Text = "";  // Xóa chữ khi chuột rời khỏi
                    textBox.ForeColor = System.Drawing.Color.Black; // Đặt màu chữ lại như mặc định (màu đen)
                }
            };

            // Rời chuột khỏi TextBox
            textBox.MouseLeave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  // Kiểm tra nếu TextBox trống thì hiển thị chữ mẫu
                {
                    textBox.Text = textToShow;  // Hiển thị chữ khi chuột vào
                    textBox.ForeColor = System.Drawing.Color.Gray;  // Chữ màu xám
                }

            };

            // Kiểm tra khi người dùng bắt đầu nhập liệu
            textBox.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(textBox.Text))  // Kiểm tra nếu TextBox trống thì ẩn chữ mẫu
                {
                    textBox.Text = "";  // Xóa chữ khi chuột rời khỏi
                    textBox.ForeColor = System.Drawing.Color.Black; // Đặt màu chữ lại như mặc định (màu đen)
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
    }
}
