use CarDealership
go

if exists (select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'ResetDb')
		drop procedure ResetDb
go

create procedure ResetDb as 
begin 
	delete from Purchase;
	delete from States;
	delete from Specials;
	delete from ContactForms;
	delete from Listings;
	delete from Models;
	delete from Makes;
	delete from BodyStyles;
	delete from InteriorColors;
	delete from ExteriorColors;
	delete from AspNetUserRoles where UserId in('00000000-0000-0000-0000-111111111111');
	delete from AspNetUsers where Id in ('00000000-0000-0000-0000-111111111111');

	SET IDENTITY_INSERT States ON
    INSERT INTO States (StateId, StateAbbreviation, StateName)
    VALUES (1, 'AL', 'Alabama'),
    (2, 'AK', 'Alaska'),
    (3, 'AZ', 'Arizona'),
    (4, 'AR', 'Arkansas'),
    (5, 'CA', 'California'),
    (6, 'CO', 'Colorado'),
    (7, 'CT', 'Connecticut'),
    (8, 'DE', 'Delaware'),
    (9, 'DC', 'District of Columbia'),
    (10, 'FL', 'Florida'),
    (11, 'GA', 'Georgia'),
    (12, 'HI', 'Hawaii'),
    (13, 'ID', 'Idaho'),
    (14, 'IL', 'Illinois'),
    (15, 'IN', 'Indiana'),
    (16, 'IA', 'Iowa'),
    (17, 'KS', 'Kansas'),
    (18, 'KY', 'Kentucky'),
    (19, 'LA', 'Louisiana'),
    (20, 'ME', 'Maine'),
    (21, 'MD', 'Maryland'),
    (22, 'MA', 'Massachusetts'),
    (23, 'MI', 'Michigan'),
    (24, 'MN', 'Minnesota'),
    (25, 'MS', 'Mississippi'),
    (26, 'MO', 'Missouri'),
    (27, 'MT', 'Montana'),
    (28, 'NE', 'Nebraska'),
    (29, 'NV', 'Nevada'),
    (30, 'NH', 'New Hampshire'),
    (31, 'NJ', 'New Jersey'),
    (32, 'NM', 'New Mexico'),
    (33, 'NY', 'New York'),
    (34, 'NC', 'North Carolina'),
    (35, 'ND', 'North Dakota'),
    (36, 'OH', 'Ohio'),
    (37, 'OK', 'Oklahoma'),
    (38, 'OR', 'Oregon'),
    (39, 'PA', 'Pennsylvania'),
    (40, 'PR', 'Puerto Rico'),
    (41, 'RI', 'Rhode Island'),
    (42, 'SC', 'South Carolina'),
    (43, 'SD', 'South Dakota'),
    (44, 'TN', 'Tennessee'),
    (45, 'TX', 'Texas'),
    (46, 'UT', 'Utah'),
    (47, 'VT', 'Vermont'),
    (48, 'VA', 'Virginia'),
    (49, 'WA', 'Washington'),
    (50, 'WV', 'West Virginia'),
    (51, 'WI', 'Wisconsin'),
    (52, 'WY', 'Wyoming');
    SET IDENTITY_INSERT States OFF;

	set identity_insert Specials on; 
	insert into Specials(SpecialId, SpecialTitle, SpecialMessage)
	values(1, 'MEGA SALE ON COOL CARS', 'THE COOLEST CARS have some MEGA SaLeS')
	set identity_insert Specials off;

	set identity_insert ContactForms on; 
	insert into ContactForms(ContactFormId, CustomerName, Email, Phone, FormMessage)
	values (1, 'Sally', 'Sally@gmail.com', '651-488-8888', 'HEY I would like a new moped, ya got one?')
	set identity_insert ContactForms off;

	set identity_insert ExteriorColors on;
	insert into ExteriorColors(ExteriorColorId, ExteriorColorName)
	values(1, 'Leprechaun Green'), 
	(2, 'Stone White')
	set identity_insert ExteriorColors off;

	set identity_insert InteriorColors on;
	insert into InteriorColors (InteriorColorId, InteriorColorName)
	values (1, 'Velvet Wonderland'), 
	(2, 'Strapping Leather')
	set identity_insert InteriorColors off; 

	INSERT INTO AspNetUsers(Id, EmailConfirmed, PhoneNumberConfirmed, Email, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, UserName, FirstName, LastName)
	VALUES('00000000-0000-0000-0000-111111111111', 0, 0, 'sales@test.com', 0, 0, 0, 'TestSales', 'Brian', 'Meehan')

	insert into AspNetUserRoles(UserId, RoleId)
	values ('00000000-0000-0000-0000-111111111111', '1c719ce0-0249-458d-9934-ee35b12cbd01')

	set identity_insert Makes on; 
	insert into Makes(MakeId, MakeName, UserName)
	values (1, 'Jeep', 'test@test.com'),
	(2, 'Mazda', 'test@test.com'),
	(3, 'Delorian', 'test@test.com')
	set identity_insert Makes off; 
	
	set identity_insert Models on; 
	insert into Models(ModelId, MakeId, ModelName, UserName)
	values(1, 2, 'CX-3', 'test@test.com'), 
	(2, 1, 'Wrangler','test@test.com'),
	(3, 3, 'Docs Car', 'test@test.com')
	set identity_insert Models off;

	set identity_insert BodyStyles on;
	insert into BodyStyles(BodyStyleId, BodyStyleName)
	values (1, 'Offroad SUV'), 
	(2, 'Subcompact SUV'),
	(3, 'Sudan')
	set identity_insert BodyStyles off;

	set identity_insert Listings on;
	insert into Listings (ListingId, ModelId, BodyStyleId, InteriorColorId, ExteriorColorId, Condition, Transmission, Mileage, ModelYear, VIN, MSRP, SalePrice, VehicleDescription, ImageFileUrl, IsFeatured, IsSold)
	values(1, 1, 2, 1, 1, 1, 2, 25000, 2019, 'FTW12345BLAHHEY69', 30000.00, 29000.00, 'This little guy is a lot of fun', 'cx3.jpg', 0, 0), 
	(2, 2, 1, 2, 2, 2, 1, 200000, 1995,'JEEP229900HEYYO', 15000.00, 14000.00, 'Hey did you see that road there? Yeah neither did I.', '95wrangler.jpg', 1, 0),
	(3, 3, 3, 2, 2, 2, 1, 1000000, 1980,'BACKTOTHEFUTURE', 400000.00, 399555.00, 'The reverse is broken and smells like lightning', 'doc.jpg', 0, 1)
	set identity_insert Listings off; 

	set identity_insert Purchase on;
	insert into Purchase(PurchaseId, ListingId, StateId, CustomerName, Phone, Email, Street1, City, ZipCode, PurchasePrice, PaymentOption, UserName)
	values (1, 1, 1, 'Ryan', '612-750-7473', 'ryan@ryan.com', '3117 Free Ave', 'Minneaplis', '55408', 25000.00, 'Bank Finance', 'test@test.com')
	set identity_insert Purchase off;

end 
