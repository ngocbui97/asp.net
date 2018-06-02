using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTLOP : Entity<long>
    {
        public string TenLop { get; set; }
        public string MaLop { get; set; }
       

       // public long gvdayId { get; set; }
        public virtual TTGV gvday { get; set; }

        //public long gvcnId { get; set; }
        public virtual TTGV gvcn { get; set; }

        [InverseProperty("lop")]
        public virtual ICollection<TTSV> dssvs { get; set; }
        [InverseProperty("lop")]
        public virtual ICollection<TTGV> dsgvs { get; set; }

        


    }
}
