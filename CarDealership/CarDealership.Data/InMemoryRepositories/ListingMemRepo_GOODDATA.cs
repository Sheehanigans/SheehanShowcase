using CarDealership.Models.Enums;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryRepositories
{
    public class ListingMemRepo_GOODDATA : IListingRepository
    {
        private List<Listing> _mockListings = new List<Listing>();

        public ListingMemRepo_GOODDATA()
        {
            MockListingRepository();
        }

        public void MockListingRepository()
        {
            if (!_mockListings.Any())
            {
                _mockListings.AddRange(new List<Listing>()
                {
                    new Listing
                    {
                        ListingId = 1,
                        ModelId = 1,
                        BodyStyleId = 2,
                        InteriorColorId = 1,
                        ExteriorColorId = 1,
                        Condition = Condition.New,
                        Transmission =Transmission.Manual,
                        Mileage = 25000,
                        ModelYear = 2019,
                        VIN = "FTW12345BLAHHEY69",
                        MSRP = 30000.00M,
                        SalePrice = 29000.00M,
                        VehicleDescription = "This little guy is a lot of fun",
                        ImageFileUrl = "cx3.jpg",
                        IsFeatured = false,
                        IsSold = false,
                    },

                    new Listing
                    {
                        ListingId = 2,
                        ModelId = 2,
                        BodyStyleId = 1,
                        InteriorColorId = 2,
                        ExteriorColorId = 2,
                        Condition = Condition.Used,
                        Transmission =Transmission.Automatic,
                        Mileage = 200000,
                        ModelYear = 1995,
                        VIN = "JEEP229900HEYYO",
                        MSRP = 15000.00M,
                        SalePrice = 14000.00M,
                        VehicleDescription = "Hey did you see that road there? Yeah neither did I.",
                        ImageFileUrl = "95wrangler.jpg",
                        IsFeatured = true,
                        IsSold = false,
                    },

                    new Listing
                    {
                        ListingId = 3,
                        ModelId = 3,
                        BodyStyleId = 3,
                        InteriorColorId = 2,
                        ExteriorColorId = 2,
                        Condition = Condition.Used,
                        Transmission =Transmission.Automatic,
                        Mileage = 1000000,
                        ModelYear = 1980,
                        VIN = "BACKTOTHEFUTURE",
                        MSRP = 400000.00M,
                        SalePrice = 399555.00M,
                        VehicleDescription = "The reverse is broken and smells like lightning",
                        ImageFileUrl = "doc.jpg",
                        IsFeatured = false,
                        IsSold = true,
                    }
                });
            }
        }


        public bool DeleteListing(int id)
        {
            return true;
        }

        public List<Listing> GetAllListings()
        {
            return _mockListings;
        }

        public List<Listing> GetFeaturedListings()
        {
            return _mockListings.Where(m => m.IsFeatured == true).ToList();
        }

        public Listing GetListingById(int id)
        {
            return _mockListings.Where(m => m.ListingId == id).FirstOrDefault();
        }

        public List<Listing> GetNewListings()
        {
            return _mockListings.Where(m => m.Condition == Condition.New).ToList();
        }

        public List<Listing> GetSoldListings()
        {
            return _mockListings.Where(m => m.IsSold == true).ToList();
        }

        public List<Listing> GetUsedListings()
        {
            return _mockListings.Where(m => m.Condition == Condition.Used).ToList();
        }

        public Listing InsertListing(Listing listing)
        {
            _mockListings.Add(listing);
            return listing;
        }

        public List<InventoryReport> InventoryReport(string report)
        {
            //report testing to implement later
            throw new NotImplementedException();
        }

        public IEnumerable<Listing> Search(ListingSearchParameters parameters)
        {
            //search testing to implement later... this would be hard
            throw new NotImplementedException();
        }

        public Listing UpdateListing(Listing listing)
        {
            //hmmm
            throw new NotImplementedException();
        }
    }
}
