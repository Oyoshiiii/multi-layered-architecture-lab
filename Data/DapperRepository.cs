using Dapper;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DapperRepository<T> : IRepository<T> where T : class, IDomainObject, new()
    {
        private string connectionString;
        private string tableName;
        private PropertyInfo[] properties;

        /// <summary>
        /// Инициализация репозитория для работы с сущностями через Dapper
        /// </summary>
        public DapperRepository()
        {
            connectionString = "Data Source=(LocalDB)\\" +
            "MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\kesha\\Desktop\\уник\\2 курс" +
            "\\аис\\lab 1\\Data\\DBProstheses.mdf\";Integrated Security=True";

            tableName = "Prosthesis";

            properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private void UseScript(string script, T entityParameters = null)
        {
            if (!string.IsNullOrEmpty(script))
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(script, entityParameters);
                }
            }
        }

        /// <summary>
        /// Добавление сущности в БД
        /// </summary>
        /// <param name="entity">Добавляемая сущность</param>
        public void Add(T entity)
        {
            var propertiesWithoutId = this.properties.Where(p => p.Name != "Id").ToArray();

            string columns = string.Join(", ", propertiesWithoutId.Select(p => p.Name));
            string values = string.Join(", ", propertiesWithoutId.Select(p => "@" + p.Name));

            string script = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            UseScript(script, entity);
        }

        /// <summary>
        /// Чтение всех сущностей из БД
        /// </summary>
        /// <returns>Лист сущностей</returns>
        public IEnumerable<T> ReadAll()
        {
            List<T> entities;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                entities = db.Query<T>($"SELECT * FROM {tableName}").ToList();
            }

            return entities;
        }

        /// <summary>
        /// Чтение сущности из БД по Id
        /// </summary>
        /// <param name="id">Id сущности</param>
        /// <returns>Найденная сущность</returns>
        public T ReadById(int id)
        {
            T entity;

            using(IDbConnection db = new SqlConnection(connectionString))
            {
                entity = db.Query<T>($"SELECT * FROM {tableName} WHERE Id = " + id).FirstOrDefault();
            }

            return entity;
        }

        /// <summary>
        /// Обновление сущности в БД
        /// </summary>
        /// <param name="entity">Обновляемая сущность</param>
        public void Update(T entity)
        {
            var id = properties.FirstOrDefault(p => p.Name == "Id");
            var propertiesWithoutId = this.properties.Where(p => p.Name != "Id").ToArray();

            string script = $"UPDATE {tableName} SET " + 
                string.Join(", ", propertiesWithoutId.Select(p => $"{p.Name} = @{p.Name}")) + 
                " WHERE Id = @Id";

            UseScript(script, entity);
        }

        /// <summary>
        /// Удаление сущности из БД
        /// </summary>
        /// <param name="entity">Удаляемая сущность</param>
        public void Delete(T entity)
        {
            var idProperty = properties.FirstOrDefault(p => p.Name == "Id");
            int id = (int)idProperty.GetValue(entity);

            string script = $"DELETE FROM {tableName} WHERE Id = @Id";

            UseScript(script, entity);
        }
    }
}
