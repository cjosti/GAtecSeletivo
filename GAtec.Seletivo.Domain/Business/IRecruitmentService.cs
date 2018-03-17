using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IRecruitmentService: IServiceBase
    {
        bool Add(Recruitment recruitment);

        bool Update(Recruitment recruitment);

        bool Delete(int id);

        Recruitment Get(int id);

        IEnumerable<Recruitment> GetAll();

    }
}
