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
    public class SpecialManager
    {
        private ISpecialRepository Repo { get; set; }

        public SpecialManager(ISpecialRepository specialRepository)
        {
            Repo = specialRepository;
        }

        public SpecialGetAllResponse GetAllSpecials()
        {
            var response = new SpecialGetAllResponse();

            response.Specials = Repo.GetSpecials();

            if (!response.Specials.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<Special> SaveSpecial(Special special)
        {
            var response = new TResponse<Special>();

            response.Payload = Repo.Save(special);

            if(response.Payload == null)
            {
                response.Success = false;
                response.Message = "Special unsuccessfully added";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<Special> DeleteSpecial(int id)
        {
            var response = new TResponse<Special>();

            if (id < 0)
            {
                response.Success = false;
                response.Message = $"Special Id less than 0. Deleted usuccessfully ID {id}";
            }
            else
            {
                bool specialDeleted = Repo.DeleteSpecial(id);

                if (!specialDeleted)
                {
                    response.Message = $"Special repository error for Special Id {id}";
                    response.Success = false;
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
