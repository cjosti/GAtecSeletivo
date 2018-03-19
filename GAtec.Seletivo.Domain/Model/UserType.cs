using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    public class UserType
    {
        public int Type { get; set; }
        public int Teste;
        public static readonly byte Admin = 0;
        public static readonly byte Candidate = 1;
    }
}
