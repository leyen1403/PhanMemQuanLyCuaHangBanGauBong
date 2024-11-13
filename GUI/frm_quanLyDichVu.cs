using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyDichVu : Form
    {
        List<PhieuDichVu> phieuDichVus = new List<PhieuDichVu>();
        PhieuDichVuBLL phieuDichVuBLL = new PhieuDichVuBLL();

        List<NhatKyDichVu> nhatKyDichVus = new List<NhatKyDichVu>();
        NhatKyDichVuBLL nhatKyDichVuBLL = new NhatKyDichVuBLL();
        public frm_quanLyDichVu()
        {
            InitializeComponent();
            phieuDichVuBLL = new PhieuDichVuBLL();
            cb_TimKiem.SelectedIndexChanged += Cb_TimKiem_SelectedIndexChanged;
            cb_TrangThai.Items.Add("Tiếp nhận");
            cb_TrangThai.Items.Add("Đang xử lý");
            cb_TrangThai.Items.Add("Hoàn thành");
            cb_TrangThai.Items.Add("Đã hủy");
            cb_TrangThai.SelectedIndex = 0;
            cb_TrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            // Thêm các lựa chọn vào ComboBox
            cb_TimKiem.Items.Add("Mã phiếu dịch vụ");
            cb_TimKiem.Items.Add("Mã khách hàng");
            cb_TimKiem.Items.Add("Mã nhân viên");
            cb_TimKiem.Items.Add("Trạng thái");
            cb_TimKiem.Items.Add("Ngày lập");
            
            cb_TimKiem.SelectedIndex = 0;
            cb_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void Cb_TimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_TimKiem.SelectedItem.ToString() == "Ngày lập")
            {
                dtpTuNgay.Enabled = true;
                dtpDenNgay.Enabled = true;
                txt_TimKiem.Enabled = false;
                cb_TrangThai.Enabled = false;
            }
            else if (cb_TimKiem.SelectedItem.ToString() == "Trạng thái")
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
                txt_TimKiem.Enabled = false;
                cb_TrangThai.Enabled = true;
            }
            else
            {
                dtpTuNgay.Enabled = false;
                dtpDenNgay.Enabled = false;
                txt_TimKiem.Enabled = true;
                cb_TrangThai.Enabled = false;

            }
        }

        private void frm_quanLyDichVu_Load(object sender, EventArgs e)
        {
            phieuDichVus = phieuDichVuBLL.GetPhieuDichVuList();
            LoadPhieuDichVuList();
            nhatKyDichVus = nhatKyDichVuBLL.GetNhatKyDichVuList();
            LoadNhatKyDichVuList();
        }
        private void LoadPhieuDichVuList()
        {
            dgv_DanhSachDichVu.DataSource = phieuDichVus;

            dgv_DanhSachDichVu.Columns["MaPhieuDichVu"].HeaderText = "Mã phiếu dịch vụ";
            dgv_DanhSachDichVu.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";
            dgv_DanhSachDichVu.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgv_DanhSachDichVu.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgv_DanhSachDichVu.Columns["NgayLap"].HeaderText = "Ngày lập";
            dgv_DanhSachDichVu.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_DanhSachDichVu.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgv_DanhSachDichVu.Columns["TrangThai"].HeaderText = "Trạng thái";

            // Kiểm tra và ẩn các cột không cần thiết
            if (dgv_DanhSachDichVu.Columns.Contains("KhachHang"))
                dgv_DanhSachDichVu.Columns["KhachHang"].Visible = false;

            if (dgv_DanhSachDichVu.Columns.Contains("NhanVien"))
                dgv_DanhSachDichVu.Columns["NhanVien"].Visible = false;
            if (dgv_DanhSachDichVu.Columns.Contains("NgayTao"))
                dgv_DanhSachDichVu.Columns["NgayTao"].Visible = false;

            dgv_DanhSachDichVu.Columns["NgayTao"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgv_DanhSachDichVu.Columns["NgayCapNhat"].DefaultCellStyle.Format = "yyyy-MM-dd";

        }
        private void LoadNhatKyDichVuList()
        {
            dgv_NhatKyDichVu.DataSource = nhatKyDichVus; 

            dgv_NhatKyDichVu.Columns["Landichvu"].HeaderText = "Lần dịch vụ";
            dgv_NhatKyDichVu.Columns["MaChiTietHoaDonBanHang"].HeaderText = "Mã chi tiết hóa đơn";
            dgv_NhatKyDichVu.Columns["MaPhieuDichVu"].HeaderText = "Mã phiếu dịch vụ";

            // Kiểm tra và ẩn các cột không cần thiết
            if (dgv_NhatKyDichVu.Columns.Contains("ChiTietHoaDonBanHang"))
                dgv_NhatKyDichVu.Columns["ChiTietHoaDonBanHang"].Visible = false;

            if (dgv_NhatKyDichVu.Columns.Contains("PhieuDichVu"))
                dgv_NhatKyDichVu.Columns["PhieuDichVu"].Visible = false;

        }

        private void label13_Click(object sender, EventArgs e)
        {
            //if (e.RowIndex >= 0) 
            //{
            //    string maPhieuDichVu = dgv_DanhSachDichVu.Rows[e.RowIndex].Cells["MaPhieuDichVu"].Value.ToString();
            //    var nhatKyPhieuDichVu = nhatKyDichVus.Where(nk => nk.MaPhieuDichVu == maPhieuDichVu).ToList();
            //    dgv_NhatKyDichVu.DataSource = nhatKyPhieuDichVu;
            //}
        }


        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            List<PhieuDichVu> filteredPhieuDichVus = new List<PhieuDichVu>();

            // Lọc phiếu dịch vụ dựa trên tiêu chí tìm kiếm và giá trị tìm kiếm
            string searchCriteria = cb_TimKiem.SelectedItem.ToString(); // Lấy tiêu chí tìm kiếm
            string searchValue = txt_TimKiem.Text.Trim(); // Lấy giá trị tìm kiếm từ TextBox

            // Kiểm tra tiêu chí tìm kiếm và lọc danh sách phiếu dịch vụ tương ứng
            if (string.IsNullOrEmpty(searchValue) && searchCriteria != "Ngày Lập" && searchCriteria != "Trạng thái")
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (searchCriteria)
            {
                case "Mã phiếu dịch vụ":
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.MaPhieuDichVu.Contains(searchValue)).ToList();
                    break;

                case "Mã khách hàng":
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.MaKhachHang.Contains(searchValue)).ToList();
                    break;

                case "Mã nhân viên":
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.MaNhanVien.Contains(searchValue)).ToList();
                    break;

                case "Ngày lập":
                    // Kiểm tra ngày bắt đầu và ngày kết thúc
                    DateTime fromDate = dtpTuNgay.Value.Date; // Lấy ngày bắt đầu từ DateTimePicker
                    DateTime toDate = dtpDenNgay.Value.Date;   // Lấy ngày kết thúc từ DateTimePicker

                    // Lọc danh sách phiếu dịch vụ trong khoảng thời gian
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.NgayLap >= fromDate && hd.NgayLap <= toDate).ToList();
                    break;

                case "Trạng thái":
                    string trangThai = cb_TrangThai.SelectedItem.ToString();
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.TrangThai==true).ToList();
                    break;

                default:
                    MessageBox.Show("Tiêu chí tìm kiếm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Cập nhật lại DataGridView với danh sách đã lọc
            dgv_DanhSachDichVu.DataSource = filteredPhieuDichVus;
        }


        private void btn_HienThiTatCa_Click(object sender, EventArgs e)
        {
            List<PhieuDichVu> filteredPhieuDichVus = new List<PhieuDichVu>();
            filteredPhieuDichVus = phieuDichVus.ToList(); 
            dgv_DanhSachDichVu.DataSource = filteredPhieuDichVus;
            List<NhatKyDichVu> filteredNhatKyDichVus = new List<NhatKyDichVu>();
            filteredNhatKyDichVus = nhatKyDichVus.ToList(); 
            dgv_NhatKyDichVu.DataSource = nhatKyDichVus;
        }
    }
}
