USE Gringotts

/* --01. */
SELECT 
COUNT(*) AS 'Count'
FROM
WizzardDeposits;

/* --02. */
SELECT
MAX(MagicWandSize) 
AS 'LongestMagicWand'
FROM
WizzardDeposits;

/* --03. */
SELECT
DepositGroup,
MAX(MagicWandSize) 
AS 'LongestMagicWand'
FROM
WizzardDeposits
GROUP BY DepositGroup;

/* --04. */
SELECT TOP 2
DepositGroup
FROM
WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize);

/* --05. */
SELECT
DepositGroup,
SUM(DepositAmount) 
AS 'TotalSum'
FROM
WizzardDeposits
GROUP BY DepositGroup;

/* --06. */
SELECT
DepositGroup,
SUM(DepositAmount) 
AS 'TotalSum'
FROM
(  
   SELECT 
   *
   FROM 
   WizzardDeposits
   WHERE MagicWandCreator='Ollivander family'
) 
AS a
GROUP BY DepositGroup;

/* --07. */
SELECT
DepositGroup,
SUM(DepositAmount) 
AS 'TotalSum'
FROM
(  
   SELECT 
   *
   FROM 
   WizzardDeposits
   WHERE MagicWandCreator='Ollivander family'
) 
AS a
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY SUM(DepositAmount) DESC;

/* --08. */
SELECT 
DepositGroup,
MagicWandCreator,
MIN(DepositCharge) AS 'MinDepositCharge'
FROM
WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator,DepositGroup;

/* --09. */
SELECT
AgeGroup,
SUM(WizardCount) AS 'WizardCount'
FROM
(
   SELECT
   CASE
   WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
   WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
   WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
   WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
   WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
   WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
   ELSE '[61+]'
   END
   AS 'AgeGroup',
   COUNT(*) AS 'WizardCount'
   FROM
      (
	  SELECT
       Age
       FROM 
       WizzardDeposits
	   ) 
       AS t
	GROUP BY Age
) 
AS t2
GROUP BY AgeGroup;

/* --10. */
SELECT DISTINCT
SUBSTRING(FirstName,1,1) AS 'FirstLetter'
FROM
WizzardDeposits
GROUP BY FirstName,DepositGroup
HAVING DepositGroup = 'Troll Chest'
ORDER BY FirstLetter;

/* --11. */
 SELECT
 DepositGroup,
 IsDepositExpired,
 AVG(DepositInterest) AS 'AverageInterest'
 FROM
 (
   SELECT
   DepositGroup,
   DepositInterest,
   IsDepositExpired
   FROM
   WizzardDeposits
   GROUP BY DepositGroup,DepositInterest,DepositStartDate,IsDepositExpired
   HAVING DepositStartDate > '1985-01-01'
  )
   AS t
  GROUP BY DepositGroup,IsDepositExpired
  ORDER BY DepositGroup DESC,IsDepositExpired;

/* --12. */
SELECT
	SUM([Difference]) AS 'SumDifference'
	FROM
		(SELECT
		 [Difference]
		FROM
			(SELECT 
			[Host Wizard],
			[Host Wizard Deposit],
			[Guest Wizard],
			[Guest Wizard Deposit],
			[Host Wizard Deposit] - [Guest Wizard Deposit] AS 'Difference'
			FROM
				(SELECT
				FirstName AS 'Host Wizard',
				DepositAmount AS 'Host Wizard Deposit',
				LEAD(FirstName) OVER (ORDER BY Id) AS 'Guest Wizard',
				LEAD(DepositAmount) OVER (ORDER BY Id) AS 'Guest Wizard Deposit'
				FROM
				WizzardDeposits
				) AS t
			) AS t2
		GROUP BY [Difference]
		) AS t3;