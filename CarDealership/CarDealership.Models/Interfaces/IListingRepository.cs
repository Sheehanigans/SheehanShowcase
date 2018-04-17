using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Interfaces
{
    public interface IListingRepository
    {
        List<Listing> GetAllListings();

        List<Listing> GetUsedListings();

        List<Listing> GetNewListings();

        List<Listing> GetFeaturedListings();

        List<Listing> GetSoldListings();

        IEnumerable<Listing> Search(ListingSearchParameters parameters);

        Listing GetListingById(int id);

        Listing InsertListing(Listing listing);

        Listing UpdateListing(Listing listing);

        bool DeleteListing(int id);

        List<InventoryReport> InventoryReport(string report);
    }
}
