using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Data.Connections
{
    class ADODatabaseConnection
    {
        public static SqlConnection GetOpenConnection()
        {
            const string connectionString = "server=(local);database=DvdLibrary;User Id=DvdLibraryApp; Password=testing123;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
