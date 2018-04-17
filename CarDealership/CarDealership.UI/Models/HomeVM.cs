using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class HomeVM
    {
        public List<Listing> FeaturedListings { get; set; }
        public List<Special> Specials { get; set; }

        public HomeVM()
        {
            FeaturedListings = new List<Listing>();
            Specials = new List<Special>();
        }

        public void SetFeaturedListingItems(IEnumerable<Listing> listings)
        {
            foreach (var listing in listings)
            {
                FeaturedListings.Add(listing);
            }
        }

        public void SetSpecialItems(IEnumerable<Special> specials)
        {
            foreach (var special in specials)
            {
                Specials.Add(special);
            }
        }
    }
}