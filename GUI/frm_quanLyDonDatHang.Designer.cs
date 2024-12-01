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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDDH = new System.Windows.Forms.DataGridView();
            this.dgvCTDDH = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLuuDuLieu = new System.Windows.Forms.Button();
            this.btnXoaDonDatHang = new System.Windows.Forms.Button();
            this.btnTaoDonDatHang = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).BeginInit();
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
            this.label1.TabIndex = 1;
            this.label1.Text = "QUẢN LÝ ĐƠN ĐẶT HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnLamMoi);
            this.groupBox1.Controls.Add(this.btnLuuDuLieu);
            this.groupBox1.Controls.Add(this.btnXoaDonDatHang);
            this.groupBox1.Controls.Add(this.btnTaoDonDatHang);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1467, 247);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvDDH);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(12, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1467, 366);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách đơn đặt hàng";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvCTDDH);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(9, 676);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1467, 257);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin chi tiết đơn đặt hàng";
            // 
            // dgvDDH
            // 
            this.dgvDDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDDH.Location = new System.Drawing.Point(3, 22);
            this.dgvDDH.Name = "dgvDDH";
            this.dgvDDH.Size = new System.Drawing.Size(1461, 341);
            this.dgvDDH.TabIndex = 0;
            // 
            // dgvCTDDH
            // 
            this.dgvCTDDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTDDH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCTDDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTDDH.Location = new System.Drawing.Point(3, 22);
            this.dgvCTDDH.Name = "dgvCTDDH";
            this.dgvCTDDH.Size = new System.Drawing.Size(1461, 232);
            this.dgvCTDDH.TabIndex = 0;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.AutoSize = true;
            this.btnLamMoi.Image = global::GUI.Properties.Resources.icons8_update_32;
            this.btnLamMoi.Location = new System.Drawing.Point(6, 173);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 41);
            this.btnLamMoi.TabIndex = 0;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnLuuDuLieu
            // 
            this.btnLuuDuLieu.AutoSize = true;
            this.btnLuuDuLieu.Image = global::GUI.Properties.Resources.icons8_save_as_32;
            this.btnLuuDuLieu.Location = new System.Drawing.Point(6, 126);
            this.btnLuuDuLieu.Name = "btnLuuDuLieu";
            this.btnLuuDuLieu.Size = new System.Drawing.Size(75, 41);
            this.btnLuuDuLieu.TabIndex = 0;
            this.btnLuuDuLieu.UseVisualStyleBackColor = true;
            // 
            // btnXoaDonDatHang
            // 
            this.btnXoaDonDatHang.AutoSize = true;
            this.btnXoaDonDatHang.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaDonDatHang.Location = new System.Drawing.Point(6, 79);
            this.btnXoaDonDatHang.Name = "btnXoaDonDatHang";
            this.btnXoaDonDatHang.Size = new System.Drawing.Size(75, 41);
            this.btnXoaDonDatHang.TabIndex = 0;
            this.btnXoaDonDatHang.UseVisualStyleBackColor = true;
            // 
            // btnTaoDonDatHang
            // 
            this.btnTaoDonDatHang.AutoSize = true;
            this.btnTaoDonDatHang.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnTaoDonDatHang.Location = new System.Drawing.Point(6, 32);
            this.btnTaoDonDatHang.Name = "btnTaoDonDatHang";
            this.btnTaoDonDatHang.Size = new System.Drawing.Size(75, 41);
            this.btnTaoDonDatHang.TabIndex = 0;
            this.btnTaoDonDatHang.UseVisualStyleBackColor = true;
            // 
            // frm_quanLyDonDatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 1015);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_quanLyDonDatHang";
            this.Text = "frm_quanLyDonDatHang";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDDH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDDH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDDH;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvCTDDH;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnLuuDuLieu;
        private System.Windows.Forms.Button btnXoaDonDatHang;
        private System.Windows.Forms.Button btnTaoDonDatHang;
    }
}