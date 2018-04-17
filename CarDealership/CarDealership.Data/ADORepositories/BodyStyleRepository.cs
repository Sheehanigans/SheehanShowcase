using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class BodyStyleRepository : IBodyStyleRepository
    {
        public List<BodyStyle> GetAll()
        {
            List<BodyStyle> bodies = new List<BodyStyle>();

            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                bodies = cn.Query<BodyStyle>(
                    "GetAllBodyStyles",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return bodies;
        }
    }
}
