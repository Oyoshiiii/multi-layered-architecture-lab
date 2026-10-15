using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DBContext : DbContext
    {
        public DbSet<Prosthesis> Prostheses { get; set; }

        public DBContext() : base("Data Source=(LocalDB)\\" +
            "MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\kesha\\Desktop\\уник\\2 курс" +
            "\\аис\\lab 1\\Data\\DBProstheses.mdf\";Integrated Security=True") { }
    }
}
