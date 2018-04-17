using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //get managers
            ListingManager listingManager = ListingManagerFactory.Create();
            SpecialManager specialManager = SpecialManagerFactory.Create();

            //get responses 
            ListingFeaturedResponse listingFeaturedResponse = listingManager.GetFeaturedListings();
            SpecialGetAllResponse specialResponse = specialManager.GetAllSpecials();

            //validate responses
            if (!listingFeaturedResponse.Success || !specialResponse.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message:{listingFeaturedResponse.Message} {specialResponse.Message}");
            }
            else
            {
               //build vm
               HomeVM model = new HomeVM();

                model.SetFeaturedListingItems(listingFeaturedResponse.Listings);
                model.SetSpecialItems(specialResponse.Specials);

                return View(model);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string vin)
        {
            var model = new ContactFormVM();

            if (!string.IsNullOrEmpty(vin))
            {
                model.ContactForm = new ContactForm
                {
                    FormMessage = vin
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactFormVM model)
        {
            if (ModelState.IsValid)
            {
                ContactFormManager manager = ContactFormManagerFactory.Create();
                var response = manager.AddContactForm(model.ContactForm);
                if (!response.Success)
                {
                    return new HttpStatusCodeResult(500, $"Error in cloud. {response.Message}");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View("Contact", model);
            }
        }



        public ActionResult Specials()
        {
            //get manager
            SpecialManager manager = SpecialManagerFactory.Create();

            //get response 
            SpecialGetAllResponse response = manager.GetAllSpecials();

            //validate 
            if (!response.Success)
            {
                return new HttpStatusCodeResult(500, $"Error in cloud. Message: {response.Message}");
            }
            else
            {
                //create vm
                SpecialListVM model = new SpecialListVM();
                model.SetSpecialItems(response.Specials);

                return View(model);
            }
        }
    }
}