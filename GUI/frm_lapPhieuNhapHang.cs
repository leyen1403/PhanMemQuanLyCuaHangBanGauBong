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
            this.btnChuyenSP.Click += BtnChuyenSP_Click;
            dgvChiTietPhieuNhap.CellValueChanged += DgvChiTietPhieuNhap_CellValueChanged;
            dgvChiTietPhieuNhap.CellValidating += DgvChiTietPhieuNhap_CellValidating;
            this.btnLuu.Click += BtnLuu_Click;
            dgvDSSanPham.CellValueChanged += DgvDSSanPham_CellValueChanged;
        }

        private void DgvDSSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDSSanPham.Columns["Chon"].Index)
            {
                int selectedCount = dgvDSSanPham.Rows.Cast<DataGridViewRow>()
                    .Count(row => row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value));

                // Nếu có nhiều hơn 1 sản phẩm được chọn, hiển thị thông báo và bỏ chọn sản phẩm mới
                if (selectedCount > 1)
                {
                    MessageBox.Show("Chỉ có thể chọn một sản phẩm tại một thời điểm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    dgvDSSanPham.Rows[e.RowIndex].Cells["Chon"].Value = false;
                }
            }
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            string maDDH = cbbMaDDH.SelectedValue.ToString();
            try
            {
                foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
                {
                    if (row.IsNewRow) // Bỏ qua dòng mới
                        continue;

                    string maCTPN = row.Cells["MaChiTietPhieuNhap"].Value.ToString();
                    string maCTDDH = row.Cells["MaCTDDH"].Value.ToString();
                    string donViTinh = row.Cells["DonViTinh"].Value.ToString();

                    if (!int.TryParse(row.Cells["SoLuong"].Value.ToString(), out int soLuong) || soLuong <= 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ ở mã chi tiết " + maCTPN);
                        return;
                    }

                    if (!decimal.TryParse(row.Cells["DonGia"].Value.ToString(), out decimal donGia) || donGia <= 0)
                    {
                        MessageBox.Show("Đơn giá không hợp lệ ở mã chi tiết " + maCTPN);
                        return;
                    }

                    decimal thanhTien = soLuong * donGia;
                    string ghiChu = row.Cells["GhiChu"].Value?.ToString();

                    bool isExistCTPN = chiTietPhieuNhapBLL.IsExist(maCTPN);
                    if (!isExistCTPN)
                    {
                        ChiTietPhieuNhap updatedCTPN = new ChiTietPhieuNhap
                        {
                            MaChiTietPhieuNhap = maCTPN,
                            MaPhieuNhap = txtMaPN.Text,
                            DonViTinh = donViTinh,
                            SoLuong = soLuong,
                            DonGia = donGia,
                            ThanhTien = thanhTien,
                            TrangThai = "Chưa giao",
                            MaChiTietDonDatHang = maCTDDH,
                            GhiChu = null
                        };

                        bool isSuccessCTPN = chiTietPhieuNhapBLL.AddChiTietPhieuNhap(updatedCTPN);

                        if (!isSuccessCTPN)
                        {
                            MessageBox.Show("Có lỗi khi thêm chi tiết phiếu nhập mã " + maCTPN);
                            return;
                        }

                        string maSanPham = row.Cells["MaSanPham"].Value.ToString(); ; 
                        if (!string.IsNullOrEmpty(maSanPham))
                        {
                            bool isSuccessUpdateStock = sanPhamBLL.UpdateProductStock(maSanPham, soLuong);
                            if (!isSuccessUpdateStock)
                            {
                                MessageBox.Show("Có lỗi khi cập nhật số lượng tồn của sản phẩm " + maSanPham);
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chi tiết phiếu nhập mã " + maCTPN + " đã tồn tại trong cơ sở dữ liệu.");
                    }
                }               
                MessageBox.Show("Cập nhật thành công!");
                loadDSSanPham(maDDH);
                UpdateTongTien(txtMaPN.Text);
                loadChiTietPhieuNhap(txtMaPN.Text);
                btnLuu.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void DgvChiTietPhieuNhap_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvChiTietPhieuNhap.Columns[e.ColumnIndex].Name == "SoLuong")
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out int value) || value <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương.");
                    e.Cancel = true;
                }
            }
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
        }

        private string GenerateMaChiTietPhieuNhap()
        {
            try
            {
                List<string> existingCTMaPNs = chiTietPhieuNhapBLL.GetAllMaCTPhieuNhap();

                // Lấy danh sách mã chi tiết phiếu nhập hiện tại trên DataGridView
                var existingCTMaPNsOnGrid = dgvChiTietPhieuNhap.Rows.Cast<DataGridViewRow>()
                    .Select(row => row.Cells["MaChiTietPhieuNhap"].Value?.ToString())
                    .Where(maCTPN => !string.IsNullOrEmpty(maCTPN))
                    .ToList();

                // Kết hợp danh sách mã có sẵn từ cả cơ sở dữ liệu và DataGridView
                existingCTMaPNs.AddRange(existingCTMaPNsOnGrid);

                if (existingCTMaPNs == null || existingCTMaPNs.Count == 0)
                {
                    return "CTPN001";
                }

                int maxNumber = 0;
                foreach (string maCTPN in existingCTMaPNs)
                {
                    if (maCTPN.StartsWith("CTPN") && int.TryParse(maCTPN.Substring(4), out int number))
                    {
                        maxNumber = Math.Max(maxNumber, number);
                    }
                }

                string newMaCTPN = "CTPN" + (maxNumber + 1).ToString("D3");
                while (existingCTMaPNs.Contains(newMaCTPN))
                {
                    maxNumber++;
                    newMaCTPN = "CTPN" + (maxNumber + 1).ToString("D3");
                }
                return newMaCTPN;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã chi tiết phiếu nhập: " + ex.Message);
                return null;
            }
        }





        private void BtnChuyenSP_Click(object sender, EventArgs e)
        {
            try
            {
                var chiTietPhieuNhapList = dgvChiTietPhieuNhap.DataSource as List<ChiTietPhieuNhapViewModel> ?? new List<ChiTietPhieuNhapViewModel>();

                foreach (DataGridViewRow row in dgvDSSanPham.Rows)
                {
                    if (row.Cells["Chon"] != null && row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value))
                    {
                        if (row.Cells["MaSanPham"].Value != null)
                        {
                            string maSanPham = row.Cells["MaSanPham"].Value.ToString(); 

                            if (chiTietPhieuNhapList.Any(ct => ct.MaSanPham == maSanPham))
                            {
                                MessageBox.Show("Sản phẩm " + maSanPham + " đã có trong chi tiết phiếu nhập. Vui lòng kiểm tra lại!");
                                continue; 
                            }
                            int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                            decimal donGia = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
                            decimal thanhTien = soLuong * donGia;
                            string maCTDDH = row.Cells["MaCTDDH"].Value?.ToString();
                            decimal DonGiaMoi = donGia / soLuong;
                            decimal DonGiaLamTron = Math.Round(DonGiaMoi, 3);
                            string maCTPN = GenerateMaChiTietPhieuNhap();
                            while (chiTietPhieuNhapList.Any(ct => ct.MaChiTietPhieuNhap == maCTPN))
                            {
                                maCTPN = GenerateMaChiTietPhieuNhap();
                            }
                            chiTietPhieuNhapList.Add(new ChiTietPhieuNhapViewModel
                            {
                                MaChiTietPhieuNhap = maCTPN,
                                MaSanPham = maSanPham, // Gán mã sản phẩm
                                DonViTinh = "Cái",
                                SoLuong = 1,
                                DonGia = DonGiaLamTron,
                                ThanhTien = thanhTien,
                                MaCTDDH = maCTDDH,
                                TrangThai = null,
                                GhiChu = null
                            });

                            row.Cells["Chon"].Value = false;
                        }
                    }
                }

                string maDDH = cbbMaDDH.SelectedValue?.ToString() ?? throw new Exception("Mã DDH không được chọn!");

                var dsCPhieuNhapViewModel = chiTietPhieuNhapList.Select(ct => new ChiTietPhieuNhapViewModel
                {
                    MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
                    MaSanPham = ct.MaSanPham, 
                    DonViTinh = ct.DonViTinh,
                    SoLuong = ct.SoLuong,
                    DonGia = ct.DonGia,
                    ThanhTien = ct.ThanhTien,
                    MaCTDDH = ct.MaCTDDH,
                    TrangThai = ct.TrangThai,
                    GhiChu = ct.GhiChu
                }).ToList();

                dgvChiTietPhieuNhap.DataSource = null;
                dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel;

                // Cấu hình lại các cột của dgvChiTietPhieuNhap
                dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
                dgvChiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã sản phẩm"; 
                dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
                dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvChiTietPhieuNhap.Columns["MaCTDDH"].HeaderText = "Mã chi tiết DDH";
                dgvChiTietPhieuNhap.Columns["TrangThai"].Visible = false;
                dgvChiTietPhieuNhap.Columns["GhiChu"].Visible = false;

                // Cấu hình các cột có thể chỉnh sửa
                dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].ReadOnly = true;
                dgvChiTietPhieuNhap.Columns["MaCTDDH"].ReadOnly = true;
                dgvChiTietPhieuNhap.Columns["ThanhTien"].ReadOnly = true;
                dgvChiTietPhieuNhap.Columns["MaSanPham"].ReadOnly = true;
                dgvChiTietPhieuNhap.Columns["SoLuong"].ReadOnly = false;
                dgvChiTietPhieuNhap.Columns["DonGia"].ReadOnly = false;

                // Căn giữa các tiêu đề cột và định dạng phông chữ
                foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                }

                dgvChiTietPhieuNhap.Refresh();
                MessageBox.Show("Chuyển sản phẩm thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }


            //try
            //{
            //    var chiTietPhieuNhapList = dgvChiTietPhieuNhap.DataSource as List<ChiTietPhieuNhapViewModel> ?? new List<ChiTietPhieuNhapViewModel>();

            //    foreach (DataGridViewRow row in dgvDSSanPham.Rows)
            //    {
            //        if (row.Cells["Chon"] != null && row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value))
            //        {
            //            if (row.Cells["MaSanPham"].Value != null)
            //            {
            //                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
            //                decimal donGia = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
            //                decimal thanhTien = soLuong * donGia;

            //                chiTietPhieuNhapList.Add(new ChiTietPhieuNhapViewModel
            //                {
            //                    MaChiTietPhieuNhap = GenerateMaChiTietPhieuNhap(),
            //                    DonViTinh = "Cái",
            //                    SoLuong = soLuong,
            //                    DonGia = donGia,
            //                    ThanhTien = thanhTien,
            //                    MaCTDDH = null, // Nếu không cần thì có thể bỏ qua
            //                    TrangThai = null, // Nếu không cần thì có thể bỏ qua
            //                    GhiChu = null // Nếu không cần thì có thể bỏ qua
            //                });
            //            }
            //        }
            //    }

            //    string maDDH = cbbMaDDH.SelectedValue?.ToString() ?? throw new Exception("Mã DDH không được chọn!");

            //    var dsCPhieuNhapViewModel = (from ct in chiTietPhieuNhapList
            //                                 join row in dgvDSSanPham.Rows.Cast<DataGridViewRow>()
            //                                 on true equals true
            //                                 where row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value)
            //                                 select new ChiTietPhieuNhapViewModel
            //                                 {
            //                                     MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
            //                                     MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
            //                                     DonViTinh = ct.DonViTinh,
            //                                     SoLuong = ct.SoLuong,
            //                                     DonGia = ct.DonGia,
            //                                     ThanhTien = ct.ThanhTien,
            //                                     MaCTDDH = ct.MaCTDDH,
            //                                     TrangThai = ct.TrangThai,
            //                                     GhiChu = ct.GhiChu
            //                                 }).ToList();

            //    dgvChiTietPhieuNhap.DataSource = null;
            //    dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel;

            //    // Xóa các dòng đã chuyển khỏi dgvDSSanPham
            //    //foreach (DataGridViewRow row in dgvDSSanPham.Rows)
            //    //{
            //    //    if (Convert.ToBoolean(row.Cells["Chon"].Value))
            //    //    {
            //    //        dgvDSSanPham.Rows.Remove(row);
            //    //    }
            //    //}

            //    // Đặt tên cho các cột
            //    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
            //    dgvChiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            //    dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            //    dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";
            //    dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
            //    dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
            //    dgvChiTietPhieuNhap.Columns["MaCTDDH"].HeaderText = "Mã chi tiết DDH";
            //    dgvChiTietPhieuNhap.Columns["TrangThai"].Visible = false;
            //    dgvChiTietPhieuNhap.Columns["GhiChu"].Visible = false;

            //    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].ReadOnly = true;
            //    dgvChiTietPhieuNhap.Columns["MaSanPham"].ReadOnly = true;
            //    dgvChiTietPhieuNhap.Columns["SoLuong"].ReadOnly = false; // Có thể chỉnh sửa
            //    dgvChiTietPhieuNhap.Columns["DonGia"].ReadOnly = false; // Có thể chỉnh sửa

            //    // Căn giữa các tiêu đề cột và định dạng phông chữ
            //    foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
            //    {
            //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            //    }

            //    dgvChiTietPhieuNhap.Refresh();
            //    MessageBox.Show("Chuyển sản phẩm thành công!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}







            //try
            //{
            //    var chiTietPhieuNhapList = dgvChiTietPhieuNhap.DataSource as List<ChiTietPhieuNhap> ?? new List<ChiTietPhieuNhap>();

            //    foreach (DataGridViewRow row in dgvDSSanPham.Rows)
            //    {
            //        if (row.Cells["Chon"] != null && row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value))
            //        {
            //            if (row.Cells["MaSanPham"].Value != null)
            //            {
            //                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
            //                decimal donGia = Convert.ToDecimal(row.Cells["GiaNhap"].Value);
            //                decimal thanhTien = soLuong * donGia;

            //                chiTietPhieuNhapList.Add(new ChiTietPhieuNhap
            //                {
            //                    MaChiTietPhieuNhap = GenerateMaChiTietPhieuNhap(),
            //                    DonViTinh = "Cái",
            //                    SoLuong = soLuong,
            //                    DonGia = donGia,
            //                    ThanhTien = thanhTien
            //                });
            //            }
            //        }
            //    }

            //    string maDDH = cbbMaDDH.SelectedValue?.ToString() ?? throw new Exception("Mã DDH không được chọn!");

            //    var dsCPhieuNhapViewModel = (from ct in chiTietPhieuNhapList
            //                                 join row in dgvDSSanPham.Rows.Cast<DataGridViewRow>()
            //                                 on true equals true
            //                                 where row.Cells["Chon"].Value != null && Convert.ToBoolean(row.Cells["Chon"].Value)
            //                                 select new
            //                                 {
            //                                     MaChiTietPhieuNhap = ct.MaChiTietPhieuNhap,
            //                                     MaSanPham = row.Cells["MaSanPham"].Value.ToString(),
            //                                     DonViTinh = ct.DonViTinh,
            //                                     SoLuong = ct.SoLuong,
            //                                     DonGia = ct.DonGia,
            //                                     ThanhTien = ct.ThanhTien,
            //                                     TrangThai = ct.TrangThai,
            //                                     GhiChu = ct.GhiChu,
            //                                     MaCTDDH = ct.MaChiTietDonDatHang
            //                                 }).ToList();

            //    dgvChiTietPhieuNhap.DataSource = null;
            //    dgvChiTietPhieuNhap.DataSource = dsCPhieuNhapViewModel;

            //    // Xóa các dòng đã chuyển khỏi dgvDSSanPham


            //    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].HeaderText = "Mã chi tiết phiếu nhập";
            //    dgvChiTietPhieuNhap.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
            //    dgvChiTietPhieuNhap.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
            //    dgvChiTietPhieuNhap.Columns["SoLuong"].HeaderText = "Số lượng";


            //    dgvChiTietPhieuNhap.Columns["DonGia"].HeaderText = "Đơn giá";
            //    dgvChiTietPhieuNhap.Columns["ThanhTien"].HeaderText = "Thành tiền";
            //    dgvChiTietPhieuNhap.Columns["MaCTDDH"].HeaderText = "Mã chi tiết DDH";

            //    dgvChiTietPhieuNhap.Columns["TrangThai"].Visible = false;
            //    dgvChiTietPhieuNhap.Columns["GhiChu"].Visible = false;

            //    foreach (DataGridViewColumn column in dgvChiTietPhieuNhap.Columns)
            //    {
            //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            //    }

            //    dgvChiTietPhieuNhap.Refresh();
            //    MessageBox.Show("Chuyển sản phẩm thành công!");
            //    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].ReadOnly = true;
            //    dgvChiTietPhieuNhap.Columns["MaSanPham"].ReadOnly = true;
            //    dgvChiTietPhieuNhap.Columns["SoLuong"].ReadOnly = false;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}

        }

        private void CbbMaDDH_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaDDH.SelectedValue != null)
                {
                    string maDDH = cbbMaDDH.SelectedValue.ToString();
                    loadDSSanPham(maDDH);
                    loadDSPhieuNhapByDonDatHang(maDDH);
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
                                                    SoLuong = ct.SoLuongTon,
                                                    GiaNhap = ct.GiaNhap,
                                                    MaCTDDH = chiTietDonDatHangBLL.GetMaCTDDHByMaSanPham(ct.MaSanPham)
                                                };
                    dgvDSSanPham.DataSource = dsSanPhamViewModel.ToList();
                    dgvDSSanPham.Columns["MaSanPham"].HeaderText = "Mã sản phẩm";
                   // dgvDSSanPham.Columns["DonViTinh"].HeaderText = "Đơn vị tính";
                    dgvDSSanPham.Columns["DonViTinh"].Visible =false;

                    dgvDSSanPham.Columns["SoLuong"].HeaderText = "Số lượng";
                    dgvDSSanPham.Columns["MaCTDDH"].Visible = false;
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

        //ChiTietPhieuNhap newCTPN = new ChiTietPhieuNhap
        //{
        //    MaChiTietPhieuNhap = maCTPN,
        //    MaPhieuNhap = maPN,
        //    DonViTinh = donViTinh,
        //    SoLuong = soLuong,
        //    DonGia = donGia,
        //    ThanhTien = thanhTien,
        //    TrangThai = "Chưa giao",
        //    MaChiTietDonDatHang = maCTDDH,
        //    GhiChu = ghiChu
        //};

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
                string maDDH = cbbMaDDH.SelectedValue.ToString();

                if (isUpdated)
                {
                    loadDSPhieuNhapByDonDatHang(maDDH);
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
        private string GenerateMaPhieuNhap()
        {
            try
            {
                List<string> existingMaPNs = phieuNhapBLL.GetAllMaPhieuNhap(); 

                if (existingMaPNs == null || existingMaPNs.Count == 0)
                {
                    return "PN001";
                }

                int maxNumber = 0;
                foreach (string maPN in existingMaPNs)
                {
                    if (maPN.StartsWith("PN") && int.TryParse(maPN.Substring(2), out int number))
                    {
                        maxNumber = Math.Max(maxNumber, number);
                    }
                }
                return "PN" + (maxNumber + 1).ToString("D3"); //
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã phiếu nhập: " + ex.Message);
                return null;
            }
        }


        private void BtnTaoPhieu_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    string maPN = txtMaPN.Text;
            //    string nhanVien = cbbNhanVien.SelectedValue?.ToString();
            //    string donDatHang = cbbMaDDH.SelectedValue?.ToString();
            //    // string chiTietDonDatHang = cbbMaCTDDH.SelectedValue?.ToString();
            //    int lanNhap = int.Parse(txtLanNhap.Text);
            //    string trangThai = txtTrangThai.Text;


            //    PhieuNhap newPhieuNhap = new PhieuNhap
            //    {
            //        MaPhieuNhap = maPN,
            //        NgayLap = DateTime.Now,
            //        TrangThai = trangThai,
            //        LanNhap = lanNhap,
            //        MaDonDatHang = donDatHang,
            //        MaNhanVien = nhanVien
            //    };


            //    bool isSuccessPN = phieuNhapBLL.AddPhieuNhap(newPhieuNhap);

            //    if (isSuccessPN)
            //    {
            //        MessageBox.Show("Phiếu nhập đã được thêm thành công!");

            //        maPN = newPhieuNhap.MaPhieuNhap;
            //        txtMaPN.Text = maPN;
            //        loadDSPhieuNhap();
            //        loadDSSanPham(donDatHang);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Có lỗi khi thêm phiếu nhập. Vui lòng thử lại.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
            try
            {
                string maPN = GenerateMaPhieuNhap();
                txtMaPN.Text = maPN;

                string nhanVien = cbbNhanVien.SelectedValue?.ToString();
                string donDatHang = cbbMaDDH.SelectedValue?.ToString();
                int lanNhap = int.Parse(txtLanNhap.Text);
                string trangThai = txtTrangThai.Text;

                PhieuNhap newPhieuNhap = new PhieuNhap
                {
                    MaPhieuNhap = maPN,
                    NgayLap = DateTime.Now,
                    TrangThai = "Đang chờ",
                    LanNhap = 1,
                    MaDonDatHang = donDatHang,
                    MaNhanVien = nhanVien
                };
                bool isSuccessPN = phieuNhapBLL.AddPhieuNhap(newPhieuNhap);

                if (isSuccessPN)
                {
                    MessageBox.Show("Phiếu nhập đã được thêm thành công!");

                    txtMaPN.Text = maPN;
                    loadDSPhieuNhapByDonDatHang(donDatHang);
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
            btnLuu.Enabled = true;

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

                if (dsCPhieuNhap != null)
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
                    dgvChiTietPhieuNhap.Columns["TrangThai"].Visible = false;
                    dgvChiTietPhieuNhap.Columns["GhiChu"].Visible = false;

                    dgvChiTietPhieuNhap.Columns["MaChiTietPhieuNhap"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["MaSanPham"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["DonViTinh"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["DonGia"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["ThanhTien"].ReadOnly = true;
                    dgvChiTietPhieuNhap.Columns["MaCTDDH"].ReadOnly = true;



                    // Căn giữa các tiêu đề cột và định dạng phông chữ
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
            //loadDSPhieuNhap();
            loadCbbNhanVien();
            loadCbbDonDatHang();
            btnLuu.Enabled = false;
            
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

        private void loadDSPhieuNhapByDonDatHang(string maDDH)
        {
            dgvPhieuNhap.DataSource = null;
            try
            {
               
                List<PhieuNhap> dsPhieuNhap = phieuNhapBLL.GetListPhieuNhapByDonDatHang(maDDH);
                if (dsPhieuNhap != null)
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

        private void btnNhapLaiPN_Click_1(object sender, EventArgs e)
        {

        }
    }
}
