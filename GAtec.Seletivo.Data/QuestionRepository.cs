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
    class QuestionRepository: IQuestionRepository
    {
        public void Add(Question item)
        {
            using (var con = new SqlConnection(SeletivoSettings.connectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("INSERT INTO GA_QUESTION (DESCRIPTION, TYPE, SCORE) " +
                                                "VALUES (@description, @type, @score)", con))
                {                    
                    cmd.Parameters.Add("description", SqlDbType.VarChar).Value = item.Description;
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

                using (var cmd = new SqlCommand("UPDATE GA_QUESTION SET " +
                                                "DESCRIPTION = @description, " +
                                                "TYPE = @type, " +
                                                "SCORE = @score" +
                                                "WHERE ID = @id", con))
                {                   
                    cmd.Parameters.Add("description", SqlDbType.VarChar).Value = item.Description;
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

                using (var cmd = new SqlCommand("DELETE FROM GA_QUESTION WHERE ID = @id", con))
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, TYPE, SCORE FROM GA_QUESTION WHERE ID = @id", con))
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

                using (var cmd = new SqlCommand("SELECT ID, DESCRIPTION, TYPE, SCORE FROM GA_QUESTION", con))
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
