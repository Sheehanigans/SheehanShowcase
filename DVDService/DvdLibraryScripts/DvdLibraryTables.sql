USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd
GO

CREATE TABLE Dvd(
	DvdId int identity(1,1) primary key not null,
	Title varchar (50) not null, 
	ReleaseYear char (4) not null,
	Director varchar (50) not null, 
	Rating varchar (5) not null, 
	Notes varchar (100) not null,
)


SET IDENTITY_INSERT Dvd ON
 
INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, Rating, Notes)
VALUES (1, 'Tropic Thunder',2010,'Ben Stiller','PG-13','This is one of my favorite movies'),
(2, 'Gladiator',2001,'Ridley Scott','R','MAXIMUS - ARE YOU NOT ENTERTAINED'),
(3, 'Wall-E',2012,'Brad Bird','PG','EEEEVVaaaaaa')
 
SET IDENTITY_INSERT Dvd OFF