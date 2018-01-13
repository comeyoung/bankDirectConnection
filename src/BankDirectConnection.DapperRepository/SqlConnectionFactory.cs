using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.DapperRepository
{
    public class SqlConnectionFactory
    {
        public static IDbConnection CreateSqlConnection()
        {
            IDbConnection connection = null;
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
                connection = new System.Data.SqlClient.SqlConnection(strConn);
                return connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
