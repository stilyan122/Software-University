--14.
CREATE DATABASE CarRental;
CREATE TABLE RentalOrders(
 Id INT NOT NULL,
 EmployeeId INT NOT NULL,
 CustomerId INT NOT NULL,
 CarId INT NOT NULL,
 TankLevel INT NULL,
 KilometrageStart INT NOT NULL,
 KilometrageEnd INT NOT NULL,
 TotalKilometrage INT NOT NULL,
 StartDate DATE NOT NULL,
 EndDate DATE NOT NULL,
 TotalDays INT NOT NULL,
 RateApplied INT NULL,
 TaxRate INT NULL,
 OrderStatus NVARCHAR(200) NULL,
 Notes NVARCHAR(max) NULL
 CONSTRAINT ord_id PRIMARY KEY(Id)
);
CREATE TABLE Categories(
 Id INT NOT NULL,
 CategoryName NVARCHAR(100) NOT NULL,
 DailyRate NVARCHAR(100) NULL,
 WeeklyRate NVARCHAR(100) NULL,
 MonthlyRate NVARCHAR(100) NULL,
 WeekendRate NVARCHAR(100) NULL
 CONSTRAINT cat_id PRIMARY KEY(Id)
);
CREATE TABLE Cars(
 Id INT NOT NULL,
 PlateNumber NVARCHAR(50) NOT NULL,
 Manifacturer NVARCHAR(100) NOT NULL,
 Model NVARCHAR(100) NOT NULL,
 CarYear INT NOT NULL,
 CategoryId INT NOT NULL,
 Doors NVARCHAR(100) NULL,
 Picture VARBINARY(max) NULL,
 Condition NVARCHAR(50) NULL,
 Available NVARCHAR(100) NOT NULL
 CONSTRAINT car_id PRIMARY KEY(Id)
);
CREATE TABLE Employees(
 Id INT NOT NULL,
 FirstName NVARCHAR(100) NOT NULL,
 LastName NVARCHAR(100) NOT NULL,
 Title NVARCHAR(200) NULL,
 Notes NVARCHAR(max) NULL
 CONSTRAINT emp_id PRIMARY KEY(Id)
);
CREATE TABLE Customers(
 Id INT NOT NULL,
 DriverLicenceNumber NVARCHAR(100) NOT NULL,
 FullName NVARCHAR(200) NOT NULL,
 [Address] NVARCHAR(100) NOT NULL,
 City NVARCHAR(100) NOT NULL,
 ZIPCode INT NOT NULL,
 Notes NVARCHAR(max) NULL
 CONSTRAINT cus_id PRIMARY KEY(Id)
);
ALTER TABLE RentalOrders ADD FOREIGN KEY(EmployeeId) REFERENCES Employees(Id);
ALTER TABLE RentalOrders ADD FOREIGN KEY(CustomerId) REFERENCES Customers(Id);
ALTER TABLE RentalOrders ADD FOREIGN KEY(CarId) REFERENCES Cars(Id);
ALTER TABLE Cars ADD FOREIGN KEY(CategoryId) REFERENCES Categories(Id);
INSERT INTO Categories
(Id,CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate)
VALUES
(1,'A','5/10','6/10','8/10','9/10'),
(2,'B','6/10','7/10','9/10','1/10'),
(3,'C','7/10','7/10','9/10','2/10')
INSERT INTO Cars
(Id,PlateNumber,Manifacturer,
Model,CarYear,CategoryId,Doors,
Picture,Condition,Available)
VALUES
(1,'SB:202020','SV Cars','Maro 2020',2020,1,'Perfect',NULL,'Good','yes'),
(2,'VD:412456','TY Cars','Capto 2030',2030,2,'Perfect, but not 100%',120,'Chill','yes'),
(3,'BV:120334','TLO (JV) Cars','Kripta Maca 2050',2050,3,'Good',300,'Not much','no')
INSERT INTO Employees
(Id,FirstName,LastName,Title,Notes)
VALUES
(1,'Penka','Svetlanova','THE BEST',NULL),
(2,'Ivan','Kostov','I work everyday','loves his job'),
(3,'Hristo','Ivanov','Hate my job',NULL)
INSERT INTO Customers
(Id,DriverLicenceNumber,FullName,[Address],City,ZIPCode,Notes)
VALUES
(1,'SB:202020','Svetlozar Kabashev','Hristo B. N12','Sofia',400,NULL),
(2,'VD:412456','Gary Prinkov','Stara Planina N22','Burgas',500,'Amazing car! 10/10'),
(3,'SBV:120334','Svetlio Prangov','Cherna Gora N45','Plovdiv',100,'I dont like the car 1/10')
INSERT INTO RentalOrders
(Id,EmployeeId,CustomerId,CarId,
TankLevel,KilometrageStart,KilometrageEnd,
TotalKilometrage,StartDate,EndDate,TotalDays,
RateApplied,TaxRate,OrderStatus,Notes)
VALUES 
(1,1,1,1,200,40000,80000,40000,
'2008-11-11','2021-11-11',10,100,10,'10/10',NULL),
(2,2,2,2,400,60000,80000,20000,
'2007-11-11','2021-11-11',60,100,8,'6/10','Cool car!'),
(3,3,3,3,700,10000,80000,70000,
'2005-11-11','2022-11-11',365,0,6,'1/10','I dont like it!');