USE Geography
/* --12. */
SELECT [CountryName] AS [Country Name],[IsoCode] AS [Iso Code]
FROM Countries
WHERE (LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')))/LEN('A') > 2
ORDER BY [IsoCode];

/* --13. */
SELECT [PeakName],[RiverName],
LOWER([PeakName])
+
SUBSTRING(LOWER([RiverName]),2,LEN([RiverName])-1)
AS [Mix]
FROM Peaks
JOIN Rivers ON RIGHT([PeakName],1)=LEFT([RiverName],1)
ORDER BY [Mix];
