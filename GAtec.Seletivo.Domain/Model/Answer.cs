using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model
{
    public class Answer
    {
        public int Id { get; set; }

        [Display(Name = "Resposta:")]
        public string Description { get; set; }

        public int QuestionId { get; set; }

        [Display(Name = "Resposta Certa:")]
        public bool RightAnswer { get; set; }

    }
}
