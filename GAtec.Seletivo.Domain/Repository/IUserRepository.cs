using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool ExistUser(string username);

        bool ExistCpf(string cpf);

        User GetInfo(string cpf);

        User Get(string name, string password);
    }
}
