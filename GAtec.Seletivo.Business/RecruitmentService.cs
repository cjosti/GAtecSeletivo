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
    public class RecruitmentService : IRecruitmentService
    {
        private IRecruitmentRepository RecruitmentRepository { get; set; }

        public IValidationError Validator { get; set; }

        public RecruitmentService(IRecruitmentRepository recruitmentRepository,
                               IValidationError validator)
        {
            this.RecruitmentRepository = recruitmentRepository;
            this.Validator = validator;
        }

        public bool Add(Recruitment recruitment)
        {
            bool Error = false;

            if(string.IsNullOrEmpty(recruitment.Description))
            {
                Validator.AddError("Description", "A descrição é obrigatória");
                Error = true;
            }

            //Validar a data [VALIDAR]

            if (Error)
            {
                return false;
            }

            RecruitmentRepository.Add(recruitment);

            return true;
        }

        public bool Update(Recruitment recruitment)
        {
            bool Error = false;

            if (string.IsNullOrEmpty(recruitment.Description))
            {
                Validator.AddError("Description", "A descrição é obrigatória");
                Error = true;
            }

            //Validar a data [VALIDAR]

            if (Error)
            {
                return false;
            }

            RecruitmentRepository.Update(recruitment);

            return true;
        }

        public bool Delete(int id)
        {
            RecruitmentRepository.Delete(id);
            return true;
        }

        public Recruitment Get(int id)
        {
            var recruitment = RecruitmentRepository.Get(id);
            return recruitment;
        }

        public IEnumerable<Recruitment> GetAll()
        {
            var recruitment = RecruitmentRepository.GetAll();

            return recruitment;
        }

    }
}
