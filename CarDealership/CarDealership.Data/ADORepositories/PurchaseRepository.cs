using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public Purchase SavePurchase(Purchase purchase)
        {
            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                cn.Execute(
                    "SavePurchase",
                    purchase,
                    commandType: System.Data.CommandType.StoredProcedure
                    );
            }

            return purchase;
        }
    }
}
