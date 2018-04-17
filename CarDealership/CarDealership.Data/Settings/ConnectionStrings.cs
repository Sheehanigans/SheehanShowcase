using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Settings
{
    public class ConnectionStrings
    {

        public static SqlConnection GetOpenConnection()
        {
            const string connectionString = "server=(local);database=CarDealership;Trusted_Connection=True;";

            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                _connectionString = ConfigurationManager.ConnectionStrings["CarDealership"].ConnectionString;

            return _connectionString;
        }


        //this should go in another class
        private static string _repositoryType;

        public static string GetRepositoryType()
        {
            if (string.IsNullOrEmpty(_repositoryType))
                _repositoryType = ConfigurationManager.AppSettings["RepositoryType"].ToString();

            return _repositoryType;
        }
    }
}
