using BLL;
using DevExpress.XtraPrinting.Native;
using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        private db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        private List<ChiTietPhieuNhap> dsCTPN;
        //private BindingList<ChiTietPhieuNhap> bindingList;
        public frm_quanLyNhapHang()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_quanLyNhapHang_Load;
            this.btnTim.Click += BtnTim_Click;
            dgvPhieuNhap.SelectionChanged += DgvPhieuNhap_SelectionChanged;
            this.btnThemPN.Click += BtnThemPN_Click;
            this.btnTaoMoi.Click += BtnTaoMoi_Click;
            this.btnHuyPhieu.Click += BtnHuyPhieu_Click;
            this.btnLuuPhieu.Click += BtnLuuPhieu_Click;
            //this.deleteMenuItem.Click += DeleteMenuItem_Click;
            this.btnLuu.Click += BtnLuu_Click;
            dgvChiTietPhieuNhap.CellValidating += DgvChiTietPhieuNhap_CellValidating;
            dgvChiTietPhieuNhap.CellValueChanged += DgvChiTietPhieuNhap_CellValueChanged;
            dgvChiTietPhieuNhap.RowContextMenuStripNeeded += DgvChiTietPhieuNhap_RowContextMenuStripNeeded1;
            btnInPhieu.Click += BtnInPhieu_Click;
            
        }




        private void BtnInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (db == null)
                {
                    MessageBox.Show("Đối tượng kết nối cơ sở dữ liệu chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mã phiếu nhập
                if (string.IsNullOrWhiteSpace(txtMaPN.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tìm phiếu nhập theo mã
                PhieuNhap pn = db.PhieuNhaps.FirstOrDefault(t => t.MaPhieuNhap == txtMaPN.Text);
                if (pn == null)
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập với mã đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra thông tin liên quan đến phiếu nhập
                var ddh = db.DonDatHangs.FirstOrDefault(d => d.MaDonDatHang == pn.MaDonDatHang);
                if (ddh == null)
                {
                    MessageBox.Show("Không tìm thấy đơn đặt hàng liên quan đến phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ncc = db.NhaCungCaps.FirstOrDefault(n => n.MaNhaCungCap == ddh.MaNhaCungCap);
                if (ncc == null)
                {
                    MessageBox.Show("Không tìm thấy nhà cung cấp cho đơn đặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Khởi tạo đối tượng xuất Excel
                ExcelExport excel = new ExcelExport();
                string path = string.Empty;
                excel.ExportPhieuNhap(pn, ref path, false);


                // Tạo dictionary để thay thế dữ liệu trong file Excel
                Dictionary<string, string> replacer = new Dictionary<string, string>();

                string ngay = "Ngày " + pn.NgayLap.Value.Day + " tháng " + pn.NgayLap.Value.Month + " năm " + pn.NgayLap.Value.Year;
                replacer.Add("%NgayThangNam", ngay);
                replacer.Add("%MaPN", pn.MaPhieuNhap);
                replacer.Add("%TongTien", String.Format("{0:0,0.00}", pn.TongTien));

                // Thêm thông tin nhà cung cấp vào replacer
                replacer.Add("%NCC", ncc.TenNhaCungCap);
                replacer.Add("%DiaChi", ncc.DiaChi);
                replacer.Add("%DienThoai", ncc.SoDienThoai);

                // Thêm số tiền bằng chữ

                //string tongTienChung = ConvertNumberToWords(pn.TongTien ?? 0);
                //replacer.Add("%BangChu", tongTienChung);

                // Thêm thông tin nhân viên
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNhanVien == pn.MaNhanVien);
                replacer.Add("%TenNV", nv?.HoTen ?? "Không xác định");

                // Đọc file mẫu Excel
                MemoryStream stream = null;
                byte[] arrByte = File.ReadAllBytes("Phieunhaphang.xlsx");
                if (arrByte.Length > 0)
                {
                    stream = new MemoryStream(arrByte);
                }

                // Tạo đối tượng Excel Engine
                ExcelEngine engine = new ExcelEngine();
                IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
                IWorksheet workSheet = workBook.Worksheets[0];
                ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();

                // Thay thế các biến trong file Excel
                if (replacer.Count > 0)
                {
                    foreach (var repl in replacer)
                    {
                        Replace(workSheet, repl.Key, repl.Value);
                    }
                }

                // Lấp đầy chi tiết phiếu nhập
                List<ChiTietPhieuNhap> ctpns = pn.ChiTietPhieuNhaps.Where(t => t.MaPhieuNhap == pn.MaPhieuNhap).ToList();
                if (ctpns == null || ctpns.Count == 0)
                {
                    MessageBox.Show("Không có chi tiết phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Danh sách chi tiết phiếu nhập với STT
                List<ChiTietPN> ctpnSTT = new List<ChiTietPN>();
                int stt = 1;

                foreach (ChiTietPhieuNhap ct in ctpns)
                {
                    try
                    {
                        ChiTietPN ctstt = new ChiTietPN(ct, stt++, db);
                        ctpnSTT.Add(ctstt);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xử lý chi tiết phiếu nhập: {ex.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Thêm dữ liệu chi tiết vào Excel
                string viewName = "Phieunhaphang";
                markProcessor.AddVariable(viewName, ctpnSTT);
                markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);

                // Xóa dòng đánh dấu [TMP] trong Excel
                IRange range = workSheet.FindFirst("[TMP]", ExcelFindType.Text);
                if (range != null)
                {
                    workSheet.DeleteRow(range.Row);
                }

                //// Tìm cột %BangChu trong Excel và thay thế giá trị
                //IRange bangChuRange = workSheet.FindFirst("%BangChu", ExcelFindType.Text);
                //if (bangChuRange == null)
                //{
                //    MessageBox.Show("Không tìm thấy ô chứa %BangChu trong file Excel.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return; // Dừng quá trình nếu không tìm thấy ô
                //}
                //else
                //{
                //    // Thay thế %BangChu nếu tìm thấy
                //    bangChuRange.Text = tongTienChung;
                //}

                // Lưu file Excel

                //Lưu file
                //string fileName = "";
                //string file = Path.Combine(Path.GetTempPath(), "PhieuNhapHang_" + Guid.NewGuid() + "xlsx");
                //fileName = file;
                //Output file

                string fileName = Path.Combine(Path.GetTempPath(), "PhieuNhapHang_" + Guid.NewGuid().ToString() + ".xlsx");
                try
                {
                    workBook.SaveAs(fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu tệp: " + ex.Message);
                    return;
                }

                // Đóng workbook và giải phóng tài nguyên
                workBook.Close();
                engine.Dispose();

                MessageBox.Show("Xuất xong");

                // Mở file nếu người dùng đồng ý
                if (!string.IsNullOrEmpty(fileName) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string ConvertNumberToWords(decimal number)
        {
            string[] ones = { "", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" };
            string[] tens = { "", "Mười", "Hai mươi", "Ba mươi", "Bốn mươi", "Năm mươi", "Sáu mươi", "Bảy mươi", "Tám mươi", "Chín mươi" };
            string[] hundreds = { "", "Một trăm", "Hai trăm", "Ba trăm", "Bốn trăm", "Năm trăm", "Sáu trăm", "Bảy trăm", "Tám trăm", "Chín trăm" };

            if (number == 0) return "Không đồng";

            string result = "";
            int intNumber = (int)number;
            int hundred = intNumber / 100;
            int ten = (intNumber % 100) / 10;
            int one = intNumber % 10;

            // Kiểm tra xem giá trị có hợp lệ trong phạm vi mảng không
            if (hundred >= 0 && hundred < hundreds.Length)
            {
                result += hundreds[hundred] + " ";
            }

            if (ten >= 0 && ten < tens.Length)
            {
                if (ten > 1)
                {
                    result += tens[ten] + " ";
                    if (one >= 0 && one < ones.Length)
                    {
                        result += ones[one];
                    }
                }
                else if (ten == 1)
                {
                    result += tens[ten] + " ";
                    if (one >= 0 && one < ones.Length)
                    {
                        result += ones[one];
                    }
                }
            }
            else if (one >= 0 && one < ones.Length)
            {
                result += ones[one];
            }

            // Xử lý "một" đặc biệt với hàng mười
            if (ten == 0 && one == 1)
            {
                result = "Một";
            }

            // Thêm "đồng" vào cuối
            result += " đồng";

            return result.Trim();
        }



        private void Replace(IWorksheet workSheet, string p1, string p2)
        {

            workSheet.Replace(p1, p2);
        }

        private void DgvChiTietPhieuNhap_RowContextMenuStripNeeded1(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                e.ContextMenuStrip = dgvChiTietPhieuNhap.ContextMenuStrip;
            }
        }

        private void SetupContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Xóa");
            deleteMenuItem.Click += DeleteMenuItem_Click;

            contextMenu.Items.Add(deleteMenuItem);

            dgvChiTietPhieuNhap.ContextMenuStrip = contextMenu;
        }

        private void DgvChiTietPhieuNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var changedColumn = dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name;

                if (changedColumn == "SoLuong")
                {
                    // Cập nhật lại giá trị Thành Tiền khi Số Lượng thay đổi
                    var row = dgvChiTietPhieuNhap.Rows[e.RowIndex];
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    row.Cells["ThanhTien"].Value = soLuong * donGia;
                }
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var changedColumn = dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name;

                if (changedColumn == "DonGia")
                {
                    // Cập nhật lại giá trị Thành Tiền khi Số Lượng thay đổi
                    var row = dgvChiTietPhieuNhap.Rows[e.RowIndex];
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    row.Cells["ThanhTien"].Value = soLuong * donGia;
                }
            }
            btnLuu.Enabled = false; 
        }

        private void DgvChiTietPhieuNhap_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name;

            if (columnName == "SoLuong")
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int value) || value <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.");
                    e.Cancel = true; 
                }
            }
            else if (columnName == "DonGia")
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal donGia) || donGia <= 0)
                {
                    MessageBox.Show("Đơn giá phải là số thập phân dương.");
                    e.Cancel = true; 
                }
            }

        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {


            string maPN = txtMaPN.Text;

            try
            {
                List<ChiTietPhieuNhap> updatedList = new List<ChiTietPhieuNhap>();

                var originalList = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(maPN);

                foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                {
                    if (row.IsNewRow) 
                        continue;

                    string maCTPN = row.Cells["MaChiTietPhieuNhap"].Value?.ToString();
                    string maCTDDH = row.Cells["MaCTDDH"].Value?.ToString();
                    string donViTinh = row.Cells["DonViTinh"].Value?.ToString();
                    string ghiChu = row.Cells["GhiChu"].Value?.ToString();
                    string trangThai = row.Cells["TrangThai"].Value?.ToString();
                    string maSanPham = row.Cells["MaSanPham"].Value?.ToString();

                    if (!int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show($"Số lượng không hợp lệ ở mã chi tiết {maCTPN}. Vui lòng kiểm tra lại.");
                        return;
                    }

                    if (!decimal.TryParse(row.Cells["DonGia"].Value?.ToString(), out decimal donGia) || donGia <= 0)
                    {
                        MessageBox.Show($"Đơn giá không hợp lệ ở mã chi tiết {maCTPN}. Vui lòng kiểm tra lại.");
                        return;
                    }

                    decimal thanhTien = soLuong * donGia;

                    ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap
                    {
                        MaChiTietPhieuNhap = maCTPN,
                        MaPhieuNhap = maPN,
                        DonViTinh = donViTinh,
                        SoLuong = soLuong,
                        DonGia = donGia,
                        ThanhTien = thanhTien,
                        TrangThai = trangThai,
                        GhiChu = ghiChu,
                        MaChiTietDonDatHang = maCTDDH
                    };

                    updatedList.Add(ctpn);

                    if (!string.IsNullOrEmpty(maSanPham))
                    {
                        bool isSuccessUpdateStock = sanPhamBLL.UpdateProductStock(maSanPham, soLuong);
                        if (!isSuccessUpdateStock)
                        {
                            MessageBox.Show($"Có lỗi khi cập nhật số lượng tồn cho sản phẩm {maSanPham}.");
                            return;
                        }
                    }
                }

                var deletedItems = originalList
                    .Where(orig => updatedList.All(updated => updated.MaChiTietPhieuNhap != orig.MaChiTietPhieuNhap))
                    .ToList();

                bool isSuccess = chiTietPhieuNhapBLL.UpdateAndDeleteChiTietPhieuNhap(updatedList, deletedItems, maPN);
                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật thành công!");
                    UpdateTongTien(maPN); 
                    loadChiTietPhieuNhap(maPN); 
                    btnLuu.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu dữ liệu.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }

        }

        private void UpdateTongTien(string maPN)
        {
            try
            {

                var chiTietPhieuNhaps = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(maPN);

                decimal tongTien = chiTietPhieuNhaps.Sum(ct => ct.ThanhTien ?? 0);

                bool isUpdated = phieuNhapBLL.UpdateTongTien(maPN, tongTien);
                string maDDH = cbbMaDDH.SelectedValue.ToString();

                if (isUpdated)
                {
                    anhXaPhieuNhap();
                }
                else
                {
                    MessageBox.Show("Cập nhật tổng tiền thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tổng tiền: " + ex.Message);
            }
        }



        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dsCTPN == null)
                {
                    dsCTPN = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(txtMaPN.Text);  // Khởi tạo lại dsCTPN nếu chưa có dữ liệu
                }

                if (dsCTPN == null || dsCTPN.Count == 0)
                {
                    MessageBox.Show("Danh sách chi tiết phiếu nhập trống hoặc chưa được khởi tạo.");
                    return;
                }
                if (dgvChiTietPhieuNhap.CurrentRow != null && !dgvChiTietPhieuNhap.CurrentRow.IsNewRow)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này?",
                                                          "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string maChiTietPhieuNhap = dgvChiTietPhieuNhap.CurrentRow.Cells["MaChiTietPhieuNhap"].Value?.ToString();

                        if (string.IsNullOrEmpty(maChiTietPhieuNhap))
                        {
                            MessageBox.Show("Không tìm thấy mã chi tiết phiếu nhập.");
                            return;
                        }

                        bool isSuccess = chiTietPhieuNhapBLL.DeleteChiTietPhieuNhap(maChiTietPhieuNhap);
                        if (isSuccess)
                        {
                            //var itemToRemove = dsCTPN.FirstOrDefault(ct => ct.MaChiTietPhieuNhap == maChiTietPhieuNhap);
                            //if (itemToRemove != null)
                            //{
                            //    dsCTPN.Remove(itemToRemove); 
                            //}

                            //dgvChiTietPhieuNhap.Rows.Remove(dgvChiTietPhieuNhap.CurrentRow);
                            loadChiTietPhieuNhap(txtMaPN.Text);
                            btnLuu.Enabled = false;
                            MessageBox.Show("Đã xóa dòng thành công.");
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa chi tiết phiếu nhập từ cơ sở dữ liệu.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một dòng hợp lệ để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa dòng: {ex.Message}");
            }

        }

        private void BtnLuuPhieu_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text;

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

            try
            {
                var bll = new ChiTietPhieuNhapBLL();  
                bll.UpdateChiTietPhieuNhapList(updatedList, maPN); 
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

                    //var dsCPhieuNhapViewModel = from ct in dsCPhieuNhap
                    //                            select new
                    //                            {
                    //                                MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
                    //                                // Ánh xạ mã sản phẩm từ MaChiTietDonDatHang
                    //                                MaSanPham = chiTietPhieuNhapBLL.GetProductIdByMaCTDDH(ct.MaChiTietDonDatHang),
                    //                                DonViTinh = ct.DonViTinh,
                    //                                SoLuong = ct.SoLuong,
                    //                                DonGia = ct.DonGia,
                    //                                ThanhTien = ct.ThanhTien,
                    //                                MaCTDDH = ct.MaChiTietDonDatHang,
                    //                                TrangThai = ct.TrangThai,
                    //                                GhiChu = ct.GhiChu
                    //                            };
                    var dsCPhieuNhapViewModel = dsCPhieuNhap.Select(ct => new ChiTietPhieuNhapViewModel
                    {
                        MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
                        MaSanPham = chiTietPhieuNhapBLL.GetProductIdByMaCTDDH(ct.MaChiTietDonDatHang),
                        DonViTinh = ct.DonViTinh,
                        SoLuong = ct.SoLuong ?? 0,
                        DonGia = ct.DonGia ?? 0,
                        ThanhTien = (ct.SoLuong ?? 0) * (ct.DonGia ?? 0),
                        MaCTDDH = ct.MaChiTietDonDatHang,
                        TrangThai = ct.TrangThai,
                        GhiChu = ct.GhiChu
                    });

                    dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel.ToList();

                    // Đặt tên cho các cột
                    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
                    dgvChiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã sản phẩm"; // Hiển thị cột MaSanPham
                    dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                    dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                    dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
                    dgvChiTietPhieuNhap.Columns["MaCTDDH"].HeaderText = "Mã chi tiết DDH";
                    dgvChiTietPhieuNhap.Columns["TrangThai"].HeaderText = "Trạng thái";
                    dgvChiTietPhieuNhap.Columns["GhiChu"].HeaderText = "Ghi chú";

                    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["MaSanPham"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["DonViTinh"].ReadOnly = false;
                    dgvChiTietPhieuNhap.Columns["DonGia"].ReadOnly = false;
                    dgvChiTietPhieuNhap.Columns["TrangThai"].ReadOnly = false;
                    dgvChiTietPhieuNhap.Columns["GhiChu"].ReadOnly = false;
                    dgvChiTietPhieuNhap.Columns["ThanhTien"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["MaCTDDH"].ReadOnly = true;



                    foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvChiTietPhieuNhap.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {
                    MessageBox.Show("Không có chi tiết phiếu nhập nào.");
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
                    dgvPhieuNhap.Columns["MaDonDatHang"].Visible = false;
                    dgvPhieuNhap.Columns["MaNhanVien"].Visible = false;



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
            SetupContextMenu();
            txtMaPN.Enabled = false;
            btnLuu.Enabled = false;

           // bindingList = new BindingList<ChiTietPhieuNhap>(listCTPhieuNhap);

            //dgvChiTietPhieuNhap.DataSource = bindingList;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void btnThemPN_Click_1(object sender, EventArgs e)
        {

        }
    }
}
