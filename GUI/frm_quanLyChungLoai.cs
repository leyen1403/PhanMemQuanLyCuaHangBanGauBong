using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyChungLoai : Form
    {

        MauSacBLL _mauSacBLL = new MauSacBLL();
        KichThuocBLL _kichThuocBLL = new KichThuocBLL();
        LoaiSanPhamBLL _loaiSanPhamBLL = new LoaiSanPhamBLL();
        public frm_quanLyChungLoai()
        {
            InitializeComponent();
        }
        private string taoMaLoai()
        {
            string maloai = "";
            int soLuongLoaI = _loaiSanPhamBLL.GetAll().Count;
            if (soLuongLoaI == 0)
            {
                maloai = "LSP001";
            }
            else
            {
                maloai = "LSP" + (soLuongLoaI + 1).ToString("000");
            }
            return maloai;
        }
        private string taoMaMau()
        {
            string maMau = "";
            int soLuongMau = _mauSacBLL.GetAllMauSac().Count; 
            if (soLuongMau == 0)
            {
                maMau = "MS001";
            }
            else
            {
                maMau = "MS" + (soLuongMau + 1).ToString("000");
            }
            return maMau;
        }
        private string taoMaKichThuoc()
        {
            string maKichThuoc = "";
            int soLuongKichThuoc = _kichThuocBLL.GetAll().Count; // Giả sử _kichThuocBLL là lớp xử lý kích thước
            if (soLuongKichThuoc == 0)
            {
                maKichThuoc = "K001";
            }
            else
            {
                maKichThuoc = "K" + (soLuongKichThuoc + 1).ToString("000");
            }
            return maKichThuoc;
        }

        private void loadMauSac()
        {
            dgv_dsMauSac.DataSource = null;
            dgv_dsMauSac.Columns.Clear(); // Xóa tất cả cột trước để tránh lỗi thêm trùng cột
            List<MauSac> dsMauSac = _mauSacBLL.GetAllMauSac();
            dgv_dsMauSac.DataSource = dsMauSac;

            // Đặt tên và định dạng cột
            dgv_dsMauSac.Columns[0].HeaderText = "Mã Màu";
            dgv_dsMauSac.Columns[1].HeaderText = "Tên Màu";
            dgv_dsMauSac.Columns[2].HeaderText = "Mô tả";
            dgv_dsMauSac.Columns[2].Width = 400;
            dgv_dsMauSac.Columns[3].HeaderText = "URL";

            // Sử dụng sự kiện RowPostPaint để tự động đánh số thứ tự
            dgv_dsMauSac.RowPostPaint += dgv_RowPostPaint;
        }

        private void loadKichThuoc()
        {
            dgv_dsKichThuoc.DataSource = null;
            dgv_dsKichThuoc.Columns.Clear();
            List<KichThuoc> dsKichThuoc = _kichThuocBLL.GetAll();
            dgv_dsKichThuoc.DataSource = dsKichThuoc;

            dgv_dsKichThuoc.Columns[0].HeaderText = "Mã Kích Thước";
            dgv_dsKichThuoc.Columns[1].HeaderText = "Tên Kích Thước";
            dgv_dsKichThuoc.Columns[2].HeaderText = "Mô tả";
            dgv_dsKichThuoc.Columns[2].Width = 380;

            dgv_dsKichThuoc.RowPostPaint += dgv_RowPostPaint;
        }

        private void loadLoaiSanPham()
        {
            dgv_dsLoaiSanPham.DataSource = null;
            dgv_dsLoaiSanPham.Columns.Clear();
            List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.GetAll();
            dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;

            dgv_dsLoaiSanPham.Columns[0].HeaderText = "Mã Loại";
            dgv_dsLoaiSanPham.Columns[1].HeaderText = "Tên Loại";
            dgv_dsLoaiSanPham.Columns[2].HeaderText = "Mô tả";
            dgv_dsLoaiSanPham.Columns[3].HeaderText = "URL";
            dgv_dsLoaiSanPham.Columns[2].Width = 380;
            dgv_dsLoaiSanPham.Columns[3].Width = 280;

            dgv_dsLoaiSanPham.RowPostPaint += dgv_RowPostPaint;
        }

        // Sự kiện RowPostPaint để tự động điền số thứ tự
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


        private void DatabingdingLoaiSanPham()
        {

        }

        private void frm_quanLyChungLoai_Load(object sender, EventArgs e)
        {
            loadMauSac();
            loadKichThuoc();
            loadLoaiSanPham();
            txt_timKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_timKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_themLoaiSanPham.Click += Btn_themLoaiSanPham_Click;
            btn_xoaLoaiSanPham.Click += Btn_xoaLoaiSanPham_Click;
            btn_suaLoaiSanPham.Click += Btn_suaLoaiSanPham_Click;
            btn_themHinhAnh.Click += Btn_themHinhAnh_Click;
            btn_themMauSac.Click += Btn_themMauSac_Click;
            btn_suaMauSac.Click += Btn_suaMauSac_Click;
            btn_xoaMauSac.Click += Btn_xoaMauSac_Click;
            btn_themKichThuoc.Click += Btn_themKichThuoc_Click;
            btn_xoaKichThuoc.Click += Btn_xoaKichThuoc_Click;
            btn_suaKichThuoc.Click += Btn_suaKichThuoc_Click;
            txt_timKiem.TextChanged += Txt_timKiem_TextChanged;
            btn_themAnhMauSac.Click += Btn_themAnhMauSac_Click;
        }
        private void LoadImageToPictureBoxMauSac(string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                if (File.Exists(resourcePath))
                {
                    img_mauSac.Image = Image.FromFile(resourcePath);
                    img_mauSac.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
                }
                else
                {
                    img_mauSac.Image = Properties.Resources.gaucute;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_themAnhMauSac_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{txt_maMauSac.Text}_{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return; 
                        }
                    }

                    txt_duongDanMauSac.Text = newImageName;
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBoxMauSac(newImageName);
                    }
                }
            }
        }

        private void Txt_timKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txt_timKiem.Text;
                List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.Search(tuKhoa);
                dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (var item in dsLoaiSanPham)
                {
                    autoCompleteCollection.Add(item.TenLoai);
                }
                txt_timKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_timKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_timKiem.AutoCompleteCustomSource = autoCompleteCollection;
                if (dsLoaiSanPham.Count == 0)
                {
                    loadLoaiSanPham();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_suaKichThuoc_Click(object sender, EventArgs e)
        {
            string maKichThuoc = txt_maKichThuoc.Text;
            string tenKichThuoc = txt_tenKichThuoc.Text;
            string moTaKichThuoc = txt_moTaKichThuoc.Text;

            if (string.IsNullOrEmpty(maKichThuoc) || string.IsNullOrEmpty(tenKichThuoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm kích thước này?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                KichThuoc kichThuoc = new KichThuoc
                {
                    MaKichThuoc = maKichThuoc,
                    TenKichThuoc = tenKichThuoc,
                    MoTa = moTaKichThuoc
                };

                bool result = _kichThuocBLL.Update(kichThuoc);
                loadKichThuoc();

                if (result)
                {
                    MessageBox.Show("Sửa kích thước thành công.");
                }
                else
                {
                    MessageBox.Show("sửa kích thước thất bại.");
                }
            }
        }

        private void Btn_xoaKichThuoc_Click(object sender, EventArgs e)
        {
            string maKichThuoc = txt_maKichThuoc.Text;

            if (string.IsNullOrEmpty(maKichThuoc))
            {
                MessageBox.Show("Vui lòng nhập mã kích thước.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa kích thước này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = _kichThuocBLL.Delete(maKichThuoc);
                loadKichThuoc();
                if (result)
                {
                    MessageBox.Show("Xóa kích thước thành công.");
                    
                }
                else
                {
                    MessageBox.Show("Xóa kích thước thất bại.");
                }
            }
        }

        private void Btn_themKichThuoc_Click(object sender, EventArgs e)
        {
            string maKichThuoc =taoMaKichThuoc() ;
            string tenKichThuoc = txt_tenKichThuoc.Text;
            string moTaKichThuoc = txt_moTaKichThuoc.Text;

            if (string.IsNullOrEmpty(maKichThuoc) || string.IsNullOrEmpty(tenKichThuoc))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm kích thước này?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                KichThuoc kichThuoc = new KichThuoc
                {
                    MaKichThuoc = maKichThuoc,
                    TenKichThuoc = tenKichThuoc,
                    MoTa = moTaKichThuoc
                };
                bool result = _kichThuocBLL.Add(kichThuoc);

                if (result)
                {
                    MessageBox.Show("Thêm kích thước thành công.");
                    loadKichThuoc();
                }
                else
                {
                    MessageBox.Show("Thêm kích thước thất bại.");
                }
            }
        }

        private void Btn_xoaMauSac_Click(object sender, EventArgs e)
        {
            string maMauSac = txt_maMauSac.Text;
            if (string.IsNullOrEmpty(maMauSac))
            {
                MessageBox.Show("Vui lòng nhập mã màu cần xóa.");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa màu sắc này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = _mauSacBLL.DeleteMauSac(maMauSac);
                if (result)
                {
                    MessageBox.Show("Xóa màu sắc thành công.");
                    loadMauSac();

                }
                else
                {
                    MessageBox.Show("Xóa màu sắc thất bại.");
                }
            }
        }

        private void Btn_suaMauSac_Click(object sender, EventArgs e)
        {
            string maMauSac = txt_maMauSac.Text;
            string tenMauSac = txt_tenMauSac.Text;
            string moTaMauSac = txt_moTaMauSac.Text;
            string duongDanMauSac = txt_duongDanMauSac.Text;
            if (string.IsNullOrEmpty(maMauSac) || string.IsNullOrEmpty(tenMauSac) || string.IsNullOrEmpty(moTaMauSac))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa màu sắc này?", "Xác nhận sửa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MauSac mauSac = new MauSac
                {
                    MaMau = maMauSac,
                    TenMau = tenMauSac,
                    MoTa = moTaMauSac,
                    HinhAnh = duongDanMauSac 
                };

                bool result = _mauSacBLL.UpdateMauSac(mauSac);
                if (result)
                {
                    MessageBox.Show("Sửa màu sắc thành công.");
                    loadMauSac();
                }
                else
                {
                    MessageBox.Show("Sửa màu sắc thất bại.");
                }
            }
        }

        private void Btn_themMauSac_Click(object sender, EventArgs e)
        {
            string maMauSac = taoMaKichThuoc();
            string tenMauSac = txt_tenMauSac.Text;
            string moTaMauSac = txt_moTaMauSac.Text;
            string duongDanMauSac = txt_duongDanMauSac.Text;

            if (string.IsNullOrEmpty(maMauSac) || string.IsNullOrEmpty(tenMauSac) || string.IsNullOrEmpty(moTaMauSac))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm màu sắc này?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MauSac mauSac = new MauSac
                {
                    MaMau = maMauSac,
                    TenMau = tenMauSac,
                    MoTa = moTaMauSac,
                    HinhAnh = duongDanMauSac 
                };
                bool result = _mauSacBLL.AddMauSac(mauSac);
                if (result)
                {
                    MessageBox.Show("Thêm màu sắc thành công.");
                    loadMauSac();
                }
                else
                {
                    MessageBox.Show("Thêm màu sắc thất bại.");
                }
            }
        }


        private void LoadImageToPictureBox(string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                if (File.Exists(resourcePath))
                {
                    img_Loai.Image = Image.FromFile(resourcePath);
                    img_Loai.SizeMode = PictureBoxSizeMode.Zoom; 
                }
                else
                {
                   img_Loai.Image=Properties.Resources.gaucute;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh lên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_themHinhAnh_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string newImageName = $"{txt_maLoai.Text}_{Path.GetFileName(selectedImagePath)}";
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);
                    if (File.Exists(resourcePath))
                    {
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return; 
                        }
                    }

                    txt_duongDan.Text = newImageName;

                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        LoadImageToPictureBox(newImageName);
                    }
                }
            }

        }

        // Phương thức lưu ảnh vào thư mục Resources
        private bool SaveImageToResources(string imagePath, string imageName)
        {
            try
            {
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                File.Copy(imagePath, resourcePath, true);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        

        private void Btn_luuLoaiSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    // Nếu mã loại sản phẩm rỗng, thực hiện thêm mới
                    Btn_themLoaiSanPham_Click(sender, e);
                }
                else
                {
                    Btn_suaLoaiSanPham_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_suaLoaiSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    LoaiSanPham loaiSanPham = new LoaiSanPham
                    {
                        MaLoai = txt_maLoai.Text,
                        TenLoai = txt_tenLoai.Text,
                        MoTa = txt_moTa.Text,
                        HinhAnh = txt_duongDan.Text
                    };

                    _loaiSanPhamBLL.Update(loaiSanPham);
                    loadLoaiSanPham();

                    MessageBox.Show("Sửa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_xoaLoaiSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    string maLoai = txt_maLoai.Text;
                    _loaiSanPhamBLL.Delete(maLoai);
                    loadLoaiSanPham();
                    MessageBox.Show("Xóa loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập mã loại sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_themLoaiSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                LoaiSanPham loaiSanPham = new LoaiSanPham
                {
                    MaLoai = taoMaLoai(),
                    TenLoai = txt_tenLoai.Text,
                    MoTa = txt_moTa.Text,
                    HinhAnh = txt_duongDan.Text
                };

                _loaiSanPhamBLL.Add(loaiSanPham);
                loadLoaiSanPham();
                MessageBox.Show("Thêm loại sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_timKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox
                string tuKhoa = txt_timKiem.Text;

                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.Search(tuKhoa);
                    dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    foreach (var item in dsLoaiSanPham)
                    {
                        autoCompleteCollection.Add(item.TenLoai); 
                    }
                    txt_timKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt_timKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt_timKiem.AutoCompleteCustomSource = autoCompleteCollection;
                    if (dsLoaiSanPham.Count == 0)
                    {
                        dgv_dsLoaiSanPham.DataSource = null;
                        MessageBox.Show("Không tìm thấy loại sản phẩm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    dgv_dsLoaiSanPham.DataSource = null;
                    txt_timKiem.AutoCompleteCustomSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm loại sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_dsLoaiSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_dsLoaiSanPham.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_dsLoaiSanPham.SelectedRows[0];
                LoaiSanPham selectedLoaiSanPham = selectedRow.DataBoundItem as LoaiSanPham;

                if (selectedLoaiSanPham != null)
                {
                    txt_maLoai.Text = selectedLoaiSanPham.MaLoai;
                    txt_tenLoai.Text = selectedLoaiSanPham.TenLoai;
                    txt_moTa.Text = selectedLoaiSanPham.MoTa;
                    string imageName = selectedLoaiSanPham.HinhAnh; 
                   LoadImageToPictureBox(imageName);
                }
            }
        }

        private void dgv_dsMauSac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_dsMauSac.Rows[e.RowIndex];
                txt_maMauSac.Text = row.Cells[0].Value?.ToString() ?? string.Empty; 
                txt_tenMauSac.Text = row.Cells[1].Value?.ToString() ?? string.Empty; 
                txt_moTaMauSac.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                txt_duongDanMauSac.Text = row.Cells[3].Value?.ToString() ?? string.Empty; 
                string duongDan = row.Cells[3].Value?.ToString() ?? string.Empty;
                LoadImageToPictureBoxMauSac(duongDan);
            }
        }

        private void dgv_dsKichThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_dsKichThuoc.Rows[e.RowIndex];
                txt_maKichThuoc.Text = row.Cells[0].Value.ToString();
                txt_tenKichThuoc.Text = row.Cells[1].Value.ToString();
                txt_moTaKichThuoc.Text = row.Cells[2].Value.ToString();
            }
        }

        private void dgv_dsMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_dsMauSac.Rows[e.RowIndex];
                txt_maMauSac.Text = row.Cells[0].Value?.ToString() ?? string.Empty; 
                txt_tenMauSac.Text = row.Cells[1].Value?.ToString() ?? string.Empty; 
                txt_moTaMauSac.Text = row.Cells[2].Value?.ToString() ?? string.Empty; 
                txt_duongDanMauSac.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                string duongDan = row.Cells[3].Value?.ToString() ?? string.Empty;
                LoadImageToPictureBoxMauSac(duongDan);
            }
        }

        private void dgv_dsKichThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_dsKichThuoc.Rows[e.RowIndex];
                txt_maKichThuoc.Text = row.Cells[0].Value.ToString();
                txt_tenKichThuoc.Text = row.Cells[1].Value.ToString();
                txt_moTaKichThuoc.Text = row.Cells[2].Value.ToString();
            }
        }

        private void dgv_dsLoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_dsLoaiSanPham.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_dsLoaiSanPham.SelectedRows[0];
                LoaiSanPham selectedLoaiSanPham = selectedRow.DataBoundItem as LoaiSanPham;

                if (selectedLoaiSanPham != null)
                {
                    txt_maLoai.Text = selectedLoaiSanPham.MaLoai;
                    txt_tenLoai.Text = selectedLoaiSanPham.TenLoai;
                    txt_moTa.Text = selectedLoaiSanPham.MoTa;
                    string imageName = selectedLoaiSanPham.HinhAnh; 
                    LoadImageToPictureBox(imageName);
                }
            }
        }

        private void dgv_dsMauSac_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }
    }
}
