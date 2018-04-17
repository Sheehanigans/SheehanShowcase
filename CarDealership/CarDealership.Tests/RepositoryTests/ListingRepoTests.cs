using CarDealership.Data.ADORepositories;
using CarDealership.Data.Settings;
using CarDealership.Models.Enums;
using CarDealership.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.RepositoryTests
{
    public class ListingRepoTests
    {

        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "ResetDb";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void GetAllListings()
        {

            ListingRepository repo = new ListingRepository();

            List<Listing> listings = new List<Listing>();

            listings = repo.GetAllListings();

            var listingToTest = listings[0];

            Assert.AreEqual(1, listingToTest.ListingId);
            Assert.AreEqual(1, listingToTest.ModelId);
            Assert.AreEqual("CX-3", listingToTest.ModelName);
            Assert.AreEqual(2019, listingToTest.ModelYear);
            Assert.AreEqual(2, listingToTest.MakeId);
            Assert.AreEqual("Mazda", listingToTest.MakeName);
            Assert.AreEqual(2, listingToTest.BodyStyleId);
            Assert.AreEqual("Subcompact SUV", listingToTest.BodyStyleName);
            Assert.AreEqual(1, listingToTest.InteriorColorId);
            Assert.AreEqual("Velvet Wonderland", listingToTest.InteriorColorName);
            Assert.AreEqual(1, listingToTest.ExteriorColorId);
            Assert.AreEqual("Leprechaun Green", listingToTest.ExteriorColorName);
            Assert.AreEqual(Condition.New, listingToTest.Condition);
            Assert.AreEqual(Transmission.Manual, listingToTest.Transmission);
            Assert.AreEqual(25000, listingToTest.Mileage);
            Assert.AreEqual("FTW12345BLAHHEY69", listingToTest.VIN);
            Assert.AreEqual(30000.00M, listingToTest.MSRP);
            Assert.AreEqual(29000.00M, listingToTest.SalePrice);
            Assert.AreEqual("This little guy is a lot of fun", listingToTest.VehicleDescription);
            Assert.AreEqual("cx3.jpg", listingToTest.ImageFileUrl);
            Assert.AreEqual(false, listingToTest.IsFeatured);
            Assert.AreEqual(false, listingToTest.IsSold);
        }

        [Test]
        public void GetAllNewListings()
        {
            ListingRepository repo = new ListingRepository();

            List<Listing> listings = new List<Listing>();

            listings = repo.GetNewListings();

            var listingToTest = listings[0];

            Assert.AreEqual(1, listingToTest.ListingId);
            Assert.AreEqual(1, listingToTest.ModelId);
            Assert.AreEqual("CX-3", listingToTest.ModelName);
            Assert.AreEqual(2019, listingToTest.ModelYear);
            Assert.AreEqual(2, listingToTest.MakeId);
            Assert.AreEqual("Mazda", listingToTest.MakeName);
            Assert.AreEqual(2, listingToTest.BodyStyleId);
            Assert.AreEqual("Subcompact SUV", listingToTest.BodyStyleName);
            Assert.AreEqual(1, listingToTest.InteriorColorId);
            Assert.AreEqual("Velvet Wonderland", listingToTest.InteriorColorName);
            Assert.AreEqual(1, listingToTest.ExteriorColorId);
            Assert.AreEqual("Leprechaun Green", listingToTest.ExteriorColorName);
            Assert.AreEqual(Condition.New, listingToTest.Condition);
            Assert.AreEqual(Transmission.Manual, listingToTest.Transmission);
            Assert.AreEqual(25000, listingToTest.Mileage);
            Assert.AreEqual("FTW12345BLAHHEY69", listingToTest.VIN);
            Assert.AreEqual(30000.00M, listingToTest.MSRP);
            Assert.AreEqual(29000.00M, listingToTest.SalePrice);
            Assert.AreEqual("This little guy is a lot of fun", listingToTest.VehicleDescription);
            Assert.AreEqual("cx3.jpg", listingToTest.ImageFileUrl);
            Assert.AreEqual(false, listingToTest.IsFeatured);
            Assert.AreEqual(false, listingToTest.IsSold);
        }

        //used 

        [Test]
        public void GetUsedVehicles()
        {
            ListingRepository repo = new ListingRepository();

            List<Listing> listings = new List<Listing>();

            listings = repo.GetUsedListings();

            var listingToTest = listings[0];

            Assert.AreEqual(2, listingToTest.ListingId);
            Assert.AreEqual(2, listingToTest.ModelId);
            Assert.AreEqual("Wrangler", listingToTest.ModelName);
            Assert.AreEqual(1995, listingToTest.ModelYear);
            Assert.AreEqual(1, listingToTest.MakeId);
            Assert.AreEqual("Jeep", listingToTest.MakeName);
            Assert.AreEqual(1, listingToTest.BodyStyleId);
            Assert.AreEqual("Offroad SUV", listingToTest.BodyStyleName);
            Assert.AreEqual(2, listingToTest.InteriorColorId);
            Assert.AreEqual("Strapping Leather", listingToTest.InteriorColorName);
            Assert.AreEqual(2, listingToTest.ExteriorColorId);
            Assert.AreEqual("Stone White", listingToTest.ExteriorColorName);
            Assert.AreEqual(Condition.Used, listingToTest.Condition);
            Assert.AreEqual(Transmission.Automatic, listingToTest.Transmission);
            Assert.AreEqual(200000, listingToTest.Mileage);
            Assert.AreEqual("JEEP229900HEYYO", listingToTest.VIN);
            Assert.AreEqual(15000.00M, listingToTest.MSRP);
            Assert.AreEqual(14000.00M, listingToTest.SalePrice);
            Assert.AreEqual("Hey did you see that road there? Yeah neither did I.", listingToTest.VehicleDescription);
            Assert.AreEqual("95wrangler.jpg", listingToTest.ImageFileUrl);
            Assert.AreEqual(true, listingToTest.IsFeatured);
            Assert.AreEqual(false, listingToTest.IsSold);
        }
        //featured 

        [Test]
        public void GetFeaturedVehicles()
        {
            ListingRepository repo = new ListingRepository();

            List<Listing> listings = new List<Listing>();

            listings = repo.GetFeaturedListings();

            var listingToTest = listings[0];

            Assert.AreEqual(2, listingToTest.ListingId);
            Assert.AreEqual(2, listingToTest.ModelId);
            Assert.AreEqual("Wrangler", listingToTest.ModelName);
            Assert.AreEqual(1995, listingToTest.ModelYear);
            Assert.AreEqual(1, listingToTest.MakeId);
            Assert.AreEqual("Jeep", listingToTest.MakeName);
            Assert.AreEqual(1, listingToTest.BodyStyleId);
            Assert.AreEqual("Offroad SUV", listingToTest.BodyStyleName);
            Assert.AreEqual(2, listingToTest.InteriorColorId);
            Assert.AreEqual("Strapping Leather", listingToTest.InteriorColorName);
            Assert.AreEqual(2, listingToTest.ExteriorColorId);
            Assert.AreEqual("Stone White", listingToTest.ExteriorColorName);
            Assert.AreEqual(Condition.Used, listingToTest.Condition);
            Assert.AreEqual(Transmission.Automatic, listingToTest.Transmission);
            Assert.AreEqual(200000, listingToTest.Mileage);
            Assert.AreEqual("JEEP229900HEYYO", listingToTest.VIN);
            Assert.AreEqual(15000.00M, listingToTest.MSRP);
            Assert.AreEqual(14000.00M, listingToTest.SalePrice);
            Assert.AreEqual("Hey did you see that road there? Yeah neither did I.", listingToTest.VehicleDescription);
            Assert.AreEqual("95wrangler.jpg", listingToTest.ImageFileUrl);
            Assert.AreEqual(true, listingToTest.IsFeatured);
            Assert.AreEqual(false, listingToTest.IsSold);
        }

        //sold 

        [Test]
        public void GetSoldVehicles()
        {
            ListingRepository repo = new ListingRepository();

            List<Listing> listings = new List<Listing>();

            listings = repo.GetSoldListings();

            var listingToTest = listings[0];

            Assert.AreEqual(3, listingToTest.ListingId);
            Assert.AreEqual(3, listingToTest.ModelId);
            Assert.AreEqual("Docs Car", listingToTest.ModelName);
            Assert.AreEqual(1980, listingToTest.ModelYear);
            Assert.AreEqual(3, listingToTest.MakeId);
            Assert.AreEqual("Delorian", listingToTest.MakeName);
            Assert.AreEqual(3, listingToTest.BodyStyleId);
            Assert.AreEqual("Sudan", listingToTest.BodyStyleName);
            Assert.AreEqual(2, listingToTest.InteriorColorId);
            Assert.AreEqual("Strapping Leather", listingToTest.InteriorColorName);
            Assert.AreEqual(2, listingToTest.ExteriorColorId);
            Assert.AreEqual("Stone White", listingToTest.ExteriorColorName);
            Assert.AreEqual(Condition.Used, listingToTest.Condition);
            Assert.AreEqual(Transmission.Automatic, listingToTest.Transmission);
            Assert.AreEqual(1000000, listingToTest.Mileage);
            Assert.AreEqual("BACKTOTHEFUTURE", listingToTest.VIN);
            Assert.AreEqual(400000.00M, listingToTest.MSRP);
            Assert.AreEqual(399555.00M, listingToTest.SalePrice);
            Assert.AreEqual("The reverse is broken and smells like lightning", listingToTest.VehicleDescription);
            Assert.AreEqual("doc.jpg", listingToTest.ImageFileUrl);
            Assert.AreEqual(false, listingToTest.IsFeatured);
            Assert.AreEqual(true, listingToTest.IsSold);
        }

        //listing add
        //lsiting update 
        //lsisting delete
    }
}
