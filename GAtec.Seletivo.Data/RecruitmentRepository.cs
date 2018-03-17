using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GAtec.Seletivo.Util.Settings;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Data
{
    class RecruitmentRepository: IRecruitmentRepository
    {
        public void Add(Recruitment item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into GA_RECRUITMENT (Name, Description) " +
                                                "values (@name, @description)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
               
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Recruitment item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("update GA_RECRUITMENT set " +
                                                "Name = @name, " +
                                                "Description = @description" +
                                                "where Id = @id", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
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

                using (var cmd = new SqlCommand("delete from GA_RECRUITMENT where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Recruitment Get(object id)
        {
            Recruitment recruitment = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Name, Description Type from GA_RECRUITMENT where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recruitment = new Recruitment
                            {

                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString()
                            };

                        }

                    }
                }

            }
            return recruitment;
        }

        public IEnumerable<Recruitment> GetAll()
        {
            var recruitments = new List<Recruitment>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Name, Description from GA_RECRUITMENT", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var recruitment = new Recruitment
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString()

                            };

                            recruitments.Add(recruitment);
                        }

                    }
                }

            }
            return recruitments;
        }
    }
}

