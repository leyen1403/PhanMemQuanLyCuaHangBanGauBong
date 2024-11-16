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
using DTO;

namespace GUI
{
    public partial class frm_lapPhieuDoiTra : Form
    {
        PhieuDoiTraBLL bll;
        private List<ChiTietHoaDonDTO> chiTietHoaDonDTOs;
        public frm_lapPhieuDoiTra()
        {
            InitializeComponent();
            bll = new PhieuDoiTraBLL();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maHD = txtNoiDung.Text.Trim();
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hoá đơn!!!");
                return;
            }

            var hoaDon = bll.TimHoaDonTheoMa(maHD);
            if (hoaDon == null)
            {
                MessageBox.Show("Không tìm thấy hoá đơn!!!");
                clearData();
                return;
            }

            lblMaHD.Text = hoaDon.MaHoaDon;
            lblNgayLap.Text = hoaDon.NgayLap.ToString();
            lblTongSP.Text = hoaDon.TongSanPham.ToString();
            lblTongTien.Text = hoaDon.TongTien.ToString();
            lblDiemCongTL.Text = hoaDon.DiemCongTichLuy.ToString();
            lblDiemTL.Text = hoaDon.DiemTichLuy.ToString();
            lblMaKH.Text = hoaDon.MaKhachHang;
            lblTenKH.Text = hoaDon.TenKhachHang;
            lblMaNV.Text = hoaDon.MaNhanVien;
            lblTenNV.Text = hoaDon.TenNhanVien;

            loadCTHD(maHD);
        }

        private void clearData()
        {
            clearThongTinHD();
            clearPhieuDoiTra();
        }

        private void clearThongTinHD()
        {
            lblMaHD.Text = string.Empty;
            lblNgayLap.Text = string.Empty;
            lblTongSP.Text = string.Empty;
            lblTongTien.Text = string.Empty;
            lblDiemCongTL.Text = string.Empty;
            lblDiemTL.Text = string.Empty;
            lblMaKH.Text = string.Empty;
            lblTenKH.Text = string.Empty;
            lblMaNV.Text = string.Empty;
            lblTenNV.Text = string.Empty;

            dgvCTHD.DataSource = null;
        }

        private void clearPhieuDoiTra()
        {
            cboSanPham.Enabled = false;
            btnLuu.Enabled = false;
            txtLyDoDoiTra.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            nudSLDoi.Value = 0;
            nudSLDoi.Maximum = 100;
            txtGhiChu.Text = string.Empty;
            lblTongTienHoan.Text = string.Empty;

            dgvCTHD.DataSource = null;
        }

        private void loadCTHD(string maHD)
        {
            chiTietHoaDonDTOs = bll.LayDSChiTietHD(maHD);
            dgvCTHD.DataSource = chiTietHoaDonDTOs;
            loadCboSanPham(chiTietHoaDonDTOs);
        }

        private void frm_lapPhieuDoiTra_Load(object sender, EventArgs e)
        {
            initDgvCTHD();
            initCboSanPham();
        }

        private void initDgvCTHD()
        {
            dgvCTHD.Columns[0].DataPropertyName = "MaChiTietHD";
            dgvCTHD.Columns[1].DataPropertyName = "MaSanPham";
            dgvCTHD.Columns[2].DataPropertyName = "TenSanPham";
            dgvCTHD.Columns[3].DataPropertyName = "SoLuong";
            dgvCTHD.Columns[4].DataPropertyName = "DonGia";
            dgvCTHD.Columns[5].DataPropertyName = "ThanhTien";
            dgvCTHD.Columns[6].DataPropertyName = "GhiChu";
        }

        private void initCboSanPham()
        {
            cboSanPham.Text = "Chưa có dữ liệu";
            cboSanPham.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void loadCboSanPham(IEnumerable<ChiTietHoaDonDTO> dto)
        {
            cboSanPham.DataSource = dto;
            cboSanPham.ValueMember = "MaChiTietHD";
            cboSanPham.DisplayMember = "TenSanPham";
            cboSanPham.Enabled = true;
            btnLuu.Enabled = true;
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            int indexSelected = cbo.SelectedIndex;
            nudSLDoi.Value = 0;
            nudSLDoi.Maximum = chiTietHoaDonDTOs[indexSelected].SoLuong.Value;
        }

        private void nudSLDoi_ValueChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCTHD.CurrentRow;
            if (row != null)
            {
                lblTongTienHoan.Text = (nudSLDoi.Value * Convert.ToDecimal(row.Cells["DonGia"].Value)).ToString();
            }
            else lblTongTienHoan.Text = string.Empty;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtLyDoDoiTra.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Lý do đổi trả!!!");
                return;
            }

            if (txtTinhTrang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Tình trạng của sản phẩm!!!");
                return;
            }

            if (nudSLDoi.Value == 0)
            {
                MessageBox.Show("Vui lòng nhập Số lượng cần đổi!!!");
                return;
            }

            var dto = new PhieuDoiTraDTO()
            {
                MaChiTietHD = cboSanPham.SelectedValue.ToString(),
                MaNhanVien = "NV003",
                LyDoDoiTra = txtLyDoDoiTra.Text.Trim(),
                TinhTrangSanPham = txtTinhTrang.Text.Trim(),
                SoLuongDoi = int.Parse(nudSLDoi.Value.ToString()),
                TongTienHoan = Convert.ToDecimal(lblTongTienHoan.Text),
                GhiChu = txtGhiChu.Text.Trim()
            };

            int result = bll.TaoPhieuDoiTra(dto);

            if (result == 1)
            {
                MessageBox.Show("Tạo phiếu thành công!!!");
                txtNoiDung.Text = string.Empty;
                clearData();
            }
            else
            {
                MessageBox.Show("Tạo phiếu thất bại!!!");
            }
        }
    }
}
