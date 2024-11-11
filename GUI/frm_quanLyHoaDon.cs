using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Collections.Generic;

namespace GUI
{
    public partial class frm_quanLyHoaDon : Form
    {
        private string maNhanVien = "NV001";
        HoaDonBanHangBLL _hoaDonBanHangBLL = new HoaDonBanHangBLL();
        ChiTietHoaDonBanHangBLL _chiTietHoaDonBanHangBLL = new ChiTietHoaDonBanHangBLL();
        public frm_quanLyHoaDon()
        {
            InitializeComponent();
            this.Load += Frm_quanLyHoaDon_Load;
        }

        private void Frm_quanLyHoaDon_Load(object sender, EventArgs e)
        {
            loadHoaDon();
            loadCTHD();
        }

        private void loadHoaDon()
        {
            List<HoaDonBanHang> dsHDBH = _hoaDonBanHangBLL.GetAllHoaDonBanHang();
            if(dsHDBH.Count > 0)
            {
                dgv_dsHoaDon.DataSource = dsHDBH;
            }    

        }
        private void loadCTHD()
        {
            List<ChiTietHoaDonBanHang> dsCTHDBH = _chiTietHoaDonBanHangBLL.GetAllChiTietHoaDonBanHang();
            if(dsCTHDBH.Count > 0)
            {
                dgv_dsCTHD.DataSource = dsCTHDBH;
            }    
        }
    }
}
