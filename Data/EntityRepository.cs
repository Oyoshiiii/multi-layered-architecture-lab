using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        private DBContext _context;

        public EntityRepository(DBContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            var origin = _context.Set<T>().Find(entity.Id);
            if (origin == null) return;

            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id");
            foreach (var prop in properties)
            {
                prop.SetValue(origin, prop.GetValue(entity));
            }

            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
