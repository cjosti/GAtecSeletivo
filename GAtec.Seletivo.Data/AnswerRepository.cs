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

                using (var cmd = new SqlCommand("INSERT INTO GA_ANSWER(DESCRIPTION, RIGHTANSWER, QUESTIONID) " +
                                                "VALUES (@description, @questionId, @rightAnswer)", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;                    
                    cmd.Parameters.Add("rightAnswer", SqlDbType.Int).Value = item.RightAnswer;
                    cmd.Parameters.Add("questionId", SqlDbType.Int).Value = item.QuestionId;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Answer item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("UPDATE GA_ANSWER SET " +
                                                "DESCRIPTION = @description, " +
                                                "RIGTHANSWER = @rightAnswer," +
                                                "QUESTIONID = @questionId," +
                                                "WHERE ID = @id", con))
                {
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
                    cmd.Parameters.Add("rightAnswer", SqlDbType.Int).Value = item.RightAnswer;
                    cmd.Parameters.Add("questionId", SqlDbType.Int).Value = item.QuestionId;
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

                using (var cmd = new SqlCommand("DELETE FROM GA_ANSWER WHERE ID = @id", con))
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, RIGHTANSWER, QUESTIONID FROM GA_ANSWER WHERE ID = @id", con))
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
                                RightAnswer = reader.GetBoolean(2),
                                QuestionId = reader.GetInt32(3),
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, RIGHTANSWER, QUESTIONID FROM GA_ANSWER", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var answer = new Answer
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                RightAnswer = reader.GetBoolean(2),
                                QuestionId = reader.GetInt32(3)

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
