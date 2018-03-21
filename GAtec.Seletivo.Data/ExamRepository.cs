using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GAtec.Seletivo.Util.Settings;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Data
{
    class ExamRepository
    {
        public void Add(Exam item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO GA_EXAM (NAME) " +
                                                "VALUES (@name, @description)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Exam item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("UPDATE GA_EXAM SET " +
                                                "NAME = @name " +
                                                "WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;
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

                using (var cmd = new SqlCommand("DELETE FROM GA_EXAM WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Exam Get(object id)
        {
            Exam exam = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT ID, NAME FROM GA_EXAM WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            exam = new Exam
                            {

                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString()
                            };

                        }

                    }
                }

            }
            return exam;
        }

        public IEnumerable<Exam> GetAll()
        {
            var exams = new List<Exam>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("SELECT ID, NAME FROM GA_EXAM", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var exam = new Exam
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["Name"].ToString()

                            };

                            exams.Add(exam);
                        }

                    }
                }

            }
            return exams;
        }

    }
}
