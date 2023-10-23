USE SoftUni

/* --01. */
SELECT [FirstName],[LastName] FROM Employees WHERE LEFT(FirstName,2)='SA';

/* --02. */
SELECT [FirstName],[LastName] FROM Employees WHERE CHARINDEX('ei',LastName,1)>0;

/* --03. */
SELECT [FirstName] 
FROM Employees 
WHERE ([DepartmentID]=3 OR [DepartmentID] = 10) AND (DATEPART(YEAR,[HireDate]) BETWEEN '1995' AND '2005');

/* --04. */
SELECT [FirstName],[LastName] FROM Employees WHERE CHARINDEX('engineer',JobTitle)=0;

/* --05. */
SELECT [Name] FROM Towns WHERE LEN([Name]) = 5 OR LEN([Name]) = 6 ORDER BY [Name];

/* --06. */
SELECT [TownID],[Name] FROM Towns 
WHERE 
SUBSTRING([Name],1,1)='M' OR
SUBSTRING([Name],1,1)='K' OR
SUBSTRING([Name],1,1)='B' OR
SUBSTRING([Name],1,1)='E'
ORDER BY [Name];

/* --07. */
SELECT [TownID],[Name] FROM Towns 
WHERE 
SUBSTRING([Name],1,1) <> 'R' AND
SUBSTRING([Name],1,1) <> 'B' AND
SUBSTRING([Name],1,1) <> 'D'
ORDER BY [Name];

/* --08. */
/* CREATE VIEW V_EmployeesHiredAfter2000 AS */
SELECT [FirstName],[LastName]
FROM Employees
WHERE DATEPART(YEAR,[HireDate])>2000;

/* --09. */
SELECT [FirstName],[LastName]
FROM Employees
WHERE LEN([LastName]) = 5;

/* --10. */
SELECT [EmployeeId],[FirstName],[LastName],[Salary],
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC;

/* --11. */
SELECT [EmployeeID],[FirstName],[LastName],[Salary],[Rank] 
FROM (SELECT [EmployeeID],[FirstName],[LastName],[Salary],
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) 
AS d
WHERE d.[Rank] = 2
ORDER BY d.Salary DESC;