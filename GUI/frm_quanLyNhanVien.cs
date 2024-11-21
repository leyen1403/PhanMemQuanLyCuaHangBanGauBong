using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;

namespace GUI
{
    public partial class frm_quanLyNhanVien : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frm_quanLyNhanVien()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            // Gọi hàm này trong Form_Load:
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_quanLyNhanVien_Load;
            this.dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
            this.btn_timKiem.Click += Btn_timKiem_Click;
            this.btn_load.Click += Btn_load_Click;
            this.btn_clear.Click += Btn_clear_Click;
            this.btn_timDK.Click += Btn_timDK_Click;
            this.btnThemNhanVien.Click += BtnThemNhanVien_Click;
            this.btnXoaNhanVien.Click += BtnXoaNhanVien_Click;
            this.btnSuaNhanVien.Click += BtnSuaNhanVien_Click; ;
            this.btnLuuSanPham.Click += BtnLuuSanPham_Click;
            this.btn_themAnh.Click += Btn_themAnh_Click;

        }

        private void Btn_themAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    txtHinhAnh.Text = newImageName;
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBox(newImageName);
                    }
                }
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

        private void BtnSuaNhanVien_Click(object sender, EventArgs e)
        {
           txtMaNV.Enabled = false;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void BtnLuuSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtMaNV.Text.Trim();
                string hoTen = txtHoTen.Text;
                string chucVu = cbbChucVu.SelectedValue?.ToString();

                DateTime ngaySinh = dTPNgaySinh.Value;
                DateTime ngayTao = dTPNgayTao.Value;

                string gioiTinh = txtGioiTinh.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string email = txtEmail.Text;
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string hinhAnh = txtHinhAnh.Text;

                string diaChi = txtDiaChi.Text;

                if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(chucVu) ||
                    string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(taiKhoan))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên.");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Email không hợp lệ!");
                    return;
                }

                if (ngaySinh > DateTime.Now)
                {
                    MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại!");
                    return;
                }

                NhanVien updatedEmployee = new NhanVien
                {
                    MaNhanVien = maNhanVien,
                    HoTen = hoTen,
                    ChucVu = chucVu,
                    GioiTinh = gioiTinh,
                    SoDienThoai = soDienThoai,
                    Email = email,
                    TaiKhoan = taiKhoan,
                    MatKhau = matKhau,
                    HinhAnh = hinhAnh,
                    TrangThai = true, 
                    NgaySinh = ngaySinh,
                    NgayTao = DateTime.Now,
                    NgayCapNhat = DateTime.Now, 
                    DiaChi = diaChi
                };

                bool result = nhanVienBLL.UpdateEmployee(updatedEmployee);

                if (result)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công.");
                    loadDSNhanVien(); // 
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại. Vui lòng kiểm tra lại thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhân viên: " + ex.Message);
            }
        }

       
        private void BtnXoaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = string.Empty;
                if (!string.IsNullOrEmpty(txtMaNV.Text))
                {
                    maNV = txtMaNV.Text;
                }
                else if (dgvNhanVien.CurrentRow != null)
                {
                    maNV = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa hoặc nhập mã nhân viên.");
                    return;
                }
                bool isDeleted = nhanVienBLL.DeleteEmployee(maNV);

                if (isDeleted)
                {
                    loadDSNhanVien();
                    MessageBox.Show("Nhân viên đã được xóa thành công.");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        private void BtnThemNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                string maNhanVien = txtMaNV.Text; // Hàm tự động tạo mã nhân viên
                string hoTen = txtHoTen.Text;
                string chucVu = cbbChucVu.SelectedValue?.ToString();


                // Sử dụng DateTimePicker để lấy ngày sinh, ngày tạo, và ngày cập nhật
                DateTime ngaySinh = dTPNgaySinh.Value;
                DateTime ngayTao = dTPNgayTao.Value;
                DateTime ngayCapNhat = dTPNgayCapNhat.Value;

                string gioiTinh = txtGioiTinh.Text;
                string soDienThoai = txtSoDienThoai.Text;
                string email = txtEmail.Text;
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string hinhAnh = txtHinhAnh.Text;
           
                string diaChi = txtDiaChi.Text;

                // Kiểm tra xem mã nhân viên đã tồn tại chưa
                string maDaCo = nhanVienBLL.GetEmployeeByCode(maNhanVien);
                if (maDaCo != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }

                // Tạo đối tượng NhanVien mới
                NhanVien newEmployee = new NhanVien
                {
                    MaNhanVien = maNhanVien,
                    HoTen = hoTen,
                    ChucVu = chucVu,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    SoDienThoai = soDienThoai,
                    Email = email,
                    TaiKhoan = taiKhoan,
                    MatKhau = matKhau,
                    HinhAnh = hinhAnh,
                    TrangThai = true,
                    NgayTao = ngayTao,
                    NgayCapNhat = ngayCapNhat,
                    DiaChi = diaChi
                };

                // Gọi phương thức thêm nhân viên
                bool isSuccess = nhanVienBLL.AddNhanVien(newEmployee);

                if (isSuccess)
                {
                    MessageBox.Show("Nhân viên đã được thêm thành công!");
                    loadDSNhanVien(); // Hàm tải lại danh sách nhân viên vào DataGridView
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm nhân viên. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void Btn_timDK_Click(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = null;

            bool tinhTrangDuocChon = cboTrangThai.SelectedItem.ToString() == "True";

            var danhSachNhanVien = nhanVienBLL.SearchNhanVienByTinhTrang(tinhTrangDuocChon);

            dgvNhanVien.DataSource = danhSachNhanVien;
        }


        private void Btn_clear_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtHoTen.Clear();
            loadComBoBoxChucVu();
            dTPNgaySinh.Value = DateTime.Now;
            txtGioiTinh.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
            txtHinhAnh.Clear();
            txtTrangThai.Clear();
            dTPNgayTao.Value = DateTime.Now;
            dTPNgayCapNhat.Value = DateTime.Now;
            txtDiaChi.Clear();
            txtMaNV.Focus();
            txtMaNV.Enabled = true;
        }

        private void Btn_load_Click(object sender, EventArgs e)
        {
            loadDSNhanVien();
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            string search = txt_timNhanVien.Text;
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm");
            }
            List<NhanVien> dsNhanVien = nhanVienBLL.SearchNhanVien(search);
            if (dsNhanVien != null)
            {
                dgvNhanVien.DataSource = dsNhanVien;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào");
                loadDSNhanVien();
            }
        }

        private void DgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvNhanVien.CurrentRow;
                txtMaNV.Text = currentRow.Cells["MaNhanVien"].Value.ToString();
                txtHoTen.Text = currentRow.Cells["HoTen"].Value.ToString();
                txtGioiTinh.Text = currentRow.Cells["GioiTinh"].Value.ToString();
                txtSoDienThoai.Text = currentRow.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = currentRow.Cells["Email"].Value.ToString();
                dTPNgayCapNhat.Value = Convert.ToDateTime(currentRow.Cells["NgayCapNhat"].Value);
                
                dTPNgaySinh.Value = Convert.ToDateTime(currentRow.Cells["NgaySinh"].Value);
                dTPNgayTao.Value = Convert.ToDateTime(currentRow.Cells["NgayTao"].Value);
                txtTaiKhoan.Text = currentRow.Cells["TaiKhoan"].Value.ToString();
                txtMatKhau.Text = currentRow.Cells["MatKhau"].Value.ToString();
                txtDiaChi.Text = currentRow.Cells["DiaChi"].Value.ToString();
                cbbChucVu.Text = currentRow.Cells["ChucVu"].Value.ToString();
                txtHinhAnh.Text = currentRow.Cells["HinhAnh"].Value.ToString();
                string imagePath = txtHinhAnh.Text;
                if (!string.IsNullOrEmpty(imagePath))
                {
                    LoadImageToPictureBox(imagePath);
                }
                else
                {
                    img_NhanVien.Image = null;
                }

                string trangThai = currentRow.Cells["TrangThai"].Value?.ToString();
                txtTrangThai.Text = string.IsNullOrEmpty(trangThai) ? "Không xác định" : (trangThai == "True" ? "Hoạt động" : "Không hoạt động");
            }
            else
            {
                Console.Write("Không có dòng nào được chọn.");
            }
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
                    img_NhanVien.Image = Image.FromFile(resourcePath);
                    img_NhanVien.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    img_NhanVien.Image = Properties.Resources.avatar;
                    Console.WriteLine("Ảnh không tồn tại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Frm_quanLyNhanVien_Load(object sender, EventArgs e)
        {
           loadDSNhanVien();
           loadComBoBoxChucVu();
     
        }

        private void AddButtonPaintEvent()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint; // Gán sự kiện Paint cho mỗi nút
                }
            }
        }
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Pen pen = new Pen(Color.Navy, 1); // Màu sắc và độ dày viền
            e.Graphics.DrawRectangle(pen, 0, 0, btn.Width - 1, btn.Height - 1);
        }

        private void AddButtonPaintEventRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint;
                    button.MouseEnter += Button_MouseEnter;  // Thêm sự kiện hover vào nút
                    button.MouseLeave += Button_MouseLeave; // Thêm sự kiện rời chuột khỏi nút
                }
                else if (control.HasChildren)
                {
                    AddButtonPaintEventRecursive(control); // Đệ quy vào các container con
                }
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control; // Đặt lại màu nền mặc định khi rời chuột
            btn.ForeColor = Color.Black; // Đặt lại màu chữ mặc định nếu cần
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Navy; // Đổi màu nền khi chuột vào
            btn.ForeColor = Color.White; // Đổi màu chữ nếu cần
        }
       




        private void loadDSNhanVien()
        {
            dgvNhanVien.DataSource = null;
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();
                if (dsNhanVien != null)
                {
                    dgvNhanVien.DataSource = dsNhanVien;
                    dgvNhanVien.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                    dgvNhanVien.Columns["HoTen"].HeaderText = "Tên Nhân Viên";
                    dgvNhanVien.Columns["ChucVu"].HeaderText = "Chức Vụ";
                   
                    dgvNhanVien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới Tính";
                    dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số Điện Thoại";
                    dgvNhanVien.Columns["Email"].HeaderText = "Email";
                    dgvNhanVien.Columns["TaiKhoan"].HeaderText = "Tài Khoản";

                    //dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                    dgvNhanVien.Columns["MatKhau"].Visible = false;


                    //dgvNhanVien.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
                    dgvNhanVien.Columns["HinhAnh"].Visible = false;
                    dgvNhanVien.Columns["TrangThai"].HeaderText = "Trạng Thái";
                  
                    //dgvNhanVien.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                    dgvNhanVien.Columns["NgayTao"].Visible = false;


                    //dgvNhanVien.Columns["NgayCapNhat"].HeaderText = "Ngày Cập Nhật";
                    dgvNhanVien.Columns["NgayCapNhat"].Visible = false;


                   // dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNhanVien.Columns["DiaChi"].Visible = false;
                    foreach (DataGridViewColumn column in dgvNhanVien.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; // Căn giữa tiêu đề
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold); // Đặt kiểu chữ cho tiêu đề (tuỳ chọn)
                    }
                    foreach (DataGridViewRow row in dgvNhanVien.Rows)
                    {
                        bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                        if (!trangThai)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                    dgvNhanVien.RowPostPaint += dgv_RowPostPaint;
               }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào.");
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

        //private void loadComBoBoxChucVu()
        //{
        //    try
        //    {
        //        List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();
        //        if (dsNhanVien != null && dsNhanVien.Count > 0)
        //        {
        //            cbbChucVu.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
        //            cbbChucVu.DataSource = dsNhanVien;
        //            cbbChucVu.ValueMember = "MaNhanVien";
        //            cbbChucVu.DisplayMember = "ChucVu";
        //        }
        //        else
        //        {
        //            MessageBox.Show("Không có chức vụ nào.");
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Lỗi khi tải danh sách dịch vụ.");
        //    }
        //}
        private void loadComBoBoxChucVu()
        {
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();

                // Lọc danh sách chức vụ duy nhất
                var uniqueChucVuList = dsNhanVien
                    .Select(nv => nv.ChucVu)
                    .Distinct()
                    .ToList();

                if (uniqueChucVuList != null && uniqueChucVuList.Count > 0)
                {
                    cbbChucVu.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu

                    // Gán lại DataSource với danh sách chức vụ duy nhất
                    cbbChucVu.DataSource = uniqueChucVuList;
                    cbbChucVu.DisplayMember = "ChucVu"; // Hiển thị chức vụ
                }
                else
                {
                    MessageBox.Show("Không có chức vụ nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách chức vụ: " + ex.Message);
            }
        }


        private void loadComBoBoxTrangThai()
        {
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();
                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    cbbChucVu.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbbChucVu.DataSource = dsNhanVien;
                    cbbChucVu.ValueMember = "MaNhanVien";
                    cbbChucVu.DisplayMember = "TrangThai";
                }
                else
                {
                    MessageBox.Show("Không có chức vụ nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ.");
            }
        }



        private void frm_quanLyNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cboTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaNhanVien_Click_1(object sender, EventArgs e)
        {

        }

        private void dTPNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dTPNgayTao_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
