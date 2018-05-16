using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Repository
{
    public interface IExamRepository: IBaseRepository<Exam>
    {
        IEnumerable<Exam> GetExamByRecruitment(object id);

        IEnumerable<Exam> GetExamList();

        void AddExamQuestion(object ExamId, object QuestionId);

    }
}
