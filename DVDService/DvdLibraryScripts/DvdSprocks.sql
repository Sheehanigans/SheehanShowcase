USE DvdLibrary;
GO

--GetAll
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetAll')
BEGIN
   DROP PROCEDURE GetAll
END
GO

CREATE PROCEDURE GetAll
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd

GO

--GetById
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetById')
BEGIN
   DROP PROCEDURE GetById
END
GO

CREATE PROCEDURE GetById(
	@DvdId int
)
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd d 
	WHERE d.DvdId = @DvdId

GO

--GetByTitle
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetByTitle')
BEGIN
   DROP PROCEDURE GetByTitle
END
GO

CREATE PROCEDURE GetByTitle(
	@Title varchar (50)
)
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd d 
	WHERE d.Title = @Title

GO

--GetByReleaseYear
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetByReleaseYear')
BEGIN
   DROP PROCEDURE GetByReleaseYear
END
GO

CREATE PROCEDURE GetByReleaseYear(
	@ReleaseYear char (4)
)
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd d 
	WHERE d.ReleaseYear = @ReleaseYear

GO

--GetByDirector
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetByDirector')
BEGIN
   DROP PROCEDURE GetByDirector
END
GO

CREATE PROCEDURE GetByDirector(
	@Director varchar (50)
)
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd d 
	WHERE d.Director = @Director

GO

--GetByRating
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetByRating')
BEGIN
   DROP PROCEDURE GetByRating
END
GO

CREATE PROCEDURE GetByRating(
	@Rating varchar (5)
)
AS

	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
    FROM Dvd d 
	WHERE d.Rating = @Rating

GO

--Add
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'Add')
BEGIN
   DROP PROCEDURE [Add]
END
GO

CREATE PROCEDURE [Add](
	@DvdId int output,
	@Title varchar (50), 
	@ReleaseYear char (4),
	@Director varchar (50), 
	@Rating varchar (5), 
	@Notes varchar (100)
)
AS
	INSERT INTO Dvd (Title, ReleaseYear, Director, Rating, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @Rating, @Notes)

	SET @DvdId = SCOPE_IDENTITY()

GO

--Edit
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'Edit')
BEGIN
   DROP PROCEDURE Edit
END
GO

CREATE PROCEDURE Edit (
	@DvdId int,
	@Title varchar (50), 
	@ReleaseYear char (4),
	@Director varchar (50), 
	@Rating varchar (5), 
	@Notes varchar (100)
)
AS

	UPDATE Dvd
		SET @DvdId = @DvdId,
		Title = @Title,
		ReleaseYear = @ReleaseYear,
		Director = @Director,
		Rating = @Rating,
		Notes = @Notes
	WHERE DvdId = @DvdId

GO

--Delete
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'Delete')
      DROP PROCEDURE [Delete]
GO

CREATE PROCEDURE [Delete] (
	@DvdId int
)
AS
	DELETE FROM Dvd
	WHERE DvdId = @DvdId
GO