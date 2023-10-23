USE Diablo;

/* --14. */
SELECT TOP 50 [Name],FORMAT([Start],'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATEPART(year,[Start]) BETWEEN 2011 AND 2012
ORDER BY [Start],[Name];

/* --15. */
SELECT [Username],
SUBSTRING(
[Email],
CHARINDEX('@',[Email],1)+1,
LEN(Email)-CHARINDEX('@',[Email],1))
AS [Email Provider]
FROM Users
ORDER BY [Email Provider],[Username];

/* --16. */
SELECT [Username],
[IpAddress] AS
[IP Adress]
FROM Users
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username];

/* --17. */
SELECT
[Name] AS [Game],
CASE 
WHEN 
DATEPART(HOUR,[Start]) >= 0 AND
DATEPART(HOUR,[Start]) < 12
THEN 'Morning'
WHEN 
DATEPART(HOUR,[Start]) >= 12 AND
DATEPART(HOUR,[Start]) < 18
THEN 'Afternoon'
WHEN 
DATEPART(HOUR,[Start]) >= 18 AND
DATEPART(HOUR,[Start]) < 24
THEN 'Evening'
END AS [Part of the Day],

CASE 
WHEN 
[Duration] <= 3
THEN 'Extra Short'
WHEN 
[Duration] BETWEEN 4 AND 6
THEN 'Short'
WHEN 
[Duration] > 6
THEN 'Long'
ELSE 'Extra Long'
END AS [Duration]
FROM Games
ORDER BY [Name],[Duration],[Part of the Day];