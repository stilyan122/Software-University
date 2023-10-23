USE Bank;

/* --01. */
CREATE 
TABLE
Logs
(
	LogId INT PRIMARY KEY IDENTITY(1,1),
	AccountId INT,
	OldSum MONEY,
	NewSum MONEY
);

CREATE 
OR 
ALTER 
TRIGGER 
tr_EnterNewSumWhenUpdated
ON Accounts
FOR UPDATE
AS
BEGIN
	INSERT INTO Logs
	(AccountId,OldSum,NewSum)
	SELECT 
	i.Id,
	d.Balance,
	i.Balance
	FROM 
	inserted AS i
	JOIN deleted AS d
	ON i.Id = d.Id
	WHERE i.Balance <> d.Balance;
END;

--UPDATE Accounts
--SET Balance = 543.3000
--WHERE Id = 10;

--SELECT 
--*
--FROM Logs;

--SELECT 
--*
--FROM Accounts;

/* --02. */
CREATE 
TABLE 
NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Recipient INT,
	[Subject] NVARCHAR(MAX),
	Body NVARCHAR(MAX)
);

CREATE
OR
ALTER
TRIGGER
tr_CreateNewEmailWheneverLogged
ON Logs
FOR INSERT
AS
BEGIN
	INSERT INTO NotificationEmails
	(Recipient,[Subject],Body)
	SELECT
	AccountId,
	CONCAT_WS
	(' ',
	'Balance change for account:',
	AccountId),
	CONCAT
	(
	'On ',
	GETDATE(),' your balance was changed from ',
	OldSum,
	' to ',
	NewSum,
	'.')
	FROM
	inserted;
END;

--SELECT
--*
--FROM
--NotificationEmails;

/* --03. */
CREATE PROC usp_DepositMoney
(@AccountId INT, @MoneyAmount MONEY)
AS
	IF(
	@MoneyAmount > 0)
	BEGIN
		UPDATE Accounts
		SET Balance = Balance + @MoneyAmount
		WHERE Id=@AccountId;
	END;

--EXEC usp_DepositMoney 1,10;
--DROP PROC usp_DepositMoney;

/* --04. */
CREATE PROC usp_WithdrawMoney 
(@AccountId INT, @MoneyAmount MONEY)
AS
IF(
	@MoneyAmount > 0)
	BEGIN
		UPDATE Accounts
		SET Balance = Balance - @MoneyAmount
		WHERE Id=@AccountId;
	END;

--EXEC usp_WithdrawMoney 1,10;
--DROP PROC usp_WithdrawMoney;

/* --05. */
CREATE PROC usp_TransferMoney
(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
--BEGIN TRANSACTION
EXEC usp_DepositMoney @ReceiverId, @Amount;
EXEC usp_WithdrawMoney @SenderId, @Amount;
--ROLLBACK
--COMMIT;