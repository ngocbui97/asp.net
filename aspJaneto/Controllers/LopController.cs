using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using apiModel;
using aspJaneto.Infrastructure;
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

       

        //create lop
        /**
           * @api {Post} /Lop/TaoLop Tao lớp mới
         * @apiGroup Lop
         * @apiPermission none
         * @apiVersion 1.0.0
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
         *          
         *      ]
         * } 
         * 
         * 
        */
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
                lop.gvcn = db.TTGVs.FirstOrDefault(x => x.Id == tl.gvcnId);

                lop = db.TTLOPs.Add(lop);

                this.db.SaveChanges();

                Lop_model Lopm = new Lop_model(lop);

                httpActionResult = Ok(Lopm);
            }
            else
            {
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.BadRequest, errors);
            }

            return httpActionResult;
        }

        // cap nhat

        /**
                   * @api {Put} /Lop/TenLop Cập nhật lớp mới
                 * @apiGroup Lop
                 * @apiPermission none
                 * 
                 * @apiParam {string} MaLop Mã của lớp cần cập nhật
                 * 
                 * 
                 * @apiParamExample {json} Request-Example:
                 * {
                 *      MaLop: '001'
                 *      
                 * }
                 * 
                 * @apiSuccess {string} Id Id của lớp vữa cập nhật
                 * @apiSuccess {string} MaLop Mã của lớp vữa cập nhật
                 * @apiSuccess {string} TenLop Tên của lớp vừa cập nhật
                 * @apiSuccess {int} gvcnId  Id của giáo viên chủ nhiệm vừa cập nhật
                 * 
                 * @apiSuccessExample {json} Response:
                 * {
                 *      Id: 1,
                 *      MaLop: '001'
                 *      TenLop: 'Cong nghe thong tin 01',
                 *      gvcnId:'2'
                 * }
                 * 
                 * 
                 * @apiError (400) {string[]} Errors Mang cac loi
                 * 
                 * @apiErrorExample: {json}
                 * {
                 *      "Errors": [
                 *          "Ma lop la truong bat buoc"
                 *          
                 *      ]
                 * } 
                 * 
                 * 
                */


        [HttpPut]
        public IHttpActionResult CapNhatLop(CapNhatLop model)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();

            TTLOP lop = this.db.TTLOPs.FirstOrDefault(x => x.Id == model.Id);

            if (lop == null)
            {
                errors.Add("Không tìm thấy lớp");

                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                lop.MaLop = model.MaLop ?? model.MaLop;
               
                lop.TenLop = model.TenLop ?? model.TenLop;

                lop.gvcn = db.TTGVs.FirstOrDefault(x => x.Id == model.gvcnId);

                this.db.Entry(lop).State = System.Data.Entity.EntityState.Modified;

                this.db.SaveChanges();

                httpActionResult = Ok(new Lop_model(lop));
            }

            return httpActionResult;
        }

        // lay tat ca

        /**
          * @api {Get} /lop/GetAll lấy tất cả thông tin của lớp
          * @apigroup Lop
          * @apiPermission none
          * @apiVersion 1.0.0
          * 
          * 
          * 
          * @apiSuccess {int} Id Id của lớp
          * @apiSuccess {string} MaLop Mã của lớp
          * @apiSuccess {string} TenLop Tên của lớp
          * @apiSuccess { int} gvcnId Id của giáo viên chủ nhiêm
          * 
          * 
          * @apiSuccessExample {json} Response: 
          * {
          *		Id: 1,
          *		MaLOp: "D12CQCN01",
          *		TenLop: "Công nghệ thông tin 1",
          *		gvcnId:"2"
          * }
          * 
          * @apiError (Error 400) {string[]} Errors Mảng các lỗi
          * 
          * @apiErrorExample: {json}
          * {
          *		"Errors" : [
          *			"Mã lớp là trường bắt buộc"
          *			
          *		]
          * }
          * 
          */


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var listLops = this.db.TTLOPs.Select(x => new Lop_model()
            {
                MaLop = x.MaLop,
                Id = x.Id,
                TenLop = x.TenLop,
                gvcnId = x.gvcn.Id
             
            });

            return Ok(listLops);
        }

        //lay thong tin khi co id

        /**
		 * @api {Get} /lop/GetbyId Lấy thông tin lớp theo Id
		 * @apigroup Lop
		 * @apiPermission none
		 * @apiVersion 1.0.0
		 * 
		 * @apiParam {int} Id Id của lớp
		 * 
		 * 
		 * @apiParamExample {json} Request-Example: 
		 * {
		 *		Id="1"
		 * }
		 * 
         * @apiSuccess {string} Id của lớp
		 * @apiSuccess {string} MaLop Mã của lớp
		 * @apiSuccess {string} TenLop Tên của lớp
		 * @apiSuccess {int } gvcnId Id của giáo viên chủ nhiệm
		 * 
		 * 
		 * @apiSuccessExample {json} Response: 
		 * {
		 *		Id: 1,
		 *		MaLOp: "D12CQCN01",
		 *		TenLop: "Công nghệ thông tin 1",
         *		gvcndId: "2"
		 * }
		 * 
		 * @apiError (Error 400) {string[]} Errors Mảng các lỗi
		 * 
		 * @apiErrorExample: {json}
		 * {
		 *		"Errors" : [
		 *			"Mã lớp là trường bắt buộc",
		 *			
		 *		]
		 * }
		 * 
		 */
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            IHttpActionResult httpActionResult;
            var lop = db.TTLOPs.FirstOrDefault(x => x.Id == id);

            if (lop == null)
            {
                ErrorModel errors = new ErrorModel();
                errors.Add("Không tìm thấy lớp");

                //httpActionResult = Ok(errors);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                httpActionResult = Ok(new Lop_model(lop));
            }

            return httpActionResult;
        }


        // xoa lớp

        /**
		 * @api {Delete} /Class/XoaLop Xóa một lớp mới
		 * @apigroup Lop
		 * @apiPermission none
		 * @apiVersion 1.0.0
		 * 
		 * @apiParam {int} Id Id của lớp cần xóa
		 * 
		 * 
		 * @apiParamExample {json} Request-Example: 
		 * {
		 *		Id: "1",
		 *		
		 * }
		 * 
         * @apiSuccess {int} Id Id của lớp xóa
		 * @apiSuccess {string} MaLop Mã của lớp vừa xóa
		 * @apiSuccess {string} TenLop Tên của lớp vừa xóa
		 * @apiSuccess { int} gvcnId Id của giáo viên chủ nhiệm lớp vừa xóa
		 * 
		 * 
		 * @apiSuccessExample {json} Response: 
		 * {
		 *		Id: 1,
		 *		MaLOp: "D12CQCN01",
		 *		TenLop: "Công nghệ thông tin 1",
         *		gvcnId: "1"
		 * }
		 * 
		 * @apiError (Error 400) {string[]} Errors Mảng các lỗi
		 * 
		 * @apiErrorExample: {json}
		 * {
		 *		"Errors" : [
		 *			"Mã lớp là trường bắt buộc",
		 *			
		 *		]
		 * }
		 * 
		 */
        //Xóa lớp
        [HttpDelete]
        public IHttpActionResult XoaLop(int id)
        {
            IHttpActionResult httpActionResult;
            ErrorModel errors = new ErrorModel();
            var lop = db.TTLOPs.FirstOrDefault(x => x.Id == id);
            if (lop == null)
            {
                errors.Add("Mã lớp không tồn tạo!");
                // httpActionResult = Ok(error);
                httpActionResult = new ErrorActionResult(Request, System.Net.HttpStatusCode.NotFound, errors);
            }
            else
            {
                this.db.TTLOPs.Remove(lop);
                this.db.SaveChanges();
                httpActionResult = Ok("Đã xóa lớp " + lop.Id);
            }
            return httpActionResult;
        }

        
    }

}
