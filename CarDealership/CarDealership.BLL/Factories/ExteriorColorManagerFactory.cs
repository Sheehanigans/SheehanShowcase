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
    public class ExteriorColorManagerFactory
    {
        public static ExteriorColorManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new ExteriorColorManager(new ExteriorColorRepository());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }
    }
}
