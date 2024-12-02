namespace GUI
{
    partial class frm_TaoDDH
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
            this.dtpNgayDatHang = new System.Windows.Forms.DateTimePicker();
            this.cboNhaCungCap = new System.Windows.Forms.ComboBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.txtMaDonDatHang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCTDDH = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.nudSoLuongYeuCau = new System.Windows.Forms.NumericUpDown();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnLuuCTDDH = new System.Windows.Forms.Button();
            this.btnXoaCTDDH = new System.Windows.Forms.Button();
            this.btnThemCTDDH = new System.Windows.Forms.Button();
            this.btnDatSPMoi = new System.Windows.Forms.Button();
            this.txtTimKiemSP = new System.Windows.Forms.TextBox();
            this.btnDatToanBo = new System.Windows.Forms.Button();
            this.btnXoaToanBo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongYeuCau)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(1828, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "TẠO ĐƠN ĐẶT HÀNG MỚI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayDatHang);
            this.groupBox1.Controls.Add(this.cboNhaCungCap);
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.txtMaDonDatHang);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 235);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đơn đặt hàng";
            // 
            // dtpNgayDatHang
            // 
            this.dtpNgayDatHang.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDatHang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDatHang.Location = new System.Drawing.Point(152, 128);
            this.dtpNgayDatHang.Name = "dtpNgayDatHang";
            this.dtpNgayDatHang.Size = new System.Drawing.Size(274, 26);
            this.dtpNgayDatHang.TabIndex = 3;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.Location = new System.Drawing.Point(152, 176);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(274, 28);
            this.cboNhaCungCap.TabIndex = 2;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(152, 82);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(274, 28);
            this.cboNhanVien.TabIndex = 2;
            // 
            // txtMaDonDatHang
            // 
            this.txtMaDonDatHang.Enabled = false;
            this.txtMaDonDatHang.Location = new System.Drawing.Point(152, 35);
            this.txtMaDonDatHang.Name = "txtMaDonDatHang";
            this.txtMaDonDatHang.Size = new System.Drawing.Size(274, 26);
            this.txtMaDonDatHang.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhà cung cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày đặt hàng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nhân viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã đơn đặt hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvSP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 292);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1801, 320);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvSP
            // 
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSP.Location = new System.Drawing.Point(3, 22);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.Size = new System.Drawing.Size(1795, 295);
            this.dgvSP.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCTDDH);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(12, 618);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1798, 275);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách sản phẩm trong đơn đặt hàng";
            // 
            // dgvCTDDH
            // 
            this.dgvCTDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTDDH.Location = new System.Drawing.Point(3, 22);
            this.dgvCTDDH.Name = "dgvCTDDH";
            this.dgvCTDDH.Size = new System.Drawing.Size(1792, 250);
            this.dgvCTDDH.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtThanhTien);
            this.groupBox4.Controls.Add(this.txtDonGia);
            this.groupBox4.Controls.Add(this.nudSoLuongYeuCau);
            this.groupBox4.Controls.Add(this.txtTimKiemSP);
            this.groupBox4.Controls.Add(this.txtMaSanPham);
            this.groupBox4.Controls.Add(this.txtTenSanPham);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnDatSPMoi);
            this.groupBox4.Controls.Add(this.btnXoaToanBo);
            this.groupBox4.Controls.Add(this.btnDatToanBo);
            this.groupBox4.Controls.Add(this.btnHoanTat);
            this.groupBox4.Controls.Add(this.btnLuuCTDDH);
            this.groupBox4.Controls.Add(this.btnXoaCTDDH);
            this.groupBox4.Controls.Add(this.btnThemCTDDH);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(477, 51);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1336, 235);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Enabled = false;
            this.txtThanhTien.Location = new System.Drawing.Point(884, 172);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(228, 26);
            this.txtThanhTien.TabIndex = 8;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Enabled = false;
            this.txtDonGia.Location = new System.Drawing.Point(884, 101);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(228, 26);
            this.txtDonGia.TabIndex = 8;
            // 
            // nudSoLuongYeuCau
            // 
            this.nudSoLuongYeuCau.Location = new System.Drawing.Point(884, 32);
            this.nudSoLuongYeuCau.Name = "nudSoLuongYeuCau";
            this.nudSoLuongYeuCau.Size = new System.Drawing.Size(228, 26);
            this.nudSoLuongYeuCau.TabIndex = 7;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Enabled = false;
            this.txtMaSanPham.Location = new System.Drawing.Point(310, 32);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(320, 26);
            this.txtMaSanPham.TabIndex = 6;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Enabled = false;
            this.txtTenSanPham.Location = new System.Drawing.Point(310, 104);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(320, 26);
            this.txtTenSanPham.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(146, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tên sản phẩm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(747, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 20);
            this.label11.TabIndex = 5;
            this.label11.Text = "Đơn giá";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(747, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "Thành tiền";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(747, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Số lượng yêu cầu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã sản phẩm";
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.AutoSize = true;
            this.btnHoanTat.Location = new System.Drawing.Point(6, 167);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(81, 41);
            this.btnHoanTat.TabIndex = 1;
            this.btnHoanTat.Text = "Hoàn tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            // 
            // btnLuuCTDDH
            // 
            this.btnLuuCTDDH.AutoSize = true;
            this.btnLuuCTDDH.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuCTDDH.Location = new System.Drawing.Point(6, 120);
            this.btnLuuCTDDH.Name = "btnLuuCTDDH";
            this.btnLuuCTDDH.Size = new System.Drawing.Size(75, 41);
            this.btnLuuCTDDH.TabIndex = 2;
            this.btnLuuCTDDH.UseVisualStyleBackColor = true;
            // 
            // btnXoaCTDDH
            // 
            this.btnXoaCTDDH.AutoSize = true;
            this.btnXoaCTDDH.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaCTDDH.Location = new System.Drawing.Point(6, 73);
            this.btnXoaCTDDH.Name = "btnXoaCTDDH";
            this.btnXoaCTDDH.Size = new System.Drawing.Size(75, 41);
            this.btnXoaCTDDH.TabIndex = 3;
            this.btnXoaCTDDH.UseVisualStyleBackColor = true;
            // 
            // btnThemCTDDH
            // 
            this.btnThemCTDDH.AutoSize = true;
            this.btnThemCTDDH.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemCTDDH.Location = new System.Drawing.Point(6, 26);
            this.btnThemCTDDH.Name = "btnThemCTDDH";
            this.btnThemCTDDH.Size = new System.Drawing.Size(75, 41);
            this.btnThemCTDDH.TabIndex = 4;
            this.btnThemCTDDH.UseVisualStyleBackColor = true;
            // 
            // btnDatSPMoi
            // 
            this.btnDatSPMoi.AutoSize = true;
            this.btnDatSPMoi.Location = new System.Drawing.Point(93, 167);
            this.btnDatSPMoi.Name = "btnDatSPMoi";
            this.btnDatSPMoi.Size = new System.Drawing.Size(274, 41);
            this.btnDatSPMoi.TabIndex = 1;
            this.btnDatSPMoi.Text = "Đặt các sản phẩm được tạo gần đây";
            this.btnDatSPMoi.UseVisualStyleBackColor = true;
            // 
            // txtTimKiemSP
            // 
            this.txtTimKiemSP.Location = new System.Drawing.Point(373, 176);
            this.txtTimKiemSP.Name = "txtTimKiemSP";
            this.txtTimKiemSP.Size = new System.Drawing.Size(320, 26);
            this.txtTimKiemSP.TabIndex = 6;
            // 
            // btnDatToanBo
            // 
            this.btnDatToanBo.AutoSize = true;
            this.btnDatToanBo.Location = new System.Drawing.Point(1136, 24);
            this.btnDatToanBo.Name = "btnDatToanBo";
            this.btnDatToanBo.Size = new System.Drawing.Size(177, 41);
            this.btnDatToanBo.TabIndex = 1;
            this.btnDatToanBo.Text = "Đặt toàn bộ sản phẩm";
            this.btnDatToanBo.UseVisualStyleBackColor = true;
            // 
            // btnXoaToanBo
            // 
            this.btnXoaToanBo.AutoSize = true;
            this.btnXoaToanBo.Location = new System.Drawing.Point(1136, 75);
            this.btnXoaToanBo.Name = "btnXoaToanBo";
            this.btnXoaToanBo.Size = new System.Drawing.Size(184, 41);
            this.btnXoaToanBo.TabIndex = 1;
            this.btnXoaToanBo.Text = "Xoá toàn bộ danh sách";
            this.btnXoaToanBo.UseVisualStyleBackColor = true;
            // 
            // frm_TaoDDH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1828, 905);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_TaoDDH";
            this.Text = "fmr_TaoDDH";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongYeuCau)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNgayDatHang;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.TextBox txtMaDonDatHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCTDDH;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnLuuCTDDH;
        private System.Windows.Forms.Button btnXoaCTDDH;
        private System.Windows.Forms.Button btnThemCTDDH;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuongYeuCau;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Button btnDatSPMoi;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Button btnXoaToanBo;
        private System.Windows.Forms.Button btnDatToanBo;
    }
}