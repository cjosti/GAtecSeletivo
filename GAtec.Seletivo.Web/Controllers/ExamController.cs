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
    public class ExamController : Controller
    { 
        private IExamService _examService;

        public ExamController(IExamService examService)
        {
            this._examService = examService;
        }

        // GET: Exam
        public ActionResult Index()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Exam exam)
        {
            if (_examService.Add(exam))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Update (Exam exam)
        {
            if (_examService.Update(exam))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (_examService.Delete(id))
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
            var exams = _examService.GetAll();

            return Json(exams, JsonRequestBehavior.AllowGet);
        }
    }
}