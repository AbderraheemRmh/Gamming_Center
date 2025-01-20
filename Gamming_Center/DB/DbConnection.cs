using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamming_Center.DB
{
    public abstract class DbConnection
    {
        private readonly string connectionString;
        public DbConnection()
        {
            connectionString = "Data Source=GammingCenter.db;Version=3;";
        }
        protected SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
