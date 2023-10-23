USE Diablo;

/* --01. */
SELECT
	SUBSTRING
	(
	Email,
	CHARINDEX('@',Email)+1,
	LEN(Email)-CHARINDEX('@',Email)+1
	) AS 'Email Provider',
	COUNT(Username) AS 'Number of Users'
FROM
Users
GROUP BY 
	SUBSTRING
	(
	Email,
	CHARINDEX('@',Email)+1,
	LEN(Email)-CHARINDEX('@',Email)+1
	)
ORDER BY COUNT(Username) DESC,
SUBSTRING
	(
	Email,
	CHARINDEX('@',Email)+1,
	LEN(Email)-CHARINDEX('@',Email)+1
	);

/* --02. */
SELECT
	g.[Name] AS 'Game',
	gt.[Name] AS 'Game Type',
	u.Username,
	ug.[Level],
	ug.Cash,
	c.[Name] AS 'Character'
FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
JOIN Characters AS c
ON c.Id = ug.CharacterId
ORDER BY [Level] DESC,
Username,g.[Name];

/* --03. */
SELECT
	u.Username,
	g.[Name] AS 'Game',
	COUNT(i.Id) AS 'Items Count',
	SUM(i.Price) AS 'Items Price'
FROM
Users AS u
JOIN 
UsersGames AS ug
ON u.Id = ug.UserId
JOIN 
Games AS g
ON ug.GameId = g.Id
JOIN 
UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN 
Items AS i
ON i.Id = ugi.ItemId
GROUP BY u.Username,g.[Name]
HAVING COUNT(i.Id) >= 10
ORDER BY
COUNT(i.Id) DESC,
SUM(i.Price) DESC,
Username;

/* --04. */
SELECT u.Username,
       g.[Name],
	   MAX(c.[Name]) AS 'Character',
	   MAX(s1.Strength) + MAX(s2.Strength) + SUM(s3.Strength) AS Strength,
	   MAX(s1.Defence) + MAX(s2.Defence) + SUM(s3.Defence)    AS Defence,
	   MAX(s1.Speed) + MAX(s2.Speed) + SUM(s3.Speed)          AS Speed,
	   MAX(s1.Mind) + MAX(s2.Mind) + SUM(s3.Mind)             AS Mind,
	   MAX(s1.Luck) + MAX(s2.Luck) + SUM(s3.Luck)             AS Luck
FROM UsersGames ug
JOIN Users u
ON u.Id=ug.UserId
JOIN Games g
ON g.Id=ug.GameId
JOIN Characters c
ON c.Id=ug.CharacterId
JOIN [Statistics] s1
ON s1.Id=c.StatisticId
JOIN GameTypes gt
ON gt.Id=g.GameTypeId
JOIN [Statistics] s2
ON s2.Id=gt.BonusStatsId
JOIN UserGameItems ugi
ON ugi.UserGameId=ug.Id
JOIN Items i
ON i.Id=ugi.ItemId
JOIN [Statistics] s3
ON s3.Id=i.StatisticId
GROUP BY u.Username, g.[Name]
ORDER BY Strength DESC, Defence DESC, Speed DESC, Mind DESC, Luck DESC

/* --05. */
SELECT
	i.[Name],
	i.Price,
	i.MinLevel,
	s.Strength,
	s.Defence,
	s.Speed,
	s.Luck,
	s.Mind
FROM
Items AS i
JOIN 
[Statistics] AS s
ON i.StatisticId = s.Id
WHERE
s.Mind > 
(
	SELECT
	AVG(Mind)
	FROM
	Items AS i
	JOIN 
	[Statistics] AS s
	ON i.StatisticId = s.Id
)
AND
s.Luck > 
(
	SELECT
	AVG(Luck)
	FROM
	Items AS i
	JOIN 
	[Statistics] AS s
	ON i.StatisticId = s.Id
)
AND
s.Speed > 
(
	SELECT
	AVG(Speed)
	FROM
	Items AS i
	JOIN 
	[Statistics] AS s
	ON i.StatisticId = s.Id
)
ORDER BY i.[Name];

/* --06. */
SELECT
i.[Name] AS 'Item',
i.Price,
i.MinLevel,
gt.[Name] AS 'Forbidden Game Type'
FROM
Items AS i
LEFT JOIN
GameTypeForbiddenItems AS fi
ON i.Id = fi.ItemId
LEFT JOIN 
GameTypes AS gt
ON fi.GameTypeId = gt.Id
ORDER BY 
gt.[Name] DESC,
i.[Name];

/* --07. */
DECLARE @username NVARCHAR(100) = 'Alex';
DECLARE @game NVARCHAR(100) = 'Edinburgh'

DECLARE @item1 NVARCHAR(100) = 'Blackguard';
DECLARE @item2 NVARCHAR(100) = 'Bottomless Potion of Amplification';
DECLARE @item3 NVARCHAR(100) = 'Eye of Etlich (Diablo III)';
DECLARE @item4 NVARCHAR(100) = 'Gem of Efficacious Toxin';
DECLARE @item5 NVARCHAR(100) = 'Golden Gorget of Leoric';
DECLARE @item6 NVARCHAR(100) = 'Hellfire Amulet';

UPDATE UsersGames
SET Cash = 
Cash - 
(
	SELECT
	SUM(Price)
	FROM
	Items AS i
	WHERE 
	i.[Name] = @item1
	OR
	i.[Name] = @item2
	OR
	i.[Name] = @item3
	OR
	i.[Name] = @item4
	OR
	i.[Name] = @item5
	OR
	i.[Name] = @item6
)
WHERE
UserId IN (SELECT Id FROM Users WHERE Username = @username)
AND
GameId IN (SELECT Id FROM Games WHERE [Name] = @game)


INSERT INTO UserGameItems 
(ItemId,UserGameId)
SELECT Id,(SELECT Id FROM UsersGames 
WHERE 
GameId IN 
(SELECT Id FROM Games WHERE [Name] = @game)
AND
UserId IN
(SELECT Id FROM Users WHERE Username = @username))
FROM Items WHERE
  [Name] = @item1 OR 
  [Name] = @item2 OR 
  [Name] = @item3 OR 
  [Name] = @item4 OR
  [Name] = @item5 OR 
  [Name] = @item6 

  
  
SELECT
u.Username,
g.[Name],
ug.Cash,
i.[Name]
FROM Users AS u
JOIN 
UsersGames AS ug
ON ug.UserId = u.Id
JOIN
Games AS g
ON ug.GameId = g.Id
JOIN
UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN
Items AS i
ON i.Id = ugi.ItemId
WHERE
g.[Name] = @game
ORDER BY i.[Name]