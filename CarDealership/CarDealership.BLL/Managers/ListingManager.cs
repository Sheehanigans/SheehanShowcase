using CarDealership.Data.ADORepositories;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class ListingManager
    {
        private IListingRepository Repo { get; set; }

        public ListingManager(IListingRepository listingRepository)
        {
            Repo = listingRepository;
        }

        public ListingGetAllResponse GetAllistings()
        {
            var response = new ListingGetAllResponse();

            response.Listings = Repo.GetAllListings();

            if (!response.Listings.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }

            return response;
        }

        public TResponse<Listing> GetListingById(int id)
        {
            var response = new TResponse<Listing>();

            if(id < 1)
            {
                response.Success = false;
                response.Message = "Invalid Listing Id";
            }
            else
            {
                response.Payload = Repo.GetListingById(id);

                if (response.Payload == null)
                {
                    response.Success = false;
                    response.Message = $"Failed to load listing id {id}";
                }
                else if (response.Payload.ListingId != id)
                {
                    response.Success = false;
                    response.Message = $"Failed to load listing id {id}";
                }
                else
                {
                    response.Success = true;
                }
            }            

            return response;
        }

        public ListingFeaturedResponse GetFeaturedListings()
        {
            var response = new ListingFeaturedResponse();

            response.Listings = Repo.GetFeaturedListings();

            if (!response.Listings.Any())
            {
                response.Success = false;
                response.Message = "Could not load any vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<InventoryReport>> GetInventoryReport(string report)
        {
            var response = new TResponse<List<InventoryReport>>();

            response.Payload = Repo.InventoryReport(report);

            if (response.Payload == null)
            {
                response.Message = $"Unable to load report for {report}";
                response.Success = false;
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<Listing>> GetNewListings()
        {
            var response = new TResponse<List<Listing>>
            {
                Payload = Repo.GetNewListings()
            };

            if (!response.Payload.Any())
            {
                response.Success = false;
                response.Message = "Could not load any new vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<Listing>> GetUsedListings()
        {
            var response = new TResponse<List<Listing>>
            {
                Payload = Repo.GetUsedListings()
            };

            if (!response.Payload.Any())
            {
                response.Success = false;
                response.Message = "Could not load any used vehicles";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public TResponse<List<Listing>> Search(ListingSearchParameters paramters)
        {
            var response = new TResponse<List<Listing>>();

            if(paramters == null)
            {
                response.Message = "No search parameters were provided";
                response.Success = false;
            }
            else
            {
                response.Payload = Repo.Search(paramters).ToList();

                if (!response.Payload.Any())
                {
                    response.Success = false;
                    response.Message = "Query could not find any results";
                }
                else
                {
                    response.Success = true;
                }
            }           

            return response;
        }

        public TResponse<Listing> SaveListing(Listing listing)
        {
            var response = new TResponse<Listing>();

            if (listing.ModelId < 1
                || listing.BodyStyleId < 1
                || listing.InteriorColorId < 1
                || listing.ExteriorColorId < 1
                || listing.Condition == null
                || listing.Transmission == null
                || listing.Mileage < 1
                || listing.Mileage > 9999999
                || listing.ModelYear < 1
                || listing.ModelYear > 9999
                || listing.VIN == null
                || listing.MSRP < 0
                || listing.MSRP > 9999999999
                || listing.SalePrice < 0
                || listing.SalePrice > 9999999999
                || listing.VehicleDescription == null
                || listing.ImageFileUrl == null)
            {
                response.Message = "Listing unable to save. Listing model paramters null or our of range";
            }
            else
            {
                response.Payload = Repo.InsertListing(listing);

                if (response.Payload == null)
                {
                    response.Success = false;
                    response.Message = "Unable to save new listing ";
                }
                else
                {
                    response.Success = true;
                }
            }            

            return response;
        }

        public TResponse<Listing> UpdateListing(Listing listing)
        {
            var response = new TResponse<Listing>();

            if (listing.ModelId < 1
                || listing.BodyStyleId < 1
                || listing.InteriorColorId < 1
                || listing.ExteriorColorId < 1
                || listing.Condition == null
                || listing.Transmission == null
                || listing.Mileage < 1
                || listing.Mileage > 9999999
                || listing.ModelYear < 1
                || listing.ModelYear > 9999
                || listing.VIN == null
                || listing.MSRP < 0
                || listing.MSRP > 9999999999
                || listing.SalePrice < 0
                || listing.SalePrice > 9999999999
                || listing.VehicleDescription == null
                || listing.ImageFileUrl == null)
            {
                response.Message = "Listing unable to save. Listing model paramters null or our of range";
            }
            else
            {
                response.Payload = Repo.UpdateListing(listing);

                if (response.Payload == null)
                {
                    response.Success = false;
                    response.Message = $"Unable to update Listing Id {listing.ListingId}";
                }
                else
                {
                    response.Success = true;
                }
            }

            return response;

        }

        public TResponse<bool> DeleteListing(int id)
        {
            var response = new TResponse<bool>();

            if(id < 1)
            {
                response.Message = "Invalid listing Id";
                response.Success = false;
            }
            else
            {
                response.Payload = Repo.DeleteListing(id);

                if (response.Payload == true)
                {
                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = $"Unable to delete for Listing Id {id}";
                }
            }

            return response;
        }
    }
}