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
    public class AnswerService : IAnswerService
    {
        private IAnswerRepository AnswerRepository { get; set; }

        public IValidationError Validator { get; set; }

        public AnswerService(IAnswerRepository answerRepository,
                               IValidationError validator)
        {
            this.AnswerRepository = answerRepository;
            this.Validator = validator;
        }

        public bool Add(Answer answer)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(answer.Description))
            {
                Validator.AddError("Description", "A descrição é obrigatório");
                Error = true;
            }
           
            if (Error)
            {
                return false;
            }

            AnswerRepository.Add(answer);

            return true;
        }

        public bool Update(Answer answer)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(answer.Description))
            {
                Validator.AddError("Description", "A descrição é obrigatório");
                Error = true;
            }

            if (Error)
            {
                return false;
            }

            AnswerRepository.Update(answer);
            return true;
        }

        public bool Delete(int id)
        {
            AnswerRepository.Delete(id);
            return true;
        }

        public Answer Get(int id)
        {
            var exam = AnswerRepository.Get(id);
            return exam;
        }

        public IEnumerable<Answer> GetAll()
        {
            var answers = AnswerRepository.GetAll();

            return answers;
        }

        public IEnumerable<Answer> GetAnswersByQuestion(int id)
        {
            var answers = AnswerRepository.GetAnswersByQuestion(id);

            return answers;
        }

    }

}
