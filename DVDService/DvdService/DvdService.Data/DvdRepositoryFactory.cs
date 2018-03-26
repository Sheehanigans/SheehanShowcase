using DvdService.Data.ADORepos;
using DvdService.Data.Connections;
using DvdService.Data.Entities;
using DvdService.Data.EntityFrameworkRepos;
using DvdService.Data.Interfaces;
using DvdService.Data.MemoryRepos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdService.Data
{
    public class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new InMemoryDvdRepo();
                case "ADO":
                    return new ADODvdRepo();
                case "EntityFramework":
                    return new EFDvdRepo(new DvdLibraryEntities());
                default:
                    throw new Exception("Mode value in app.config file is invalid");
            }
        }
    }
}
