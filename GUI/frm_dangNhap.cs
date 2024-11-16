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

namespace GUI
{
    public partial class frm_dangNhap : Form
    {
        DangNhapBLL dangNhapBLL = new DangNhapBLL();
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
            isValid();
            frm_main frm = new frm_main();
            frm.frmParent = this;

            if (isValid())
            {
                frm.Show();
                this.Hide();
            }
        }
        public void xoaTextBox()
        {
            txtMatKhau.Text = string.Empty;
            txtTenDangNhap.Text = string.Empty;
        }
        private bool isValid()
        {
            // Kiểm tra tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
            {
                lb_canhBaoTaiKhoan.Visible = true;
                lb_canhBaoTaiKhoan.Text = "Vui lòng nhập tài khoản!";
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
                    return true;
                }

            }
            return false;
        }
    }
}
