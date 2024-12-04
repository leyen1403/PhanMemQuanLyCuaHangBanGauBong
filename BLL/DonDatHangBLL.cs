using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DonDatHangBLL
    {
        public DonDatHangBLL()
        {
        }
        DonDatHangDAL ddhDAL = new DonDatHangDAL();
        public List<DonDatHang> LayDanhSachDonDatHang()
        {
            return ddhDAL.LayDanhSachDonDatHang();
        }
        public List<DonDatHang> LayDanhSachDonDatHang2()
        {
            return ddhDAL.LayDanhSachDonDatHang2();
        }
        public bool ThemDonDatHang(DonDatHang ddh)
        {
            return ddhDAL.ThemDonDatHang(ddh);
        }

        public DonDatHang LayDonDayHang(string maDonDatHang)
        {
            return ddhDAL.LayDonDatHang(maDonDatHang);
        }

        public bool CapNhatDonDatHang(DonDatHang ddh)
        {
            return ddhDAL.CapNhatDonDatHang(ddh);
        }

        public bool XoaDonDatHang(string maDonDatHang)
        {
            return ddhDAL.XoaDonDatHang(maDonDatHang);
        }

        public string LayMaDonDatHangCuoiCung()
        {
            var lastOrder = LayDanhSachDonDatHang2().LastOrDefault();
            if (lastOrder != null)
            {
                return lastOrder.MaDonDatHang;
            }
            return null; // or handle the case where there is no last order
        }

        public bool LuuDonDatHangVoiDanhSachChiTietDonDatHang(DonDatHang donDatHang, List<ChiTietDonDatHang> lstChiTietDonDatHang)
        {
            // Tạo đơn đặt hàng
            if (ThemDonDatHang(donDatHang))
            {
                // Lấy mã đơn đặt hàng cuối cùng
                string maDonDatHang = LayMaDonDatHangCuoiCung();

                // Lưu danh sách chi tiết đơn đặt hàng
                ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();
                foreach (ChiTietDonDatHang chiTietDonDatHang in lstChiTietDonDatHang)
                {
                    chiTietDonDatHang.MaDonDatHang = maDonDatHang;
                    if (!chiTietDonDatHangBLL.ThemChiTietDonDatHang(chiTietDonDatHang))
                    {
                        // Nếu một chi tiết đơn đặt hàng không thể thêm, trả về false
                        return false;
                    }
                }
                // Nếu tất cả chi tiết đơn đặt hàng được lưu thành công
                return true;
            }
            else
            {
                // Nếu không thể thêm đơn đặt hàng, trả về false
                return false;
            }
        }

        public bool CapNhatChiTietDonDatHangDuaTrenDDHVaDSCTDDH(DonDatHang ddhTemp, List<ChiTietDonDatHang> lstTemp)
        {
            // Cập nhật thông tin đơn đặt hàng
            if (!CapNhatDonDatHang(ddhTemp))
            {
                // Nếu cập nhật đơn đặt hàng thất bại, trả về false
                return false;
            }

            // Cập nhật chi tiết đơn đặt hàng
            ChiTietDonDatHangBLL chiTietDonDatHangBLL = new ChiTietDonDatHangBLL();

            foreach (ChiTietDonDatHang ctddh in lstTemp)
            {
                // Cập nhật chi tiết đơn đặt hàng
                if (!chiTietDonDatHangBLL.CapNhatChiTietDonDatHang(ctddh))
                {
                    // Nếu có chi tiết không cập nhật được, trả về false
                    return false;
                }
            }

            // Nếu tất cả các chi tiết được cập nhật thành công, trả về true
            return true;
        }

    }
}
