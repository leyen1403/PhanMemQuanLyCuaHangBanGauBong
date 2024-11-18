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
        public frm_quanLyHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_quanLyHoaDon_Load;
        }

        private void Frm_quanLyHoaDon_Load(object sender, EventArgs e)
        {
            loadHoaDon();
            loadCTHD();
            dgv_dsHoaDon.SelectionChanged += Dgv_dsHoaDon_SelectionChanged;
        }

        private void Dgv_dsHoaDon_SelectionChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
            if (dgv_dsHoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv_dsHoaDon.SelectedRows[0];

                // Kiểm tra và gán giá trị cho các TextBox, tránh NullReferenceException
                txt_maHDBH.Text = row.Cells["MaHoaDon"].Value != DBNull.Value ? row.Cells["MaHoaDon"].Value.ToString() : string.Empty;
                txt_maKhachHang.Text = row.Cells["MaKhachHang"].Value != DBNull.Value ? row.Cells["MaKhachHang"].Value.ToString() : string.Empty;
                txt_maNhanVien.Text = row.Cells["MaNhanVien"].Value != DBNull.Value ? row.Cells["MaNhanVien"].Value.ToString() : string.Empty;
                txt_tongTien.Text = row.Cells["TongTien"].Value != DBNull.Value ? Convert.ToDecimal(row.Cells["TongTien"].Value).ToString("N0") : string.Empty;
                txt_ghiChu.Text = row.Cells["GhiChu"].Value != DBNull.Value ? row.Cells["GhiChu"].Value.ToString() : string.Empty;
                txt_diemTichLuy.Text = row.Cells["DiemTichLuySuDung"].Value != DBNull.Value ? row.Cells["DiemTichLuySuDung"].Value.ToString() : string.Empty;
                string maHoaDon = row.Cells["MaHoaDon"].Value.ToString();
                //_lstChiTietHoaDon = _chiTietHoaDonBLL.LayChiTietHoaDonTheoMaHoaDon(maHoaDon);
                //dgv_dsCTHD.DataSource = _lstChiTietHoaDon;

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
            //set tiêu đề
            if (dgv_dsCTHD != null)
            {
                // Sửa tên cột đã có
                dgv_dsCTHD.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgv_dsCTHD.Columns["MaSanPham"].HeaderText = "Mã Sản Phẩm";
                dgv_dsCTHD.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgv_dsCTHD.Columns["DonGia"].HeaderText = "Đơn Giá";
                dgv_dsCTHD.Columns["ThanhTien"].HeaderText = "Thành Tiền";

                //căn chỉnh độ rộng cột tự động
                dgv_dsCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_dsCTHD.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                // Đặt lại định dạng cột "DonGia" và "ThanhTien" cho số tiền
                dgv_dsCTHD.Columns["DonGia"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ
                dgv_dsCTHD.Columns["ThanhTien"].DefaultCellStyle.Format = "N0"; // Định dạng tiền tệ

                // Đặt cột "SoLuong" chỉ nhận giá trị số nguyên
                dgv_dsCTHD.Columns["SoLuong"].ValueType = typeof(int);

                //ẩn cột không cần thiết
                dgv_dsCTHD.Columns["HoaDon"].Visible = false;
                dgv_dsCTHD.Columns["SanPham"].Visible = false;
            }

        }
        private void IniDataGirdViewHoaDon()
        {
            if (dgv_dsHoaDon != null)
            {
                // sét tiêu đề
                dgv_dsHoaDon.Columns["MaHoaDon"].HeaderText = "Mã Hóa Đơn";
                dgv_dsHoaDon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                dgv_dsHoaDon.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dgv_dsHoaDon.Columns["NgayTao"].HeaderText = "Ngày Tạo";
                dgv_dsHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dgv_dsHoaDon.Columns["GhiChu"].HeaderText = "Ghi Chú";
                dgv_dsHoaDon.Columns["DiemTichLuySuDung"].HeaderText = "Sử dụng điểm";
                dgv_dsHoaDon.Columns["PhuongThucThanhToan"].HeaderText = "Phương Thức Thanh Toán";

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
                            //LoadHoaDon();
                        }
                        else
                        {
                            //_lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaNhanVien(key);
                            //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                        //_lstHoaDon = _hoaDonBLL.TimHoaDonTheoKhoangThoiGian(tuNgay, denNgay);
                        //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                            //LoadHoaDon();
                        }
                        else
                        {
                            //_lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaKhachHang(key);
                            //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                            //LoadHoaDon();
                        }
                        else
                        {
                            //_lstHoaDon = _hoaDonBLL.TimHoaDonTheoMaHoaDon(key);
                            //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                            //LoadHoaDon();
                        }
                        else
                        {
                            //_lstHoaDon = _hoaDonBLL.TimHoaDonTheoTenKhachHangHoacSDT(key);
                            //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                            //LoadHoaDon();
                        }
                        else
                        {
                            //_lstHoaDon = _hoaDonBLL.TimKiemHoaDonTheoTenNhanVien(key);
                            //dgv_dsHoaDon.DataSource = _lstHoaDon;
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
                        //LoadHoaDon();
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
