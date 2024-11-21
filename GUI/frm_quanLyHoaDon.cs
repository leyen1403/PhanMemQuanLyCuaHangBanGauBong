using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Collections.Generic;
using System.Drawing;

namespace GUI
{
    public partial class frm_quanLyHoaDon : Form
    {
        private string maNhanVien = "NV001";
        HoaDonBanHangBLL _hoaDonBanHangBLL = new HoaDonBanHangBLL();
        ChiTietHoaDonBanHangBLL _chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL();
        KhachHangBLL _khachHangBLL = new KhachHangBLL();
        NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        List<HoaDonBanHang> _lstHoaDon = null;
        List<ChiTietHoaDonBanHang> _lstChiTietHoaDon = null;
        public frm_quanLyHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_quanLyHoaDon_Load;
        }

        private void Frm_quanLyHoaDon_Load(object sender, EventArgs e)
        {
            loadComBoBoxChucNang();
            loadHoaDon();
            loadCTHD();
            IniDataGirdViewHoaDon();
            IniDataGirdViewCTHD();
            dgv_dsHoaDon.SelectionChanged += Dgv_dsHoaDon_SelectionChanged;
            dgv_dsCTHD.SelectionChanged += Dgv_dsCTHD_SelectionChanged;
            this.btn_inHoaDon.Click += Btn_inHoaDon_Click;
        }

        private void Dgv_dsCTHD_SelectionChanged(object sender, EventArgs e)
        {
            //chọn dòng xuất lên Textbox
            if (dgv_dsCTHD.CurrentRow!=null)
            {
                DataGridViewRow row = dgv_dsCTHD.CurrentRow;
                txt_maCTHD.Text = row.Cells["MaChiTietHoaDonBanHang"].Value != DBNull.Value ? row.Cells["MaChiTietHoaDonBanHang"].Value.ToString() : string.Empty;
                txt_maHD.Text = row.Cells["MaHoaDon"].Value != DBNull.Value ? row.Cells["MaHoaDon"].Value.ToString() : string.Empty;
                txt_maSanPham.Text = row.Cells["MaSanPham"].Value != DBNull.Value ? row.Cells["MaSanPham"].Value.ToString() : string.Empty;
                txt_soLuong.Text = row.Cells["SoLuong"].Value != DBNull.Value ? row.Cells["SoLuong"].Value.ToString() : string.Empty;
                txt_DonGia.Text = row.Cells["DonGia"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["DonGia"].Value).ToString("N0") : string.Empty;
                txt_thanhTien.Text = row.Cells["ThanhTien"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["ThanhTien"].Value).ToString("N0") : string.Empty;
                //txt_ghiChu.Text = row.Cells["GhiChu"].Value != DBNull.Value ? row.Cells["GhiChu"].Value.ToString() : string.Empty;
            }
            else
            {
                txt_maHD.Clear();
                txt_maSanPham.Clear();
                txt_soLuong.Clear();
                txt_DonGia.Clear();
                txt_thanhTien.Clear();
                txt_ghiChu.Clear();
            }

        }

        private void Btn_inHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDon();
        }
        private void XuatHoaDon()
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xuất file Word?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Word Documents (*.docx)|*.docx",
                    FileName = "Hoa-Don-(" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ").docx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Mở tài liệu Word mẫu sẵn
                        var wordApp = new Microsoft.Office.Interop.Word.Application();
                        string url = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                        var document = wordApp.Documents.Open(url + @"\Resources\hoa-don-ban-hang-file-word.docx");
                        string maHoaDon = txt_maHDBH.Text;
                        HoaDonBanHang hd = _hoaDonBanHangBLL.GetHoaDonByMaHoaDon(maHoaDon).FirstOrDefault();
                        if (hd == null)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        KhachHang kh = _khachHangBLL.GetKhachHang(hd.MaKhachHang, string.Empty, string.Empty);
                        NhanVien nv = _nhanVienBLL.GetNhanVienById(hd.MaNhanVien);
                        if (kh == null || nv == null)
                        {
                            MessageBox.Show("Không tìm thấy thông tin khách hàng hoặc nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        string tenNhanVien = nv.HoTen;
                        string tenKhachHang = kh.TenKhachHang;
                        string DiaChi = kh.DiaChi;
                        string soDienThoai = kh.SoDienThoai;

                        // Thay thế các thông tin trong tài liệu Word
                        document.Bookmarks["NgayLap"].Range.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        document.Bookmarks["TenNhanVien"].Range.Text = tenNhanVien;
                        document.Bookmarks["MaHoaDonBanHang"].Range.Text = maHoaDon;
                        document.Bookmarks["TenKhachHang"].Range.Text = tenKhachHang;
                        document.Bookmarks["DiaChi"].Range.Text = DiaChi;
                        document.Bookmarks["SDT"].Range.Text = soDienThoai;

                        // Lấy bảng đầu tiên trong tài liệu (giả sử bảng đã được định dạng sẵn)
                        var table = document.Tables[1];

                        var lstCTHD = from cthd in new ChiTietHoaDonBanHangBLL().GetChiTietHoaDonByMaHoaDon(maHoaDon)
                                      select new
                                      {
                                          cthd.SanPham.TenSanPham,
                                          cthd.SoLuong,
                                          cthd.DonGia,
                                          cthd.ThanhTien
                                      };

                        DataGridView dgvTemp = new DataGridView();
                        dgvTemp.Name = "dgvTemp";
                        dgvTemp.DataSource = lstCTHD.ToList();
                        this.Controls.Add(dgvTemp);
                        for (int i = 0; i < dgvTemp.Rows.Count; i++)
                        {
                            var newRow = table.Rows.Add();
                            newRow.Cells[1].Range.Text = (i + 1).ToString();
                            newRow.Cells[2].Range.Text = dgvTemp.Rows[i].Cells["TenSanPham"].Value.ToString();
                            newRow.Cells[3].Range.Text = dgvTemp.Rows[i].Cells["SoLuong"].Value.ToString();
                            newRow.Cells[4].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["DonGia"].Value).ToString("N0") + " VNĐ";
                            newRow.Cells[5].Range.Text = Convert.ToDecimal(dgvTemp.Rows[i].Cells["ThanhTien"].Value).ToString("N0") + " VNĐ";
                        }
                        var tongTien = (decimal)lstCTHD.Sum(x => x.ThanhTien);
                        document.Bookmarks["TongTien"].Range.Text = tongTien.ToString("N0") + " VNĐ";
                        // Lưu tài liệu sau khi thêm dữ liệu
                        document.SaveAs2(saveFileDialog.FileName);
                        document.Close();
                        wordApp.Quit();
                        MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Controls.Remove(dgvTemp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xuất báo cáo thất bại: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void Dgv_dsHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_dsHoaDon.CurrentRow!=null)
            {
                DataGridViewRow row = dgv_dsHoaDon.CurrentRow;

                // Kiểm tra và gán giá trị cho các TextBox, tránh NullReferenceException
                txt_maHDBH.Text = row.Cells["MaHoaDonBanHang"].Value != DBNull.Value ? row.Cells["MaHoaDonBanHang"].Value.ToString() : string.Empty;
                txt_maKhachHang.Text = row.Cells["MaKhachHang"].Value != DBNull.Value ? row.Cells["MaKhachHang"].Value.ToString() : string.Empty;
                txt_maNhanVien.Text = row.Cells["MaNhanVien"].Value != DBNull.Value ? row.Cells["MaNhanVien"].Value.ToString() : string.Empty;
                txt_tongTien.Text = row.Cells["TongTien"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["TongTien"].Value).ToString("N0") : string.Empty;
                txt_tongSL.Text = row.Cells["TongSanPham"].Value != DBNull.Value ? row.Cells["TongSanPham"].Value.ToString() : string.Empty;
                txt_diemTichLuy.Text = row.Cells["DiemCongTichLuy"].Value != DBNull.Value ? row.Cells["DiemCongTichLuy"].Value.ToString() : string.Empty;
                string maHoaDon = row.Cells["MaHoaDonBanHang"].Value.ToString();
                _lstChiTietHoaDon = _chiTietHoaDonBanHangBLL.GetChiTietHoaDonByMaHoaDon(maHoaDon);
                dgv_dsCTHD.DataSource = _lstChiTietHoaDon;

            }
            else
            {
                // Xử lý khi không có hàng nào được chọn, có thể xóa các TextBox hoặc để trống
                txt_maHD.Clear();
                txt_maKhachHang.Clear();
                txt_maNhanVien.Clear();
                txt_tongTien.Clear();
                txt_ghiChu.Clear();
                txt_diemTichLuy.Clear();
            }
        }

        private void loadHoaDon()
        {
            List<HoaDonBanHang> dsHDBH = _hoaDonBanHangBLL.GetAllHoaDonBanHang();
            if(dsHDBH.Count > 0)
            {
                dgv_dsHoaDon.DataSource = dsHDBH;
            }    

        }
        private void loadCTHD()
        {
            List<ChiTietHoaDonBanHang> dsCTHDBH = _chiTietHoaDonBanHangBLL.GetAllChiTietHoaDonBanHang();
            if(dsCTHDBH.Count > 0)
            {
                dgv_dsCTHD.DataSource = dsCTHDBH;
            }    
        }

        private void dgv_dsHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void loadComBoBoxChucNang()
        {
            cbbLuaChonHienThi.Items.Clear();
            // Thêm các chức năng tìm kiếm vào ComboBox
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Nhân Viên");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Khoảng Thời Gian");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Khách Hàng");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Mã Hóa Đơn");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Tên Khách Hàng");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm theo Tên Nhân Viên");
            cbbLuaChonHienThi.Items.Add("Tìm kiếm tất cả");
            // Đặt mặc định cho ComboBox
            cbbLuaChonHienThi.SelectedIndex = 0;
        }
        // khởi tạo dữ liệu tiêu đề cho datagridview
        private void IniDataGirdViewCTHD()
        {

            if (dgv_dsCTHD != null)
            {
                // Sửa tên cột đã có
                dgv_dsCTHD.Columns["MaChiTietHoaDonBanHang"].HeaderText = "Mã Chi Tiết";
                dgv_dsCTHD.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgv_dsCTHD.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                dgv_dsCTHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgv_dsCTHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgv_dsCTHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                dgv_dsCTHD.Columns["GhiChu"].HeaderText = "Ghi Chú";

                //căn chỉnh độ rộng cột tự động
                dgv_dsCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_dsCTHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Đặt lại định dạng cột "DonGia" và "ThanhTien" cho số tiền
                dgv_dsCTHD.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ
                dgv_dsCTHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ

                // Đặt cột "SoLuong" chỉ nhận giá trị số nguyên
                dgv_dsCTHD.Columns["SoLuong"].ValueType = typeof(int);

                //ẩn cột không cần thiết
                dgv_dsCTHD.Columns["HoaDonBanHang"].Visible = false;
                dgv_dsCTHD.Columns["SanPham"].Visible = false;
            }

        }
        private void IniDataGirdViewHoaDon()
        {
            if (dgv_dsHoaDon != null)
            {
                // sét tiêu đề
                dgv_dsHoaDon.Columns["MaHoaDonBanHang"].HeaderText = "Mã Hóa Đơn";
                dgv_dsHoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dgv_dsHoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgv_dsHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgv_dsHoaDon.Columns["TongSanPham"].HeaderText = "SL";
                dgv_dsHoaDon.Columns["DiemCongTichLuy"].HeaderText = "Điểm Cộng Tích Lũy";
                dgv_dsHoaDon.Columns["DiemTichLuy"].HeaderText = "Ghi Chú";
                dgv_dsHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";

                //căn chỉnh độ rộng cột
                // Thiết lập chế độ tự động dàn đều cột và đồng thời điều chỉnh chiều cao của hàng
                dgv_dsHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_dsHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                //in đậm tiêu đề
                dgv_dsHoaDon.Columns[0].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                dgv_dsHoaDon.Columns["TongTien"].DefaultCellStyle.Format = "N0";  // Định dạng tiền tệ

                //ẩn cột không cần thiết
                dgv_dsHoaDon.Columns["KhachHang"].Visible = false;
                dgv_dsHoaDon.Columns["NhanVien"].Visible = false;
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            // Xử lý khi người dùng chọn chức năng tìm kiếm
            switch (cbbLuaChonHienThi.SelectedIndex)
            {
                case 0: // Tìm kiếm theo Mã Nhân Viên
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            loadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByMaNhanVien(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 1: // Tìm kiếm theo Khoảng Thời Gian
                    try
                    {
                        DateTime tuNgay = dtpTuNgay.Value;
                        DateTime denNgay = dtpDenNgay.Value;
                        if (tuNgay > denNgay)
                        {
                            MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc");
                            return;
                        }
                        _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByDateRange(tuNgay, denNgay);
                        dgv_dsHoaDon.DataSource = _lstHoaDon;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 2: // Tìm kiếm theo Mã Khách Hàng
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                           loadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByMaKhachHang(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 3: // Tìm kiếm theo Mã Hóa Đơn
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            loadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByMaHoaDon(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 4: // Tìm kiếm theo Tên Khách Hàng
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            loadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByTenKhachHang(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case 5: // Tìm kiếm theo Tên Nhân Viên
                    try
                    {
                        txt_timKiem.Visible = true;
                        string key = txt_timKiem.Text;
                        if (key == "")
                        {
                            loadHoaDon();
                        }
                        else
                        {
                            _lstHoaDon = _hoaDonBanHangBLL.GetHoaDonByTenNhanVien(key);
                            dgv_dsHoaDon.DataSource = _lstHoaDon;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 6:
                    try
                    {
                        loadHoaDon();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    txt_timKiem.Text = "Nhập giá trị tìm kiếm:";
                    break;
            }
        }
    }
}
