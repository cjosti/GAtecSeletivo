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
    class QuestionRepository
    {
        public void Add(Question item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("insert into GA_QUESTION (Description, Type, Score) " +
                                                "values (@description, @type, @score)", con))
                {                    
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
                    cmd.Parameters.Add("type", SqlDbType.Int).Value = item.Type;
                    cmd.Parameters.Add("score", SqlDbType.Int).Value = item.Score;

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Update(Question item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("update GA_QUESTION set " +
                                                "Description = @description, " +
                                                "Type = @type, " +
                                                "Score = @score" +
                                                "where Id = @id", con))
                {                   
                    cmd.Parameters.Add("description", SqlDbType.NVarChar).Value = item.Description;
                    cmd.Parameters.Add("type", SqlDbType.Int).Value = item.Type;
                    cmd.Parameters.Add("score", SqlDbType.Int).Value = item.Score;
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

                using (var cmd = new SqlCommand("delete from GA_QUESTION where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Question Get(object id)
        {
            Question question = null;

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Description, Type, Score from GA_QUESTION where Id = @id", con))
                {
                    cmd.Parameters.Add("id", SqlDbType.Int).Value = id;

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            question = new Question
                            {

                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Type = reader.GetInt32(2),
                                Score = reader.GetInt32(3)
                            };

                        }

                    }
                }

            }
            return question;
        }

        public IEnumerable<Question> GetAll()
        {
            var questions = new List<Question>();

            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("select Id, Description, Type, Score from GA_QUESTION", con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var question = new Question
                            {
                                Id = reader.GetInt32(0),
                                Description = reader["Description"].ToString(),
                                Type = reader.GetInt32(2),
                                Score = reader.GetInt32(3)

                            };

                            questions.Add(question);
                        }

                    }
                }

            }
            return questions;
        }
    }
}
