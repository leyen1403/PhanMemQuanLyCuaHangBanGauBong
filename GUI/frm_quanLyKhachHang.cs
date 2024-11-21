using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class frm_quanLyKhachHang : Form
    {
        KhachHangBLL bll = new KhachHangBLL();
        db_QLCHBGBDataContext context = new db_QLCHBGBDataContext();
        public frm_quanLyKhachHang()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frm_quanLyKhachHang_Load(object sender, EventArgs e)
        {
      
            lbl_NgayTaoValue.Text = DateTime.Now.ToString();    
            lbl_NgayCapNhatValue.Text = DateTime.Now.ToString();
            loadKhachHang();
            // Dòng này sẽ bỏ chọn tất cả các dòng trong DataGridView
            dgv_dsKhachHang.ClearSelection();

        }

        private void dgv_dsKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_dsKhachHang.SelectedRows.Count > 0)
            {
                // Lấy thông tin khách hàng từ dòng đã chọn
                var row = dgv_dsKhachHang.SelectedRows[0];
                var khachHang = row.DataBoundItem as KhachHang;

                if (khachHang != null)
                {
                    // Hiển thị thông tin chi tiết (ví dụ: trong các TextBox hoặc Label)
                    txt_MaKH.Text = khachHang.MaKhachHang;
                    txt_TenKH.Text = khachHang.TenKhachHang;
                    dtp_NgaySinh.Text = khachHang.NgaySinh.ToString();
                    txt_TaiKhoan.Text = khachHang.TaiKhoan;
                    txt_MatKhau.Text = khachHang.MatKhau;
                    lbl_NgayCapNhatValue.Text = khachHang.NgayCapNhat.ToString();
                    lbl_NgayTaoValue.Text = khachHang.NgayTao.ToString();
                    lbl_DiemTichLuyValue.Text = khachHang.DiemTichLuy.ToString();
                    pb_img.ImageLocation = khachHang.HinhAnh;
                    txt_DiaChi.Text = khachHang.DiaChi;
                    txt_Email.Text = khachHang.Email;
                    txt_SoDienThoai.Text = khachHang.SoDienThoai;
                    if(khachHang.TrangThai == true)
                    {
                        cb_Khoa.Checked = true;
                    }
                    else
                    {
                        cb_Khoa.Checked = false;
                    }
                    if(khachHang.GioiTinh == "Nam")
                    {
                        cb_GioiTinh.Checked = true;
                    }
                    else
                    {
                        cb_GioiTinh.Checked = false;
                    }
                    if(khachHang.ThanhVien == true)
                    {
                        cb_DangKy.Checked = true;
                    }
                    else
                    {
                        cb_DangKy.Checked = false;
                    }
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra số điện thoại
                if (txt_SoDienThoai.Text.Length == 0)
                {
                    
                    MessageBox.Show("Vui lòng nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (bll.isPhoneExits(txt_SoDienThoai.Text))
                    {
                        MessageBox.Show("Số điện thoại đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
                // Kiểm tra tên khách hàng
                if (txt_TenKH.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng tên khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Kiểm tra mật khẩu
                if (txt_MatKhau.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txt_Email.Text.Length > 0) {
                    if (bll.isEmailExits(txt_Email.Text))
                    {
                        MessageBox.Show("Email đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                // gán giá trị
                KhachHang kh = new KhachHang();
              
                kh.TenKhachHang = txt_TenKH.Text;
                kh.SoDienThoai = txt_SoDienThoai.Text;
                kh.Email = txt_Email.Text ?? null;
                kh.NgaySinh = dtp_NgaySinh.Value;
                if (cb_GioiTinh.Checked == true)
                {
                    kh.GioiTinh = "Nam";
                }
                else
                {
                    kh.GioiTinh = "Nữ";
                }
                kh.TaiKhoan =txt_SoDienThoai.Text;
                kh.MatKhau = txt_MatKhau.Text;
                
                    kh.TrangThai = true;
               
                if (cb_DangKy.Checked == true)
                {
                    kh.ThanhVien = true;
                }
                else
                {
                    kh.ThanhVien = false;
                }
                kh.DiemTichLuy = 0;
                kh.NgayTao = DateTime.Now;
                kh.NgayCapNhat = DateTime.Now;
                kh.HinhAnh = img_url;
                kh.DiaChi = txt_DiaChi.Text ?? null;
                bll.CreateKhachHang(kh);
                upload_img(kh.MaKhachHang);
                // Loại lại table
                loadKhachHang();
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public void loadKhachHang()
        {
            var lst_kh = bll.GetAllKhachHangs();
        
            dgv_dsKhachHang.DataSource = lst_kh;
            dgv_dsKhachHang.Refresh();
            dgv_dsKhachHang.ClearSelection();
        }
        string img_url = "";
        private void btn_ChonHinhAnh_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng OpenFileDialog
            OpenFileDialog fileDialog = new OpenFileDialog();

            // Thiết lập bộ lọc và tiêu đề cho hộp thoại
            fileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            fileDialog.Title = "Chọn hình ảnh";

            // Hiển thị hộp thoại và kiểm tra nếu người dùng chọn tệp
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của tệp hình ảnh đã chọn
                // Hiển thị ảnh cho người dùng xem
                string selectedFilePath = fileDialog.FileName;
                pb_img.ImageLocation = selectedFilePath;



                // Lưu lại đường dẫn
                string fileName = Path.GetFileName(selectedFilePath);  // Lấy tên tệp từ đường dẫn

                // Đường dẫn đến thư mục đích nơi bạn muốn sao chép file
                string targetDirectory = @"D:\HK7\CNPM\PhanMemQuanLyCuaHangBanGauBong\GUI\Resources";
                string targetFilePath = Path.Combine(targetDirectory, fileName);  // Tạo đường dẫn đích
                img_url = selectedFilePath;
                
            }
        }
        private void upload_img(string makh)
        {
            if (img_url.Equals(""))
            {
                return;
            }
            string targetDirectory = @"D:\HK7\CNPM\PhanMemQuanLyCuaHangBanGauBong\GUI\Resources";
            try
            {
                // Kiểm tra xem thư mục đích có tồn tại không, nếu không thì tạo mới
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                 string fileExtension = Path.GetExtension(img_url);
                targetDirectory = Path.Combine(targetDirectory, makh + fileExtension);

                // Sao chép file vào thư mục đích
                File.Copy(img_url,targetDirectory , true);  // true để ghi đè nếu file đã tồn tại

                // Thông báo người dùng đã sao chép thành công
               

                // Gán đường dẫn của file vào PictureBox để hiển thị ảnh
                // Hiển thị hình ảnh trong PictureBox
            }
            catch (Exception ex)
            {
                // Nếu có lỗi xảy ra trong quá trình sao chép, thông báo lỗi cho người dùng
                MessageBox.Show("Lỗi khi sao chép tệp: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgv_dsKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var row = dgv_dsKhachHang.SelectedRows[0];
            string makh = row.Cells["MaKhachHang"].Value.ToString();
            string result = bll.deleteKhachHang(makh);
            MessageBox.Show(result,"Thông báo" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadKhachHang();
        }
        
        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            if (dgv_dsKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_Email.Text.Length > 0)
            {
                if (isNewEmail())
                {
                    if (bll.isEmailExits(txt_Email.Text))
                    {
                        MessageBox.Show("Email đã tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return ;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Kiểm tra số điện thoại
            if (txt_SoDienThoai.Text.Length == 0)
            {

                MessageBox.Show("Vui lòng nhập số điện thoại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (isNewPhone())
                {
                    if (bll.isPhoneExits(txt_SoDienThoai.Text))
                    {
                        MessageBox.Show("Số điện thoại đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            // Kiểm tra tên khách hàng
            if (txt_TenKH.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng tên khách hàng ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            // Kiểm tra mật khẩu
            if (txt_MatKhau.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // gán giá trị
            KhachHang kh = new KhachHang();
            kh.MaKhachHang = txt_MaKH.Text;
            kh.TenKhachHang = txt_TenKH.Text;
            kh.SoDienThoai = txt_SoDienThoai.Text;
            kh.Email = txt_Email.Text ?? null;
            kh.NgaySinh = dtp_NgaySinh.Value;
            if (cb_GioiTinh.Checked == true)
            {
                kh.GioiTinh = "Nam";
            }
            else
            {
                kh.GioiTinh = "Nữ";
            }
            kh.TaiKhoan = txt_SoDienThoai.Text;
            kh.MatKhau = txt_MatKhau.Text;
            if (cb_Khoa.Checked == true)
            {
                kh.TrangThai = true;
            }
            else
            {
                kh.TrangThai = false;
            }
            if (cb_DangKy.Checked == true)
            {
                kh.ThanhVien = true;
            }
            else
            {
                kh.ThanhVien = false;
            }
       
            kh.NgayCapNhat = DateTime.Now;
            kh.HinhAnh = img_url;
            kh.DiaChi = txt_DiaChi.Text ?? null;
            bll.updateKhachHang(kh);
            loadKhachHang() ;
            upload_img(kh.MaKhachHang);
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

      
        public void loadDataCheckBox()
        {
            
           
        }
        private void dgv_dsKhachHang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_dsKhachHang.Columns[e.ColumnIndex].Name == "TrangThai") // Thay "ColumnBool" bằng tên cột của bạn
            {
                if (e.Value != null)
                {
                    // Kiểm tra nếu giá trị là true hoặc false, thay đổi hiển thị thành "Đúng" hoặc "Sai"
                    if ((bool)e.Value)
                    {
                        e.Value = "Hoạt động"; // Hiển thị "Đúng" nếu giá trị là true
                    }
                    else
                    {
                        e.Value = "Ngừng hoạt động"; // Hiển thị "Sai" nếu giá trị là false
                    }
                }
            }
            if (dgv_dsKhachHang.Columns[e.ColumnIndex].Name == "ThanhVien") // Thay "ColumnBool" bằng tên cột của bạn
            {
                if (e.Value != null)
                {
                    // Kiểm tra nếu giá trị là true hoặc false, thay đổi hiển thị thành "Đúng" hoặc "Sai"
                    if ((bool)e.Value)
                    {
                        e.Value = "Đã đăng ký"; // Hiển thị "Đúng" nếu giá trị là true
                    }
                    else
                    {
                        e.Value = "Chưa đăng ký"; // Hiển thị "Sai" nếu giá trị là false
                    }
                }
            }
        }
        private bool isNewEmail()
        {
            if (dgv_dsKhachHang.SelectedRows.Count == 0)
            {
                return false;
            }

            var row = dgv_dsKhachHang.SelectedRows[0];
            var cell = row.Cells["Email"];

            if (cell == null || cell.Value == null)
            {
                return false;
            }

            string email = cell.Value?.ToString();
            return !email.Equals(txt_Email.Text);
        }
        private bool isNewPhone()
        {
            var row = dgv_dsKhachHang.SelectedRows[0];
            string email = row.Cells["SoDienThoai"].Value.ToString();
            if (email.Equals(txt_SoDienThoai.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_TaiLai_Click(object sender, EventArgs e)
        {
            txt_TenKH.Clear();
            txt_SoDienThoai.Clear();
            txt_Email.Clear();
            txt_DiaChi.Clear();
            txt_TaiKhoan.Clear();
            txt_DiaChi.Clear();
            txt_DiaChi.Clear();
            txt_MaKH.Clear();
            txt_MatKhau.Clear();
            lbl_DiemTichLuyValue.Text = DateTime.Now.ToString();
            lbl_NgayCapNhatValue.Text = DateTime.Now.ToString();

            loadKhachHang();
            

        }

        private void btn_Timkiem_Click(object sender, EventArgs e)
        {
            // Lấy giá trị tìm kiếm từ TextBox
            string searchValue = txt_SoDienThoai.Text.Trim().ToLower();

            // Kiểm tra nếu người dùng không nhập gì
            if (string.IsNullOrEmpty(searchValue))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool found = false;

            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dgv_dsKhachHang.Rows)
            {
                // Lấy giá trị trong cột muốn tìm kiếm, giả sử bạn muốn tìm kiếm theo tên khách hàng
                string cellValue = row.Cells["SoDienThoai"].Value?.ToString().ToLower();

                // Nếu giá trị trong cột này trùng với từ khóa tìm kiếm, chọn dòng đó
                if (cellValue != null && cellValue.Contains(searchValue))
                {
                    // Chọn dòng và làm nổi bật nó
                    row.Selected = true;
                    found = true;
                    return;
                }
                else
                {
                    // Nếu không trùng, bỏ chọn dòng
                    row.Selected = false;
                }
            }

            // Nếu không tìm thấy kết quả
            if (!found)
            {
                MessageBox.Show("Không tìm thấy kết quả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
