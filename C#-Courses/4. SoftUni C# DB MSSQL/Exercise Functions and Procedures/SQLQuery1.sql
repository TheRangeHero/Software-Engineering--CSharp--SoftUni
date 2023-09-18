USE [SoftUni]

GO


-- PROBLEM 1


		CREATE PROCEDURE [usp_GetEmployeesSalaryAbove35000]
					  AS
				   BEGIN  			  
						SELECT [FirstName]
							  ,[LastName]			  
						  FROM [Employees]
						 WHERE [Salary] > 35000
					 END

		EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]


-- PROBLEM 2


		CREATE PROCEDURE [usp_GetEmployeesSalaryAboveNumber]  @minSalary DECIMAL(18,4)
					  AS
				   BEGIN
						 SELECT [FirstName]
							   ,[LastName]			  
						   FROM [Employees]
						  WHERE [Salary] >= @minSalary
					 END
		
EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100


-- PROBLEM 3


		CREATE PROCEDURE [usp_GetTownsStartingWith] @searchedParam VARCHAR(50)
					  AS
				   BEGIN
				   DECLARE @stringLen INT = LEN(@searchedParam)
						 SELECT [Name] AS [Town]
						   FROM [Towns]
						  WHERE SUBSTRING([Name],1,@stringLen) = @searchedParam
					 END

EXEC [dbo].[usp_GetTownsStartingWith] 'B'


-- PROBLEM 4


		CREATE PROCEDURE [usp_GetEmployeesFromTown] @searchedTown VARCHAR(100)
					  AS
					  BEGIN
							SELECT [e].[FirstName]
								  ,[e].[LastName]
							  FROM [Employees] AS [e]
						INNER JOIN [Addresses] AS [a] ON [e].[AddressID]=[a].[AddressID]
						INNER JOIN [Towns] AS [t] ON [a].[TownID]=[t].[TownID]
							 WHERE [t].[Name] = @searchedTown					
						END

EXEC [dbo].[usp_GetEmployeesFromTown] 'Monroe'


-- PROBLEM 5


		CREATE FUNCTION [ufn_GetSalaryLevel] (@salary DECIMAL(18,4))
		RETURNS VARCHAR (10) 
					 AS
				  BEGIN
						DECLARE @level VARCHAR (10) = 'Average';
						IF @Salary<30000
						 BEGIN
								SET @level = 'Low';
						   END
						ELSE IF @Salary >50000
						 BEGIN
								SET @level = 'High';
						   END
						RETURN @level;
				   END;

		SELECT *,[dbo].[ufn_GetSalaryLevel](Salary) FROM Employees


-- PROBLEM 6 


		CREATE PROCEDURE [usp_EmployeesBySalaryLevel] @levelOfSalary VARCHAR (8)
					AS
					BEGIN
						 SELECT [FirstName]
							   ,[LastName]
						   FROM [Employees]
						  WHERE [dbo].[ufn_GetSalaryLevel](Salary) = @levelOfSalary
					 END;

		EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'


-- PROBLEM 7


		CREATE FUNCTION [ufn_IsWordComprised] (@setOfLeters VARCHAR(50),@word VARCHAR(50))
			RETURNS BIT
					 AS
				  BEGIN
						 DECLARE @wordIndex INT = 1;
						   WHILE(@wordIndex<=LEN(@word))
						   BEGIN
								 DECLARE @currentCharacter CHAR = SUBSTRING(@word, @wordIndex,1);
									  IF (CHARINDEX(@currentCharacter,@setOfLeters)=0)
								   BEGIN
										 RETURN 0;
									 END
									 SET @wordIndex +=1;							 
							 END
							 RETURN 1;
					END;

SELECT [dbo].[ufn_IsWordComprised] ('oistmiahf','Sofia')


-- PROBLEM 8


CREATE PROCEDURE [usp_DeleteEmployeesFromDepartment] @deparmentId INT
			  AS
		   BEGIN
		   -- Storing all the information which we will use for deleting
				 DECLARE @employessToDelete TABLE ([Id] INT);
				  INSERT INTO @employessToDelete
				       SELECT [EmployeeId]
				         FROM [Employees]
				        WHERE [DepartmentID] = @deparmentId


				 DELETE
				   FROM [EmployeesProjects]
				  WHERE [EmployeeID] IN (
											SELECT [Id]
											  FROM @employessToDelete
										)

				  ALTER TABLE [Departments]
				 ALTER COLUMN [ManagerID] INT

				  UPDATE [Departments]
				     SET [ManagerID] = NULL
				   WHERE [ManagerID] IN (
											SELECT [Id]
											  FROM @employessToDelete
										)

				 UPDATE [Employees]
				    SET [ManagerID] = NULL
				  WHERE [ManagerID] IN (
											SELECT [Id]
											  FROM @employessToDelete
									   )

				 DELETE
				   FROM [Employees]
				  WHERE [DepartmentID] = @deparmentId

				  DELETE
				    FROM [Departments]
				   WHERE [DepartmentID] = @deparmentId

				   SELECT COUNT(*)
				     FROM [Employees]
					 WHERE [DepartmentID] = @deparmentId
		     END;

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 7


-- PROBLEM 9
GO
USE Bank
GO

		CREATE PROCEDURE [usp_GetHoldersFullName]
					  AS
				   BEGIN
						 SELECT CONCAT([FirstName],' ',[LastName]) AS [Full Name]
						  FROM [AccountHolders]
					 END;

EXEC [dbo].[usp_GetHoldersFullName]


-- PROBLEM 10

CREATE PROCEDURE [usp_GetHoldersWithBalanceHigherThan] @searchedMoney MONEY
			  AS
		   BEGIN        
				 SELECT [FirstName]
					   ,[LastName]									
				   FROM [AccountHolders] AS [ah]
			 INNER JOIN [Accounts] AS [a]
					 ON [ah].Id = [a].AccountHolderId
			   GROUP BY [FirstName],[LastName]
		     HAVING SUM([a].Balance) > @searchedMoney
			   ORDER BY [FirstName],[LastName]
		     END;


EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 6546543


-- PROBLEM 11


CREATE FUNCTION [ufn_CalculateFutureValue] (@sum DECIMAL(15,4), @yearlyIterestRate FLOAT, @years INT)
RETURNS DECIMAL (15,4)
			 AS
		  BEGIN
		  DECLARE @FutureValue DECIMAL(15,4)
		  SET @FutureValue = @sum*POWER((1+@yearlyIterestRate),@years)

		  RETURN @FutureValue
		    END;


-- PROBLEM 12


CREATE PROCEDURE [usp_CalculateFutureValueForAccount] @accountId INT, @interestRate FLOAT
			  AS
			  SELECT [a].[Id] AS [Account Id],
					 [ah].[FirstName] AS [First Name],
					 [ah].[LastName] AS [Last Name],
					 [a].[Balance],
					 [dbo].[ufn_CalculateFutureValue] (Balance,@interestRate,5) AS [Balance in 5 years]
			   FROM [AccountHolders] AS [ah]
			   INNER JOIN Accounts AS [a]
			   ON [ah].[Id] = [a].[Id]
			   WHERE [a].[Id] = @accountId

-- PROBLEM 13
CREATE FUNCTION [ufn_CashInUsersGames] (@gameName NVARCHAR(50))
  RETURNS TABLE
	         AS
		 RETURN
	     (

				SELECT SUM([Cash]) AS [SumCash]
				  FROM (
							SELECT [g].[Name]
								  ,[ug].[Cash]
								  ,ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC) AS [RowNumber]
							 FROM [UsersGames] AS [ug]
					   INNER JOIN [Games] AS [g]
							   ON [ug].[GameId] = [g].[Id]
							WHERE [g].[Name] = @gameName
					) AS [RankingSubquery]
				 WHERE [RowNumber] % 2 <> 0
		)

SELECT * FROM [dbo].[ufn_CashInUsersGames] ('Love in a mist')

