using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class MakeManager
    {
        private IMakeRepository Repo { get; set; }

        public MakeManager(IMakeRepository makeRepository)
        {
            Repo = makeRepository;
        }

        public TResponse<List<Make>> GetAllMakes()
        {
            var response = new TResponse<List<Make>>();

            response.Payload = Repo.GetMakes();

            if (response.Payload == null)
            {
                response.Success = false;
                response.Message = "Unable to load makes";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<Make> SaveMake(Make make)
        {
            var response = new TResponse<Make>();

            if (make == null)
            {
                response.Success = false;
                response.Message = "No Make object recived in manager";
            }
            else if (make.MakeName == null || make.MakeName.Length > 50)
            {
                response.Success = false;
                response.Message = "Make object paramters invalid";
            }
            else
            {
                response.Payload = Repo.Save(make);

                if (response.Payload == null)
                {
                    response.Success = false;
                    response.Message = $"failed to save Make {make.MakeName}";
                }
                else
                {
                    response.Success = true;
                }
            }            

            return response;
        }
    }
}
