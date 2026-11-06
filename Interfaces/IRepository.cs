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
        /// Добавление сущности в БД; если obj null - ничего не происходит
        /// </summary>
        /// <param name="obj">Добавляемая сущность</param>
        void Add(T obj);

        /// <summary>
        /// Чтение всех сущностей из БД; если сущностей нет, возвр пустая коллекция
        /// </summary>
        /// <returns>Коллекция перебираемых сущностей из БД или пустая коллекция</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Чтение сущности из БД по Id; если сущности нет с данным Id, возвр null
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Искомая сущность по Id или null</returns>
        T ReadById(int id);

        /// <summary>
        /// Обновление сущности в БД; obj не null; если не найдена сущность, ничего не происходит
        /// </summary>
        /// <param name="obj">Обновляемая сущность</param>
        void Update(T obj);

        /// <summary>
        /// Удаление сущности из БД; obj не null; если не найдена сущность, ничего не происходит
        /// </summary>
        /// <param name="obj">Удаляемая сущность</param>
        void Delete(T obj);
    }
}
