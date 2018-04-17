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
    public class ListingMemRepo_ALWAYSNULL : IListingRepository
    {
        public bool DeleteListing(int id)
        {
            return false;
        }

        public List<Listing> GetAllListings()
        {
            return null;
        }

        public List<Listing> GetFeaturedListings()
        {
            return null;
        }

        public Listing GetListingById(int id)
        {
            return null;
        }

        public List<Listing> GetNewListings()
        {
            return null;
        }

        public List<Listing> GetSoldListings()
        {
            return null;
        }

        public List<Listing> GetUsedListings()
        {
            return null;
        }

        public Listing InsertListing(Listing listing)
        {
            return null;
        }

        public List<InventoryReport> InventoryReport(string report)
        {
            return null;
        }

        public IEnumerable<Listing> Search(ListingSearchParameters parameters)
        {
            return null;
        }

        public Listing UpdateListing(Listing listing)
        {
            return null;
        }
    }
}
