using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();

        public KhachHangDAL() { }

        public bool AddKhachHang(KhachHang khachHang)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(khachHang);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public KhachHang GetKhachHangByMa(string maKhachHang)
        {
            return db.KhachHangs.FirstOrDefault(kh => kh.MaKhachHang == maKhachHang);
        }

        public List<KhachHang> GetKhachHangByTen(string tenKhachHang)
        {
            return db.KhachHangs.Where(kh => kh.TenKhachHang.Contains(tenKhachHang)).ToList();
        }

        public KhachHang GetKhachHangBySoDienThoai(string soDienThoai)
        {
            return db.KhachHangs.FirstOrDefault(kh => kh.SoDienThoai == soDienThoai);
        }
        public KhachHang GetKhachHang(string maKhachHang = null, string tenKhachHang = null, string soDienThoai = null)
        {
            var query = db.KhachHangs.AsQueryable();
            if (!string.IsNullOrEmpty(maKhachHang))
            {
                query = query.Where(kh => kh.MaKhachHang == maKhachHang);
            }
            if (!string.IsNullOrEmpty(tenKhachHang))
            {
                query = query.Where(kh => kh.TenKhachHang.Contains(tenKhachHang));
            }
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                query = query.Where(kh => kh.SoDienThoai == soDienThoai);
            }
            return query.FirstOrDefault();
        }
        public List<KhachHang> GetAllKhachHangs()
        {
            try
            {
                return db.KhachHangs.ToList(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<KhachHang>(); 
            }
        }

    }
}
