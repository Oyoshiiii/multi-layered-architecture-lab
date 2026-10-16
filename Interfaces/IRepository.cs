using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        /// <summary>
        /// Добавление сущности в БД
        /// </summary>
        /// <param name="obj">Добавляемая сущность</param>
        void Add(T obj);

        /// <summary>
        /// Чтение всех сущностей из БД
        /// </summary>
        /// <returns>Коллекция перебираемых сущностей из БД</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Чтение сущности из БД по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Искомая сущность по Id</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновление сущности в БД
        /// </summary>
        /// <param name="obj">Обновляемая сущность</param>
        void Update(T obj);

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        /// <param name="obj">Удаляемая сущность</param>
        void Delete(T obj);
    }
}
