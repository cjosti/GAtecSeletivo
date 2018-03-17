using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Model
{
    class Recruitment
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public DateTime data { get; set; }

        public IList<User> users { get; set; }
    }
}
