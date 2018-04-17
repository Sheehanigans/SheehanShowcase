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
    public class ModelManager
    {
        private IModelRepository Repo { get; set; }

        public ModelManager(IModelRepository modelRepository)
        {
            Repo = modelRepository;
        }

        public TResponse<List<Model>> GetAllModels()
        {
            var response = new TResponse<List<Model>>();

            response.Payload = Repo.GetAllModels();

            if(response.Payload == null)
            {
                response.Message = "Unable to load models";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<Model> SaveModel(Model model)
        {
            var response = new TResponse<Model>();

            if(model == null)
            {
                response.Success = false;
                response.Message = "Model object was null";
            }
            else if(model.ModelName.Length > 50 
                || model.ModelName == null
                || model.Make.MakeId < 1)
            {
                response.Success = false;
                response.Message = "Model object parameters invalid";
            }
            else
            {
                response.Payload = Repo.Save(model);

                if (response.Payload == null)
                {
                    response.Message = $"Unable to save model {model.ModelName}";
                    response.Success = false;
                }
                else
                {
                    response.Success = true;
                }
            }           

            return response;
        }

        public TResponse<List<Model>> GetModelsByMakeId(int makeId)
        {
            var response = new TResponse<List<Model>>();

            if(makeId < 1)
            {
                response.Message = "Make Id invalid";
                response.Success = false;
            }
            else
            {
                response.Payload = Repo.GetModelsByMakeId(makeId);

                if (!response.Payload.Any())
                {
                    response.Message = $"Unable to load any models with make id {makeId}";
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
