using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Util;

namespace GAtec.Seletivo.Business
{
    class UserService
    {
        public class CategoryService : IUserService
        {
            private IUserRepository UserRepository { get; set; }

            public IValidationError Validator { get; set; }

            public CategoryService(IUserRepository userRepository,
                                   IValidationError validator)
            {
                this.UserRepository = userRepository;
                this.Validator = validator;
            }

            public bool Add(User user)
            {
                bool Error = false;

                if (string.IsNullOrEmpty(user.Name))
                {
                    Validator.AddError("Name", "O nome é obrigatório");
                    Error = true;
                }
                if (string.IsNullOrEmpty(user.UserName)) //verificar também se o usuário já existe
                {
                    Validator.AddError("UserName", "O usuário é obrigatório");
                    Error = true;
                }
                if (string.IsNullOrEmpty(user.Email))
                {
                    Validator.AddError("Email","O e-mail é obrigatório");
                    Error = true;
                }
                if (string.IsNullOrEmpty(user.Password))
                {
                    Validator.AddError("Password", "O password é obrigatório");
                    Error = true;
                }

                if (Error)
                {
                    return false;
                }

                UserRepository.Add(user);

                return true;
            }

            public bool Update(User user)
            {
                throw new System.NotImplementedException();
            }

            public bool Delete(int id)
            {
                throw new System.NotImplementedException();
            }

            public User GetUser(int id)
            {
                throw new System.NotImplementedException();
            }

            public IEnumerable<User> GetUsers()
            {
                var data = UserRepository.GetAll();

                return data;
            }

            public bool existUser(string username)
            {
                return false;
            }
        }
    }
}
