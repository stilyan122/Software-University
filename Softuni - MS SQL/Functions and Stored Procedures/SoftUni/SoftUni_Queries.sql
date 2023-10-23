USE SoftUni;

/* --01. */
CREATE OR ALTER PROC usp_GetEmployeesSalaryAbove35000 AS
SELECT
FirstName AS 'First Name',
LastName AS 'Last Name'
FROM
Employees
WHERE Salary > 35000;

--EXEC usp_GetEmployeesSalaryAbove35000;
--DROP PROC usp_GetEmployeesSalaryAbove35000;

/* --02. */
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber  
(@Number DECIMAL(18,4)) AS
SELECT
FirstName AS 'First Name',
LastName AS 'Last Name'
FROM
Employees
WHERE Salary >= @Number;

--EXEC usp_GetEmployeesSalaryAboveNumber 48100;
--DROP PROC usp_GetEmployeesSalaryAboveNumber;

/* --03. */
CREATE OR ALTER PROC usp_GetTownsStartingWith
(@String NVARCHAR(100)) AS
SELECT 
[Name]
FROM Towns
WHERE UPPER(SUBSTRING([Name],1,LEN(@String))) = UPPER(@String);

--EXEC usp_GetTownsStartingWith 'be';
--DROP PROC usp_GetTownsStartingWith;

/* --04. */
CREATE OR ALTER PROC usp_GetEmployeesFromTown
(@Town NVARCHAR(200)) AS
SELECT
FirstName AS 'First Name',
LastName AS 'Last Name'
FROM 
Employees AS e
JOIN 
Addresses AS a
ON e.AddressID = a.AddressID
JOIN
Towns AS t
ON a.TownID = t.TownID
WHERE t.[Name]= @Town;

--EXEC usp_GetEmployeesFromTown 'Sofia';
--DROP PROC usp_GetTownsStartingWith;

/* --05. */
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20) 
AS
BEGIN
DECLARE @result NVARCHAR(20);
IF @salary < 30000
BEGIN
SET @result = 'Low';
END;
ELSE IF @salary <= 50000
BEGIN
SET @result = 'Average';
END;
ELSE
BEGIN
SET @result = 'High';
END;
RETURN @result;
END;

/* --06. */
CREATE PROC usp_EmployeesBySalaryLevel 
(@level NVARCHAR(20))
AS
SELECT
FirstName AS 'First Name',
LastName AS 'Last Name'
FROM 
Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @level;

--EXEC usp_EmployeesBySalaryLevel 'Low';
--DROP PROC usp_EmployeesBySalaryLevel;

/* --07. */
CREATE FUNCTION ufn_IsWordComprised
(@setOfLetters NVARCHAR(200), @word NVARCHAR(200))
RETURNS BIT
AS
BEGIN
 DECLARE @isComprised BIT = 1;

    DECLARE @setLen INT = LEN(@setOfLetters);
    DECLARE @wordLen INT = LEN(@word);
    DECLARE @i INT = 1;

    WHILE @i <= @wordLen
    BEGIN
        DECLARE @char CHAR(1) = LOWER(SUBSTRING(@word, @i, 1));
        IF CHARINDEX(@char, LOWER(@setOfLetters)) = 0
        BEGIN
            SET @isComprised = 0;
            BREAK;
        END

        SET @i = @i + 1;
    END
    RETURN @isComprised;
END;

/* --08. */
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment 
(@departmentId INT)
AS
	DECLARE @EmployeesToDelete TABLE ([Id] INT);
		INSERT INTO @EmployeesToDelete
		SELECT EmployeeId FROM Employees
		WHERE DepartmentID = @departmentId;

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT * FROM @EmployeesToDelete);
	
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT;

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @EmployeesToDelete);

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT * FROM @EmployeesToDelete);

	DELETE FROM Employees 
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments 
	WHERE DepartmentID = @departmentId	
SELECT 
COUNT(*) 
FROM Employees
WHERE DepartmentID = @departmentId;

--EXEC usp_DeleteEmployeesFromDepartment 1;
--DROP PROC usp_DeleteEmployeesFromDepartment;