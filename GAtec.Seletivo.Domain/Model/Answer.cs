using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    class Answer
    {
        public int id { get; set; }

        public string description { get; set; }

        public int questionId { get; set; }

        public bool rightAnswer { get; set; }

    }
}
