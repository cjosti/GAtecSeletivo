using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Web.ViewModel;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class ExamController : Controller
    {
        private IExamService _examService;
        private IQuestionService _questionService;        

        public ExamController(IExamService examService, IQuestionService questionService)
        {
            this._examService = examService;
            this._questionService = questionService;
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

        [HttpGet]
        public ActionResult IndexAsync()
        {
            var exams = _examService.GetAll();

            return Json(exams, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
                return HttpNotFound();

            Question question = _questionService.Get(id);
            if (question == null)
                return HttpNotFound();

            var viewModel = new ExamQuestionViewModel()
            {
                Question = question
            };

            return View("Details", viewModel);
        }

    }
}