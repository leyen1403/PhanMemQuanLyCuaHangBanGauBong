using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ChiTietDonDatHangDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public ChiTietDonDatHangDAL()
        {
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHang()
        {
            return db.ChiTietDonDatHangs.ToList();
        }

        public List<ChiTietDonDatHang> LayDanhSachChiTietDonDatHangTheoMaDonDatHang(string id)
        {
            return db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == id).ToList();
        }
       
        public bool ThemChiTietDonDatHang(ChiTietDonDatHang ctdh)
        {
            try
            {
                string maddh = ctdh.MaDonDatHang;
                string masp = ctdh.MaSanPham;
                ChiTietDonDatHang ctdh1 = db.ChiTietDonDatHangs.Where(ct => ct.MaDonDatHang == maddh && ct.MaSanPham == masp).FirstOrDefault();
                if (ctdh1 != null)
                {
                    ctdh1.SoLuongYeuCau = ctdh.SoLuongYeuCau;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    db.ChiTietDonDatHangs.InsertOnSubmit(ctdh);
                    db.SubmitChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool XoaChiTietDonDatHang(ChiTietDonDatHang ctddh)
        {
            try
            {
                ChiTietDonDatHang ctdh = db.ChiTietDonDatHangs.Where(ct => ct==ctddh).FirstOrDefault();
                db.ChiTietDonDatHangs.DeleteOnSubmit(ctdh);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
