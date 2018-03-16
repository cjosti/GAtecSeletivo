using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Seletivo.Domain.Repository
{
    interface IBaseRepository<T>
    {
        void add(T item);

        void update(T item);

        void delete(object id);

        T Get(object id);

        IEnumerable<T> GetAll();
    }
}
