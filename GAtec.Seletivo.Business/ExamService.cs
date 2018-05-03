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
    public class ExamService : IExamService
    {
        private IExamRepository ExamRepository { get; set; }

        public IValidationError Validator { get; set; }

        public ExamService(IExamRepository examRepository,
                               IValidationError validator)
        {
            this.ExamRepository = examRepository;
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

        public IEnumerable<Exam> GetExamByRecruitment(int id)
        {
            var exam = ExamRepository.GetExamByRecruitment(id);

            return exam;
        }

        public IEnumerable<Exam> GetExamList()
        {
            var exam = ExamRepository.GetExamList();

            return exam;
        }

    }

}
