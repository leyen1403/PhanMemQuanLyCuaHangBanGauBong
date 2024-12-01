using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        }

        private void LoadData()
        {
            DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
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
            dgvDDH.Columns["NgayTao"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvDDH.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
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
            _maNhanVien = "NV002";
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
            if (dgvDDH.CurrentCell != null)
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
    }
}
