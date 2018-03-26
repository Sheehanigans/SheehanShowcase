--USE master
--GO

--CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
--GO

--USE DvdLibrary
--GO

--CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
--GO

--GRANT EXECUTE ON [Add] TO DvdLibraryApp
--GRANT EXECUTE ON [Delete] TO DvdLibraryApp
--GRANT EXECUTE ON Edit TO DvdLibraryApp
--GRANT EXECUTE ON GetAll TO DvdLibraryApp
--GRANT EXECUTE ON GetByDirector TO DvdLibraryApp
--GRANT EXECUTE ON GetById TO DvdLibraryApp
--GRANT EXECUTE ON GetByRating TO DvdLibraryApp
--GRANT EXECUTE ON GetByReleaseYear TO DvdLibraryApp
--GRANT EXECUTE ON GetByTitle TO DvdLibraryApp
--GO

--CREATE ROLE db_executor

--GRANT EXECUTE TO db_executor

--ALTER ROLE db_executor ADD MEMBER DvdLibraryApp

--use DvdLibrary
--go

--GRANT SELECT ON Dvd TO DvdLibraryApp
--GRANT INSERT ON Dvd TO DvdLibraryApp
--GRANT UPDATE ON Dvd TO DvdLibraryApp
--GRANT DELETE ON Dvd TO DvdLibraryApp
--GO
