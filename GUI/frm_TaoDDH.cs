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
    public partial class frm_TaoDDH : Form
    {
        public string MaNhanVien { get; set; }
        DonDatHang donDatHang = new DonDatHang();
        List<ChiTietDonDatHang> lstChiTietDonDatHang = new List<ChiTietDonDatHang>();
        List<SanPham> lstSanPham = new List<SanPham>();
        public frm_TaoDDH()
        {
            InitializeComponent();
            Load += Frm_TaoDDH_Load;
            dgvSP.SelectionChanged += DgvSP_SelectionChanged;
            btnThemCTDDH.Click += BtnThemCTDDH_Click;
            btnXoaCTDDH.Click += BtnXoaCTDDH_Click;
            dgvCTDDH.SelectionChanged += DgvCTDDH_SelectionChanged;
            nudSoLuongYeuCau.ValueChanged += NudSoLuongYeuCau_ValueChanged;
            btnLuuCTDDH.Click += BtnLuuCTDDH_Click;
            dgvCTDDH.CellValidating += DgvCTDDH_CellValidating;
            dgvCTDDH.CellValidated += DgvCTDDH_CellValidated;
            btnHoanTat.Click += BtnHoanTat_Click;
        }



        private void DinhDangDGVSP()
        {
            // Ẩn các cột không cần thiết
            dgvSP.Columns["SoLuongToiThieu"].Visible = false;
            dgvSP.Columns["GiaBan"].Visible = false;
            dgvSP.Columns["HinhAnh"].Visible = false;
            dgvSP.Columns["TrangThai"].Visible = false;
            dgvSP.Columns["NgayTao"].Visible = false;
            dgvSP.Columns["NgayCapNhat"].Visible = false;
            dgvSP.Columns["MaLoai"].Visible = false;
            dgvSP.Columns["LoaiSanPham"].Visible = false;

            // Đặt lại tên các cột
            dgvSP.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvSP.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvSP.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvSP.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgvSP.Columns["GiaNhap"].HeaderText = "Giá nhập";
            dgvSP.Columns["MoTa"].HeaderText = "Mô tả sản phẩm";

            // Định dạng các cột đặc biệt (Ví dụ: cột Giá nhập, Số lượng tồn)
            dgvSP.Columns["GiaNhap"].DefaultCellStyle.Format = "N0"; // Định dạng theo tiền tệ
            dgvSP.Columns["GiaNhap"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvSP.Columns["SoLuongTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Căn chỉnh Header
            foreach (DataGridViewColumn column in dgvSP.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Autosize cột để nội dung vừa khung
            dgvSP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Căn chỉnh toàn bộ cột mặc định
            dgvSP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void Frm_TaoDDH_Load(object sender, EventArgs e)
        {
            DonDatHangBLL donDatHangBLL = new DonDatHangBLL();

            // Lấy đơn đặt hàng cuối cùng
            string maDonDatHangCuoi = donDatHangBLL.LayMaDonDatHangCuoiCung();

            // Kiểm tra nếu có mã đơn hàng cuối cùng
            if (!string.IsNullOrEmpty(maDonDatHangCuoi))
            {
                // Tạo mã đơn đặt hàng mới từ mã đơn hàng cuối cùng
                // Giả sử mã đơn đặt hàng có định dạng là "DDH001", "DDH002", "DDH003"...
                string soCuoi = maDonDatHangCuoi.Substring(3); // Lấy phần số sau "DDH"
                int soMoi = int.Parse(soCuoi) + 1; // Tăng số lên 1

                // Tạo mã mới với định dạng "DDH" + số mới
                string maDonDatHangMoi = "DDH" + soMoi.ToString("D3"); // Đảm bảo mã có 3 chữ số, ví dụ DDH001

                // Hiển thị mã đơn đặt hàng mới trong TextBox hoặc Label
                txtMaDonDatHang.Text = maDonDatHangMoi;
            }
            else
            {
                // Nếu không có mã đơn hàng cuối cùng, tạo mã đơn hàng đầu tiên
                string maDonDatHangMoi = "DDH001";
                txtMaDonDatHang.Text = maDonDatHangMoi;
            }

            // Đổ dữ liệu nhân viên vào combobox
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            List<NhanVien> lstNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            cboNhanVien.DataSource = lstNhanVien;
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "MaNhanVien";
            string maNhanVien = MaNhanVien;
            if (!string.IsNullOrEmpty(maNhanVien))
            {
                cboNhanVien.SelectedValue = maNhanVien;
            }

            // Lấy ngày hiện tại làm ngày đặt hàng
            dtpNgayDatHang.Value = DateTime.Now;

            // Đổ dữ liệu nhà cung cấp vào combobox
            NhaCungCapBLL nhaCungCapBLL = new NhaCungCapBLL();
            List<NhaCungCap> lstNhaCungCap = nhaCungCapBLL.LayDanhSachNhaCungCap();
            cboNhaCungCap.DataSource = lstNhaCungCap;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.ValueMember = "MaNhaCungCap";
            cboNhaCungCap.SelectedIndex = -1; // Chọn mặc định là không chọn nhà cung cấp nào

            // Tạo một danh sách các sản phẩm để chọn
            SanPhamBLL sanPhamBLL = new SanPhamBLL();
            lstSanPham = sanPhamBLL.LayDanhSachSanPham();
            dgvSP.DataSource = lstSanPham;

            DinhDangDGVSP();
        }        

        private void DgvSP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSP.CurrentCell != null)
            {
                txtMaSanPham.Text = dgvSP.CurrentRow.Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = dgvSP.CurrentRow.Cells["TenSanPham"].Value.ToString();
                nudSoLuongYeuCau.Value = 1;
                txtDonGia.Text = Convert.ToInt32(dgvSP.CurrentRow.Cells["GiaNhap"].Value).ToString("N0");
            }
        }

        private void DinhDangDGVCTDDH()
        {
            // Đặt chế độ tự động điều chỉnh kích thước cột
            dgvCTDDH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ẩn các cột không cần thiết
            dgvCTDDH.Columns["STT"].Visible = false;
            dgvCTDDH.Columns["MaDonDatHang"].Visible = false;
            dgvCTDDH.Columns["SoLuongCungCap"].Visible = false;
            dgvCTDDH.Columns["SoLuongThieu"].Visible = false;
            dgvCTDDH.Columns["DonDatHang"].Visible = false;
            dgvCTDDH.Columns["SanPham"].Visible = false;

            // Đặt lại tên cột
            dgvCTDDH.Columns["MaChiTietDonDatHang"].HeaderText = "Mã chi tiết";
            dgvCTDDH.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvCTDDH.Columns["SoLuongYeuCau"].HeaderText = "Số lượng yêu cầu";
            dgvCTDDH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvCTDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvCTDDH.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvCTDDH.Columns["GhiChu"].HeaderText = "Ghi chú";
            dgvCTDDH.Columns["MaSanPham"].HeaderText = "Mã SP";

            // Định dạng số lượng và tiền
            dgvCTDDH.Columns["SoLuongYeuCau"].DefaultCellStyle.Format = "N0";
            dgvCTDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvCTDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            // Căn chỉnh dữ liệu
            dgvCTDDH.Columns["MaChiTietDonDatHang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTDDH.Columns["SoLuongYeuCau"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTDDH.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Đặt màu nền
            dgvCTDDH.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Đặt cột chỉ đọc
            dgvCTDDH.Columns["MaChiTietDonDatHang"].ReadOnly = true;
            dgvCTDDH.Columns["MaSanPham"].ReadOnly = true;
            dgvCTDDH.Columns["ThanhTien"].ReadOnly = true;

            // Đặt FillWeight để cột "Ghi chú" rộng nhất
            dgvCTDDH.Columns["MaChiTietDonDatHang"].FillWeight = 15;
            dgvCTDDH.Columns["DonViTinh"].FillWeight = 10;
            dgvCTDDH.Columns["SoLuongYeuCau"].FillWeight = 10;
            dgvCTDDH.Columns["DonGia"].FillWeight = 15;
            dgvCTDDH.Columns["ThanhTien"].FillWeight = 15;
            dgvCTDDH.Columns["TrangThai"].FillWeight = 10;
            dgvCTDDH.Columns["MaSanPham"].FillWeight = 10;
            dgvCTDDH.Columns["GhiChu"].FillWeight = 25; // Cột rộng nhất
        }

        private void BtnThemCTDDH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm sản phẩm này vào đơn đặt hàng không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dgvSP.CurrentCell != null)
                {
                    // Kiểm tra số lượng yêu cầu
                    if (nudSoLuongYeuCau.Value <= 0)
                    {
                        MessageBox.Show("Số lượng yêu cầu phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    ChiTietDonDatHang chiTietDonDatHang = new ChiTietDonDatHang();
                    string maCTDDHMoi;

                    if (lstChiTietDonDatHang == null || lstChiTietDonDatHang.Count == 0)
                    {
                        ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
                        string maCTDDHCuoiTrongDB = chiTietDonDatHangBLL.LayMaChiTietDonDatHangCuoi();

                        if (string.IsNullOrEmpty(maCTDDHCuoiTrongDB))
                        {
                            maCTDDHMoi = "CTDDH001";
                        }
                        else
                        {
                            string soCuoi = maCTDDHCuoiTrongDB.Substring(5);
                            int soMoi = int.Parse(soCuoi) + 1;
                            maCTDDHMoi = "CTDDH" + soMoi.ToString("D3");
                        }
                    }
                    else
                    {
                        // Lấy mã chi tiết cuối trong danh sách tạm thời
                        string maCTDDHCuoi = lstChiTietDonDatHang.Last().MaChiTietDonDatHang;
                        string soCuoi = maCTDDHCuoi.Substring(5);
                        int soMoi = int.Parse(soCuoi) + 1;
                        maCTDDHMoi = "CTDDH" + soMoi.ToString("D3");
                    }

                    // Gán giá trị cho đối tượng ChiTietDonDatHang
                    chiTietDonDatHang.MaChiTietDonDatHang = maCTDDHMoi;
                    chiTietDonDatHang.MaDonDatHang = txtMaDonDatHang.Text;
                    chiTietDonDatHang.DonViTinh = dgvSP.CurrentRow.Cells["DonViTinh"].Value.ToString();
                    chiTietDonDatHang.SoLuongYeuCau = (int)nudSoLuongYeuCau.Value;
                    chiTietDonDatHang.SoLuongCungCap = 0;
                    chiTietDonDatHang.SoLuongThieu = chiTietDonDatHang.SoLuongYeuCau;
                    chiTietDonDatHang.DonGia = Convert.ToInt32(dgvSP.CurrentRow.Cells["GiaNhap"].Value);
                    chiTietDonDatHang.ThanhTien = chiTietDonDatHang.DonGia * chiTietDonDatHang.SoLuongYeuCau;
                    chiTietDonDatHang.TrangThai = "Chưa xác nhận";
                    chiTietDonDatHang.GhiChu = string.Empty;
                    chiTietDonDatHang.MaSanPham = dgvSP.CurrentRow.Cells["MaSanPham"].Value.ToString();

                    // Thêm vào danh sách tạm
                    lstChiTietDonDatHang.Add(chiTietDonDatHang);

                    // Xoá sản phẩm khỏi danh sách sản phẩm và load lại dgvSP
                    lstSanPham.Remove(lstSanPham.FirstOrDefault(sp => sp.MaSanPham == chiTietDonDatHang.MaSanPham));
                    ReloadDGVSP();

                    // Load lại dgvCTDDH
                    ReloadDGVCTDDH();

                    MessageBox.Show("Sản phẩm đã được thêm vào đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm trước khi thêm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnXoaCTDDH_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xoá sản phẩm này khỏi đơn đặt hàng không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (dgvCTDDH.CurrentCell != null)
                {
                    string maSanPham = dgvCTDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
                    int soLuongYeuCau = (int)dgvCTDDH.CurrentRow.Cells["SoLuongYeuCau"].Value;
                    // Xoá sản phẩm khỏi danh sách chi tiết đơn đặt hàng
                    lstChiTietDonDatHang.Remove(lstChiTietDonDatHang.FirstOrDefault(ctddh => ctddh.MaSanPham == maSanPham));
                    dgvCTDDH.DataSource = null;
                    dgvCTDDH.DataSource = lstChiTietDonDatHang;
                    DinhDangDGVCTDDH();
                    dgvCTDDH.Refresh();
                    // Thêm sản phẩm vào danh sách sản phẩm và load lại dgvSP
                    SanPhamBLL sanPhamBLL = new SanPhamBLL();
                    SanPham sanPham = sanPhamBLL.GetProductById(maSanPham);
                    lstSanPham.Add(sanPham);
                    ReloadDGVSP();
                    MessageBox.Show("Sản phẩm đã được xoá khỏi đơn đặt hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm trước khi xoá.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ReloadDGVSP()
        {
            dgvSP.DataSource = null;
            dgvSP.DataSource = lstSanPham;
            DinhDangDGVSP();
            dgvSP.Refresh();
        }

        private void DgvCTDDH_SelectionChanged(object sender, EventArgs e)
        {
           if(dgvCTDDH.CurrentCell != null)
            {
                SanPhamBLL sanPhamBLL = new SanPhamBLL();
                txtMaSanPham.Text = dgvCTDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
                txtTenSanPham.Text = sanPhamBLL.GetProductById(txtMaSanPham.Text).TenSanPham;
                nudSoLuongYeuCau.Value = (int)dgvCTDDH.CurrentRow.Cells["SoLuongYeuCau"].Value;
                txtDonGia.Text = Convert.ToInt32(dgvCTDDH.CurrentRow.Cells["DonGia"].Value).ToString("N0");
                txtThanhTien.Text = Convert.ToInt32(dgvCTDDH.CurrentRow.Cells["ThanhTien"].Value).ToString("N0");
            }
        }

        private void NudSoLuongYeuCau_ValueChanged(object sender, EventArgs e)
        {
            if (dgvSP.CurrentCell != null && txtDonGia.Text != "")
            {
                int sl = (int)nudSoLuongYeuCau.Value;
                int donGia = Convert.ToInt32(txtDonGia.Text.Replace(",", ""));
                txtThanhTien.Text = (sl * donGia).ToString("N0");
            }
        }

        private void BtnLuuCTDDH_Click(object sender, EventArgs e)
        {
            int soLuongNew = (int)nudSoLuongYeuCau.Value;
            decimal thanhTienNew = txtThanhTien.Text == "" ? 0 : Convert.ToDecimal(txtThanhTien.Text.Replace(",", ""));

            if (dgvCTDDH.CurrentRow == null || dgvCTDDH.CurrentRow.Cells["MaChiTietDonDatHang"] == null)
            {
                MessageBox.Show("No row selected or invalid cell.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string maCTDDH = dgvCTDDH.CurrentRow.Cells["MaChiTietDonDatHang"].Value?.ToString();
            if (maCTDDH == null)
            {
                MessageBox.Show("Invalid cell value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ChiTietDonDatHang ctddhOld = lstChiTietDonDatHang.Where(x => x.MaChiTietDonDatHang == maCTDDH).FirstOrDefault();
            if (soLuongNew <= 0)
            {
                MessageBox.Show("Số lượng yêu cầu phải lớn hơn 0.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuongNew != ctddhOld?.SoLuongYeuCau || thanhTienNew != ctddhOld?.ThanhTien)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi không?",
                                                      "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (ctddhOld != null)
                    {
                        ctddhOld.SoLuongYeuCau = soLuongNew;
                        ctddhOld.ThanhTien = thanhTienNew;
                        ReloadDGVCTDDH();
                    }
                }
            }
        }

        private void ReloadDGVCTDDH()
        {
            dgvCTDDH.DataSource = null;
            dgvCTDDH.DataSource = lstChiTietDonDatHang;
            DinhDangDGVCTDDH();
            dgvCTDDH.Refresh();
        }

        private void DgvCTDDH_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Kiểm tra nếu ô đang chỉnh sửa thuộc cột SoLuongYeuCau
            if (dgvCTDDH.Columns[e.ColumnIndex].Name == "SoLuongYeuCau")
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int value) || value <= 0)
                {
                    // Hiển thị cảnh báo và ngăn giá trị không hợp lệ
                    MessageBox.Show("Số lượng phải là số nguyên dương!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true; // Hủy chỉnh sửa
                }
            }
        }

        private void DgvCTDDH_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu ô được chỉnh sửa thuộc cột SoLuongYeuCau
            if (dgvCTDDH.Columns[e.ColumnIndex].Name == "SoLuongYeuCau")
            {
                // Lấy giá trị từ các cột liên quan
                var row = dgvCTDDH.Rows[e.RowIndex];
                if (row.Cells["SoLuongYeuCau"].Value != null && row.Cells["DonGia"].Value != null)
                {
                    int soLuongYeuCau = Convert.ToInt32(row.Cells["SoLuongYeuCau"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);

                    // Tính lại giá trị Thành tiền
                    row.Cells["ThanhTien"].Value = soLuongYeuCau * donGia;

                    ChiTietDonDatHang ctddhOld = lstChiTietDonDatHang.Where(x=>x.MaChiTietDonDatHang == row.Cells["MaChiTietDonDatHang"].Value.ToString()).FirstOrDefault();
                    ctddhOld.SoLuongYeuCau = soLuongYeuCau;
                    ctddhOld.ThanhTien = soLuongYeuCau * donGia;
                    ctddhOld.SoLuongThieu = soLuongYeuCau;

                }
            }
        }

        private void BtnHoanTat_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhân viên
            if(cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên lập đơn đặt hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra nhà cung cấp
            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra danh sách chi tiết đơn đặt hàng
            if (lstChiTietDonDatHang == null || lstChiTietDonDatHang.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào đơn đặt hàng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hỏi xác nhận 
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hoàn tất đơn đặt hàng này không?",
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Tạo đơn đặt hàng
                donDatHang.MaDonDatHang = txtMaDonDatHang.Text;
                donDatHang.MaNhanVien = cboNhanVien.SelectedValue.ToString();
                donDatHang.MaNhaCungCap = cboNhaCungCap.SelectedValue.ToString();
                donDatHang.NgayDat = dtpNgayDatHang.Value;
                donDatHang.TrangThai = "Chưa xác nhận";
                donDatHang.NgayTao = dtpNgayDatHang.Value;
                donDatHang.NgayCapNhat = dtpNgayDatHang.Value;
                decimal tongTien = 0;
                foreach (ChiTietDonDatHang ctddh in lstChiTietDonDatHang)
                {
                    tongTien += (decimal)ctddh.ThanhTien;
                }
                donDatHang.TongTien = tongTien;

                // Lưu đơn đặt hàng
                DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
                if (donDatHangBLL.LuuDonDatHangVoiDanhSachChiTietDonDatHang(donDatHang, lstChiTietDonDatHang))
                {
                    MessageBox.Show("Tạo đơn đặt hàng thành công.\n Tổng giá trị đơn hàng là: "+tongTien.ToString("N0"), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tạo đơn đặt hàng thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
