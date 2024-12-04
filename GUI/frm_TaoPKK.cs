using BLL;
using DevExpress.XtraEditors.Mask.Design;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_TaoPKK : Form
    {
        public string MaNhanVien { get; set; }
        PhieuKiemKe phieuKiemKe = new PhieuKiemKe();
        List<SanPham> lstSP = new List<SanPham>();
        List<ChiTietPhieuKiemKe> lstCTPKK = new List<ChiTietPhieuKiemKe>();
        public frm_TaoPKK()
        {
            InitializeComponent();
            Load += Frm_TaoPKK_Load;
            dgvSP.SelectionChanged += DgvSP_SelectionChanged;
            btnThemCTPKK.Click += BtnThemCTPKK_Click;
            btnXoaCTPKK.Click += BtnXoaCTPKK_Click;
            btnLuuCTPKK.Click += BtnLuuCTPKK_Click;
            btnHoanTat.Click += BtnHoanTat_Click;
            dgvCTPKK.CellValueChanged += DgvCTPKK_CellValueChanged;
            dgvCTPKK.EditingControlShowing += DgvCTPKK_EditingControlShowing;
            btnToanBo.Click += BtnToanBo_Click;
            btnChonSL.Click += BtnChonSL_Click;
            btnXoaToanBo.Click += BtnXoaToanBo_Click;
        }

        private void BtnXoaToanBo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá tất cả phiếu kiểm kê không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }
            lstCTPKK.Clear();
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            lstSP = sanPhamBLL.LayDanhSachSanPham();
            CapNhatDataGridView();
        }

        private void BtnChonSL_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu danh sách sản phẩm rỗng
                if (lstSP == null || lstSP.Count == 0)
                {
                    MessageBox.Show("Danh sách sản phẩm không có sản phẩm nào để kiểm kê.");
                    return;
                }

                // Hiển thị hộp thoại nhập số lượng
                string input = Microsoft.VisualBasic.Interaction.InputBox(
                    "Nhập số lượng kiểm kê",
                    "Nhập số lượng",
                    "0"
                );

                // Kiểm tra giá trị nhập vào có hợp lệ không
                if (!int.TryParse(input, out int soLuongNhap) || soLuongNhap <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số nguyên dương hợp lệ.");
                    return;
                }

                // Danh sách sản phẩm cần xóa khỏi lstSP
                var itemsToRemove = new List<SanPham>();

                // Duyệt qua tất cả sản phẩm trong lstSP
                foreach (var item in lstSP.ToList()) // Dùng ToList để tránh thay đổi lstSP khi duyệt qua
                {
                    // Kiểm tra nếu số lượng tồn kho của sản phẩm nhỏ hơn hoặc bằng số lượng nhập
                    if (item.SoLuongTon <= soLuongNhap)
                    {
                        // Tạo đối tượng ChiTietPhieuKiemKe cho sản phẩm này
                        ChiTietPhieuKiemKe ctpkk = new ChiTietPhieuKiemKe
                        {
                            MaPhieuKiemKe = phieuKiemKe.MaPhieuKiemKe,
                            MaSanPham = item.MaSanPham,
                            SoLuongHeThong = item.SoLuongTon,
                            SoLuongThucTe = item.SoLuongTon, // Mặc định là số lượng tồn kho
                            LyDoChenhLech = "Lý do chênh lệch",
                        };

                        // Thêm vào danh sách chi tiết phiếu kiểm kê
                        lstCTPKK.Add(ctpkk);

                        // Thêm sản phẩm vào danh sách xóa
                        itemsToRemove.Add(item);
                    }
                }

                // Kiểm tra nếu không có sản phẩm nào được thêm vào phiếu kiểm kê
                if (itemsToRemove.Count == 0)
                {
                    MessageBox.Show("Không có sản phẩm nào có số lượng tồn kho nhỏ hơn hoặc bằng số lượng nhập.");
                    return;
                }

                // Xóa các sản phẩm đã được thêm vào chi tiết phiếu kiểm kê
                foreach (var item in itemsToRemove)
                {
                    lstSP.Remove(item);
                }

                // Cập nhật lại DataGridView
                CapNhatDataGridView();

                // Thông báo kết quả
                MessageBox.Show($"Đã thêm {itemsToRemove.Count} sản phẩm vào phiếu kiểm kê.");
            }
            catch (Exception ex)
            {
                // Xử lý tất cả các lỗi không lường trước
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }




        private void BtnToanBo_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm tất cả sản phẩm vào phiếu kiểm kê không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            // Thêm tất cả sản phẩm vào danh sách chi tiết phiếu kiểm kê
            foreach (var sp in lstSP.ToList()) // Sử dụng ToList để tránh lỗi khi thay đổi danh sách trong vòng lặp
            {
                ChiTietPhieuKiemKe ctpkk = new ChiTietPhieuKiemKe
                {
                    MaPhieuKiemKe = phieuKiemKe.MaPhieuKiemKe,
                    MaSanPham = sp.MaSanPham,
                    SoLuongHeThong = sp.SoLuongTon,
                    SoLuongThucTe = sp.SoLuongTon, // Giá trị mặc định là bằng số lượng hệ thống
                    LyDoChenhLech = "Lý do chênh lệch"
                };

                lstCTPKK.Add(ctpkk);
            }

            // Xóa tất cả sản phẩm khỏi danh sách sản phẩm
            lstSP.Clear();

            // Cập nhật giao diện
            CapNhatDataGridView();
        }


        private void DgvCTPKK_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvCTPKK.DataSource != null)
            {
                // Kiểm tra nếu cột được chỉnh sửa là "SoLuongThucTe"
                if (dgvCTPKK.CurrentCell.OwningColumn.Name == "SoLuongThucTe")
                {
                    // Hủy đăng ký sự kiện KeyPress nếu đã được gắn trước đó
                    e.Control.KeyPress -= SoLuongThucTe_KeyPress;

                    // Đăng ký sự kiện KeyPress mới
                    e.Control.KeyPress += SoLuongThucTe_KeyPress;
                }
                if (dgvCTPKK.CurrentCell.OwningColumn.Name == "LyDoChenhLech")
                {

                }
                else
                {
                    // Hủy sự kiện nếu không phải cột "SoLuongThucTe"
                    e.Control.KeyPress -= SoLuongThucTe_KeyPress;
                }
            }
        }

        private void SoLuongThucTe_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập không phải số (và không phải phím Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Loại bỏ ký tự không hợp lệ
            }
        }

        private void DgvCTPKK_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCTPKK.DataSource != null)
            {
                // Kiểm tra nếu cột được thay đổi là "SoLuongThucTe"
                if (dgvCTPKK.Columns[e.ColumnIndex].Name == "SoLuongThucTe")
                {
                    // Kiểm tra nếu e.RowIndex hợp lệ
                    if (e.RowIndex >= 0 && e.RowIndex < dgvCTPKK.Rows.Count)
                    {
                        // Kiểm tra nếu cột "MaSanPham" tồn tại
                        if (dgvCTPKK.Columns.Contains("MaSanPham"))
                        {
                            // Lấy mã sản phẩm từ cột "MaSanPham"
                            string maSP = dgvCTPKK.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString();

                            // Lấy giá trị mới của "SoLuongThucTe"
                            int soLuongThucTe = Convert.ToInt32(dgvCTPKK.Rows[e.RowIndex].Cells["SoLuongThucTe"].Value);

                            // Cập nhật lại giá trị trong lstCTPKK
                            ChiTietPhieuKiemKe chiTiet = lstCTPKK.FirstOrDefault(ct => ct.MaSanPham == maSP);
                            if (chiTiet != null)
                            {
                                chiTiet.SoLuongThucTe = soLuongThucTe;
                            }
                        }
                    }
                }
            }
        }

        private void BtnHoanTat_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận 
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu kiểm kê này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            if (lstCTPKK == null || lstCTPKK.Count == 0)
            {
                MessageBox.Show("Danh sách chi tiết phiếu kiểm kê không được để trống.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú.");
                return;
            }
            PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
            phieuKiemKe.MaNhanVien = cboNhanVien.SelectedValue.ToString();
            phieuKiemKe.NgayLap = dtpNgayLap.Value;
            phieuKiemKe.GhiChu = txtGhiChu.Text;
            bool ketQua = phieuKiemKeBLL.TaoPhieuKiemKe(phieuKiemKe, lstCTPKK);
            if (ketQua)
            {
                MessageBox.Show("Tạo phiếu kiểm kê thành công.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo phiếu kiểm kê thất bại.");
            }
        }

        private void BtnLuuCTPKK_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu phiếu kiểm kê này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            // Kiểm tra dữ liệu đầu vào
            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.");
                return;
            }

            if (lstCTPKK == null || lstCTPKK.Count == 0)
            {
                MessageBox.Show("Danh sách chi tiết phiếu kiểm kê không được để trống.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú.");
                return;
            }

            // Cập nhật thông tin phiếu kiểm kê từ giao diện
            phieuKiemKe.MaNhanVien = cboNhanVien.SelectedValue.ToString();
            phieuKiemKe.NgayLap = dtpNgayLap.Value;
            phieuKiemKe.GhiChu = txtGhiChu.Text;
            lstCTPKK = (List<ChiTietPhieuKiemKe>)dgvCTPKK.DataSource;
            MessageBox.Show("Cập nhật phiếu kiểm kê thành công.");
        }

        private void BtnXoaCTPKK_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết phiếu kiểm kê này không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes)
            {
                return;
            }

            if (dgvCTPKK.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một chi tiết phiếu kiểm kê để xóa.");
                return;
            }

            // Lấy mã sản phẩm từ dòng hiện tại
            string maSP = dgvCTPKK.CurrentRow.Cells["MaSanPham"].Value.ToString();

            // Tìm sản phẩm trong danh sách chi tiết phiếu kiểm kê
            var chiTiet = lstCTPKK.FirstOrDefault(x => x.MaSanPham == maSP);
            if (chiTiet == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm trong danh sách chi tiết phiếu kiểm kê.");
                return;
            }

            // Lấy thông tin sản phẩm từ cơ sở dữ liệu hoặc danh sách sản phẩm
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            SanPham sp = sanPhamBLL.LaySanPhamTheoMa(maSP);

            if (sp != null)
            {
                // Đưa sản phẩm trở lại danh sách sản phẩm
                lstSP.Add(sp);
            }
            else
            {
                MessageBox.Show("Không thể lấy thông tin sản phẩm từ cơ sở dữ liệu.");
            }

            // Xóa sản phẩm khỏi danh sách chi tiết phiếu kiểm kê
            lstCTPKK.Remove(chiTiet);

            // Cập nhật giao diện
            CapNhatDataGridView();
        }


        private void BtnThemCTPKK_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận thêm
            // Kiểm tra số lượng thực tế hợp lệ
            if (nudSLTT.Value <= 0 || dgvSP.CurrentCell == null)
            {
                MessageBox.Show("Số lượng thực tế phải lớn hơn 0");
                return;
            }

            // Lấy thông tin cơ bản
            string maPKK = phieuKiemKe.MaPhieuKiemKe;
            string maSP = dgvSP.CurrentRow.Cells["MaSanPham"].Value.ToString();
            int SLHT = (int)nudSLHT.Value;
            int SLTT = (int)nudSLTT.Value;

            // Tìm sản phẩm trong danh sách
            SanPham sp = lstSP.FirstOrDefault(x => x.MaSanPham == maSP);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm.");
                return;
            }

            // Tạo đối tượng ChiTietPhieuKiemKe
            ChiTietPhieuKiemKe ctpkk = new ChiTietPhieuKiemKe
            {
                MaPhieuKiemKe = maPKK,
                MaSanPham = maSP,
                SoLuongHeThong = SLHT,
                SoLuongThucTe = SLTT,
                LyDoChenhLech = "Lý do chênh lệch",
            };

            // Cập nhật danh sách
            lstCTPKK.Add(ctpkk);
            lstSP.Remove(sp);

            // Cập nhật DataGridView
            CapNhatDataGridView();
        }

        // Hàm cập nhật DataGridView
        private void CapNhatDataGridView()
        {
            dgvCTPKK.DataSource = null;
            dgvCTPKK.DataSource = lstCTPKK;
            dgvSP.DataSource = null;
            dgvSP.DataSource = lstSP;

            dgvSP.Refresh();
            dgvCTPKK.Refresh();

            DinhDangDGVSP();
            DinhDangDGVCTPKK();
        }



        private void DgvSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSP != null && dgvSP.CurrentCell != null && dgvSP.CurrentRow != null)
            {
                var cell = dgvSP.CurrentRow.Cells["MaSanPham"];
                if (cell != null && cell.Value != null)
                {
                    string maSP = cell.Value.ToString();
                    SanPham sp = lstSP.FirstOrDefault(t => t.MaSanPham == maSP);
                    if (sp != null)
                    {
                        txtMaSP.Text = sp.MaSanPham;
                        nudSLHT.Value = (decimal)sp.SoLuongTon;
                        nudSLTT.Value = 0;
                    }
                }
            }
        }

        private void Frm_TaoPKK_Load(object sender, EventArgs e)
        {
            // Tạo phiếu kiểm kê tạm thời
            PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
            string maPKKCuoi = phieuKiemKeBLL.LayMaPhieuKiemKeCuoiCung();

            string maPhieuKiemKe;
            if (string.IsNullOrEmpty(maPKKCuoi))
            {
                // Nếu không có mã cũ, tạo mã mặc định
                maPhieuKiemKe = "PKK001";
            }
            else
            {
                // Lấy số thứ tự từ mã cũ và tạo mã mới
                string soPhieu = maPKKCuoi.Substring(3);
                if (int.TryParse(soPhieu, out int soPhieuMoi))
                {
                    soPhieuMoi += 1;
                    maPhieuKiemKe = "PKK" + soPhieuMoi.ToString("000");
                }
                else
                {
                    // Trường hợp mã cũ không đúng định dạng, tạo mã mặc định
                    maPhieuKiemKe = "PKK001";
                }
            }

            // Lấy danh sách nhân viên
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            List<NhanVien> lstNV = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DataSource = lstNV;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";

            // Gán mã nhân viên đang đăng nhập
            string maNhanVien = MaNhanVien;
            cboNhanVien.SelectedValue = maNhanVien;

            // Lấy danh sách sản phẩm
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            lstSP = sanPhamBLL.LayDanhSachSanPham();
            dgvSP.DataSource = lstSP;
            DinhDangDGVSP();

            // Hiển thị thông tin mã phiếu kiểm kê và lưu vào đối tượng phiếu kiểm kê
            txtMaPKK.Text = maPhieuKiemKe;
            phieuKiemKe.MaPhieuKiemKe = maPhieuKiemKe;
        }


        private void DinhDangDGVSP()
        {
            // Không cho chỉnh sửa tất cả các ô
            dgvSP.ReadOnly = true;
            foreach (DataGridViewColumn column in dgvSP.Columns)
            {
                column.Visible = false;
            }

            // Hiện các cột cần thiết
            dgvSP.Columns["MaSanPham"].Visible = true;
            dgvSP.Columns["TenSanPham"].Visible = true;
            dgvSP.Columns["DonViTinh"].Visible = true;
            dgvSP.Columns["SoLuongTon"].Visible = true;
            dgvSP.Columns["GiaNhap"].Visible = true;
            dgvSP.Columns["GiaBan"].Visible = true;
            dgvSP.Columns["MoTa"].Visible = true;
            dgvSP.Columns["NgayCapNhat"].Visible = true;

            // Đặt lại tên các cột
            dgvSP.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSP.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSP.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvSP.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgvSP.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvSP.Columns["GiaBan"].HeaderText = "Giá bán";
            dgvSP.Columns["MoTa"].HeaderText = "Mô tả";
            dgvSP.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";

            // Định dạng các cột đặt biệt
            dgvSP.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSP.Columns["GiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSP.Columns["GiaNhap"].DefaultCellStyle.Format = "N0";
            dgvSP.Columns["GiaBan"].DefaultCellStyle.Format = "N0";
            dgvSP.Columns["GiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvSP.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";


        }

        private void DinhDangDGVCTPKK()
        {
            // Đặt tất cả các cột thành không cho chỉnh sửa
            foreach (DataGridViewColumn column in dgvCTPKK.Columns)
            {
                column.ReadOnly = true;
                column.Visible = false;
            }

            // Chỉ cho phép chỉnh sửa cột "SoLuongThucTe"
            if (dgvCTPKK.Columns["SoLuongThucTe"] != null)
            {
                dgvCTPKK.Columns["SoLuongThucTe"].ReadOnly = false;
            }

            // Hiện các cột cần thiết
            dgvCTPKK.Columns["MaSanPham"].Visible = true;
            dgvCTPKK.Columns["SoLuongHeThong"].Visible = true;
            dgvCTPKK.Columns["SoLuongThucTe"].Visible = true;
            dgvCTPKK.Columns["LyDoChenhLech"].Visible = true;

            // Đặt lại tên cột
            dgvCTPKK.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvCTPKK.Columns["SoLuongHeThong"].HeaderText = "Số lượng hệ thống";
            dgvCTPKK.Columns["SoLuongThucTe"].HeaderText = "Số lượng thực tế";
            dgvCTPKK.Columns["LyDoChenhLech"].HeaderText = "Lý do chênh lệch";

            // Điều chỉnh căn giữa tên cột
            dgvCTPKK.Columns["MaSanPham"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTPKK.Columns["SoLuongHeThong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTPKK.Columns["SoLuongThucTe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvCTPKK.Columns["LyDoChenhLech"].ReadOnly = false;
        }
    }
}
