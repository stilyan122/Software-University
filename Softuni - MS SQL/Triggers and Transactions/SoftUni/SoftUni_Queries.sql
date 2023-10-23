USE SoftUni;

/* --08. */
CREATE OR ALTER PROC usp_AssignProject
(@emloyeeId INT, @projectID INT)
AS
IF
(
(
	SELECT
	COUNT(EmployeeID) 
	FROM
    EmployeesProjects
	WHERE EmployeeID = @emloyeeId
) > 2
)
BEGIN
	THROW 50000, 'The employee has too many projects!', 1;
END
ELSE
BEGIN
	INSERT INTO EmployeesProjects(EmployeeID,ProjectID)
	VALUES (@emloyeeId,@projectID)
END;

/* --09. */
CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(200),
	LastName NVARCHAR(200),
	MiddleName NVARCHAR(200),
	JobTitle NVARCHAR(MAX),
	DepartmentId INT,
	Salary MONEY
);
CREATE TRIGGER tr_InsertRecordsForFiredEmployees
ON Employees
AFTER DELETE
AS
	INSERT INTO Deleted_Employees
	(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
	SELECT
	d.FirstName,
	d.LastName,d.MiddleName,d.JobTitle,
	d.DepartmentID,d.Salary
	FROM
	deleted AS d
;