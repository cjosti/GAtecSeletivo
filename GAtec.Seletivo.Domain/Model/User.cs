using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    class User
    {
        public int id { get; set; }

        public string name { get; set; }

        public string user { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public UserType type { get; set; }
        
    }
}
