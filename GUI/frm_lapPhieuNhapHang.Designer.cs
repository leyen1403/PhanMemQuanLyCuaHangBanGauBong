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
            this.btnDong = new System.Windows.Forms.Button();
            this.btnNhapLaiPN = new System.Windows.Forms.Button();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThemPN = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dTPNgayLap = new System.Windows.Forms.DateTimePicker();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtLanNhap = new System.Windows.Forms.TextBox();
            this.cbbMaDDH = new System.Windows.Forms.ComboBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.txtMaPN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvChiTietPhieuNhap = new System.Windows.Forms.DataGridView();
            this.dgvPhieuNhap = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSSanPham = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(381, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(133, 12, 133, 12);
            this.label1.Size = new System.Drawing.Size(536, 49);
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
            this.groupBox1.Location = new System.Drawing.Point(744, 98);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(765, 520);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(637, 201);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(111, 50);
            this.btnDong.TabIndex = 51;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnNhapLaiPN
            // 
            this.btnNhapLaiPN.Image = global::GUI.Properties.Resources.icons8_load_32;
            this.btnNhapLaiPN.Location = new System.Drawing.Point(639, 132);
            this.btnNhapLaiPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNhapLaiPN.Name = "btnNhapLaiPN";
            this.btnNhapLaiPN.Size = new System.Drawing.Size(99, 42);
            this.btnNhapLaiPN.TabIndex = 50;
            this.btnNhapLaiPN.UseVisualStyleBackColor = true;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Enabled = false;
            this.txtTongTien.Location = new System.Drawing.Point(257, 260);
            this.txtTongTien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(329, 26);
            this.txtTongTien.TabIndex = 36;
            // 
            // btnThemPN
            // 
            this.btnThemPN.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemPN.Location = new System.Drawing.Point(639, 59);
            this.btnThemPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemPN.Name = "btnThemPN";
            this.btnThemPN.Size = new System.Drawing.Size(99, 43);
            this.btnThemPN.TabIndex = 49;
            this.btnThemPN.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 260);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Tổng tiền";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(781, 382);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 20);
            this.label12.TabIndex = 19;
            // 
            // dTPNgayLap
            // 
            this.dTPNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dTPNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPNgayLap.Location = new System.Drawing.Point(257, 219);
            this.dTPNgayLap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dTPNgayLap.Name = "dTPNgayLap";
            this.dTPNgayLap.Size = new System.Drawing.Size(329, 26);
            this.dTPNgayLap.TabIndex = 11;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(257, 176);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(329, 26);
            this.txtTrangThai.TabIndex = 10;
            // 
            // txtLanNhap
            // 
            this.txtLanNhap.Location = new System.Drawing.Point(257, 133);
            this.txtLanNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLanNhap.Name = "txtLanNhap";
            this.txtLanNhap.Size = new System.Drawing.Size(329, 26);
            this.txtLanNhap.TabIndex = 9;
            // 
            // cbbMaDDH
            // 
            this.cbbMaDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMaDDH.FormattingEnabled = true;
            this.cbbMaDDH.Location = new System.Drawing.Point(229, 114);
            this.cbbMaDDH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbMaDDH.Name = "cbbMaDDH";
            this.cbbMaDDH.Size = new System.Drawing.Size(329, 28);
            this.cbbMaDDH.TabIndex = 8;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(257, 92);
            this.cbbNhanVien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(329, 28);
            this.cbbNhanVien.TabIndex = 7;
            // 
            // txtMaPN
            // 
            this.txtMaPN.Location = new System.Drawing.Point(257, 49);
            this.txtMaPN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaPN.Name = "txtMaPN";
            this.txtMaPN.Size = new System.Drawing.Size(329, 26);
            this.txtMaPN.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(63, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Đơn đặt hàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 95);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lần nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Trạng thái";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 222);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ngày lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã phiếu nhập";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvChiTietPhieuNhap);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(751, 636);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(750, 291);
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
            this.dgvChiTietPhieuNhap.Location = new System.Drawing.Point(7, 66);
            this.dgvChiTietPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChiTietPhieuNhap.Name = "dgvChiTietPhieuNhap";
            this.dgvChiTietPhieuNhap.RowHeadersWidth = 51;
            this.dgvChiTietPhieuNhap.RowTemplate.Height = 24;
            this.dgvChiTietPhieuNhap.Size = new System.Drawing.Size(737, 221);
            this.dgvChiTietPhieuNhap.TabIndex = 0;
            // 
            // dgvPhieuNhap
            // 
            this.dgvPhieuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieuNhap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuNhap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPhieuNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuNhap.Location = new System.Drawing.Point(7, 305);
            this.dgvPhieuNhap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPhieuNhap.Name = "dgvPhieuNhap";
            this.dgvPhieuNhap.RowHeadersWidth = 51;
            this.dgvPhieuNhap.RowTemplate.Height = 24;
            this.dgvPhieuNhap.Size = new System.Drawing.Size(751, 209);
            this.dgvPhieuNhap.TabIndex = 52;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dgvDSSanPham);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(28, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(688, 776);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvDSSanPham
            // 
            this.dgvDSSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSSanPham.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDSSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgvDSSanPham.Location = new System.Drawing.Point(6, 24);
            this.dgvDSSanPham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDSSanPham.Name = "dgvDSSanPham";
            this.dgvDSSanPham.RowHeadersWidth = 51;
            this.dgvDSSanPham.RowTemplate.Height = 24;
            this.dgvDSSanPham.Size = new System.Drawing.Size(673, 686);
            this.dgvDSSanPham.TabIndex = 53;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 715);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 38);
            this.button1.TabIndex = 54;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Thêm";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // frm_lapPhieuNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 951);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbMaDDH);
            this.Controls.Add(this.label7);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_lapPhieuNhapHang";
            this.Text = "frm_lapPhieuNhapHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieuNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuNhap)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}