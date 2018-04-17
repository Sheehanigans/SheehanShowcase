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
    public class ExteriorColorRepository : IExteriorColorRepository
    {
        public List<ExteriorColor> GetAll()
        {
            List<ExteriorColor> colors = new List<ExteriorColor>();

            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                colors = cn.Query<ExteriorColor>(
                    "GetAllExteriorColors",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return colors;
        }
    }
}
