using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTGV : Entity<long>
    {
        public string MaGv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Khoa { get; set; }
        public long lopId { get; set; }
        public virtual TTLOP lop { get; set; }

        [InverseProperty("gvcn")]
        public virtual ICollection<TTLOP> lop_cn { get; set; }
        [InverseProperty("gvday")]
        public virtual ICollection<TTLOP> lop_day { get; set; }
    }
}
