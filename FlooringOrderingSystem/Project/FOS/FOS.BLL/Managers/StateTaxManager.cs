using FOS.MODELS.Interfaces;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.Managers
{
    public class StateTaxManager
    {
        private IStateTaxRepository _stateTaxRepository;

        public StateTaxManager(IStateTaxRepository stateTaxRepository)
        {
            _stateTaxRepository = stateTaxRepository;
        }

        public StateTaxResponse GetStateTax(string stateAbbreviation)
        {
            StateTaxResponse response = new StateTaxResponse();

            response.State = _stateTaxRepository.GetState(stateAbbreviation);
            
            if (response.State == null)
            {
                response.Success = false;
                response.Message = $"State {stateAbbreviation} does not exist.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }
    }
}