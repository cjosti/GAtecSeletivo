using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class RecruitmentController : Controller
    {
        // GET: Question
        private IRecruitmentService _recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            this._recruitmentService = recruitmentService;
        }
        // GET: Recruitment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teste()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recruitment recruit)
        {
            if (_recruitmentService.Add(recruit))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Update(Recruitment recruitment)
        {
            if (_recruitmentService.Update(recruitment))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (_recruitmentService.Delete(id))
            {
                return View("Index");
            }

            return View("Index");
        }

        public ActionResult Details()
        {
            return View();
        }

        [HttpGet]
        public ActionResult IndexAsync()
        {
            var recruitment = _recruitmentService.GetAll();

            return Json(recruitment, JsonRequestBehavior.AllowGet);
        }
    }
}