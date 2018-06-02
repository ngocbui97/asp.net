using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiModel;
using aspJaneto.ViewModels;
using static aspJaneto.ViewModels.SinhVien_model;

namespace aspJaneto.Controllers
{
    public class SinhVienController : ApiController
    {
        private ApiDbcontext db;
        public SinhVienController()
        {
            this.db = new ApiDbcontext();
        }
        //create lop
        [HttpPost]
        public IHttpActionResult TaoSV(TaoSinhVien model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaSv))
            {
                errors.Add("Mã sinh vien là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                TTSV sv = new TTSV();
                sv.MaSv = model.MaSv;
                sv.HoTen = model.HoTen;
                sv.NgaySinh = model.NgaySinh;
                sv.lop = model.lop;
                sv = db.TTSVs.Add(sv);

                this.db.SaveChanges();

                SinhVien_model Lopm = new SinhVien_model(sv);

                httpActionResult = Ok(Lopm);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }

        [HttpPut]
        public IHttpActionResult CapNhatSV(CapNhatSinhVien model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            TTSV sv = this.db.TTSVs.FirstOrDefault(x => x.Id == model.Id);

            if (sv == null)
            {
                errors.Add("Không tìm thấy lớp");

                httpActionResult = Ok(errors);
            }
            else
            {
                sv.MaSv = model.MaSv ?? model.MaSv;
                sv.NgaySinh = model.NgaySinh;
                sv.HoTen = model.HoTen ?? model.HoTen;
                sv.lop = model.lop;
                this.db.Entry(sv).State = System.Data.Entity.EntityState.Modified;

                this.db.SaveChanges();

                httpActionResult = Ok(new SinhVien_model(sv));
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listLops = this.db.TTSVs.Select(x => new SinhVien_model()
            {
                Id = x.Id,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                MaSv=x.MaSv,
                lop=x.lop


            });

            return Ok(listLops);
        }

        //[HttpGet]
        //public IHttpActionResult GetById(long id)
        //{
        //    IHttpActionResult httpActionResult;
        //    var sv = db.TTSVs.FirstOrDefault(x => x.Id == id);

        //    if (sv == null)
        //    {
        //        ErrorModel errors = new ErrorModel();
        //        errors.Add("Không tìm thấy lớp");

        //        httpActionResult = Ok(errors);
        //    }
        //    else
        //    {
        //        httpActionResult = Ok(new SinhVien_model(sv));
        //    }

        //    return httpActionResult;
        //}
    }
}
