using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.ViewModel
{
    public class ExamQuestionViewModel
    {
        public Exam Exam { get; set; }
        public Question Question { get; set; }
        
    }
}