using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiModel;

namespace aspJaneto.ViewModels
{
    public class GiaoVien_model
    {
        public int Id { get; set; }
        public string MaGv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
       
        
        public GiaoVien_model()
        {

        }
        public GiaoVien_model(TTGV ttgv)
        {
            this.Id = ttgv.Id;
            this.MaGv = ttgv.MaGv;
            this.HoTen = ttgv.HoTen;
            this.NgaySinh = ttgv.NgaySinh;
            
           
        }
        public class TaoGiaoVien
        {
            public string MaGv { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }
           
           

        }
        public class CapNhatGiaoVien : TaoGiaoVien
        {
            public int Id { get; set; }
        }
        public class XoaGiaoVien : CapNhatGiaoVien { }

    }
}