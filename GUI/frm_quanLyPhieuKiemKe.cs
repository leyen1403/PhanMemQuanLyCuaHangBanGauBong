using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.Drawing.Internal.Fonts;
using DTO;

namespace GUI
{
    public partial class frm_quanLyPhieuKiemKe : Form
    {
        int _tongChenhLech = 0, _tongChenhLechGia = 0;
        List<PhieuKiemKe> _ListPhieuKiemKe = new List<PhieuKiemKe>();
        PhieuKiemKeBLL _PhieuKiemKeBLL = new PhieuKiemKeBLL();

        List<ChiTietPhieuKiemKe> _ListChiTietPKK = new List<ChiTietPhieuKiemKe>();
        ChiTietPhieuKiemKeBLL _ChiTietPhieuKiemKeBLL = new ChiTietPhieuKiemKeBLL();

        List<SanPham> _ListSanPham = new List<SanPham>();
        SanPhamBLL _SanPhamBLL = new SanPhamBLL();

        NhanVienBLL _NhanVienBLL = new NhanVienBLL();
        public frm_quanLyPhieuKiemKe()
        {
            InitializeComponent();
            this.Load += Frm_quanLyPhieuKiemKe_Load;
            this.btnTim.Click += BtnTim_Click;
            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            this.btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string ghiChu = txtGhiChu.Text;
            string maPhieuKiemKe = dataGridView1.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
            bool result = _PhieuKiemKeBLL.UpdateGhiChu(maPhieuKiemKe, ghiChu);
            if (result)
            {
                MessageBox.Show("Cập nhật ghi chú thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật ghi chú thất bại");
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string selectedValue = cbbLuaChonHienThi.SelectedItem.ToString();
            CachHienThi(selectedValue);
        }

        private void CachHienThi(string selectedValue)
        {
            if (selectedValue == "Tất cả phiếu kiểm kê" || selectedValue == "Phiếu theo ngày lập" || selectedValue == "Phiếu theo nhân viên")
            {
                string maPhieuKiemKe = dataGridView1.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
                _ListChiTietPKK = _ChiTietPhieuKiemKeBLL.chiTietPhieuKiemKes(maPhieuKiemKe);
                dataGridView2.DataSource = _ListChiTietPKK;
                dataGridView2.Columns["MaPhieuKiemKe"].Visible = false;
                dataGridView2.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                dataGridView2.Columns["SoLuongHeThong"].HeaderText = "Số lượng hệ thống";
                dataGridView2.Columns["SoLuongThucTe"].HeaderText = "Số lượng thực tế";
                dataGridView2.Columns["PhieuKiemKe"].Visible = false;
                dataGridView2.Columns["SanPham"].Visible = false;
                _tongChenhLech = 0;
                _tongChenhLechGia = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    row.Cells["STT"].Value = row.Index + 1;
                    string tenSanPham = "";
                    decimal giaSanPham = 0;
                    string maSanPham = row.Cells["MaSanPham"].Value.ToString();
                    SanPham sp = _SanPhamBLL.GetProductById(maSanPham);
                    tenSanPham = sp.TenSanPham;
                    giaSanPham = (decimal)sp.GiaNhap;
                    row.Cells["TenSanPham"].Value = tenSanPham;
                    int soLuongHeThong = Convert.ToInt32(row.Cells["SoLuongHeThong"].Value.ToString());
                    int soLuongThucTe = Convert.ToInt32(row.Cells["SoLuongThucTe"].Value.ToString());
                    int soLuongChenhLech = Math.Abs(soLuongHeThong - soLuongThucTe);
                    _tongChenhLech += soLuongChenhLech;
                    _tongChenhLechGia += (int)(soLuongChenhLech * giaSanPham);
                    row.Cells["ChenhLech"].Value = soLuongChenhLech;
                }
                dataGridView2.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
                dataGridView2.Columns["ChenhLech"].HeaderText = "Chênh lệch";

                dataGridView2.Columns["STT"].DisplayIndex = 0;
                dataGridView2.Columns["MaSanPham"].DisplayIndex = 1;
                dataGridView2.Columns["TenSanPham"].DisplayIndex = 2;
                dataGridView2.Columns["SoLuongHeThong"].DisplayIndex = 3;
                dataGridView2.Columns["SoLuongThucTe"].DisplayIndex = 4;
                dataGridView2.Columns["ChenhLech"].DisplayIndex = 5;
                string maNhanVien = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                NhanVien nv = _NhanVienBLL.GetNhanVienById(maNhanVien);
                string tenNhanVien = nv.HoTen;
                txtTenNhanVien.Text = tenNhanVien;
                txtTongChenhLech.Text = _tongChenhLech.ToString();
                DateTime ngayLap = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["NgayLap"].Value.ToString());
                dtpNgayLap.Value = ngayLap;
                txtTongChenhLechGia.Text = _tongChenhLechGia.ToString("N0");
                string ghiChu = dataGridView1.CurrentRow.Cells["GhiChu"].Value.ToString();
                txtGhiChu.Text = ghiChu;
            }

        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string selectedValue = cbbLuaChonHienThi.SelectedItem.ToString();
            if(selectedValue == "Tất cả phiếu kiểm kê")
            {
                _ListPhieuKiemKe = _PhieuKiemKeBLL.GetListPhieuKiemKe();
                dataGridView1.DataSource = _ListPhieuKiemKe;
                loadDgv1DangDanhSachPhieuKiemKe();
            }
            if (selectedValue == "Phiếu theo ngày lập")
            {
                DateTime ngayBatDau = dtpTuNgay.Value;
                DateTime ngayKetThuc = dtpDenNgay.Value;
                _ListPhieuKiemKe = _PhieuKiemKeBLL.GetListPhieuKiemKeByDate(ngayBatDau, ngayKetThuc);
                dataGridView1.DataSource = _ListPhieuKiemKe;
                loadDgv1DangDanhSachPhieuKiemKe();
            }
            if(selectedValue == "Phiếu theo nhân viên")
            {
                string maNhanVien = cbbMaNhanVien.SelectedValue.ToString();
                _ListPhieuKiemKe = _PhieuKiemKeBLL.GetListPhieuKiemKeByNhanVien(maNhanVien);
                dataGridView1.DataSource = _ListPhieuKiemKe;
                loadDgv1DangDanhSachPhieuKiemKe();
            }
        }

        private void loadDgv1DangDanhSachPhieuKiemKe()
        {
            dataGridView1.Columns["MaPhieuKiemKe"].HeaderText = "Mã phiếu";
            dataGridView1.Columns["NgayLap"].HeaderText = "Ngày lập";
            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["NhanVien"].Visible = false;
            dataGridView1.Columns["GhiChu"].Visible = false;
            dataGridView1.Columns["TenNhanVien"].Visible = false;
            dataGridView1.Columns["STT"].DisplayIndex = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["STT"].Value = row.Index + 1;
            }
        }

        private void Frm_quanLyPhieuKiemKe_Load(object sender, EventArgs e)
        {
            cbbLuaChonHienThi.SelectedIndex = 0;     
            cbbMaNhanVien.DataSource = _NhanVienBLL.getAllNhanVien();
            cbbMaNhanVien.DisplayMember = "HoTen";
            cbbMaNhanVien.ValueMember = "MaNhanVien";
        }
    }
}
