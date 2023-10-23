USE SoftUni;

/* --01. */
SELECT TOP 5
e.[EmployeeID],
e.[JobTitle],
e.[AddressID],
a.[AddressText]
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY a.AddressID;

/* --02. */
SELECT TOP 50
e.[FirstName],
e.[LastName],
t.[Name],
a.[AddressText]
FROM Employees AS e
JOIN Addresses AS a
ON e.[AddressID] = a.[AddressID]
JOIN Towns AS t
ON a.[TownID] = t.[TownID]
ORDER BY e.[FirstName],e.[LastName];

/* --03. */
SELECT
e.[EmployeeID],
e.[FirstName],
e.[LastName],
d.[Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Departments AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE d.[Name] = 'Sales'
ORDER BY e.[EmployeeID];

/* --04. */
SELECT TOP 5
e.[EmployeeID],
e.[FirstName],
e.[Salary],
d.[Name] AS 'DepartmentName'
FROM Employees AS e
JOIN Departments AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[Salary] > 15000
ORDER BY e.[DepartmentID];

/* --05. */
SELECT TOP 3
e.[EmployeeID],
e.[FirstName]
FROM Employees AS e
WHERE e.[EmployeeID] NOT IN (
SELECT [EmployeeID] FROM EmployeesProjects
)
ORDER BY e.[EmployeeID];

/* --06. */
SELECT 
e.[FirstName],
e.[LastName],
e.[HireDate],
d.[Name] AS 'DeptName'
FROM Employees AS e
JOIN Departments AS d
ON e.[DepartmentID] = d.[DepartmentID]
WHERE e.[HireDate] > '1999-01-01' 
AND (
d.[Name] = 'Sales' OR
d.[Name] = 'Finance'
)
ORDER BY e.[HireDate];

/* --07. */
SELECT TOP 5
e.[EmployeeID],
e.[FirstName],
p.[Name] AS 'ProjectName'
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
JOIN Projects AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE 
p.[StartDate] > '2002-08-13' 
AND 
p.[EndDate] IS NULL
ORDER BY e.[EmployeeID];

/* --08. */
SELECT
e.[EmployeeID],
e.[FirstName],
CASE
WHEN DATEPART(YEAR,p.[StartDate]) >= 2005 THEN NULL
ELSE p.[Name]
END
AS 'ProjectName'
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.[EmployeeID] = ep.[EmployeeID]
JOIN Projects AS p
ON ep.[ProjectID] = p.[ProjectID]
WHERE e.EmployeeID = 24;

/* --09. */
SELECT 
e.[EmployeeID],
e.[FirstName],
e.[ManagerID],
e2.[FirstName] AS 'ManagerName'
FROM Employees AS e
JOIN Employees AS e2
ON e.[ManagerID] = e2.[EmployeeID]
WHERE 
e.[ManagerID] = 3 OR
e.[ManagerID] = 7
ORDER BY e.[EmployeeID];

/* --10. */
SELECT TOP 50
e.[EmployeeID],
e.[FirstName] + ' ' + e.[LastName] AS 'EmployeeName',
e2.[FirstName] + ' ' + e2.[LastName] AS 'ManagerName',
d.[Name] AS 'DepartmentName' 
FROM Employees AS e
JOIN Employees AS e2
ON e.[ManagerID] = e2.[EmployeeID]
JOIN Departments AS d
ON e.[DepartmentID] = d.[DepartmentID]
ORDER BY e.[EmployeeID];

/* --11. */
SELECT MIN(a.Average) FROM
(
SELECT AVG(Salary) AS 'Average'
FROM Employees AS e
JOIN Departments AS d
ON e.[DepartmentID] = d.[DepartmentID]
GROUP BY d.[DepartmentID]
) AS a;