using CarDealership.BLL.Managers;
using CarDealership.Data.ADORepos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Factories
{
    public class StateManagerFactory
    {
        public static StateManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "QA":
                    return new StateManager(new StateRepository());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }
    }
}

