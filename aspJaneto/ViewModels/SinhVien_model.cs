using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using apiModel;

namespace aspJaneto.ViewModels
{
    public class SinhVien_model
    {
        public int Id { get; set; }
        public string MaSv { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public int LopId { get; set; }



        public SinhVien_model()
        {

        }
        public SinhVien_model(TTSV ttsv)
        {
            this.Id = ttsv.Id;
            this.MaSv = ttsv.MaSv;
            this.HoTen = ttsv.HoTen;
            this.NgaySinh = ttsv.NgaySinh;
            this.LopId = ttsv.lop.Id;
            
        }
        public class TaoSinhVien
        {
            public string MaSv { get; set; }
            public string HoTen { get; set; }
            public DateTime NgaySinh { get; set; }

            public int LopId { get; set; }


        }
        public class CapNhatSinhVien : TaoSinhVien
        {
            public int Id { get; set; }
        }
        public class XoaSinhVien : CapNhatSinhVien { }
    }
}