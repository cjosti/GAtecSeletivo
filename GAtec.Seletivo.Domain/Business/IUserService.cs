using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Business
{
    public interface IUserService: IServiceBase
    {
        bool Add(User user);

        bool Update(User user);

        bool Delete(int id);

        User GetInfo(string cpf);
        User Get(string username, string password);

        IEnumerable<User> GetAll();

        bool ExistUser(string username);
        bool ExistCpf(string username);

    }
}
