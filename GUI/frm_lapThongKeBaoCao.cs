using BLL;
using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace GUI
{
    public partial class frm_lapThongKeBaoCao : Form
    {
        //DataGridView dgvThongKe = new DataGridView();
        HoaDonBanHangBLL hoaDonBanHangBLL = new HoaDonBanHangBLL();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        
        public frm_lapThongKeBaoCao()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_lapThongKeBaoCao_Load;
            this.btnXemDoanhThu.Click += BtnXemDoanhThu_Click;
            this.btnChuyen.Click += BtnChuyen_Click;
        
            tabCrlDoanhThu.Selected += TabCrlDoanhThu_Selected;
            this.btnXuatDoanhThu.Click += BtnXuatDoanhThu_Click;
            dtgvThongKe.BackgroundColor = Color.White;
        }

        private void BtnXuatDoanhThu_Click(object sender, EventArgs e)
        {

            string maNV = cbbNhanVien.SelectedValue.ToString();
            DateTime starDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;
            Console.WriteLine($"Ngày bắt đầu: {starDate}");
            Console.WriteLine($"Ngày kết thúc: {endDate}");

            List<PhieuBaoCao> dsPBC = hoaDonBanHangBLL.LayPhieuBaoCaoTheoKhoangThoiGian(starDate, endDate);

            if (dsPBC.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ngày bắt đầu và ngày kết thúc");
                return;
            }
            //Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            string ngay = "Ngày" + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
            replacer.Add("%NgayBatDau", starDate.ToString());
            replacer.Add("%NgayKetThuc", endDate.ToString());
            replacer.Add("%NgayThangNam", ngay);
            //NHACUNGCAP ncc = qlhh.NHACUNGCAPs.Where(t => t.MANCC == pn.MANCC).FirstOrDefault();
         
            var tenNV = nhanVienBLL.GetTenNhanVienByMaNhanVien(maNV);
            var soDienThoai = nhanVienBLL.GetSDTByMaNhanVien(maNV);
            var diaChi = nhanVienBLL.GetDiaChiByMaNhanVien(maNV);
            replacer.Add("%MaNV", maNV);
            replacer.Add("%TenNhanVien", tenNV);
            replacer.Add("%DiaChi", diaChi);
            replacer.Add("%SDT", soDienThoai);
            double tongTien = 0;
            decimal tongTienDecimal = (decimal)tongTien; 

            foreach (PhieuBaoCao item in dsPBC)
            {
                tongTienDecimal += item.THANHTIEN;  // Cộng với decimal
            }

            replacer.Add("%TongTien", String.Format("{0:0,0} VNĐ", tongTienDecimal));

            MemoryStream stream = null;
            byte[] arrByte = new byte[0];
            arrByte = File.ReadAllBytes("PhieuBaoCao.xlsx").ToArray();
            //Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }
            //Create Excel Engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
            //Replace value
            if (replacer != null && replacer.Count > 0)
            {
                foreach (KeyValuePair<string, string> repl in replacer)
                {
                    Replace(workSheet, repl.Key, repl.Value);
                }
            }
         
            string viewName = "PhieuBaoCao";
            markProcessor.AddVariable(viewName, dsPBC);
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
            ////Xóa bỏ dòng đánh dấu [TMP]
            IRange range = workSheet.FindFirst("[TMP]", ExcelFindType.Text);
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }
            
            //Luu
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


            workBook.Close();
            engine.Dispose();

            MessageBox.Show("Xuất xong");

            // Mở file nếu người dùng đồng ý
            if (!string.IsNullOrEmpty(fileName) && MessageBox.Show("Bạn có muốn mở file không?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(fileName);
            }
        }


        private void Replace(IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
        }
        private void TabCrlDoanhThu_Selected(object sender, TabControlEventArgs e)
        {
            if(e.TabPage == tabSoLuongTon)
            {
                try
                {

                    DataTable dt = sanPhamBLL.GetSanPhamTonKho();
                    dataGridView2.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if(e.TabPage == tabSPBanChay)
            {
                try
                {

                    DataTable dt = sanPhamBLL.GetSanPhamBanChayDataTable();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnChuyen_Click(object sender, EventArgs e)
        {
            chart1.Visible = true;
            LoadDataAndChart();
        }

        private void BtnXemDoanhThu_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            DateTime starDate = dtpNgayBD.Value;
            DateTime endDate = dtpNgayKT.Value;
            dtgvThongKe.DataSource = null;
            try
            {
                
                DataTable dt = hoaDonBanHangBLL.GetTongTienTheoNgayDataTable(starDate,endDate);
                dtgvThongKe.DataSource = dt;
              
                dtgvThongKe.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void LoadDataAndChart()
        {
            DataTable dataTable = (DataTable)dtgvThongKe.DataSource;

            DrawChart(dataTable);
        }
        private void DrawChart(DataTable dataTable)
        {
           
                chart1.Series.Clear();

                Series series = new Series
                {
                    Name = "Tổng tiền",
                    Color = System.Drawing.Color.ForestGreen,
                    ChartType = SeriesChartType.Column 
                };

                foreach (DataRow row in dataTable.Rows)
                {
                    series.Points.AddXY(row["Ngày"], row["Tổng Tiền"]);
                }

                chart1.Series.Add(series);

                chart1.ChartAreas[0].AxisX.Title = "Ngày";
                chart1.ChartAreas[0].AxisY.Title = "Tổng tiền";

                chart1.Titles.Clear();
                chart1.Titles.Add("Biểu Đồ Dữ Liệu Thu Nhập");
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



        private void Frm_lapThongKeBaoCao_Load(object sender, EventArgs e)
        {
            loadCbbNhanVien();
            dtgvThongKe.ReadOnly = true;
            DataTable dt = hoaDonBanHangBLL.GetTongTienTheoNgayDataTable();
            dtgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dtgvThongKe.DefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);
            dtgvThongKe.MultiSelect = false;
            dtgvThongKe.AllowUserToAddRows = false;
            dtgvThongKe.DataSource = dt;
            dtgvThongKe.Refresh();
            dtgvThongKe.BackgroundColor = Color.White;
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
        private void tabDanhThu_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
