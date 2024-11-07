using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class MauSacBLL
    {
        private MauSacDAL mauSacDAL;

        public MauSacBLL()
        {
            mauSacDAL = new MauSacDAL();
        }

        public bool AddMauSac(MauSac mauSac)
        {
            return mauSacDAL.Add(mauSac);
        }

        public bool DeleteMauSac(string id)
        {
            return mauSacDAL.Delete(id);
        }

        public bool UpdateMauSac(MauSac updatedMauSac)
        {
            return mauSacDAL.Update(updatedMauSac);
        }

        public List<MauSac> GetAllMauSac()
        {
            return mauSacDAL.GetAll();
        }

        public List<MauSac> GetByMaMau(string keyword)
        {
            return mauSacDAL.GetByMaMau(keyword);
        }
    }
}
