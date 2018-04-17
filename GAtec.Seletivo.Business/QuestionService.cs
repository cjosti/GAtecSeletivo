using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool Add(Exam exam)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(exam.Name))
            {
                Validator.AddError("Name", "O nome é obrigatório");
                Error = true;
            }

            if (Error)
            {
                return false;
            }

            ExamRepository.Add(exam);

            return true;
        }

        public bool Update(Exam exam)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(exam.Name))
            {
                Validator.AddError("Name", "O nome é obrigatório");
                Error = true;
            }

            if (Error)
            {
                return false;
            }

            ExamRepository.Update(exam);
            return true;
        }

        public bool Delete(int id)
        {
            ExamRepository.Delete(id);
            return true;
        }

        public Exam Get(int id)
        {
            var exam = ExamRepository.Get(id);
            return exam;
        }

        public IEnumerable<Exam> GetAll()
        {
            var exams = ExamRepository.GetAll();

            return exams;
        }
    }
}
