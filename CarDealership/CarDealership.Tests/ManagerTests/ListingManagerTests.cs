using CarDealership.BLL.Managers;
using CarDealership.Data.InMemoryRepositories;
using CarDealership.Models.Enums;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.ManagerTests
{
    [TestFixture]
    public class ListingManagerTests
    {
        //get by id 
        [TestCase(1, true)]
        [TestCase(4, false)]
        public static void CanGetListingByIdGOODREPO(int listingId, bool expected)
        {
            ListingManager manager = new ListingManager(new ListingMemRepo_GOODDATA());

            var test = manager.GetListingById(listingId);

            bool actual;

            if (test.Payload == null)
                actual = false;
            else
                actual = true;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, false)]
        public static void CanGetListingByIdALWAYSNULL(int listingId, bool expected)
        {
            ListingManager manager = new ListingManager(new ListingMemRepo_ALWAYSNULL());

            var test = manager.GetListingById(listingId);

            bool actual;

            if (test.Payload == null)
                actual = false;
            else
                actual = true;

            Assert.AreEqual(expected, actual);
        }

        //save listing 
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, true)]
        [TestCase(0, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 0, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 0, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 0, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 0, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, 0, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, 0, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 0, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 0, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "", 40000, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 0, 39000, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 0, "Yo this car is great", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "", "car.jpg", false, false, 10, 20, 2019, false)]
        [TestCase(4, 1, 2, 1, 1, Condition.New, Transmission.Automatic, 33000, 2018, "HEYOOOALMOSTDONE123", 40000, 39000, "Yo this car is great", "", false, false, 10, 20, 2019, false)]
        public static void SaveListing(int listingId, int modelId, int bodyStyleid, int interiorColorid, int exteriorColorid, 
            Condition condition, Transmission transmission, int mileage, int modelYear, string VIN, decimal MSRP, 
            decimal salePrice, string vdesc, string imageFileUrl, bool isFeatured, bool isSold, int month, int day, int year, bool expected)
        {
            DateTime DateAdded = new DateTime(year, month, day);

            ListingManager manager = new ListingManager(new ListingMemRepo_GOODDATA());

            Listing listing = new Listing
            {
                ListingId = listingId,
                ModelId = modelId,
                BodyStyleId = bodyStyleid,
                InteriorColorId = interiorColorid,
                ExteriorColorId = exteriorColorid,
                Condition = condition,
                Transmission = transmission,
                Mileage = mileage,
                ModelYear = modelYear,
                VIN = VIN, 
                MSRP = MSRP,
                SalePrice = salePrice,
                VehicleDescription = vdesc,
                ImageFileUrl = imageFileUrl,
                IsFeatured = isFeatured,
                IsSold = isSold,
                DateAdded = DateAdded,
            };

            var test = manager.SaveListing(listing);

            Assert.AreEqual(expected, test.Success);
        }


        //public static void CanSaveListing

        //upsate listing 
        //delete listing
    }
}
