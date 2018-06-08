using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiModel;

namespace aspJaneto.ViewModels
{
    public class Lop_model
    {
        public int Id { get; set; }

        public string MaLop { get; set; }
        
        public string TenLop { get; set; }
       
        public int gvcnId { get; set; }
        public Lop_model()
        {

        }
        public Lop_model(TTLOP ttlop)
        {
            this.Id = ttlop.Id;
            this.MaLop = ttlop.MaLop;
            this.TenLop = ttlop.TenLop;
            this.gvcnId = ttlop.gvcn.Id;
        }
        public class TaoLop
         {
            public string MaLop { get; set; } 
            public string TenLop { get; set; }
            public int gvcnId { get; set; }
        }
        public class CapNhatLop:TaoLop
        {
            public int Id { get; set; }
        }
        public class XoaLop : CapNhatLop { }
    }
}