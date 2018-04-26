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
    public class RecruitmentRepository: IRecruitmentRepository
    {
        public void Add(Recruitment item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO GA_RECRUITMENT (DESCRIPTION, DATE) " +
                                                "VALUES (@description, @date)", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.VarChar).Value = item.Description;
                    cmd.Parameters.Add("date", SqlDbType.DateTime).Value = item.Date;
               
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Recruitment item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("UPDATE GA_RECRUITMENT SET " +
                                                "DESCRIPTION = @description, " +
                                                "DATE = @date" +
                                                "WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.VarChar).Value = item.Description;
                    cmd.Parameters.Add("date", SqlDbType.DateTime).Value = item.Date;
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

                using (var cmd = new SqlCommand("DELETE FROM GA_RECRUITMENT WHERE ID = @id", con))
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, DATE FROM GA_RECRUITMENT WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recruitment = new Recruitment
                            {

                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Date = reader.GetDateTime(3)
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, DATE FROM GA_RECRUITMENT", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var recruitment = new Recruitment
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Date = reader.GetDateTime(2)

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

