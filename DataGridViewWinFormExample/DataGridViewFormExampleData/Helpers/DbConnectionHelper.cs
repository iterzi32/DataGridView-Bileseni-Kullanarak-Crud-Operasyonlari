using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewFormExampleData.Helpers
{
    public class DbConnectionHelper
    {
        SqlConnection connection;
        public SqlConnection GetSqlConnection()
        {
            connection = new SqlConnection("server=.\\SQLExpress;database=ProductDb;integrated security=true");
            return connection;
        }
    }
}
