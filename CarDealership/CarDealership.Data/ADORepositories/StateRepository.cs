using CarDealership.Data.Settings;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepos
{
    public class StateRepository : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> states; 

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                states = connection.Query<State>(
                    "StatesSelectAll",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return states;
        }

        public State GetState(int stateId)
        {
            State stateToReturn;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@StateId", stateId);

                stateToReturn = connection.Query<State>(
                    "GetState",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).SingleOrDefault();
            }

            return stateToReturn;
        }
    }
}