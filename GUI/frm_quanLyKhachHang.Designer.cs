namespace GUI
{
    partial class frm_quanLyKhachHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_dsKhachHang = new System.Windows.Forms.DataGridView();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTichLuy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaytao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCapNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gioitinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_MaKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TenKH = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_SoDienThoai = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_TrangThai = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.dtp_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.pb_img = new System.Windows.Forms.PictureBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_AnhDaiDien = new System.Windows.Forms.Label();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.cb_GioiTinh = new System.Windows.Forms.CheckBox();
            this.cb_Khoa = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_DangKy = new System.Windows.Forms.CheckBox();
            this.lbl_DiemTichLuyValue = new System.Windows.Forms.Label();
            this.lbl_NgayCapNhatValue = new System.Windows.Forms.Label();
            this.lbl_NgayTaoValue = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_CapNhat = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_ChonHinhAnh = new System.Windows.Forms.Button();
            this.lbl_DiaChi = new System.Windows.Forms.Label();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.btn_Timkiem = new System.Windows.Forms.Button();
            this.btn_TaiLai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_dsKhachHang
            // 
            this.dgv_dsKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKhachHang,
            this.TenKhachHang,
            this.NgaySinh,
            this.DiemTichLuy,
            this.SoDienThoai,
            this.Email,
            this.TaiKhoan,
            this.MatKhau,
            this.Ngaytao,
            this.NgayCapNhat,
            this.Gioitinh,
            this.Image,
            this.TrangThai,
            this.ThanhVien});
            this.dgv_dsKhachHang.Location = new System.Drawing.Point(12, 528);
            this.dgv_dsKhachHang.MultiSelect = false;
            this.dgv_dsKhachHang.Name = "dgv_dsKhachHang";
            this.dgv_dsKhachHang.RowHeadersWidth = 51;
            this.dgv_dsKhachHang.RowTemplate.Height = 24;
            this.dgv_dsKhachHang.Size = new System.Drawing.Size(1606, 515);
            this.dgv_dsKhachHang.TabIndex = 1;
            this.dgv_dsKhachHang.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_dsKhachHang_CellFormatting);
            this.dgv_dsKhachHang.SelectionChanged += new System.EventHandler(this.dgv_dsKhachHang_SelectionChanged);
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "Mã khách hàng";
            this.MaKhachHang.MinimumWidth = 6;
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.Width = 125;
            // 
            // TenKhachHang
            // 
            this.TenKhachHang.DataPropertyName = "TenKhachHang";
            this.TenKhachHang.HeaderText = "Tên khách hàng";
            this.TenKhachHang.MinimumWidth = 6;
            this.TenKhachHang.Name = "TenKhachHang";
            this.TenKhachHang.Width = 125;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.Width = 125;
            // 
            // DiemTichLuy
            // 
            this.DiemTichLuy.DataPropertyName = "DiemTichLuy";
            this.DiemTichLuy.HeaderText = "Điểm tích lũy";
            this.DiemTichLuy.MinimumWidth = 6;
            this.DiemTichLuy.Name = "DiemTichLuy";
            this.DiemTichLuy.Width = 125;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.MinimumWidth = 6;
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Emai";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài khoản";
            this.TaiKhoan.MinimumWidth = 6;
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.Width = 125;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật khẩu";
            this.MatKhau.MinimumWidth = 6;
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Width = 125;
            // 
            // Ngaytao
            // 
            this.Ngaytao.DataPropertyName = "NgayTao";
            this.Ngaytao.HeaderText = "Ngày tạo";
            this.Ngaytao.MinimumWidth = 6;
            this.Ngaytao.Name = "Ngaytao";
            this.Ngaytao.Width = 125;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.DataPropertyName = "NgayCapNhat";
            this.NgayCapNhat.HeaderText = "Ngày cập nhật";
            this.NgayCapNhat.MinimumWidth = 6;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Width = 125;
            // 
            // Gioitinh
            // 
            this.Gioitinh.DataPropertyName = "GioiTinh";
            this.Gioitinh.HeaderText = "Giới tính";
            this.Gioitinh.MinimumWidth = 6;
            this.Gioitinh.Name = "Gioitinh";
            this.Gioitinh.Width = 125;
            // 
            // Image
            // 
            this.Image.DataPropertyName = "HinhAnh";
            this.Image.HeaderText = "Hình ảnh";
            this.Image.MinimumWidth = 6;
            this.Image.Name = "Image";
            this.Image.Visible = false;
            this.Image.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // ThanhVien
            // 
            this.ThanhVien.DataPropertyName = "ThanhVien";
            this.ThanhVien.HeaderText = "Thành viên";
            this.ThanhVien.MinimumWidth = 6;
            this.ThanhVien.Name = "ThanhVien";
            this.ThanhVien.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1628, 100);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(693, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý khách hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã khách hàng";
            // 
            // txt_MaKH
            // 
            this.txt_MaKH.Location = new System.Drawing.Point(147, 155);
            this.txt_MaKH.Name = "txt_MaKH";
            this.txt_MaKH.ReadOnly = true;
            this.txt_MaKH.Size = new System.Drawing.Size(200, 22);
            this.txt_MaKH.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tên khách hàng";
            // 
            // txt_TenKH
            // 
            this.txt_TenKH.Location = new System.Drawing.Point(147, 236);
            this.txt_TenKH.Name = "txt_TenKH";
            this.txt_TenKH.Size = new System.Drawing.Size(200, 22);
            this.txt_TenKH.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(805, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giới tính";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số điện thoại";
            // 
            // txt_SoDienThoai
            // 
            this.txt_SoDienThoai.Location = new System.Drawing.Point(147, 403);
            this.txt_SoDienThoai.Name = "txt_SoDienThoai";
            this.txt_SoDienThoai.Size = new System.Drawing.Size(213, 22);
            this.txt_SoDienThoai.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(420, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Email";
            // 
            // lbl_TrangThai
            // 
            this.lbl_TrangThai.AutoSize = true;
            this.lbl_TrangThai.Location = new System.Drawing.Point(792, 167);
            this.lbl_TrangThai.Name = "lbl_TrangThai";
            this.lbl_TrangThai.Size = new System.Drawing.Size(67, 16);
            this.lbl_TrangThai.TabIndex = 13;
            this.lbl_TrangThai.Text = "Trạng thái";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tài khoản";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(420, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "Mật khẩu";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(537, 403);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(224, 22);
            this.txt_Email.TabIndex = 16;
            // 
            // dtp_NgaySinh
            // 
            this.dtp_NgaySinh.Location = new System.Drawing.Point(147, 317);
            this.dtp_NgaySinh.Name = "dtp_NgaySinh";
            this.dtp_NgaySinh.Size = new System.Drawing.Size(200, 22);
            this.dtp_NgaySinh.TabIndex = 18;
            // 
            // pb_img
            // 
            this.pb_img.Location = new System.Drawing.Point(1355, 206);
            this.pb_img.Name = "pb_img";
            this.pb_img.Size = new System.Drawing.Size(263, 216);
            this.pb_img.TabIndex = 19;
            this.pb_img.TabStop = false;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Location = new System.Drawing.Point(537, 320);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(224, 22);
            this.txt_MatKhau.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(420, 164);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Điểm tích lũy";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1023, 167);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Ngày cập nhật ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1023, 242);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "Ngày tạo";
            // 
            // lbl_AnhDaiDien
            // 
            this.lbl_AnhDaiDien.AutoSize = true;
            this.lbl_AnhDaiDien.Location = new System.Drawing.Point(1391, 170);
            this.lbl_AnhDaiDien.Name = "lbl_AnhDaiDien";
            this.lbl_AnhDaiDien.Size = new System.Drawing.Size(81, 16);
            this.lbl_AnhDaiDien.TabIndex = 24;
            this.lbl_AnhDaiDien.Text = "Ảnh đại diện";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Location = new System.Drawing.Point(537, 236);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(224, 22);
            this.txt_TaiKhoan.TabIndex = 26;
            // 
            // cb_GioiTinh
            // 
            this.cb_GioiTinh.AutoSize = true;
            this.cb_GioiTinh.Location = new System.Drawing.Point(905, 304);
            this.cb_GioiTinh.Name = "cb_GioiTinh";
            this.cb_GioiTinh.Size = new System.Drawing.Size(58, 20);
            this.cb_GioiTinh.TabIndex = 27;
            this.cb_GioiTinh.Text = "Nam";
            this.cb_GioiTinh.UseVisualStyleBackColor = true;
            // 
            // cb_Khoa
            // 
            this.cb_Khoa.AutoSize = true;
            this.cb_Khoa.Location = new System.Drawing.Point(903, 162);
            this.cb_Khoa.Name = "cb_Khoa";
            this.cb_Khoa.Size = new System.Drawing.Size(92, 20);
            this.cb_Khoa.TabIndex = 29;
            this.cb_Khoa.Text = "Hoạt động";
            this.cb_Khoa.UseVisualStyleBackColor = true;
            this.cb_Khoa.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(786, 242);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Thành viên";
            // 
            // cb_DangKy
            // 
            this.cb_DangKy.AutoSize = true;
            this.cb_DangKy.Location = new System.Drawing.Point(903, 238);
            this.cb_DangKy.Name = "cb_DangKy";
            this.cb_DangKy.Size = new System.Drawing.Size(78, 20);
            this.cb_DangKy.TabIndex = 31;
            this.cb_DangKy.Text = "Đăng ký";
            this.cb_DangKy.UseVisualStyleBackColor = true;
            // 
            // lbl_DiemTichLuyValue
            // 
            this.lbl_DiemTichLuyValue.AutoSize = true;
            this.lbl_DiemTichLuyValue.Location = new System.Drawing.Point(534, 163);
            this.lbl_DiemTichLuyValue.Name = "lbl_DiemTichLuyValue";
            this.lbl_DiemTichLuyValue.Size = new System.Drawing.Size(97, 16);
            this.lbl_DiemTichLuyValue.TabIndex = 32;
            this.lbl_DiemTichLuyValue.Text = "Ngày cập nhật ";
            // 
            // lbl_NgayCapNhatValue
            // 
            this.lbl_NgayCapNhatValue.AutoSize = true;
            this.lbl_NgayCapNhatValue.Location = new System.Drawing.Point(1168, 170);
            this.lbl_NgayCapNhatValue.Name = "lbl_NgayCapNhatValue";
            this.lbl_NgayCapNhatValue.Size = new System.Drawing.Size(97, 16);
            this.lbl_NgayCapNhatValue.TabIndex = 33;
            this.lbl_NgayCapNhatValue.Text = "Ngày cập nhật ";
            // 
            // lbl_NgayTaoValue
            // 
            this.lbl_NgayTaoValue.AutoSize = true;
            this.lbl_NgayTaoValue.Location = new System.Drawing.Point(1168, 236);
            this.lbl_NgayTaoValue.Name = "lbl_NgayTaoValue";
            this.lbl_NgayTaoValue.Size = new System.Drawing.Size(97, 16);
            this.lbl_NgayTaoValue.TabIndex = 34;
            this.lbl_NgayTaoValue.Text = "Ngày cập nhật ";
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(537, 467);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(109, 55);
            this.btn_Them.TabIndex = 35;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_CapNhat
            // 
            this.btn_CapNhat.Location = new System.Drawing.Point(713, 467);
            this.btn_CapNhat.Name = "btn_CapNhat";
            this.btn_CapNhat.Size = new System.Drawing.Size(103, 55);
            this.btn_CapNhat.TabIndex = 36;
            this.btn_CapNhat.Text = "Cập nhật";
            this.btn_CapNhat.UseVisualStyleBackColor = true;
            this.btn_CapNhat.Click += new System.EventHandler(this.btn_CapNhat_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(879, 467);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(102, 55);
            this.btn_Xoa.TabIndex = 37;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_ChonHinhAnh
            // 
            this.btn_ChonHinhAnh.Location = new System.Drawing.Point(1497, 157);
            this.btn_ChonHinhAnh.Name = "btn_ChonHinhAnh";
            this.btn_ChonHinhAnh.Size = new System.Drawing.Size(109, 43);
            this.btn_ChonHinhAnh.TabIndex = 38;
            this.btn_ChonHinhAnh.Text = "Chọn Hình Ảnh";
            this.btn_ChonHinhAnh.UseVisualStyleBackColor = true;
            this.btn_ChonHinhAnh.Click += new System.EventHandler(this.btn_ChonHinhAnh_Click);
            // 
            // lbl_DiaChi
            // 
            this.lbl_DiaChi.AutoSize = true;
            this.lbl_DiaChi.Location = new System.Drawing.Point(1023, 305);
            this.lbl_DiaChi.Name = "lbl_DiaChi";
            this.lbl_DiaChi.Size = new System.Drawing.Size(47, 16);
            this.lbl_DiaChi.TabIndex = 39;
            this.lbl_DiaChi.Text = "Địa chỉ";
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(1090, 298);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(213, 22);
            this.txt_DiaChi.TabIndex = 40;
            // 
            // btn_Timkiem
            // 
            this.btn_Timkiem.Location = new System.Drawing.Point(1042, 467);
            this.btn_Timkiem.Name = "btn_Timkiem";
            this.btn_Timkiem.Size = new System.Drawing.Size(102, 55);
            this.btn_Timkiem.TabIndex = 41;
            this.btn_Timkiem.Text = "Tìm kiếm";
            this.btn_Timkiem.UseVisualStyleBackColor = true;
            this.btn_Timkiem.Click += new System.EventHandler(this.btn_Timkiem_Click);
            // 
            // btn_TaiLai
            // 
            this.btn_TaiLai.Location = new System.Drawing.Point(1190, 467);
            this.btn_TaiLai.Name = "btn_TaiLai";
            this.btn_TaiLai.Size = new System.Drawing.Size(102, 55);
            this.btn_TaiLai.TabIndex = 42;
            this.btn_TaiLai.Text = "Làm mới";
            this.btn_TaiLai.UseVisualStyleBackColor = true;
            this.btn_TaiLai.Click += new System.EventHandler(this.btn_TaiLai_Click);
            // 
            // frm_quanLyKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1653, 1055);
            this.Controls.Add(this.btn_TaiLai);
            this.Controls.Add(this.btn_Timkiem);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.lbl_DiaChi);
            this.Controls.Add(this.btn_ChonHinhAnh);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_CapNhat);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.lbl_NgayTaoValue);
            this.Controls.Add(this.lbl_NgayCapNhatValue);
            this.Controls.Add(this.lbl_DiemTichLuyValue);
            this.Controls.Add(this.cb_DangKy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_Khoa);
            this.Controls.Add(this.cb_GioiTinh);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.lbl_AnhDaiDien);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.pb_img);
            this.Controls.Add(this.dtp_NgaySinh);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_TrangThai);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_SoDienThoai);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_TenKH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_MaKH);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_dsKhachHang);
            this.Name = "frm_quanLyKhachHang";
            this.Text = "frm_quanLyKhachHang";
            this.Load += new System.EventHandler(this.frm_quanLyKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsKhachHang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_dsKhachHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_MaKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TenKH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_SoDienThoai;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_TrangThai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.DateTimePicker dtp_NgaySinh;
        private System.Windows.Forms.PictureBox pb_img;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_AnhDaiDien;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.CheckBox cb_GioiTinh;
        private System.Windows.Forms.CheckBox cb_Khoa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_DangKy;
        private System.Windows.Forms.Label lbl_DiemTichLuyValue;
        private System.Windows.Forms.Label lbl_NgayCapNhatValue;
        private System.Windows.Forms.Label lbl_NgayTaoValue;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_CapNhat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_ChonHinhAnh;
        private System.Windows.Forms.Label lbl_DiaChi;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTichLuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaytao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gioitinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhVien;
        private System.Windows.Forms.Button btn_Timkiem;
        private System.Windows.Forms.Button btn_TaiLai;
    }
}