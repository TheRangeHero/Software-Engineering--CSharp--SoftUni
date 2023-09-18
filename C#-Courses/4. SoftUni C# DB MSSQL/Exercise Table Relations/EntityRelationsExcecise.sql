CREATE DATABASE [EntityRelationsExcercise]
GO

USE[EntityRelationsExcercise]
GO

-- Problem 1


CREATE TABLE [Passports]
(
[PassportID] INT PRIMARY KEY IDENTITY(101,1),
[PassportNumber] VARCHAR(8) NOT NULL
)

CREATE TABLE [Persons]
(
[PersonID] INT PRIMARY KEY IDENTITY(1,1),
[FirstName] VARCHAR(50) NOT NULL,
[Salary] DECIMAL(8,2) NOT NULL,
[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
)

INSERT INTO [Passports]([PassportNumber])
		VALUES
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

INSERT INTO [Persons]([FirstName],[Salary],[PassportID])
		VALUES
		('Roberto',43300.00,102),
		('Tom',56100.00,103),
		('Yana',60200.00,101)

ALTER TABLE [Passports]
ADD UNIQUE ([PassportNumber])

ALTER TABLE [Passports]
ADD CHECK (LEN([PassportNumber])=8)

-- Problem 2

CREATE TABLE [Manufacturers]
(
[ManufacturerID] INT PRIMARY KEY IDENTITY (1,1),
[Name] VARCHAR(50) NOT NULL,
[EstablishedOn] DATETIME2 NOT NULL
)

CREATE TABLE [Models]
(
[ModelID] INT PRIMARY KEY IDENTITY (101,1),
[Name] VARCHAR(50) NOT NULL,
[ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)

INSERT INTO [Manufacturers]([Name],[EstablishedOn])
	 VALUES
			('BMW','07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')

SELECT*FROM [Manufacturers]

INSERT INTO [Models]([Name],[ManufacturerID])
	 VALUES
			('X1', 1),
			('i6', 1),
			('Model S', 2),
			('Model X', 2),
			('Model 3', 2),
			('Nova', 3)

SELECT*FROM [Models]

-- Problem 3 

CREATE TABLE [Students]
(
[StudentID] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
[ExamID] INT PRIMARY KEY IDENTITY(101,1),
[ExamName] NVARCHAR(100) NOT NULL
)

CREATE TABLE [StudentsExams]
(
[StudentID] INT FOREIGN KEY REFERENCES [Students] ([StudentID]),
[ExamID] INT FOREIGN KEY REFERENCES [Exams] ([ExamID]),
PRIMARY KEY ([StudentID],[ExamID])
)

INSERT INTO [Students] ([Name])
	 VALUES
	 ('Mila'),
	 ('Toni'),
	 ('Ron')

SELECT*FROM [Students]

INSERT INTO [Exams] ([ExamName])
	 VALUES
	 ('SpringMVC'),
	 ('Neo4j'),
	 ('Oracle 11g')

SELECT*FROM [Exams]

INSERT INTO [StudentsExams] ([StudentID],[ExamID])
	 VALUES
	 (1,101),
	 (1,102),
	 (2,101)

-- Problem 4

CREATE TABLE [Teachers]
(
[TeacherID] INT PRIMARY KEY IDENTITY(101,1),
[Name] NVARCHAR(50) NOT NULL,
[ManagerID] INT FOREIGN KEY REFERENCES [Teachers] ([TeacherID])
)

INSERT INTO [Teachers] ([Name],[ManagerID])
	 VALUES
	 ('John',NULL),
	 ('Maya',106),
	 ('Silvia',106),
	 ('Ted',105),
	 ('Mark',101),
	 ('Desa',101)

SELECT*FROM [Teachers]


-- Problem 5

CREATE TABLE [Cities]
(
[CityID] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Customers]
(
[CustomerID] INT PRIMARY KEY IDENTITY(1,1),
[Name] NVARCHAR(50) NOT NULL,
[Birthday] DATETIME2 NOT NULL,
[CityID] INT FOREIGN KEY REFERENCES [Cities]([CityID]) NOT NULL,
)

CREATE TABLE [Orders]
(
[OrderID] INT PRIMARY KEY IDENTITY(1,1),
[CustomerID] INT FOREIGN KEY REFERENCES[Customers]([CustomerID]) NOT NULL
)

CREATE TABLE [ItemTypes]
(
[ItemTypeID] INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Items]
(
[ItemID] INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,
[ItemTypeID] INT FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID]) NOT NULL
)

CREATE TABLE [OrderItems]
(
[OrderID] INT FOREIGN KEY REFERENCES [Orders]([OrderID]) NOT NULL,
[ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID]) NOT NULL,
PRIMARY KEY ([OrderID],[ItemID])
)


-- Problem 6
CREATE DATABASE [UniversityDataBase]
GO

USE [UniversityDataBase]
GO

CREATE TABLE [Majors]
(
[MajorID] INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
)

CREATE TABLE [Subjects]
(
[SubjectID] INT PRIMARY KEY IDENTITY,
[SubjectName] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Students]
(
[StudentID] INT PRIMARY KEY IDENTITY,
[StudentNumber] VARCHAR(20) NOT NULL,
[StudentName] NVARCHAR(50) NOT NULL,
[MajorID] INT FOREIGN KEY REFERENCES[Majors]([MajorID]) NOT NULL,
)

CREATE TABLE [Agenda]
(
[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID])
PRIMARY KEY([StudentID],[SubjectID])
)

CREATE TABLE [Payments]
(
[PaymentID] INT PRIMARY KEY IDENTITY,
[PaymentDate] DATETIME2 NOT NULL,
[PaymentAmount] DECIMAL(8,2) NOT NULL,
[StudentID] INT FOREIGN KEY REFERENCES[Students]([StudentID]) NOT NULL
)

ALTER TABLE [Students]
ADD UNIQUE ([StudentNumber])

-- Problem 7
USE [SoftUni]
GO

ALTER TABLE [Employees]
ADD CONSTRAINT FK_ManagerIDEmployees FOREIGN KEY([ManagerID])
REFERENCES [Employees]([EmployeeID])

-- Problem 9

USE [Geography]
GO

      SELECT [m].[MountainRange]
            ,[p].[PeakName]
	        ,[p].[Elevation]
        FROM [Peaks]
		  AS [p]
   LEFT JOIN [Mountains]
		  AS [m]
		  ON [p].MountainId = [m].Id
	   WHERE [m].MountainRange = 'Rila'
    ORDER BY [P].Elevation DESC