using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    interface IQuestionService: IServiceBase
    {
        bool Add(Question question);

        bool Update(Question question);

        bool delete(int id);

        Question GetQuestion(int id);

        IEnumerable<Question> GetQuestions();
    }
}
