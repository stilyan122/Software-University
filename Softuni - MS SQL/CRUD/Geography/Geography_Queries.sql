--22.
SELECT [PeakName]
FROM dbo.Peaks
ORDER BY [PeakName];
--23.
SELECT TOP(30) [CountryName],[Population]
FROM dbo.Countries
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC,[CountryName];
--24.
SELECT [CountryName],[CountryCode],
CASE 
WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
ELSE 'Not Euro'
END AS [Currency]
FROM dbo.Countries
ORDER BY [CountryName];