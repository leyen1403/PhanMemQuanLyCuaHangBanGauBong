namespace GUI
{
    partial class frm_lapThongKeBaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabCrlDoanhThu = new System.Windows.Forms.TabControl();
            this.tabDanhThu = new System.Windows.Forms.TabPage();
            this.grbThongKe = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgvThongKe = new System.Windows.Forms.DataGridView();
            this.btnXemDoanhThu = new System.Windows.Forms.Button();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabSPBanChay = new System.Windows.Forms.TabPage();
            this.tabSoLuongTon = new System.Windows.Forms.TabPage();
            this.btnChuyen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnXuatDoanhThu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.tabCrlDoanhThu.SuspendLayout();
            this.tabDanhThu.SuspendLayout();
            this.grbThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).BeginInit();
            this.tabSPBanChay.SuspendLayout();
            this.tabSoLuongTon.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabCrlDoanhThu
            // 
            this.tabCrlDoanhThu.Controls.Add(this.tabDanhThu);
            this.tabCrlDoanhThu.Controls.Add(this.tabSPBanChay);
            this.tabCrlDoanhThu.Controls.Add(this.tabSoLuongTon);
            this.tabCrlDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCrlDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCrlDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.tabCrlDoanhThu.Name = "tabCrlDoanhThu";
            this.tabCrlDoanhThu.SelectedIndex = 0;
            this.tabCrlDoanhThu.Size = new System.Drawing.Size(1240, 857);
            this.tabCrlDoanhThu.TabIndex = 1;
            // 
            // tabDanhThu
            // 
            this.tabDanhThu.Controls.Add(this.cbbNhanVien);
            this.tabDanhThu.Controls.Add(this.label1);
            this.tabDanhThu.Controls.Add(this.btnXuatDoanhThu);
            this.tabDanhThu.Controls.Add(this.btnChuyen);
            this.tabDanhThu.Controls.Add(this.grbThongKe);
            this.tabDanhThu.Controls.Add(this.btnXemDoanhThu);
            this.tabDanhThu.Controls.Add(this.dtpNgayKT);
            this.tabDanhThu.Controls.Add(this.dtpNgayBD);
            this.tabDanhThu.Controls.Add(this.label12);
            this.tabDanhThu.Controls.Add(this.label11);
            this.tabDanhThu.Location = new System.Drawing.Point(4, 29);
            this.tabDanhThu.Name = "tabDanhThu";
            this.tabDanhThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDanhThu.Size = new System.Drawing.Size(1232, 824);
            this.tabDanhThu.TabIndex = 0;
            this.tabDanhThu.Text = "Doanh thu";
            this.tabDanhThu.UseVisualStyleBackColor = true;
            this.tabDanhThu.Click += new System.EventHandler(this.tabDanhThu_Click);
            // 
            // grbThongKe
            // 
            this.grbThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbThongKe.Controls.Add(this.chart1);
            this.grbThongKe.Controls.Add(this.dtgvThongKe);
            this.grbThongKe.Location = new System.Drawing.Point(23, 202);
            this.grbThongKe.Name = "grbThongKe";
            this.grbThongKe.Size = new System.Drawing.Size(1201, 576);
            this.grbThongKe.TabIndex = 50;
            this.grbThongKe.TabStop = false;
            this.grbThongKe.Text = "Thống kê doanh thu";
            // 
            // chart1
            // 
            chartArea6.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea6);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(3, 22);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(1195, 551);
            this.chart1.TabIndex = 45;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // dtgvThongKe
            // 
            this.dtgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThongKe.Location = new System.Drawing.Point(3, 22);
            this.dtgvThongKe.Name = "dtgvThongKe";
            this.dtgvThongKe.Size = new System.Drawing.Size(1195, 551);
            this.dtgvThongKe.TabIndex = 0;
            // 
            // btnXemDoanhThu
            // 
            this.btnXemDoanhThu.BackColor = System.Drawing.Color.Navy;
            this.btnXemDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemDoanhThu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXemDoanhThu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemDoanhThu.Location = new System.Drawing.Point(520, 20);
            this.btnXemDoanhThu.Name = "btnXemDoanhThu";
            this.btnXemDoanhThu.Size = new System.Drawing.Size(209, 38);
            this.btnXemDoanhThu.TabIndex = 49;
            this.btnXemDoanhThu.Text = "Xem danh thu";
            this.btnXemDoanhThu.UseVisualStyleBackColor = false;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKT.Location = new System.Drawing.Point(214, 78);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(230, 26);
            this.dtpNgayKT.TabIndex = 47;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBD.Location = new System.Drawing.Point(214, 30);
            this.dtpNgayBD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(230, 26);
            this.dtpNgayBD.TabIndex = 46;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(23, 81);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 20);
            this.label12.TabIndex = 45;
            this.label12.Text = "Chọn ngày kết thúc :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 35);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "Chọn ngày bắt đầu :";
            // 
            // tabSPBanChay
            // 
            this.tabSPBanChay.Controls.Add(this.groupBox1);
            this.tabSPBanChay.Location = new System.Drawing.Point(4, 29);
            this.tabSPBanChay.Name = "tabSPBanChay";
            this.tabSPBanChay.Padding = new System.Windows.Forms.Padding(3);
            this.tabSPBanChay.Size = new System.Drawing.Size(1232, 824);
            this.tabSPBanChay.TabIndex = 1;
            this.tabSPBanChay.Text = "Sản phẩm bán chạy";
            this.tabSPBanChay.UseVisualStyleBackColor = true;
            // 
            // tabSoLuongTon
            // 
            this.tabSoLuongTon.Controls.Add(this.groupBox2);
            this.tabSoLuongTon.Location = new System.Drawing.Point(4, 29);
            this.tabSoLuongTon.Name = "tabSoLuongTon";
            this.tabSoLuongTon.Size = new System.Drawing.Size(1232, 824);
            this.tabSoLuongTon.TabIndex = 2;
            this.tabSoLuongTon.Text = "Số lượng tồn";
            this.tabSoLuongTon.UseVisualStyleBackColor = true;
            // 
            // btnChuyen
            // 
            this.btnChuyen.BackColor = System.Drawing.Color.Navy;
            this.btnChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChuyen.Location = new System.Drawing.Point(520, 69);
            this.btnChuyen.Name = "btnChuyen";
            this.btnChuyen.Size = new System.Drawing.Size(209, 38);
            this.btnChuyen.TabIndex = 51;
            this.btnChuyen.Text = "Xem dưới dạng đồ thị";
            this.btnChuyen.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(23, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1201, 576);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê sản phẩm bán chạy";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1195, 551);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(16, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1201, 576);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê số lượng tồn kho";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 22);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(1195, 551);
            this.dataGridView2.TabIndex = 0;
            // 
            // btnXuatDoanhThu
            // 
            this.btnXuatDoanhThu.BackColor = System.Drawing.Color.Navy;
            this.btnXuatDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatDoanhThu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXuatDoanhThu.Location = new System.Drawing.Point(520, 122);
            this.btnXuatDoanhThu.Name = "btnXuatDoanhThu";
            this.btnXuatDoanhThu.Size = new System.Drawing.Size(209, 38);
            this.btnXuatDoanhThu.TabIndex = 51;
            this.btnXuatDoanhThu.Text = "Xuất doanh thu";
            this.btnXuatDoanhThu.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Chọn nhân viên xuất:";
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(214, 126);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(230, 28);
            this.cbbNhanVien.TabIndex = 53;
            // 
            // frm_lapThongKeBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 857);
            this.Controls.Add(this.tabCrlDoanhThu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_lapThongKeBaoCao";
            this.Text = "frm_lapThongKeBaoCao";
            this.tabCrlDoanhThu.ResumeLayout(false);
            this.tabDanhThu.ResumeLayout(false);
            this.tabDanhThu.PerformLayout();
            this.grbThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).EndInit();
            this.tabSPBanChay.ResumeLayout(false);
            this.tabSoLuongTon.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCrlDoanhThu;
        private System.Windows.Forms.TabPage tabDanhThu;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabSPBanChay;
        private System.Windows.Forms.TabPage tabSoLuongTon;
        private System.Windows.Forms.Button btnXemDoanhThu;
        private System.Windows.Forms.GroupBox grbThongKe;
        private System.Windows.Forms.DataGridView dtgvThongKe;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btnChuyen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnXuatDoanhThu;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.Label label1;
    }
}