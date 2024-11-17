using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class frm_dangNhap : Form
    {
        DangNhapBLL dangNhapBLL = new DangNhapBLL();
        NhanVien nv = new NhanVien();
        public frm_dangNhap()
        {
            InitializeComponent();
            lb_canhBaoTaiKhoan.Visible = false;
            lb_canhBaoMatKhau.Visible = false;
            txtMatKhau.PasswordChar = '•';
        }

        private void frm_dangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btn_dangNhap_Click(object sender, EventArgs e)
        {
            int result = isValid();
            frm_main frm = new frm_main();
            frm.frmParent = this;
            if (result == -1) return;
            else if (isValid() == 1)
            {
                frm.Show();
                frm.nhanVien = nv;
                this.Hide();
                return;
            }
            else
                MessageBox.Show("Đăng nhập thất bại, tài khoản hoặc mật khẩu chưa chính xác");
        }
        public void xoaTextBox()
        {
            txtMatKhau.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
        }
        private int isValid()
        {
            int status = 0;
            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                lb_canhBaoTaiKhoan.Visible = true;
                lb_canhBaoTaiKhoan.Text = "Vui lòng nhập tài khoản!";
                status = -1;
            }
            else
            {
                lb_canhBaoTaiKhoan.Visible = false;
            }

            // Kiểm tra mật khẩu
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                lb_canhBaoMatKhau.Visible = true;
                lb_canhBaoMatKhau.Text = "Vui lòng nhập mật khẩu!";
                status = -1;
                return status;
            }
            else
            {
                lb_canhBaoMatKhau.Visible = false;
            }

            // Nếu cả hai đều hợp lệ
            if (!lb_canhBaoTaiKhoan.Visible && !lb_canhBaoMatKhau.Visible)
            {
                var nhanVien = dangNhapBLL.kiemTraDangNhap(txtTenDangNhap.Text, txtMatKhau.Text);
                if (nhanVien != null)
                {
                    nv = nhanVien;
                    return 1;
                }
            }
            return 0;
        }
    }
}
