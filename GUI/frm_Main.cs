using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public frm_main()
        {
            InitializeComponent();
            this.Load += Frm_main1_Load;

        }

        private void Frm_main1_Load(object sender, EventArgs e)
        {
            pnMain.Height = this.ClientSize.Height;
            pnMain.Width = this.ClientSize.Width - pnLeft.Width;
            this.MaximizeBox = false;
            this.btn_NhanVien.Click += Btn_NhanVien_Click;
            this.btn_Kho.Click += Btn_Kho_Click;

        }

        private void Btn_Kho_Click(object sender, EventArgs e)
        {
           loadForm(new frm_quanLyKhoHang(),string.Empty);
        }

        private void Btn_NhanVien_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien(), string.Empty);
        }

        void loadForm(Form form, string titleLabel)
        {
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Height = pnMain.Height;
            form.Width = pnMain.Width;
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            // Thiết lập tiêu đề của form vào label
            //label_tenForm.Text = titleLabel;
            form.BringToFront();
            form.Show();

        }

        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon(), string.Empty);
        }

        private void btn_LapHoaDon_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon(), string.Empty);
        }

        private void pnLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_dangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnMain.BackgroundImage =Properties.Resources._01_1;
        }
    }
}
