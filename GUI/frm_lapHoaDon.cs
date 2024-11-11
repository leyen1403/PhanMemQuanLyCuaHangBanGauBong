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
        private string maNV = "NV001";
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        KhachHangBLL _khachHangBLL= new KhachHangBLL();
        HoaDonBanHangBLL _hoaDonBanHangBLL = new HoaDonBanHangBLL();
        ChiTietHoaDonBanHangBLL _chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL() ;
        public frm_lapHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_lapHoaDon_Load;
            loadNgayHT();
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
            dgvCart.Columns["MaSP"].Width = 70;  // Đặt chiều rộng cột Mã Sản Phẩm là 70
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

            // Ngăn không cho tạo thêm cột mới
            dgvCart.AllowUserToAddRows = false;
        }

        private void dsSanPham_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Frm_lapHoaDon_Load(object sender, EventArgs e)
        {
            txt_tenSanPham.Text = "Nhập thông tin sản phẩm";
            txt_tenSanPham.ForeColor = Color.Gray;
            this.txt_tenSanPham.Enter += Txt_tenSanPham_Enter;
            this.txt_tenSanPham.Leave += Txt_tenSanPham_Leave;
            this.btn_timSanPham.Click += Btn_timSanPham_Click;
            this.btn_addCart.Click += Btn_addCart_Click;
            this.btn_timKhachHang.Click += Btn_timKhachHang_Click;
            this.btn_Clear.Click += Btn_Clear_Click;
            this.btn_inHoaDon.Click += Btn_inHoaDon_Click;
            this.btn_luuHoaDon.Click += Btn_luuHoaDon_Click;
            txt_TongSL.Enabled =txt_tongTien.Enabled =txt_diemTichLuy.Enabled= false;
            dsSanPham.AutoScroll = true;
            loadSanPham(_sanPhamBLL.GetUniqueProducts());
            loadComBoxLoai();
            txt_soLuong.Minimum = 1;
            txt_soLuong.Maximum = 100;
            txt_soLuong.Value = 1;
            InitializeDataGridView();
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

        private void Btn_luuHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra giỏ hàng
            if (dgvCart.Rows.Count == 0 || dgvCart.Rows.Cast<DataGridViewRow>().All(row => row.IsNewRow))
            {
                MessageBox.Show("Giỏ hàng không có sản phẩm. Vui lòng thêm sản phẩm vào giỏ hàng trước khi lưu hóa đơn.");
                return;
            }

            // Lấy thông tin khách hàng từ các TextBox
            string maKhachHang = txt_maKhachHang.Text;
            string tenKhachHang = txt_tenKhachHang.Text;
            string sdt = txt_soDienThoai.Text;
            string diaChi = txt_diaChi.Text;
            decimal diemTichLuy = 0;

            // Tính tổng tiền và điểm tích lũy
            decimal tongTien = CalculateTotalAmount();
            diemTichLuy = CalculateDiemTichLuy(tongTien);

            int tongSl = CalculateTotalProducts();
            if (tongTien <= 0)
            {
                MessageBox.Show("Tổng tiền không hợp lệ.");
                return;
            }

            // Kiểm tra thông tin khách hàng
            if (string.IsNullOrEmpty(maKhachHang) && string.IsNullOrEmpty(tenKhachHang) && string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập hoặc chọn thông tin khách hàng.");
                return;
            }

            // Lấy khách hàng từ cơ sở dữ liệu
            KhachHang kh = _khachHangBLL.GetKhachHang(maKhachHang, tenKhachHang, sdt);
            if (kh == null)
            {
                string maKhachHangMoi = taoMaKhachHang();
                // Thêm khách hàng mới vào cơ sở dữ liệu nếu chưa có
                KhachHang khachHangMoi = new KhachHang
                {
                    MaKhachHang = maKhachHangMoi,
                    TenKhachHang = tenKhachHang,
                    SoDienThoai = sdt,
                    DiaChi = diaChi,
                    TrangThai=true,
                    ThanhVien=false
                };

                bool isAdded = _khachHangBLL.ThemKhachHang(khachHangMoi);

                if (!isAdded)
                {
                    MessageBox.Show("Có lỗi xảy ra khi thêm khách hàng mới.");
                    return;
                }

                kh = khachHangMoi;
            }

            // Kiểm tra và sử dụng điểm tích lũy (nếu khách hàng là thành viên)
            decimal diemSuDung = 0; // Gán giá trị mặc định
            if (decimal.TryParse(txt_diemDung.Text, out diemSuDung))
            {
                // Chuyển thành công, diemSuDung sẽ chứa giá trị nhập vào
            }

            if (chkSuDungDiemTichLuy.Checked)
            {
                if (kh.ThanhVien == false) // Kiểm tra nếu khách hàng là thành viên mới có thể sử dụng điểm tích lũy
                {
                    MessageBox.Show("Chỉ khách hàng thành viên mới có thể sử dụng điểm tích lũy.");
                    return; // Dừng lại nếu khách hàng không phải là thành viên
                }
                if (diemSuDung > 0)
                {

                    diemSuDung = (kh.DiemTichLuy ?? 0) >= diemTichLuy ? diemTichLuy : (kh.DiemTichLuy ?? 0);
                    tongTien -= diemSuDung; // Trừ điểm tích lũy từ tổng tiền
                    txt_tongTien.Text = tongTien.ToString();
                }
            }

            // Kiểm tra và lưu hóa đơn
            try
            {
                HoaDonBanHang hoaDon = new HoaDonBanHang
                {
                    MaHoaDonBanHang = taoMaHoaDon(), // Tạo mã hóa đơn mới
                    NgayLap = DateTime.Now, // Thời gian lập hóa đơn
                    MaKhachHang = kh.MaKhachHang, // Mã khách hàng (có giá trị hợp lệ?)
                    MaNhanVien = maNV, // Mã nhân viên (có giá trị hợp lệ?)
                    TongSanPham = tongSl, // Tổng số lượng sản phẩm
                    TongTien = tongTien, // Tổng tiền
                    DiemCongTichLuy = diemTichLuy, // Điểm cộng tích lũy
                    DiemTichLuy = (kh.DiemTichLuy ?? 0) + diemTichLuy - diemSuDung // Điểm tích lũy cập nhật
                };

                bool themDiemCong = _khachHangBLL.AddDiemCongTichLuy(kh.MaKhachHang, diemTichLuy);

                if (!themDiemCong)
                {
                    Console.WriteLine("Thêm điểm cộng thất bại");
                }
                // Kiểm tra các giá trị trước khi thêm vào cơ sở dữ liệu
                if (hoaDon.MaKhachHang == null || hoaDon.MaNhanVien == null)
                {
                    MessageBox.Show("Thông tin khách hàng hoặc nhân viên không hợp lệ.");
                    return;
                }

                // Tiến hành thêm hóa đơn vào cơ sở dữ liệu
                bool isHoaDonAdded = _hoaDonBanHangBLL.AddHoaDonBanHang(hoaDon);
                if (!isHoaDonAdded)
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu hóa đơn.");
                    return;
                }

                // Thêm chi tiết hóa đơn cho từng sản phẩm trong giỏ hàng
                foreach (DataGridViewRow row in dgvCart.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string maCTHDBH = taoCTHD();
                        var chiTietHoaDon = new ChiTietHoaDonBanHang
                        {
                            MaChiTietHoaDonBanHang=maCTHDBH,
                            MaHoaDon = hoaDon.MaHoaDonBanHang,
                            MaSanPham = row.Cells["MaSP"].Value.ToString(),
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            DonGia = Convert.ToDecimal(row.Cells["Gia"].Value),
                            ThanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value),
                        };

                        Console.WriteLine($"Adding ChiTietHoaDon: {chiTietHoaDon.MaSanPham}, Quantity: {chiTietHoaDon.SoLuong}, TotalPrice: {chiTietHoaDon.ThanhTien}");
                        _chiTietHoaDonBanHangBLL.AddChiTietHoaDon(chiTietHoaDon);
                    }
                }

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


        private void Btn_inHoaDon_Click(object sender, EventArgs e)
        {
            
        }

        private void Btn_Clear_Click(object sender, EventArgs e)
        {
           clearAll();
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
        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }
            txt_tongTien.Text = totalAmount.ToString("N0");  // Định dạng theo kiểu tiền tệ
        }

        private void Btn_timSanPham_Click(object sender, EventArgs e)
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            loadNgayHT();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

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
        public void loadNgayHT()
        {
            DateTime currentDateTime = DateTime.Now;
            string formattedDate = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");
            label_ngayHT.Text = formattedDate; 
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
        private void cbo_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_loai.SelectedItem != null)
            {
                var selectedLoai = (LoaiSanPham)cbo_loai.SelectedItem;

                if (selectedLoai.MaLoai == "ALL")
                {
                    loadSanPham(_sanPhamBLL.GetUniqueProducts());
                }
                else
                {
                    loadSanPhamTheoMa();
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
    }
}
