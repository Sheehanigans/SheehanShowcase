USE HotelReservationSystem
GO

--INSERT INTO Customer (FirstName, LastName, PhoneNumber, Email, Age, Birthday)
--VALUES ('Ryan','Sheehan','6127507473','ryan@gmail.com','24','11/04/1993')

--INSERT INTO Promotion (PromotionName, StartDate, EndDate, PercentDiscount, DollarAmountDiscount)
--VALUES ('Lucky sunshine promo','10/20/2019','11/11/2019', 10.00, null),
--('Happy ending beginning', '10/20/2019','11/11/2019', null, 10.00)

--INSERT INTO Reservation(CustomerID, PromotionID, StartDate, EndDate)
--VALUES (1, 1, '9/10/2019','9/17/2019')

--INSERT INTO AdditionalGuests(ReservationID, FirstName, LastName, Age)
--VALUES('1','Billy','Mays','60')

--INSERT INTO Bill (ReservationID, Total, Tax)
--VALUES ('1', 1000.00, 10.00)

--INSERT INTO AddOn (AddOnName, Price)
--VALUES ('Massage', 100.00)

--INSERT INTO BillDetails(BillID, AddOnID, Quantity)
--VALUES (1,1,2)

--INSERT INTO Amenity(AmenityName)
--VALUES ('Mini Bar')

--INSERT INTO RoomType (TypeName)
--VALUES ('Single'),
--('Double'),
--('King'),
--('Queen'),
--('MEGA SUITE')

--INSERT INTO Room (RoomTypeID, RoomNumber, FloorLevel, OccupancyLimit)
--VALUES (1, 202, 2, 2)

--INSERT INTO RoomAmenity (RoomID, AmenityID)
--VALUES (1, 1)

--INSERT INTO RoomReservation (ReservationID, RoomID)
--VALUES (1,1)

--INSERT INTO Rate (RateName, RatePrice)
--VALUES ('Single rate', 100.00), 
--('Double rate', 200.00), 
--('King rate', 400.00), 
--('Queen rate', 300.00), 
--('MEGA SUITE rate', 10000.00)

--INSERT INTO TypeRate (RoomTypeID, RateID, StartDate, EndDate)
--VALUES (1,2,'11/11/2019','12/11/2019'), 
--(2,1,'11/11/2019','12/11/2019')


