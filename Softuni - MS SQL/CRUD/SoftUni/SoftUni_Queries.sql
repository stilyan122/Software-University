--1.Downloaded
--2.
SELECT * FROM dbo.Departments;
--3.
SELECT [Name] FROM dbo.Departments;
--4.
SELECT [FirstName],[LastName],[Salary] FROM dbo.Employees;
--5.
SELECT [FirstName],[MiddleName],[LastName] FROM dbo.Employees;
--6.
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg'
AS [Full Email Address] 
FROM dbo.Employees;
--7.
SELECT DISTINCT [Salary]
AS [Salary]
FROM dbo.Employees;
--8.
SELECT * 
FROM dbo.Employees
WHERE [JobTitle]= 'Sales Representative';
--9.
SELECT [FirstName],[LastName],[JobTitle]
FROM dbo.Employees
WHERE [Salary] BETWEEN 20000 AND 30000;
--10.
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
FROM dbo.Employees
WHERE [Salary] IN (25000, 14000, 12500, 23600);
--11.
SELECT [FirstName],[LastName]
FROM dbo.Employees
WHERE [ManagerID] IS NULL;
--12.
SELECT [FirstName],[LastName],[Salary]
FROM dbo.Employees
WHERE [Salary] > 50000
ORDER BY [Salary] DESC;
--13.
SELECT TOP(5) [FirstName],[LastName]
FROM dbo.Employees
ORDER BY [Salary] DESC;
--14.
SELECT [FirstName],[LastName]
FROM dbo.Employees
WHERE [DepartmentID] <> 4;
--15.
SELECT *
FROM dbo.Employees
ORDER BY [Salary] DESC, [FirstName], [LastName] DESC, [MiddleName];
--16.
-- CREATE VIEW V_EmployeesSalaries AS
-- SELECT [FirstName],[LastName],[Salary]
-- FROM dbo.Employees;
--17.
-- CREATE VIEW V_EmployeeNameJobTitle AS
-- SELECT [FirstName] + ' ' + ISNULL([MiddleName],'') + ' ' + [LastName] AS [Full Name],[JobTitle]
-- FROM dbo.Employees;
--18.
SELECT DISTINCT [JobTitle]
FROM dbo.Employees;
--19.
SELECT TOP(10) *
FROM dbo.Projects
ORDER BY [StartDate],[Name];
--20.
SELECT TOP(7) [FirstName],[LastName],[HireDate]
FROM dbo.Employees
ORDER BY [HireDate] DESC;
--21.
-- BEGIN TRANSACTION
-- UPDATE dbo.Employees
-- SET [Salary] = [Salary] + 0.12 * [Salary]
-- WHERE [DepartmentID] = 1 OR [DepartmentID] = 2
-- OR [DepartmentID] = 4 OR [DepartmentID] = 11;
-- SELECT [Salary] 
-- FROM dbo.Employees;
-- COMMIT TRANSACTION;
-- ROLLBACK TRANSACTION;