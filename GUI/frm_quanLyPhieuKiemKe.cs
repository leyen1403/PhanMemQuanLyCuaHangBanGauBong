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
        public string MaNhanVien { get; set; }
        List<PhieuKiemKe> lstPKK = new List<PhieuKiemKe>();
        List<ChiTietPhieuKiemKe> lstCTPKK = new List<ChiTietPhieuKiemKe>();
        public frm_quanLyPhieuKiemKe()
        {
            InitializeComponent();
            Load += Frm_quanLyPhieuKiemKe_Load;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnTaoPKK.Click += BtnTaoPKK_Click;
            dgvPKK.SelectionChanged += DgvPKK_SelectionChanged;
            dgvCTPKK.SelectionChanged += DgvCTPKK_SelectionChanged;
            btnXoaPKK.Click += BtnXoaPKK_Click;
            btnLuuPKK.Click += BtnLuuPKK_Click;
        }


        private void BtnLuuPKK_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu dòng hiện tại trong DataGridView
                if (dgvPKK.CurrentRow == null || dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu kiểm kê cần lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string maPKK = dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
                if (string.IsNullOrEmpty(maPKK))
                {
                    MessageBox.Show("Mã phiếu kiểm kê không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy phiếu kiểm kê từ danh sách
                PhieuKiemKe pkk = lstPKK.Where(x => x.MaPhieuKiemKe == maPKK).FirstOrDefault();
                if (pkk == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu kiểm kê trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật thông tin phiếu kiểm kê
                pkk.NgayLap = Convert.ToDateTime(dgvPKK.CurrentRow.Cells["NgayLap"].Value);
                pkk.GhiChu = dgvPKK.CurrentRow.Cells["GhiChu"].Value?.ToString();
                pkk.MaNhanVien = dgvPKK.CurrentRow.Cells["MaNhanVien"].Value?.ToString();

                if (string.IsNullOrEmpty(pkk.MaNhanVien))
                {
                    MessageBox.Show("Mã nhân viên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo danh sách chi tiết phiếu kiểm kê tạm
                List<ChiTietPhieuKiemKe> lstTemp = new List<ChiTietPhieuKiemKe>();
                foreach (DataGridViewRow row in dgvCTPKK.Rows)
                {
                    if (row.Cells["MaSanPham"].Value == null || row.Cells["SoLuongHeThong"].Value == null || row.Cells["SoLuongThucTe"].Value == null)
                    {
                        MessageBox.Show("Dữ liệu không hợp lệ trong chi tiết phiếu kiểm kê. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        ChiTietPhieuKiemKe ctpkk = new ChiTietPhieuKiemKe
                        {
                            MaPhieuKiemKe = row.Cells["MaPhieuKiemKe"].Value.ToString(),
                            MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
                            SoLuongHeThong = Convert.ToInt32(row.Cells["SoLuongHeThong"].Value),
                            SoLuongThucTe = Convert.ToInt32(row.Cells["SoLuongThucTe"].Value),
                            LyDoChenhLech = row.Cells["LyDoChenhLech"].Value?.ToString()
                        };
                        lstTemp.Add(ctpkk);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Số lượng hệ thống hoặc thực tế không đúng định dạng. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xử lý dữ liệu chi tiết phiếu kiểm kê: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Cập nhật phiếu kiểm kê và chi tiết phiếu kiểm kê
                PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
                bool ketQua = phieuKiemKeBLL.CapNhatPhieuKiemKeDuaTrenPhieuKiemKeVaDSCTPKK(pkk, lstTemp);

                if (ketQua)
                {
                    MessageBox.Show("Lưu phiếu kiểm kê thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lưu phiếu kiểm kê thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Tải lại dữ liệu
                loadDGVPKK();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Lỗi: Không thể lấy thông tin từ dòng được chọn.\nChi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Lỗi: Hoạt động không hợp lệ trong quá trình xử lý.\nChi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi không xác định. Vui lòng liên hệ bộ phận kỹ thuật.\nChi tiết lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnXoaPKK_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có hàng nào được chọn không
                if (dgvPKK.CurrentRow == null || dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"] == null || dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu kiểm kê cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã phiếu kiểm kê từ dòng được chọn
                string maPhieuKiemKe = dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
                if (string.IsNullOrEmpty(maPhieuKiemKe))
                {
                    MessageBox.Show("Không thể lấy mã phiếu kiểm kê từ dòng được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hỏi xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu kiểm kê này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa phiếu kiểm kê trong cơ sở dữ liệu
                    PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
                    bool ketQua = phieuKiemKeBLL.XoaPhieuKiemKe(maPhieuKiemKe);

                    if (ketQua)
                    {
                        MessageBox.Show("Xóa phiếu kiểm kê thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDGVPKK(); // Tải lại dữ liệu phiếu kiểm kê
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu kiểm kê thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        loadDGVPKK(); // Tải lại dữ liệu để đảm bảo cập nhật
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Lỗi: Không thể lấy thông tin từ dòng được chọn. Vui lòng thử lại.\nChi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Lỗi: Hoạt động không hợp lệ trong quá trình xử lý.\nChi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi không xác định. Vui lòng liên hệ bộ phận kỹ thuật.\nChi tiết lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCTPKK_SelectionChanged(object sender, EventArgs e)
        {
            if (lstCTPKK != null && lstCTPKK.Count > 0)
            {
                if (dgvCTPKK.CurrentRow != null)
                {
                    var cells = dgvCTPKK.CurrentRow.Cells;
                    if (cells["MaSanPham"] != null && cells["SoLuongHeThong"] != null && cells["SoLuongThucTe"] != null && cells["LyDoChenhLech"] != null)
                    {
                        txtMaSP.Text = cells["MaSanPham"].Value.ToString();
                        nudSLHT.Value = Convert.ToInt32(cells["SoLuongHeThong"].Value.ToString());
                        nudSLTT.Value = Convert.ToInt32(cells["SoLuongThucTe"].Value.ToString());
                        txtLyDoChenhLech.Text = cells["LyDoChenhLech"].Value.ToString();
                        int chenhLech = Convert.ToInt32(cells["SoLuongThucTe"].Value.ToString()) - Convert.ToInt32(cells["SoLuongHeThong"].Value.ToString());
                        if (chenhLech > 0)
                        {
                            txtLyDoChenhLech.Text = "Thừa " + chenhLech + " sản phẩm";
                        }
                        else if (chenhLech < 0)
                        {
                            txtLyDoChenhLech.Text = "Thiếu " + Math.Abs(chenhLech) + " sản phẩm";
                        }
                        else
                        {
                            txtLyDoChenhLech.Text = "Không chênh lệch";
                        }
                        nudSLCL.Value = Math.Abs(chenhLech);
                    }
                }
            }
        }

        private void Frm_quanLyPhieuKiemKe_Load(object sender, EventArgs e)
        {
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            List<NhanVien> lstNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DataSource = lstNhanVien;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
        }

        private void DgvPKK_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPKK.DataSource != null && dgvPKK.CurrentRow != null)
            {
                var cell = dgvPKK.CurrentRow.Cells["MaNhanVien"];
                if (cell != null && cell.Value != null)
                {
                    string maNhanVien = cell.Value.ToString();
                    if (!string.IsNullOrEmpty(maNhanVien))
                    {
                        NhanVienBLL nhanVienBLL = new NhanVienBLL();
                        NhanVien nhanVien = nhanVienBLL.GetNhanVienById(maNhanVien);
                        cboNhanVien.SelectedValue = nhanVien.MaNhanVien;
                    }
                    dtpNgayLap.Value = Convert.ToDateTime(dgvPKK.CurrentRow.Cells["NgayLap"].Value.ToString());
                    txtMaPhieu.Text = dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
                    string maPhieuKiemKe = dgvPKK.CurrentRow.Cells["MaPhieuKiemKe"].Value.ToString();
                    ChiTietPhieuKiemKeBLL CTPKKBLL = new ChiTietPhieuKiemKeBLL();
                    lstCTPKK = CTPKKBLL.GetListChiTietPhieuKiemKeByMaPhieuKiemKe(maPhieuKiemKe);
                    dgvCTPKK.DataSource = lstCTPKK;
                    DinhDangDGVCTPKK();
                }
            }
        }

        private void DinhDangDGVCTPKK()
        {
            if (dgvCTPKK.DataSource != null)
            {
                dgvCTPKK.Columns["MaPhieuKiemKe"].HeaderText = "Mã phiếu kiểm kê";
                dgvCTPKK.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                dgvCTPKK.Columns["SoLuongHeThong"].HeaderText = "Số lượng hệ thống";
                dgvCTPKK.Columns["SoLuongThucTe"].HeaderText = "Số lượng thực tế";
                dgvCTPKK.Columns["LyDoChenhLech"].HeaderText = "Lý do chênh lệch";

                dgvCTPKK.Columns["SoLuongHeThong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvCTPKK.Columns["SoLuongThucTe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dgvCTPKK.Columns["PhieuKiemKe"].Visible = false;
                dgvCTPKK.Columns["SanPham"].Visible = false;

                // Đăng ký sự kiện định dạng màu
                dgvCTPKK.CellFormatting += DgvCTPKK_CellFormatting;
            }
        }

        private void DgvCTPKK_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCTPKK.Columns["SoLuongHeThong"] != null && dgvCTPKK.Columns["SoLuongThucTe"] != null)
            {
                var currentRow = dgvCTPKK.Rows[e.RowIndex];
                int soLuongHeThong = Convert.ToInt32(currentRow.Cells["SoLuongHeThong"].Value ?? 0);
                int soLuongThucTe = Convert.ToInt32(currentRow.Cells["SoLuongThucTe"].Value ?? 0);

                // Kiểm tra sự chênh lệch
                if (soLuongHeThong != soLuongThucTe)
                {
                    currentRow.DefaultCellStyle.BackColor = Color.LightCoral; // Màu đỏ nhạt cho chênh lệch
                    currentRow.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    currentRow.DefaultCellStyle.BackColor = Color.White; // Màu trắng cho dòng bình thường
                    currentRow.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        private void BtnTaoPKK_Click(object sender, EventArgs e)
        {
            frm_TaoPKK f = new frm_TaoPKK();
            f.MaNhanVien = MaNhanVien;
            f.ShowDialog();
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            loadDGVPKK();
        }

        private void loadDGVPKK()
        {
            PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
            lstPKK = phieuKiemKeBLL.GetListPhieuKiemKe();
            dgvPKK.DataSource = lstPKK;
            DinhDangDGVPKK();
        }

        private void DinhDangDGVPKK()
        {
            if (dgvPKK.DataSource != null)
            {
                dgvPKK.Columns["MaPhieuKiemKe"].HeaderText = "Mã phiếu kiểm kê";
                dgvPKK.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
                dgvPKK.Columns["NgayLap"].HeaderText = "Ngày kiểm kê";
                dgvPKK.Columns["GhiChu"].HeaderText = "Ghi chú";

                dgvPKK.Columns["NgayLap"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvPKK.Columns["NgayLap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPKK.Columns["NhanVien"].Visible = false;
            }

        }
    }
}