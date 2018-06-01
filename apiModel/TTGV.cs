using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTGV : Entity<int>
    {
        public string MaGv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Khoa { get; set; }

        public virtual ICollection<TTLOP> lop_cn { get; set; }
        public virtual ICollection<TTLOP> lop_day { get; set; }
    }
}
