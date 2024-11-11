using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class PhieuDichVuBLL
    {
        PhieuDichVuDAL phieuDichVuDal = new PhieuDichVuDAL();

        public PhieuDichVuBLL() { }

        // Lấy danh sách phiếu dịch vụ
        public List<PhieuDichVu> GetPhieuDichVuList()
        {
            return phieuDichVuDal.GetPhieuDichVuList();
        }

        // Lấy phiếu dịch vụ theo mã
        public PhieuDichVu GetPhieuDichVuById(string id)
        {
            return phieuDichVuDal.GetPhieuDichVuById(id);
        }
        public string GetLatestMaPhieuDichVu()
        {
            var list = GetPhieuDichVuList(); // Giả sử phương thức này trả về danh sách tất cả phiếu dịch vụ
            var lastMaPhieu = list.OrderByDescending(p => p.MaPhieuDichVu).FirstOrDefault()?.MaPhieuDichVu;

            if (lastMaPhieu != null && lastMaPhieu.StartsWith("PDV"))
            {
                int lastNumber = int.Parse(lastMaPhieu.Substring(3)); // Lấy phần số từ mã cuối cùng
                return "PDV" + (lastNumber + 1).ToString("D3"); // Tăng số và định dạng lại với 3 chữ số
            }
            return "PDV001"; // Trả về mã đầu tiên nếu chưa có mã nào trong DB
        }


        // Lưu phiếu dịch vụ vào cơ sở dữ liệu
        public bool SavePhieuDichVu(PhieuDichVu phieuDichVu, out string errorMessage)
        {
            string result = phieuDichVuDal.SavePhieuDichVu(phieuDichVu);
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
