﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAtec.Seletivo.Domain.Model;

namespace GAtec.Seletivo.Domain.Repository
{
    public interface IAnswerRepository: IBaseRepository<Answer>
    {
        IEnumerable <Answer> GetAnswersByQuestion(object id);
    }
}
