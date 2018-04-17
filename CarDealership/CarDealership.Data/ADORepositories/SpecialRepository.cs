using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class SpecialRepository : ISpecialRepository
    {
        public List<Special> GetSpecials()
        {
            List<Special> specials = new List<Special>();

            using(var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special row = new Special();

                        row.SpecialId = (int)dr["SpecialId"];
                        row.SpecialTitle = dr["SpecialTitle"].ToString();
                        row.SpecialMessage = dr["SpecialMessage"].ToString();

                        specials.Add(row);
                    }
                }
            }

            return specials;
        }

        public Special Save(Special special)
        {
            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                connection.Execute(
                    "SaveSpecial",
                    special,
                    commandType: CommandType.StoredProcedure
                    );
            }

            return special;
        }

        public bool DeleteSpecial(int id)
        {
            using (var connection = ConnectionStrings.GetOpenConnection())
            {

                var parameters = new DynamicParameters();
                parameters.Add("@SpecialId", id);

                connection.Execute(
                    "DeleteSpecial",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }

            return true;
        }
    }
}
