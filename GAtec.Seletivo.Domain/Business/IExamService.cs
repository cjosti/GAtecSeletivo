using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    interface IExamService: IServiceBase
    {
        bool Add(Exam exam);

        bool Update(Exam exam);

        bool Delete(int id);

        Exam GetExam(int id);

        IEnumerable<Exam> GetExams();
    }
}
