using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiModel;

namespace aspJaneto.ViewModels
{
    public class Lop_model
    {
        public long Id { get; set; }

        public string MaLop { get; set; }
        
        public string TenLop { get; set; }
       
        // public int svIds  { get; set; }
        
        public long gvdayId { get; set; }
        //   public int gvIds  { get; set; }

        // public int gvcn { get; set; }
        public long gvcnId { get; set; }
        public Lop_model()
        {

        }
        public Lop_model(TTLOP ttlop)
        {
            this.MaLop = ttlop.MaLop;
            this.TenLop = ttlop.TenLop;
            this.gvdayId = ttlop.gvday.Id;
           
            this.gvcnId = ttlop.gvcn.Id;
        }
        public class TaoLop
         {
            public string MaLop { get; set; } 
            public string TenLop { get; set; }

            public long gvdayId { get; set; }
            
            public long gvcnId { get; set; }
        }
        public class CapNhatLop:TaoLop
        {
            public long Id { get; set; }
        }
    }
}