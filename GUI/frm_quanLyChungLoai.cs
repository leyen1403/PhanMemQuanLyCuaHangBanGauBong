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
            List<MauSac> dsMauSac = _mauSacBLL.GetAllMauSac();
            dgv_dsMauSac.DataSource = dsMauSac;

            // Đặt tên cho các cột trong dgv_dsMauSac
            dgv_dsMauSac.Columns[0].HeaderText = "Mã Màu"; // Cột 0 là MaMau
            dgv_dsMauSac.Columns[1].HeaderText = "Tên Màu"; // Cột 1 là TenMau
            dgv_dsMauSac.Columns[2].HeaderText = "Mô tả"; // Cột 1 là TenMau
            dgv_dsMauSac.Columns[3].HeaderText = "URL"; // Cột 1 là TenMau
            dgv_dsMauSac.Columns[2].Width = 400;

            // Dàn đều các cột
            dgv_dsMauSac.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Các cột sẽ tự động dàn đều theo chiều rộng của DataGridView
        }

        private void loadKichThuoc()
        {
            List<KichThuoc> dsKichThuoc = _kichThuocBLL.GetAll();
            dgv_dsKichThuoc.DataSource = dsKichThuoc;

            // Đặt tên cho các cột trong dgv_dsKichThuoc
            dgv_dsKichThuoc.Columns[0].HeaderText = "Mã Kích Thước";
            dgv_dsKichThuoc.Columns[1].HeaderText = "Tên Kích Thước";
            dgv_dsKichThuoc.Columns[2].HeaderText = "Mô tả";
            dgv_dsKichThuoc.Columns[2].Width = 380;

            // Dàn đều các cột
            dgv_dsKichThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadLoaiSanPham()
        {
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
        private void LoadImageToPictureBox(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    img_Loai.Image = Image.FromFile(imagePath);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hình ảnh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load hình ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frm_quanLyChungLoai_Load(object sender, EventArgs e)
        {
            loadMauSac();
            loadKichThuoc();
            loadLoaiSanPham();
            btn_timKiem.Click += Btn_timKiem_Click;
            btn_themLoaiSanPham.Click += Btn_themLoaiSanPham_Click;
            btn_xoaLoaiSanPham.Click += Btn_xoaLoaiSanPham_Click;
            btn_suaLoaiSanPham.Click += Btn_suaLoaiSanPham_Click;
            btn_luuLoaiSanPham.Click += Btn_luuLoaiSanPham_Click;
            btn_themHinhAnh.Click += Btn_themHinhAnh_Click;

        }

        private void Btn_themHinhAnh_Click(object sender, EventArgs e)
        {

            // Tạo đối tượng OpenFileDialog để chọn hình ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp;*.tiff"; // Định dạng hình ảnh
            openFileDialog.Title = "Chọn Hình Ảnh";

            // Mở hộp thoại chọn tệp
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên tệp từ đường dẫn
                string imagePath = openFileDialog.FileName;
                string imageName = Path.GetFileName(imagePath); // Lấy tên tệp từ đường dẫn

                // Cập nhật đường dẫn vào TextBox
                txt_duongDan.Text = imagePath; // Hiển thị đường dẫn vào TextBox

                // Hiển thị hình ảnh trong PictureBox
                img_Loai.Image = Image.FromFile(imagePath); // Tải hình ảnh vào PictureBox

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

                // Gọi phương thức tìm kiếm từ BLL
                List<LoaiSanPham> dsLoaiSanPham = _loaiSanPhamBLL.Search(tuKhoa);

                // Cập nhật danh sách tìm được vào DataGridView
                dgv_dsLoaiSanPham.DataSource = dsLoaiSanPham;

                if (dsLoaiSanPham.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy loại sản phẩm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                    string imageName = selectedLoaiSanPham.HinhAnh; // Tên tài nguyên hình ảnh
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        try
                        {
                            img_Loai.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading image: " + ex.Message);
                            img_Loai.Image = null; 
                        }
                    }
                    else
                    {
                        img_Loai.Image = null; 
                    }
                }
            }

        }
    }
}
