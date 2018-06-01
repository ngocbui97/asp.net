using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTLOP:Entity<int>
    {
        public string TenLop { get; set; }
        public string MaLop { get; set; }
        public string Nganh { get; set; }
        public virtual ICollection<TTSV> dssvs { get; set; }

        public virtual ICollection<TTGV> dsgvs { get; set; }

        public virtual TTGV gvcn { get; set; }


    }
}
