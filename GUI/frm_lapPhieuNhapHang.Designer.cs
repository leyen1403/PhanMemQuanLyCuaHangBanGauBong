namespace GUI
{
    partial class frm_lapPhieuNhapHang
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
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dTPNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtLanNhap = new System.Windows.Forms.TextBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbMaDDH = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnChuyenSP = new System.Windows.Forms.Button();
            this.dgvDSSanPham = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnNhapLaiPN = new System.Windows.Forms.Button();
            this.btnThemPN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Navy;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(286, 7);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(100, 10, 100, 10);
            this.label1.Size = new System.Drawing.Size(470, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "LẬP PHIẾU NHẬP HÀNG";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvPhieuNhap);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnNhapLaiPN);
            this.groupBox1.Controls.Add(this.txtTongTien);
            this.groupBox1.Controls.Add(this.btnThemPN);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dTPNgayLap);
            this.groupBox1.Controls.Add(this.txtTrangThai);
            this.groupBox1.Controls.Add(this.txtLanNhap);
            this.groupBox1.Controls.Add(this.cbbNhanVien);
            this.groupBox1.Controls.Add(this.txtMaPN);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(558, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 422);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(5, 248);
            this.dgvPhieuNhap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.RowTemplate.Height = 24;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(563, 170);
            this.dgvPhieuNhap.TabIndex = 52;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(193, 211);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(248, 26);
            this.txtTongTien.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 211);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Tổng tiền";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(586, 310);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 19;
            // 
            // dTPNgayLap
            // 
            this.dTPNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dTPNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPNgayLap.Location = new System.Drawing.Point(193, 178);
            this.dTPNgayLap.Name = "dTPNgayLap";
            this.dTPNgayLap.Size = new System.Drawing.Size(248, 26);
            this.dTPNgayLap.TabIndex = 11;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(193, 143);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(248, 26);
            this.txtTrangThai.TabIndex = 10;
            // 
            // txtLanNhap
            // 
            this.txtLanNhap.Location = new System.Drawing.Point(193, 108);
            this.txtLanNhap.Name = "txtLanNhap";
            this.txtLanNhap.Size = new System.Drawing.Size(248, 26);
            this.txtLanNhap.TabIndex = 9;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(193, 75);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(248, 28);
            this.cbbNhanVien.TabIndex = 7;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(193, 40);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(248, 26);
            this.txtMaPN.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lần nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã phiếu nhập";
            // 
            // cbbMaDDH
            // 
            this.cbbMaDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMaDDH.FormattingEnabled = true;
            this.cbbMaDDH.Location = new System.Drawing.Point(172, 93);
            this.cbbMaDDH.Name = "cbbMaDDH";
            this.cbbMaDDH.Size = new System.Drawing.Size(248, 28);
            this.cbbMaDDH.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(47, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Đơn đặt hàng";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvChiTietPhieuNhap);
            this.groupBox3.Controls.Add(this.btnLuu);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(563, 517);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(562, 236);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết phiếu nhập";
            // 
            // dgvChiTietPhieuNhap
            // 
            this.dgvChiTietPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieuNhap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvChiTietPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(5, 54);
            this.dgvChiTietPhieuNhap.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.RowTemplate.Height = 24;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(553, 180);
            this.dgvChiTietPhieuNhap.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnChuyenSP);
            this.groupBox2.Controls.Add(this.dgvDSSanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(21, 130);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(516, 630);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // btnChuyenSP
            // 
            this.btnChuyenSP.BackColor = System.Drawing.Color.Navy;
            this.btnChuyenSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenSP.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChuyenSP.Location = new System.Drawing.Point(230, 581);
            this.btnChuyenSP.Margin = new System.Windows.Forms.Padding(2);
            this.btnChuyenSP.Name = "btnChuyenSP";
            this.btnChuyenSP.Size = new System.Drawing.Size(70, 31);
            this.btnChuyenSP.TabIndex = 54;
            this.btnChuyenSP.Text = ">>";
            this.btnChuyenSP.UseVisualStyleBackColor = false;
            // 
            // dgvDSSanPham
            // 
            this.dgvDSSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon});
            this.dgvDSSanPham.Location = new System.Drawing.Point(4, 20);
            this.dgvDSSanPham.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDSSanPham.Name = "dgvDSSanPham";
            this.dgvDSSanPham.RowHeadersWidth = 51;
            this.dgvDSSanPham.RowTemplate.Height = 24;
            this.dgvDSSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDSSanPham.Size = new System.Drawing.Size(505, 557);
            this.dgvDSSanPham.TabIndex = 53;
            // 
            // Chon
            // 
            this.Chon.HeaderText = "Thêm";
            this.Chon.Name = "Chon";
            this.Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chon.Width = 50;
            // 
            // btnLuu
            // 
            this.btnLuu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuu.BackColor = System.Drawing.Color.Transparent;
            this.btnLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuu.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuu.Location = new System.Drawing.Point(456, 17);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(47, 35);
            this.btnLuu.TabIndex = 51;
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDong.Image = global::GUI.Properties.Resources.icons8_macos_close_30;
            this.btnDong.Location = new System.Drawing.Point(479, 163);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(47, 35);
            this.btnDong.TabIndex = 51;
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnNhapLaiPN
            // 
            this.btnNhapLaiPN.Image = global::GUI.Properties.Resources.icons8_load_32;
            this.btnNhapLaiPN.Location = new System.Drawing.Point(479, 107);
            this.btnNhapLaiPN.Name = "btnNhapLaiPN";
            this.btnNhapLaiPN.Size = new System.Drawing.Size(47, 34);
            this.btnNhapLaiPN.TabIndex = 50;
            this.btnNhapLaiPN.UseVisualStyleBackColor = true;
            this.btnNhapLaiPN.Click += new System.EventHandler(this.btnNhapLaiPN_Click_1);
            // 
            // btnThemPN
            // 
            this.btnThemPN.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemPN.Location = new System.Drawing.Point(479, 50);
            this.btnThemPN.Name = "btnThemPN";
            this.btnThemPN.Size = new System.Drawing.Size(47, 35);
            this.btnThemPN.TabIndex = 49;
            this.btnThemPN.UseVisualStyleBackColor = true;
            // 
            // frm_lapPhieuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 773);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbMaDDH);
            this.Controls.Add(this.label7);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_lapPhieuNhapHang";
            this.Text = "frm_lapPhieuNhapHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSanPham)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dTPNgayLap;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.TextBox txtLanNhap;
        private System.Windows.Forms.ComboBox cbbMaDDH;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvChiTietPhieuNhap;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnNhapLaiPN;
        private System.Windows.Forms.Button btnThemPN;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dgvPhieuNhap;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSSanPham;
        private System.Windows.Forms.Button btnChuyenSP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.Button btnLuu;
    }
}