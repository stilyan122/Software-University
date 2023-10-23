--07.
 CREATE TABLE People(
  Id INT PRIMARY KEY NOT NULL,
  [Name] NVARCHAR(200) NOT NULL,
  Picture VARBINARY(max) NULL,
  Height FLOAT(2) NULL,
  [Weight] FLOAT(2) NULL,
  Gender CHAR(1) NOT NULL,
  Birthdate DATE NOT NULL,
  Biography NVARCHAR(max) NULL
 );
 INSERT INTO People
 (Id,[Name],Picture,
 Height,[Weight],Gender,
 Birthdate,Biography
 ) VALUES
 (1,'Petar',3,122.45,67.80,'m','1999-11-15','Really talented person!'),
 (2,'Ivan',NULL,NULL,NULL,'m','2000-01-01','Nothing interesting'),
 (3,'Maria',12,150.44,NULL,'f','2005-12-12',NULL),
 (4,'Stanimir',NULL,NULL,NULL,'m','1970-06-04',NULL),
 (5,'Svetlana',40,167.66,70.70,'f','1999-12-11','The best person in the world!')
