using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model
{
    public enum QuestionType
    {
        Dissertative = 1,
        MultipleChoice = 2
    }

    public class Question
    {
        public int Id { get; set; }

        [Display(Name = "Questão:")]
        public string Description { get; set; }

        public QuestionType Type { get; set; }

        public IList<QuestionType> QuestionTypes => Enum.GetValues(typeof(QuestionType))
                                                        .Cast<QuestionType>()
                                                        .ToList();

        public int Score { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}
