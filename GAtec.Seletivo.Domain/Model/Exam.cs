﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model
{
    public class Exam
    {
        public int Id { get; set; }

        [Display(Name = "Nome:")]
        public string Name { get; set; }

        public int ExamId { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
