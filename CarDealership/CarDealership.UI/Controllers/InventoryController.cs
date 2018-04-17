using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        ListingManager _listingManager;

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Used()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            _listingManager = ListingManagerFactory.Create();

            var response = _listingManager.GetListingById(id);

            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
            }
            else
            {
                var model = new ListingVM();
                model.Listing = response.Payload;

                return View(model);
            }

        }
    }
}