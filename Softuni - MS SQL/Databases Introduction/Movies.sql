--13.
CREATE DATABASE Movies;
 CREATE TABLE Movies(
  Id INT NOT NULL,
  Title NVARCHAR(100) NOT NULL,
  DirectorId INT NOT NULL,
  CopyrightYear INT NOT NULL,
  [Length] INT NOT NULL,
  GenreId INT NOT NULL,
  CategoryId INT NOT NULL,
  Rating NVARCHAR(50) NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT pk_idMovie PRIMARY KEY(Id)
 );
 CREATE TABLE Directors(
  Id INT NOT NULL,
  DirectorName NVARCHAR(100) NOT NULL,
  Notes NVARCHAR(max) NUll
  CONSTRAINT pk_idDirector PRIMARY KEY(Id)
 );
 CREATE TABLE Genres(
  Id INT NOT NULL,
  GenreName NVARCHAR(100) NOT NULL,
  Notes NVARCHAR(max) NUll
  CONSTRAINT pk_idGenres PRIMARY KEY(Id)
 );
 CREATE TABLE Categories(
  Id INT NOT NULL,
  CategoryName NVARCHAR(100) NOT NULL,
  Notes NVARCHAR(max) NUll
  CONSTRAINT pk_idCategories PRIMARY KEY(Id)
 );
 ALTER TABLE [Movies] ADD FOREIGN KEY(GenreId) REFERENCES [Genres](Id);
 ALTER TABLE [Movies] ADD FOREIGN KEY(CategoryId) REFERENCES [Categories](Id);
 ALTER TABLE [Movies] ADD FOREIGN KEY(DirectorId) REFERENCES [Directors](Id);
 INSERT INTO [Directors]
 (Id,DirectorName,Notes)
 VALUES
 (1,'Svetlio',NULL),
 (2,'Dimitar','Amazing person!'),
 (3,'Hristina','Love<3!'),
 (5,'Kaloyan','nothing personal'),
 (4,'Krustio',NULL);
 INSERT INTO [Genres]
 (Id,GenreName,Notes)
 VALUES
 (1,'Thriller',NULL),
 (2,'Drama','so dramatic!'),
 (3,'Comedy','HAHAH'),
 (4,'Musical','dance dance dance'),
 (5,'Romantic',NULL);
 INSERT INTO [Categories]
 (Id,CategoryName,Notes)
 VALUES
 (1,'Cool','so cool?!'),
 (2,'OK','its ok i guess?'),
 (3,'Middle',NULL),
 (4,'Bad','i dont like it'),
 (5,'Terrible',NULL);
 INSERT INTO [Movies]
 (
 Id,Title,DirectorId,CopyrightYear,
 [Length],GenreId,CategoryId,Rating,Notes
 )
 VALUES 
 (1,'Titanic',2,1970,2,2,2,'5/10','Vary basic'),
 (2,'Harry Potter',5,2000,3,5,5,'Cool','Its good'),
 (3,'Pirates of the Carribean',1,2015,3,1,1,'9/10','Very interesting'),
 (4,'Lilly the fish',4,2020,2,4,4,'1/10','SO BORING!'),
 (5,'Super Mario',3,2021,3,3,3,'10/10','AMAZING')
