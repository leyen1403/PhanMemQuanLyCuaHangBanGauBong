namespace GUI
{
    partial class frm_quanLyDonDatHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.cbbNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cbbTrangThai = new System.Windows.Forms.ComboBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.cbbLuaChonHienThi = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachDonDatHang = new System.Windows.Forms.DataGridView();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietDDH = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSoLuongYeuCau = new System.Windows.Forms.NumericUpDown();
            this.txtSoLuongCungCap = new System.Windows.Forms.NumericUpDown();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.cbbTrangThaiCTDDH = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMau = new System.Windows.Forms.TextBox();
            this.txtKichThuoc = new System.Windows.Forms.TextBox();
            this.txtTenLoai = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtSoLuongThieu = new System.Windows.Forms.TextBox();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonDatHang)).BeginInit();
            this.groupbox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDDH)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongCungCap)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1491, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "QUẢN LÝ ĐƠN ĐẶT HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Controls.Add(this.dtpDenNgay);
            this.groupBox1.Controls.Add(this.dtpTuNgay);
            this.groupBox1.Controls.Add(this.cbbNhaCungCap);
            this.groupBox1.Controls.Add(this.cbbTrangThai);
            this.groupBox1.Controls.Add(this.cbbNhanVien);
            this.groupBox1.Controls.Add(this.cbbLuaChonHienThi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 407);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm thông tin đơn đặt hàng";
            // 
            // btnTim
            // 
            this.btnTim.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(256, 340);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(75, 43);
            this.btnTim.TabIndex = 4;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(198, 183);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(382, 27);
            this.dtpDenNgay.TabIndex = 3;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(198, 132);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(382, 27);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // cbbNhaCungCap
            // 
            this.cbbNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhaCungCap.FormattingEnabled = true;
            this.cbbNhaCungCap.Location = new System.Drawing.Point(198, 285);
            this.cbbNhaCungCap.Name = "cbbNhaCungCap";
            this.cbbNhaCungCap.Size = new System.Drawing.Size(382, 27);
            this.cbbNhaCungCap.TabIndex = 2;
            // 
            // cbbTrangThai
            // 
            this.cbbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrangThai.FormattingEnabled = true;
            this.cbbTrangThai.Location = new System.Drawing.Point(198, 234);
            this.cbbTrangThai.Name = "cbbTrangThai";
            this.cbbTrangThai.Size = new System.Drawing.Size(382, 27);
            this.cbbTrangThai.TabIndex = 2;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(198, 81);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(382, 27);
            this.cbbNhanVien.TabIndex = 2;
            // 
            // cbbLuaChonHienThi
            // 
            this.cbbLuaChonHienThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLuaChonHienThi.FormattingEnabled = true;
            this.cbbLuaChonHienThi.Location = new System.Drawing.Point(198, 30);
            this.cbbLuaChonHienThi.Name = "cbbLuaChonHienThi";
            this.cbbLuaChonHienThi.Size = new System.Drawing.Size(382, 27);
            this.cbbLuaChonHienThi.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 293);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "Nhà cung cấp:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Trạng thái:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Đến ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Từ ngày:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lựa chọn hiển thị:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvDanhSachDonDatHang);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(604, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(875, 407);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đơn đặt hàng";
            // 
            // dgvDanhSachDonDatHang
            // 
            this.dgvDanhSachDonDatHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachDonDatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachDonDatHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachDonDatHang.Location = new System.Drawing.Point(3, 23);
            this.dgvDanhSachDonDatHang.Name = "dgvDanhSachDonDatHang";
            this.dgvDanhSachDonDatHang.ReadOnly = true;
            this.dgvDanhSachDonDatHang.Size = new System.Drawing.Size(869, 381);
            this.dgvDanhSachDonDatHang.TabIndex = 0;
            // 
            // groupbox3
            // 
            this.groupbox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupbox3.Controls.Add(this.dgvChiTietDDH);
            this.groupbox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox3.Location = new System.Drawing.Point(604, 461);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(872, 542);
            this.groupbox3.TabIndex = 5;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "Chi tiết đơn đặt hàng";
            // 
            // dgvChiTietDDH
            // 
            this.dgvChiTietDDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietDDH.Location = new System.Drawing.Point(3, 23);
            this.dgvChiTietDDH.Name = "dgvChiTietDDH";
            this.dgvChiTietDDH.ReadOnly = true;
            this.dgvChiTietDDH.Size = new System.Drawing.Size(866, 516);
            this.dgvChiTietDDH.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.txtSoLuongYeuCau);
            this.groupBox4.Controls.Add(this.txtSoLuongCungCap);
            this.groupBox4.Controls.Add(this.btnCapNhat);
            this.groupBox4.Controls.Add(this.cbbTrangThaiCTDDH);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.txtMau);
            this.groupBox4.Controls.Add(this.txtKichThuoc);
            this.groupBox4.Controls.Add(this.txtTenLoai);
            this.groupBox4.Controls.Add(this.txtTongTien);
            this.groupBox4.Controls.Add(this.txtThanhTien);
            this.groupBox4.Controls.Add(this.txtDonGia);
            this.groupBox4.Controls.Add(this.txtSoLuongThieu);
            this.groupBox4.Controls.Add(this.txtTenSP);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 464);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(586, 536);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết sản phẩm";
            // 
            // txtSoLuongYeuCau
            // 
            this.txtSoLuongYeuCau.Location = new System.Drawing.Point(154, 202);
            this.txtSoLuongYeuCau.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSoLuongYeuCau.Name = "txtSoLuongYeuCau";
            this.txtSoLuongYeuCau.Size = new System.Drawing.Size(289, 27);
            this.txtSoLuongYeuCau.TabIndex = 7;
            // 
            // txtSoLuongCungCap
            // 
            this.txtSoLuongCungCap.Location = new System.Drawing.Point(154, 261);
            this.txtSoLuongCungCap.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtSoLuongCungCap.Name = "txtSoLuongCungCap";
            this.txtSoLuongCungCap.Size = new System.Drawing.Size(289, 27);
            this.txtSoLuongCungCap.TabIndex = 7;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(464, 26);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(111, 41);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.UseVisualStyleBackColor = true;
            // 
            // cbbTrangThaiCTDDH
            // 
            this.cbbTrangThaiCTDDH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTrangThaiCTDDH.FormattingEnabled = true;
            this.cbbTrangThaiCTDDH.Location = new System.Drawing.Point(193, 26);
            this.cbbTrangThaiCTDDH.Name = "cbbTrangThaiCTDDH";
            this.cbbTrangThaiCTDDH.Size = new System.Drawing.Size(250, 27);
            this.cbbTrangThaiCTDDH.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(187, 19);
            this.label18.TabIndex = 5;
            this.label18.Text = "Trạng thái đơn đặt hàng:";
            // 
            // txtMau
            // 
            this.txtMau.Location = new System.Drawing.Point(492, 143);
            this.txtMau.Name = "txtMau";
            this.txtMau.ReadOnly = true;
            this.txtMau.Size = new System.Drawing.Size(83, 27);
            this.txtMau.TabIndex = 3;
            // 
            // txtKichThuoc
            // 
            this.txtKichThuoc.Location = new System.Drawing.Point(294, 143);
            this.txtKichThuoc.Name = "txtKichThuoc";
            this.txtKichThuoc.ReadOnly = true;
            this.txtKichThuoc.Size = new System.Drawing.Size(142, 27);
            this.txtKichThuoc.TabIndex = 3;
            // 
            // txtTenLoai
            // 
            this.txtTenLoai.Location = new System.Drawing.Point(51, 143);
            this.txtTenLoai.Name = "txtTenLoai";
            this.txtTenLoai.ReadOnly = true;
            this.txtTenLoai.Size = new System.Drawing.Size(142, 27);
            this.txtTenLoai.TabIndex = 3;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(154, 497);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(289, 27);
            this.txtTongTien.TabIndex = 2;
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Location = new System.Drawing.Point(154, 438);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.ReadOnly = true;
            this.txtThanhTien.Size = new System.Drawing.Size(289, 27);
            this.txtThanhTien.TabIndex = 2;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(154, 379);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(289, 27);
            this.txtDonGia.TabIndex = 2;
            // 
            // txtSoLuongThieu
            // 
            this.txtSoLuongThieu.Location = new System.Drawing.Point(154, 320);
            this.txtSoLuongThieu.Name = "txtSoLuongThieu";
            this.txtSoLuongThieu.ReadOnly = true;
            this.txtSoLuongThieu.Size = new System.Drawing.Size(289, 27);
            this.txtSoLuongThieu.TabIndex = 2;
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(154, 84);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.ReadOnly = true;
            this.txtTenSP.Size = new System.Drawing.Size(289, 27);
            this.txtTenSP.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1, 387);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 19);
            this.label13.TabIndex = 1;
            this.label13.Text = "Đơn giá:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 505);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 19);
            this.label14.TabIndex = 1;
            this.label14.Text = "Tổng tiền:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 446);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 19);
            this.label12.TabIndex = 1;
            this.label12.Text = "Thành tiền:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 19);
            this.label11.TabIndex = 1;
            this.label11.Text = "Số lượng thiếu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 19);
            this.label10.TabIndex = 1;
            this.label10.Text = "Số lượng cung cấp:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(199, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 19);
            this.label17.TabIndex = 1;
            this.label17.Text = "Kích thước:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1, 151);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 19);
            this.label16.TabIndex = 1;
            this.label16.Text = "Loại:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(442, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 19);
            this.label15.TabIndex = 1;
            this.label15.Text = "Màu:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Số lượng yêu cầu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tên sản phẩm:";
            // 
            // frm_quanLyDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 1015);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupbox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_quanLyDonDatHang";
            this.Text = "frm_quanLyDonDatHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachDonDatHang)).EndInit();
            this.groupbox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietDDH)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongCungCap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.ComboBox cbbLuaChonHienThi;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.ComboBox cbbNhaCungCap;
        private System.Windows.Forms.ComboBox cbbTrangThai;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDanhSachDonDatHang;
        private System.Windows.Forms.GroupBox groupbox3;
        private System.Windows.Forms.DataGridView dgvChiTietDDH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMau;
        private System.Windows.Forms.TextBox txtKichThuoc;
        private System.Windows.Forms.TextBox txtTenLoai;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtSoLuongThieu;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbbTrangThaiCTDDH;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.NumericUpDown txtSoLuongYeuCau;
        private System.Windows.Forms.NumericUpDown txtSoLuongCungCap;
    }
}