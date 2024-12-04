namespace GUI
{
    partial class frm_TaoPKK
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtMaPKK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSP = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCTPKK = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.nudSLTT = new System.Windows.Forms.NumericUpDown();
            this.nudSLHT = new System.Windows.Forms.NumericUpDown();
            this.btnChonSL = new System.Windows.Forms.Button();
            this.btnToanBo = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnLuuCTPKK = new System.Windows.Forms.Button();
            this.btnXoaCTPKK = new System.Windows.Forms.Button();
            this.btnThemCTPKK = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXoaToanBo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPKK)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLHT)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.txtMaPKK);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 220);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiếu kiểm kê";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(144, 143);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(173, 26);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(144, 92);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(173, 28);
            this.cboNhanVien.TabIndex = 2;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(419, 39);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(225, 130);
            this.txtGhiChu.TabIndex = 1;
            // 
            // txtMaPKK
            // 
            this.txtMaPKK.Location = new System.Drawing.Point(144, 39);
            this.txtMaPKK.Name = "txtMaPKK";
            this.txtMaPKK.Size = new System.Drawing.Size(173, 26);
            this.txtMaPKK.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(349, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày lập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã phiếu kiểm kê";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvSP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1548, 317);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // dgvSP
            // 
            this.dgvSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSP.Location = new System.Drawing.Point(3, 22);
            this.dgvSP.Name = "dgvSP";
            this.dgvSP.Size = new System.Drawing.Size(1542, 292);
            this.dgvSP.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCTPKK);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(12, 561);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1548, 325);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết phiếu kiểm kê";
            // 
            // dgvCTPKK
            // 
            this.dgvCTPKK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTPKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTPKK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTPKK.Location = new System.Drawing.Point(3, 22);
            this.dgvCTPKK.Name = "dgvCTPKK";
            this.dgvCTPKK.Size = new System.Drawing.Size(1542, 300);
            this.dgvCTPKK.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtMaSP);
            this.groupBox4.Controls.Add(this.nudSLTT);
            this.groupBox4.Controls.Add(this.nudSLHT);
            this.groupBox4.Controls.Add(this.btnXoaToanBo);
            this.groupBox4.Controls.Add(this.btnChonSL);
            this.groupBox4.Controls.Add(this.btnToanBo);
            this.groupBox4.Controls.Add(this.btnHoanTat);
            this.groupBox4.Controls.Add(this.btnLuuCTPKK);
            this.groupBox4.Controls.Add(this.btnXoaCTPKK);
            this.groupBox4.Controls.Add(this.btnThemCTPKK);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(668, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(889, 220);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin chi tiết";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(244, 32);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(120, 26);
            this.txtMaSP.TabIndex = 11;
            // 
            // nudSLTT
            // 
            this.nudSLTT.Location = new System.Drawing.Point(244, 123);
            this.nudSLTT.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSLTT.Name = "nudSLTT";
            this.nudSLTT.Size = new System.Drawing.Size(120, 26);
            this.nudSLTT.TabIndex = 10;
            // 
            // nudSLHT
            // 
            this.nudSLHT.Location = new System.Drawing.Point(244, 76);
            this.nudSLHT.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSLHT.Name = "nudSLHT";
            this.nudSLHT.Size = new System.Drawing.Size(120, 26);
            this.nudSLHT.TabIndex = 10;
            // 
            // btnChonSL
            // 
            this.btnChonSL.AutoSize = true;
            this.btnChonSL.Location = new System.Drawing.Point(444, 166);
            this.btnChonSL.Name = "btnChonSL";
            this.btnChonSL.Size = new System.Drawing.Size(157, 41);
            this.btnChonSL.TabIndex = 9;
            this.btnChonSL.Text = "Chọn theo số lượng";
            this.btnChonSL.UseVisualStyleBackColor = true;
            // 
            // btnToanBo
            // 
            this.btnToanBo.AutoSize = true;
            this.btnToanBo.Location = new System.Drawing.Point(287, 166);
            this.btnToanBo.Name = "btnToanBo";
            this.btnToanBo.Size = new System.Drawing.Size(157, 41);
            this.btnToanBo.TabIndex = 9;
            this.btnToanBo.Text = "Chọn toàn bộ";
            this.btnToanBo.UseVisualStyleBackColor = true;
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.AutoSize = true;
            this.btnHoanTat.Location = new System.Drawing.Point(130, 166);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(157, 41);
            this.btnHoanTat.TabIndex = 5;
            this.btnHoanTat.Text = "Hoàn tất";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            // 
            // btnLuuCTPKK
            // 
            this.btnLuuCTPKK.AutoSize = true;
            this.btnLuuCTPKK.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuCTPKK.Location = new System.Drawing.Point(6, 119);
            this.btnLuuCTPKK.Name = "btnLuuCTPKK";
            this.btnLuuCTPKK.Size = new System.Drawing.Size(75, 41);
            this.btnLuuCTPKK.TabIndex = 6;
            this.btnLuuCTPKK.UseVisualStyleBackColor = true;
            // 
            // btnXoaCTPKK
            // 
            this.btnXoaCTPKK.AutoSize = true;
            this.btnXoaCTPKK.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaCTPKK.Location = new System.Drawing.Point(6, 72);
            this.btnXoaCTPKK.Name = "btnXoaCTPKK";
            this.btnXoaCTPKK.Size = new System.Drawing.Size(75, 41);
            this.btnXoaCTPKK.TabIndex = 7;
            this.btnXoaCTPKK.UseVisualStyleBackColor = true;
            // 
            // btnThemCTPKK
            // 
            this.btnThemCTPKK.AutoSize = true;
            this.btnThemCTPKK.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemCTPKK.Location = new System.Drawing.Point(6, 25);
            this.btnThemCTPKK.Name = "btnThemCTPKK";
            this.btnThemCTPKK.Size = new System.Drawing.Size(75, 41);
            this.btnThemCTPKK.TabIndex = 8;
            this.btnThemCTPKK.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "SL thực tế";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "SL hệ thống";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã sản phẩm";
            // 
            // btnXoaToanBo
            // 
            this.btnXoaToanBo.AutoSize = true;
            this.btnXoaToanBo.Location = new System.Drawing.Point(601, 166);
            this.btnXoaToanBo.Name = "btnXoaToanBo";
            this.btnXoaToanBo.Size = new System.Drawing.Size(157, 41);
            this.btnXoaToanBo.TabIndex = 9;
            this.btnXoaToanBo.Text = "Xoá toàn bộ";
            this.btnXoaToanBo.UseVisualStyleBackColor = true;
            // 
            // frm_TaoPKK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1572, 898);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_TaoPKK";
            this.Text = "frm_TaoPKK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSP)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPKK)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLHT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvSP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCTPKK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaPKK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudSLHT;
        private System.Windows.Forms.Button btnToanBo;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnLuuCTPKK;
        private System.Windows.Forms.Button btnXoaCTPKK;
        private System.Windows.Forms.Button btnThemCTPKK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.NumericUpDown nudSLTT;
        private System.Windows.Forms.Button btnChonSL;
        private System.Windows.Forms.Button btnXoaToanBo;
    }
}