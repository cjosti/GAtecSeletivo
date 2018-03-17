using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    class Question
    {
        public int id { get; set; }

        public string description { get; set; }

        public int type { get; set; }

        public int score { get; set; }

        public IList<Answer> answers { get; set; }
    }
}
