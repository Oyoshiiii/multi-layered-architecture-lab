using Dapper;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

        public DapperRepository()
        {
            connectionString = "Data Source=(LocalDB)\\" +
            "MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\kesha\\Desktop\\уник\\2 курс" +
            "\\аис\\lab 1\\Data\\DBProstheses.mdf\";Integrated Security=True";

            tableName = "Prostheses";

            properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        private void UseScript(string script)
        {
            if (!string.IsNullOrEmpty(script))
            {
                using(IDbConnection db = new SqlConnection(connectionString))
                {
                    db.Execute(script);
                }
            }
        }

        public void Add(T obj)
        {
            var propertiesWithoutId = this.properties.Where(p => p.Name != "Id").ToArray();

            string columns = "";
            string values = "";
            foreach (var prop in propertiesWithoutId)
            {
                columns += prop.Name + ", ";
                values += "@" + prop.Name + ", ";
            }

            string script = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            UseScript(script);
        }
        public IEnumerable<T> ReadAll()
        {
            List<T> entities;

            using (IDbConnection db = new SqlConnection(connectionString))
            {
                entities = db.Query<T>($"SELECT * FROM {tableName}").ToList();
            }

            return entities;
        }

        public T ReadById(int id)
        {
            T entity;

            using(IDbConnection db = new SqlConnection(connectionString))
            {
                entity = db.Query<T>($"SELECT * FROM {tableName} WHERE Id = " + id).FirstOrDefault();
            }

            return entity;
        }

        public void Update(T obj)
        {
            var id = properties.FirstOrDefault(p => p.Name == "Id");
            var propertiesWithoutId = this.properties.Where(p => p.Name != "Id").ToArray();

            string script = $"UPDATE {tableName} SET ";

            foreach (var prop in propertiesWithoutId)
            {
                script += prop.Name + " = @" + prop.Name + ", ";
            }

            script += " WHERE Id = " + id;

            UseScript(script);
        }

        public void Delete(T obj)
        {
            var id = properties.FirstOrDefault(p => p.Name == "Id");
            string script = $"DELETE FROM {tableName} WHERE Id = " + id;

            UseScript(script);
        }
    }
}
