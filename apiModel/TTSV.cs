using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTSV : Entity<int>
    {
        public string HoTen { get; set; }
        public string MaSv { get; set; }
        public DateTime NgaySinh { get; set; }
        
        public virtual ICollection<TTLOP> Ds_lophoc { get; set; }

    }
}
