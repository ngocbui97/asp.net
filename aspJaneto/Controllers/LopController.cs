using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiModel;
using aspJaneto.ViewModels;
using static aspJaneto.ViewModels.Lop_model;

namespace aspJaneto.Controllers
{
    public class LopController : ApiController
    {
        private ApiDbcontext db;
        public LopController()
        {
            this.db = new ApiDbcontext();
        }
        
        /// <summary>
        //
        /// </summary>
        /// <param name="tl"></param>
        /// <returns></returns>
         
        //create lop
        [HttpPost]
        public IHttpActionResult TaoLop(TaoLop tl)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            if (string.IsNullOrEmpty(tl.MaLop))
            {
                errors.Add("Mã lớp là trường bắt buộc");
            }

            if (errors.Errors.Count == 0)
            {
                TTLOP lop = new TTLOP();
                lop.MaLop = tl.MaLop;
                lop.TenLop = tl.TenLop;
                //lop.gvcnId = tl.gvcnId;
                //lop.gvdayId = tl.gvdayId;
                lop = db.TTLOPs.Add(lop);

                this.db.SaveChanges();

                Lop_model Lopm = new Lop_model(lop);

                httpActionResult = Ok(Lopm);
            }
            else
            {
                httpActionResult = Ok(errors);
            }

            return httpActionResult;
        }

        [HttpPut]
        public IHttpActionResult CapNhatLop(CapNhatLop model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            TTLOP lop = this.db.TTLOPs.FirstOrDefault(x => x.Id == model.Id);

            if (lop == null)
            {
                errors.Add("Không tìm thấy lớp");

                httpActionResult = Ok(errors);
            }
            else
            {
                lop.MaLop = model.MaLop ?? model.MaLop;
                //lop.gvdayId = model.gvdayId;
                lop.TenLop = model.TenLop ?? model.TenLop;      
                //lop.gvcnId = model.gvcnId ;
                this.db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

                this.db.SaveChanges();

                httpActionResult = Ok(new Lop_model(lop));
            }

            return httpActionResult;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listLops = this.db.TTLOPs.Select(x => new Lop_model()
            {
                MaLop = x.MaLop,
                Id = x.Id,
                TenLop = x.TenLop,
              // gvcnId=x.gvcnId
             
            });

            return Ok(listLops);
        }

        [HttpGet]
        public IHttpActionResult GetById(long id)
        {
            IHttpActionResult httpActionResult;
            var lop = db.TTLOPs.FirstOrDefault(x => x.Id == id);

            if (lop == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                httpActionResult = Ok(errors);
            }
            else
            {
                httpActionResult = Ok(new Lop_model(lop));
            }

            return httpActionResult;
        }


        /**
           * @api [Post] /Lop/TenLop Tao mot lop moi
         * @apiGroup Lop
         * @apiPermission none
         * 
         * @apiParam {string} MaLop Ma cua lop moi 
         * @apiParam {string} TenLop Ten cua lop moi
         * 
         * @apiParamExample {json} Request-Example:
         * {
         *      MaLop: '001',
         *      TenLop: 'Cong nghe thong tin 01'
         * }
         * 
         * @apiSuccess {string} MaLop Ma cua lop moi vua tao
         * @apiSuccess {string} TenLop Ten cua lop moi vua tao
         * @apiSuccess {long} Id  Iid cua lop moi vua tao
         * 
         * @apiSuccessExample {json} Response:
         * {
         *      Id: 1,
         *      MaLop: '001'
         *      TenLop: 'Cong nghe thong tin 01'
         * }
         * 
         * 
         * @apiError (400) {string[]} Errors Mang cac loi
         * 
         * @apiErrorExample: {json}
         * {
         *      "Errors": [
         *          "Ma lop la truong bat buoc",
         *          "Ten lop la truong bat buoc"
         *      ]
         * } 
         * 
         * 
        */
    }

}
