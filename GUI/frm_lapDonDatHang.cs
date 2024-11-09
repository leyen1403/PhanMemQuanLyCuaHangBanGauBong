using BLL;
using DevExpress.Utils.DPI;
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
    public partial class frm_lapDonDatHang : Form
    {
        private string _maNhaCungCap;
        private string _maDonDatHang;
        private string _maNhanVien = "NV001";
        private decimal? _tongTien;
        private decimal? _tongTienDonDatHang;

        List<NhaCungCap> _nhaCungCapList = new List<NhaCungCap>();
        NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();

        List<SanPham> _sanPhamList = new List<SanPham>();
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();

        List<LoaiSanPham> _loaiSanPhamList = new List<LoaiSanPham>();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();

        List<DonDatHang> _donDatHangList = new List<DonDatHang>();
        DonDatHangBLL _donDatHangBLL = new DonDatHangBLL();

        List<ChiTietDonDatHang> _chiTietDonDatHangList = new List<ChiTietDonDatHang>();
        ChiTietDonDatHangBLL _chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();

        public string MaNhaCungCap { get => _maNhaCungCap; set => _maNhaCungCap = value; }
        public string MaDonDatHang { get => _maDonDatHang; set => _maDonDatHang = value; }
        public string MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public decimal? TongTien { get => _tongTien; set => _tongTien = value; }
        public List<NhaCungCap> NhaCungCapList { get => _nhaCungCapList; set => _nhaCungCapList = value; }
        public NhaCungCapBLL NhaCungCapBLL { get => _nhaCungCapBLL; set => _nhaCungCapBLL = value; }
        public List<SanPham> SanPhamList { get => _sanPhamList; set => _sanPhamList = value; }
        public SanPhamBLL SanPhamBLL { get => _sanPhamBLL; set => _sanPhamBLL = value; }
        public List<LoaiSanPham> LoaiSanPhamList { get => _loaiSanPhamList; set => _loaiSanPhamList = value; }
        public LoaiSanPhamBLL LoaiSanPhamBLL { get => _loaiSanPhamBLL; set => _loaiSanPhamBLL = value; }
        public List<DonDatHang> DonDatHangList { get => _donDatHangList; set => _donDatHangList = value; }
        public DonDatHangBLL DonDatHangBLL { get => _donDatHangBLL; set => _donDatHangBLL = value; }
        public List<ChiTietDonDatHang> ChiTietDonDatHangList { get => _chiTietDonDatHangList; set => _chiTietDonDatHangList = value; }
        public ChiTietDonDatHangBLL ChiTietDonDatHangBLL { get => _chiTietDonDatHangBLL; set => _chiTietDonDatHangBLL = value; }
        public decimal? TongTienDonDatHang { get => _tongTienDonDatHang; set => _tongTienDonDatHang = value; }

        public frm_lapDonDatHang()
        {
            InitializeComponent();
            loadNCC();
            loadLoaiSanPham();
            loadDanhSachSanPham();
            MaDonDatHang = taoMaDonDatHang();
            this.cbbNhaCungCap.SelectedIndexChanged += CbbNhaCungCap_SelectedIndexChanged;
            this.dgvDanhSachSanPham.SelectionChanged += DgvDanhSachSanPham_SelectionChanged;
            this.btnThem.Click += BtnThem_Click;
            this.dgvDanhSachChiTietDonDatHang.SelectionChanged += DgvDanhSachChiTietDonDatHang_SelectionChanged;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnDatHang.Click += BtnDatHang_Click;
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            DonDatHang ddhNew = new DonDatHang();
            ddhNew = DonDatHangBLL.LayDonDayHang(MaDonDatHang);
            ddhNew.NgayDat = DateTime.Now;
            ChiTietDonDatHangList = ChiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(MaDonDatHang);
            TongTienDonDatHang = tinhTongGiaTriDonDatHang(ChiTietDonDatHangList);            
            ddhNew.TongTien = TongTienDonDatHang;
            ddhNew.TrangThai = "Đã xác nhận";
            ddhNew.NgayTao = DateTime.Now;
            ddhNew.NgayCapNhat = DateTime.Now;
            ddhNew.MaNhanVien = MaNhanVien;
            ddhNew.MaNhaCungCap = MaNhaCungCap;
            // Cap nhat don dat hang
            if (DonDatHangBLL.CapNhatDonDatHang(ddhNew))
            {
                MessageBox.Show("Đã xác nhận đơn đặt hàng");
                this.Close();
            }
            else
            {
                MessageBox.Show("Xác nhận đơn đặt hàng thất bại");
            }

        }

        private decimal? tinhTongGiaTriDonDatHang(List<ChiTietDonDatHang> chiTietDonDatHangList)
        {
            TongTienDonDatHang = 0;
            foreach (ChiTietDonDatHang ct in chiTietDonDatHangList)
            {
                TongTienDonDatHang += ct.ThanhTien;
            }
            return TongTienDonDatHang;
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            string maSanPham = txtMaSanPham.Text;
            string maDonDatHang = MaDonDatHang;
            ChiTietDonDatHang chiTietDonDatHang = ChiTietDonDatHangList.Where(ct => ct.MaSanPham == maSanPham && ct.MaDonDatHang == MaDonDatHang).FirstOrDefault();
            if (ChiTietDonDatHangBLL.XoaChiTietDonDatHang(chiTietDonDatHang))
            {
                MessageBox.Show("Xóa sản phẩm khỏi đơn đặt hàng thành công");
                ChiTietDonDatHangList = ChiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(maDonDatHang);
                dgvDanhSachChiTietDonDatHang.DataSource = ChiTietDonDatHangList;
            }
        }

        private void DgvDanhSachChiTietDonDatHang_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDanhSachChiTietDonDatHang.CurrentRow != null &&
                    dgvDanhSachChiTietDonDatHang.CurrentRow.Cells["MaSanPham"] != null &&
                    dgvDanhSachChiTietDonDatHang.CurrentRow.Cells["MaSanPham"].Value != null)
                {
                    string maSanPham = dgvDanhSachChiTietDonDatHang.CurrentRow.Cells["MaSanPham"].Value.ToString();
                    hienThiThongTinSanPham(maSanPham);
                    int soLuongNhap = int.Parse(dgvDanhSachChiTietDonDatHang.CurrentRow.Cells["SoLuongYeuCau"].Value.ToString());
                    txtSoLuongNhapThem.Text = soLuongNhap.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        private string taoMaDonDatHang()
        {
            string maDonDatHang = "";
            int soLuongDonDatHang = DonDatHangBLL.LayDanhSachDonDatHang().Count;
            if (soLuongDonDatHang == 0)
            {
                maDonDatHang = "DDH001";
            }
            else
            {
                maDonDatHang = "DDH" + (soLuongDonDatHang + 1).ToString("000");
            }
            return maDonDatHang;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (MaNhaCungCap == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp");
                return;
            }
            if (ChiTietDonDatHangList.Count() == 0)
            {
                DonDatHang donDatHang = new DonDatHang();
                donDatHang.MaDonDatHang = MaDonDatHang;
                donDatHang.NgayDat = DateTime.Now;
                donDatHang.TongTien = TongTien;
                donDatHang.TrangThai = "Chưa xác nhận";
                donDatHang.NgayTao = DateTime.Now;
                donDatHang.NgayCapNhat = DateTime.Now;
                donDatHang.MaNhaCungCap = MaNhaCungCap;
                donDatHang.MaNhanVien = MaNhanVien;
                if (DonDatHangBLL.ThemDonDatHang(donDatHang) == true)
                {
                    themSanPhamVaoDonDatHang();
                }
                else
                {
                    themSanPhamVaoDonDatHang();
                }

            }
            else
            {
                themSanPhamVaoDonDatHang();
            }
            lblTongGiaTriDonHang.Text = "Tổng giá trị đơn hàng: " + tinhTongGiaTriDonDatHang(ChiTietDonDatHangList)?.ToString("#,##0") + " VNĐ";
        }

        private void themSanPhamVaoDonDatHang()
        {
            SanPham sp = new SanPham();
            string maSanPham = txtMaSanPham.Text;
            sp = SanPhamBLL.GetProductById(maSanPham);
            int soLuongYeuCau = int.Parse(txtSoLuongNhapThem.Text);
            ChiTietDonDatHang chiTietDonDatHang = new ChiTietDonDatHang();
            chiTietDonDatHang.MaChiTietDonDatHang = taoMaChiTietDonDatHang();
            chiTietDonDatHang.MaDonDatHang = MaDonDatHang;
            chiTietDonDatHang.DonViTinh = sp.DonViTinh;
            chiTietDonDatHang.SoLuongYeuCau = soLuongYeuCau;
            chiTietDonDatHang.SoLuongCungCap = 0;
            chiTietDonDatHang.SoLuongThieu = sp.SoLuongToiThieu;
            chiTietDonDatHang.DonGia = sp.GiaNhap;
            chiTietDonDatHang.ThanhTien = soLuongYeuCau * sp.GiaNhap;
            chiTietDonDatHang.TrangThai = "Chưa xác nhận";
            chiTietDonDatHang.GhiChu = "";
            chiTietDonDatHang.MaSanPham = maSanPham;
            if (ChiTietDonDatHangBLL.ThemChiTietDonDatHang(chiTietDonDatHang) == true)
            {
                MessageBox.Show("Đã thêm sản phẩm vào đơn đặt hàng");
                ChiTietDonDatHangList = ChiTietDonDatHangBLL.LayDanhSachChiTietDonDatHangTheoMaDonDatHang(MaDonDatHang);
                dgvDanhSachChiTietDonDatHang.DataSource = ChiTietDonDatHangList;
                foreach(DataGridViewRow row in dgvDanhSachChiTietDonDatHang.Rows)
                {
                    row.Cells["STT"].Value = row.Index + 1;
                }
                dgvDanhSachChiTietDonDatHang.Columns["MaChiTietDonDatHang"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["MaDonDatHang"].HeaderText = "Đơn đặt";
                dgvDanhSachChiTietDonDatHang.Columns["DonViTinh"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["SoLuongYeuCau"].HeaderText = "Số lượng yêu cầu";
                dgvDanhSachChiTietDonDatHang.Columns["SoLuongCungCap"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["SoLuongThieu"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["DonGia"].HeaderText = "Đơn giá";
                dinhDangTienTe(dgvDanhSachChiTietDonDatHang, "DonGia");
                dgvDanhSachChiTietDonDatHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dinhDangTienTe(dgvDanhSachChiTietDonDatHang, "ThanhTien");
                dgvDanhSachChiTietDonDatHang.Columns["TrangThai"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["GhiChu"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                dgvDanhSachChiTietDonDatHang.Columns["DonDatHang"].Visible = false;
                dgvDanhSachChiTietDonDatHang.Columns["SanPham"].Visible = false;

                dgvDanhSachChiTietDonDatHang.Columns["STT"].DisplayIndex = 0;
                dgvDanhSachChiTietDonDatHang.Columns["MaDonDatHang"].DisplayIndex = 1;
                dgvDanhSachChiTietDonDatHang.Columns["MaSanPham"].DisplayIndex = 2;
                dgvDanhSachChiTietDonDatHang.Columns["SoLuongYeuCau"].DisplayIndex = 3;
                dgvDanhSachChiTietDonDatHang.Columns["DonGia"].DisplayIndex = 4;
                dgvDanhSachChiTietDonDatHang.Columns["ThanhTien"].DisplayIndex = 5;
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm vào đơn đặt hàng thất bại");
            }
        }

        private void dinhDangTienTe(DataGridView dgv ,string tenCot)
        {
            dgv.Columns[tenCot].DefaultCellStyle.Format = "#,##0";
        }

        private string taoMaChiTietDonDatHang()
        {
            string maCTDDH = "";
            int soLuongCTDDH = ChiTietDonDatHangBLL.LayDanhSachChiTietDonDatHang().Count();
            if (soLuongCTDDH == 0)
            {
                maCTDDH = "CTDDH001";
            }
            else
            {
                maCTDDH = "CTDDH" + (soLuongCTDDH + 1).ToString("000");
            }
            return maCTDDH;
        }


        private void loadLoaiSanPham()
        {
            List<LoaiSanPham> temp = new List<LoaiSanPham>();
            temp.Add(new LoaiSanPham { MaLoai = "TatCa", TenLoai = "Tất cả" });
            temp.AddRange(LoaiSanPhamBLL.GetAll());
            cbbLoaiSanPham.DataSource = temp;
            LoaiSanPhamList = LoaiSanPhamBLL.GetAll();
            cbbLoaiSanPham.DisplayMember = "TenLoai";
            cbbLoaiSanPham.ValueMember = "MaLoai";
        }

        private void DgvDanhSachSanPham_SelectionChanged(object sender, EventArgs e)
        {
            string maSanPham = dgvDanhSachSanPham.CurrentRow.Cells["MaSanPham"].Value.ToString();
            hienThiThongTinSanPham(maSanPham);
            int soLuongNhap = 0;
            ChiTietDonDatHang chiTietDonDatHang = ChiTietDonDatHangList.Where(ct => ct.MaSanPham == maSanPham).FirstOrDefault();
            if (chiTietDonDatHang != null)
            {
                soLuongNhap = (int)chiTietDonDatHang.SoLuongYeuCau;
            }
            txtSoLuongNhapThem.Text = soLuongNhap.ToString();
        }

        private void hienThiThongTinSanPham(string maSanPham)
        {
            SanPham sanPham = SanPhamBLL.GetProductById(maSanPham);
            txtMaSanPham.Text = sanPham.MaSanPham;
            txtTenSanPham.Text = sanPham.TenSanPham;
            string loaiSanPham = sanPham.LoaiSanPham.TenLoai;
            txtLoai.Text = loaiSanPham;
        }

        private void loadDanhSachSanPham()
        {
            SanPhamList = SanPhamBLL.GetProductList();
            dgvDanhSachSanPham.DataSource = SanPhamList;
            dgvDanhSachSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            dgvDanhSachSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";
            dgvDanhSachSanPham.Columns["DonViTinh"].Visible = false;
            dgvDanhSachSanPham.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dgvDanhSachSanPham.Columns["SoLuongToiThieu"].HeaderText = "SL tối thiểu";
            dgvDanhSachSanPham.Columns["GiaNhap"].Visible = false;
            dgvDanhSachSanPham.Columns["GiaBan"].Visible = false;
            dgvDanhSachSanPham.Columns["MoTa"].Visible = false;
            dgvDanhSachSanPham.Columns["TrangThai"].Visible = false;
            dgvDanhSachSanPham.Columns["NgayTao"].Visible = false;
            dgvDanhSachSanPham.Columns["NgayCapNhat"].Visible = false;
            dgvDanhSachSanPham.Columns["MaLoai"].Visible = false;
            dgvDanhSachSanPham.Columns["LoaiSanPham"].Visible = false;
            dgvDanhSachSanPham.Columns["HinhAnh"].Visible = false;
        }

        private void loadNCC()
        {
            NhaCungCapList = NhaCungCapBLL.LayDanhSachNhaCungCap();
            foreach (var item in NhaCungCapList)
            {
                if (item is NhaCungCap)
                {
                    if (item.TrangThai == false)
                    {
                        NhaCungCapList.Remove(item);
                    }
                }
            }
            cbbNhaCungCap.DataSource = NhaCungCapList;
            cbbNhaCungCap.DisplayMember = "TenNhaCungCap";
            cbbNhaCungCap.ValueMember = "MaNhaCungCap";
            cbbNhaCungCap.SelectedIndex = 0;
        }

        private void CbbNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDanhSachChiTietDonDatHang.Rows.Count <= 0)
            {
                string maNhaCungCap = cbbNhaCungCap.SelectedValue.ToString();
                MaNhaCungCap = maNhaCungCap;
                NhaCungCap ncc = NhaCungCapBLL.LayNhaCungCapTheoMa(maNhaCungCap);
                txtMaNhaCungCap.Text = ncc.MaNhaCungCap;
                txtTenNhaCungCap.Text = ncc.TenNhaCungCap;
                txtNguoiDaiDien.Text = ncc.NguoiDaiDien;
                txtEmail.Text = ncc.Email;
                txtSDT.Text = ncc.SoDienThoai;
            }
            else
            {
                MessageBox.Show("Đã có sản phẩm trong đơn đặt hàng, không thể thay đổi nhà cung cấp");
                cbbNhaCungCap.SelectedValue = MaNhaCungCap;
            }
        }

    }
}
