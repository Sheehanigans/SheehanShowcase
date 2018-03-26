USE master
GO
 
IF EXISTS(SELECT * FROM sys.databases WHERE Name='DvdLibrary')
DROP DATABASE DvdLibrary
GO
 
CREATE DATABASE DvdLibrary
GO