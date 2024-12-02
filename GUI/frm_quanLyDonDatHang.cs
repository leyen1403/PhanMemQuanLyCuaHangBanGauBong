using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyDonDatHang : Form
    {
        public string _maNhanVien { get; set; }
        List<DonDatHang> lstDonDatHang = new List<DonDatHang>();
        List<ChiTietDonDatHang> lstCTDDH = new List<ChiTietDonDatHang>();

        public frm_quanLyDonDatHang()
        {
            InitializeComponent();
            btnLamMoi.Click += BtnLamMoi_Click;
            dgvDDH.RowPostPaint += DgvDDH_RowPostPaint;
            dgvDDH.SelectionChanged += DgvDDH_SelectionChanged;
            btnTaoDonDatHang.Click += BtnTaoDonDatHang_Click;
            btnXoaDonDatHang.Click += BtnXoaDonDatHang_Click;
            dgvCTDDH.SelectionChanged += DgvCTDDH_SelectionChanged;
            btnLuuDuLieu.Click += BtnLuuDuLieu_Click;                        
            cboNhaCungCap.SelectedIndexChanged += cboNhaCungCap_SelectedIndexChanged;
            cboTrangThaiDonHang.SelectedIndexChanged += CboTrangThaiDonHang_SelectedIndexChanged;
            cboTrangThaiCTDDH.SelectedIndexChanged += CboTrangThaiCTDDH_SelectedIndexChanged;
            dgvCTDDH.CellValueChanged += DgvCTDDH_CellValueChanged;
            nudSLYC.ValueChanged += NudSLYC_ValueChanged;
            nudSLCC.ValueChanged += NudSLCC_ValueChanged;
            dgvCTDDH.CellBeginEdit += DgvCTDDH_CellBeginEdit;
        }

        private void NudSLCC_ValueChanged(object sender, EventArgs e)
        {
            // Số lượng yêu cầu không được bé hơn số lượng cung cấp
            if (nudSLYC.Value < nudSLCC.Value)
            {
                nudSLYC.Value = nudSLCC.Value;
                return;
            }
            dgvCTDDH.CurrentRow.Cells["SoLuongCungCap"].Value = (int)nudSLCC.Value;
            nudSLYC.Value = Convert.ToDecimal(dgvCTDDH.CurrentRow.Cells["SoLuongYeuCau"].Value);
            nudSLT.Value = Convert.ToDecimal(dgvCTDDH.CurrentRow.Cells["SoLuongThieu"].Value);
        }

        private void NudSLYC_ValueChanged(object sender, EventArgs e)
        {
            // Số lượng yêu cầu không được bé hơn số lượng cung cấp
            if (nudSLYC.Value < nudSLCC.Value)
            {
                nudSLYC.Value = nudSLCC.Value;
                return;
            }
            dgvCTDDH.CurrentRow.Cells["SoLuongYeuCau"].Value = (int)nudSLYC.Value;
            nudSLCC.Value = Convert.ToDecimal(dgvCTDDH.CurrentRow.Cells["SoLuongCungCap"].Value);
            nudSLT.Value = Convert.ToDecimal(dgvCTDDH.CurrentRow.Cells["SoLuongThieu"].Value);
        }

        private void DgvCTDDH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var currentRow = dgvCTDDH.Rows[e.RowIndex];

                // Xử lý khi thay đổi tại cột SoLuongYeuCau
                if (dgvCTDDH.Columns[e.ColumnIndex].Name == "SoLuongYeuCau")
                {
                    int soLuongCungCap = Convert.ToInt32(currentRow.Cells["SoLuongCungCap"].Value ?? 0);
                    int soLuongYeuCau = Convert.ToInt32(currentRow.Cells["SoLuongYeuCau"].Value ?? 0);

                    // Kiểm tra số lượng yêu cầu không nhỏ hơn số lượng cung cấp
                    if (soLuongYeuCau < soLuongCungCap)
                    {
                        MessageBox.Show("Số lượng yêu cầu không được nhỏ hơn số lượng cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Khôi phục giá trị cũ nếu không hợp lệ
                        currentRow.Cells["SoLuongYeuCau"].Value = soLuongCungCap;
                        return;
                    }

                    decimal donGia = Convert.ToDecimal(currentRow.Cells["DonGia"].Value ?? 0);
                    int soLuongThieu = soLuongYeuCau - soLuongCungCap;
                    decimal thanhTien = soLuongYeuCau * donGia;

                    // Cập nhật giá trị
                    currentRow.Cells["SoLuongThieu"].Value = soLuongThieu;
                    currentRow.Cells["ThanhTien"].Value = thanhTien;

                    // Cập nhật tổng tiền
                    CapNhatTongTien();
                }
            }
        }

        private void DgvCTDDH_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Chỉ cho phép chỉnh sửa cột SoLuongYeuCau và GhiChu
            string columnName = dgvCTDDH.Columns[e.ColumnIndex].Name;
            if (columnName != "SoLuongYeuCau" && columnName != "GhiChu")
            {
                e.Cancel = true;
            }
        }

        private void CapNhatTongTien()
        {
            // Tính tổng tiền từ dgvCTDDH
            decimal tongTien = dgvCTDDH.Rows.Cast<DataGridViewRow>()
                .Where(row => row.Cells["ThanhTien"].Value != null)
                .Sum(row => Convert.ToDecimal(row.Cells["ThanhTien"].Value));

            // Cập nhật vào ô TongTien trong dgvDDH
            if (dgvDDH.CurrentRow != null)
            {
                dgvDDH.CurrentRow.Cells["TongTien"].Value = tongTien;
            }

            // Cập nhật hiển thị
            lblTongTien.Text = tongTien.ToString("#,0");
        }

        private void LoadData()
        {
            DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
            lstDonDatHang.Clear();
            lstCTDDH.Clear();
            lstDonDatHang = donDatHangBLL.LayDanhSachDonDatHang();
            dgvDDH.DataSource = lstDonDatHang;

            // Ẩn các cột không cần thiết
            dgvDDH.Columns["NhaCungCap"].Visible = false;
            dgvDDH.Columns["NhanVien"].Visible = false;

            // Đặt lại tên cột
            dgvDDH.Columns["MaDonDatHang"].HeaderText = "Mã DDH";
            dgvDDH.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvDDH.Columns["MaNhaCungCap"].HeaderText = "Mã nhà cung cấp";
            dgvDDH.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgvDDH.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvDDH.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvDDH.Columns["NgayTao"].HeaderText = "Ngày tạo đơn";
            dgvDDH.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";

            // Đặt lại thứ tự các cột
            dgvDDH.Columns["MaDonDatHang"].DisplayIndex = 0;
            dgvDDH.Columns["NgayDat"].DisplayIndex = 1;
            dgvDDH.Columns["MaNhaCungCap"].DisplayIndex = 2;
            dgvDDH.Columns["MaNhanVien"].DisplayIndex = 3;
            dgvDDH.Columns["TongTien"].DisplayIndex = 4;
            dgvDDH.Columns["TrangThai"].DisplayIndex = 5;
            dgvDDH.Columns["NgayTao"].DisplayIndex = 6;
            dgvDDH.Columns["NgayCapNhat"].DisplayIndex = 7;

            // Đặt Autosize column mode cho DataGridView
            dgvDDH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Định dạng các cột đặc biệt (nếu cần)
            dgvDDH.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvDDH.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDDH.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDDH.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDDH.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void DgvDDH_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Đặt số thứ tự vào từng dòng
            using (SolidBrush b = new SolidBrush(dgvDDH.RowHeadersDefaultCellStyle.ForeColor))
            {
                string rowNumber = (e.RowIndex + 1).ToString(); // Đánh số từ 1
                e.Graphics.DrawString(
                    rowNumber,
                    dgvDDH.Font,
                    b,
                    e.RowBounds.Location.X + 10, // Khoảng cách từ cạnh trái
                    e.RowBounds.Location.Y + (e.RowBounds.Height - dgvDDH.Font.Height) / 2
                );
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            // Load dữ liệu danh sách đơn đặt hàng
            LoadData();
        }

        private void loadDataChiTiet(string maDDH)
        {            
            ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
            lstCTDDH = chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(maDDH);

            if (lstCTDDH == null || lstCTDDH.Count == 0)
            {
                MessageBox.Show("Không có chi tiết đơn đặt hàng nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvCTDDH.DataSource = null;
                return;
            }

            dgvCTDDH.DataSource = lstCTDDH;

            // Ẩn các cột không cần thiết
            dgvCTDDH.Columns["STT"].Visible = false;
            dgvCTDDH.Columns["MaDonDatHang"].Visible = false;
            dgvCTDDH.Columns["DonDatHang"].Visible = false;
            dgvCTDDH.Columns["SanPham"].Visible = false;

            // Đặt tên các cột
            dgvCTDDH.Columns["MaChiTietDonDatHang"].HeaderText = "Mã chi tiết";
            dgvCTDDH.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvCTDDH.Columns["SoLuongYeuCau"].HeaderText = "SL yêu cầu";
            dgvCTDDH.Columns["SoLuongCungCap"].HeaderText = "SL cung cấp";
            dgvCTDDH.Columns["SoLuongThieu"].HeaderText = "SL thiếu";
            dgvCTDDH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvCTDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvCTDDH.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvCTDDH.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvCTDDH.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";

            // Đặt lại thứ tự các cột
            dgvCTDDH.Columns["MaChiTietDonDatHang"].DisplayIndex = 0;
            dgvCTDDH.Columns["MaSanPham"].DisplayIndex = 1;
            dgvCTDDH.Columns["DonViTinh"].DisplayIndex = 2;
            dgvCTDDH.Columns["SoLuongYeuCau"].DisplayIndex = 3;
            dgvCTDDH.Columns["SoLuongCungCap"].DisplayIndex = 4;
            dgvCTDDH.Columns["SoLuongThieu"].DisplayIndex = 5;
            dgvCTDDH.Columns["DonGia"].DisplayIndex = 6;
            dgvCTDDH.Columns["ThanhTien"].DisplayIndex = 7;
            dgvCTDDH.Columns["TrangThai"].DisplayIndex = 8;
            dgvCTDDH.Columns["GhiChu"].DisplayIndex = 9;

            // Định dạng các cột đặc biệt
            dgvCTDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Định dạng số nguyên
            dgvCTDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Định dạng số nguyên
            dgvCTDDH.Columns["SoLuongThieu"].DefaultCellStyle.Format = "N0";
            dgvCTDDH.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["SoLuongYeuCau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["SoLuongCungCap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["SoLuongThieu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Căn chỉnh Header
            foreach (DataGridViewColumn column in dgvCTDDH.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Autosize cột để nội dung vừa khung
            dgvCTDDH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Căn chỉnh toàn bộ cột mặc định
            dgvCTDDH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // Thêm tooltip (tuỳ chọn)
            dgvCTDDH.Columns["TrangThai"].ToolTipText = "Trạng thái hiện tại của chi tiết đơn đặt hàng.";
        }

        private void DgvDDH_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có ô đang được chọn
            if (dgvDDH.CurrentCell != null && dgvDDH.CurrentRow != null && dgvDDH.CurrentRow.Cells["MaDonDatHang"].Value != null)
            {
                string maDDH = dgvDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                loadDataChiTiet(maDDH);
            }
        }

        private void BtnTaoDonDatHang_Click(object sender, EventArgs e)
        {
            // Hiện thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn tạo đơn đặt hàng mới không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frm_TaoDDH frm = new frm_TaoDDH() { MaNhanVien = _maNhanVien };
                frm.ShowDialog();
                LoadData();
            }
        }

        private void BtnXoaDonDatHang_Click(object sender, EventArgs e)
        {
            // Hỏi xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn đặt hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Kiểm tra xem có đơn đặt hàng nào đang được chọn không
                if (dgvDDH.CurrentCell == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn đặt hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Xoá lstCTDDH
                lstCTDDH.Clear();
                // Lấy mã đơn đặt hàng cần xóa
                string maDDH = dgvDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
                if (donDatHangBLL.XoaDonDatHang(maDDH))
                {
                    MessageBox.Show("Xóa đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa đơn đặt hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DgvCTDDH_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu có ô đang được chọn
            if (dgvCTDDH.CurrentCell != null)
            {
                string trangThaiDDH, ngayTao, maSP, donViTinh, trangThaiCTDDH, ghiChu;
                int soLuongYeuCau, soLuongCungCap, soLuongThieu;
                decimal donGia, thanhTien, tongTien;

                // Lấy thông tin nhà cung cấp từ mã nhà cung cấp trong dgvDDH
                string maNCC = dgvDDH.CurrentRow.Cells["MaNhaCungCap"].Value?.ToString();
                NhaCungCapBLL nhaCungCapBLL = new NhaCungCapBLL();

                // Trạng thái DDH gồm: 
                trangThaiDDH = dgvDDH.CurrentRow.Cells["TrangThai"]?.Value?.ToString() ?? "Chưa xác nhận";
                if (trangThaiDDH == "Chưa xác nhận")
                {
                    cboTrangThaiDonHang.SelectedIndex = 0;
                }
                else if (trangThaiDDH == "Đã xác nhận")
                {
                    cboTrangThaiDonHang.SelectedIndex = 1;
                }
                else if (trangThaiDDH == "Hoàn thành")
                {
                    cboTrangThaiDonHang.SelectedIndex = 2;
                }
                else if (trangThaiDDH == "Đã huỷ")
                {
                    cboTrangThaiDonHang.SelectedIndex = 3;
                }

                // Lấy thông tin ngày tạo từ dgvDDH
                ngayTao = Convert.ToDateTime(dgvDDH.CurrentRow.Cells["NgayTao"].Value).ToString("dd/MM/yyyy");

                // Lấy thông tin tổng tiền từ dgvDDH
                tongTien = Convert.ToDecimal(dgvDDH.CurrentRow.Cells["TongTien"].Value);

                // Lấy thông tin mã sản phẩm từ dgvCTDDH
                maSP = dgvCTDDH.CurrentRow.Cells["MaSanPham"].Value?.ToString();
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                SanPham sanPham = sanPhamBLL.LaySanPhamTheoMa(maSP);
                if (sanPham == null) return;
                donViTinh = sanPham?.DonViTinh ?? "";

                // Trạng thái CTDDH gồm: 
                trangThaiCTDDH = dgvCTDDH.CurrentRow.Cells["TrangThai"]?.Value?.ToString() ?? "Chưa xác nhận";
                if (trangThaiCTDDH == "Chưa xác nhận")
                {
                    cboTrangThaiCTDDH.SelectedIndex = 0;
                }
                else if (trangThaiCTDDH == "Đã xác nhận")
                {
                    cboTrangThaiCTDDH.SelectedIndex = 1;
                }
                else if (trangThaiCTDDH == "Hoàn thành")
                {
                    cboTrangThaiCTDDH.SelectedIndex = 2;
                }
                else if (trangThaiCTDDH == "Đã huỷ")
                {
                    cboTrangThaiCTDDH.SelectedIndex = 3;
                }
                ghiChu = dgvCTDDH.CurrentRow.Cells["GhiChu"]?.Value?.ToString() ?? "";

                // Lấy thông tin số lượng yêu cầu từ dgvCTDDH
                soLuongYeuCau = Convert.ToInt32(dgvCTDDH.CurrentRow.Cells["SoLuongYeuCau"].Value);
                soLuongCungCap = Convert.ToInt32(dgvCTDDH.CurrentRow.Cells["SoLuongCungCap"].Value);
                soLuongThieu = Convert.ToInt32(dgvCTDDH.CurrentRow.Cells["SoLuongThieu"].Value);
                donGia = (decimal)sanPham.GiaNhap;
                thanhTien = (decimal)dgvCTDDH.CurrentRow.Cells["ThanhTien"].Value;

                // Hiển thị thông tin lên các control
                NhaCungCapBLL nhaCungCapBLL1 = new NhaCungCapBLL();
                List<NhaCungCap> lstNCC = nhaCungCapBLL.LayDanhSachNhaCungCap();
                cboNhaCungCap.DataSource = lstNCC;
                cboNhaCungCap.DisplayMember = "TenNhaCungCap";
                cboNhaCungCap.ValueMember = "MaNhaCungCap";
                cboNhaCungCap.SelectedValue = maNCC;
                lblNgayTaoDDH.Text = ngayTao;
                lblTongTien.Text = tongTien.ToString("N0");
                lblMaSP.Text = maSP;
                lblDonViTinh.Text = donViTinh;
                txtGhiChuCTDDH.Text = ghiChu;
                nudSLYC.Value = soLuongYeuCau;
                nudSLCC.Value = soLuongCungCap;
                nudSLT.Value = soLuongThieu;
                lblDonGia.Text = donGia.ToString("N0");
                lblThanhTien.Text = thanhTien.ToString("N0");                
            }
        }


        private void BtnLuuDuLieu_Click(object sender, EventArgs e)
        {
            int index = dgvDDH.CurrentRow.Index;
            // Hỏi xác nhận trước khi lưu
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                DonDatHang ddhTemp = new DonDatHang();
                ddhTemp.MaDonDatHang = dgvDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                ddhTemp.MaNhaCungCap = dgvDDH.CurrentRow.Cells["MaNhaCungCap"].Value.ToString();
                ddhTemp.MaNhanVien = _maNhanVien;
                ddhTemp.TongTien = Convert.ToDecimal(lblTongTien.Text);
                ddhTemp.TrangThai = dgvDDH.CurrentRow.Cells["TrangThai"].Value.ToString();
                ddhTemp.NgayTao = DateTime.ParseExact(lblNgayTaoDDH.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                ddhTemp.NgayDat = ddhTemp.NgayTao;

                List<ChiTietDonDatHang> lstTemp = new List<ChiTietDonDatHang>();
                foreach (DataGridViewRow row in dgvCTDDH.Rows)
                {
                    ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
                    ctddh.MaChiTietDonDatHang = row.Cells["MaChiTietDonDatHang"].Value.ToString();
                    ctddh.MaDonDatHang = row.Cells["MaDonDatHang"].Value.ToString();
                    ctddh.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                    ctddh.DonViTinh = row.Cells["DonViTinh"].Value.ToString();
                    ctddh.SoLuongYeuCau = Convert.ToInt32(row.Cells["SoLuongYeuCau"].Value);
                    ctddh.SoLuongCungCap = Convert.ToInt32(row.Cells["SoLuongCungCap"].Value);
                    ctddh.SoLuongThieu = Convert.ToInt32(row.Cells["SoLuongThieu"].Value);
                    ctddh.DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    ctddh.ThanhTien = Convert.ToDecimal(row.Cells["ThanhTien"].Value);
                    ctddh.TrangThai = row.Cells["TrangThai"].Value.ToString();
                    ctddh.GhiChu = row.Cells["GhiChu"].Value.ToString();
                    lstTemp.Add(ctddh);
                }
                DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
                if (donDatHangBLL.CapNhatChiTietDonDatHangDuaTrenDDHVaDSCTDDH(ddhTemp, lstTemp))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    dgvDDH.Rows[index].Selected = true;
                }
                else
                {
                    MessageBox.Show("Cập nhật chi tiết thất bại");
                }
            }

            
        }


        private void cboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhaCungCap.SelectedItem == null) return;

            string maNCC = cboNhaCungCap.SelectedValue.ToString();
            dgvDDH.CurrentRow.Cells["MaNhaCungCap"].Value = maNCC;
        }


        private void CboTrangThaiDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTrangThaiDonHang.SelectedItem == null)
            {
                return;
            }
            string trangThai = cboTrangThaiDonHang.SelectedItem.ToString();
            dgvDDH.CurrentRow.Cells["TrangThai"].Value = trangThai;
        }

        private void CboTrangThaiCTDDH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTrangThaiCTDDH.SelectedItem == null)
            {
                return;
            }
            string trangThai = cboTrangThaiCTDDH.SelectedItem.ToString();
            dgvCTDDH.CurrentRow.Cells["TrangThai"].Value = trangThai;
        }

    }
}
