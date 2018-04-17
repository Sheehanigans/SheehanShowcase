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
    [Authorize(Roles = "Sales, Admin")]
    public class SalesController : Controller
    {
        ListingManager _listingManager;
        StateManager _stateManager;
        PurchaseManager _purchaseManager;

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase(int id)
        {
            try
            {
                _listingManager = ListingManagerFactory.Create();
                _stateManager = StateManagerFactory.Create();

                var listingResponse = _listingManager.GetListingById(id);

                if (!listingResponse.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. Message:{listingResponse.Message}");
                }
                else
                {
                    var model = new PurchaseListingVM
                    {
                        ListingToPurchase = listingResponse.Payload,
                        PurchaseForm = new Purchase()
                    };

                    var stateResponse = _stateManager.GetAllStates();

                    model.States = stateResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.StateAbbreviation,
                        Value = m.StateId.ToString()
                    });

                    return View(model);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something wrong happened while loading a purchase:", ex);
            }

        }

        [HttpPost]
        public ActionResult Purchase(PurchaseListingVM model)
        {
            _purchaseManager = PurchaseManagerFactory.Create();
            _stateManager = StateManagerFactory.Create();
            _listingManager = ListingManagerFactory.Create();

            try
            {
                var listingResponse = _listingManager.GetListingById(model.ListingToPurchase.ListingId);

                model.ListingToPurchase = listingResponse.Payload;

                if (ModelState.IsValid)
                {
                    //set sold listing in db


                    //set user name 
                    model.PurchaseForm.UserName = User.Identity.Name;

                    //set listing id 
                    model.PurchaseForm.ListingId = model.ListingToPurchase.ListingId;

                    //set date 
                    model.PurchaseForm.DateAdded = DateTime.Now;



                    //send to manager 
                    var response = _purchaseManager.SavePurchase(model.PurchaseForm);

                    if (!response.Success)
                    {
                        return new HttpStatusCodeResult(500, $"Error in cloud. Message:{response.Message}");
                    }
                }
                else
                {
                    var stateResponse = _stateManager.GetAllStates();

                    model.States = stateResponse.Payload.Select(m => new SelectListItem
                    {
                        Text = m.StateAbbreviation,
                        Value = m.StateId.ToString()
                    });


                    return View(model);
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Something wrong happened while loading a purchase:", ex);
            }

        }
    }
}