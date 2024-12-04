using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PhieuKiemKeBLL
    {
        PhieuKiemKeDAL phieuKiemKeDAL = new PhieuKiemKeDAL();
        public PhieuKiemKeBLL() { }
        public List<PhieuKiemKe> GetListPhieuKiemKe()
        {
            return phieuKiemKeDAL.GetListPhieuKiemKe();
        }
        public bool InsertPhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            return phieuKiemKeDAL.InsertPhieuKiemKe(phieuKiemKe);
        }
        public bool UpdatePhieuKiemKe(PhieuKiemKe phieuKiemKe)
        {
            return phieuKiemKeDAL.UpdatePhieuKiemKe(phieuKiemKe);
        }
        public PhieuKiemKe GetPhieuKiemKeById(string id)
        {
            return phieuKiemKeDAL.GetPhieuKiemKeById(id);
        }

        public bool UpdateGhiChu(string maPhieuKiemKe, string ghiChu)
        {
            return phieuKiemKeDAL.UpdateGhiChu(maPhieuKiemKe, ghiChu);
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByDate(DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return phieuKiemKeDAL.GetListPhieuKiemKeByDate(ngayBatDau, ngayKetThuc);
        }

        public List<PhieuKiemKe> GetListPhieuKiemKeByNhanVien(string maNhanVien)
        {
            return phieuKiemKeDAL.GetListPhieuKiemKeByNhanVien(maNhanVien);
        }

        public string LayMaPhieuKiemKeCuoiCung()
        {
            var lastPhieuKiemKe = phieuKiemKeDAL.LayDanhSachPhieuKiemKe().LastOrDefault();
            return lastPhieuKiemKe?.MaPhieuKiemKe;
        }

        public bool TaoPhieuKiemKe(PhieuKiemKe pkk, List<ChiTietPhieuKiemKe> lstPKK)
        {
            try
            {
                if (!InsertPhieuKiemKe(pkk))
                {
                    return false;
                }
                foreach (var item in lstPKK)
                {
                    ChiTietPhieuKiemKeBLL chiTietPhieuKiemKeBLL = new ChiTietPhieuKiemKeBLL();
                    if (!chiTietPhieuKiemKeBLL.InsertChiTietPhieuKiemKe(item))
                    {
                        return false;
                    }
                    SanPhamBLL sanPhamBLL = new SanPhamBLL();
                    SanPham sp = sanPhamBLL.LaySanPhamTheoMa(item.MaSanPham);
                    sp.SoLuongTon = item.SoLuongThucTe;
                    sp.NgayCapNhat = DateTime.Now;
                    if (!sanPhamBLL.UpdateProduct(sp))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<PhieuKiemKe> LayDanhSachPhieuKiemKe()
        {
            return phieuKiemKeDAL.LayDanhSachPhieuKiemKe();
        }

        public bool XoaPhieuKiemKe(string maPhieuKiemKe)
        {
            PhieuKiemKe phieuKiemKe = GetPhieuKiemKeById(maPhieuKiemKe);
            List<ChiTietPhieuKiemKe> lstCTPKK = new ChiTietPhieuKiemKeBLL().GetListChiTietPhieuKiemKeByMaPhieuKiemKe(maPhieuKiemKe);
            if(!new ChiTietPhieuKiemKeBLL().Xoa(maPhieuKiemKe))
            {
                return false;
            }
            if (!phieuKiemKeDAL.XoaPhieuKiemKe1(maPhieuKiemKe))
            {
                return false;
            }
            return true;
        }

        public bool CapNhatPhieuKiemKeDuaTrenPhieuKiemKeVaDSCTPKK(PhieuKiemKe pkk, List<ChiTietPhieuKiemKe> lstTemp)
        {
            PhieuKiemKeBLL phieuKiemKeBLL = new PhieuKiemKeBLL();
            if (phieuKiemKeBLL.UpdatePhieuKiemKe(pkk))
            {
                foreach(ChiTietPhieuKiemKe item in lstTemp)
                {
                    ChiTietPhieuKiemKeBLL chiTietPhieuKiemKeBLL = new ChiTietPhieuKiemKeBLL();
                    if (!chiTietPhieuKiemKeBLL.UpdateChiTietPhieuKiemKe(item))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
