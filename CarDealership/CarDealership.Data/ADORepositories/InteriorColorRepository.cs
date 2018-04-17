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
    public class InteriorColorRepository : IInteriorColorRepository
    {
        public List<InteriorColor> GetAll()
        {
            List<InteriorColor> colors = new List<InteriorColor>();

            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                colors = cn.Query<InteriorColor>(
                    "GetAllInteriorColors",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return colors;
        }
    }
}
