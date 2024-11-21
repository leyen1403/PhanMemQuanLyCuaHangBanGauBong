using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhieuBaoCao
    {
        public string STT { get; set; }
        public string MASANPHAM { get; set; }
        public string TENSANPHAM { get; set; }
        public int SOLUONG { get; set; }
        public Decimal DONGIA { get; set; }
        public Decimal THANHTIEN { get; set; }

        public DateTime NGAY { get; set; }
        public PhieuBaoCao()
        {

        }
    }
}
