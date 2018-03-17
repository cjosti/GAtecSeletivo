using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IQuestionService: IServiceBase
    {
        bool Add(Question question);

        bool Update(Question question);

        bool Delete(int id);

        Question Get(int id);

        IEnumerable<Question> GetAll();
    }
}
