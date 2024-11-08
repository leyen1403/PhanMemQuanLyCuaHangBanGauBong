using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Collections.Generic;

namespace GUI
{
    public partial class frm_quanLyKhoHang : Form
    {
        SanPhamBLL _sanPhamBLL = new SanPhamBLL();
        public frm_quanLyKhoHang()
        {
            InitializeComponent();
            loadSanPham();
            this.Load += Frm_quanLyKhoHang_Load;
        }

        private void loadSanPham()
        {
            dgv_dsSanPham.DataSource = null;
            try
            {
                List<SanPham> dsSanPham = new List<SanPham>();
                if (dsSanPham != null)
                {
                    dgv_dsSanPham.DataSource= dsSanPham;
                }
                else
                {
                    MessageBox.Show("không tìm thấy sản phẩm nào");
                }
            }
            catch {
                MessageBox.Show("không tìm thấy sản phẩm nào");
            }
        }

        private void Frm_quanLyKhoHang_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
