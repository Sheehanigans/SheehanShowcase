using FOS.DATA;
using FOS.DATA.FileRepositories;
using FOS.DATA.Settings;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new TestOrderRepository(), new TestProductRepository(), new TestStateTaxRepository());
                case "Prod":
                    return new OrderManager(new FileOrderRepository(FilePaths.OrdersFilePath), new FileProductRepository(FilePaths.ProductsFilePath), new FileStateTaxRepository(FilePaths.StateTaxFilePath));
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }

    }
}
