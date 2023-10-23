--15.
CREATE DATABASE Hotel
CREATE TABLE Employees
(
  Id INT NOT NULL,
  FirstName NVARCHAR(100),
  LastName NVARCHAR(100),
  Title NVARCHAR(100) NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT emp_id PRIMARY KEY(Id)
);
CREATE TABLE Customers
(
  AccountNumber INT NOT NULL,
  FirstName NVARCHAR(100) NOT NULL,
  LastName NVARCHAR(100) NOT NULL,
  PhoneNumber CHAR(10) NOT NULL,
  EmergencyName NVARCHAR(100) NULL,
  EmergencyNumber NVARCHAR(100) NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT cus_id PRIMARY KEY(AccountNumber)
);
CREATE TABLE RoomStatus
(
  RoomStatus NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT sta_id PRIMARY KEY(RoomStatus)
);
CREATE TABLE RoomTypes
(
  RoomType NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT typ_id PRIMARY KEY(RoomType)
);
CREATE TABLE BedTypes
(
  BedType NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT bed_id PRIMARY KEY(BedType)
);
CREATE TABLE Rooms
( 
  RoomNumber INT NOT NULL,
  RoomType NVARCHAR(50) NOT NULL,
  BedType NVARCHAR(50) NOT NULL,
  Rate NVARCHAR(10) NOT NULL,
  RoomStatus NVARCHAR(50) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT num_id PRIMARY KEY(RoomNumber)
);
CREATE TABLE Payments
(
  Id INT NOT NULL,
  EmployeeId INT NOT NULL,
  PaymentDate DATE NOT NULL,
  AccountNumber INT NOT NULL,
  FirstDateOccupied DATE NOT NULL,
  LastDateOccupied DATE NOT NULL,
  TotalDays INT NOT NULL,
  AmountCharged FLOAT(2) NOT NULL,
  TaxRate FLOAT(2) NOT NULL,
  TaxAmount FLOAT(2) NOT NULL,
  PaymentTotal FLOAT(2) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT pay_id PRIMARY KEY(Id)
);
CREATE TABLE Occupancies
(
  Id INT NOT NULL,
  EmployeeId INT NOT NULL,
  DateOccupied DATE NOT NULL,
  AccountNumber INT NOT NULL,
  RoomNumber INT NOT NULL,
  RateApplied NVARCHAR(10) NOT NULL,
  PhoneCharge NVARCHAR(10) NOT NULL,
  Notes NVARCHAR(max) NULL
  CONSTRAINT occ_id PRIMARY KEY(Id)
); 
ALTER TABLE Rooms ADD FOREIGN KEY(RoomType) REFERENCES RoomTypes(RoomType);
ALTER TABLE Rooms ADD FOREIGN KEY(BedType) REFERENCES BedTypes(BedType);
ALTER TABLE Rooms ADD FOREIGN KEY(RoomStatus) REFERENCES RoomStatus(RoomStatus);
ALTER TABLE Payments ADD FOREIGN KEY(EmployeeId) REFERENCES Employees(Id);
ALTER TABLE Payments ADD FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber);
ALTER TABLE Occupancies ADD FOREIGN KEY(EmployeeId) REFERENCES Employees(Id);
ALTER TABLE Occupancies ADD FOREIGN KEY(AccountNumber) REFERENCES Customers(AccountNumber);
ALTER TABLE Occupancies ADD FOREIGN KEY(RoomNumber) REFERENCES Rooms(RoomNumber);
INSERT INTO Employees
(Id,FirstName,LastName,Title,Notes)
VALUES
(1,'Ivana','Petrova','I love my job','My job is the best'),
(2,'Sofia','Kalashkova','I hate my job','My job is very awful'),
(3,'Kristian','Bashkehaiov','Im bored',NULL)
INSERT INTO Customers
(AccountNumber,FirstName,LastName,
PhoneNumber,EmergencyName,EmergencyNumber,Notes)
VALUES
(1,'Kaloyan','Chobanov','0887645221','Koko','1',NULL),
(2,'Boshko','Varbanov','0893456732','Bobi','2','I love the shop'),
(3,'Cveta','Karayancheva','0876541908','Cveti','3','The shop is cringe')
INSERT INTO RoomStatus
(RoomStatus,Notes)
VALUES
('Excellent','10/10'),
('Good','5/10'),
('Bad',NULL)
INSERT INTO RoomTypes
(RoomType,Notes)
VALUES
('Double-bed','100$'),
('Single-bed','50$'),
('4-beds',NULL)
INSERT INTO BedTypes
(BedType,Notes)
VALUES
('Double-bed','100$'),
('Single-bed','50$'),
('4-beds',NULL)
INSERT INTO Rooms
(RoomNumber,RoomType,BedType,Rate,RoomStatus,Notes)
VALUES
(1,'Single-bed','Single-bed','10/10','Excellent','SUPER!'),
(2,'Double-bed','Double-bed','0/10','Bad','Didnt like it'),
(3,'4-beds','4-beds','5/10','Good',NULL)
INSERT INTO Payments
(Id,EmployeeId,PaymentDate,
AccountNumber,FirstDateOccupied,
LastDateOccupied,TotalDays,AmountCharged,
TaxRate,TaxAmount,PaymentTotal,Notes)
VALUES
(1,1,'2009-01-01',1,'2009-01-01','2009-01-01',
1,200.00,23.33,222.22,300.00,NULL),
(2,2,'2019-01-01',2,'2019-01-01','2009-01-01',
1,400.00,23.33,222.22,300.00,'Cool room!'),
(3,3,'2029-01-01',3,'2029-01-01','2009-01-01',
1,500.00,23.33,222.22,300.00,'Not my cup of tea')
INSERT INTO Occupancies
(Id,EmployeeId,DateOccupied,AccountNumber,
RoomNumber,RateApplied,PhoneCharge,Notes)
VALUES
(1,1,'2004-02-02',1,1,'10/10','1111',NULL),
(2,2,'2005-02-02',2,2,'450/10','2451','I liked it'),
(3,3,'2007-02-02',3,3,'20/10','1666','AMAZING!')

--23.
UPDATE Payments
SET TaxRate = TaxRate - 0.03*TaxRate;
SELECT TaxRate FROM Payments;
--24.
DELETE FROM Occupancies;
