using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Question
        private IRecruitmentService _recruitmentService;
        private IExamService _examService;

        public HomeController(IRecruitmentService recruitmentService, IExamService examService)
        {
            this._recruitmentService = recruitmentService;
            this._examService = examService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult IndexAsync()
        {
            var recruitment = _recruitmentService.GetAll();

            return Json(recruitment, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult IndexCAsync()
        {
            var exam = _examService.GetExamList();

            return Json(exam, JsonRequestBehavior.AllowGet);
        }
    }
}