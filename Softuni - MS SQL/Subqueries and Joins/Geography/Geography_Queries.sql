USE Geography;

/* --12. */
SELECT
c.CountryCode,
m.MountainRange,
p.PeakName,
p.Elevation
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON p.MountainId = m.Id
WHERE p.Elevation > 2835 AND c.CountryCode = 'BG'
ORDER BY p.Elevation DESC;

/* --13. */
SELECT 
c.CountryCode,
COUNT(m.MountainRange) AS MountainRanges
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE
c.CountryCode = 'US' OR
c.CountryCode = 'BG' OR
c.CountryCode = 'RU'
GROUP BY c.CountryCode;

/* --14. */
SELECT TOP 5
c2.CountryName,
r.RiverName
FROM Continents AS c1
JOIN Countries AS c2
ON c1.ContinentCode = c2.ContinentCode
LEFT JOIN CountriesRivers AS cr
ON c2.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
WHERE c2.ContinentCode = 'AF'
ORDER BY c2.CountryName;

/* --15. */
SELECT 
[ContinentCode],[CurrencyCode],[CurrencyUsage]
FROM 
   (
   SELECT *,
   DENSE_RANK() 
   OVER 
   (
   PARTITION BY [ContinentCode] 
   ORDER BY [CurrencyUsage] DESC
   )
   AS [CurrencyRank]
   FROM 
      (
      SELECT 
      ContinentCode,CurrencyCode,COUNT(*) AS CurrencyUsage
      FROM Countries
      GROUP BY ContinentCode,CurrencyCode
      HAVING COUNT(*) > 1
      )
        AS subquery
    )   AS secondSubquery
WHERE CurrencyRank = 1;

/* --16. */
SELECT
COUNT(CountryName) AS 'Count'
FROM Countries AS c
FULL JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE MountainId IS NULL;

/* --17. */
SELECT TOP 5
c.CountryName,
MAX(p.Elevation) AS HighestPeakElevation,
MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON p.MountainId = m.Id
JOIN CountriesRivers AS rc
ON c.CountryCode = rc.CountryCode
JOIN Rivers AS r
ON rc.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC,LongestRiverLength DESC,c.CountryName;

/* --18. */
    SELECT TOP 5
	c.CountryName,
	ISNULL((
	SELECT PeakName 
	FROM Peaks AS pe 
	WHERE 
	pe.Elevation = MAX(p.Elevation)),
	'(no highest peak)') AS 'Highest Peak Name',
	ISNULL(MAX(p.Elevation),'0') AS 'Highest Peak Elevation',
	ISNULL((
	SELECT MountainRange 
	FROM Mountains AS mo 
	JOIN Peaks AS pe2
	ON pe2.MountainId = mo.Id
	WHERE
	MAX(p.Elevation) = pe2.Elevation),
	'(no mountain)') AS 'Mountain' 
    FROM Countries AS c
    LEFT JOIN MountainsCountries AS mc
    ON c.CountryCode = mc.CountryCode
    LEFT JOIN Mountains AS m
    ON mc.MountainId = m.Id
    LEFT JOIN Peaks AS p
    ON m.Id = p.MountainId
    GROUP BY c.CountryName
    ORDER BY c.CountryName,MAX(p.PeakName);