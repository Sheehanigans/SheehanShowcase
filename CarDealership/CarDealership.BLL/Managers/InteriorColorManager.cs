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
    public class InteriorColorManager
    {
        private IInteriorColorRepository Repo { get; set; }

        public InteriorColorManager(IInteriorColorRepository interiorColorRepository)
        {
            Repo = interiorColorRepository;
        }

        public TResponse<List<InteriorColor>> GetAll()
        {
            var response = new TResponse<List<InteriorColor>>();

            response.Payload = Repo.GetAll();

            if (!response.Payload.Any())
            {
                response.Message = "Could not load any interior colors";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
