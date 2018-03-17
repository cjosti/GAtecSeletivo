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
    public class UserRepository: IUserRepository
    {
        public void Add(User item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into GA_USER (Name, User, Email, Password, Type) " +
                                                "values (@name, @user, @email, @password, @type)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("user", SqlDbType.NVarChar).Value = item.UserName;
                    cmd.Parameters.Add("email", SqlDbType.NVarChar).Value = item.Email;
                    cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = item.Password;
                    cmd.Parameters.Add("type", SqlDbType.Int).Value = item.UserName;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(User item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("update GA_USER set " +
                                                "Name = @name, " +
                                                "User = @user," +
                                                "Email = @email," +
                                                "Password = @password," +
                                                "Type = @type," +
                                                "where Id = @id", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("user", SqlDbType.NVarChar).Value = item.UserName;
                    cmd.Parameters.Add("email", SqlDbType.NVarChar).Value = item.Email;
                    cmd.Parameters.Add("password", SqlDbType.NVarChar).Value = item.Password;
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

                using (var cmd = new SqlCommand("delete from GA_USER where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User Get(object id)
        {
            User user = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Name, User, Email, Password, Type from GA_USER where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {

                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                UserName = reader["User"].ToString(),
                                Email = reader["Email"].ToString(),
                                Password = reader["Password"].ToString(),
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

                using (var cmd = new SqlCommand("select Id, Name, User, Email, Password, Type from GA_USER", con))
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
                                Type = (UserType)reader["Type"]

                            };

                            users.Add(user);
                        }

                    }
                }

            }
            return users;
        }
    } 
        
}
