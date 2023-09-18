USE [SOFTUNI]
GO

-- PROBLEM 1

SELECT TOP(5) [EmployeeID]
			 ,[JobTitle]
			 ,[e].[AddressID]
			 ,[AddressText]	
		 FROM [Employees] AS [e]
	LEFT JOIN [Addresses] AS [a]
		   ON [e].AddressID = [a].AddressID
	 ORDER BY [e].[AddressID]

-- PROBLEM 2

	   SELECT 
	   TOP 50 [e].[FirstName]
			 ,[e].[LastName]
			 ,[t].[Name]
			 ,[a].[AddressText]
		 FROM [Employees] AS [e]
		 JOIN [Addresses] AS [a]
		   ON [e].AddressID = [a].[AddressID]
		 JOIN [Towns] AS [t]
		   ON [t].[TownID] = [a].TownID
	 ORDER BY [e].[FirstName]
		     ,[e].[LastName]

-- PROBLEM 3

		SELECT [e].[EmployeeID]
			  ,[e].[FirstName]
			  ,[e].[LastName]
			  ,[d].[Name] AS [DepartmentName]
		  FROM [Employees] AS [e]
		  JOIN [Departments] AS [d]
		    ON [e].DepartmentID = [d].DepartmentID
		 WHERE [d].[Name] = 'Sales'
      ORDER BY [e].[EmployeeID]

-- PROBLEM 4

		SELECT 
		 TOP 5 [e].[EmployeeID]
			  ,[e].[FirstName]
			  ,[e].[Salary]
			  ,[d].[Name] AS [DepartmentName]
		  FROM [Employees] AS [e]
		  JOIN [Departments] AS [d]
		    ON [e].DepartmentID = [d].DepartmentID
		 WHERE [e].[Salary] > 15000
	  ORDER BY [d].[DepartmentID]

-- PROBLEM 5

	SELECT TOP 3 [e].[EmployeeID]
				,[FirstName]
			FROM [Employees] AS [e]
	   LEFT JOIN [EmployeesProjects] AS [ep]
			  ON [e].[EmployeeID] = [ep].EmployeeID
		   WHERE [ep].[ProjectID] IS NULL
		ORDER BY [e].[EmployeeID]

-- PROBLEM 6


		SELECT [e].[FirstName]
			  ,[e].[LastName]
			  ,[e].[HireDate]
			  ,[d].[Name] AS [DeptName]
		  FROM [Employees] AS [e]
	INNER JOIN [Departments] AS [d]
		    ON [d].DepartmentID = [e].[DepartmentID]
		 WHERE [e].[HireDate] > '01-01-1999'
		   AND [d].[Name] IN ('Sales','Finance')
	  ORDER BY [e].[HireDate]


-- PROBLEM 7

	SELECT TOP 5 [e].[EmployeeID]
	            ,[FirstName]
	            ,[Name] AS [ProjectName]
            FROM [EmployeesProjects] AS [ep]
	  INNER JOIN [Employees] AS [e]
			  ON [ep].[EmployeeID] = [e].[EmployeeID]
	  INNER JOIN [Projects] AS [p]
		      ON [ep].[ProjectID] = [p].[ProjectID]
		   WHERE [p].[StartDate] > '08-13-2002' AND [p].[EndDate] IS NULL
		ORDER BY [ep].[EmployeeID]


-- PROBLEM 8


		SELECT [e].[EmployeeID]
			  ,[e].[FirstName]
		      ,CASE
					WHEN DATEPART(YEAR,[p].[StartDate]) = 2005 THEN NULL
					ELSE [p].[Name]
		      END
		 FROM [Employees] AS [e]
	LEFT JOIN [EmployeesProjects] AS [ep]
		   ON [ep].EmployeeID = [e].EmployeeID
	LEFT JOIN [Projects] AS [p]
		   ON [p].ProjectID = [ep].ProjectID
		WHERE [e].[EmployeeID] = 24


-- PROBLEM 9

	SELECT [e].[EmployeeID]
	      ,[e].[FirstName]
	      ,[m].[EmployeeID] AS [ManagerID]
	      ,[m].[FirstName] AS [ManagerName]
	  FROM [Employees] AS [e]
	  JOIN [Employees] AS [m]
	    ON [e].[ManagerID] = [m].[EmployeeID]
	 WHERE [m].[EmployeeID] IN (3,7)
  ORDER BY [e].[EmployeeID]


-- PROBLEM 10


		 SELECT 
		 TOP 50	[e].[EmployeeID]
			   ,CONCAT([e].[FirstName],' ',[e].[LastName]) AS [EmployeeName]
			   ,CONCAT([m].[FirstName],' ',[m].[LastName]) AS [ManagerName]
			   ,[d].[Name] AS [DepartmentName]
		   FROM [Employees] AS [e]
		   JOIN [Employees] AS [m]
			 ON [e].[ManagerID] = [m].[EmployeeID]
		   JOIN [Departments] AS [d]
		     ON [d].[DepartmentID] = [e].[DepartmentID]
	   ORDER BY [e].[EmployeeID]


-- PROBLEM 11


	SELECT 
	      MIN([AVG]) AS [MinAverageSalary]
	  FROM ( 
			 SELECT AVG(Salary) AS [AVG]
			   FROM [Employees]
			   GROUP BY [DepartmentID]
		   ) 
			AS [AverageSalary]


-- PROBLEM 12

USE [Geography]
GO

	SELECT [mc].[CountryCode]
	      ,[m].[MountainRange]
	      ,[p].[PeakName]
	      ,[p].[Elevation]
      FROM [MountainsCountries] AS [mc]
INNER JOIN [Countries] AS [c]
        ON [mc].CountryCode = [c].[CountryCode]
INNER JOIN [Mountains] AS [m]
	    ON [mc].MountainId = [m].Id
INNER JOIN [Peaks] AS [p]
	    ON [m].[Id] = [p].[MountainId]
	 WHERE [c].CountryName = 'Bulgaria' AND [p].[Elevation] > 2835
  ORDER BY [p].[Elevation] DESC

-- PROBLEM 13

	SELECT [CountryCode]
	,COUNT([MountainId]) AS [MountainRanges]
	  FROM [MountainsCountries]
     WHERE [CountryCode] IN (
							  SELECT [CountryCode]
							  FROM [Countries]
							  WHERE [CountryName] IN ('United States', 'Russia', 'Bulgaria')
							)
  GROUP BY [CountryCode]


-- PROBLEM 14
		SELECT 
		 TOP 5 [CRQueiry].[CountryName]
		      ,[CRQueiry].[RiverName]
		 FROM(  
				SELECT  [cc].[CountryName]
					   ,[r].[RiverName]
					   ,[cc].ContinentCode
						  FROM [Countries] AS [cc]		 
					 LEFT JOIN [CountriesRivers] AS [cr]
							ON [cc].[CountryCode] = [cr].[CountryCode]
					 LEFT JOIN [Rivers] AS [r]
							ON [r].[Id] = [cr].[RiverId]
		    ) AS [CRQueiry]
		JOIN [Continents] AS [c]
		  ON [c].ContinentCode = [CRQueiry].[ContinentCode]
	   WHERE [c].ContinentName = 'Africa'
	ORDER BY [CRQueiry].[CountryName]


			SELECT 
		 TOP 5 [cc].[CountryName]
			  ,[r].[RiverName]
		  FROM [Countries] AS [cc]
		  JOIN [Continents] AS [c]
		    ON [c].[ContinentCode] = [cc].[ContinentCode]
	 LEFT JOIN [CountriesRivers] AS [cr]
	        ON [cc].[CountryCode] = [cr].[CountryCode]
	 LEFT JOIN [Rivers] AS [r]
		    ON [r].[Id] = [cr].[RiverId]
		 WHERE [c].[ContinentName] = 'Africa'
	  ORDER BY [cc].[CountryName]


-- PROBLEM 15
	SELECT [ContinentCode]
		  ,[CurrencyCode]
		  ,[CurrencyUsage]
      FROM(
			SELECT *
				,DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [Currencyusage] DESC) AS [CurrencyRank]
			  FROM(
					SELECT [ContinentCode]
					      ,[CurrencyCode]
					      ,COUNT(*) AS [CurrencyUsage]
					 FROM [Countries]
			   	 GROUP BY [ContinentCode],[CurrencyCode]
				   HAVING COUNT(*)>1
				 )
				       AS [CurrencyUsageSubquery]
		 )
		 AS [CurrencyRankingQuery]
	WHERE [CurrencyRank] = 1


-- PROBLEM 16
			

		SELECT 
		 COUNT ([c].[CountryName])
		  FROM  [Countries] AS [c]
LEFT OUTER JOIN [MountainsCountries] AS [mc]
		     ON [mc].[CountryCode] = [c].[CountryCode]
		  WHERE [mc].[MountainId] IS NULL


-- PROBLEM 17
		 SELECT		
	      TOP 5 [c].[CountryName]
		  ,MAX([p].[Elevation]) AS [HighestPeakElevation]
          ,MAX([r].[Length]) AS [LongestRiverLenght]
	      FROM [Countries] AS [c]
	 LEFT JOIN [CountriesRivers] AS [cr]
			ON [c].[CountryCode] = [cr].[CountryCode]
	 LEFT JOIN [Rivers] AS [r]
			ON [cr].RiverId = [r].[Id]
	 LEFT JOIN [MountainsCountries] AS [mc]
			ON [mc].CountryCode = [c].[CountryCode]
	 LEFT JOIN [Mountains] AS [m]
			ON [mc].[MountainId] = [m].[Id]
	 LEFT JOIN [Peaks] AS [p]
			ON [p].[MountainId] = [m].[Id]
	  GROUP BY [c].[CountryName]
      ORDER BY [HighestPeakElevation] DESC
			  ,[LongestRiverLenght] DESC
			  ,[CountryName]

-- PROBLEM 18
	  SELECT 
	     TOP 5[CountryName] AS [Country]
			,ISNULL([PEAKNAME], '(no highest peak)') AS [Highest Peak Name]
			,CASE
				 WHEN [Elevation] IS NULL THEN 0
				 ELSE [Elevation]
			 END AS [Highest Peak Elevation]
			,CASE
				 WHEN [MountainRange] IS NULL THEN '(no mountain)'
				 ELSE [MountainRange]
			 END AS [Mountain]
		FROM(
			  SELECT [c].[CountryName]
				    ,[p].[PeakName]
				    ,[p].[Elevation]
				    ,[m].[MountainRange]
				    ,DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) AS [PeakRank]
			   FROM [Countries] AS [c]
		 LEFT JOIN [MountainsCountries] AS [mc]
			    ON [mc].[CountryCode] = [c].[CountryCode]
	     LEFT JOIN [Mountains] AS [m]
			    ON [mc].[MountainId] = [m].[Id]
		 LEFT JOIN [Peaks] AS [p]
			    ON [p].[MountainId] = [m].[Id]
			)
		AS [PeakRankinSubquery]
	 WHERE [PeakRank] = 1
  ORDER BY [Country]
		  ,[Highest Peak Name]


