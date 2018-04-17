using CarDealership.Models.Interfaces;
using CarDealership.Models.Responses;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.BLL.Managers
{
    public class PurchaseManager
    {
        private IPurchaseRepository Repo { get; set; }

        public PurchaseManager(IPurchaseRepository purchaseRepository)
        {
            Repo = purchaseRepository;
        }

        public TResponse<Purchase> SavePurchase(Purchase purchase)
        {
            var response = new TResponse<Purchase>();

            response.Success = false;

            if (purchase.ListingId < 1)
            {
                response.Message = "Listing Id inavlid";
            }
            else if (purchase.StateId < 1)
            {
                response.Message = "State Id inavlid";
            }
            else if (purchase.CustomerName == null || purchase.CustomerName.Length > 50)
            {
                response.Message = "Customer name inavlid";
            }
            else if (purchase.Phone == null || purchase.Phone.Length > 20)
            {
                response.Message = "Phone inavlid";
            }
            else if (purchase.Email == null || purchase.Email.Length > 100)
            {
                response.Message = "Email inavlid";
            }
            else if (purchase.Street1 == null || purchase.Street1.Length > 100)
            {
                response.Message = "Street 1 inavlid";
            }
            else if (!string.IsNullOrEmpty(purchase.Street2))
            {
                if(purchase.Street2.Length > 100)
                {
                    response.Message = "Street 2 inavlid";
                }
            }
            else if (purchase.City == null || purchase.City.Length > 100)
            {
                response.Message = "City inavlid";
            }
            else if (purchase.Zipcode == null || purchase.Zipcode.Length > 5)
            {
                response.Message = "Zipcode inavlid";
            }
            else if(purchase.PurchasePrice < 0 || purchase.PurchasePrice > 9999999999)
            {
                response.Message = "Purchase price inavlid";
            }
            else if(purchase.PaymentOption == null)
            {
                response.Message = "Payment option invalid";
            }
            else if(purchase.UserName == null)
            {
                response.Message = "User name inavlid";
            }
            else
            {
                response.Payload = Repo.SavePurchase(purchase);

                if (response.Payload != purchase)
                {
                    response.Success = false;
                    response.Message = $"Unsuccessfully saved purchase for Listing Id: {purchase.ListingId}";
                }
                else
                {
                    response.Success = true;
                }
            }
            

            return response;
        }
    }
}
