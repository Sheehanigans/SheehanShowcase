use CarDealership
go

	SELECT ListingId, l.ModelId, mo.ModelName, l.ModelYear, ma.MakeId, ma.MakeName, l.BodyStyleId, bs.BodyStyleName, l.InteriorColorId, ic.InteriorColorName, l.ExteriorColorId, ec.ExteriorColorName, Condition, Transmission, Mileage, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, l.IsSold, l.DateAdded
	FROM Listings l 
	inner join Models mo on mo.ModelId = l.ModelId
	inner join Makes ma on ma.MakeId = mo.MakeId
	inner join InteriorColors ic on ic.InteriorColorId = l.InteriorColorId
	inner join ExteriorColors ec on ec.ExteriorColorId = l.ExteriorColorId
	inner join BodyStyles bs on bs.BodyStyleId = l.BodyStyleId

	where 1 = 1

	where (l.Condition = 1 or l.Condition = 2) AND SalePrice <= 100000 AND ma.MakeName LIKE '2019' OR mo.ModelName LIKE '2019' OR l.ModelYear LIKE '2019'
	go

