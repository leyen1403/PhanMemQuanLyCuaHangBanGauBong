using BLL;
using DevExpress.XtraBars.Navigation;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frm_main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public NhanVien nhanVien { get; set; }
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
            loadForm(new frm_quanLyDonDatHang() { _maNhanVien = nhanVien.MaNhanVien});
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
            loadForm(new frm_lapPhieuKiemKe() { _maNhanVien = nhanVien.MaNhanVien });
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
            this.btn_HoaDon.Click += Btn_HoaDon_Click;
            this.btn_DichVu.Click += Btn_DichVu_Click;
            PhanQuyenAccordion(nhanVien.MaNhanVien);
            loadForm(new frm_lapHoaDon());

        }
        DangNhapBLL dangNhapBLL = new DangNhapBLL();
        private void PhanQuyenAccordion(string maNhanVien)
        {

            var danhSachQuyen = dangNhapBLL.LayDanhSachQuyen(maNhanVien);

            foreach (AccordionControlElement element in accordionControl1.Elements)
            {
                PhanQuyenElement(element, danhSachQuyen);
            }
        }
        private void PhanQuyenElement(AccordionControlElement element, List<string> danhSachQuyen)
        {
            if (element.Tag != null && danhSachQuyen.Contains(element.Tag.ToString()))
            {
                element.Visible = true;
            }
            else
            {
                //element.Visible = false;
            }

            foreach (AccordionControlElement childElement in element.Elements)
            {
                PhanQuyenElement(childElement, danhSachQuyen);
            }
        }
        private void Btn_DichVu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDichVu());
        }

        private void Btn_HoaDon_Click(object sender, EventArgs e)
        {
           loadForm(new frm_quanLyHoaDon());
        }

        private void Btn_LapPhieuDichVu_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuDichVu());
        }

        private void Btn_LapDonDatHang_Click(object sender, EventArgs e)
        {
           loadForm(new frm_lapDonDatHang() { MaNhanVien = nhanVien.MaNhanVien});
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
            // Kiểm tra nếu pnMain đã có một form con nào khác đang mở thì đóng nó
            if (pnMain.Controls.Count > 0)
            {
                var existingForm = pnMain.Controls[0] as Form;
                existingForm?.Close();
                pnMain.Controls.Clear();
            }

            // Thiết lập form mới
            this.Text = form.Text;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
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

       
        private void btn_dangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnMain.BackgroundImage =Properties.Resources._01_1;
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyKhachHang());
        }

        private void btn_NhaCC_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyNhaCungCap());
        }

        private void btn_LapPhieuDoiTra_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuDoiTra());
        }

        private void btn_DoiTra_Click(object sender, EventArgs e)
        {
            loadForm(new frm_quanLyDoiTraSanPham());
        }
        public frm_dangNhap frmParent;
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                frmParent.xoaTextBox();
                frmParent.Show();
                this.Close();
            }
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmParent.xoaTextBox();
            frmParent.Show();
            this.Close();
        }

        private void btn_HoanTra_Click(object sender, EventArgs e)
        {
            loadForm(new frm_QuanLyPhieuHoanTra());
        }
<<<<<<< Updated upstream
=======

        private void btn_Khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
            frm_dangNhap frm = new frm_dangNhap();
            frm.Show();
        }
        private void btn_phieuHoanTra_Click(object sender, EventArgs e)
        {
            loadForm(new frm_lapPhieuHoanTra());
        }
>>>>>>> Stashed changes
    }
}
