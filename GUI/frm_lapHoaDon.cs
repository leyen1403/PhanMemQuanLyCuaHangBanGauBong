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
        private Timer timer;
        private string maNV = "NV001";
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        public frm_lapHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_lapHoaDon_Load;
            loadNgayHT();
        }
        private void InitializeDataGridView()
        {
            dgvCart.Columns.Clear(); // Xóa các cột cũ nếu có

            // Thêm các cột
            dgvCart.Columns.Add("MaSP", "Mã Sản Phẩm");
            dgvCart.Columns.Add("TenSanPham", "Tên Sản Phẩm");
            dgvCart.Columns.Add("MauSac", "Màu Sắc"); // Thêm cột màu sắc
            dgvCart.Columns.Add("KichThuoc", "Kích Thước"); // Thêm cột kích thước
            dgvCart.Columns.Add("SoLuong", "Số Lượng");
            dgvCart.Columns.Add("Gia", "Giá");
            dgvCart.Columns.Add("ThanhTien", "Thành Tiền");

            // Thêm cột Xóa với hình ảnh
            DataGridViewImageColumn btnXoa = new DataGridViewImageColumn();
            btnXoa.Name = "Xoa";
            btnXoa.HeaderText = "Xóa";
            btnXoa.Image = Properties.Resources.icons8_delete_35;  // Đảm bảo rằng "icons8_delete_35" là tên tài nguyên của bạn trong Resources

            dgvCart.Columns.Add(btnXoa);
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
            dsSanPham.AutoScroll = true;
            loadSanPham(_sanPhamBLL.GetUniqueProducts());
            loadComBoxLoai();
            txt_soLuong.Minimum = 1;
            txt_soLuong.Maximum = 100;
            txt_soLuong.Value = 1;
            InitializeDataGridView();
        }
        private void Btn_addCart_Click(object sender, EventArgs e)
        {
            //if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            //{
            //    string tenSanPham = productSelected.TenSanPham;  // Lấy tên sản phẩm đã chọn
            //    string mauSac = cbo_mauSac.SelectedItem.ToString();  // Lấy màu sắc đã chọn
            //    string kichThuoc = cbo_kichThuoc.SelectedItem.ToString();  // Lấy kích thước đã chọn

            //    // Lấy mã sản phẩm dựa trên tên, màu sắc và kích thước
            //    string maSanPham = _sanPhamBLL.GetProductCodesByNameColorSize(tenSanPham, mauSac, kichThuoc);

            //    if (string.IsNullOrEmpty(maSanPham))
            //    {
            //        MessageBox.Show("Mã sản phẩm không hợp lệ!");
            //        return;
            //    }

            //    int soLuong = (int)txt_soLuong.Value;  // Lấy số lượng từ control txt_soLuong
            //    if (soLuong <= 0)
            //    {
            //        MessageBox.Show("Vui lòng chọn số lượng sản phẩm lớn hơn 0!");
            //        return;
            //    }

            //    var sanPham = _sanPhamBLL.GetSanPhamWithMauSacKichThuocByMaSanPham(maSanPham);

            //    if (sanPham != null)
            //    {
            //        decimal giaBan = sanPham.GiaBan;  // Truy cập thuộc tính giaBan trực tiếp

            //        if (giaBan <= 0)
            //        {
            //            MessageBox.Show("Giá sản phẩm không hợp lệ!");
            //            return;
            //        }

            //        decimal thanhTien = giaBan * soLuong;

            //        // Thêm sản phẩm vào giỏ hàng
            //        dgvCart.Rows.Add(sanPham.MaSanPham, sanPham.TenSanPham,
            //                         sanPham.TenMau, sanPham.TenKichThuoc,
            //                         giaBan.ToString("N0"), soLuong, thanhTien.ToString("N0"));

            //        UpdateTotalAmount();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sản phẩm không tìm thấy!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn màu sắc và kích thước sản phẩm!");
            //}

        }
        private void UpdateTotalAmount()
        {
            // Tính tổng số tiền trong giỏ hàng
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgvCart.Rows)
            {
                totalAmount += Convert.ToDecimal(row.Cells["ThanhTien"].Value);
            }

            // Hiển thị tổng số tiền vào TextBox hoặc Label
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
            // Lấy danh sách các loại sản phẩm từ BLL
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
                // Định nghĩa đường dẫn đến ảnh trong thư mục "Resources"
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra xem tệp có tồn tại trong đường dẫn đã chỉ định không
                if (File.Exists(resourcePath))
                {
                    // Tải ảnh vào PictureBox
                    pictureBox.Image = Image.FromFile(resourcePath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Điều chỉnh ảnh để vừa vặn trong PictureBox
                }
                else
                {
                    // Nếu tệp không tồn tại, đặt ảnh mặc định
                    pictureBox.Image = Properties.Resources.gaucute; // Thay thế với ảnh mặc định của bạn
                }
            }
            catch (Exception ex)
            {
               
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
                // Tạo mới một điều khiển ProductItem
                ProductItem myControl = new ProductItem();

                // Gán tên sản phẩm cho ProductItem
                myControl.TenSanPham = sp.TenSanPham;  // Gán tên sản phẩm vào Label

                // Gán sự kiện cho các sự kiện chuột
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;

                // Đặt kích thước cho ProductItem
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);

                // Tìm PictureBox bên trong ProductItem
                PictureBox anhSanPham = myControl.Controls.Find("anhSanPham", true).FirstOrDefault() as PictureBox;
                if (anhSanPham != null)
                {
                    // Gọi LoadImageToPictureBox để tải ảnh cho sản phẩm
                    LoadImageToPictureBox(sp.HinhAnh, anhSanPham);  // Thay thế sp.HinhAnh với đường dẫn hình ảnh
                }

                // Thêm ProductItem vào điều khiển chứa sản phẩm
                dsSanPham.Controls.Add(myControl);

                // Tính toán vị trí để sắp xếp sản phẩm
                currentX += controlWidth + spacing;

                // Kiểm tra nếu hết chiều rộng panel, chuyển sang dòng mới
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }

            // Đặt AutoScrollMinSize để hiển thị tất cả sản phẩm
            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
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
            // Giả sử bạn có phương thức trong DAL hoặc BLL để lấy tên màu sắc và kích thước của sản phẩm
            var colors = _sanPhamBLL.GetAllColorsByProductName(tenSanPham); // Lấy danh sách màu sắc
            var sizes = _sanPhamBLL.GetAllSizesByProductName(tenSanPham);   // Lấy danh sách kích thước

            // Cập nhật giao diện với màu sắc và kích thước
            cbo_mauSac.Items.Clear(); // Xóa các mục cũ
            cbo_kichThuoc.Items.Clear();  // Xóa các mục cũ

            // Thêm tên màu sắc vào ComboBox hoặc ListBox
            foreach (var color in colors)
            {
                cbo_mauSac.Items.Add(color.TenMau); // Thêm tên màu sắc vào cbo_mauSac
            }

            // Thêm tên kích thước vào ComboBox hoặc ListBox
            foreach (var size in sizes)
            {
                cbo_kichThuoc.Items.Add(size.TenKichThuoc); // Thêm tên kích thước vào cbo_kichThuoc
            }

            // Cập nhật giao diện sau khi load dữ liệu
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

            // Định dạng ngày theo dd/MM/yyyy
            string formattedDate = currentDateTime.ToString("dd/MM/yyyy HH:mm:ss");

            // Hiển thị ra giao diện, ví dụ, vào một Label
            label_ngayHT.Text = formattedDate; // lblNgayHT là tên Label để hiển thị ngày giờ
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void LoadProductPrice()
        {
            // Kiểm tra xem người dùng đã chọn đủ thông tin chưa
            if (cbo_mauSac.SelectedItem != null && cbo_kichThuoc.SelectedItem != null)
            {
                // Lấy tên sản phẩm từ ProductItem được chọn
                string tenSanPham = productSelected.TenSanPham; // Giả sử ProductItem có thuộc tính TenSanPham
                string mauSac = cbo_mauSac.SelectedItem.ToString(); // Lấy màu sắc đã chọn
                string kichThuoc = cbo_kichThuoc.SelectedItem.ToString(); // Lấy kích thước đã chọn

                // Lấy mã sản phẩm từ tên, màu sắc, kích thước
                string maSP = _sanPhamBLL.GetProductCodesByNameColorSize(tenSanPham, mauSac, kichThuoc);

                // Gọi phương thức trong BLL hoặc DAL để lấy giá sản phẩm theo mã sản phẩm
                decimal? giaSanPham = _sanPhamBLL.GetProductPriceByCode(maSP);

                // Kiểm tra xem giá có hợp lệ không và cập nhật giá vào TextBox
                if (giaSanPham.HasValue)
                {
                    // Định dạng giá theo kiểu tiền tệ, thêm dấu phân cách hàng nghìn
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
                // Tạo mới một điều khiển ProductItem
                ProductItem myControl = new ProductItem();

                // Gán tên sản phẩm cho ProductItem
                myControl.TenSanPham = sp.TenSanPham;  // Gán tên sản phẩm vào Label

                // Gán sự kiện cho các sự kiện chuột
                myControl.Click += MyControl_Click;
                myControl.MouseEnter += MyControl_MouseEnter;
                myControl.MouseLeave += MyControl_MouseLeave;

                // Đặt kích thước cho ProductItem
                myControl.Size = new Size(controlWidth, controlHeight);
                myControl.Location = new Point(currentX, currentY);

                // Tìm PictureBox bên trong ProductItem
                PictureBox anhSanPham = myControl.Controls.Find("anhSanPham", true).FirstOrDefault() as PictureBox;
                if (anhSanPham != null)
                {
                    // Gọi LoadImageToPictureBox để tải ảnh cho sản phẩm
                    LoadImageToPictureBox(sp.HinhAnh, anhSanPham);  // Thay thế sp.HinhAnh với đường dẫn hình ảnh
                }

                // Thêm ProductItem vào điều khiển chứa sản phẩm
                dsSanPham.Controls.Add(myControl);

                // Tính toán vị trí để sắp xếp sản phẩm
                currentX += controlWidth + spacing;

                // Kiểm tra nếu hết chiều rộng panel, chuyển sang dòng mới
                if (currentX + controlWidth > panelWidth)
                {
                    currentX = 10;
                    currentY += controlHeight + spacing;
                }
            }

            // Đặt AutoScrollMinSize để hiển thị tất cả sản phẩm
            dsSanPham.AutoScrollMinSize = new Size(0, currentY + controlHeight + spacing);
        }
        private void cbo_loai_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Chỉ thực hiện xử lý khi ComboBox đã được nạp đầy đủ
            if (cbo_loai.SelectedItem != null)
            {
                var selectedLoai = (LoaiSanPham)cbo_loai.SelectedItem;

                // Kiểm tra nếu người dùng chọn "Tất cả"
                if (selectedLoai.MaLoai == "ALL")
                {
                    // Hiển thị tất cả sản phẩm
                    loadSanPham(_sanPhamBLL.GetUniqueProducts());
                }
                else
                {
                    // Lấy sản phẩm theo mã loại đã chọn
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
            // Kiểm tra xem người dùng có nhập phải là chữ cái không
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)  // 8 là phím Backspace
            {
                e.Handled = true; // Nếu không phải số hoặc phím Backspace thì không cho nhập
            }
        }
    }
}
