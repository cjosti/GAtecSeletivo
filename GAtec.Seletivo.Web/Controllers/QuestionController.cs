using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class QuestionController : Controller
    {
        // GET: Question
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        // GET: Exam
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Question question)
        {
            if (_questionService.Add(question))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Update(Question question)
        {
            if (_questionService.Update(question))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (_questionService.Delete(id))
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
            var questions = _questionService.GetAll();

            return Json(questions, JsonRequestBehavior.AllowGet);
        }
    }
}