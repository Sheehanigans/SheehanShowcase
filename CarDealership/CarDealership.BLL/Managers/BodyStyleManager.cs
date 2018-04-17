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
    public class BodyStyleManager
    {
        private IBodyStyleRepository Repo { get; set; }

        public BodyStyleManager(IBodyStyleRepository bodyStyleRepository)
        {
            Repo = bodyStyleRepository;
        }

        public TResponse<List<BodyStyle>> GetAll()
        {
            var response = new TResponse<List<BodyStyle>>();

            response.Payload = Repo.GetAll();

            if (!response.Payload.Any())
            {
                response.Success = false;
                response.Message = "Could not load any body styles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
