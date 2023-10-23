USE Geography;

/* --08. */
SELECT
p.PeakName,
m.MountainRange AS 'Mountain',
p.Elevation
FROM
Peaks AS p
JOIN Mountains AS m
ON p.MountainId = m.Id
ORDER BY 
p.Elevation DESC,
p.PeakName;

/* --09. */
SELECT
p.PeakName,
m.MountainRange AS 'Mountain',
c.CountryName,
con.ContinentName
FROM 
Peaks AS p
JOIN
Mountains AS m
ON p.MountainId = m.Id
JOIN
MountainsCountries AS mc
ON m.Id = mc.MountainId
JOIN
Countries AS c
ON c.CountryCode = mc.CountryCode
JOIN
Continents AS con
ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName,c.CountryName;

/* --10. */
SELECT
c.CountryName,
con.ContinentName,
ISNULL(COUNT(r.Id),0) AS 'RiversCount',
ISNULL(SUM(r.[Length]),0) AS 'TotalLength'
FROM
Continents AS con
JOIN
Countries AS c
ON con.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName,con.ContinentName
ORDER BY 
COUNT(r.Id) DESC,
SUM(r.[Length]) DESC,
c.CountryName;

/* --11. */
SELECT
curr.CurrencyCode,
curr.[Description],
COUNT(coun.CurrencyCode) AS 'NumberOfCountries'
FROM 
Currencies AS curr
LEFT JOIN 
Countries AS coun
ON coun.CurrencyCode = curr.CurrencyCode
GROUP BY curr.CurrencyCode,curr.[Description]
ORDER BY 
COUNT(coun.CurrencyCode) DESC,
curr.[Description];

/* --12. */
SELECT
con.ContinentName,
SUM(CAST(cou.AreaInSqKm AS BIGINT)) AS 'CountriesArea',
SUM(CAST(cou.[Population] AS BIGINT)) AS 'CountriesPopulation'
FROM
Continents AS con
JOIN Countries AS cou
ON con.ContinentCode = cou.ContinentCode
GROUP BY con.ContinentName
ORDER BY SUM(CAST(cou.[Population] AS BIGINT)) DESC;

/* --13. */
CREATE TABLE Monasteries
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(300),
	CountryCode CHAR(2),
	FOREIGN KEY (CountryCode) REFERENCES Countries(CountryCode)
);

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery St. Ivan of Rila', 'BG'), 
('Bachkovo Monastery Virgin Mary', 'BG'),
('Troyan Monastery Holy Mother''s Assumption', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('S?mela Monastery', 'TR');

ALTER TABLE Monasteries 
ADD IsDeleted NVARCHAR(10);

UPDATE Monasteries
SET IsDeleted = 'false';

UPDATE Monasteries
SET IsDeleted = 'true'
WHERE Id IN
(
	SELECT
	m.Id,
	COUNT(r.Id)
	FROM
	Monasteries AS m
	JOIN Countries AS c
	ON m.CountryCode = c.CountryCode
	JOIN CountriesRivers AS rc
	ON c.CountryCode = rc.CountryCode
	JOIN Rivers AS r
	ON r.Id = rc.RiverId
	GROUP BY m.Id
	HAVING COUNT(r.Id) > 3
);

SELECT
	m.[Name] AS 'Monastery',
	c.CountryName AS 'Country'
FROM
Monasteries AS m
JOIN
Countries AS c
ON m.CountryCode = c.CountryCode
WHERE m.IsDeleted = 'false'
ORDER BY m.[Name];

/* --14. */
