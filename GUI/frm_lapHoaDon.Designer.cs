namespace GUI
{
    partial class frm_lapHoaDon
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
            this.label2 = new System.Windows.Forms.Label();
            this.dsSanPham = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_SLTon = new System.Windows.Forms.TextBox();
            this.txt_soLuong = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_giaBan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_kichThuoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_mauSac = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_ngayHT = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbo_hinhThucThanhToan = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbo_giaoHang = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.rdo_diaChiMoi = new System.Windows.Forms.RadioButton();
            this.rdo_diaChiHienTai = new System.Windows.Forms.RadioButton();
            this.cbo_loaiKhachHang = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label_xuaHD = new System.Windows.Forms.Label();
            this.chkSuDungDiemTichLuy = new System.Windows.Forms.CheckBox();
            this.txt_diemDung = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_diemTichLuy = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_tongTien = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_TongSL = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_diaChi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_soDienThoai = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_tenKhachHang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_maKhachHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbo_loai = new System.Windows.Forms.ComboBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_trangDau = new System.Windows.Forms.Button();
            this.btn_troLai = new System.Windows.Forms.Button();
            this.btn_trangCuoi = new System.Windows.Forms.Button();
            this.btn_keTiep = new System.Windows.Forms.Button();
            this.txt_tenSanPham = new System.Windows.Forms.ComboBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_timKhachHang = new System.Windows.Forms.Button();
            this.btn_luuHoaDon = new System.Windows.Forms.Button();
            this.btn_inHoaDon = new System.Windows.Forms.Button();
            this.btn_addCart = new System.Windows.Forms.Button();
            this.btn_timSanPham = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soLuong)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.groupBox3.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(1536, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "LẬP HOÁ ĐƠN BÁN HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(362, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Danh sách sản phẩm";
            // 
            // dsSanPham
            // 
            this.dsSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dsSanPham.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dsSanPham.Location = new System.Drawing.Point(10, 122);
            this.dsSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.dsSanPham.Name = "dsSanPham";
            this.dsSanPham.Size = new System.Drawing.Size(887, 449);
            this.dsSanPham.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txt_SLTon);
            this.groupBox1.Controls.Add(this.txt_soLuong);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.txt_giaBan);
            this.groupBox1.Controls.Add(this.btn_addCart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbo_kichThuoc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbo_mauSac);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 647);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(887, 84);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Navy;
            this.label21.Location = new System.Drawing.Point(489, 19);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 18);
            this.label21.TabIndex = 16;
            this.label21.Text = "Số lượng tồn :";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Navy;
            this.label15.Location = new System.Drawing.Point(345, 17);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 18);
            this.label15.TabIndex = 15;
            this.label15.Text = "Giá :";
            // 
            // txt_SLTon
            // 
            this.txt_SLTon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_SLTon.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_SLTon.Enabled = false;
            this.txt_SLTon.Location = new System.Drawing.Point(556, 48);
            this.txt_SLTon.Margin = new System.Windows.Forms.Padding(2);
            this.txt_SLTon.Name = "txt_SLTon";
            this.txt_SLTon.ReadOnly = true;
            this.txt_SLTon.Size = new System.Drawing.Size(104, 24);
            this.txt_SLTon.TabIndex = 14;
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_soLuong.Location = new System.Drawing.Point(730, 42);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.Size = new System.Drawing.Size(71, 24);
            this.txt_soLuong.TabIndex = 13;
            this.txt_soLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_soLuong_KeyPress);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Navy;
            this.label16.Location = new System.Drawing.Point(468, 55);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(33, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "VNĐ";
            // 
            // txt_giaBan
            // 
            this.txt_giaBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.txt_giaBan.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_giaBan.Location = new System.Drawing.Point(360, 44);
            this.txt_giaBan.Margin = new System.Windows.Forms.Padding(2);
            this.txt_giaBan.Name = "txt_giaBan";
            this.txt_giaBan.ReadOnly = true;
            this.txt_giaBan.Size = new System.Drawing.Size(104, 24);
            this.txt_giaBan.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(674, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nhập số lượng :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(182, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = " Kích thước :";
            // 
            // cbo_kichThuoc
            // 
            this.cbo_kichThuoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbo_kichThuoc.FormattingEnabled = true;
            this.cbo_kichThuoc.Location = new System.Drawing.Point(215, 40);
            this.cbo_kichThuoc.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_kichThuoc.Name = "cbo_kichThuoc";
            this.cbo_kichThuoc.Size = new System.Drawing.Size(115, 26);
            this.cbo_kichThuoc.TabIndex = 3;
            this.cbo_kichThuoc.SelectedIndexChanged += new System.EventHandler(this.cbo_kichThuoc_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(18, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Màu sắc :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-43, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 18);
            this.label3.TabIndex = 1;
            // 
            // cbo_mauSac
            // 
            this.cbo_mauSac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.cbo_mauSac.FormattingEnabled = true;
            this.cbo_mauSac.Location = new System.Drawing.Point(53, 40);
            this.cbo_mauSac.Margin = new System.Windows.Forms.Padding(2);
            this.cbo_mauSac.Name = "cbo_mauSac";
            this.cbo_mauSac.Size = new System.Drawing.Size(118, 26);
            this.cbo_mauSac.TabIndex = 0;
            this.cbo_mauSac.SelectedIndexChanged += new System.EventHandler(this.cbo_mauSac_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(1163, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Hoá đơn bán hàng";
            // 
            // label_ngayHT
            // 
            this.label_ngayHT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ngayHT.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ngayHT.Appearance.Options.UseFont = true;
            this.label_ngayHT.Location = new System.Drawing.Point(914, 104);
            this.label_ngayHT.Margin = new System.Windows.Forms.Padding(2);
            this.label_ngayHT.Name = "label_ngayHT";
            this.label_ngayHT.Size = new System.Drawing.Size(53, 14);
            this.label_ngayHT.TabIndex = 9;
            this.label_ngayHT.Text = "ngày giờ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Controls.Add(this.cbo_hinhThucThanhToan);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.cbo_giaoHang);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.rdo_diaChiMoi);
            this.groupBox2.Controls.Add(this.rdo_diaChiHienTai);
            this.groupBox2.Controls.Add(this.cbo_loaiKhachHang);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label_xuaHD);
            this.groupBox2.Controls.Add(this.chkSuDungDiemTichLuy);
            this.groupBox2.Controls.Add(this.txt_diemDung);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txt_diemTichLuy);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.btn_Clear);
            this.groupBox2.Controls.Add(this.btn_timKhachHang);
            this.groupBox2.Controls.Add(this.btn_luuHoaDon);
            this.groupBox2.Controls.Add(this.btn_inHoaDon);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_tongTien);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txt_TongSL);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txt_diaChi);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txt_soDienThoai);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txt_tenKhachHang);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txt_maKhachHang);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(914, 323);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(611, 523);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin hoá đơn";
            // 
            // cbo_hinhThucThanhToan
            // 
            this.cbo_hinhThucThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_hinhThucThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_hinhThucThanhToan.FormattingEnabled = true;
            this.cbo_hinhThucThanhToan.Location = new System.Drawing.Point(204, 414);
            this.cbo_hinhThucThanhToan.Name = "cbo_hinhThucThanhToan";
            this.cbo_hinhThucThanhToan.Size = new System.Drawing.Size(307, 26);
            this.cbo_hinhThucThanhToan.TabIndex = 40;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Navy;
            this.label23.Location = new System.Drawing.Point(17, 416);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(178, 20);
            this.label23.TabIndex = 39;
            this.label23.Text = "Hình thức thanh toán";
            // 
            // cbo_giaoHang
            // 
            this.cbo_giaoHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_giaoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_giaoHang.FormattingEnabled = true;
            this.cbo_giaoHang.Location = new System.Drawing.Point(206, 83);
            this.cbo_giaoHang.Name = "cbo_giaoHang";
            this.cbo_giaoHang.Size = new System.Drawing.Size(307, 26);
            this.cbo_giaoHang.TabIndex = 38;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Navy;
            this.label22.Location = new System.Drawing.Point(19, 83);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(170, 20);
            this.label22.TabIndex = 37;
            this.label22.Text = "Hình thức giao hàng";
            // 
            // rdo_diaChiMoi
            // 
            this.rdo_diaChiMoi.AutoSize = true;
            this.rdo_diaChiMoi.Location = new System.Drawing.Point(364, 247);
            this.rdo_diaChiMoi.Name = "rdo_diaChiMoi";
            this.rdo_diaChiMoi.Size = new System.Drawing.Size(100, 22);
            this.rdo_diaChiMoi.TabIndex = 36;
            this.rdo_diaChiMoi.TabStop = true;
            this.rdo_diaChiMoi.Text = "Địa chỉ mới";
            this.rdo_diaChiMoi.UseVisualStyleBackColor = true;
            // 
            // rdo_diaChiHienTai
            // 
            this.rdo_diaChiHienTai.AutoSize = true;
            this.rdo_diaChiHienTai.Location = new System.Drawing.Point(206, 247);
            this.rdo_diaChiHienTai.Name = "rdo_diaChiHienTai";
            this.rdo_diaChiHienTai.Size = new System.Drawing.Size(121, 22);
            this.rdo_diaChiHienTai.TabIndex = 35;
            this.rdo_diaChiHienTai.TabStop = true;
            this.rdo_diaChiHienTai.Text = "Địa chỉ hiện tại";
            this.rdo_diaChiHienTai.UseVisualStyleBackColor = true;
            // 
            // cbo_loaiKhachHang
            // 
            this.cbo_loaiKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_loaiKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_loaiKhachHang.FormattingEnabled = true;
            this.cbo_loaiKhachHang.Location = new System.Drawing.Point(206, 41);
            this.cbo_loaiKhachHang.Name = "cbo_loaiKhachHang";
            this.cbo_loaiKhachHang.Size = new System.Drawing.Size(307, 26);
            this.cbo_loaiKhachHang.TabIndex = 34;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Navy;
            this.label20.Location = new System.Drawing.Point(19, 41);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(182, 20);
            this.label20.TabIndex = 23;
            this.label20.Text = "Chọn loại khách hàng";
            // 
            // label_xuaHD
            // 
            this.label_xuaHD.AutoSize = true;
            this.label_xuaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_xuaHD.ForeColor = System.Drawing.Color.Navy;
            this.label_xuaHD.Location = new System.Drawing.Point(172, 369);
            this.label_xuaHD.Name = "label_xuaHD";
            this.label_xuaHD.Size = new System.Drawing.Size(0, 13);
            this.label_xuaHD.TabIndex = 22;
            this.label_xuaHD.Visible = false;
            // 
            // chkSuDungDiemTichLuy
            // 
            this.chkSuDungDiemTichLuy.AutoSize = true;
            this.chkSuDungDiemTichLuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSuDungDiemTichLuy.Location = new System.Drawing.Point(206, 386);
            this.chkSuDungDiemTichLuy.Name = "chkSuDungDiemTichLuy";
            this.chkSuDungDiemTichLuy.Size = new System.Drawing.Size(166, 22);
            this.chkSuDungDiemTichLuy.TabIndex = 21;
            this.chkSuDungDiemTichLuy.Text = "Sử dụng điểm tích luỹ";
            this.chkSuDungDiemTichLuy.UseVisualStyleBackColor = true;
            // 
            // txt_diemDung
            // 
            this.txt_diemDung.Location = new System.Drawing.Point(206, 316);
            this.txt_diemDung.Margin = new System.Windows.Forms.Padding(2);
            this.txt_diemDung.Name = "txt_diemDung";
            this.txt_diemDung.Size = new System.Drawing.Size(305, 24);
            this.txt_diemDung.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Navy;
            this.label19.Location = new System.Drawing.Point(19, 317);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(95, 20);
            this.label19.TabIndex = 19;
            this.label19.Text = "Dùng điểm";
            // 
            // txt_diemTichLuy
            // 
            this.txt_diemTichLuy.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_diemTichLuy.Location = new System.Drawing.Point(206, 350);
            this.txt_diemTichLuy.Margin = new System.Windows.Forms.Padding(2);
            this.txt_diemTichLuy.Name = "txt_diemTichLuy";
            this.txt_diemTichLuy.Size = new System.Drawing.Size(305, 24);
            this.txt_diemTichLuy.TabIndex = 18;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Navy;
            this.label18.Location = new System.Drawing.Point(19, 351);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 20);
            this.label18.TabIndex = 17;
            this.label18.Text = "Điểm tích luỹ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label14.Location = new System.Drawing.Point(497, 285);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 18);
            this.label14.TabIndex = 12;
            this.label14.Text = "VNĐ";
            // 
            // txt_tongTien
            // 
            this.txt_tongTien.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_tongTien.Location = new System.Drawing.Point(364, 282);
            this.txt_tongTien.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tongTien.Name = "txt_tongTien";
            this.txt_tongTien.Size = new System.Drawing.Size(129, 24);
            this.txt_tongTien.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(259, 282);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 20);
            this.label13.TabIndex = 10;
            this.label13.Text = "Tổng tiền";
            // 
            // txt_TongSL
            // 
            this.txt_TongSL.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txt_TongSL.Location = new System.Drawing.Point(203, 280);
            this.txt_TongSL.Margin = new System.Windows.Forms.Padding(2);
            this.txt_TongSL.Name = "txt_TongSL";
            this.txt_TongSL.Size = new System.Drawing.Size(49, 24);
            this.txt_TongSL.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(19, 286);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Tổng SL";
            // 
            // txt_diaChi
            // 
            this.txt_diaChi.Location = new System.Drawing.Point(206, 218);
            this.txt_diaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txt_diaChi.Name = "txt_diaChi";
            this.txt_diaChi.Size = new System.Drawing.Size(305, 24);
            this.txt_diaChi.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(19, 223);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Địa chỉ";
            // 
            // txt_soDienThoai
            // 
            this.txt_soDienThoai.Location = new System.Drawing.Point(206, 184);
            this.txt_soDienThoai.Margin = new System.Windows.Forms.Padding(2);
            this.txt_soDienThoai.Name = "txt_soDienThoai";
            this.txt_soDienThoai.Size = new System.Drawing.Size(305, 24);
            this.txt_soDienThoai.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(19, 189);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 20);
            this.label10.TabIndex = 4;
            this.label10.Text = "Số điện thoại";
            // 
            // txt_tenKhachHang
            // 
            this.txt_tenKhachHang.Location = new System.Drawing.Point(206, 147);
            this.txt_tenKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.txt_tenKhachHang.Name = "txt_tenKhachHang";
            this.txt_tenKhachHang.Size = new System.Drawing.Size(307, 24);
            this.txt_tenKhachHang.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(19, 152);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tên khách hàng";
            // 
            // txt_maKhachHang
            // 
            this.txt_maKhachHang.Location = new System.Drawing.Point(206, 114);
            this.txt_maKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.txt_maKhachHang.Name = "txt_maKhachHang";
            this.txt_maKhachHang.Size = new System.Drawing.Size(307, 24);
            this.txt_maKhachHang.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(19, 116);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã khách hàng";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.Navy;
            this.label17.Location = new System.Drawing.Point(903, 123);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(5, 1000);
            this.label17.TabIndex = 11;
            // 
            // cbo_loai
            // 
            this.cbo_loai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbo_loai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_loai.FormattingEnabled = true;
            this.cbo_loai.Location = new System.Drawing.Point(707, 69);
            this.cbo_loai.Name = "cbo_loai";
            this.cbo_loai.Size = new System.Drawing.Size(166, 26);
            this.cbo_loai.TabIndex = 12;
            this.cbo_loai.SelectedIndexChanged += new System.EventHandler(this.cbo_loai_SelectedIndexChanged);
            // 
            // dgvCart
            // 
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(914, 123);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.Size = new System.Drawing.Size(610, 195);
            this.dgvCart.TabIndex = 13;
            this.dgvCart.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellContentClick);
            this.dgvCart.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCart_CellValidating);
            this.dgvCart.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCart_CellValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Controls.Add(this.btn_trangDau);
            this.groupBox3.Controls.Add(this.btn_troLai);
            this.groupBox3.Controls.Add(this.btn_trangCuoi);
            this.groupBox3.Controls.Add(this.btn_keTiep);
            this.groupBox3.Location = new System.Drawing.Point(298, 585);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 43);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            // 
            // btn_trangDau
            // 
            this.btn_trangDau.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_trangDau.BackColor = System.Drawing.Color.Navy;
            this.btn_trangDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trangDau.ForeColor = System.Drawing.Color.Cornsilk;
            this.btn_trangDau.Location = new System.Drawing.Point(73, 14);
            this.btn_trangDau.Name = "btn_trangDau";
            this.btn_trangDau.Size = new System.Drawing.Size(37, 23);
            this.btn_trangDau.TabIndex = 28;
            this.btn_trangDau.Text = "<<";
            this.btn_trangDau.UseVisualStyleBackColor = false;
            // 
            // btn_troLai
            // 
            this.btn_troLai.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_troLai.BackColor = System.Drawing.Color.Navy;
            this.btn_troLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_troLai.ForeColor = System.Drawing.Color.Cornsilk;
            this.btn_troLai.Location = new System.Drawing.Point(116, 14);
            this.btn_troLai.Name = "btn_troLai";
            this.btn_troLai.Size = new System.Drawing.Size(37, 23);
            this.btn_troLai.TabIndex = 26;
            this.btn_troLai.Text = "<";
            this.btn_troLai.UseVisualStyleBackColor = false;
            // 
            // btn_trangCuoi
            // 
            this.btn_trangCuoi.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_trangCuoi.BackColor = System.Drawing.Color.Navy;
            this.btn_trangCuoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_trangCuoi.ForeColor = System.Drawing.Color.Cornsilk;
            this.btn_trangCuoi.Location = new System.Drawing.Point(202, 14);
            this.btn_trangCuoi.Name = "btn_trangCuoi";
            this.btn_trangCuoi.Size = new System.Drawing.Size(37, 23);
            this.btn_trangCuoi.TabIndex = 29;
            this.btn_trangCuoi.Text = ">>";
            this.btn_trangCuoi.UseVisualStyleBackColor = false;
            // 
            // btn_keTiep
            // 
            this.btn_keTiep.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_keTiep.BackColor = System.Drawing.Color.Navy;
            this.btn_keTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_keTiep.ForeColor = System.Drawing.Color.Cornsilk;
            this.btn_keTiep.Location = new System.Drawing.Point(159, 14);
            this.btn_keTiep.Name = "btn_keTiep";
            this.btn_keTiep.Size = new System.Drawing.Size(37, 23);
            this.btn_keTiep.TabIndex = 27;
            this.btn_keTiep.Text = ">";
            this.btn_keTiep.UseVisualStyleBackColor = false;
            // 
            // txt_tenSanPham
            // 
            this.txt_tenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenSanPham.FormattingEnabled = true;
            this.txt_tenSanPham.Location = new System.Drawing.Point(10, 67);
            this.txt_tenSanPham.Name = "txt_tenSanPham";
            this.txt_tenSanPham.Size = new System.Drawing.Size(254, 26);
            this.txt_tenSanPham.TabIndex = 34;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.Navy;
            this.btn_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_Clear.Image = global::GUI.Properties.Resources.icons8_clear_32;
            this.btn_Clear.Location = new System.Drawing.Point(551, 92);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(42, 38);
            this.btn_Clear.TabIndex = 16;
            this.btn_Clear.UseVisualStyleBackColor = false;
            // 
            // btn_timKhachHang
            // 
            this.btn_timKhachHang.BackColor = System.Drawing.Color.Navy;
            this.btn_timKhachHang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timKhachHang.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timKhachHang.Location = new System.Drawing.Point(551, 41);
            this.btn_timKhachHang.Margin = new System.Windows.Forms.Padding(2);
            this.btn_timKhachHang.Name = "btn_timKhachHang";
            this.btn_timKhachHang.Size = new System.Drawing.Size(42, 38);
            this.btn_timKhachHang.TabIndex = 14;
            this.btn_timKhachHang.UseVisualStyleBackColor = false;
            // 
            // btn_luuHoaDon
            // 
            this.btn_luuHoaDon.AutoSize = true;
            this.btn_luuHoaDon.BackColor = System.Drawing.Color.Navy;
            this.btn_luuHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luuHoaDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_luuHoaDon.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btn_luuHoaDon.Location = new System.Drawing.Point(551, 141);
            this.btn_luuHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btn_luuHoaDon.Name = "btn_luuHoaDon";
            this.btn_luuHoaDon.Size = new System.Drawing.Size(46, 40);
            this.btn_luuHoaDon.TabIndex = 15;
            this.btn_luuHoaDon.UseVisualStyleBackColor = false;
            // 
            // btn_inHoaDon
            // 
            this.btn_inHoaDon.AutoSize = true;
            this.btn_inHoaDon.BackColor = System.Drawing.Color.Navy;
            this.btn_inHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_inHoaDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_inHoaDon.Image = global::GUI.Properties.Resources.icons8_print_32;
            this.btn_inHoaDon.Location = new System.Drawing.Point(551, 189);
            this.btn_inHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.btn_inHoaDon.Name = "btn_inHoaDon";
            this.btn_inHoaDon.Size = new System.Drawing.Size(46, 43);
            this.btn_inHoaDon.TabIndex = 14;
            this.btn_inHoaDon.UseVisualStyleBackColor = false;
            // 
            // btn_addCart
            // 
            this.btn_addCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_addCart.BackColor = System.Drawing.Color.Navy;
            this.btn_addCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_addCart.Image = global::GUI.Properties.Resources.icons8_add_shopping_cart_35;
            this.btn_addCart.Location = new System.Drawing.Point(818, 21);
            this.btn_addCart.Margin = new System.Windows.Forms.Padding(2);
            this.btn_addCart.Name = "btn_addCart";
            this.btn_addCart.Size = new System.Drawing.Size(55, 49);
            this.btn_addCart.TabIndex = 9;
            this.btn_addCart.UseVisualStyleBackColor = false;
            // 
            // btn_timSanPham
            // 
            this.btn_timSanPham.BackColor = System.Drawing.Color.Navy;
            this.btn_timSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_timSanPham.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btn_timSanPham.Location = new System.Drawing.Point(284, 60);
            this.btn_timSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.btn_timSanPham.Name = "btn_timSanPham";
            this.btn_timSanPham.Size = new System.Drawing.Size(44, 41);
            this.btn_timSanPham.TabIndex = 4;
            this.btn_timSanPham.UseVisualStyleBackColor = false;
            // 
            // frm_lapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1536, 857);
            this.Controls.Add(this.txt_tenSanPham);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.cbo_loai);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label_ngayHT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_timSanPham);
            this.Controls.Add(this.dsSanPham);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_lapHoaDon";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_soLuong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel dsSanPham;
        private System.Windows.Forms.Button btn_timSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbo_kichThuoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_mauSac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addCart;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LabelControl label_ngayHT;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_maKhachHang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_diaChi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_soDienThoai;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_tenKhachHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_tongTien;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_inHoaDon;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_giaBan;
        private System.Windows.Forms.Button btn_luuHoaDon;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbo_loai;
        private System.Windows.Forms.NumericUpDown txt_soLuong;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btn_timKhachHang;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox txt_diemTichLuy;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_TongSL;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_diemDung;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkSuDungDiemTichLuy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_trangDau;
        private System.Windows.Forms.Button btn_troLai;
        private System.Windows.Forms.Button btn_trangCuoi;
        private System.Windows.Forms.Button btn_keTiep;
        private System.Windows.Forms.Label label_xuaHD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbo_loaiKhachHang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_SLTon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RadioButton rdo_diaChiMoi;
        private System.Windows.Forms.RadioButton rdo_diaChiHienTai;
        private System.Windows.Forms.ComboBox cbo_giaoHang;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cbo_hinhThucThanhToan;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox txt_tenSanPham;
    }
}