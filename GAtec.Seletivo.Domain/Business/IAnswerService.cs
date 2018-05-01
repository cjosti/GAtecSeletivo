using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IAnswerService: IServiceBase
    {
        bool Add(Answer answer);

        bool Update(Answer answer);

        bool Delete(int id);

        Answer Get(int id);

        IEnumerable<Answer> GetAll();

        IEnumerable<Answer> GetAnswersByQuestion(int id);
    }
}
