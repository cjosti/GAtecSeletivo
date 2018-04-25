using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string Description { get; set; }

        public QuestionType Type { get; set; }

        public int Score { get; set; }

        public IList<Answer> Answers { get; set; }
    }
}
