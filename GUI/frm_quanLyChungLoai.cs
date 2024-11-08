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

        private void loadMauSac()
        {
            dgv_dsMauSac.DataSource = null;
            List<MauSac> dsMauSac = _mauSacBLL.GetAllMauSac();
            if (dsMauSac.Count > 0)
            {
                dgv_dsMauSac.DataSource = dsMauSac;

                // Đặt tên và định dạng cột khi có dữ liệu
                dgv_dsMauSac.Columns[0].HeaderText = "Mã Màu";
                dgv_dsMauSac.Columns[1].HeaderText = "Tên Màu";
                dgv_dsMauSac.Columns[2].HeaderText = "Mô tả";
                dgv_dsMauSac.Columns[2].Width = 400;
                dgv_dsMauSac.Columns[3].HeaderText = "URL";

            }
        }
        private void loadKichThuoc()
        {
            dgv_dsKichThuoc.DataSource = null;
            List<KichThuoc> dsKichThuoc = _kichThuocBLL.GetAll();
            if (dsKichThuoc.Count > 0)
            {
                dgv_dsKichThuoc.DataSource = dsKichThuoc;

                // Đặt tên và định dạng cột khi có dữ liệu
                dgv_dsKichThuoc.Columns[0].HeaderText = "Mã Kích Thước";
                dgv_dsKichThuoc.Columns[1].HeaderText = "Tên Kích Thước";
                dgv_dsKichThuoc.Columns[2].HeaderText = "Mô tả";
                dgv_dsKichThuoc.Columns[2].Width = 380;

            }
        }

        private void loadLoaiSanPham()
        {
            dgv_dsLoaiSanPham.DataSource = null;
            List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.GetAll();
            dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;

            // Đặt tên cho các cột trong dgv_dsLoaiSanPham
            dgv_dsLoaiSanPham.Columns[0].HeaderText = "Mã Loại";
            dgv_dsLoaiSanPham.Columns[1].HeaderText = "Tên Loại";
            dgv_dsLoaiSanPham.Columns[2].HeaderText = "Mô tả";
            dgv_dsLoaiSanPham.Columns[3].HeaderText = "url";
            dgv_dsLoaiSanPham.Columns[2].Width = 380;
            dgv_dsLoaiSanPham.Columns[3].Width = 280;

            // Dàn đều các cột
            dgv_dsLoaiSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Các cột sẽ tự động dàn đều
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
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
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

                    // Đổi tên ảnh dựa trên mã loại sản phẩm hoặc tên khác
                    string newImageName = $"{txt_maMauSac.Text}_{Path.GetFileName(selectedImagePath)}";

                    // Đường dẫn lưu ảnh trong thư mục Resources của ứng dụng
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);

                    // Kiểm tra xem ảnh đã tồn tại chưa
                    if (File.Exists(resourcePath))
                    {
                        // Hỏi người dùng có muốn ghi đè ảnh cũ không
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return; // Dừng lại nếu người dùng không muốn ghi đè
                        }
                    }

                    // Cập nhật đường dẫn mới vào TextBox hiển thị đường dẫn
                    txt_duongDanMauSac.Text = newImageName;

                    // Lưu ảnh vào thư mục Resources
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        // Hiển thị hình ảnh đã lưu vào PictureBox
                        LoadImageToPictureBoxMauSac(newImageName);
                    }
                }
            }
        }

        private void Txt_timKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Lấy từ khóa tìm kiếm từ TextBox
                string tuKhoa = txt_timKiem.Text;

                // Gọi phương thức tìm kiếm từ BLL
                List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.Search(tuKhoa);

                // Cập nhật danh sách tìm được vào DataGridView
                dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;

                // Thiết lập AutoComplete cho TextBox
                AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                foreach (var item in dsLoaiSanPham)
                {
                    autoCompleteCollection.Add(item.TenLoai); // Thêm tên loại sản phẩm vào gợi ý
                }

                // Cấu hình AutoComplete cho txt_timKiem
                txt_timKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txt_timKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txt_timKiem.AutoCompleteCustomSource = autoCompleteCollection;

                // Nếu không tìm thấy kết quả, hiển thị thông báo và xóa dữ liệu trong DataGridView
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

                // Cập nhật danh sách sau khi thêm
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
            // Lấy mã màu từ TextBox
            string maMauSac = txt_maMauSac.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maMauSac))
            {
                MessageBox.Show("Vui lòng nhập mã màu cần xóa.");
                return;
            }

            // Hiển thị hộp thoại xác nhận xóa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa màu sắc này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Xóa màu sắc
                bool result = _mauSacBLL.DeleteMauSac(maMauSac);

                // Thông báo kết quả
                if (result)
                {
                    MessageBox.Show("Xóa màu sắc thành công.");
                    // Cập nhật danh sách nếu cần
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
            // Lấy dữ liệu từ các TextBox
            string maMauSac = txt_maMauSac.Text;
            string tenMauSac = txt_tenMauSac.Text;
            string moTaMauSac = txt_moTaMauSac.Text;
            string duongDanMauSac = txt_duongDanMauSac.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maMauSac) || string.IsNullOrEmpty(tenMauSac) || string.IsNullOrEmpty(moTaMauSac))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Hiển thị hộp thoại xác nhận sửa
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa màu sắc này?", "Xác nhận sửa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Tạo đối tượng MauSac
                MauSac mauSac = new MauSac
                {
                    MaMau = maMauSac,
                    TenMau = tenMauSac,
                    MoTa = moTaMauSac,
                    HinhAnh = duongDanMauSac // Đường dẫn hình ảnh của màu sắc
                };

                // Sửa màu sắc
                bool result = _mauSacBLL.UpdateMauSac(mauSac);

                // Thông báo kết quả
                if (result)
                {
                    MessageBox.Show("Sửa màu sắc thành công.");
                    loadMauSac();
                    // Cập nhật danh sách nếu cần
                }
                else
                {
                    MessageBox.Show("Sửa màu sắc thất bại.");
                }
            }
        }

        private void Btn_themMauSac_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string maMauSac = txt_maMauSac.Text;
            string tenMauSac = txt_tenMauSac.Text;
            string moTaMauSac = txt_moTaMauSac.Text;
            string duongDanMauSac = txt_duongDanMauSac.Text;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maMauSac) || string.IsNullOrEmpty(tenMauSac) || string.IsNullOrEmpty(moTaMauSac))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Hiển thị hộp thoại xác nhận thêm
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm màu sắc này?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Tạo đối tượng MauSac
                MauSac mauSac = new MauSac
                {
                    MaMau = maMauSac,
                    TenMau = tenMauSac,
                    MoTa = moTaMauSac,
                    HinhAnh = duongDanMauSac // Đường dẫn hình ảnh của màu sắc
                };

                // Thêm màu sắc
                bool result = _mauSacBLL.AddMauSac(mauSac);

                // Thông báo kết quả
                if (result)
                {
                    MessageBox.Show("Thêm màu sắc thành công.");
                    loadMauSac();
                    // Cập nhật danh sách nếu cần
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
                // Đường dẫn đến ảnh trong thư mục Resources
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Kiểm tra nếu file ảnh tồn tại, hiển thị ảnh vào PictureBox
                if (File.Exists(resourcePath))
                {
                    img_Loai.Image = Image.FromFile(resourcePath);
                    img_Loai.SizeMode = PictureBoxSizeMode.Zoom; // Tùy chọn để ảnh phù hợp với PictureBox
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

                    // Đổi tên ảnh dựa trên mã loại sản phẩm hoặc tên khác
                    string newImageName = $"{txt_maLoai.Text}_{Path.GetFileName(selectedImagePath)}";

                    // Đường dẫn lưu ảnh trong thư mục Resources của ứng dụng
                    string resourcePath = Path.Combine(Application.StartupPath, "Resources", newImageName);

                    // Kiểm tra xem ảnh đã tồn tại chưa
                    if (File.Exists(resourcePath))
                    {
                        // Hỏi người dùng có muốn ghi đè ảnh cũ không
                        DialogResult result = MessageBox.Show("Ảnh đã tồn tại. Bạn có muốn ghi đè không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return; // Dừng lại nếu người dùng không muốn ghi đè
                        }
                    }

                    // Cập nhật đường dẫn mới vào TextBox hiển thị đường dẫn
                    txt_duongDan.Text = newImageName;

                    // Lưu ảnh vào thư mục Resources
                    bool isSaved = SaveImageToResources(selectedImagePath, newImageName);

                    if (isSaved)
                    {
                        // Hiển thị hình ảnh đã lưu vào PictureBox
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
                // Đường dẫn lưu ảnh trong thư mục Resources của ứng dụng
                string resourcePath = Path.Combine(Application.StartupPath, "Resources", imageName);

                // Tạo thư mục Resources nếu chưa tồn tại
                string directoryPath = Path.GetDirectoryName(resourcePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Sao chép ảnh vào thư mục Resources
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
                // Kiểm tra nếu mã loại sản phẩm đã có sẵn (cho sửa) hoặc chưa có (cho thêm mới)
                if (string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    // Nếu mã loại sản phẩm rỗng, thực hiện thêm mới
                    Btn_themLoaiSanPham_Click(sender, e);
                }
                else
                {
                    // Nếu mã loại sản phẩm đã có, thực hiện sửa
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
                // Kiểm tra xem người dùng đã chọn một loại sản phẩm trong DataGridView chưa
                if (!string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    // Tạo đối tượng LoaiSanPham để sửa
                    LoaiSanPham loaiSanPham = new LoaiSanPham
                    {
                        MaLoai = txt_maLoai.Text,
                        TenLoai = txt_tenLoai.Text,
                        MoTa = txt_moTa.Text,
                        HinhAnh = txt_duongDan.Text
                    };

                    // Gọi phương thức sửa LoaiSanPham từ BLL
                    _loaiSanPhamBLL.Update(loaiSanPham);

                    // Cập nhật lại danh sách trong DataGridView
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
                // Kiểm tra xem người dùng đã nhập mã loại sản phẩm chưa
                if (!string.IsNullOrEmpty(txt_maLoai.Text))
                {
                    // Lấy mã loại sản phẩm từ TextBox
                    string maLoai = txt_maLoai.Text;

                    // Gọi phương thức xóa LoaiSanPham từ BLL
                    _loaiSanPhamBLL.Delete(maLoai);

                    // Cập nhật lại danh sách trong DataGridView
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
                // Tạo đối tượng LoaiSanPham mới từ các giá trị trong TextBox
                LoaiSanPham loaiSanPham = new LoaiSanPham
                {
                    MaLoai = txt_maLoai.Text,
                    TenLoai = txt_tenLoai.Text,
                    MoTa = txt_moTa.Text,
                    HinhAnh = txt_duongDan.Text
                };

                // Gọi phương thức thêm LoaiSanPham từ BLL
                _loaiSanPhamBLL.Add(loaiSanPham);

                // Cập nhật lại danh sách trong DataGridView
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
                    // Gọi phương thức tìm kiếm từ BLL
                    List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.Search(tuKhoa);

                    // Cập nhật danh sách tìm được vào DataGridView
                    dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;

                    // Thiết lập AutoComplete cho TextBox
                    AutoCompleteStringCollection autoCompleteCollection = new AutoCompleteStringCollection();
                    foreach (var item in dsLoaiSanPham)
                    {
                        autoCompleteCollection.Add(item.TenLoai); // Thêm tên loại sản phẩm vào gợi ý
                    }

                    // Cấu hình AutoComplete cho txt_timKiem
                    txt_timKiem.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt_timKiem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt_timKiem.AutoCompleteCustomSource = autoCompleteCollection;

                    // Nếu không tìm thấy kết quả, hiển thị thông báo và xóa dữ liệu trong DataGridView
                    if (dsLoaiSanPham.Count == 0)
                    {
                        dgv_dsLoaiSanPham.DataSource = null;
                        MessageBox.Show("Không tìm thấy loại sản phẩm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Nếu không có từ khóa tìm kiếm, reset DataGridView và gợi ý
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
            // Sự kiện khi người dùng chọn một dòng trong DataGridView
            if (dgv_dsLoaiSanPham.SelectedRows.Count > 0)
            {
                var selectedRow = dgv_dsLoaiSanPham.SelectedRows[0];
                LoaiSanPham selectedLoaiSanPham = selectedRow.DataBoundItem as LoaiSanPham;

                if (selectedLoaiSanPham != null)
                {
                    txt_maLoai.Text = selectedLoaiSanPham.MaLoai;
                    txt_tenLoai.Text = selectedLoaiSanPham.TenLoai;
                    txt_moTa.Text = selectedLoaiSanPham.MoTa;

                    string imageName = selectedLoaiSanPham.HinhAnh; // Tên tài nguyên hình ảnh
                   LoadImageToPictureBox(imageName);
                }
            }
        }

        private void dgv_dsMauSac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (e.RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dgv_dsMauSac.Rows[e.RowIndex];

                // Gán dữ liệu từ các ô vào các TextBox
                txt_maMauSac.Text = row.Cells[0].Value?.ToString() ?? string.Empty; // Giả sử ô đầu tiên chứa mã màu
                txt_tenMauSac.Text = row.Cells[1].Value?.ToString() ?? string.Empty; // Giả sử ô thứ hai chứa tên màu
                txt_moTaMauSac.Text = row.Cells[2].Value?.ToString() ?? string.Empty; // Giả sử ô thứ ba chứa mô tả màu
                txt_duongDanMauSac.Text = row.Cells[3].Value?.ToString() ?? string.Empty; // Giả sử ô thứ tư chứa đường dẫn màu
            }
        }

        private void dgv_dsKichThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ các ô trong dòng đã chọn
                DataGridViewRow row = dgv_dsKichThuoc.Rows[e.RowIndex];

                // Gán dữ liệu từ các ô vào các TextBox
                txt_maKichThuoc.Text = row.Cells[0].Value.ToString();
                txt_tenKichThuoc.Text = row.Cells[1].Value.ToString();
                txt_moTaKichThuoc.Text = row.Cells[2].Value.ToString();
            }
        }

        private void dgv_dsMauSac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ (e.RowIndex >= 0)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng đã chọn
                DataGridViewRow row = dgv_dsMauSac.Rows[e.RowIndex];

                // Gán dữ liệu từ các ô vào các TextBox
                txt_maMauSac.Text = row.Cells[0].Value?.ToString() ?? string.Empty; // Giả sử ô đầu tiên chứa mã màu
                txt_tenMauSac.Text = row.Cells[1].Value?.ToString() ?? string.Empty; // Giả sử ô thứ hai chứa tên màu
                txt_moTaMauSac.Text = row.Cells[2].Value?.ToString() ?? string.Empty; // Giả sử ô thứ ba chứa mô tả màu
                txt_duongDanMauSac.Text = row.Cells[3].Value?.ToString() ?? string.Empty; // Giả sử ô thứ tư chứa đường dẫn màu
            }
        }

        private void dgv_dsKichThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu người dùng click vào một dòng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ các ô trong dòng đã chọn
                DataGridViewRow row = dgv_dsKichThuoc.Rows[e.RowIndex];

                // Gán dữ liệu từ các ô vào các TextBox
                txt_maKichThuoc.Text = row.Cells[0].Value.ToString();
                txt_tenKichThuoc.Text = row.Cells[1].Value.ToString();
                txt_moTaKichThuoc.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
