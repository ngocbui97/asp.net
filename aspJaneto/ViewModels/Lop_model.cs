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
        public string Nganh { get; set; }
        // public int svIds  { get; set; }
        
        public TTGV GVCN { get; set; }
        //   public int gvIds  { get; set; }

        // public int gvcn { get; set; }

        public Lop_model()
        {

        }
        public Lop_model(TTLOP ttlop)
        {
            this.MaLop = ttlop.MaLop;
            this.TenLop = ttlop.TenLop;
            this.Nganh = ttlop.Nganh;
           
            this.GVCN = ttlop.gvcn;
        }
        public class TaoLop
         {
            public string MaLop { get; set; } 
            public string TenLop { get; set; }
            public string Nganh { get; set; }
           
            
            public TTGV GVCN { get; set; }
        }
        public class CapNhatLop:TaoLop
        {
            public int Id { get; set; }
        }
    }
}