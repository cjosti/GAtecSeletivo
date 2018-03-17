using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    public class Exam
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public IList<Question> Questions { get; set; }
    }
}
