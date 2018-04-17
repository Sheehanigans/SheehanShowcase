using CarDealership.Data.Settings;
using CarDealership.Models.Enums;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.ADORepositories
{
    public class ListingRepository : IListingRepository
    {
        public List<Listing> GetAllListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetAllListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetNewListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetNewListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetUsedListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetUsedListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetFeaturedListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetFeaturedListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public List<Listing> GetSoldListings()
        {
            List<Listing> listings;

            using (var connection = ConnectionStrings.GetOpenConnection())
            {
                listings = connection.Query<Listing>(
                    "GetSoldListings",
                    commandType: CommandType.StoredProcedure
                    ).ToList();
            }

            return listings;
        }

        public Listing GetListingById(int id)
        {
            Listing listing;

            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ListingId", id);

                listing = cn.Query<Listing>(
                    "GetListingById",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    ).SingleOrDefault();
            }

            return listing;
        }

        public bool DeleteListing(int id)
        {
            using (var cn = ConnectionStrings.GetOpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ListingId", id);

                cn.Execute(
                    "ListingDelete",
                    parameters,
                    commandType: CommandType.StoredProcedure
                    );
            }

            return true;
        }

        public Listing UpdateListing(Listing listing)
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@ListingId", listing.ListingId);
                parameters.Add("@ModelId", listing.ModelId);
                parameters.Add("@BodyStyleId", listing.BodyStyleId);
                parameters.Add("@InteriorColorId", listing.InteriorColorId);
                parameters.Add("@ExteriorColorId", listing.ExteriorColorId);
                parameters.Add("@Condition", listing.Condition);
                parameters.Add("@Transmission", listing.Transmission);
                parameters.Add("@Mileage", listing.Mileage);
                parameters.Add("@ModelYear", listing.ModelYear);
                parameters.Add("@VIN", listing.VIN);
                parameters.Add("@MSRP", listing.MSRP);
                parameters.Add("@SalePrice", listing.SalePrice);
                parameters.Add("@VehicleDescription", listing.VehicleDescription);
                parameters.Add("@ImageFileUrl", listing.ImageFileUrl);
                parameters.Add("@IsFeatured", listing.IsFeatured);

                cn.Execute("ListingUpdate", parameters, commandType: CommandType.StoredProcedure);
            }

            return listing;
        }


        public Listing InsertListing(Listing listing)
        {
            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ListingId", listing.ListingId, DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@ModelId", listing.ModelId);
                parameters.Add("@BodyStyleId", listing.BodyStyleId);
                parameters.Add("@InteriorColorId", listing.InteriorColorId);
                parameters.Add("@ExteriorColorId", listing.ExteriorColorId);
                parameters.Add("@Condition", listing.Condition);
                parameters.Add("@Transmission", listing.Transmission);
                parameters.Add("@Mileage", listing.Mileage);
                parameters.Add("@ModelYear", listing.ModelYear);
                parameters.Add("@VIN", listing.VIN);
                parameters.Add("@MSRP", listing.MSRP);
                parameters.Add("@SalePrice", listing.SalePrice);
                parameters.Add("@VehicleDescription", listing.VehicleDescription);
                parameters.Add("@ImageFileUrl", listing.ImageFileUrl);
                parameters.Add("@IsFeatured", listing.IsFeatured);
                parameters.Add("@IsSold", listing.IsSold);
                parameters.Add("@DateAdded", listing.DateAdded);
                cn.Execute("ListingInsert", parameters, commandType: CommandType.StoredProcedure);

                listing.ListingId = parameters.Get<int>("@ListingId");
            }

            return listing;
        }

        public IEnumerable<Listing> Search (ListingSearchParameters parameters)
        {
            List<Listing> listings = new List<Listing>();

            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                string query =
                    "SELECT TOP 20 ListingId, l.ModelId, mo.ModelName, l.ModelYear, " +
                    "ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, " +
                    "ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, " +
                    "Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, " +
                    "ImageFileUrl, IsFeatured, IsSold, l.DateAdded " +
                    "FROM Listings l " +
                    "inner join Models mo on mo.ModelId = l.ModelId " +
                    "inner join Makes ma on ma.MakeId = mo.MakeId  " +
                    "inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId  " +
                    "inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId  " +
                    "inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId  " +
                    "WHERE 1 = 1 ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                switch (parameters.View)
                {
                    case "New":
                        query += "AND l.Condition = 1 ";
                        break;
                    case "Used":
                        query += "AND l.Condition = 2 ";
                        break;
                    case "Admin":
                        query += "AND (l.Condition = 1 or l.Condition = 2) ";
                        break;
                    case "Sales":
                        query += "AND l.IsSold = 0 ";
                        break;
                    default:
                        break;
                }

                if (parameters.MinPrice.HasValue)
                {
                    query += "AND SalePrice >= @MinPrice ";
                    cmd.Parameters.AddWithValue("@MinPrice", parameters.MinPrice.Value);
                }
                if (parameters.MaxPrice.HasValue)
                {
                    query += "AND SalePrice <= @MaxPrice ";
                    cmd.Parameters.AddWithValue("@MaxPrice", parameters.MaxPrice.Value);
                }
                if (parameters.MinYear.HasValue)
                {
                    query += "AND l.ModelYear >= @MinYear ";
                    cmd.Parameters.AddWithValue("@MinYear", parameters.MinYear.Value);
                }
                if (parameters.MaxYear.HasValue)
                {
                    query += "AND l.ModelYear <= @MaxYear ";
                    cmd.Parameters.AddWithValue("@MaxYear", parameters.MaxYear.Value);
                }

                if (!string.IsNullOrEmpty(parameters.QuickSearch))
                {
                    query += "AND (ma.MakeName LIKE @QuickSearch OR mo.ModelName LIKE @QuickSearch OR l.ModelYear LIKE @QuickSearch) ";
                    cmd.Parameters.AddWithValue("@QuickSearch", parameters.QuickSearch + '%');
                }

                query += "ORDER BY DateAdded DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Listing row = new Listing();

                        row.ListingId = (int)dr["ListingId"];
                        row.ModelId = (int)dr["ModelId"];
                        row.ModelName = dr["ModelName"].ToString();
                        row.ModelYear = (int)dr["ModelYear"];
                        row.MakeId = (int)dr["MakeId"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.BodyStyleId = (int)dr["BodyStyleId"];
                        row.BodyStyleName = dr["BodyStyleName"].ToString();
                        row.InteriorColorId = (int)dr["InteriorColorId"];
                        row.InteriorColorName = dr["InteriorColorName"].ToString();
                        row.ExteriorColorId = (int)dr["ExteriorColorId"];
                        row.ExteriorColorName = dr["ExteriorColorName"].ToString();
                        row.Condition = (Condition)dr["Condition"];
                        row.Transmission = (Transmission)dr["Transmission"];
                        row.Mileage = (int)dr["Mileage"];
                        row.VIN = dr["VIN"].ToString();
                        row.MSRP = (decimal)dr["MSRP"];
                        row.SalePrice = (decimal)dr["SalePrice"];
                        row.VehicleDescription = dr["VehicleDescription"].ToString();
                        row.IsFeatured = (bool)dr["IsFeatured"];
                        row.IsSold = (bool)dr["IsSold"];

                        if (dr["ImageFileUrl"] != DBNull.Value)
                            row.ImageFileUrl = dr["ImageFileUrl"].ToString();

                        listings.Add(row);
                    }
                }
            }

            return listings;
        }

        public List<InventoryReport> InventoryReport(string report)
        {
            List<InventoryReport> reportItems = new List<InventoryReport>();

            using (var cn = new SqlConnection(ConnectionStrings.GetConnectionString()))
            {
                string query = "SELECT l.ModelYear, ma.MakeName, ModelName, COUNT(*) as [Count], SUM(l.SalePrice) AS 'StockValue' " +
                "FROM Listings l " +
                "INNER JOIN Models mo on mo.ModelId = l.ModelId " +
                "INNER JOIN Makes ma on ma.MakeId = mo.MakeId ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                switch (report)
                {
                    case "New":
                        query += "WHERE l.Condition = 1 AND IsSold = 0 ";
                        break;
                    case "Used":
                        query += "WHERE l.Condition = 2 AND IsSold = 0";
                        break;
                    default:
                        break;
                }

                query += "GROUP BY l.ModelYear, mo.ModelName, ma.MakeName, l.SalePrice";

                cmd.CommandText = query;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InventoryReport row = new InventoryReport();

                        row.ModelYear = (int)dr["ModelYear"];
                        row.MakeName = dr["MakeName"].ToString();
                        row.ModelName = dr["ModelName"].ToString();
                        row.Count = (int)dr["Count"];
                        row.StockValue = (decimal)dr["StockValue"];

                        reportItems.Add(row);
                    }
                }
            }

            return reportItems;
        }
    }
}
