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
            var list = GetPhieuDichVuList(); 
            var lastMaPhieu = list.OrderByDescending(p => p.MaPhieuDichVu).FirstOrDefault()?.MaPhieuDichVu;

            if (lastMaPhieu != null && lastMaPhieu.StartsWith("PDV"))
            {
                int lastNumber = int.Parse(lastMaPhieu.Substring(3)); 
                return "PDV" + (lastNumber + 1).ToString("D3"); 
            }
            return "PDV001"; 
        }


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
        public bool UpdatePhieuDichVu(PhieuDichVu phieuDichVu, out string errorMessage)
        {
            string result = phieuDichVuDal.UpdatePhieuDichVu(phieuDichVu);
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
