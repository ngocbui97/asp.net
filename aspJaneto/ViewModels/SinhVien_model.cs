using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiModel;

namespace aspJaneto.ViewModels
{
    public class SinhVien_model
    {
        public long Id { get; set; }
        public string MaSv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public virtual TTLOP lop { get; set; }



        public SinhVien_model()
        {

        }
        public SinhVien_model(TTSV ttsv)
        {
            this.MaSv = ttsv.MaSv;
            this.HoTen = ttsv.HoTen;
            this.NgaySinh = ttsv.NgaySinh;
            
            
        }
        public class TaoSinhVien
        {
            public string MaSv { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }

            public virtual TTLOP lop { get; set; }


        }
        public class CapNhatSinhVien : TaoSinhVien
        {
            public long Id { get; set; }
        }
    }
}