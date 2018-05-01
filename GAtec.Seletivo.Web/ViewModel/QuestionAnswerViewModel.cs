using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.ViewModel
{
    public class QuestionAnswerViewModel
    {
        public Question Question { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}