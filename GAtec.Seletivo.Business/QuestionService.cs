using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;
using GAtec.Seletivo.Domain.Business;
using GAtec.Seletivo.Domain.Repository;
using GAtec.Seletivo.Util;

namespace GAtec.Seletivo.Business
{
    public class QuestionService: IQuestionService
    {
        private IQuestionRepository QuestionRepository { get; set; }

        public IValidationError Validator { get; set; }

        public QuestionService(IQuestionRepository questionRepository,
                               IValidationError validator)
        {
            this.QuestionRepository = questionRepository;
            this.Validator = validator;
        }

        public bool Add(Question question)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(question.Description))
            {
                Validator.AddError("Description", "O nome é obrigatório");
                Error = true;
            }

            if (Error)
            {
                return false;
            }

            QuestionRepository.Add(question);

            return true;
        }

        public bool Update(Question question)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(question.Description))
            {
                Validator.AddError("Description", "O nome é obrigatório");
                Error = true;
            }

            if (Error)
            {
                return false;
            }

            QuestionRepository.Update(question);
            return true;
        }

        public bool Delete(int id)
        {
            QuestionRepository.Delete(id);
            return true;
        }

        public Question Get(int id)
        {
            var question = QuestionRepository.Get(id);
            return question;
        }

        public IEnumerable<Question> GetAll()
        {
            var questions = QuestionRepository.GetAll();

            return questions;
        }
    }
}
