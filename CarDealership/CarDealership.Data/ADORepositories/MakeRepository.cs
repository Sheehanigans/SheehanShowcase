using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class MakeRepository : IMakeRepository
    {
        public List<Make> GetMakes()
        {
            List<Make> makes = new List<Make>();

            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                makes = cn.Query<Make>(
                    "GetMakes",
                    commandType: System.Data.CommandType.StoredProcedure
                    ).ToList();
            }

            return makes;
        }

        public Make Save(Make make)
        {
            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                cn.Execute(
                    "SaveMake",
                    make,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }

            return make;
        }
    }
}
