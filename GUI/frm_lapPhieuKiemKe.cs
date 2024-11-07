using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_lapPhieuKiemKe : Form
    {
        List<SanPham> sanPhams = new List<SanPham>();
        SanPhamBLL sanPhamBll = new SanPhamBLL();
        LoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
        public frm_lapPhieuKiemKe()
        {
            InitializeComponent();
            sanPhams = sanPhamBll.GetProductList();
            this.Load += Frm_lapPhieuKiemKe_Load;
            this.btnTao.Click += BtnTao_Click;
            this.dgv_DSSP.SelectionChanged += Dgv_DSSP_SelectionChanged;
        }

        private void Dgv_DSSP_SelectionChanged(object sender, EventArgs e)
        {
            txtMaSanPham.Text = dgv_DSSP.CurrentRow.Cells["MaSanPham"].Value.ToString();
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
            DateTime dateCreate = dtpNgayLap.ToString().Length > 0 ? dtpNgayLap.Value : DateTime.Now;            
        }

        private void Frm_lapPhieuKiemKe_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtTimTenSanPham, "Nhập tên sản phẩm");
            loadProductList();
            loadCombobox();
        }

        private void loadCombobox()
        {
            cbbLoaiSanPham.DataSource = loaiSanPhamBLL.GetAll();
            cbbLoaiSanPham.DisplayMember = "TenLoai";
            cbbLoaiSanPham.ValueMember = "MaLoai";
        }

        private void loadProductList()
        {

            dgv_DSSP.DataSource = sanPhams;

            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
            sttColumn.Name = "STT";
            sttColumn.HeaderText = "Số Thứ Tự";
            sttColumn.Width = 80;
            dgv_DSSP.Columns.Insert(0, sttColumn);
            for (int i = 0; i < dgv_DSSP.Rows.Count; i++)
            {
                dgv_DSSP.Rows[i].Cells["STT"].Value = i + 1;
            }


            dgv_DSSP.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgv_DSSP.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgv_DSSP.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgv_DSSP.Columns["SoLuongTon"].HeaderText = "Số lượng hệ thống";
            dgv_DSSP.Columns["SoLuongToiThieu"].HeaderText = "Số lượng tối thiểu";
            dgv_DSSP.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";

            dgv_DSSP.Columns["GiaNhap"].Visible = false;
            dgv_DSSP.Columns["GiaBan"].Visible = false;
            dgv_DSSP.Columns["MoTa"].Visible = false;
            dgv_DSSP.Columns["HinhAnh"].Visible = false;
            dgv_DSSP.Columns["TrangThai"].Visible = false;
            dgv_DSSP.Columns["NgayTao"].Visible = false;
            dgv_DSSP.Columns["MaLoai"].Visible = false;
            dgv_DSSP.Columns["LoaiSanPham"].Visible = false;
            

        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            // Gán sự kiện cho Enter và Leave
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

    }
}
