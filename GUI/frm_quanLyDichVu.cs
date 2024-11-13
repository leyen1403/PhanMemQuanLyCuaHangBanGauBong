using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;


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
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgv_DanhSachDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
