--06.
CREATE DATABASE University;
CREATE TABLE Students(
   StudentID INT PRIMARY KEY NOT NULL,
   StudentNumber INT NOT NULL,
   StudentName NVARCHAR(100) NOT NULL,
   MajorID INT NOT NULL
);
CREATE TABLE Agenda(
   StudentID INT NOT NULL,
   SubjectID INT NOT NULL
);
CREATE TABLE Subjects(
   SubjectID INT PRIMARY KEY NOT NULL,
   SubjectName NVARCHAR(100) NOT NULL
);
CREATE TABLE Majors(
   MajorID INT PRIMARY KEY NOT NULL,
   [Name] NVARCHAR(100) NOT NULL
);
CREATE TABLE Payments(
   PaymentID INT PRIMARY KEY NOT NULL,
   PaymentDate DATE NOT NULL,
   PaymentAmount INT NOT NULL,
   StudentID INT NOT NULL
);

ALTER TABLE Agenda ADD CONSTRAINT PK_StudentSubjectID
PRIMARY KEY(StudentID,SubjectID);

ALTER TABLE Students
ADD CONSTRAINT FK_MajorID
FOREIGN KEY(MajorID)
REFERENCES Majors(MajorID);

ALTER TABLE Agenda
ADD CONSTRAINT FK_StudentID
FOREIGN KEY(StudentID)
REFERENCES Students(StudentID);

ALTER TABLE Agenda
ADD CONSTRAINT FK_SubjectID
FOREIGN KEY(SubjectID)
REFERENCES Subjects(SubjectID);

ALTER TABLE Payments
ADD CONSTRAINT FK_PaymentID
FOREIGN KEY(StudentID)
REFERENCES Students(StudentID);

--07. Checked
--08. Created
--09.
USE Geography;
SELECT [MountainRange],[PeakName],[Elevation]
FROM Mountains
JOIN Peaks
ON Peaks.MountainId 
= Mountains.Id
WHERE [MountainRange] = 'Rila'
ORDER BY [Elevation] DESC;
