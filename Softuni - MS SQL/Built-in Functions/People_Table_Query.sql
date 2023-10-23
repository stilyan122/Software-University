/* --19. */
CREATE TABLE People
(
 [Id] INT PRIMARY KEY IDENTITY(1,1),
 [Name] NVARCHAR(100),
 [Birthdate] DATE
);

INSERT INTO People ([Name],[Birthdate])
VALUES
('Victor','2000-12-07 00:00:00.000'),
('Steven','1992-09-10 00:00:00.000'),
('Stephen','1910-09-19 00:00:00.000'),
('John','2010-01-06 00:00:00.000');

SELECT 
[Name],
DATEDIFF(year,[Birthdate],GETDATE()) AS [Age in Years],
DATEDIFF(month,[Birthdate],GETDATE()) AS [Age in Months],
DATEDIFF(day,[Birthdate],GETDATE()) AS [Age in Days],
DATEDIFF(minute,[Birthdate],GETDATE()) AS [Age in Minutes]
FROM People;