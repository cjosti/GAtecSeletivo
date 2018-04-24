using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Util.Settings;


namespace GAtec.Seletivo.Data
{
    public class UserRepository : IUserRepository
    {
        public void Add(User item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                int codUser = MaxCodUser();

                string userName = item.Name;
               // userName = userName.Substring(0, 2) + codUser;

                userName = CreateUsername(userName, codUser);

                using (var cmd = new SqlCommand("INSERT INTO GA_USER (NAME, USERNAME, EMAIL, CPF, TYPE)" +
                                                " VALUES (@name, @userName, @email, @CPF, @type)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.VarChar).Value = item.Name;
                    cmd.Parameters.Add("userName", SqlDbType.VarChar).Value = userName;
                    //cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = "";
                    cmd.Parameters.Add("email", SqlDbType.VarChar).Value = item.Email;
                    cmd.Parameters.Add("CPF", SqlDbType.VarChar).Value = item.CPF;
                    cmd.Parameters.Add("type", SqlDbType.Int).Value = 0;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(User item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("UPDATE GA_USER SET " +
                                                "NAME = @name, " +
                                                "USERNAME = @userName," +
                                                "EMAIL = @email," +
                                                "PASSWORD = @password," +
                                                "CPF = @CPF," +
                                                "TYPE = @type," +
                                                "WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.VarChar).Value = item.Name;
                    cmd.Parameters.Add("userName", SqlDbType.VarChar).Value = item.UserName;
                    cmd.Parameters.Add("email", SqlDbType.VarChar).Value = item.Email;
                    cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = item.Password;
                    cmd.Parameters.Add("CPF", SqlDbType.VarChar).Value = item.CPF;
                    cmd.Parameters.Add("type", SqlDbType.Int).Value = item.Type;
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = item.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(object id)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("DELETE FROM GA_USER WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User Get(object id)
        {
            throw new NotImplementedException();
        }

        public User Get(string username, string password)
        {
            User user = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                string IsPassword;

                if (password != null)
                {
                    IsPassword = " AND PASSWORD = @pass";
                }
                else
                {
                    IsPassword = " AND PASSWORD IS NULL";
                }

                using (var cmd = new SqlCommand("SELECT ID, NAME, USERNAME, EMAIL, PASSWORD, CPF, TYPE FROM GA_USER WHERE USERNAME = @username" + IsPassword, con))
                {
                    cmd.Parameters.Add("username", SqlDbType.VarChar).Value = username;
                    if (password != null)
                    {
                        cmd.Parameters.Add("pass", SqlDbType.VarChar).Value = password;
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {

                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                CPF = reader["CPF"].ToString(),
                                Type = (UserType)reader["Type"]
                            };

                        }

                    }
                }

            }
            return user;
        }

        public User GetInfo(string cpf)
        {
            User user = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT ID, NAME, USERNAME, EMAIL, PASSWORD, CPF, TYPE FROM GA_USER WHERE CPF = @cpf", con))
                {
                    cmd.Parameters.Add("cpf", SqlDbType.VarChar).Value = cpf;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {

                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                UserName = reader["UserName"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                CPF = reader["CPF"].ToString(),
                                Type = (UserType)reader["Type"]
                            };

                        }

                    }
                }

            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT ID, NAME, USERNAME, EMAIL, PASSWORD, CPF, TYPE FROM GA_USER", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
                                CPF = reader["CPF"].ToString(),
                                Type = (UserType)reader["Type"]

                            };

                            users.Add(user);
                        }

                    }
                }

            }
            return users;
        }

        public bool ExistUser(string username)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT 1 FROM GA_USER WHERE USERNAME = @user_name", con))
                {
                    cmd.Parameters.Add("user_name", SqlDbType.VarChar).Value = username;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public bool ExistCpf(string cpf)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT 1 FROM GA_USER WHERE CPF = @cpf", con))
                {
                    cmd.Parameters.Add("cpf", SqlDbType.VarChar).Value = cpf;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        public int MaxCodUser()
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT MAX(ID) + 1 MAX_ID FROM GA_USER", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (int)reader["MAX_ID"];
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
            }

        }

        private string CreateUsername(string Username, int codlen)
        {
            string nick = "";

            //Pega até o espaço
            if(Username.IndexOf(' ') > 1 )
            {
                nick = Username.Substring(0, Username.IndexOf(' '));
            }

            //Se for maior que 15 corta em substring
            if (nick.Length > 12)
            {
                nick = Username.Substring(0, 12);
            }

            //Adiciona o código
            nick = nick + codlen;

            return nick;
        }

    }

}
