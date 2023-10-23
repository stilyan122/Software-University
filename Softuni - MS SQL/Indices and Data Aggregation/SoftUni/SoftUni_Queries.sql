USE SoftUni

/* --13. */
SELECT
	DepartmentID,
	SUM(Salary) AS 'TotalSalary'
FROM
Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

/* --14. */
SELECT
	DepartmentID,
	MIN(Salary) AS 'MinimumSalary'
FROM
Employees
WHERE 
(DepartmentID = 2 OR DepartmentID = 5 OR DepartmentID = 7)
AND HireDate > '2000-01-01'
GROUP BY DepartmentID;

/* --15. */
SELECT 
* 
INTO EmployeesWhoEarnMoreThan3000
FROM Employees
WHERE Salary > 30000;

DELETE
FROM
EmployeesWhoEarnMoreThan3000
WHERE ManagerId = 42;

UPDATE 
EmployeesWhoEarnMoreThan3000
SET Salary = Salary + 5000
WHERE DepartmentID = 1;

SELECT
DepartmentId,
AVG(Salary) AS 'AverageSalary'
FROM EmployeesWhoEarnMoreThan3000
GROUP BY DepartmentID;

/* --16. */
SELECT
DepartmentId,
MAX(Salary) AS 'MaxSalary'
FROM
Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000;

/* --17. */
SELECT
COUNT(*) AS 'Count' 
FROM
Employees
WHERE ManagerId IS NULL;

/* --18. */
SELECT DepartmentID, 
   (SELECT DISTINCT Salary FROM Employees 
   WHERE DepartmentID = e.DepartmentID 
   ORDER BY Salary DESC 
   OFFSET 2 ROWS 
   FETCH NEXT 1 ROWS ONLY)
   AS ThirdHighestSalary
 FROM Employees e
WHERE 
(SELECT DISTINCT Salary 
 FROM Employees 
 WHERE DepartmentID = e.DepartmentID 
 ORDER BY Salary DESC 
 OFFSET 2 ROWS 
 FETCH NEXT 1 ROWS ONLY) 
 IS NOT NULL
 GROUP BY DepartmentID;

/* --19. */
SELECT TOP 10
e.FirstName,
e.LastName,
e.DepartmentID
FROM
Employees AS e
WHERE e.Salary > 
(
    SELECT
	AVG(Salary)
	FROM
	Employees AS e2
	GROUP BY e2.DepartmentId
	HAVING e2.DepartmentID = e.DepartmentID
)
ORDER BY e.DepartmentID;