--16.
CREATE DATABASE SoftUni
CREATE TABLE Towns
(
 Id INT NOT NULL IDENTITY(1,1),
 [Name] NVARCHAR(100) NOT NULL
 CONSTRAINT town_id PRIMARY KEY(Id)
);
CREATE TABLE Adresses
(
 Id INT NOT NULL IDENTITY(1,1),
 AddressText NVARCHAR(100) NOT NULL,
 TownId INT NOT NULL
 CONSTRAINT address_id PRIMARY KEY(Id)
);
CREATE TABLE Departments
(
 Id INT NOT NULL IDENTITY(1,1),
 [Name] NVARCHAR(100) NOT NULL
 CONSTRAINT dep_id PRIMARY KEY(Id)
);
CREATE TABLE Employees
(
 Id INT NOT NULL IDENTITY(1,1),
 FirstName NVARCHAR(100) NOT NULL,
 MiddleName NVARCHAR(100) NOT NULL,
 LastName NVARCHAR(100) NOT NULL,
 JobTitle NVARCHAR(100) NOT NULL,
 DepartmentId INT NOT NULL,
 HireDate DATE NOT NULL,
 Salary FLOAT(2) NOT NULL,
 AddressId INT NOT NULL
 CONSTRAINT empl_id PRIMARY KEY(Id)
);
ALTER TABLE Employees ADD FOREIGN KEY(DepartmentId) REFERENCES Department(Id);
ALTER TABLE Employees ADD FOREIGN KEY(AddressId) REFERENCES Adresses(Id);
ALTER TABLE Adresses ADD FOREIGN KEY(TownId) REFERENCES Towns(Id);

--17. backup... (link for help video: https://www.youtube.com/watch?v=lEsTwrETh_E)

--18.
INSERT INTO Towns
(Id,[Name])
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna'),
(4,'Burgas')

INSERT INTO Departments
(Id,[Name])
VALUES
(1,'Engineering'),
(2,'Sales'),
(3,'Marketing'),
(4,'Software Development'),
(5,'Quality Assurance')

INSERT INTO Employees
(Id,FirstName,MiddleName,LastName,
JobTitle,DepartmentId,HireDate,Salary,AddressId)
VALUES
(1,'Ivan','Ivanov','Ivanov',
'.NET Developer','Software Development'
,'01/02/2013',3500.00,1),
(2,'Petar','Petrov','Petrov',
'Senior Engineer','Engineering'
,'02/03/2004',4000.00,2),
(3,'Maria','Petrova','Ivanova',
'Intern','Quality Assurance'
,'28/08/2016',525.25,3),
(4,'Georgi','Teziev','Ivanov',
'CEO','Sales'
,'09/12/2007',3000.00,4),
(5,'Peter','Pan','Pan',
'Intern','Marketing'
,'28/08/2016',599.88,5)

--19.
SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;
--20.
SELECT * FROM Towns ORDER BY [Name];
SELECT * FROM Departments ORDER BY [Name];
SELECT * FROM Employees ORDER BY Salary DESC;
--21.
SELECT [Name] FROM Towns ORDER BY [Name];
SELECT [Name] FROM Departments ORDER BY [Name];
SELECT FirstName,LastName,JobTitle,Salary FROM Employees ORDER BY Salary DESC;
--22.
UPDATE Employees
SET Salary = Salary + 0.10 * Salary;
SELECT Salary FROM Employees;