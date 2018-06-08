using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiModel;
using aspJaneto.ViewModels;
using aspJaneto.Infrastructure;
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
        //create sinh vien


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
                sv.lop = db.TTLOPs.FirstOrDefault(x => x.Id == model.LopId);
                sv = db.TTSVs.Add(sv);

                this.db.SaveChanges();

                SinhVien_model SV = new SinhVien_model(sv);

                httpActionResult = Ok(SV);
            }
            else
            {
                // httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }
        // sua
        [HttpPut]
        public IHttpActionResult CapNhatSV(CapNhatSinhVien model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            TTSV sv = this.db.TTSVs.FirstOrDefault(x => x.Id == model.Id);

            if (sv == null)
            {
                errors.Add("Không tìm thấy lớp");

                // httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                sv.MaSv = model.MaSv ?? model.MaSv;
                sv.NgaySinh = model.NgaySinh;
                sv.HoTen = model.HoTen ?? model.HoTen;
               
                this.db.Entry(sv).State = System.Data.Entity.EntityState.Modified;

                this.db.SaveChanges();

                httpActionResult = Ok(new SinhVien_model(sv));
            }

            return httpActionResult;
        }
        // lay tat ca
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listSv = this.db.TTSVs.Select(x => new SinhVien_model()
            {
                Id = x.Id,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh,
                MaSv = x.MaSv,
                LopId = x.lop.Id
            });

            return Ok(listSv);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var sv = db.TTSVs.FirstOrDefault(x => x.Id == id);

            if (sv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy sinh vien");

                // httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new SinhVien_model(sv));
            }

            return httpActionResult;
        }

        //Xóa sinh viên
        [HttpDelete]
        public IHttpActionResult XoaSinhVien(int studentId)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();
            var sv = db.TTSVs.FirstOrDefault(x => x.Id == studentId);
            if (sv == null)
            {
                errors.Add("Mã sinh viên không tồn tại");
                //httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                this.db.TTSVs.Remove(sv);
                this.db.SaveChanges();
                httpActionResult = Ok("Đã xóa sinh viên " + sv.Id);
            }
            return httpActionResult;
        }
    }
}
