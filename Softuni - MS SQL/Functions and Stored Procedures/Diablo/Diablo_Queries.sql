USE Diablo;

 /* --13. */
 CREATE FUNCTION ufn_CashInUsersGames
 (@game NVARCHAR(200))
 RETURNS Table
 AS
 RETURN
 SELECT
 SUM(Cash) AS 'SumCash'
 FROM
    (SELECT Cash,
	ROW_NUMBER() OVER (ORDER BY u.Cash DESC) AS 'Rank'
	FROM
	(
		SELECT
		Id AS 'GameId'
		FROM
		Games
		WHERE [Name] = @game
	) AS t
	JOIN UsersGames AS u
	ON t.GameId = u.GameId
	) 
	AS ordered
	WHERE [Rank] % 2 = 1;