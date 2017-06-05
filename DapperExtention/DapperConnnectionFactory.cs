using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperExtention
{
    public class DapperConnnectionFactory
    {
        private static readonly string connectionString;
        private static readonly string databaseType;

        static DapperConnnectionFactory()
        {
            var collection = ConfigurationManager.ConnectionStrings["connectionString"];
            connectionString = collection.ConnectionString;
            databaseType = collection.ProviderName.ToLower();
        }

        public static IDbConnection CreateDbConnection()
        {
            IDbConnection connection = null;
            switch (databaseType)
            {
                case "system.data.sqlclient":
                    //connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
                case "system.data.mysqlclient":
                    connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    break;
                case "oracle":
                    //connection = new Oracle.DataAccess.Client.OracleConnection(connectionString);
                    //connection = new System.Data.OracleClient.OracleConnection(connectionString);
                    break;
                case "db2":
                    connection = new System.Data.OleDb.OleDbConnection(connectionString);
                    break;
                default:
                    connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;
            }
            return connection;
        }
    }
}
