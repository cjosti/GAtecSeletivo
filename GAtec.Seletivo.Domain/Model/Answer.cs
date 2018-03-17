using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    public class Answer
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int QuestionId { get; set; }

        public bool RightAnswer { get; set; }

    }
}
