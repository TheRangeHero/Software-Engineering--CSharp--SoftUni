
-- PROBLEM 1

SELECT [FIRSTNAME]
      ,[LastName]
  FROM [Employees]
  WHERE LEFT([FirstName],2) = 'SA'

SELECT [FIRSTNAME]
      ,[LastName]
  FROM [Employees]
 WHERE [FirstName] LIKE 'SA%'

 -- PROBLEM 2

 SELECT [FIRSTNAME]
       ,[LastName]
   FROM [Employees]
  WHERE [LastName] LIKE '%ei%'


 SELECT [FIRSTNAME]
       ,[LastName]
   FROM [Employees]
  WHERE CHARINDEX ('ei', [LastName])>0

-- PROBLEM 3

SELECT [FIRSTNAME]
  FROM [Employees]
 WHERE (DepartmentID) IN (3,10)
  AND  
 YEAR ([HireDate])  BETWEEN 1995 AND 2005

-- PROBLEM 4

SELECT [FIRSTNAME]
      ,[LastName]
  FROM [Employees]
 WHERE CHARINDEX('engineer',[JobTitle]) = 0


 SELECT [FIRSTNAME]
       ,[LastName]
   FROM [Employees]
  WHERE [JobTitle] NOT LIKE '%engineer%'

-- PROBLEM 5

SELECT [NAME]
  FROM [Towns]
 WHERE LEN([Name]) IN (5,6)
 ORDER BY [Name]

-- PROBLEM 6

SELECT *
  FROM [Towns]
 WHERE [NAME] LIKE '[MKBE]%'
 ORDER BY [Name]


 SELECT *
  FROM [Towns]
 WHERE LEFT([Name],1) IN ('M','K','B','E')
  ORDER BY [Name]

-- PROBLEM 7


SELECT *
  FROM [Towns]
 WHERE [NAME] NOT LIKE '[RBD]%'
 ORDER BY [Name]

 SELECT *
  FROM [Towns]
 WHERE LEFT([Name],1) NOT IN ('D','R','B')
 ORDER BY [Name]

-- PROBLEM 8

CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT [FIRSTNAME]
      ,[LASTNAME]
  FROM [Employees]
 WHERE YEAR([HireDate]) > 2000

-- PROBLEM 9 


 SELECT [FirstName]
       ,[LastName]
  FROM [Employees]
 WHERE LEN([LastName]) = 5

-- PROBLEM 10

SELECT [EmployeeID]
	  ,[FirstName]
      ,[LastName]
	  ,[Salary]
	  ,DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
  FROM [Employees]
 WHERE [Salary] BETWEEN 10000 AND 50000
 ORDER BY [Salary] DESC

-- PROBLEM 11
SELECT *
  FROM (  
		SELECT [EmployeeID]
			  ,[FirstName]
			  ,[LastName]
			  ,[Salary]
			  ,DENSE_RANK() OVER(PARTITION BY [Salary] ORDER BY [EmployeeID])
            AS [RANK]
		  FROM [Employees]
		 WHERE [Salary] BETWEEN 10000 AND 50000		 
       ) AS [RankingSubquery]
   WHERE [RANK] = 2
ORDER BY [Salary] DESC

-- PROBLEM 12

GO

USE [Geography]

GO

   SELECT [CountryName] AS [Country Name]
	     ,[ISOcode] AS [ISO Code]
     FROM [Countries]
    WHERE LOWER([CountryName]) LIKE '%a%a%a%'
 ORDER BY [ISO Code]



   SELECT [CountryName] AS [Country Name]
	     ,[ISOcode] AS [ISO Code]
     FROM [Countries]
    WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]),'a','')) >=3
 ORDER BY [ISO Code]

-- PROBLEM 13

SELECT [p].[PeakName]
	  ,[r].[RiverName]
	  ,LOWER(CONCAT(SUBSTRING([p].[PeakName],1,LEN([p].[PeakName])-1),[r].[RiverName])) AS [Mix]
  FROM [Peaks] AS [p]
      ,[Rivers] AS [r]
 WHERE RIGHT(LOWER([p].[PeakName]),1) = LEFT(LOWER([r].RiverName),1)
 ORDER BY [Mix]

-- PROBLEM 14
GO
USE Diablo
GO

SELECT TOP 50 [NAME] AS [Name]
			 ,FORMAT([Start],'yyyy-MM-dd') AS [Start]
      FROM [Games]
	 WHERE YEAR(CONVERT(date,[Start])) IN (2011,2012)
  ORDER BY [Start],[Name]

-- PROBLEM 15

SELECT [Username]
	  ,SUBSTRING([Email],CHARINDEX('@',[Email])+1,LEN([EMAIL])- CHARINDEX('@',[EMAIL]))
    AS [Email Provider]
  FROM [Users]
 ORDER BY [Email Provider], [Username]

-- PROBLEM 16

SELECT [Username]
	  ,[ipAddress] AS [IP Adress]
  FROM [Users]
 WHERE [IpAddress] LIKE '___.1%.%.___'
 ORDER BY [Username]

-- PROBLEM 17

SELECT [Name] AS [Game]
	  ,CASE
			WHEN DATEPART(HOUR,[START]) >= 0 AND DATEPART(HOUR,[Start]) < 12 THEN 'Morning'
			WHEN DATEPART(HOUR,[START]) >= 12 AND DATEPART(HOUR,[Start]) < 18 THEN 'Afternoon'
			ELSE 'Evening'
		END AS [Part of the Day]		  
		,CASE
			WHEN [Duration] <=3 THEN 'Extra Short'
			WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
			WHEN [Duration] > 6 THEN 'Long'
			ELSE 'Extra Long'
		END AS [Duration]
  FROM [Games] AS [g]
  ORDER BY [Game],[Duration], [Part of the Day]

-- PROBLEM 18

GO
USE [SoftUni]
GO

SELECT [FirstName]
      ,[HireDate]
	  ,DATEADD(DAY,3,[HireDate]) AS [Pay Due]
	  ,DATEADD(MONTH,1,[HireDate]) AS [Deliver Due]
  FROM [Employees]
