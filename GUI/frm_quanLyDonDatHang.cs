using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyDonDatHang : Form
    {
        string _maNhanVien = "NV002";
        int _soLuong;
        decimal _donGia, _thanhTien, _tongTien;

        List<NhaCungCap> _listNhaCungCap = new List<NhaCungCap>();
        NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();

        List<NhanVien> _listNhanVien = new List<NhanVien>();
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();

        List<DonDatHang> _listDonDatHang = new List<DonDatHang>();
        DonDatHangBLL _donDatHangBLL = new DonDatHangBLL();

        List<ChiTietDonDatHang> _listCTDDH = new List<ChiTietDonDatHang>();
        ChiTietDonDatHangBLL _chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();

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
        }

        private void TxtSoLuongCungCap_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                _soLuong = int.Parse(txtSoLuongCungCap.Text);
                _donGia = decimal.Parse(txtDonGia.Text.Replace(",", ""));
                _thanhTien = _soLuong * _donGia;
                txtThanhTien.Text = _thanhTien.ToString("N0");
                txtDonGia.Text = _donGia.ToString("N0");
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
                if (decimal.TryParse(input, out decimal result))
                {
                    txtDonGia.Text = result.ToString("N0");
                    txtDonGia.SelectionStart = txtDonGia.Text.Length;
                }
                _soLuong = int.Parse(txtSoLuongCungCap.Text);
                _donGia = decimal.Parse(txtDonGia.Text.Replace(",", ""));
                decimal thanhTienNew = _soLuong * _donGia;
                txtThanhTien.Text = thanhTienNew.ToString("N0");
                decimal tongTienNew = _tongTien - _thanhTien + thanhTienNew;
                txtTongTien.Text = tongTienNew.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void TxtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            ChiTietDonDatHang ctddh = new ChiTietDonDatHang();
            string maSP = dgvChiTietDDH.CurrentRow.Cells["MaSanPham"].Value.ToString();
            string maDDH = dgvChiTietDDH.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
            sp = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHang().Where(ct => ct.MaSanPham == maSP).FirstOrDefault().SanPham;
            ctddh = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHang().Where(ct => ct.MaSanPham == maSP && ct.MaDonDatHang == maDDH).FirstOrDefault();

        }

        private void dgvChiTietDDH_SelectionChanged(object sender, EventArgs e)
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
            txtTongTien.Text = Convert.ToDecimal(dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value).ToString("N0");
            _soLuong = Convert.ToInt32(dgvChiTietDDH.CurrentRow.Cells["SoLuongCungCap"].Value);
            _donGia = Convert.ToDecimal(dgvChiTietDDH.CurrentRow.Cells["DonGia"].Value);
            _thanhTien = Convert.ToDecimal(dgvChiTietDDH.CurrentRow.Cells["ThanhTien"].Value);
            _tongTien = Convert.ToDecimal(dgvDanhSachDonDatHang.CurrentRow.Cells["TongTien"].Value);
        }

        private void dgvDanhSachDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            string maDonDatHang = dgvDanhSachDonDatHang.CurrentRow.Cells["MaDonDatHang"].Value.ToString();
            _listCTDDH = _chiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(maDonDatHang);
            ThemCotSoThuTu(dgvChiTietDDH);
            dgvChiTietDDH.DataSource = _listCTDDH;
            suaTieuDeCotDSCTDDH();
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
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhanVien":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => ddh.MaNhanVien == cbbNhanVien.SelectedValue.ToString()).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NgayDatHang":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => ddh.NgayDat >= dtpTuNgay.Value && ddh.NgayDat <= dtpDenNgay.Value).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "TrangThai":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => ddh.TrangThai == cbbTrangThai.SelectedValue.ToString()).ToList();
                    dgvDanhSachDonDatHang.DataSource = _listDonDatHang;
                    suaTieuDeCotDSDDH();
                    break;
                case "NhaCungCap":
                    _listDonDatHang = _donDatHangBLL.LayDanhSachDonDatHang().Where(ddh => ddh.MaNhaCungCap == cbbNhaCungCap.SelectedValue.ToString()).ToList();
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
            loadNhaCungCapVaoComboBox(cbbNhaCungCap);
            loadLuaChonHienThiVaoComboBox(cbbLuaChonHienThi);
            loadNhanVienVaoComboBox(cbbNhanVien);
            loadTrangThaiVaoComboBox(cbbTrangThai);
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
