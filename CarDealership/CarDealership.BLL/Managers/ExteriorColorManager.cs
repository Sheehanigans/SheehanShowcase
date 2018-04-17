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
    public class ExteriorColorManager
    {
        private IExteriorColorRepository Repo { get; set; }

        public ExteriorColorManager(IExteriorColorRepository exteriorColorRepository)
        {
            Repo = exteriorColorRepository;
        }

        public TResponse<List<ExteriorColor>> GetAll()
        {
            var response = new TResponse<List<ExteriorColor>>();

            response.Payload = Repo.GetAll();

            if (!response.Payload.Any())
            {
                response.Message = "Could not load any exterior colors";
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
