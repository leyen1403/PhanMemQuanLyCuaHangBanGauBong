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
    public partial class frm_quanLyDoiTraSanPham : Form
    {
        PhieuDoiTraBLL bll;
        public frm_quanLyDoiTraSanPham()
        {
            InitializeComponent();
            bll = new PhieuDoiTraBLL();
        }

        private void frm_quanLyDoiTraSanPham_Load(object sender, EventArgs e)
        {
            initDgvPhieuDT();
            loadDataDgvPhieuDoiTra();
            initNhapLieu(false);
        }

        private void initDgvPhieuDT()
        {
            dgvPhieuDoiTra.AutoGenerateColumns = false;
            dgvPhieuDoiTra.Columns[0].DataPropertyName = "MaPhieuDoiTra";
            dgvPhieuDoiTra.Columns[1].DataPropertyName = "NgayLap";
            dgvPhieuDoiTra.Columns[2].DataPropertyName = "LyDoDoiTra";
            dgvPhieuDoiTra.Columns[3].DataPropertyName = "TinhTrangSanPham";
            dgvPhieuDoiTra.Columns[4].DataPropertyName = "SoLuong";
            dgvPhieuDoiTra.Columns[5].DataPropertyName = "TongTienHoanLai";
            dgvPhieuDoiTra.Columns[6].DataPropertyName = "GhiChuThem";
            dgvPhieuDoiTra.Columns[7].DataPropertyName = "NgayCapNhat";
            dgvPhieuDoiTra.Columns[8].DataPropertyName = "MaNhanVien";
            dgvPhieuDoiTra.Columns[9].DataPropertyName = "MaChiTietDonBanHang";
        }

        private void loadDataDgvPhieuDoiTra()
        {
            dgvPhieuDoiTra.DataSource = bll.LayDSPhieuDoiTra();
        }

        private void initNhapLieu(bool b)
        {
            btnSua.Enabled = !b;
            btnXoa.Enabled = !b;
            btnLuu.Enabled = b;
            txtLyDoDoiTra.Enabled = b;
            txtTinhTrang.Enabled = b;
            txtGhiChu.Enabled = b;
            dgvPhieuDoiTra.Enabled = !b;
        }

        private void clearData()
        {
            lblMaPhieu.Text = string.Empty;
            lblNgayLap.Text = string.Empty;
            txtLyDoDoiTra.Text = string.Empty;
            txtTinhTrang.Text = string.Empty;
            lblSLDoi.Text = string.Empty;
            lblTongTienHoan.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            lblNgayCapNhat.Text = string.Empty;
            lblMaNV.Text = string.Empty;
            lblNVLap.Text = string.Empty;
            lblMaCTHD.Text = string.Empty;
            lblMaSP.Text = string.Empty;
            lblTenSP.Text = string.Empty;
        }

        private void dgvPhieuDoiTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuDoiTra.Rows[e.RowIndex];
                lblMaPhieu.Text = row.Cells[0].Value.ToString();
                lblNgayLap.Text = row.Cells[1].Value.ToString().Substring(0, 10);
                txtLyDoDoiTra.Text = row.Cells[2].Value.ToString();
                txtTinhTrang.Text = row.Cells[3].Value.ToString();
                lblSLDoi.Text = row.Cells[4].Value.ToString();
                lblTongTienHoan.Text = row.Cells[5].Value.ToString();
                txtGhiChu.Text = row.Cells[6].Value.ToString();
                lblNgayCapNhat.Text = row.Cells[7].Value?.ToString().Substring(0, 10);
                lblMaNV.Text = row.Cells[8].Value.ToString();
                lblNVLap.Text = bll.TimNhanVienTheoMa(lblMaNV.Text).HoTen;
                lblMaCTHD.Text = row.Cells[9].Value.ToString();
                lblMaSP.Text = bll.TimChiTietHDTheoMa(lblMaCTHD.Text).MaSanPham;
                lblTenSP.Text = bll.TimSanPhamTheoMa(lblMaSP.Text).TenSanPham;
            }
            else
            {
                clearData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            initNhapLieu(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblMaPhieu.Text != string.Empty)
                {
                    DialogResult choose = MessageBox.Show("Bạn có muốn xoá phiếu có mã " + lblMaPhieu.Text + " này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (choose == DialogResult.Yes)
                    {
                        int result = bll.XoaPhieuDoiTra(lblMaPhieu.Text);
                        if (result == 1)
                        {
                            MessageBox.Show("Xoá thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDataDgvPhieuDoiTra();
                            initNhapLieu(false);
                            clearData();
                        }
                        else MessageBox.Show("Không tìm phiếu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn phiếu!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
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

                int result = bll.SuaPhieuDoiTra(new PhieuDoiTraUpdate()
                {
                    MaPhieu = lblMaPhieu.Text,
                    LyDoDoiTra = txtLyDoDoiTra.Text,
                    TinhTrangSanPham = txtTinhTrang.Text,
                    GhiChu = txtGhiChu.Text
                });
                if (result == 1)
                {
                    MessageBox.Show("Sửa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataDgvPhieuDoiTra();
                    initNhapLieu(false);
                }
                else MessageBox.Show("Không tìm phiếu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            initNhapLieu(false);
            clearData();
        }
    }
}
