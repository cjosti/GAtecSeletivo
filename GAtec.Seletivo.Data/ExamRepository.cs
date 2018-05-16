using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using GAtec.Seletivo.Util.Settings;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Domain.Repository;

namespace GAtec.Seletivo.Data
{
    public class ExamRepository : IExamRepository
    {
        public void Add(Exam item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO GA_EXAM (NAME) " +
                                                "VALUES (@name)", con))
                {
                    cmd.Parameters.Add("name", SqlDbType.NVarChar).Value = item.Name;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void AddExamQuestion(object ExamId, object QuestionId)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO GA_EXAM_QUESTION (EXAMID, QUESTIONID) " +
                                                "VALUES (@examId, @questionId)", con))
                {
                    cmd.Parameters.Add("examId", SqlDbType.Int).Value = ExamId;
                    cmd.Parameters.Add("questionId", SqlDbType.Int).Value = QuestionId;

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


        public IEnumerable<Exam> GetExamByRecruitment(object recruitmentId)
        {
            return null;
        }

        public IEnumerable<Exam> GetExamList()
        {
            string query;
            var exams = new List<Exam>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                query = " SELECT E.ID AS ID_EXAM, E.NAME AS DSC_EXAM, RE.RECRUITID AS ID_RECRUIT  FROM GA_EXAM E ";
                query = query + "  INNER JOIN GA_RECRUITMENT_EXAM RE ON RE.EXAMID = E.ID";

                using (var cmd = new SqlCommand(query, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var exam = new Exam
                            {
                                Id = reader.GetInt32(0),
                                Name = reader["DSC_EXAM"].ToString(),
                                ExamId = reader.GetInt32(2)
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
