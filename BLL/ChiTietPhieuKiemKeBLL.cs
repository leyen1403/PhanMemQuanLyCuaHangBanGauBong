using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ChiTietPhieuKiemKeBLL
    {
        public ChiTietPhieuKiemKeBLL() { }
        ChiTietPhieuKiemKeDAL chiTietPhieuKiemKeDAL = new ChiTietPhieuKiemKeDAL();
        public bool InsertChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().InsertChiTietPhieuKiemKe(chiTietPhieuKiemKe);
        }
        public List<ChiTietPhieuKiemKe> chiTietPhieuKiemKes(string maPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().chiTietPhieuKiemKes(maPhieuKiemKe);
        }
        public bool UpdateChiTietPhieuKiemKe(ChiTietPhieuKiemKe chiTietPhieuKiemKe)
        {
            return new DAL.ChiTietPhieuKiemKeDAL().UpdateChiTietPhieuKiemKe(chiTietPhieuKiemKe);
        }

        public List<ChiTietPhieuKiemKe> LayDanhSachChiTietPhieuKiemKe()
        {
            return chiTietPhieuKiemKeDAL.LayDanhSachChiTietPhieuKiemKe();
        }

        public List<ChiTietPhieuKiemKe> GetListChiTietPhieuKiemKeByMaPhieuKiemKe(string maPhieuKiemKe)
        {
            return chiTietPhieuKiemKeDAL.chiTietPhieuKiemKes(maPhieuKiemKe);
        }

        public bool Xoa(string maPhieuKiemKe)
        {
            return chiTietPhieuKiemKeDAL.XoaDanhSach(maPhieuKiemKe);
        }
    }
}
