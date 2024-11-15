using BLL;
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
    public partial class frm_quanLyNhapHang : Form
    {
        List<PhieuNhap> listPhieuNhap = new List<PhieuNhap>();
        PhieuNhapBLL phieuNhapBLL = new PhieuNhapBLL();

        List<ChiTietPhieuNhap> listCTPhieuNhap = new List<ChiTietPhieuNhap>();
        ChiTietPhieuNhapBLL chiTietPhieuNhapBLL = new ChiTietPhieuNhapBLL();
        DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private BindingList<ChiTietPhieuNhap> bindingList;
        public frm_quanLyNhapHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyNhapHang_Load;
            this.btnTim.Click += BtnTim_Click;
            dgvPhieuNhap.SelectionChanged += DgvPhieuNhap_SelectionChanged;
            this.btnThemPN.Click += BtnThemPN_Click;
            this.btnTaoMoi.Click += BtnTaoMoi_Click;
            this.btnHuyPhieu.Click += BtnHuyPhieu_Click;
            this.btnLuuPhieu.Click += BtnLuuPhieu_Click;
            this.deleteMenuItem.Click += DeleteMenuItem_Click;
            
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.CurrentRow != null)
            {
                // Lấy MaChiTietPhieuNhap của dòng hiện tại
                string maChiTietPhieuNhap = dgvChiTietPhieuNhap.CurrentRow.Cells["MaChiTietPhieuNhap"].Value.ToString();

                // Tìm và xóa sản phẩm trong BindingList dựa trên MaChiTietPhieuNhap
                var itemToRemove = bindingList.FirstOrDefault(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
                if (itemToRemove != null)
                {
                    bindingList.Remove(itemToRemove); // Xóa từ BindingList
                }

                // Để DataGridView cập nhật, gán lại DataSource của dgvChiTietPhieuNhap với bindingList
                dgvChiTietPhieuNhap.DataSource = null;
                dgvChiTietPhieuNhap.DataSource = bindingList;

                // Cập nhật lại giao diện
                dgvChiTietPhieuNhap.Refresh();

                MessageBox.Show("Sản phẩm đã được xóa khỏi chi tiết phiếu nhập.");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }

        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text;

            // Tạo danh sách `ChiTietPhieuNhap` từ `dgvChiTietPhieuNhap`
            List<ChiTietPhieuNhap> updatedList = new List<ChiTietPhieuNhap>();

            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                if (row.Cells["MaChiTietPhieuNhap"].Value != null)
                {
                    ChiTietPhieuNhap ct = new ChiTietPhieuNhap
                    {
                        MaChiTietPhieuNhap = row.Cells["MaChiTietPhieuNhap"].Value.ToString(),
                        MaPhieuNhap = maPN,
                        DonViTinh = row.Cells["DonViTinh"].Value?.ToString(),
                        SoLuong = row.Cells["SoLuong"].Value != null ? Convert.ToInt32(row.Cells["SoLuong"].Value) : 0,
                        DonGia = row.Cells["DonGia"].Value != null ? Convert.ToDecimal(row.Cells["DonGia"].Value) : 0,
                        ThanhTien = row.Cells["ThanhTien"].Value != null ? Convert.ToDecimal(row.Cells["ThanhTien"].Value) : 0,
                        TrangThai = row.Cells["TrangThai"].Value?.ToString(),
                        GhiChu = row.Cells["GhiChu"].Value?.ToString(),
                        MaChiTietDonDatHang = row.Cells["MaCTDDH"].Value?.ToString()
                    };

                    updatedList.Add(ct);
                }
            }

            // Gọi lớp BLL để lưu vào cơ sở dữ liệu
            try
            {
                var bll = new ChiTietPhieuNhapBLL();  // Khởi tạo lớp BLL
                bll.UpdateChiTietPhieuNhapList(updatedList, maPN); // Cập nhật dữ liệu vào cơ sở dữ liệu
                MessageBox.Show("Phiếu nhập đã được lưu thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void BtnHuyPhieu_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text;
            bool isSuccess = phieuNhapBLL.DeletePhieuNhap(maPN);
            if (isSuccess)
            {
                MessageBox.Show("Xóa phiếu nhập thành công.");
                listPhieuNhap = phieuNhapBLL.getAllPhieuNhap();
                dgvPhieuNhap.DataSource = listPhieuNhap;
                anhXaPhieuNhap();
            }
            else
            {
                MessageBox.Show("Xóa thất bại.");
            }
           
           
        }

        private void BtnTaoMoi_Click(object sender, EventArgs e)
        {
            cbbLuaChonHienThi.SelectedIndex = 0;
            loadCbbMaNhanVien();
            loadCbbDonDatHang();
            loadCbbNhanVien();
            dtpTuNgay.Value =DateTime.Now;
            dtpDenNgay.Value =DateTime.Now;
            txtMaPN.Clear();
            txtLanNhap.Clear();
            txtTrangThai.Clear();
            txtTongTien.Clear();
            dTPNgayLap.Value =DateTime.Now;
        }

        private void BtnThemPN_Click(object sender, EventArgs e)
        {
            frm_lapPhieuNhapHang frm = new frm_lapPhieuNhapHang();
            frm.ShowDialog();
        }

        private void DgvPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhieuNhap.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvPhieuNhap.CurrentRow;
                txtMaPN.Text = currentRow.Cells["MaPhieuNhap"].Value?.ToString();
                txtLanNhap.Text = currentRow.Cells["LanNhap"].Value?.ToString();
                cbbNhanVien.SelectedValue = currentRow.Cells["MaNhanVien"].Value?.ToString();
                txtTrangThai.Text = currentRow.Cells["TrangThai"].Value?.ToString();
                txtTongTien.Text = currentRow.Cells["TongTien"].Value?.ToString();
                dTPNgayLap.Value = Convert.ToDateTime(currentRow.Cells["NgayLap"].Value);
                loadChiTietPhieuNhap(txtMaPN.Text);
            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string selectedValue = cbbLuaChonHienThi.SelectedItem.ToString();
            if (selectedValue == "Tất cả phiếu nhập")
            {
                listPhieuNhap = phieuNhapBLL.getAllPhieuNhap();
                dgvPhieuNhap.DataSource = listPhieuNhap;
                anhXaPhieuNhap();
                
            }
            if (selectedValue == "Phiếu theo ngày lập")
            {
                DateTime ngayBatDau = dtpTuNgay.Value;
                DateTime ngayKetThuc = dtpDenNgay.Value;
                listPhieuNhap = phieuNhapBLL.GetListPhieuNhapByDate(ngayBatDau, ngayKetThuc);
                dgvPhieuNhap.DataSource = listPhieuNhap;
                anhXaPhieuNhap();
               
            }
            if (selectedValue == "Phiếu theo nhân viên")
            {
                string maNhanVien = cbbMaNhanVien.SelectedValue.ToString();
                listPhieuNhap = phieuNhapBLL.GetListPhieuNhapByNhanVien(maNhanVien);
                dgvPhieuNhap.DataSource = dgvPhieuNhap;
                anhXaPhieuNhap();
               
            }
        }
        private void anhXaPhieuNhap()
        {
            if (listPhieuNhap != null && listPhieuNhap.Count > 0)
            {
                // Dùng LINQ để ánh xạ sang đối tượng ViewModel hoặc DTO mà bạn đã tạo
                var dsPhieuNhapViewModel = from pn in listPhieuNhap
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
                loadDSPhieuNhap();
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu nhập nào.");
            }
        }
        private void loadChiTietPhieuNhap(string maPN)
        {
            dgvChiTietPhieuNhap.DataSource = null;
            try
            {
                List<ChiTietPhieuNhap> dsCPhieuNhap = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(maPN);

                if (dsCPhieuNhap != null && dsCPhieuNhap.Count > 0)
                {
                    var dsCPhieuNhapViewModel = from ct in dsCPhieuNhap
                                                select new
                                                {
                                                    MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
                                                    TenSanPham = chiTietPhieuNhapBLL.GetProductNameByMaCTDDH(ct.MaChiTietDonDatHang),
                                                    DonViTinh = ct.DonViTinh,
                                                    SoLuong = ct.SoLuong,
                                                    DonGia = ct.DonGia,
                                                    ThanhTien = ct.ThanhTien,
                                                    MaCTDDH = ct.MaChiTietDonDatHang,
                                                    TrangThai = ct.TrangThai,
                                                    GhiChu = ct.GhiChu
                                                };
                    dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel.ToList();
                    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
                    dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                    dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvChiTietPhieuNhap.Columns["MaCTDDH"].Visible = false;
                    dgvChiTietPhieuNhap.Columns["TrangThai"].Visible = false;
                    dgvChiTietPhieuNhap.Columns["GhiChu"].Visible = false;

                    foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvChiTietPhieuNhap.RowPostPaint += dgv_RowPostPaint;
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

        private void loadDSPhieuNhap()
        {                   
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
                    dgvPhieuNhap.RowPostPaint += dgv_RowPostPaint;
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near, // Căn trái
                LineAlignment = System.Drawing.StringAlignment.Center // Giữa theo chiều dọc
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }
        private void loadCbbDonDatHang()
        {
            try
            {
                List<DonDatHang> dsDonDatHang = donDatHangBLL.LayDanhSachDonDatHang();
                if (dsDonDatHang != null && dsDonDatHang.Count > 0)
                {
                    cbbMaDDH.DataSource = null;
                    cbbMaDDH.DataSource = dsDonDatHang;
                    cbbMaDDH.ValueMember = "MaDonDatHang";
                    cbbMaDDH.DisplayMember = "MaDonDatHang";
                }
                else
                {
                    MessageBox.Show("Không có đơn đặt hàng nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách đơn đặt hàng.");
            }
        }
        private void loadCbbNhanVien()
        {
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();
                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    cbbNhanVien.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbbNhanVien.DataSource = dsNhanVien;
                    cbbNhanVien.ValueMember = "MaNhanVien";
                    cbbNhanVien.DisplayMember = "HoTen";
                }
                else
                {
                    MessageBox.Show("Không có nhân viên nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ.");
            }
        }

        private void Frm_quanLyNhapHang_Load(object sender, EventArgs e)
        {
            loadCbbNhanVien();
            loadCbbDonDatHang();
            cbbLuaChonHienThi.SelectedIndex = 0;
            loadCbbMaNhanVien();
            bindingList = new BindingList<ChiTietPhieuNhap>(listCTPhieuNhap);

            dgvChiTietPhieuNhap.DataSource = bindingList;
        }
        private void loadCbbMaNhanVien()
        {
            try
            {
                List<NhanVien> dsNhanVien = nhanVienBLL.getAllNhanVien();
                if (dsNhanVien != null && dsNhanVien.Count > 0)
                {
                    cbbMaNhanVien.DataSource = null; // Đặt lại trước khi gán nguồn dữ liệu
                    cbbMaNhanVien.DataSource = dsNhanVien;
                    cbbMaNhanVien.ValueMember = "MaNhanVien";
                    cbbMaNhanVien.DisplayMember = "HoTen";
                }
                else
                {
                    MessageBox.Show("Không có nhân viên nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên.");
            }
        }

    }
}
