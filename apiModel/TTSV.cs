using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiModel
{
    public class TTSV : Entity<long>
    {
        public string HoTen { get; set; }
        public string MaSv { get; set; }
        public DateTime NgaySinh { get; set; }
        public long lopId { get; set; }
        public virtual TTLOP lop { get; set; }

        
    }
}
