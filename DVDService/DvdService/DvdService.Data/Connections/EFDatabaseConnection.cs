using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Data.Connections
{
    public class EFDatabaseConnection
    {
        public static SqlConnection GetOpenConnection()
        {
            const string connectionString = "Server=localhost;Database=DvdLibraryEF;Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }   
    }
}
