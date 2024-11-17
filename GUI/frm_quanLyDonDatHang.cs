using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyDonDatHang : Form
    {
        public string _maNhanVien { get; set; }

        List<NhaCungCap> _listNhaCungCap = new List<NhaCungCap>();
        NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();

        List<NhanVien> _listNhanVien = new List<NhanVien>();
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        List<DonDatHang> _listDonDatHang = new List<DonDatHang>();
        DonDatHangBLL _donDatHangBLL = new DonDatHangBLL();

        List<ChiTietDonDatHang> _listCTDDH = new List<ChiTietDonDatHang>();
        ChiTietDonDatHangBLL _chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();

        SanPhamBLL _sanPhamBLL = new SanPhamBLL();

        public frm_quanLyDonDatHang()
        {
            InitializeComponent();
            this.Load += Frm_quanLyDonDatHang_Load;
            this.cbbLuaChonHienThi.SelectedIndexChanged += CbbLuaChonHienThi_SelectedIndexChanged;
            this.dgvDanhSachDonDatHang.DataBindingComplete += dgvDanhSachDonDatHang_DataBindingComplete;
            this.btnTim.Click += BtnTim_Click;
            this.dgvDanhSachDonDatHang.SelectionChanged += dgvDanhSachDonDatHang_SelectionChanged;
            this.dgvChiTietDDH.DataBindingComplete += dgvChiTietDDH_DataBindingComplete;
            this.dgvChiTietDDH.SelectionChanged += dgvChiTietDDH_SelectionChanged;
            this.txtDonGia.KeyPress += TxtDonGia_KeyPress;
            this.txtDonGia.TextChanged += TxtDonGia_TextChanged;
            this.txtSoLuongCungCap.ValueChanged += TxtSoLuongCungCap_ValueChanged;
            this.btnCapNhat.Click += BtnCapNhat_Click;
            this.txtSoLuongYeuCau.ValueChanged += TxtSoLuongCungCap_ValueChanged;
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
            DonDatHang ddh = new DonDatHang();
            if (dgvChiTietDDH.Rows.Count > 0)
            {
                string maSP = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
                sp = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHang().Where(ct => ct.MaSanPham == maSP).FirstOrDefault().SanPham;
                sp.GiaNhap = Convert.ToDecimal(txtDonGia.Text.Replace(",", ""));
                sp.NgayCapNhat = DateTime.Now;
                if (!_sanPhamBLL.UpdateProduct(sp))
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại");
                }
                string maDDH = dgvChiTietDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
                ddh = _donDatHangBLL.LayDonDayHang(maDDH);
                ddh.TongTien = Convert.ToDecimal(txtTongTien.Text.Replace(",", ""));
                ddh.NgayCapNhat = DateTime.Now;
                ddh.TrangThai = cbbTrangThaiCTDDH.SelectedValue.ToString();
                ddh.MaNhanVien = _maNhanVien;
                if (!_donDatHangBLL.CapNhatDonDatHang(ddh))
                {
                    MessageBox.Show("Cập nhật đơn đặt hàng thất bại");
                    return;
                }
                ctddh = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(maDDH).Where(ct => ct.MaSanPham == maSP).FirstOrDefault();
                ctddh.SoLuongYeuCau = Convert.ToInt32(txtSoLuongYeuCau.Value.ToString());
                ctddh.SoLuongCungCap = Convert.ToInt32(txtSoLuongCungCap.Value.ToString());
                ctddh.SoLuongThieu = int.Parse(txtSoLuongThieu.Text);
                ctddh.DonGia = Convert.ToDecimal(txtDonGia.Text.Replace(",", ""));
                ctddh.ThanhTien = Convert.ToDecimal(txtThanhTien.Text.Replace(",", ""));
                if (cbbTrangThaiCTDDH.SelectedValue != null)
                {
                    ctddh.TrangThai = cbbTrangThaiCTDDH.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Hãy chọn trạng thái.");
                    return;
                }
                ctddh.TrangThai = cbbTrangThaiCTDDH.SelectedValue.ToString();
                if (!_chiTietDonDatHangBLL.CapNhatChiTietDonDatHang(ctddh))
                {
                    MessageBox.Show("Cập nhật chi tiết đơn đặt hàng thất bại");
                    return;
                }
                MessageBox.Show("Cập nhật thành công");
                hienThiDanhSachDonDatHang();
                return;
            }
            else
            {
                MessageBox.Show("Chưa chọn đúng");
            }
        }
        void hienThiDanhSachDonDatHang()
        {
            string luaChon = cbbLuaChonHienThi.SelectedValue.ToString();
            switch (luaChon)
            {
                case "TatCa":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhanVien":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(d => d.MaNhanVien == cbbNhanVien.SelectedValue.ToString()).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NgayDatHang":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(d => d.NgayDat >= dtpTuNgay.Value && d.NgayDat <= dtpDenNgay.Value).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "TrangThai":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(d => d.TrangThai == cbbTrangThai.SelectedValue.ToString()).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhaCungCap":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(d => d.MaNhaCungCap == cbbNhaCungCap.SelectedValue.ToString()).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                default:
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
            }
        }

        private void TxtSoLuongCungCap_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tinhToanTien();
            }
            catch
            {

            }
        }

        private void TxtDonGia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string input = txtDonGia.Text.Replace(",", "");
                if (string.IsNullOrEmpty(txtDonGia.Text))
                {
                    txtDonGia.Text = "0";
                    return;
                }
                if (decimal.TryParse(input, out decimal result))
                {
                    txtDonGia.Text = result.ToString("N0");
                    txtDonGia.SelectionStart = txtDonGia.Text.Length;
                }
                tinhToanTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void tinhToanTien()
        {

            int soLuong = int.Parse(txtSoLuongCungCap.Text);
            decimal donGia = decimal.Parse(txtDonGia.Text.Replace(",", ""));
            decimal thanhTienMoi = soLuong * donGia;

            if (dgvDanhSachDonDatHang.CurrentRow != null && dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value != null)
            {
                decimal tongTienCu = Convert.ToDecimal(dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value.ToString());
                decimal thanhTienCu = Convert.ToDecimal(dgvChiTietDDH.CurrentRow.Cells["ThanhTien"].Value.ToString());
                decimal tongTienMoi = tongTienCu - thanhTienCu + thanhTienMoi;
                int soLuongThieu = (int)(txtSoLuongYeuCau.Value - txtSoLuongCungCap.Value);
                txtSoLuongThieu.Text = soLuongThieu.ToString();
                txtTongTien.Text = tongTienMoi.ToString("N0");
                txtThanhTien.Text = thanhTienMoi.ToString("N0");
            }
            else
            {
                clearAll();
            }


        }

        private void clearAll()
        {
            txtSoLuongCungCap.Text = "0";
            txtDonGia.Text = "0";
            txtThanhTien.Text = "0";
            txtTongTien.Text = "0";
            txtTenLoai.Text = "";
            txtTenSP.Text = "";
            txtSoLuongYeuCau.Text = "";
            txtSoLuongThieu.Text = "";
        }

        private void TxtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void dgvChiTietDDH_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvChiTietDDH.DataSource != null)
            {
                string maSP = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
                SanPham sp = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHang().Where(ct => ct.MaSanPham == maSP).FirstOrDefault().SanPham;
                txtTenSP.Text = sp.TenSanPham;
                txtTenLoai.Text = sp.LoaiSanPham.TenLoai;
                txtSoLuongYeuCau.Text = dgvChiTietDDH.CurrentRow.Cells["SoLuongYeuCau"].Value.ToString();
                txtSoLuongCungCap.Text = dgvChiTietDDH.CurrentRow.Cells["SoLuongCungCap"].Value.ToString();
                txtSoLuongThieu.Text = dgvChiTietDDH.CurrentRow.Cells["SoLuongThieu"].Value.ToString();
                txtDonGia.Text = Convert.ToDecimal(dgvChiTietDDH.CurrentRow.Cells["DonGia"].Value).ToString("N0");
                txtThanhTien.Text = Convert.ToDecimal(dgvChiTietDDH.CurrentRow.Cells["ThanhTien"].Value).ToString("N0");
                string trangThai = dgvChiTietDDH.CurrentRow.Cells["TrangThai"].Value.ToString();
                cbbTrangThaiCTDDH.SelectedValue = trangThai;
                if (dgvDanhSachDonDatHang.CurrentRow != null && dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value != null)
                {
                    txtTongTien.Text = Convert.ToDecimal(dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value).ToString("N0");
                }
                string tenMau = new SanPhamMauSacBLL().GetOldProductColor(maSP);
                string tenKichThuoc = new SanPhamKichThuocBLL().GetOldSize(maSP);
                if(tenMau != null || tenKichThuoc != null)
                {
                    tenMau = new BLL.MauSacBLL().GetAllMauSac().Where(x => x.MaMau == tenMau).FirstOrDefault().TenMau;
                    tenKichThuoc = new BLL.KichThuocBLL().GetAll().Where(x => x.MaKichThuoc == tenKichThuoc).FirstOrDefault().TenKichThuoc;
                    txtMau.Text = tenMau;
                    txtKichThuoc.Text = tenKichThuoc;
                }

            }
            
        }

        private void dgvDanhSachDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            string maDonDatHang = dgvDanhSachDonDatHang.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
            _listCTDDH = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(maDonDatHang);
            if(_listCTDDH.Count < 0)
            {
                dgvChiTietDDH.DataSource = null;
                return;
            }
            ThemCotSoThuTu(dgvChiTietDDH);
            dgvChiTietDDH.DataSource = _listCTDDH;
            suaTieuDeCotDSCTDDH();
            string trangThaiDonHang = dgvDanhSachDonDatHang.CurrentRow.Cells["TrangThai"].Value.ToString();
            foreach(var item in cbbTrangThaiCTDDH.Items)
            {
                if (item.ToString() == trangThaiDonHang)
                {
                    cbbTrangThaiCTDDH.SelectedValue = trangThaiDonHang;
                    break;
                }
            }
        }

        private void suaTieuDeCotDSCTDDH()
        {
            dgvChiTietDDH.Columns["MaDonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["STT"].Visible = false;
            dgvChiTietDDH.Columns["MaChiTietDonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            dgvChiTietDDH.Columns["SoLuongYeuCau"].HeaderText = "Số lượng yêu cầu";
            dgvChiTietDDH.Columns["SoLuongCungCap"].HeaderText = "Số lượng cung cấp";
            dgvChiTietDDH.Columns["SoLuongThieu"].HeaderText = "Số lượng thiếu";
            dgvChiTietDDH.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvChiTietDDH.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["ThanhTien"].HeaderText = "Thành tiền";
            dgvChiTietDDH.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvChiTietDDH.Columns["TrangThai"].Visible = false;
            dgvChiTietDDH.Columns["GhiChu"].Visible = false;
            dgvChiTietDDH.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvChiTietDDH.Columns["DonDatHang"].Visible = false;
            dgvChiTietDDH.Columns["SanPham"].Visible = false;
        }

        private void dgvChiTietDDH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvChiTietDDH.Rows)
            {
                row.Cells["SoThuTu"].Value = row.Index + 1;
            }
        }

        private void ThemCotSoThuTu(DataGridView dgv)
        {
            // Kiểm tra xem cột số thứ tự đã tồn tại chưa
            if (!dgv.Columns.Contains("SoThuTu"))
            {
                // Tạo cột số thứ tự
                DataGridViewTextBoxColumn soThuTuColumn = new DataGridViewTextBoxColumn();
                soThuTuColumn.Name = "SoThuTu";
                soThuTuColumn.HeaderText = "STT";
                soThuTuColumn.Width = 50;
                soThuTuColumn.ReadOnly = true;

                // Thêm cột vào vị trí đầu tiên
                dgv.Columns.Insert(0, soThuTuColumn);
            }
        }

        private void dgvDanhSachDonDatHang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvDanhSachDonDatHang.Rows)
            {
                row.Cells["SoThuTu"].Value = row.Index + 1;
            }
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string luaChon = cbbLuaChonHienThi.SelectedValue.ToString();
            ThemCotSoThuTu(dgvDanhSachDonDatHang);
            switch (luaChon)
            {
                case "TatCa":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(x => x.TongTien.HasValue && x.TongTien.Value != 0).ToList();

                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhanVien":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => (ddh.MaNhanVien == cbbNhanVien.SelectedValue.ToString())&& (ddh.TongTien.HasValue && ddh.TongTien.Value!=0)).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NgayDatHang":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => (ddh.NgayDat >= dtpTuNgay.Value && ddh.NgayDat <= dtpDenNgay.Value) && (ddh.TongTien.HasValue && ddh.TongTien.Value != 0)).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "TrangThai":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => (ddh.TrangThai == cbbTrangThai.SelectedValue.ToString()) && (ddh.TongTien.HasValue && ddh.TongTien.Value != 0)).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhaCungCap":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => (ddh.MaNhaCungCap == cbbNhaCungCap.SelectedValue.ToString()) && (ddh.TongTien.HasValue && ddh.TongTien.Value != 0)).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                default:
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
            }
        }

        private void suaTieuDeCotDSDDH()
        {
            dgvDanhSachDonDatHang.Columns["MaDonDatHang"].HeaderText = "Mã đơn đặt";
            dgvDanhSachDonDatHang.Columns["NgayDat"].HeaderText = "Ngày đặt";
            dgvDanhSachDonDatHang.Columns["NgayDat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDanhSachDonDatHang.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvDanhSachDonDatHang.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvDanhSachDonDatHang.Columns["TrangThai"].HeaderText = "Trạng thái";
            dgvDanhSachDonDatHang.Columns["NgayTao"].Visible = false;
            dgvDanhSachDonDatHang.Columns["NgayCapNhat"].HeaderText = "Ngày cập nhật";
            dgvDanhSachDonDatHang.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDanhSachDonDatHang.Columns["MaNhaCungCap"].Visible = false;
            dgvDanhSachDonDatHang.Columns["MaNhanVien"].Visible = false;
            dgvDanhSachDonDatHang.Columns["NhaCungCap"].Visible = false;
            dgvDanhSachDonDatHang.Columns["NhanVien"].Visible = false;
            if(_listDonDatHang.Count <= 0)
            {
                dgvChiTietDDH.DataSource = null;
            }
        }

        private void ChinhSuaTieuDeCot(DataGridView dgv, Dictionary<string, string> columnHeaders)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (columnHeaders.ContainsKey(column.Name))
                {
                    column.HeaderText = columnHeaders[column.Name];
                }
            }
        }


        private void CbbLuaChonHienThi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string luaChon = cbbLuaChonHienThi.SelectedValue.ToString();
            switch (luaChon)
            {
                case "NhanVien":
                    cbbNhanVien.Enabled = true;
                    cbbNhaCungCap.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    break;
                case "NgayDatHang":
                    cbbNhanVien.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    dtpTuNgay.Enabled = true;
                    dtpDenNgay.Enabled = true;
                    cbbTrangThai.Enabled = false;
                    break;
                case "TrangThai":
                    cbbNhanVien.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbTrangThai.Enabled = true;
                    break;
                case "TatCa":
                    cbbNhanVien.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    break;
                case "NhaCungCap":
                    cbbNhanVien.Enabled = false;
                    cbbNhaCungCap.Enabled = true;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    cbbTrangThai.Enabled = false;
                    break;
                default:
                    cbbNhanVien.Enabled = false;
                    cbbNhaCungCap.Enabled = false;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    break;
            }
        }

        private void Frm_quanLyDonDatHang_Load(object sender, EventArgs e)
        {
            cbbNhanVien.Enabled = false;
            cbbNhaCungCap.Enabled = false;
            dtpTuNgay.Enabled = false;
            dtpDenNgay.Enabled = false;
            cbbTrangThai.Enabled = false;
            txtSoLuongYeuCau.KeyDown += TextBox_KeyDown;
            txtSoLuongCungCap.KeyDown += TextBox_KeyDown;
            txtDonGia.KeyDown += TextBox_KeyDown;
            loadNhaCungCapVaoComboBox(cbbNhaCungCap);
            loadLuaChonHienThiVaoComboBox(cbbLuaChonHienThi);
            loadNhanVienVaoComboBox(cbbNhanVien);
            loadTrangThaiVaoComboBox1(cbbTrangThai);
            loadTrangThaiVaoComboBox1(cbbTrangThaiCTDDH);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCapNhat.PerformClick();
            }
        }

        private void loadTrangThaiVaoComboBox1(ComboBox combo)
        {
            List<LuaChonHienThi> lst = new List<LuaChonHienThi>();
            lst.Add(new LuaChonHienThi() { TenHienThi = "Chưa xác nhận", MaHienThi = "Chưa xác nhận" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Đã xác nhận", MaHienThi = "Đã xác nhận" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Đang giao hàng", MaHienThi = "Đang giao hàng" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Đã nhận hàng", MaHienThi = "Đã nhận hàng" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Hoàn thành", MaHienThi = "Hoàn thành" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Đã hủy", MaHienThi = "Đã hủy" });
            lst.Add(new LuaChonHienThi() { TenHienThi = "Hoàn trả", MaHienThi = "Hoàn trả" });
            combo.DataSource = lst;
            combo.DisplayMember = "TenHienThi";
            combo.ValueMember = "MaHienThi";

        }

        private void loadTrangThaiVaoComboBox(ComboBox combo)
        {
            _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang();
            HashSet<string> s = new HashSet<string>();
            foreach (DonDatHang item in _listDonDatHang)
            {
                s.Add(item.TrangThai);
            }
            List<LuaChonHienThi> lst = new List<LuaChonHienThi>();
            foreach (string item in s)
            {
                lst.Add(new LuaChonHienThi() { TenHienThi = item, MaHienThi = item });
            }
            combo.DataSource = lst;
            combo.DisplayMember = "TenHienThi";
            combo.ValueMember = "MaHienThi";
        }

        private void loadNhanVienVaoComboBox(ComboBox combo)
        {
            _listNhanVien = _nhanVienBLL.getAllNhanVien();
            combo.DataSource = _listNhanVien;
            combo.DisplayMember = "HoTen";
            combo.ValueMember = "MaNhanVien";
        }

        private void loadLuaChonHienThiVaoComboBox(ComboBox combo)
        {
            List<LuaChonHienThi> lstLuaChon = new List<LuaChonHienThi>();
            lstLuaChon.Add(new LuaChonHienThi() { TenHienThi = "Tất cả", MaHienThi = "TatCa" });
            lstLuaChon.Add(new LuaChonHienThi() { TenHienThi = "Nhân viên", MaHienThi = "NhanVien" });
            lstLuaChon.Add(new LuaChonHienThi() { TenHienThi = "Ngày đặt hàng", MaHienThi = "NgayDatHang" });
            lstLuaChon.Add(new LuaChonHienThi() { TenHienThi = "Trạng thái", MaHienThi = "TrangThai" });
            lstLuaChon.Add(new LuaChonHienThi() { TenHienThi = "Nhà cung cấp", MaHienThi = "NhaCungCap" });
            combo.DataSource = lstLuaChon;
            combo.DisplayMember = "TenHienThi";
            combo.ValueMember = "MaHienThi";
        }

        private void loadNhaCungCapVaoComboBox(ComboBox comboBox)
        {
            _listNhaCungCap = _nhaCungCapBLL.LayDanhSachNhaCungCap();
            comboBox.DataSource = _listNhaCungCap;
            comboBox.DisplayMember = "TenNhaCungCap";
            comboBox.ValueMember = "MaNhaCungCap";
        }
    }
}
