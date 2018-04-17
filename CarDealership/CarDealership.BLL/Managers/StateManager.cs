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
    public class StateManager
    {
        private IStateRepository Repo { get; set; }

        public StateManager(IStateRepository stateRepository)
        {
            Repo = stateRepository;
        }

        public TResponse<State> GetStateById(int stateId)
        {
            var response = new TResponse<State>();

            if(stateId < 1)
            {
                response.Message = "Invalid state Id";
                response.Success = false;
            }
            else
            {
                response.Payload = Repo.GetState(stateId);

                if (response.Payload.StateId != stateId)
                {
                    response.Success = false;
                    response.Message = $"State Id {stateId} was not found.";
                }
                else
                {
                    response.Success = true;
                }
            }

            return response;
        }

        public TResponse<List<State>> GetAllStates()
        {
            var response = new TResponse<List<State>>();

            response.Payload = Repo.GetAll();

            if(response.Payload == null)
            {
                response.Success = false;
                response.Message = "Unable to retrieve all states";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}
