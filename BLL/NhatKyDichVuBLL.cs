using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhatKyDichVuBLL
    {
        NhatKyDichVuDAL nhatKyDichVuDal = new NhatKyDichVuDAL();

        public NhatKyDichVuBLL() { }

        // Lấy danh sách nhật ký dịch vụ
        public List<NhatKyDichVu> GetNhatKyDichVuList()
        {
            return nhatKyDichVuDal.GetNhatKyDichVuList();
        }
        public int GenerateLanDichVu(string maChiTietHoaDonBanHang)
        {
            // Lấy danh sách nhật ký dịch vụ hiện tại từ DAL
            var nhatKyList = nhatKyDichVuDal.GetNhatKyDichVuList()
                               .Where(nk => nk.MaChiTietHoaDonBanHang == maChiTietHoaDonBanHang)
                               .ToList();

            // Nếu có bản ghi trước đó với mã chi tiết hóa đơn này, tăng `LanDichVu` lên 1
            if (nhatKyList.Any())
            {
                return nhatKyList.Max(nk => nk.Landichvu) + 1;
            }
            else
            {
                // Nếu không có bản ghi nào, bắt đầu từ 1
                return 1;
            }
        }
        public int GetLatestLanDichVu(string maChiTietHoaDonBanHang)
        {
            var nhatKyList = nhatKyDichVuDal.GetNhatKyDichVuList();
            var maxLanDichVu = nhatKyList
                .Where(nk => nk.MaChiTietHoaDonBanHang == maChiTietHoaDonBanHang)
                .Max(nk => (int?)nk.Landichvu) ?? 0; // Sử dụng 0 nếu không tìm thấy

            return maxLanDichVu + 1;
        }

        // Lưu nhật ký dịch vụ
        public bool SaveNhatKyDichVu(NhatKyDichVu nhatKyDichVu, out string errorMessage)
        {
            string result = nhatKyDichVuDal.SaveNhatKyDichVu(nhatKyDichVu);
            if (result == "Success")
            {
                errorMessage = null;
                return true;
            }
            else
            {
                errorMessage = result;
                return false;
            }
        }
    }
}