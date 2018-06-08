using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiModel;
using aspJaneto.Infrastructure;
using aspJaneto.ViewModels;
using static aspJaneto.ViewModels.GiaoVien_model;

namespace aspJaneto.Controllers
{
    public class GiaoVienController : ApiController
    {
        private ApiDbcontext db;
        public GiaoVienController()
        {
            this.db = new ApiDbcontext();
        }
        //create lop
        [HttpPost]
        public IHttpActionResult TaoGV(TaoGiaoVien model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(model.MaGv))
            {
                errors.Add("Mã giao vien là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                TTGV gv = new TTGV();
                gv.MaGv = model.MaGv;
                gv.HoTen = model.HoTen;
                gv.NgaySinh = model.NgaySinh;
               
                gv = db.TTGVs.Add(gv);

                this.db.SaveChanges();

                GiaoVien_model Lopm = new GiaoVien_model(gv);

                httpActionResult = Ok(Lopm);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }

        [HttpPut]
        public IHttpActionResult CapNhatGV(CapNhatGiaoVien model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            TTGV gv = this.db.TTGVs.FirstOrDefault(x => x.Id == model.Id);

            if (gv == null)
            {
                errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                gv.MaGv = model.MaGv ?? model.MaGv;
                gv.NgaySinh = model.NgaySinh;
                gv.HoTen = model.HoTen ?? model.HoTen;
              
                this.db.Entry(gv).State = System.Data.Entity.EntityState.Modified;

                this.db.SaveChanges();

                httpActionResult = Ok(new GiaoVien_model(gv));
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listSV = this.db.TTGVs.Select(x => new GiaoVien_model()
            {
                Id = x.Id,
                HoTen = x.HoTen,
                NgaySinh = x.NgaySinh, 
                MaGv=x.MaGv
               

            });

            return Ok(listSV);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var gv = db.TTGVs.FirstOrDefault(x => x.Id == id);

            if (gv == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                // httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new GiaoVien_model(gv));
            }

            return httpActionResult; 
        }
        [HttpDelete]
        public IHttpActionResult DeleteTeacher(int Id)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();
            var tc = db.TTGVs.FirstOrDefault(x => x.Id == Id);
            if (tc == null)
            {
                errors.Add("Mã giáo viên không tồn tại!");
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                this.db.TTGVs.Remove(tc);
                this.db.SaveChanges();
                httpActionResult = Ok("Đã xóa giáo viên " + tc.Id);
            }
            return httpActionResult;
        }
    }
}
