using FOS.BLL.Factories;
using FOS.BLL.Managers;
using FOS.MODELS.Models;
using FOS.MODELS.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.BLL.DataValidations
{
    public class StateTaxValidation
    {
        public static StateTaxResponse CreateStateTax(string stateAbbreviation)
        {
            StateTaxManager manager = StateTaxManagerFactory.Create();

            StateTaxResponse stResponse = manager.GetStateTax(stateAbbreviation);

            if (stResponse.Success)
            {
                return stResponse;
            }
            else
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(stResponse.Message);
            }

            return stResponse;
        }
    }
}
