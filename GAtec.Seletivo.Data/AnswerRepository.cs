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
    class AnswerRepository
    {
        public void Add(Answer item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into GA_ANSWER(Description, QuestionId, RightAnswer) " +
                                                "values (@description, @questionId, @rightAnswer)", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
                    cmd.Parameters.Add("questionId", SqlDbType.Int).Value = item.QuestionId;
                    cmd.Parameters.Add("rightAnswer", SqlDbType.Int).Value = item.RightAnswer;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Answer item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("update GA_ANSWER set " +
                                                "Description = @description, " +
                                                "QuestionId = @questionId," +
                                                "RightAnswer = @rightAnswer," +
                                                "where Id = @id", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
                    cmd.Parameters.Add("questionId", SqlDbType.Int).Value = item.QuestionId;
                    cmd.Parameters.Add("rightAnswer", SqlDbType.Int).Value = item.RightAnswer; 
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

                using (var cmd = new SqlCommand("delete from GA_ANSWER where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Answer Get(object id)
        {
            Answer answer = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Description, QuestionId, RightAnswer from GA_ANSWER where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            answer = new Answer
                            {

                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                QuestionId = reader.GetInt32(2),
                                RightAnswer = reader.GetBoolean(3)
                            };

                        }

                    }
                }

            }
            return answer;
        }

        public IEnumerable<Answer> GetAll()
        {
            var answers = new List<Answer>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Description, QuestionId, RightAnswer from GA_ANSWER", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var answer = new Answer
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                QuestionId = reader.GetInt32(2),
                                RightAnswer = reader.GetBoolean(3)

                            };

                            answers.Add(answer);
                        }

                    }
                }

            }
            return answers;
        }
    }
}
