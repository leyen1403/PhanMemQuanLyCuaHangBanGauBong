namespace GUI
{
    partial class frm_quanLyPhieuKiemKe
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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLuuPKK = new System.Windows.Forms.Button();
            this.btnXoaPKK = new System.Windows.Forms.Button();
            this.btnTaoPKK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPKK = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvCTPKK = new System.Windows.Forms.DataGridView();
            this.nudSLHT = new System.Windows.Forms.NumericUpDown();
            this.nudSLTT = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudSLCL = new System.Windows.Forms.NumericUpDown();
            this.txtLyDoChenhLech = new System.Windows.Forms.TextBox();
            this.cboNhanVien = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPKK)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPKK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLHT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLCL)).BeginInit();
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
            this.label1.TabIndex = 3;
            this.label1.Text = "QUẢN LÝ PHIẾU KIỂM KÊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cboNhanVien);
            this.groupBox1.Controls.Add(this.nudSLTT);
            this.groupBox1.Controls.Add(this.nudSLCL);
            this.groupBox1.Controls.Add(this.nudSLHT);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMaPhieu);
            this.groupBox1.Controls.Add(this.txtLyDoChenhLech);
            this.groupBox1.Controls.Add(this.txtMaSP);
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnLuuPKK);
            this.groupBox1.Controls.Add(this.btnXoaPKK);
            this.groupBox1.Controls.Add(this.btnTaoPKK);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1467, 212);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(470, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "SL thực tế";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "SL hệ thống";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(470, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã sản phẩm";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(206, 125);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(189, 26);
            this.txtMaPhieu.TabIndex = 7;
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(581, 26);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(189, 26);
            this.txtMaSP.TabIndex = 7;
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLap.Location = new System.Drawing.Point(204, 29);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(189, 26);
            this.dtpNgayLap.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(126, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mã phiếu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Người tạo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày tạo";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.Image = global::GUI.Properties.Resources.icons8_update_32;
            this.btnLamMoi.Location = new System.Drawing.Point(6, 165);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 41);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuuPKK
            // 
            this.btnLuuPKK.AutoSize = true;
            this.btnLuuPKK.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuPKK.Location = new System.Drawing.Point(6, 118);
            this.btnLuuPKK.Name = "btnLuuPKK";
            this.btnLuuPKK.Size = new System.Drawing.Size(75, 41);
            this.btnLuuPKK.TabIndex = 2;
            this.btnLuuPKK.UseVisualStyleBackColor = true;
            // 
            // btnXoaPKK
            // 
            this.btnXoaPKK.AutoSize = true;
            this.btnXoaPKK.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaPKK.Location = new System.Drawing.Point(6, 71);
            this.btnXoaPKK.Name = "btnXoaPKK";
            this.btnXoaPKK.Size = new System.Drawing.Size(75, 41);
            this.btnXoaPKK.TabIndex = 3;
            this.btnXoaPKK.UseVisualStyleBackColor = true;
            // 
            // btnTaoPKK
            // 
            this.btnTaoPKK.AutoSize = true;
            this.btnTaoPKK.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnTaoPKK.Location = new System.Drawing.Point(6, 24);
            this.btnTaoPKK.Name = "btnTaoPKK";
            this.btnTaoPKK.Size = new System.Drawing.Size(75, 41);
            this.btnTaoPKK.TabIndex = 4;
            this.btnTaoPKK.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvPKK);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1467, 212);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách phiếu kiểm kê";
            // 
            // dgvPKK
            // 
            this.dgvPKK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPKK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPKK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPKK.Location = new System.Drawing.Point(3, 22);
            this.dgvPKK.Name = "dgvPKK";
            this.dgvPKK.Size = new System.Drawing.Size(1461, 187);
            this.dgvPKK.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCTPKK);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(12, 487);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1467, 470);
            this.groupBox3.TabIndex = 4;
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
            this.dgvCTPKK.Size = new System.Drawing.Size(1461, 445);
            this.dgvCTPKK.TabIndex = 0;
            // 
            // nudSLHT
            // 
            this.nudSLHT.Location = new System.Drawing.Point(581, 79);
            this.nudSLHT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSLHT.Name = "nudSLHT";
            this.nudSLHT.Size = new System.Drawing.Size(120, 26);
            this.nudSLHT.TabIndex = 9;
            // 
            // nudSLTT
            // 
            this.nudSLTT.Location = new System.Drawing.Point(581, 126);
            this.nudSLTT.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSLTT.Name = "nudSLTT";
            this.nudSLTT.Size = new System.Drawing.Size(120, 26);
            this.nudSLTT.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(849, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Lý do chênh lệch";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(849, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Chênh lệch";
            // 
            // nudSLCL
            // 
            this.nudSLCL.Location = new System.Drawing.Point(999, 27);
            this.nudSLCL.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSLCL.Name = "nudSLCL";
            this.nudSLCL.Size = new System.Drawing.Size(120, 26);
            this.nudSLCL.TabIndex = 9;
            // 
            // txtLyDoChenhLech
            // 
            this.txtLyDoChenhLech.Location = new System.Drawing.Point(999, 78);
            this.txtLyDoChenhLech.Multiline = true;
            this.txtLyDoChenhLech.Name = "txtLyDoChenhLech";
            this.txtLyDoChenhLech.Size = new System.Drawing.Size(327, 73);
            this.txtLyDoChenhLech.TabIndex = 7;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.FormattingEnabled = true;
            this.cboNhanVien.Location = new System.Drawing.Point(204, 78);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Size = new System.Drawing.Size(189, 28);
            this.cboNhanVien.TabIndex = 10;
            // 
            // frm_quanLyPhieuKiemKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 1015);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frm_quanLyPhieuKiemKe";
            this.Text = "frm_quanLyPhieuKiemKe";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPKK)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTPKK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLHT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSLCL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuuPKK;
        private System.Windows.Forms.Button btnXoaPKK;
        private System.Windows.Forms.Button btnTaoPKK;
        private System.Windows.Forms.DataGridView dgvPKK;
        private System.Windows.Forms.DataGridView dgvCTPKK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.NumericUpDown nudSLTT;
        private System.Windows.Forms.NumericUpDown nudSLCL;
        private System.Windows.Forms.NumericUpDown nudSLHT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLyDoChenhLech;
    }
}