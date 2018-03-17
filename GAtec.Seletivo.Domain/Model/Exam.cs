using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    class Exam
    {
        public int id { get; set; }

        public string name { get; set; }

        public bool active { get; set; }

        public IList<Question> questions { get; set; }
    }
}
