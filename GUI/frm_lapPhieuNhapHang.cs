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
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        DonDatHangBLL donDatHangBLL = new DonDatHangBLL();
        ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
        SanPhamBLL sanPhamBLL = new SanPhamBLL();
        public frm_lapPhieuNhapHang()
        {
            InitializeComponent();
            AddButtonPaintEvent();
            AddButtonPaintEventRecursive(this);
            this.Load += Frm_lapPhieuNhapHang_Load;
            this.dgvPhieuNhap.SelectionChanged += DgvPhieuNhap_SelectionChanged;
            this.dgvChiTietPhieuNhap.SelectionChanged += DgvChiTietPhieuNhap_SelectionChanged; ;
            this.btnNhapLaiPN.Click += BtnNhapLaiPN_Click; ;
            this.btnThemPN.Click += BtnTaoPhieu_Click;
            this.btnDong.Click += BtnDong_Click;
            cbbMaDDH.SelectedValueChanged += CbbMaDDH_SelectedValueChanged;
        }

        private void CbbMaDDH_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaDDH.SelectedValue != null)
                {
                    string maDDH = cbbMaDDH.SelectedValue.ToString();
                    loadDSSanPham(maDDH); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xử lý sự kiện SelectedValueChanged: " + ex.Message);
            }
        }

        private void loadDSSanPham(string maDDH)
        {
            dgvDSSanPham.DataSource = null;
            try
            {
                List<SanPham> dsSanPham = sanPhamBLL.GetSanPhamByMaDDH(maDDH);
                if (dsSanPham != null)
                {
                    var dsSanPhamViewModel = from ct in dsSanPham
                                                select new
                                                {
                                                    MaSanPham = ct.MaSanPham,
                                                    TenSanPham = ct.TenSanPham,
                                                    DonViTinh = ct.DonViTinh,
                                                    SoLuongTon = ct.SoLuongTon,
                                                    GiaNhap = ct.GiaNhap
                                                };
                    dgvDSSanPham.DataSource = dsSanPhamViewModel.ToList();
                    dgvDSSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                   // dgvDSSanPham.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                    dgvDSSanPham.Columns["DonViTinh"].Visible =false;

                    dgvDSSanPham.Columns["SoLuongTon"].HeaderText = "Số lượng";
                    dgvDSSanPham.Columns["GiaNhap"].HeaderText = "Đơn giá";
                    dgvDSSanPham.Columns["TenSanPham"].HeaderText = "Tên sản phẩm";

                    foreach (DataGridViewColumn column in dgvDSSanPham.Columns)
                    {
                        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                    }
                    dgvDSSanPham.RowPostPaint += dgv_RowPostPaint;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
    

        private void DgvChiTietPhieuNhap_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnNhapLaiPN_Click(object sender, EventArgs e)
        {
            txtMaPN.Clear();
            loadCbbNhanVien();
            loadCbbDonDatHang();
            txtLanNhap.Clear();
            txtTrangThai.Clear();
            dTPNgayLap.Value = DateTime.Now;
            txtTongTien.Clear();
            
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void BtnThemCTPN_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string maCTPN = txtMaCTPN.Text;
          
        //        string maCTDDH = cbbMaCTDDH.SelectedValue != null ? cbbMaCTDDH.SelectedValue.ToString() : string.Empty;
        //        if (string.IsNullOrEmpty(maCTPN))
        //        {
        //            MessageBox.Show("Vui lòng chọn một mã chi tiết đơn đặt hàng hợp lệ.");
        //            return;
        //        }

        //        string maPN = txtMaPN.Text;
        //        string donViTinh = txtDonViTinh.Text;

        //        if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
        //        {
        //            MessageBox.Show("Số lượng không hợp lệ!");
        //            return;
        //        }

        //        if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia <= 0)
        //        {
        //            MessageBox.Show("Đơn giá không hợp lệ!");
        //            return;
        //        }

        //        decimal thanhTien = soLuong * donGia;

        //        string ghiChu = txtGhiChu.Text;

        //        ChiTietPhieuNhap newCTPN = new ChiTietPhieuNhap
        //        {
        //            MaChiTietPhieuNhap = maCTPN,
        //            MaPhieuNhap = maPN,
        //            DonViTinh = donViTinh,
        //            SoLuong = soLuong,
        //            DonGia = donGia,
        //            ThanhTien = thanhTien,
        //            TrangThai = "Chưa giao",
        //            MaChiTietDonDatHang = maCTDDH,
        //            GhiChu = ghiChu
        //        };

        //        // Attempt to add the new detail
        //        bool isSuccessCTPN = chiTietPhieuNhapBLL.AddChiTietPhieuNhap(newCTPN);

        //        if (isSuccessCTPN)
        //        {
        //            MessageBox.Show("Chi tiết phiếu nhập đã được thêm thành công!");
        //            UpdateTongTien(maPN);
        //            loadChiTietPhieuNhap(maPN);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Có lỗi khi thêm chi tiết phiếu nhập. Vui lòng thử lại.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi: " + ex.Message);
        //    }
        //}

        private void UpdateTongTien(string maPN)
        {
            try
            {
             
                var chiTietPhieuNhaps = chiTietPhieuNhapBLL.GetChiTietPhieuNhapByMaPN(maPN);

                decimal tongTien = chiTietPhieuNhaps.Sum(ct => ct.ThanhTien ?? 0);

                bool isUpdated = phieuNhapBLL.UpdateTongTien(maPN, tongTien);

                if (isUpdated)
                {
                    loadDSPhieuNhap();
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

      

        //private void TxtSoLuong_ValueChanged(object sender, EventArgs e)
        //{
        //    CalculateThanhTien();
        //}

        //private void TxtDonGia_TextChanged(object sender, EventArgs e)
        //{
        //    CalculateThanhTien();
        //}

        //private void CalculateThanhTien()
        //{
           
        //    if (decimal.TryParse(txtDonGia.Text, out decimal donGia) && int.TryParse(txtSoLuong.Text, out int soLuong))
        //    {
        //        decimal thanhTien = donGia * soLuong;

        //        txtThanhTien.Text = thanhTien.ToString();  
        //    }
        //    else
        //    {
        //        txtThanhTien.Text = "0";
        //    }
        //}

        private void BtnTaoPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                string maPN = txtMaPN.Text;
                string nhanVien = cbbNhanVien.SelectedValue?.ToString();
                string donDatHang = cbbMaDDH.SelectedValue?.ToString();
               // string chiTietDonDatHang = cbbMaCTDDH.SelectedValue?.ToString();
                int lanNhap = int.Parse(txtLanNhap.Text);
                string trangThai = txtTrangThai.Text;

             
                PhieuNhap newPhieuNhap = new PhieuNhap
                {
                    MaPhieuNhap = maPN,
                    NgayLap = DateTime.Now,
                    TrangThai = trangThai,
                    LanNhap = lanNhap,
                    MaDonDatHang = donDatHang,
                    MaNhanVien = nhanVien
                };

              
                bool isSuccessPN = phieuNhapBLL.AddPhieuNhap(newPhieuNhap);

                if (isSuccessPN)
                {
                    MessageBox.Show("Phiếu nhập đã được thêm thành công!");
                 
                    maPN = newPhieuNhap.MaPhieuNhap; 
                    txtMaPN.Text = maPN;
                    loadDSPhieuNhap();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm phiếu nhập. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnNhapLai_Click(object sender, EventArgs e)
        {
           
           
           
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


        private void Frm_lapPhieuNhapHang_Load(object sender, EventArgs e)
        {
            loadDSPhieuNhap();
            loadCbbNhanVien();
            loadCbbDonDatHang();
            
        }

        

        private void loadCbbDonDatHang()
        {
            try
            {
                List<DonDatHang> dsDonDatHang = donDatHangBLL.LayDanhSachDonDatHang2();
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
                    MessageBox.Show("Không có chức vụ nào.");
                }
            }
            catch
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ.");
            }
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
                    dgvPhieuNhap.RowPostPaint += dgv_RowPostPaint;
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
