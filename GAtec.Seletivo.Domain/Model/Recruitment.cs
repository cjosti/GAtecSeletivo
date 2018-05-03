using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    public class Recruitment
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public IList<User> Users { get; set; }

        public IList<Exam> Exams { get; set; }
    }
}
