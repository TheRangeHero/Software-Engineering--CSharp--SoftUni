GO
USE  [Gringotts]
GO

-- PROBLEM 1


		SELECT COUNT([Id]) AS [Count]
		  FROM [WizzardDeposits]


-- PROBLEM 2

		SELECT MAX([MagicWandSize]) AS [LongestMagicWand]
		  FROM [WizzardDeposits]


-- PROBLEM 3


		SELECT [DepositGroup]
			  ,MAX([MagicWandSize]) AS [LongestMagicWand]
		  FROM [WizzardDeposits]
	  GROUP BY [DepositGroup]


-- PROBLEM 4


		SELECT 
		 TOP 2 [DepositGroup]
		  FROM [WizzardDeposits]
	  GROUP BY [DepositGroup]
      ORDER BY AVG([MagicWandSize]) ASC


-- PROBLEM 5


		SELECT [DepositGroup]
			  ,SUM([DepositAmount]) AS [TotalSum]
		  FROM [WizzardDeposits]
	  GROUP BY [DepositGroup]


-- PROBLEM 6



		SELECT [DepositGroup]
			  ,SUM([DepositAmount]) AS [TotalSum]
		  FROM [WizzardDeposits]
	     WHERE [MagicWandCreator] = 'Ollivander family'
	  GROUP BY [DepositGroup]


-- PROBLEM 7


		SELECT [DepositGroup]
			  ,SUM([DepositAmount]) AS [TotalSum]
		  FROM [WizzardDeposits]
		 WHERE [MagicWandCreator] = 'Ollivander family'
	  GROUP BY [DepositGroup]
		HAVING SUM([DepositAmount]) <150000
	  ORDER BY [TotalSum] DESC


-- PROBLEM 8


		SELECT [DepositGroup]
			  ,[MagicWandCreator]
			  ,MIN(DepositCharge) AS [MinDepositChartge]
		  FROM [WizzardDeposits]
	  GROUP BY [DepositGroup],[MagicWandCreator]
	  ORDER BY [MagicWandCreator],[DepositGroup]


-- PROBLEM 9


	  SELECT [AgeGroup]
			,COUNT(*)
		FROM (
			  SELECT 
			  CASE
				  WHEN [Age] <= 10 THEN '[0-10]'
				  WHEN [Age] <= 20 THEN '[11-20]'
				  WHEN [Age] <= 30 THEN '[21-30]'
				  WHEN [Age] <= 40 THEN '[31-40]'
				  WHEN [Age] <= 50 THEN '[41-50]'
				  WHEN [Age] <= 60 THEN '[51-60]'
				  WHEN [Age] >= 61 THEN '[61+]'
			   END AS [AgeGroup] 
			  FROM [WizzardDeposits]
			 )  AS [AgeGroupQuerry]
	GROUP BY [AgeGroup]


-- PROBLEM 10


		SELECT [FirstLetter]
		  FROM (
				  SELECT
				DISTINCT SUBSTRING(FirstName,1,1) AS [FirstLetter]
				    FROM [WizzardDeposits]
				   WHERE [DepositGroup] = 'Troll ChesT'
			   ) AS [SsubstingQuerry]
	  GROUP BY [FirstLetter]
	  ORDER BY [FirstLetter]


-- PROBLEM 11


		SELECT [DepositGroup]
			  ,[IsDepositExpired]
			  ,AVG(DepositInterest) AS [AverageInterest]
		  FROM [WizzardDeposits]
		 WHERE [DepositStartDate] > '01-01-1985'
	  GROUP BY [DepositGroup],[IsDepositExpired]
      ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC


-- PROBLEM 12


--SELECT*
--  FROM[WizzardDeposits] AS [wD1]
--  JOIN [WizzardDeposits] AS [WD2]
--  ON [wD1].[Id]+1 = [WD2].[Id]

		SELECT SUM([Difference]) AS [SumDifference]
		  FROM (
				  SELECT [FirstName] AS [Host Wizard]
					  ,[DepositAmount] AS [Host Wizard Deposit]
					  ,LEAD([FirstName]) OVER(ORDER BY [Id]) AS [Guest Wizard]
					  ,LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Guest Wizard Deposit]
					  ,([DepositAmount]) - LEAD([DepositAmount]) OVER (ORDER BY [Id]) AS [Difference]
				 FROM [WizzardDeposits]
			  ) AS [DifferenceSubquerry]


-- PROBLEM 13
GO
USE SoftUni
GO

		--SELECT [e].[DepartmentID]
		--	  ,SUM([Salary]) AS [TotalSalary]
		--  FROM [Employees] AS [e]
		--  JOIN [Departments] AS [d]
		--  ON [e].[DepartmentID] = [d].[DepartmentID]
  --  GROUP BY [e].[DepartmentID]
  --  ORDER BY [e].[DepartmentID]

  
		SELECT [e].[DepartmentID]
			  ,SUM([Salary]) AS [TotalSalary]
		  FROM [Employees] AS [e]		 
    GROUP BY [e].[DepartmentID]
    ORDER BY [e].[DepartmentID]


-- PROBLEM 14

		 SELECT [DepartmentID], MIN(Salary)
		   FROM [Employees]
		  WHERE [DepartmentID] IN (2,5,7) AND [HireDate]>'01-01-2000'
	   GROUP BY [DepartmentID]


-- PROBLEM 15


		SELECT *
		  INTO [NewTable]
		  FROM [Employees]
		 WHERE [Salary] > 30000

		DELETE FROM [NewTable]
		      WHERE [ManagerID]=42

		UPDATE [NewTable]
		   SET [Salary]+=5000
		 WHERE [DepartmentID] = 1

		SELECT DepartmentID, AVG(Salary)
		  FROM [NewTable]
	  GROUP BY [DepartmentID]


-- PROBLEM 16


		SELECT [DepartmentID], MAX([Salary])
		  FROM [Employees]
	  GROUP BY [DepartmentID]
	    HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


-- PROBLEM 17


		SELECT COUNT([EmployeeID]) AS [Count]
		  FROM [Employees]
		 WHERE [ManagerID] IS NULL
