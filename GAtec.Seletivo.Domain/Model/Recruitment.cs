using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GAtec.Seletivo.Domain.Model
{
    public class Recruitment
    {
        public int Id { get; set; }

        [Display(Name = "Seleção:")]
        public string Description { get; set; }

        [Display(Name = "Data:")]
        public DateTime Date { get; set; }

        [Display(Name = "Candidato:")]
        public IList<User> Users { get; set; }

        [Display(Name = "Exames:")]
        public IList<Exam> Exams { get; set; }
    }
}
