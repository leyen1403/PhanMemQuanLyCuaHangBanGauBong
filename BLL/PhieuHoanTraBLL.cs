using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhieuHoanTraBLL
    {
        private PhieuHoanTraDAL _phieuHoanTraDAL;

        public PhieuHoanTraBLL()
        {
            _phieuHoanTraDAL = new PhieuHoanTraDAL();
        }

        public List<PhieuHoanTra> GetAllPhieuHoanTra()
        {
            return _phieuHoanTraDAL.GetPhieuHoanTra();
        }

        public void AddPhieuHoanTra(PhieuHoanTra phieuHoanTra)
        {
            _phieuHoanTraDAL.AddPhieuHoanTra(phieuHoanTra);
        }

        public void UpdatePhieuHoanTra(PhieuHoanTra phieuHoanTra)
        {
            _phieuHoanTraDAL.UpdatePhieuHoanTra(phieuHoanTra);
        }

        public bool DeletePhieuHoanTra(string maPhieuHoanTra)
        {
           return _phieuHoanTraDAL.DeletePhieuHoanTra(maPhieuHoanTra);
        }
    }

}
