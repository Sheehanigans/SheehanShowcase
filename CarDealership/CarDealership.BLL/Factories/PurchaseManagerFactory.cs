using CarDealership.BLL.Managers;
using CarDealership.Data.ADORepositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Factories
{
    public class PurchaseManagerFactory
    {
        public static PurchaseManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new PurchaseManager(new PurchaseRepository());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }
    }
}
