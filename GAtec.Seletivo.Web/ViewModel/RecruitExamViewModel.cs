using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Web.ViewModel
{
    public class RecruitExamViewModel
    {
        public Recruitment Recruitment { get; set; }
        public IList<Exam> Exams { get; set; }
    }
}
