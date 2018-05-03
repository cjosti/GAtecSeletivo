using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Web.ViewModel;

namespace GAtec.Seletivo.Web.Controllers
{
    [AllowAnonymous]
    public class AnswerController : Controller
    {
        private IAnswerService _answerService;
        private IQuestionService _questionService;

        public AnswerController(IAnswerService answerService, IQuestionService questionService)
        {
            this._answerService = answerService;
            this._questionService = questionService;
        }        

        // GET: Answer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
                return HttpNotFound();

            Question question = _questionService.Get(id);
            if (question == null)
                return HttpNotFound();

            var viewModel = new QuestionAnswerViewModel()
            {
                Question = question
            };

            return View("Details", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            if (_answerService.Add(answer))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Update(Answer answer)
        {
            if (_answerService.Update(answer))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (_answerService.Delete(id))
            {
                return View("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult IndexAsync()
        {
            var answers = _answerService.GetAll();

            return Json(answers, JsonRequestBehavior.AllowGet);
        }
    
    }
}