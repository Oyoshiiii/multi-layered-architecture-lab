using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    interface IRepository<T> : IDisposable where T : IDomainObject, new()
    {
        void Add(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(T obj);
    }
}
