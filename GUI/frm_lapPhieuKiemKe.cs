using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class frm_lapPhieuKiemKe : Form
    {
        string _maNhanVien = "NV001";
        List<SanPham> sanPhams = new List<SanPham>();
        SanPhamBLL sanPhamBll = new SanPhamBLL();
        LoaiSanPhamBLL loaiSanPhamBLL = new LoaiSanPhamBLL();
        PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
        ChiTietPhieuKiemKeBLL chiTietPhieuKiemKeBLL = new ChiTietPhieuKiemKeBLL();
        string _maPhieuKiemKe = "";
        string _tenNhanVien = "";
        DateTime _ngayLap = DateTime.Now;
        NhanVien _nhanVien = new NhanVien();
        List<SanPham> _dsSanPhamTrongPhieuKiemKe = new List<SanPham>();
        List<ChiTietPhieuKiemKe> _dsChiTietPhieuKiemKe = new List<ChiTietPhieuKiemKe>();
        public frm_lapPhieuKiemKe()
        {
            InitializeComponent();
            sanPhams = sanPhamBll.GetProductList();
            this.Load += Frm_lapPhieuKiemKe_Load;
            this.btnTao.Click += BtnTao_Click;
            this.dgv_DSSP.SelectionChanged += Dgv_DSSP_SelectionChanged;
            this.txtSoLuongThucTe.TextChanged += TxtSoLuongThucTe_TextChanged;
            this.cbbLoaiSanPham.SelectedIndexChanged += CbbLoaiSanPham_SelectedIndexChanged;
            this.btnTim.Click += BtnTim_Click;
            this.dgvDSChiTietPhieuKiemKe.SelectionChanged += DgvDSChiTietPhieuKiemKe_SelectionChanged;
            this.cbbMaPhieuKiemKe.SelectedIndexChanged += CbbMaPhieuKiemKe_SelectedIndexChanged;
            this.btnCapNhat.Click += BtnCapNhat_Click;
            
        }

        private void DgvDSChiTietPhieuKiemKe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDSChiTietPhieuKiemKe.CurrentRow != null &&
                dgvDSChiTietPhieuKiemKe.CurrentRow.Cells["MaSanPham"].Value != null)
            {
                string _maPhieuKiemKe = cbbMaPhieuKiemKe.SelectedValue?.ToString();
                string maSanPham = dgvDSChiTietPhieuKiemKe.CurrentRow.Cells["MaSanPham"].Value.ToString();
                int soLuongHeThong = Convert.ToInt32(dgvDSChiTietPhieuKiemKe.CurrentRow.Cells["SoLuongHeThong"].Value);
                int soLuongThucTe = Convert.ToInt32(dgvDSChiTietPhieuKiemKe.CurrentRow.Cells["SoLuongThucTe"].Value);

                SanPham sp = sanPhamBll.GetProductById(maSanPham);
                int soLuongToiThieu = (int)sp.SoLuongToiThieu;
                int soLuongChenhLech = Math.Abs(soLuongHeThong - soLuongThucTe);

                // Cập nhật các trường thông tin trong form
                txtMaSanPham.Text = maSanPham;
                txtTenSanPham.Text = sp.TenSanPham;
                txtSoLuongHeThong.Value = soLuongHeThong;
                txtSoLuongTonKhoToiThieu.Text = soLuongToiThieu.ToString();
                txtSoLuongThucTe.Value = soLuongThucTe;
                txtSoLuongChenhLech.Text = soLuongChenhLech.ToString();
            }
        }


        private void CbbMaPhieuKiemKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dsChiTietPhieuKiemKe = chiTietPhieuKiemKeBLL.chiTietPhieuKiemKes(cbbMaPhieuKiemKe.SelectedValue.ToString());
            dgvDSChiTietPhieuKiemKe.DataSource = _dsChiTietPhieuKiemKe;
            txtNhanVienLap.Text = _tenNhanVien;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            ChiTietPhieuKiemKe ct = new ChiTietPhieuKiemKe();
            ct.MaPhieuKiemKe = cbbMaPhieuKiemKe.SelectedValue.ToString();
            ct.MaSanPham = txtMaSanPham.Text;
            ct.SoLuongThucTe = Convert.ToInt32(txtSoLuongThucTe.Value);
            ct.SoLuongHeThong = Convert.ToInt32(txtSoLuongHeThong.Value);
            _ngayLap = DateTime.Now;
            SanPham sp = new SanPham();
            PhieuKiemKe phieuKiemKe = new PhieuKiemKe();
            string maPhieuKiemKe = cbbMaPhieuKiemKe.SelectedValue.ToString();
            phieuKiemKe = phieuKiemKeBLL.GetPhieuKiemKeById(maPhieuKiemKe);
            sp = sanPhamBll.GetProductById(ct.MaSanPham);
            if (chiTietPhieuKiemKeBLL.UpdateChiTietPhieuKiemKe(ct))
            {                
                sp.SoLuongTon = ct.SoLuongThucTe;
                sp.NgayCapNhat = _ngayLap;
                phieuKiemKe.GhiChu = txtGhiChu.Text;
                phieuKiemKe.MaNhanVien = _maNhanVien;
                phieuKiemKeBLL.UpdatePhieuKiemKe(phieuKiemKe);
                sanPhamBll.UpdateProduct(sp);
                MessageBox.Show("Cập nhật thành công");
            }
            else if(chiTietPhieuKiemKeBLL.InsertChiTietPhieuKiemKe(ct))
            {
                sp.SoLuongTon = ct.SoLuongThucTe;
                sp.NgayCapNhat = _ngayLap;
                phieuKiemKe.GhiChu = txtGhiChu.Text;
                phieuKiemKe.MaNhanVien = _maNhanVien;
                phieuKiemKeBLL.UpdatePhieuKiemKe(phieuKiemKe);
                sanPhamBll.UpdateProduct(sp);
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            dgvDSChiTietPhieuKiemKe.DataSource = chiTietPhieuKiemKeBLL.chiTietPhieuKiemKes(cbbMaPhieuKiemKe.SelectedValue.ToString());
            dgv_DSSP.DataSource = sanPhamBll.GetProductList();

        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string tenSanPham = txtTimTenSanPham.Text;
            if (tenSanPham == "Nhập tên sản phẩm" || tenSanPham == "")
            {
                dgv_DSSP.DataSource = sanPhams;
                return;
            }
            List<SanPham> newList = new List<SanPham>();
            newList = sanPhams.Where(sp => sp.TenSanPham.ToLower().Contains(tenSanPham.ToLower())).ToList();
            dgv_DSSP.DataSource = newList;
        }

        private void CbbLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbLoaiSanPham.SelectedIndex == 0)
            {
                dgv_DSSP.DataSource = sanPhams;
                return;
            }
            List<SanPham> newList = new List<SanPham>();
            newList = sanPhams.Where(sp => sp.MaLoai == cbbLoaiSanPham.SelectedValue.ToString()).ToList();
            dgv_DSSP.DataSource = newList;
        }

        private void TxtSoLuongThucTe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int soLuongHeThong = Convert.ToInt32(txtSoLuongHeThong.Value);
                int soLuongThucTe = Convert.ToInt32(txtSoLuongThucTe.Text);
                int soLuongChenhLech = soLuongHeThong - soLuongThucTe;
                if(soLuongChenhLech < 0)
                {
                    soLuongChenhLech *= -1;
                }
                txtSoLuongChenhLech.Text = soLuongChenhLech.ToString();
            }
            catch
            {
                return;
            }
        }

        private void Dgv_DSSP_SelectionChanged(object sender, EventArgs e)
        {
            string maSanPham = dgv_DSSP.CurrentRow.Cells["MaSanPham"].Value.ToString();
            string tenSanPham = dgv_DSSP.CurrentRow.Cells["TenSanPham"].Value.ToString();
            int soLuongHeThong = Convert.ToInt32(dgv_DSSP.CurrentRow.Cells["SoLuongTon"].Value);
            int soLuongToiThieu = Convert.ToInt32(dgv_DSSP.CurrentRow.Cells["SoLuongToiThieu"].Value);
            int soLuongThucTe = soLuongHeThong;
            int soLuongChenhLech = soLuongHeThong - soLuongThucTe;
            SanPham sp = sanPhamBll.GetProductById(maSanPham);
            _ngayLap =(DateTime) sp.NgayCapNhat;
            if (soLuongChenhLech < 0)
            {
                soLuongChenhLech *= -1;
            }

            txtMaSanPham.Text = maSanPham;
            txtSoLuongHeThong.Value = soLuongHeThong;
            txtSoLuongTonKhoToiThieu.Text = soLuongToiThieu.ToString();
            txtTenSanPham.Text = tenSanPham;
            txtSoLuongThucTe.Value = soLuongHeThong;
            txtSoLuongChenhLech.Text = soLuongChenhLech.ToString();
        }

        private void BtnTao_Click(object sender, EventArgs e)
        {
            loadProductList();                        
            DateTime dateCreate = dtpNgayLap.ToString().Length > 0 ? dtpNgayLap.Value : DateTime.Now;
            try
            {
                PhieuKiemKe phieuKiemKe = new PhieuKiemKe();
                phieuKiemKe.MaPhieuKiemKe = taoMaPhieuKiemKe();
                phieuKiemKe.NgayLap = dateCreate;                
                phieuKiemKe.MaNhanVien = _maNhanVien;
                phieuKiemKe.GhiChu = txtGhiChu.Text;
                if (phieuKiemKeBLL.InsertPhieuKiemKe(phieuKiemKe))
                {
                    MessageBox.Show("Tạo phiếu kiểm kê thành công");
                    loadCombobox();
                    cbbMaPhieuKiemKe.SelectedIndex = cbbMaPhieuKiemKe.Items.Count - 1;
                }                
            }
            catch
            {
                return;
            }
        }

        private string taoMaPhieuKiemKe()
        {
            string maPhieuKiemKe = "";
            int soLuongPhieuKiemKe = phieuKiemKeBLL.GetListPhieuKiemKe().Count;
            if (soLuongPhieuKiemKe == 0)
            {
                maPhieuKiemKe = "PKK001";
            }
            else
            {
                maPhieuKiemKe = "PKK" + (soLuongPhieuKiemKe + 1).ToString("000");
            }
            return maPhieuKiemKe;
        }

        private void Frm_lapPhieuKiemKe_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtTimTenSanPham, "Nhập tên sản phẩm");
            string maPhieuKiemKe = taoMaPhieuKiemKe();
            _maPhieuKiemKe = maPhieuKiemKe;            
            string tenNhanVien = "Nguyen Van A";
            _tenNhanVien = tenNhanVien;
            txtNhanVienLap.Text = tenNhanVien;
            loadProductList();
            loadCombobox();
            loadChiTietKiemKe();
        }

        private void loadChiTietKiemKe()
        {
            string maPhieuKiemKe = cbbMaPhieuKiemKe.SelectedValue.ToString();
            dgvDSChiTietPhieuKiemKe.DataSource = chiTietPhieuKiemKeBLL.chiTietPhieuKiemKes(maPhieuKiemKe);

            dgvDSChiTietPhieuKiemKe.Columns["MaPhieuKiemKe"].Visible = false;
            dgvDSChiTietPhieuKiemKe.Columns["PhieuKiemKe"].Visible = false;
            dgvDSChiTietPhieuKiemKe.Columns["SanPham"].Visible = false;

            dgvDSChiTietPhieuKiemKe.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvDSChiTietPhieuKiemKe.Columns["SoLuongHeThong"].HeaderText = "Số lượng hệ thống";
            dgvDSChiTietPhieuKiemKe.Columns["SoLuongThucTe"].HeaderText = "Số lượng thực tế";
        }

        // Load du lieu vao combobox
        private void loadCombobox()
        {
            var loaiSanPhams = loaiSanPhamBLL.GetAll();
            loaiSanPhams.Insert(0, new LoaiSanPham { MaLoai = "TatCa", TenLoai = "Tất cả" });
            cbbLoaiSanPham.DataSource = loaiSanPhams;
            cbbLoaiSanPham.DisplayMember = "TenLoai";
            cbbLoaiSanPham.ValueMember = "MaLoai";

            var phieuKiemKes = phieuKiemKeBLL.GetListPhieuKiemKe();
            cbbMaPhieuKiemKe.DataSource = phieuKiemKes;
            cbbMaPhieuKiemKe.DisplayMember = "MaPhieuKiemKe";
            cbbMaPhieuKiemKe.ValueMember = "MaPhieuKiemKe";
        }

        // Hien thi du lieu danh sach san pham vao dgv_DSSP
        private void loadProductList()
        {
            dgv_DSSP.DataSource = null;
            dgv_DSSP.DataSource = sanPhamBll.GetProductList();

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

        // Tao hieu ung placeholder cho textbox
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
