if exists (select * from sys.databases where name = 'DB_Software')
DROP DATABASE DB_Software;
GO

CREATE DATABASE DB_Software;
GO

USE DB_Software;

if exists (select * from sys.tables where name = 'Software')
DROP TABLE Software
GO

CREATE TABLE Software (
	ID int identity(1,1) NOT NULL PRIMARY KEY,
	Name varchar(50),
	Provider varchar(50),
	Version int,
	ReleaseDate date,
	LicenseID int,
	License varchar(50)
);
GO

if exists (select * from sys.tables where name = 'License')
DROP TABLE License
GO

CREATE TABLE License (
	ID int NOT NULL PRIMARY KEY,
	LicenseName varchar(50),
	Terms varchar(100)
);
GO