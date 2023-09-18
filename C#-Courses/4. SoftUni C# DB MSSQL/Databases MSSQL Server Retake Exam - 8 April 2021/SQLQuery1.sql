GO
CREATE DATABASE [Service]

GO

USE [Service]

GO

-- PROBLEM 1

CREATE TABLE Users 
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 Username VARCHAR(30) UNIQUE NOT NULL,
			 [Password] VARCHAR(50) NOT NULL,
			 [Name] VARCHAR(50),
			 Birthdate DATETIME,
			 Age INT CHECK(Age BETWEEN 14 AND 110),
			 Email VARCHAR(50) NOT NULL
			 )

CREATE TABLE Departments
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL
			 )

CREATE TABLE Employees
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 FirstName VARCHAR(25),
			 LastName VARCHAR(25),
			 Birthdate DATETIME,
			 Age INT CHECK(Age BETWEEN 18 AND 110),
			 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
			 )

CREATE TABLE Categories
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
			 )

CREATE TABLE [Status]
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 [Label] VARCHAR(20) NOT NULL
			 )

CREATE TABLE Reports
			 (
			 Id INT PRIMARY KEY IDENTITY,
			 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
			 StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
			 OpenDate DATETIME NOT NULL,
			 CloseDate DATETIME,
			 [Description] VARCHAR(200) NOT NULL,
			 UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
			 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
			 )

-- PROBLEM 2

INSERT INTO Employees(FirstName,LastName,Birthdate,DepartmentId)
	 VALUES ('Marlo','O''Malley','1958-9-21',1),
			('Niki','Stanaghan','1969-11-26',4),
			('Ayrton','Senna','1960-03-21',9),
			('Ronnie','Peterson','1944-02-14',9),
		    ('Giovanna','Amati','1959-07-20',5)

INSERT INTO Reports(CategoryId,StatusId,OpenDate,CloseDate,[Description],UserId,EmployeeId)
     VALUES (1,1,'2017-04-13',NULL,'Stuck Road on Str.133',6,2),
			(6,3,'2015-09-05','2015-12-06','Charity trail running',3,5),
			(14,2,'2015-09-07',NULL,'Falling bricks on Str.58',5,2),
			(4,3,'2017-07-03','2017-07-06','Cut off streetlight on Str.11',1,1)

-- PROBLEM 3

		UPDATE Reports
		   SET CloseDate = CURRENT_TIMESTAMP
		 WHERE CloseDate IS NULL

		  SELECT * FROM Reports

-- PROBLEM 4

		 DELETE
		   FROM Reports
		  WHERE StatusId = 4

		  SELECT * FROM Reports

-- PROBLEM 5

		SELECT [Description]
			  ,FORMAT(OpenDate,'dd-MM-yyyy')
		  FROM Reports
		 WHERE EmployeeId IS NULL
	  ORDER BY OpenDate ASC
		      ,[Description] ASC

-- PROBLEM 6

		SELECT [Description]
			  ,[Name]
		  FROM Reports AS r
		  JOIN Categories AS c
		    ON r.CategoryId = c.Id
	  ORDER BY [Description]
			  ,[Name]

-- PROBLEM 7

		SELECT
		 TOP 5 [Name]
			  ,COUNT(CategoryId) AS ReportsNumber
		  FROM Reports AS r
		  JOIN Categories AS c
		    ON r.CategoryId = c.Id
	  GROUP BY CategoryId,[Name]
	  ORDER BY ReportsNumber DESC
		      ,[Name]

-- PROBLEM 8
  
		SELECT u.Username
			  ,c.[Name]
		  FROM Users AS u
		  JOIN Reports AS r
		    ON r.UserId = u.Id
		  JOIN Categories AS c
		    ON r.CategoryId = c.Id
		 WHERE DAY(r.OpenDate) = DAY(u.Birthdate) 
		   AND 
		       MONTH(r.OpenDate)=MONTH(u.Birthdate)
	  ORDER BY u.Username
		      ,c.[Name]

-- PROBLEM 9

		SELECT CONCAT(e.FirstName,' ',e.LastName) AS FullName
		      , COUNT( r.UserId) AS UserCount
		  FROM Employees AS e
		 LEFT JOIN Reports AS r
		    ON e.Id = r.EmployeeId
      GROUP BY e.FirstName,e.LastName
	  ORDER BY UserCount DESC	  
		      ,FullName

-- PROBLEM 10

		SELECT ISNULL(e.FirstName + ' ' + e.LastName,'None') AS Employee
		      ,ISNULL(d.[Name], 'None') AS Department
		      ,ISNULL(c.[Name], 'None') AS Category
		      ,ISNULL(r.[Description],'None') AS [Description]
		      ,FORMAT(OpenDate,'dd.MM.yyyy') AS OpenDate
		      ,ISNULL(s.[Label],'None') AS [Status]
		      ,ISNULL(u.[Name],'None') AS [User]
		  FROM Reports AS r
	 LEFT JOIN Employees AS e
		    ON r.EmployeeId = e.Id
	 LEFT JOIN Departments AS d
		    ON d.Id = e.DepartmentId
	 LEFT JOIN Categories AS c
		    ON r.CategoryId = c.Id
	 LEFT JOIN [Status] AS s
		    ON s.Id = r.StatusId
	 LEFT JOIN Users AS u
		    ON u.Id = r.UserId
	  ORDER BY e.FirstName DESC
		      ,e.LastName DESC
			  ,d.[Name]
			  ,c.[Name]
			  ,r.[Description]
			  ,r.OpenDate
			  ,s.[Label]
			  ,u.[Name]
