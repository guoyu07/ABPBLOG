using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABPBLOGRepository
{
    public class DateBase
    {
        private static readonly string connectionstring = ConfigurationManager.ConnectionStrings["ABPBLOG"].ToString();
        // 得到工厂提供器类型  
        private static readonly string ProviderFactoryString = ConfigurationManager.AppSettings["DBProvider"].ToString();
        private static DbProviderFactory dbfactory = null;
        private static readonly object locker = new object();
        private static IDbConnection _connection ;

        public static IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    lock (locker)
                    {
                        if (_connection==null)
                        {
                            if (dbfactory==null)
                            {
                                dbfactory = DbProviderFactories.GetFactory(ProviderFactoryString);
                            }
                            var _connection = dbfactory.CreateConnection();
                            _connection.ConnectionString = connectionstring;
                            _connection.Open();
                            return _connection;
                        }
                    }
                }
                return _connection;
            }
        }
    }
}
