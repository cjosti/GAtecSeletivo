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

                using (var cmd = new SqlCommand("insert into GA_EXAM (Name) " +
                                                "values (@name, @description)", con))
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

                using (var cmd = new SqlCommand("update GA_EXAM set " +
                                                "Name = @name " +
                                                "where Id = @id", con))
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

                using (var cmd = new SqlCommand("delete from GA_EXAM where Id = @id", con))
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

                using (var cmd = new SqlCommand("select Id, Name from GA_EXAM where Id = @id", con))
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

                using (var cmd = new SqlCommand("select Id, Name from GA_EXAM", con))
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
