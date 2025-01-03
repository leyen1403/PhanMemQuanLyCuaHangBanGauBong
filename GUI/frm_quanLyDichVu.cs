﻿using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyDichVu : Form
    {
        List<ChiTietHoaDonBanHang> chiTietHoaDonBanHangs = new List<ChiTietHoaDonBanHang>();  // Danh sách khách hàng
        ChiTietHoaDonBanHangBLL chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL();
        List<KhachHang> khachHangs = new List<KhachHang>();  // Danh sách khách hàng
        KhachHangBLL khachHangBll = new KhachHangBLL();


        List<PhieuDichVu> phieuDichVus = new List<PhieuDichVu>();
        PhieuDichVuBLL phieuDichVuBLL = new PhieuDichVuBLL();

        List<NhatKyDichVu> nhatKyDichVus = new List<NhatKyDichVu>();
        NhatKyDichVuBLL nhatKyDichVuBLL = new NhatKyDichVuBLL();
        public frm_quanLyDichVu()
        {
            InitializeComponent();
            phieuDichVuBLL = new PhieuDichVuBLL();
            cb_TimKiem.SelectedIndexChanged += Cb_TimKiem_SelectedIndexChanged;
            dgv_DanhSachDichVu.CellClick += Dgv_DanhSachDichVu_CellClick;
            dgv_NhatKyDichVu.CellClick += Dgv_NhatKyDichVu_CellClick;
            dgv_DanhSachDichVu.DataBindingComplete += Dgv_DanhSachDichVu_DataBindingComplete;
            txt_GhiChu.ReadOnly = true;
            txt_LanDichVu.ReadOnly = true;
            txt_MaPDV.ReadOnly = true;
            txt_TenKH.ReadOnly = true;
            txt_TenSP.ReadOnly = true;
            txt_TongTien.ReadOnly = true;
            cb_TrangThai.Items.Add("Đã xong");
            cb_TrangThai.Items.Add("Chưa xong");
            cb_TrangThai.SelectedIndex = 0;
            cb_TrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_UpTrangTrai.Items.Add("Chưa xong");
            cb_UpTrangTrai.Items.Add("Đã xong");
            cb_UpTrangTrai.SelectedIndex = 0;
            cb_UpTrangTrai.DropDownStyle = ComboBoxStyle.DropDownList;
            // Thêm các lựa chọn vào ComboBox
            cb_TimKiem.Items.Add("Mã phiếu dịch vụ");
            cb_TimKiem.Items.Add("Mã khách hàng");
            cb_TimKiem.Items.Add("Mã nhân viên");
            cb_TimKiem.Items.Add("Trạng thái");
            cb_TimKiem.Items.Add("Ngày lập");
            
            cb_TimKiem.SelectedIndex = 0;
            cb_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        private void Dgv_NhatKyDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgv_NhatKyDichVu.Rows[e.RowIndex];
                string lanDichVu = row.Cells["Landichvu"].Value.ToString();
                string maChiTietHoaDon = row.Cells["MaChiTietHoaDonBanHang"].Value.ToString();
                string maPhieuDichVu = row.Cells["MaPhieuDichVu"].Value.ToString();

                txt_LanDichVu.Text = lanDichVu;

                var chiTietHoaDonList = chiTietHoaDonBanHangBLL.GetAllChiTietHoaDonBanHang();
                var chiTietHoaDon = chiTietHoaDonList?.FirstOrDefault(ct => ct.MaChiTietHoaDonBanHang == maChiTietHoaDon);

                if (chiTietHoaDon != null)
                {
                    string maSanPham = chiTietHoaDon.MaSanPham;
                    var sanPhamBLL = new SanPhamBLL();
                    var sanPham = sanPhamBLL.GetProductById(maSanPham); // Hoặc GetSanPhamByMaSP(maSanPham)

                    txt_TenSP.Text = sanPham?.TenSanPham ?? "Không tìm thấy sản phẩm";
                }
            }
        }

        private void Dgv_DanhSachDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
           
                
                // Lấy thông tin phiếu dịch vụ từ dgv_DanhSachDichVu
                var row = dgv_DanhSachDichVu.Rows[e.RowIndex];
                string maPhieuDichVu = row.Cells["MaPhieuDichVu"].Value.ToString();
                string maKhachHang = row.Cells["MaKhachHang"].Value.ToString();
                string ghiChu = row.Cells["GhiChu"].Value.ToString();
                DateTime ngayLap = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                DateTime ngayCapNhat = Convert.ToDateTime(row.Cells["NgayCapNhat"].Value);
                decimal tongTien = Convert.ToDecimal(row.Cells["TongTien"].Value);
                string trangThai = row.Cells["TrangThai"].Value.ToString();

                // Cập nhật vào các ô nhập liệu
                txt_MaPDV.Text = maPhieuDichVu;
                txt_TenKH.Text = maKhachHang; // Bạn có thể thay đổi theo logic lấy tên khách hàng
                txt_GhiChu.Text = ghiChu;
                txt_TongTien.Text = tongTien.ToString();
                cb_TrangThai.SelectedItem = trangThai;

                var khachHang = khachHangBll.GetKhachHang(maKhachHang); // Lấy thông tin khách hàng từ mã khách hàng

                if (khachHang != null)
                {
                    // Cập nhật tên khách hàng vào textbox
                    txt_TenKH.Text = khachHang.TenKhachHang; // Hoặc tên trường tên khách hàng trong bảng KhachHang
                }
                else
                {
                    txt_TenKH.Text = "Không tìm thấy khách hàng";
                }

                // Lọc nhật ký dịch vụ theo mã phiếu dịch vụ
                var nhatKyPhieuDichVu = nhatKyDichVus.Where(nk => nk.MaPhieuDichVu == maPhieuDichVu).ToList();
                dgv_NhatKyDichVu.DataSource = nhatKyPhieuDichVu;
            }
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
            dgv_DanhSachDichVu.DataSource = null;
            // Gán dữ liệu vào DataGridView
            dgv_DanhSachDichVu.DataSource = phieuDichVus;

            // Thêm cột "Trạng Thái Hiển Thị" vào DataGridView nếu chưa có
            if (!dgv_DanhSachDichVu.Columns.Contains("TrangThaiHienThi"))
            {
                DataGridViewTextBoxColumn trangThaiHienThiColumn = new DataGridViewTextBoxColumn();
                trangThaiHienThiColumn.Name = "TrangThaiHienThi";
                trangThaiHienThiColumn.HeaderText = "Trạng thái";
                dgv_DanhSachDichVu.Columns.Add(trangThaiHienThiColumn);
            }

            // Thiết lập lại các tiêu đề cột
            dgv_DanhSachDichVu.Columns["MaPhieuDichVu"].HeaderText = "Mã phiếu dịch vụ";
            dgv_DanhSachDichVu.Columns["MaKhachHang"].HeaderText = "Mã khách hàng";
            dgv_DanhSachDichVu.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dgv_DanhSachDichVu.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgv_DanhSachDichVu.Columns["NgayLap"].HeaderText = "Ngày lập";
            dgv_DanhSachDichVu.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgv_DanhSachDichVu.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgv_DanhSachDichVu.Columns["TrangThai"].Visible = false; // Ẩn cột trạng thái gốc

            // Kiểm tra và ẩn các cột không cần thiết
            if (dgv_DanhSachDichVu.Columns.Contains("KhachHang"))
                dgv_DanhSachDichVu.Columns["KhachHang"].Visible = false;

            if (dgv_DanhSachDichVu.Columns.Contains("NhanVien"))
                dgv_DanhSachDichVu.Columns["NhanVien"].Visible = false;
            if (dgv_DanhSachDichVu.Columns.Contains("NgayTao"))
                dgv_DanhSachDichVu.Columns["NgayTao"].Visible = false;

            dgv_DanhSachDichVu.Columns["NgayLap"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgv_DanhSachDichVu.Columns["NgayCapNhat"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dgv_DanhSachDichVu.Columns["TrangThaiHienThi"].DisplayIndex = dgv_DanhSachDichVu.Columns.Count - 1;
        }

        private void Dgv_DanhSachDichVu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgv_DanhSachDichVu.Rows)
            {
                // Kiểm tra cột "TrangThaiHienThi" có tồn tại và cập nhật giá trị
                if (dgv_DanhSachDichVu.Columns.Contains("TrangThaiHienThi"))
                {
                    if (row.Cells["TrangThai"].Value != null)
                    {
                        bool trangThai = (bool)row.Cells["TrangThai"].Value;
                        row.Cells["TrangThaiHienThi"].Value = trangThai ? "Đã xong" : "Chưa xong";
                    }
                }
            }
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
        }


        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            List<PhieuDichVu> filteredPhieuDichVus = new List<PhieuDichVu>();

            // Lọc phiếu dịch vụ dựa trên tiêu chí tìm kiếm và giá trị tìm kiếm
            string searchCriteria = cb_TimKiem.SelectedItem.ToString(); // Lấy tiêu chí tìm kiếm
            string searchValue = txt_TimKiem.Text.Trim(); // Lấy giá trị tìm kiếm từ TextBox

            // Kiểm tra tiêu chí tìm kiếm và lọc danh sách phiếu dịch vụ tương ứng
            if (string.IsNullOrEmpty(searchValue) && searchCriteria != "Ngày lập" && searchCriteria != "Trạng thái")
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
                    // Kiểm tra nếu dtpTuNgay lớn hơn hoặc bằng dtpDenNgay
                    if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng việc tìm kiếm
                    }

                    // Tiếp tục xử lý tìm kiếm khi điều kiện ngày hợp lệ
                    DateTime fromDate = dtpTuNgay.Value.Date;
                    DateTime toDate = dtpDenNgay.Value.Date;

                    // Lọc danh sách phiếu dịch vụ trong khoảng thời gian
                    filteredPhieuDichVus = phieuDichVus.Where(hd => hd.NgayLap >= fromDate && hd.NgayLap <= toDate).ToList();
                    break;


                case "Trạng thái":
                    // Lấy giá trị trạng thái từ ComboBox và chuyển đổi sang kiểu bool
                    string trangThaiHienThi = cb_TrangThai.SelectedItem.ToString();

                    // Kiểm tra nếu giá trị là "Đã xong" hoặc "Chưa xong" để tìm kiếm theo bool
                    bool? trangThai = null;
                    if (trangThaiHienThi == "Đã xong")
                    {
                        trangThai = true;
                    }
                    else if (trangThaiHienThi == "Chưa xong")
                    {
                        trangThai = false;
                    }

                    // Lọc danh sách theo trạng thái nếu có giá trị
                    if (trangThai.HasValue)
                    {
                        filteredPhieuDichVus = phieuDichVus.Where(hd => hd.TrangThai == trangThai.Value).ToList();
                    }
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

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            // Lấy mã phiếu dịch vụ cần cập nhật
            string maPhieuDichVu = txt_MaPDV.Text;  // Lấy từ TextBox hoặc GridView

            // Kiểm tra xem phiếu dịch vụ có tồn tại hay không
            PhieuDichVuBLL phieuDichVuBLL = new PhieuDichVuBLL();
            PhieuDichVu phieuDichVu = phieuDichVuBLL.GetPhieuDichVuById(maPhieuDichVu);

            if (phieuDichVu == null)
            {
                MessageBox.Show("Phiếu dịch vụ không tồn tại.");
                return;
            }

            // Lấy trạng thái mới từ ComboBox
            bool trangThaiMoi = cb_UpTrangTrai.SelectedItem.ToString() == "Đã xong";

            // Cập nhật trạng thái cho phiếu dịch vụ
            phieuDichVu.TrangThai = trangThaiMoi;
            phieuDichVu.NgayCapNhat = DateTime.Now;

            // Lưu kết quả cập nhật
            string errorMessage;
            bool isUpdated = phieuDichVuBLL.UpdatePhieuDichVu(phieuDichVu, out errorMessage);

            if (isUpdated)
            {
                MessageBox.Show("Cập nhật trạng thái thành công!");


                phieuDichVus = phieuDichVuBLL.GetPhieuDichVuList();
                // Làm mới DataGridView sau khi cập nhật
                LoadPhieuDichVuList();  // Gọi phương thức để tải lại dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại: " + errorMessage);
            }
        }
    }
}
