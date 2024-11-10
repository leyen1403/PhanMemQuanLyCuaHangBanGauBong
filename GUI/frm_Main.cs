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
            this.btn_LapPhieuKiemKe.Click += Btn_LapPhieuKiemKe_Click;
            this.btn_NhanVien.Click += Btn_NhanVien_Click1;
            this.btnQuanLyPhieuKiemKe.Click += BtnQuanLyPhieuKiemKe_Click;
            this.btn_DonDatHang.Click += Btn_DonDatHang_Click;
        }

        private void Btn_DonDatHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDonDatHang());
        }

        private void BtnQuanLyPhieuKiemKe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyPhieuKiemKe());
        }

        private void Btn_NhanVien_Click1(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien());
        }

        private void Btn_LapPhieuKiemKe_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuKiemKe());
        }

        private void Frm_main1_Load(object sender, EventArgs e)
        {
            pnMain.Height = this.ClientSize.Height;
            pnMain.Width = this.ClientSize.Width - pnLeft.Width;
            this.MaximizeBox = false;
            this.btn_NhanVien.Click += Btn_NhanVien_Click;
            this.btn_Kho.Click += Btn_Kho_Click;
            this.btn_Loai.Click += Btn_Loai_Click;
            this.btn_LapDonDatHang.Click += Btn_LapDonDatHang_Click;
            this.btn_LapPhieuDichVu.Click += Btn_LapPhieuDichVu_Click;

            loadForm(new frm_quanLyDonDatHang());

        }

        private void Btn_LapPhieuDichVu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuDichVu());
        }

        private void Btn_LapDonDatHang_Click(object sender, EventArgs e)
        {
           loadForm(new frm_lapDonDatHang());
        }

        private void Btn_Loai_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyChungLoai());
        }

        private void Btn_Kho_Click(object sender, EventArgs e)
        {
           loadForm(new frm_quanLyKhoHang());
        }

        private void Btn_NhanVien_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhanVien());
        }

        void loadForm(Form form)
        {
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Height = pnMain.Height;
            form.Width = pnMain.Width;
            pnMain.Controls.Add(form);
            pnMain.Tag = form;
            form.BringToFront();
            form.Show();

        }

        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon());
        }

        private void btn_LapHoaDon_Click_1(object sender, EventArgs e)
        {
            loadForm(new frm_lapHoaDon());
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
