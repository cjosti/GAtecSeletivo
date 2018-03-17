using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    interface IUserService: IServiceBase
    {
        bool Add(User user);

        bool Update(User user);

        bool Delete(int id);

        User GetUser(int id);

        IEnumerable<User> GetUsers();
    }
}
