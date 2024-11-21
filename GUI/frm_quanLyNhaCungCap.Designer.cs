namespace GUI
{
    partial class frm_quanLyNhaCungCap
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_NhaCC = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TenNhaCungCap = new System.Windows.Forms.TextBox();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_SoDienThoai = new System.Windows.Forms.TextBox();
            this.cb_HoatDong = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_NguoiDaiDien = new System.Windows.Forms.TextBox();
            this.lbl_MaNCC = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_TaiLai = new System.Windows.Forms.Button();
            this.lbl_NgayTao = new System.Windows.Forms.Label();
            this.lbl_NgayCapNhap = new System.Windows.Forms.Label();
            this.MaNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDaiDien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCapNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhaCC)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1800, 123);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(806, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý nhà cung cấp";
            // 
            // dgv_NhaCC
            // 
            this.dgv_NhaCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhaCC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhaCungCap,
            this.TenNhaCungCap,
            this.DiaChi,
            this.Email,
            this.SoDienThoai,
            this.NguoiDaiDien,
            this.NgayTao,
            this.NgayCapNhat,
            this.TrangThai});
            this.dgv_NhaCC.Location = new System.Drawing.Point(0, 558);
            this.dgv_NhaCC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_NhaCC.Name = "dgv_NhaCC";
            this.dgv_NhaCC.RowHeadersWidth = 51;
            this.dgv_NhaCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NhaCC.Size = new System.Drawing.Size(1800, 494);
            this.dgv_NhaCC.TabIndex = 1;
            this.dgv_NhaCC.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_NhaCC_CellFormatting);
            this.dgv_NhaCC.SelectionChanged += new System.EventHandler(this.dgv_NhaCC_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 297);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên nhà cung cấp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 196);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã nhà cung cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(136, 420);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(589, 196);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(547, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Số điện thoại";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1024, 412);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Trạng thái";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1033, 193);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ngày tạo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1015, 297);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Ngày cập nhật";
            // 
            // txt_TenNhaCungCap
            // 
            this.txt_TenNhaCungCap.Location = new System.Drawing.Point(249, 290);
            this.txt_TenNhaCungCap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_TenNhaCungCap.Name = "txt_TenNhaCungCap";
            this.txt_TenNhaCungCap.Size = new System.Drawing.Size(237, 22);
            this.txt_TenNhaCungCap.TabIndex = 11;
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(249, 412);
            this.txt_DiaChi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.Size = new System.Drawing.Size(237, 22);
            this.txt_DiaChi.TabIndex = 12;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(700, 190);
            this.txt_Email.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(259, 22);
            this.txt_Email.TabIndex = 13;
            // 
            // txt_SoDienThoai
            // 
            this.txt_SoDienThoai.Location = new System.Drawing.Point(700, 284);
            this.txt_SoDienThoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_SoDienThoai.Name = "txt_SoDienThoai";
            this.txt_SoDienThoai.Size = new System.Drawing.Size(259, 22);
            this.txt_SoDienThoai.TabIndex = 14;
            // 
            // cb_HoatDong
            // 
            this.cb_HoatDong.AutoSize = true;
            this.cb_HoatDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_HoatDong.Location = new System.Drawing.Point(1223, 416);
            this.cb_HoatDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cb_HoatDong.Name = "cb_HoatDong";
            this.cb_HoatDong.Size = new System.Drawing.Size(108, 24);
            this.cb_HoatDong.TabIndex = 15;
            this.cb_HoatDong.Text = "Hoạt động";
            this.cb_HoatDong.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(536, 416);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Người đại điện";
            // 
            // txt_NguoiDaiDien
            // 
            this.txt_NguoiDaiDien.Location = new System.Drawing.Point(700, 412);
            this.txt_NguoiDaiDien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_NguoiDaiDien.Name = "txt_NguoiDaiDien";
            this.txt_NguoiDaiDien.Size = new System.Drawing.Size(259, 22);
            this.txt_NguoiDaiDien.TabIndex = 17;
            // 
            // lbl_MaNCC
            // 
            this.lbl_MaNCC.AutoSize = true;
            this.lbl_MaNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaNCC.Location = new System.Drawing.Point(259, 196);
            this.lbl_MaNCC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MaNCC.Name = "lbl_MaNCC";
            this.lbl_MaNCC.Size = new System.Drawing.Size(137, 20);
            this.lbl_MaNCC.TabIndex = 18;
            this.lbl_MaNCC.Text = "Mã nhà cung cấp";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(531, 495);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 49);
            this.button1.TabIndex = 19;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(700, 495);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 47);
            this.button2.TabIndex = 20;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(860, 497);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 42);
            this.button3.TabIndex = 21;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1028, 497);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 44);
            this.button4.TabIndex = 22;
            this.button4.Text = "Tìm kiếm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_TaiLai
            // 
            this.btn_TaiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaiLai.Location = new System.Drawing.Point(1204, 500);
            this.btn_TaiLai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_TaiLai.Name = "btn_TaiLai";
            this.btn_TaiLai.Size = new System.Drawing.Size(100, 44);
            this.btn_TaiLai.TabIndex = 23;
            this.btn_TaiLai.Text = "Tải lại";
            this.btn_TaiLai.UseVisualStyleBackColor = true;
            this.btn_TaiLai.Click += new System.EventHandler(this.btn_TaiLai_Click);
            // 
            // lbl_NgayTao
            // 
            this.lbl_NgayTao.AutoSize = true;
            this.lbl_NgayTao.Location = new System.Drawing.Point(1219, 196);
            this.lbl_NgayTao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NgayTao.Name = "lbl_NgayTao";
            this.lbl_NgayTao.Size = new System.Drawing.Size(0, 16);
            this.lbl_NgayTao.TabIndex = 24;
            // 
            // lbl_NgayCapNhap
            // 
            this.lbl_NgayCapNhap.AutoSize = true;
            this.lbl_NgayCapNhap.Location = new System.Drawing.Point(1223, 297);
            this.lbl_NgayCapNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NgayCapNhap.Name = "lbl_NgayCapNhap";
            this.lbl_NgayCapNhap.Size = new System.Drawing.Size(0, 16);
            this.lbl_NgayCapNhap.TabIndex = 25;
            // 
            // MaNhaCungCap
            // 
            this.MaNhaCungCap.DataPropertyName = "MaNhaCungCap";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaNhaCungCap.DefaultCellStyle = dataGridViewCellStyle1;
            this.MaNhaCungCap.HeaderText = "Mã nhà cung cấp";
            this.MaNhaCungCap.MinimumWidth = 6;
            this.MaNhaCungCap.Name = "MaNhaCungCap";
            this.MaNhaCungCap.Width = 125;
            // 
            // TenNhaCungCap
            // 
            this.TenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenNhaCungCap.DefaultCellStyle = dataGridViewCellStyle2;
            this.TenNhaCungCap.HeaderText = "Tên nhà cung cấp";
            this.TenNhaCungCap.MinimumWidth = 6;
            this.TenNhaCungCap.Name = "TenNhaCungCap";
            this.TenNhaCungCap.Width = 125;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DiaChi.DefaultCellStyle = dataGridViewCellStyle3;
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 125;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email.DefaultCellStyle = dataGridViewCellStyle4;
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.Width = 125;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.DataPropertyName = "SoDienThoai";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SoDienThoai.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoDienThoai.HeaderText = "Số điện thoại";
            this.SoDienThoai.MinimumWidth = 6;
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.Width = 125;
            // 
            // NguoiDaiDien
            // 
            this.NguoiDaiDien.DataPropertyName = "NguoiDaiDien";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NguoiDaiDien.DefaultCellStyle = dataGridViewCellStyle6;
            this.NguoiDaiDien.HeaderText = "Người đại diện";
            this.NguoiDaiDien.MinimumWidth = 6;
            this.NguoiDaiDien.Name = "NguoiDaiDien";
            this.NguoiDaiDien.Width = 125;
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTao";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgayTao.DefaultCellStyle = dataGridViewCellStyle7;
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.MinimumWidth = 6;
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.Width = 125;
            // 
            // NgayCapNhat
            // 
            this.NgayCapNhat.DataPropertyName = "NgayCapNhat";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgayCapNhat.DefaultCellStyle = dataGridViewCellStyle8;
            this.NgayCapNhat.HeaderText = "Ngày cập nhật";
            this.NgayCapNhat.MinimumWidth = 6;
            this.NgayCapNhat.Name = "NgayCapNhat";
            this.NgayCapNhat.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangThai.DefaultCellStyle = dataGridViewCellStyle9;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // frm_quanLyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1805, 1055);
            this.Controls.Add(this.lbl_NgayCapNhap);
            this.Controls.Add(this.lbl_NgayTao);
            this.Controls.Add(this.btn_TaiLai);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_MaNCC);
            this.Controls.Add(this.txt_NguoiDaiDien);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_HoatDong);
            this.Controls.Add(this.txt_SoDienThoai);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_DiaChi);
            this.Controls.Add(this.txt_TenNhaCungCap);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_NhaCC);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frm_quanLyNhaCungCap";
            this.Text = "frm_quanLyNhaCungCap";
            this.Load += new System.EventHandler(this.frm_quanLyNhaCungCap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhaCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_NhaCC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TenNhaCungCap;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_SoDienThoai;
        private System.Windows.Forms.CheckBox cb_HoatDong;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_NguoiDaiDien;
        private System.Windows.Forms.Label lbl_MaNCC;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_TaiLai;
        private System.Windows.Forms.Label lbl_NgayTao;
        private System.Windows.Forms.Label lbl_NgayCapNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoDienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiDaiDien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}