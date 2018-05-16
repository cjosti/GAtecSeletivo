using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IExamService: IServiceBase
    {
        bool Add(Exam exam);

        bool Update(Exam exam);

        bool Delete(int id);

        Exam Get(int id);

        IEnumerable<Exam> GetAll();

        IEnumerable<Exam> GetExamByRecruitment(int id);

        IEnumerable<Exam> GetExamList();

        bool AddExamQuestion(int ExamId, int QuestionId);
    }
}
