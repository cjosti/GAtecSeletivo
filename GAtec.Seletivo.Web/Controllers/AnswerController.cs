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
            Question question = _questionService.Get(id);
            if (question == null)
                return HttpNotFound();

            IEnumerable<Answer> answers = _answerService.GetAnswersByQuestion(question.Id);           

            var viewModel = new QuestionAnswerViewModel()
            {
                Question = question,
                Answers = answers.ToList()
            };

            return View("Details", viewModel);
        }
    }
}