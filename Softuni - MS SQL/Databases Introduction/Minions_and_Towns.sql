 --01.
 CREATE DATABASE Minions
 --02.
 CREATE TABLE Minions(
 Id int NOT NULL,
 [Name] nvarchar(150) NULL,
 Age int NULL
 CONSTRAINT PKID PRIMARY KEY(Id)
);
 CREATE TABLE Towns(
  Id int NOT NULL,
  [Name] nvarchar(150) NULL
  CONSTRAINT PKIDTOWN PRIMARY KEY(Id)
);
 --03.
 ALTER TABLE Minions ADD TownId int NOT NULL;
 ALTER TABLE Minions ADD FOREIGN KEY(TownId) REFERENCES Towns(Id);
 --04.
 INSERT INTO Towns (Id,[Name]) VALUES 
 (1,'Sofia'),
 (2,'Plovdiv'),
 (3,'Varna')
 INSERT INTO Minions (Id,[Name],Age,TownId) VALUES 
 (1,'Kevin',22,1),
 (2,'Bob',15,3),
 (3,'Steward',NULL,2)
 --05.
 DELETE FROM Minions;
 --06.
 DROP TABLE Minions;
 DROP TABLE Towns;