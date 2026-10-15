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

        /// <summary>
        /// Инициализация репозитория для работы с сущностями через Entity Framework
        /// </summary>
        /// <param name="context">Контекст для доступа к БД</param>
        public EntityRepository(DBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Добавление сущности в БД
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Чтение всех сущностей из БД
        /// </summary>
        /// <returns>Лист сущностей</returns>
        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        /// <summary>
        /// Чтение сущности по Id из БД
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Сущность</returns>
        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        /// Обновление сущности в БД
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
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

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
