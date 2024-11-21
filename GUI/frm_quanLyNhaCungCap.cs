using BLL;
using DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_quanLyNhaCungCap : Form
    {
        NhaCungCapBLL NhaCungCapBLL = new NhaCungCapBLL();
        public frm_quanLyNhaCungCap()
        {
            InitializeComponent();
        }

        private void frm_quanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }
        private void LoadNCC()
        {
            var lst_ncc = NhaCungCapBLL.LayDanhSachNhaCungCap();
            lbl_NgayCapNhap.Font = new System.Drawing.Font("Arial", 10.2f);
            lbl_NgayTao.Font = new System.Drawing.Font("Arial", 10.2f);

            dgv_NhaCC.DataSource = lst_ncc;
        }
        private void dgv_NhaCC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_NhaCC.Columns[e.ColumnIndex].Name == "TrangThai") // Thay "ColumnBool" bằng tên cột của bạn
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
        }

        private void button4_Click(object sender, EventArgs e)
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
            foreach (DataGridViewRow row in dgv_NhaCC.Rows)
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
        }

        private void btn_TaiLai_Click(object sender, EventArgs e)
        {
            dgv_NhaCC.ClearSelection();
            txt_DiaChi.Clear();
            txt_Email.Clear();
            txt_NguoiDaiDien.Clear();
            txt_SoDienThoai.Clear();
            txt_TenNhaCungCap.Clear();
            lbl_MaNCC.Text = string.Empty;
            lbl_NgayCapNhap.Text = string.Empty;
            lbl_NgayTao.Text = string.Empty;
        }

        private void dgv_NhaCC_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_NhaCC.SelectedRows.Count > 0)
            {
                // Lấy thông tin khách hàng từ dòng đã chọn
                var row = dgv_NhaCC.SelectedRows[0];
                var NhaCC = row.DataBoundItem as NhaCungCap;

                if (NhaCC != null)
                {
                   lbl_MaNCC.Text = NhaCC.MaNhaCungCap;
                    txt_TenNhaCungCap.Text = NhaCC.TenNhaCungCap;
                    txt_Email.Text = NhaCC.Email;
                    txt_DiaChi.Text = NhaCC.DiaChi;
                    txt_NguoiDaiDien.Text = NhaCC?.NguoiDaiDien;
                    txt_SoDienThoai.Text = NhaCC.SoDienThoai;
                    lbl_NgayCapNhap.Text = NhaCC.NgayCapNhat.HasValue ? NhaCC.NgayCapNhat.Value.ToString("dd-MM-yyyy") : "";
                    lbl_NgayTao.Text = NhaCC.NgayTao.HasValue? NhaCC.NgayTao.Value.ToString("dd-MM-yyyy") :"";
                    if (NhaCC.TrangThai == true)
                    {
                        cb_HoatDong.Checked = true;
                    }
                    else
                    {
                        cb_HoatDong.Checked= false;
                    }
                }
            }
        }
        // Thêm nhà cung cấp
        private void button1_Click(object sender, EventArgs e)
        {
            string TenNCC = txt_TenNhaCungCap.Text;
            string SoDienThoai = txt_SoDienThoai.Text;
            string NguoiDaiDien = txt_NguoiDaiDien.Text;
            string Email = txt_Email.Text;
           
            if(TenNCC.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SoDienThoai.Length == 0) {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
              
                    if (NhaCungCapBLL.isPhoneExits(SoDienThoai))
                    {
                        MessageBox.Show("Số điện thoại đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
               
            }
            if (NguoiDaiDien.Length == 0) {
                MessageBox.Show("Vui lòng nhập người đại diện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Email.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
               
                    if (NhaCungCapBLL.isEmailExits(Email))
                    {
                        MessageBox.Show("Email đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                
            }
            NhaCungCap newNCC = new NhaCungCap();
            newNCC.Email = Email;
            newNCC.DiaChi = txt_DiaChi.Text;
            newNCC.SoDienThoai = SoDienThoai;
            newNCC.TenNhaCungCap = TenNCC;
            newNCC.NgayTao = DateTime.Now;
            newNCC.NgayCapNhat = DateTime.Now;  
            newNCC.TrangThai = true;
            string result = NhaCungCapBLL.ThemNhaCungCap(newNCC);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNCC();
        }
        // Sửa nhà cung cấp
        private void button3_Click(object sender, EventArgs e)
        {
            if (dgv_NhaCC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string TenNCC = txt_TenNhaCungCap.Text;
            string SoDienThoai = txt_SoDienThoai.Text;
            string NguoiDaiDien = txt_NguoiDaiDien.Text;
            string Email = txt_Email.Text;

            if (TenNCC.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (SoDienThoai.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else
            {
                 if (isNewPhone())
                    {
                    if (NhaCungCapBLL.isPhoneExits(SoDienThoai))
                {
                    MessageBox.Show("Số điện thoại đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    }
                    }
            if (NguoiDaiDien.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập người đại diện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Email.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập Email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (isNewEmail())
                {
                    if (NhaCungCapBLL.isEmailExits(Email))
                    {
                        MessageBox.Show("Email đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            NhaCungCap newNCC = new NhaCungCap();
            string MaNCC = lbl_MaNCC.Text;
            newNCC.Email = Email;
            newNCC.DiaChi = txt_DiaChi.Text;
            newNCC.SoDienThoai = SoDienThoai;
            newNCC.TenNhaCungCap = TenNCC;
            newNCC.NgayTao = DateTime.Now;
            newNCC.NgayCapNhat = DateTime.Now;
            newNCC.TrangThai = true;
            newNCC.NguoiDaiDien = txt_NguoiDaiDien.Text;
            string result = NhaCungCapBLL.SuaNhaCungCap(MaNCC,newNCC);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNCC();
        }

        private bool isNewEmail()
        {
            if (dgv_NhaCC.SelectedRows.Count == 0)
            {
                return false;
            }

            var row = dgv_NhaCC.SelectedRows[0];
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
            var row = dgv_NhaCC.SelectedRows[0];
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv_NhaCC.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var row = dgv_NhaCC.SelectedRows[0];
            string makh = row.Cells["MaNhaCungCap"].Value.ToString();
            string result = NhaCungCapBLL.XoaNhaCungCap(makh);
            MessageBox.Show(result, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNCC();
            
        }
    }
}
