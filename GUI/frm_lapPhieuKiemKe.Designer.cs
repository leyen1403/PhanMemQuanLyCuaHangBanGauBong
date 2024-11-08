namespace GUI
{
    partial class frm_lapPhieuKiemKe
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
            this.dgv_DSSP = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtSoLuongThucTe = new System.Windows.Forms.NumericUpDown();
            this.txtSoLuongHeThong = new System.Windows.Forms.NumericUpDown();
            this.txtSoLuongTonKhoToiThieu = new System.Windows.Forms.TextBox();
            this.txtSoLuongChenhLech = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNhanVienLap = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbbMaPhieuKiemKe = new System.Windows.Forms.ComboBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.btnTao = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTimTenSanPham = new System.Windows.Forms.TextBox();
            this.cbbLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnCapNhatGhiChu = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvDSChiTietPhieuKiemKe = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongThucTe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongHeThong)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChiTietPhieuKiemKe)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1364, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "LẬP PHIỂU KIỂM KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv_DSSP);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 309);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 277);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgv_DSSP
            // 
            this.dgv_DSSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DSSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DSSP.Location = new System.Drawing.Point(3, 23);
            this.dgv_DSSP.Name = "dgv_DSSP";
            this.dgv_DSSP.ReadOnly = true;
            this.dgv_DSSP.Size = new System.Drawing.Size(730, 251);
            this.dgv_DSSP.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.txtSoLuongThucTe);
            this.groupBox2.Controls.Add(this.txtSoLuongHeThong);
            this.groupBox2.Controls.Add(this.txtSoLuongTonKhoToiThieu);
            this.groupBox2.Controls.Add(this.txtSoLuongChenhLech);
            this.groupBox2.Controls.Add(this.txtTenSanPham);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMaSanPham);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(746, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 617);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin sản phẩm";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(293, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.AutoSize = true;
            this.btnCapNhat.BackColor = System.Drawing.Color.Navy;
            this.btnCapNhat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnCapNhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhat.Location = new System.Drawing.Point(497, 27);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(109, 51);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // txtSoLuongThucTe
            // 
            this.txtSoLuongThucTe.Location = new System.Drawing.Point(188, 265);
            this.txtSoLuongThucTe.Name = "txtSoLuongThucTe";
            this.txtSoLuongThucTe.Size = new System.Drawing.Size(120, 27);
            this.txtSoLuongThucTe.TabIndex = 2;
            // 
            // txtSoLuongHeThong
            // 
            this.txtSoLuongHeThong.Enabled = false;
            this.txtSoLuongHeThong.Location = new System.Drawing.Point(188, 190);
            this.txtSoLuongHeThong.Name = "txtSoLuongHeThong";
            this.txtSoLuongHeThong.Size = new System.Drawing.Size(120, 27);
            this.txtSoLuongHeThong.TabIndex = 2;
            // 
            // txtSoLuongTonKhoToiThieu
            // 
            this.txtSoLuongTonKhoToiThieu.Location = new System.Drawing.Point(457, 340);
            this.txtSoLuongTonKhoToiThieu.Name = "txtSoLuongTonKhoToiThieu";
            this.txtSoLuongTonKhoToiThieu.Size = new System.Drawing.Size(120, 27);
            this.txtSoLuongTonKhoToiThieu.TabIndex = 1;
            // 
            // txtSoLuongChenhLech
            // 
            this.txtSoLuongChenhLech.Enabled = false;
            this.txtSoLuongChenhLech.Location = new System.Drawing.Point(188, 340);
            this.txtSoLuongChenhLech.Name = "txtSoLuongChenhLech";
            this.txtSoLuongChenhLech.Size = new System.Drawing.Size(120, 27);
            this.txtSoLuongChenhLech.TabIndex = 1;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Enabled = false;
            this.txtTenSanPham.Location = new System.Drawing.Point(188, 115);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(256, 27);
            this.txtTenSanPham.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(314, 348);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tồn kho tối thiểu:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 348);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(159, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Số lượng chênh lệch:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Số lượng thực tế:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(147, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số lượng hệ thống:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tên sản phẩm:";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Enabled = false;
            this.txtMaSanPham.Location = new System.Drawing.Point(188, 40);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(256, 27);
            this.txtMaSanPham.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã sản phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã phiếu kiểm kê:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày lập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(558, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ghi chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(633, 16);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(303, 137);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 19);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nhân viên lập:";
            // 
            // txtNhanVienLap
            // 
            this.txtNhanVienLap.Enabled = false;
            this.txtNhanVienLap.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVienLap.Location = new System.Drawing.Point(222, 126);
            this.txtNhanVienLap.Name = "txtNhanVienLap";
            this.txtNhanVienLap.Size = new System.Drawing.Size(275, 27);
            this.txtNhanVienLap.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbbMaPhieuKiemKe);
            this.groupBox3.Controls.Add(this.dtpNgayLap);
            this.groupBox3.Controls.Add(this.txtNhanVienLap);
            this.groupBox3.Controls.Add(this.txtGhiChu);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(942, 162);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chung";
            // 
            // cbbMaPhieuKiemKe
            // 
            this.cbbMaPhieuKiemKe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaPhieuKiemKe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMaPhieuKiemKe.FormattingEnabled = true;
            this.cbbMaPhieuKiemKe.Location = new System.Drawing.Point(222, 21);
            this.cbbMaPhieuKiemKe.Name = "cbbMaPhieuKiemKe";
            this.cbbMaPhieuKiemKe.Size = new System.Drawing.Size(275, 27);
            this.cbbMaPhieuKiemKe.TabIndex = 6;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLap.Location = new System.Drawing.Point(222, 75);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(275, 27);
            this.dtpNgayLap.TabIndex = 6;
            // 
            // btnTao
            // 
            this.btnTao.AutoSize = true;
            this.btnTao.BackColor = System.Drawing.Color.Navy;
            this.btnTao.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTao.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTao.ForeColor = System.Drawing.Color.White;
            this.btnTao.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnTao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTao.Location = new System.Drawing.Point(952, 67);
            this.btnTao.Name = "btnTao";
            this.btnTao.Size = new System.Drawing.Size(85, 53);
            this.btnTao.TabIndex = 3;
            this.btnTao.Text = "Tạo";
            this.btnTao.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTao.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.AutoSize = true;
            this.btnDong.BackColor = System.Drawing.Color.Navy;
            this.btnDong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDong.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(952, 126);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 53);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // txtTimTenSanPham
            // 
            this.txtTimTenSanPham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimTenSanPham.Location = new System.Drawing.Point(12, 276);
            this.txtTimTenSanPham.Name = "txtTimTenSanPham";
            this.txtTimTenSanPham.Size = new System.Drawing.Size(386, 27);
            this.txtTimTenSanPham.TabIndex = 4;
            // 
            // cbbLoaiSanPham
            // 
            this.cbbLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiSanPham.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLoaiSanPham.FormattingEnabled = true;
            this.cbbLoaiSanPham.Location = new System.Drawing.Point(467, 276);
            this.cbbLoaiSanPham.Name = "cbbLoaiSanPham";
            this.cbbLoaiSanPham.Size = new System.Drawing.Size(270, 27);
            this.cbbLoaiSanPham.TabIndex = 6;
            // 
            // btnTim
            // 
            this.btnTim.AutoSize = true;
            this.btnTim.BackColor = System.Drawing.Color.Navy;
            this.btnTim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btnTim.Location = new System.Drawing.Point(404, 269);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(57, 41);
            this.btnTim.TabIndex = 3;
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // btnCapNhatGhiChu
            // 
            this.btnCapNhatGhiChu.AutoSize = true;
            this.btnCapNhatGhiChu.BackColor = System.Drawing.Color.Navy;
            this.btnCapNhatGhiChu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCapNhatGhiChu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatGhiChu.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnCapNhatGhiChu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhatGhiChu.Location = new System.Drawing.Point(1043, 69);
            this.btnCapNhatGhiChu.Name = "btnCapNhatGhiChu";
            this.btnCapNhatGhiChu.Size = new System.Drawing.Size(109, 51);
            this.btnCapNhatGhiChu.TabIndex = 3;
            this.btnCapNhatGhiChu.Text = "Cập nhật";
            this.btnCapNhatGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhatGhiChu.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvDSChiTietPhieuKiemKe);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(4, 592);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(736, 277);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách sản phẩm trong phiếu kiểm";
            // 
            // dgvDSChiTietPhieuKiemKe
            // 
            this.dgvDSChiTietPhieuKiemKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSChiTietPhieuKiemKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSChiTietPhieuKiemKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDSChiTietPhieuKiemKe.Location = new System.Drawing.Point(3, 23);
            this.dgvDSChiTietPhieuKiemKe.Name = "dgvDSChiTietPhieuKiemKe";
            this.dgvDSChiTietPhieuKiemKe.ReadOnly = true;
            this.dgvDSChiTietPhieuKiemKe.Size = new System.Drawing.Size(730, 251);
            this.dgvDSChiTietPhieuKiemKe.TabIndex = 0;
            // 
            // frm_lapPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 903);
            this.Controls.Add(this.cbbLoaiSanPham);
            this.Controls.Add(this.btnCapNhatGhiChu);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtTimTenSanPham);
            this.Controls.Add(this.btnTao);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_lapPhieuKiemKe";
            this.Text = "frm_lapPhieuKiemKe";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSP)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongThucTe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuongHeThong)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSChiTietPhieuKiemKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNhanVienLap;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_DSSP;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.NumericUpDown txtSoLuongThucTe;
        private System.Windows.Forms.NumericUpDown txtSoLuongHeThong;
        private System.Windows.Forms.TextBox txtSoLuongChenhLech;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnTao;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTimTenSanPham;
        private System.Windows.Forms.ComboBox cbbLoaiSanPham;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Button btnCapNhatGhiChu;
        private System.Windows.Forms.TextBox txtSoLuongTonKhoToiThieu;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbMaPhieuKiemKe;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvDSChiTietPhieuKiemKe;
    }
}