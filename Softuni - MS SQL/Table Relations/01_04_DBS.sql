--01.
CREATE DATABASE One_To_One_Relationship;
CREATE TABLE Persons(
    PersonID INT IDENTITY(1,1) NOT NULL,
    FirstName NVARCHAR(100) NOT NULL,
    Salary FLOAT(2) NOT NULL,
    PassportID INT NOT NULL
);
CREATE TABLE Passports(
    PassportID INT NOT NULL,
    PassportNumber NVARCHAR(100) NOT NULL
);
INSERT INTO Persons
(FirstName,Salary,PassportID)
VALUES
('Roberto',43300.00,102),
('Tom',56100.00,103),
('Yana',60200.00,101);
INSERT INTO Passports
(PassportID,PassportNumber)
VALUES
(101,'N34FG21B'),
(102,'K65LO4R7'),
(103,'ZE657QP2');
ALTER TABLE Persons ADD CONSTRAINT PKID PRIMARY KEY(PersonID);
ALTER TABLE Passports ADD CONSTRAINT PASSID PRIMARY KEY(PassportID);
ALTER TABLE Persons ADD CONSTRAINT FKID FOREIGN KEY(PassportID)
REFERENCES Passports(PassportID);
--02.
CREATE DATABASE One_To_Many_Relationship;
CREATE TABLE Models(
    ModelID INT IDENTITY(101,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    ManufacturerID INT NOT NULL
);
CREATE TABLE Manufacturers(
    ManufacturerID INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    EstablishedOn DATE NOT NULL
);
INSERT INTO Models
([Name],ManufacturerID)
VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3);
INSERT INTO Manufacturers
([Name],EstablishedOn)
VALUES
('BMW','07/03/1916'),
('Tesla','01/01/2003'),
('Lada','01/05/1966');
ALTER TABLE Models
ADD CONSTRAINT PK_ModelID PRIMARY KEY (ModelID);
ALTER TABLE Manufacturers
ADD CONSTRAINT PK_ManID PRIMARY KEY (ManufacturerID);
ALTER TABLE Models
ADD CONSTRAINT FK_IDS FOREIGN KEY (ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID);
--03.
CREATE DATABASE Many_To_Many_Relationship;
CREATE TABLE Students(
    StudentID INT IDENTITY(1,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL
);
CREATE TABLE Exams(
    ExamID INT IDENTITY(101,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL
);
CREATE TABLE StudentsExams(
    StudentID INT NOT NULL,
    ExamID  INT NOT NULL
);
ALTER TABLE Students 
ADD CONSTRAINT PK_Stud 
PRIMARY KEY(StudentID);
ALTER TABLE Exams
ADD CONSTRAINT PK_Exam
PRIMARY KEY(ExamID);
ALTER TABLE StudentsExams
ADD CONSTRAINT PK_ExamStud
PRIMARY KEY(StudentID,ExamID);
ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Stud
FOREIGN KEY (StudentID) 
REFERENCES Students(StudentID);
ALTER TABLE StudentsExams
ADD CONSTRAINT FK_Exam
FOREIGN KEY (ExamID)
REFERENCES Exams(ExamID);
INSERT INTO Students
([Name]) 
VALUES
('Mila'),
('Toni'),
('Ron');
INSERT INTO Exams
([Name])
VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g');
INSERT INTO StudentsExams
(StudentID,ExamID)
VALUES
(1,101),
(1,102),
(2,101),
(3,103),
(2,102),
(2,103);
--04.
CREATE DATABASE Self_Referencing;
CREATE TABLE Teachers(
    TeacherID INT IDENTITY(101,1) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    ManagerID INT NULL
);
ALTER TABLE Teachers
ADD CONSTRAINT PK_TeachersID 
PRIMARY KEY(TeacherID);
ALTER TABLE Teachers
ADD CONSTRAINT FK_ID
FOREIGN KEY(ManagerID)
REFERENCES Teachers(TeacherID);
INSERT INTO Teachers
([Name],ManagerID)
VALUES
('John',NULL),
('Maya',106),
('Silvia',106),
('Ted',105),
('Mark',101),
('Greata',101);