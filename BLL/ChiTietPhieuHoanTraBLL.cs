using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietPhieuHoanTraBLL
    {
        private ChiTietPhieuHoanTraDAL _chiTietPhieuHoanTraDAL;

        public ChiTietPhieuHoanTraBLL()
        {
            _chiTietPhieuHoanTraDAL = new ChiTietPhieuHoanTraDAL();
        }

        // Lấy chi tiết phiếu hoàn trả theo mã phiếu hoàn trả
        public List<ChiTietPhieuHoanTra> GetChiTietPhieuHoanTra(string maPhieuHoanTra)
        {
            return _chiTietPhieuHoanTraDAL.GetChiTietPhieuHoanTra(maPhieuHoanTra);
        }

        // Thêm chi tiết phiếu hoàn trả
        public void AddChiTietPhieuHoanTra(ChiTietPhieuHoanTra chiTietPhieuHoanTra)
        {
            _chiTietPhieuHoanTraDAL.AddChiTietPhieuHoanTra(chiTietPhieuHoanTra);
        }

        // Cập nhật chi tiết phiếu hoàn trả
        public void UpdateChiTietPhieuHoanTra(ChiTietPhieuHoanTra chiTietPhieuHoanTra)
        {
            _chiTietPhieuHoanTraDAL.UpdateChiTietPhieuHoanTra(chiTietPhieuHoanTra);
        }

        // Xóa chi tiết phiếu hoàn trả
        public void DeleteChiTietPhieuHoanTra(string maPhieuHoanTra, string maChiTietPhieuNhap)
        {
            _chiTietPhieuHoanTraDAL.DeleteChiTietPhieuHoanTra(maPhieuHoanTra, maChiTietPhieuNhap);
        }
    }
}
