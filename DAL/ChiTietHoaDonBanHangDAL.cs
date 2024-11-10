using System;
using System.Collections.Generic;
using System.Linq;
using DTO;

namespace DAL
{
    public class ChiTietHoaDonBanHangDAL
    {
        private readonly db_QLCHBGBDataContext _dbContext = new db_QLCHBGBDataContext();

        public ChiTietHoaDonBanHangDAL() { }

        public bool AddChiTietHoaDon(ChiTietHoaDonBanHang chiTietHoaDon)
        {
            try
            {
                _dbContext.ChiTietHoaDonBanHangs.InsertOnSubmit(chiTietHoaDon);
                _dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding ChiTietHoaDonBanHang: " + ex.Message);
                return false;
            }
        }

        public List<ChiTietHoaDonBanHang> GetChiTietHoaDonByMaHoaDon(string maHoaDon)
        {
            try
            {
                return _dbContext.ChiTietHoaDonBanHangs
                                 .Where(cthd => cthd.MaHoaDon == maHoaDon)
                                 .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching ChiTietHoaDon by MaHoaDon: " + ex.Message);
                return new List<ChiTietHoaDonBanHang>();
            }
        }

        public ChiTietHoaDonBanHang GetChiTietHoaDonByMaChiTiet(string maChiTietHoaDon)
        {
            try
            {
                return _dbContext.ChiTietHoaDonBanHangs
                                 .SingleOrDefault(cthd => cthd.MaChiTietHoaDonBanHang == maChiTietHoaDon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching ChiTietHoaDon by MaChiTietHoaDon: " + ex.Message);
                return null;
            }
        }

        public bool DeleteChiTietHoaDon(string maChiTietHoaDon)
        {
            try
            {
                var chiTietHoaDon = GetChiTietHoaDonByMaChiTiet(maChiTietHoaDon);
                if (chiTietHoaDon != null)
                {
                    _dbContext.ChiTietHoaDonBanHangs.DeleteOnSubmit(chiTietHoaDon);
                    _dbContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting ChiTietHoaDon: " + ex.Message);
                return false;
            }
        }
    }
}
