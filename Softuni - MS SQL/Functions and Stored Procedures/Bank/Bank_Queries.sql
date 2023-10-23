USE Bank;

/* --09. */
CREATE OR ALTER PROC usp_GetHoldersFullName 
AS
SELECT
CONCAT_WS(' ',FirstName,LastName) AS 'Full Name'
FROM
AccountHolders;

--EXEC usp_GetHoldersFullName;
--DROP PROC usp_GetHoldersFullName;

/* --10. */
CREATE OR ALTER PROC usp_GetHoldersWithBalanceHigherThan
(@amount MONEY)
AS
SELECT
FirstName,LastName
FROM
AccountHolders AS ah
JOIN Accounts AS a
ON ah.Id = a.AccountHolderId
GROUP BY FirstName,LastName
HAVING SUM(Balance) > @amount
ORDER BY FirstName,LastName;

/* --11. */
CREATE OR ALTER FUNCTION ufn_CalculateFutureValue 
(@sum MONEY,@yir FLOAT, @years INT)
RETURNS MONEY
AS
BEGIN
RETURN 
@sum*POWER(1+@yir,@years)
END;

/* --12. */
CREATE OR ALTER PROC usp_CalculateFutureValueForAccount 
(@AccountId INT, @InterestRate FLOAT) AS
SELECT a.Id AS [Account Id],
	   ah.FirstName AS [First Name],
	   ah.LastName AS [Last Name],
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(Balance, @InterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a ON ah.Id = a.Id
 WHERE a.Id = @AccountId;
