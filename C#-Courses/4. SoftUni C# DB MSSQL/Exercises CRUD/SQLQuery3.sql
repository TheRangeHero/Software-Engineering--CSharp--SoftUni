USE SoftUni

-- Problem 2

SELECT *
  FROM Departments

-- Problem 3

SELECT [Name]
  FROM Departments

-- Problem 4

SELECT FirstName
      ,LastName
	  ,Salary
  FROM Employees

-- Problem 5

SELECT [FirstName]
      ,[MiddleName]
	  ,[LastName]
  FROM [Employees]

-- Problem 6

SELECT CONCAT([FirstName] + '.', [LastName] ,'@', 'softuni.bg')
    AS [Full Name Address]
  FROM Employees

-- Problem 7

SELECT DISTINCT [Salary]
           FROM [Employees]

-- Problem 8

SELECT *
  FROM [Employees]
 WHERE JobTitle = 'Sales Representative'

-- Problem 9

SELECT [FirstName]
      ,[LastName]
	  ,[JobTitle]
  FROM [Employees]
 WHERE [Salary] BETWEEN 20000 AND 30000

-- Problem 10

SELECT CONCAT ([FirstName], ' ', [MiddleName], ' ', [LastName])
	AS [Full Name]
  FROM [Employees]
 WHERE [Salary] IN (25000,14000,12500,23600)

-- Problem 11

SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [ManagerID] IS NULL

-- Problem 12

SELECT [FirstName]
      ,[LastName]
	  ,[Salary]
  FROM [Employees]
 WHERE [Salary] > 50000
 Order by [Salary] DESC

-- Problem 13

SELECT TOP 5 [FirstName]
            ,[LastName]
      FROM   [Employees]
  Order by   [Salary] DESC

-- Problem 14

SELECT [FirstName]
      ,[LastName]
  FROM [Employees]
 WHERE [DepartmentID] !=4

-- Problem 15

SELECT * 
  FROM [Employees]
 ORDER BY [Salary] DESC
         ,[FirstName] ASC
		 ,[LastName] DESC
		 ,[MiddleName] ASC

-- Problem 16
GO
CREATE VIEW [V_EmployeesSalaries] 
         AS
		 (
            SELECT [FirstName]
                  ,[LastName]
	              ,[Salary]
              FROM [Employees]
		 )
GO

SELECT * FROM [V_EmployeesSalaries]
-- Problem 17

GO
CREATE VIEW [V_EmployeeNameJobTitle]
         AS
		    (
				SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])  AS [Full Name]
					  ,[JobTitle]
				  FROM [Employees]
			)
GO

SELECT*FROM [V_EmployeeNameJobTitle]

-- Problem 18

SELECT DISTINCT [JOBTITLE]
           FROM [Employees]

-- Problem 19

SELECT TOP 10 *
  FROM [Projects]
ORDER BY [StartDate]
		,[Name]

-- Problem 20

SELECT TOP 7 [FirstName]		
			,[LastName]
			,[HireDate]
	    FROM [Employees]
	ORDER BY [HireDate] DESC

-- Problem 21

 UPDATE [Employees]
    SET [Salary] +=0.12*[Salary]
  WHERE [DepartmentID] IN   
						 (
							 SELECT [DepartmentID]
							   FROM [Departments]
							  WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
						 )

SELECT [SALARY]
  FROM [Employees]

-- Problem 22

USE [Geography]

SELECT [PeakName]
  FROM [Peaks]
 ORDER BY [PeakName]

-- Problem 23

SELECT *
FROM [Countries]

SELECT TOP 30 [COUNTRYNAME]
             ,[POPULATION]
       FROM   [Countries]
       WHERE  [ContinentCode] IN (
									  SELECT [ContinentCode] FROM Continents
									  WHERE ContinentName = 'Europe'
						         )
    ORDER BY [Population] DESC
		    ,[CountryName]

-- Problem 24


SELECT [CountryName]
	  ,[CountryCode]
		,CASE [CurrencyCode]
		   WHEN 'EUR' THEN 'Euro'
		   ELSE 'Not Euro'
		 END
	AS [Currency]
  FROM [Countries]
 ORDER BY [CountryName]


 -- Problem 25

 USE [Diablo]

   SELECT [NAME]
     FROM [Characters]
 ORDER BY [Name]

