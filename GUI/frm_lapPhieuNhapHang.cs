using BLL;
using DevExpress.XtraEditors.Design;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_lapPhieuNhapHang : Form
    {
        PhieuNhapBLL phieuNhapBLL = new PhieuNhapBLL();
        ChiTietPhieuNhapBLL chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
        public frm_lapPhieuNhapHang()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_lapPhieuNhapHang_Load;
            dgvPhieuNhap.SelectionChanged += DgvPhieuNhap_SelectionChanged;
           
        }

        private void DgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvPhieuNhap.CurrentRow;
                txtMaPN.Text = currentRow.Cells["MaPhieuNhap"].Value.ToString();
                loadChiTietPhieuNhap(txtMaPN.Text);
            }
            else
            {
                Console.Write("Không có dòng nào được chọn.");
            }
        }

        private void loadChiTietPhieuNhap(string maPN)
        {
            dgvChiTietPhieuNhap.DataSource = null;  // Đặt lại DataSource trước khi load dữ liệu mới
            try
            {
                // Lấy danh sách chi tiết phiếu nhập theo mã phiếu nhập
                List<ChiTietPhieuNhap> dsCPhieuNhap = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(maPN);

                if (dsCPhieuNhap != null && dsCPhieuNhap.Count > 0)
                {
                    // Dùng LINQ để ánh xạ sang đối tượng ViewModel hoặc DTO nếu cần
                    var dsCPhieuNhapViewModel = from ct in dsCPhieuNhap
                                                select new
                                                {
                                                    MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
                                                    DonViTinh = ct.DonViTinh,
                                                    SoLuong = ct.SoLuong,
                                                    DonGia = ct.DonGia,
                                                    ThanhTien = ct.ThanhTien,
                                                    MaCTDDH = ct.MaChiTietDonDatHang,
                                                  
                                                };

                    // Gán danh sách ViewModel vào DataGridView
                    dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel.ToList();

                    // Đặt tiêu đề cho các cột trong DataGridView
                    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
                    dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                    dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvChiTietPhieuNhap.Columns["MaCTDDH"].HeaderText = "Mã đơn đặt hàng";

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu nhập nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }


        private void Frm_lapPhieuNhapHang_Load(object sender, EventArgs e)
        {
            loadDSPhieuNhap();
        }
        private void loadDSPhieuNhap()
        {
            dgvPhieuNhap.DataSource = null;
            try
            {
                List<PhieuNhap> dsPhieuNhap = phieuNhapBLL.getAllPhieuNhap();
                if (dsPhieuNhap != null && dsPhieuNhap.Count > 0)
                {
                    // Dùng LINQ để ánh xạ sang đối tượng ViewModel hoặc DTO mà bạn đã tạo
                    var dsPhieuNhapViewModel = from pn in dsPhieuNhap
                                               select new
                                               {
                                                   MaPhieuNhap = pn.MaPhieuNhap,
                                                   NgayLap = pn.NgayLap,
                                                   TongTien = pn.TongTien,
                                                   TrangThai = pn.TrangThai,
                                                   LanNhap = pn.LanNhap,
                                                   MaDonDatHang = pn.DonDatHang != null ? pn.DonDatHang.MaDonDatHang : string.Empty,
                                                   MaNhanVien = pn.NhanVien != null ? pn.NhanVien.MaNhanVien : string.Empty
                                               };

                    dgvPhieuNhap.DataSource = dsPhieuNhapViewModel.ToList();                  
                    dgvPhieuNhap.Columns["MaPhieuNhap"].HeaderText = "Mã phiếu nhập";
                    dgvPhieuNhap.Columns["NgayLap"].HeaderText = "Ngày lập";
                    dgvPhieuNhap.Columns["TongTien"].HeaderText = "Tổng tiền";
                    dgvPhieuNhap.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvPhieuNhap.Columns["LanNhap"].HeaderText = "Lần nhập";
                    dgvPhieuNhap.Columns["MaDonDatHang"].HeaderText = "Mã đơn đặt hàng";
                    dgvPhieuNhap.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";

                    // Căn giữa tiêu đề cột và chỉnh font chữ
                    foreach (DataGridViewColumn column in dgvPhieuNhap.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }



        private void AddButtonPaintEvent()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint; // Gán sự kiện Paint cho mỗi nút
                }
            }
        }
        private void CustomButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Pen pen = new Pen(Color.Navy, 1); // Màu sắc và độ dày viền
            e.Graphics.DrawRectangle(pen, 0, 0, btn.Width - 1, btn.Height - 1);
        }

        private void AddButtonPaintEventRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button button)
                {
                    button.Paint += CustomButton_Paint;
                    button.MouseEnter += Button_MouseEnter;  // Thêm sự kiện hover vào nút
                    button.MouseLeave += Button_MouseLeave; // Thêm sự kiện rời chuột khỏi nút
                }
                else if (control.HasChildren)
                {
                    AddButtonPaintEventRecursive(control); // Đệ quy vào các container con
                }
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = SystemColors.Control; // Đặt lại màu nền mặc định khi rời chuột
            btn.ForeColor = Color.Black; // Đặt lại màu chữ mặc định nếu cần
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Navy; // Đổi màu nền khi chuột vào
            btn.ForeColor = Color.White; // Đổi màu chữ nếu cần
        }

      
    }
}
