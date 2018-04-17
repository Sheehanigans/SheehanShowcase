using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class ModelsVM
    {
        public List<Model> Models { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
        public Model NewModel { get; set; }

        public ModelsVM()
        {
            Models = new List<Model>();
            NewModel = new Model();
        }

        public void SetModelItems(IEnumerable<Model> models)
        {
            foreach (var model in models)
            {
                Models.Add(model);
            }
        }    
    }
}