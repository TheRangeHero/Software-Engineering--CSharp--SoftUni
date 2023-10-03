
--Create database //1
CREATE DATABASE Minions
--Use the database
USE Minions
--Create Minions table //2
CREATE TABLE Minions
(
ID int PRIMARY KEY,
[Name] varchar(65),
Age int
)
--Create Towns table
CREATE TABLE Towns
(
Id int PRIMARY KEY,
[Name] varchar (100)
)
--alter table
ALTER TABLE Minions
ALTER COLUMN Id INT NOT NULL;
ALTER TABLE Minions
ADD CONSTRAINT PK_Id PRIMARY KEY(Id);
-- Alter table //3
ALTER TABLE Minions 
ADD [TownId] int FOREIGN KEY REFERENCES Towns(Id)
--ADD Information //4
INSERT INTO Towns
VALUES
(1,'Sofia'),
(2,'Plovdiv'),
(3,'Varna')
INSERT INTO Minions
VALUES
(1,'Kevin',22,1),
(2,'Bob',15,3),
(3,'Steward',NULL,2)
TRUNCATE TABLE Minions -- delete data inside table
DROP TABLE Minions
DROP TABLE Towns
--use master
--DROP DATABASE Minions
--//8
Use  Minions
CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(max), --Limit to 900000
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL
)
INSERT INTO Users
values
('Petar', '1234561',null,'10-20-2022',0),
('Petar2', '1234566',null,'12-20-2022',1),
('Petar3', '1234566',null,'5-20-2022',0),
('Petar4', '1234565',null,'7-20-2022',1),
('Petar5', '123456',null,'1-20-2022',0)
SELECT*FROM Users

--//9
ALTER TABLE [Users] DROP CONSTRAINT PK__Users__3214EC07B20BE8B8;
ALTER TABLE [Users] ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id,Username);

--//10
ALTER TABLE [Users] ADD CONSTRAINT CHK_PasswordMinLen CHECK(LEN([Password])>=5);

--//11
ALTER TABLE [Users]  ADD CONSTRAINT DF_LastLogingTime  DEFAULT GETDATE() FOR [LastLoginTime]
INSERT INTO Users ([Username],[Password],IsDeleted)
values
('IVAn', '1234561',0)
SELECT*FROM Users

--//12
ALTER TABLE [Users] DROP CONSTRAINT PK_IdUsername
ALTER TABLE [Users] ADD CONSTRAINT PK_Id PRIMARY KEY (Id)
ALTER TABLE [Users] ADD CONSTRAINT UC_Username UNIQUE (Username)
ALTER TABLE [Users] ADD CONSTRAINT CHK_UsernameLen CHECK (LEN(Username)>=3)


--//15
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Title NVARCHAR(50),
Notes NVARCHAR(MAX))

CREATE TABLE Customers(
AccountNumber INT PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
PhoneNumber CHAR(10) NOT NULL,
EmergencyName NVARCHAR(100) NOT NULL,
EmergencyNumber CHAR(10) NOT NULL,
Notes NVARCHAR(MAX))

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(10) NOT NULL,
Notes NVARCHAR(MAX))

CREATE TABLE RoomTypes(
RoomType NVARCHAR(10) NOT NULL,
Notes NVARCHAR(MAX))

CREATE TABLE BedTypes(
BedTyppe NVARCHAR(10) NOT NULL,
Notes NVARCHAR(MAX))

CREATE TABLE Rooms(
RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(10) NOT NULL,
BedType NVARCHAR(10) NOT NULL,
Rate TINYINT,
RoomStatus NVARCHAR(10),
Notes NVARCHAR(MAX))

CREATE TABLE Payments(
Id INT PRIMARY KEY,
EmployeeId INT NOT NULL,
PaymentDate DATETIME2,
AccountNumber INT,
FirstDateOccupied DATETIME2,
LastDateOccupied DATETIME2,
TotalDays TINYINT,
AmountCharged DECIMAL(15,2),
TaxRate INT,
TaxAmount DECIMAL(15,2),
PaymentTotal DECIMAL(15,2),
Notes NVARCHAR(MAX))

CREATE TABLE Occupancies(
Id INT PRIMARY KEY,
EmployeeId INT,
DateOccupied DATETIME2,
AccountNumber INT,
RoomNumber INT,
RateApplied INT,
PhoneCharge DECIMAL(15,2),
Notes NVARCHAR(MAX))

INSERT INTO Employees(Id,[FirstName],LastName)
VALUES
(1,'A','b'),
(2,'S','b'),
(3,'D','b')

INSERT INTO Customers(AccountNumber,[FirstName],LastName,PhoneNumber,EmergencyName,EmergencyNumber)
VALUES
(1,'A','b','12341234','a','1'),
(2,'S','b','12341234','a','2'),
(3,'D','b','12341234','a','3')

INSERT INTO RoomStatus(RoomStatus)
VALUES
('y'),
('n'),
('y')

INSERT INTO RoomTypes(RoomType)
VALUES
('double'),
('single'),
('double')

INSERT INTO BedTypes(BedTyppe)
VALUES
('single'),
('double'),
('double')

INSERT INTO Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus)
VALUES
(123,'single','single',5,'taken'),
(133,'single','double',5,'free'),
(423,'double','single',5,'taken')

INSERT INTO Payments(Id,EmployeeId)
VALUES
(32,111),
(22,113),
(44,231)

INSERT INTO Occupancies(Id,EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge)
VALUES
(1,111,'1-11-2022',2022,11,10,15.00),
(2,211,'2-11-2022',3022,21,20,14.00),
(3,311,'3-11-2022',3022,31,30,17.00)


--//7

USE Minions
CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture varbinary(max) Null,
Height DECIMAL(5,2) NULL,
[Weight] DECIMAL(4,2) NULL,
Gender CHAR(1) NOT NULL CHECK(Gender='m' OR Gender='f'),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX) NULL
)
INSERT INTO People([Name],Picture,Height,[Weight],Gender,Birthdate,Biography) 
Values
('Stela',Null,1.65,44.55,'f','2000-09-22',Null),
('Ivan',Null,2.15,95.55,'m','1989-11-02',Null),
('Qvor',Null,1.55,33.00,'m','2010-04-11',Null),
('Karolina',Null,2.15,55.55,'f','2001-11-11',Null),
('Pesho',Null,1.85,90.00,'m','1983-07-22',Null)

SELECT*FROM People


--//13
CREATE DATABASE Movies;
Go;
Use Movies;

CREATE TABLE Directors(
Id INT PRIMARY KEY  IDENTITY,
DirectorName VARCHAR(100) NOT NULL,
Notes VARCHAR(MAX) NULL
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY,
GenreName VARCHAR(100) NOT NULL,
Notes VARCHAR(MAX) NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(50) NOT NULL,
Notes VARCHAR(MAX) NULL
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(100) NOT NULL,
DirectorId INT,
CopyrightYear INT NOT NULL,
[Length] TIME NOT NULL,
GenreId INT,
CategoryId INT,
Rating DECIMAL(2,1) NOT NULL,
Notes VARCHAR(MAX)
)

INSERT INTO Directors(DirectorName)
VALUES
('Pesho'), 
('Ivan'), 
('Gosho'), 
('Tapata'), 
('Ali') 
--SELECT*FROM Directors

INSERT INTO Genres(GenreName)
VALUES
('Parody'),
('Comedy'),
('Drama'),
('Action'),
('Animation')
--SELECT*FROM Genres

INSERT INTO Categories(CategoryName)
VALUES
('+0'),
('+6'),
('+12'),
('+16'),
('+18')
--SELECT*FROM Categories

INSERT INTO Movies (Title, DirectorId, CopyrightYear,[Length], GenreId,CategoryId, Rating, Notes)
VALUES
('No commentt', '1', '1991', '00:05:00', '1','1', 1, NULL),
('No commentttt', '2', '1992', '00:04:00', '2','5', 2, NULL),
('No commenttttt', '3', '1993', '00:03:00', '5','4', 3.4, NULL),
('No commenttttttt', '4', '1994', '00:02:00', '4', '3', 4.5, NULL),
('No commentttttttt', '4', '1995', '00:01:00', '3','2', 6.6, NULL)
--SELECT*FROM Movies


--//14

CREATE DATABASE CarRental
GO
USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
CategoryName VARCHAR(50) NOT NULL,
DailyRate DECIMAL,
WeeklyRate DECIMAL,
MonthlyRate DECIMAL,
WeekendRate DECIMAL)

CREATE TABLE Cars (
Id INT PRIMARY KEY IDENTITY,
PlateNumber VARCHAR(50) NOT NULL,
Manufacturer VARCHAR(50),
Model VARCHAR(50),
CarYear INT,
CategoryId INT,
Doors TINYINT,
Picture varbinary(max),
Condition VARCHAR(50),
Available BIT)

CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(50) NOT NULL,
LastName VARCHAR(50) NOT NULL,
Title VARCHAR(50),
Notes VARCHAR(MAX))

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY,
DriverLicenceNumber INT NOT NULL,
FullName VARCHAR(100) NOT NULL,
[Address] VARCHAR(100),
City VARCHAR(100),
ZIPCode INT,
Notes VARCHAR(MAX))

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT,
CustomerId INT,
CarId INT,
TankLevel INT,
KilometrageStart INT,
KilometrageEnd INT,
TotalKilometrage INT,
StartDate DATETIME2,
EndDate DATETIME2,
TotalDays INT,
RateApplied DECIMAL(2,1),
TaxRate DECIMAL (2,1),
OrderStatus VARCHAR(50),
Notes VARCHAR(MAX))

INSERT INTO Categories (CategoryName)
VALUES
('Van'),
('Sedan'),
('4x4');
--SELECT*FROM Categories

INSERT INTO Cars(PlateNumber)
VALUES
('ch213123'),
('vd1235'),
('AS65455');
--SELECT*FROM Cars

INSERT INTO Employees(FirstName,LastName)
VALUES
('IVAN','RADEV'),
('TISLAA', 'ZHEKOVA'),
('GENADI','STAVREV')
--SELECT*FROM Employees

INSERT INTO Customers(DriverLicenceNumber,FullName)
VALUES
(12312,'DESKATA ZHEKOVA'),
(512321, 'DONKA BIDONKA'),
(1231245, 'CHOKO PARLQKA')
--SELECT*FROM Customers

INSERT INTO RentalOrders(EmployeeId,CustomerId,CarId)
VALUES
(1,1,1),
(2,2,2),
(3,3,3)
--SELECT*FROM RentalOrders

--//16

CREATE DATABASE SoftUni
GO
USE SoftUni

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(100) NOT NULL);

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY(1,1),
AddressText VARCHAR(100) NOT NULL,
TownId INT NOT NULL);

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(50) NOT NULL,);

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1,1),
FirstName VARCHAR(100) NOT NULL,
MiddleName VARCHAR(100) NOT NULL,
LastName VARCHAR(100) NOT NULL,
JobTitle VARCHAR(50),
DepartmentId INT NOT NULL,
HireDate DATETIME2,
Salary DECIMAL(10,2),
AddressId INT);

ALTER TABLE Employees ADD CONSTRAINT FK_ADDRESS_ID FOREIGN KEY(AddressId) REFERENCES Addresses(Id)
ALTER TABLE Employees ADD CONSTRAINT FK_DEPARTMENT_ID FOREIGN KEY(DepartmentId) REFERENCES Departments(Id)

--//18
INSERT INTO Towns
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')
--SELECT*FROM Towns

INSERT INTO Departments
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Developmen'),
('Quality Assurance')
--SELECT*FROM Departments

INSERT INTO Employees(FirstName,MiddleName,LastName,JobTitle,DepartmentId,HireDate,Salary)
VALUES
('Ivan','Ivanov','Ivanov','.NET Developer',4,'2013-02-01',3500.00),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00),
('Maria','Petrova','Ivanova','Intern',5,'2016-08-28',525.25),
('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09',3000),
('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88)

--//19
SELECT*FROM Towns
SELECT*FROM Departments
SELECT*FROM Employees

--//20
SELECT*FROM Towns
ORDER BY [Name] ASC

SELECT*FROM Departments
ORDER BY [Name] ASC

SELECT*FROM Employees
ORDER BY Salary DESC

--//21

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName,LastName,JobTitle,Salary FROM Employees
ORDER BY Salary DESC

--//22
UPDATE Employees
SET Salary *=1.10;
SELECT SALARY FROM Employees

--//23
USE Hotel
GO
UPDATE Payments
SET TaxRate *=0.97
SELECT TAXRATE FROM Payments

--//24
TRUNCATE TABLE OCCUPANCIES

--//17
USE SoftUni
GO
BACKUP DATABASE SOFTUNI
TO DISK = 'E:\Softuni All\Softuni C# DB\Exercise Databases Introduction\BACKUP\testDB.bak'