namespace GUI
{
    partial class frm_QuanLyPhieuHoanTra
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
            this.components = new System.ComponentModel.Container();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvChiTietPhieuHoanTra = new System.Windows.Forms.DataGridView();
            this.contextMenuStripDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvPhieuHoanTra = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.dTPNgayCapNhat = new System.Windows.Forms.DateTimePicker();
            this.btnHuyPhieu = new System.Windows.Forms.Button();
            this.btnThemPHT = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dTPNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtTongSoLuong = new System.Windows.Forms.TextBox();
            this.txtMaPHT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbMaPhieuHT = new System.Windows.Forms.ComboBox();
            this.cbbLuaChonHienThi = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuHoanTra)).BeginInit();
            this.contextMenuStripDelete.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuHoanTra)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(94, 22);
            this.deleteMenuItem.Text = "Xóa";
            // 
            // dgvChiTietPhieuHoanTra
            // 
            this.dgvChiTietPhieuHoanTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuHoanTra.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTietPhieuHoanTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuHoanTra.ContextMenuStrip = this.contextMenuStripDelete;
            this.dgvChiTietPhieuHoanTra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPhieuHoanTra.Location = new System.Drawing.Point(3, 19);
            this.dgvChiTietPhieuHoanTra.Name = "dgvChiTietPhieuHoanTra";
            this.dgvChiTietPhieuHoanTra.RowHeadersWidth = 51;
            this.dgvChiTietPhieuHoanTra.RowTemplate.Height = 24;
            this.dgvChiTietPhieuHoanTra.Size = new System.Drawing.Size(609, 507);
            this.dgvChiTietPhieuHoanTra.TabIndex = 0;
            // 
            // contextMenuStripDelete
            // 
            this.contextMenuStripDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteMenuItem});
            this.contextMenuStripDelete.Name = "contextMenuStripDelete";
            this.contextMenuStripDelete.Size = new System.Drawing.Size(95, 26);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.dgvChiTietPhieuHoanTra);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(777, 355);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(615, 529);
            this.groupBox4.TabIndex = 41;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chi tiết phiếu hoàn trả";
            // 
            // dgvPhieuHoanTra
            // 
            this.dgvPhieuHoanTra.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuHoanTra.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPhieuHoanTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuHoanTra.Location = new System.Drawing.Point(3, 17);
            this.dgvPhieuHoanTra.Name = "dgvPhieuHoanTra";
            this.dgvPhieuHoanTra.RowHeadersWidth = 51;
            this.dgvPhieuHoanTra.RowTemplate.Height = 24;
            this.dgvPhieuHoanTra.Size = new System.Drawing.Size(754, 484);
            this.dgvPhieuHoanTra.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dgvPhieuHoanTra);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(11, 355);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 506);
            this.groupBox3.TabIndex = 40;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách phiếu hoàn trả";
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.Navy;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuPhieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuuPhieu.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuPhieu.Location = new System.Drawing.Point(466, 79);
            this.btnLuuPhieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(39, 48);
            this.btnLuuPhieu.TabIndex = 51;
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(683, 381);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cbbNhanVien);
            this.groupBox1.Controls.Add(this.dTPNgayCapNhat);
            this.groupBox1.Controls.Add(this.btnHuyPhieu);
            this.groupBox1.Controls.Add(this.btnLuuPhieu);
            this.groupBox1.Controls.Add(this.btnThemPHT);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dTPNgayLap);
            this.groupBox1.Controls.Add(this.txtTongSoLuong);
            this.groupBox1.Controls.Add(this.txtMaPHT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(523, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(572, 335);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu hoàn trả";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 75);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(288, 63);
            this.textBox1.TabIndex = 56;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(158, 281);
            this.cbbNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(288, 24);
            this.cbbNhanVien.TabIndex = 55;
            // 
            // dTPNgayCapNhat
            // 
            this.dTPNgayCapNhat.CustomFormat = "dd/MM/yyyy";
            this.dTPNgayCapNhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPNgayCapNhat.Location = new System.Drawing.Point(158, 198);
            this.dTPNgayCapNhat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dTPNgayCapNhat.Name = "dTPNgayCapNhat";
            this.dTPNgayCapNhat.Size = new System.Drawing.Size(288, 23);
            this.dTPNgayCapNhat.TabIndex = 54;
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BackColor = System.Drawing.Color.Navy;
            this.btnHuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPhieu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHuyPhieu.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnHuyPhieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyPhieu.Location = new System.Drawing.Point(466, 144);
            this.btnHuyPhieu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(39, 44);
            this.btnHuyPhieu.TabIndex = 51;
            this.btnHuyPhieu.UseVisualStyleBackColor = false;
            // 
            // btnThemPHT
            // 
            this.btnThemPHT.BackColor = System.Drawing.Color.Navy;
            this.btnThemPHT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemPHT.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThemPHT.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemPHT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemPHT.Location = new System.Drawing.Point(466, 24);
            this.btnThemPHT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemPHT.Name = "btnThemPHT";
            this.btnThemPHT.Size = new System.Drawing.Size(39, 41);
            this.btnThemPHT.TabIndex = 49;
            this.btnThemPHT.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 285);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 16);
            this.label16.TabIndex = 35;
            this.label16.Text = "Mã nhân viên";
            // 
            // dTPNgayLap
            // 
            this.dTPNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dTPNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPNgayLap.Location = new System.Drawing.Point(158, 241);
            this.dTPNgayLap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dTPNgayLap.Name = "dTPNgayLap";
            this.dTPNgayLap.Size = new System.Drawing.Size(288, 23);
            this.dTPNgayLap.TabIndex = 11;
            // 
            // txtTongSoLuong
            // 
            this.txtTongSoLuong.Location = new System.Drawing.Point(158, 155);
            this.txtTongSoLuong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTongSoLuong.Name = "txtTongSoLuong";
            this.txtTongSoLuong.Size = new System.Drawing.Size(288, 23);
            this.txtTongSoLuong.TabIndex = 9;
            // 
            // txtMaPHT
            // 
            this.txtMaPHT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPHT.Location = new System.Drawing.Point(158, 28);
            this.txtMaPHT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaPHT.Name = "txtMaPHT";
            this.txtMaPHT.Size = new System.Drawing.Size(288, 23);
            this.txtMaPHT.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tình trạng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tổng số lượng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Ngày cập nhật";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 247);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Ngày lập";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(30, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mã phiếu hoàn trả";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpTuNgay);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnTim);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpDenNgay);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbbMaPhieuHT);
            this.groupBox2.Controls.Add(this.cbbLuaChonHienThi);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(11, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(504, 335);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm thông tin phiếu hoàn trả";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(133, 92);
            this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(357, 23);
            this.dtpTuNgay.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Từ ngày:";
            // 
            // btnTim
            // 
            this.btnTim.AutoSize = true;
            this.btnTim.BackColor = System.Drawing.Color.Navy;
            this.btnTim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Image = global::GUI.Properties.Resources.icons8_find_35;
            this.btnTim.Location = new System.Drawing.Point(446, 247);
            this.btnTim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(46, 41);
            this.btnTim.TabIndex = 7;
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lựa chọn hiển thị:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(135, 146);
            this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(357, 23);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 207);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã phiếu hoàn trả:";
            // 
            // cbbMaPhieuHT
            // 
            this.cbbMaPhieuHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaPhieuHT.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMaPhieuHT.FormattingEnabled = true;
            this.cbbMaPhieuHT.Items.AddRange(new object[] {
            "Tất cả phiếu kiểm kê",
            "Phiếu theo ngày lập",
            "Phiếu theo nhân viên"});
            this.cbbMaPhieuHT.Location = new System.Drawing.Point(133, 200);
            this.cbbMaPhieuHT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbMaPhieuHT.Name = "cbbMaPhieuHT";
            this.cbbMaPhieuHT.Size = new System.Drawing.Size(357, 24);
            this.cbbMaPhieuHT.TabIndex = 4;
            // 
            // cbbLuaChonHienThi
            // 
            this.cbbLuaChonHienThi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLuaChonHienThi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLuaChonHienThi.FormattingEnabled = true;
            this.cbbLuaChonHienThi.Items.AddRange(new object[] {
            "Tất cả phiếu hoàn trả",
            "Phiếu theo ngày lập",
            "Phiếu theo nhân viên"});
            this.cbbLuaChonHienThi.Location = new System.Drawing.Point(133, 38);
            this.cbbLuaChonHienThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbLuaChonHienThi.Name = "cbbLuaChonHienThi";
            this.cbbLuaChonHienThi.Size = new System.Drawing.Size(357, 24);
            this.cbbLuaChonHienThi.TabIndex = 4;
            // 
            // frm_QuanLyPhieuHoanTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1361, 749);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frm_QuanLyPhieuHoanTra";
            this.Text = "frm_QuanLyPhieuHoanTra";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuHoanTra)).EndInit();
            this.contextMenuStripDelete.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuHoanTra)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuHoanTra;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDelete;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvPhieuHoanTra;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTongSoLuong;
        private System.Windows.Forms.TextBox txtMaPHT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbMaPhieuHT;
        private System.Windows.Forms.ComboBox cbbLuaChonHienThi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dTPNgayLap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dTPNgayCapNhat;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.Button btnHuyPhieu;
        private System.Windows.Forms.Button btnThemPHT;
        private System.Windows.Forms.TextBox textBox1;
    }
}