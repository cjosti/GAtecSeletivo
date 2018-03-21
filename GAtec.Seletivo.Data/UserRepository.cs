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

                using (var cmd = new SqlCommand("INSERT INTO GA_USER (NAME, USERNAME, PASSWORD, EMAIL, CPF, TYPE)" +
                                                "VALUES (@name, @userName, @email, @CPF, @password, @type)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.VarChar).Value = item.Name;
                    cmd.Parameters.Add("userName", SqlDbType.VarChar).Value = item.UserName;
                    cmd.Parameters.Add("email", SqlDbType.VarChar).Value = item.Email;
                    cmd.Parameters.Add("CPF", SqlDbType.VarChar).Value = item.CPF;
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
            User user = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT ID, NAME, USER, EMAIL, PASSWORD, CPF, TYPE FROM GA_USER WHERE ID = @id", con))
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

                using (var cmd = new SqlCommand("SELECT ID, NAME, USER, EMAIL, PASSWORD, CPF, TYPE FROM GA_USER", con))
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

                using (var cmd = new SqlCommand("select 1 from GA_USER where", con))
                {

                }
            }
            return false;
        }
    } 
        
}
