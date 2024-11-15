﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhieuNhapDAL
    {
        db_QLCHBGBDataContext db = new db_QLCHBGBDataContext();
        public PhieuNhapDAL() { }
        public List<PhieuNhap> GetListPhieuNhap()
        {
            return db.PhieuNhaps.ToList();
        }
        public bool AddPhieuNhap(PhieuNhap newPhieuNhap)
        {
            try
            {
                db.PhieuNhaps.InsertOnSubmit(newPhieuNhap);
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
