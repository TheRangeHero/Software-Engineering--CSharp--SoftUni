CREATE DATABASE [NationalTouristSitesOfBulgaria]
GO
USE [NationalTouristSitesOfBulgaria]
GO

CREATE TABLE [Categories] 
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL
			 )

CREATE TABLE [Locations]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 [Municipality] VARCHAR(50),
			 [Province] VARCHAR(50)
			 )

CREATE TABLE [Sites]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(100) NOT NULL,
			 [LocationId] INT FOREIGN KEY REFERENCES [Locations]([Id]) NOT NULL,
			 [CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
			 [Establishment] VARCHAR(15)
			 )

CREATE TABLE [Tourists]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL,
			 [Age] INT NOT NULL,
			 CONSTRAINT [TouristAge_Ck] CHECK([Age] BETWEEN 0 AND 120),
			 [PhoneNumber] VARCHAR(20) NOT NULL,
			 [Nationality] VARCHAR(30) NOT NULL,
			 [Reward] VARCHAR(20)
			 )

CREATE TABLE [SitesTourists]
			 (
			 [TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]),
			 [SiteId] INT FOREIGN KEY REFERENCES [Sites]([Id]),
			 PRIMARY KEY ([TouristId],[SiteId])
			 )

CREATE TABLE [BonusPrizes]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(50) NOT NULL
			 )

CREATE TABLE [TouristsBonusPrizes]
			 (
			 [TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]),
			 [BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes]([Id]),
			 PRIMARY KEY ([TouristId],[BonusPrizeId])
			 )

-- PROBLEM 2

INSERT INTO [Tourists]([Name],[Age],[PhoneNumber],[Nationality],[Reward])
	 VALUES ('Borislava Kazakova',52 ,'+359896354244','Bulgaria',NULL),
	        ('Peter Bosh',48,'+447911844141','UK',NULL),
			('Martin Smith',29,'+353863818592','Ireland','Bronze badge'),
			('Svilen Dobrev',49,'+359986584786','Bulgaria','Silver badge'),
			('Kremena Popova',38,'+359893298604','Bulgaria',NULL)

INSERT INTO [Sites]([Name],[LocationId],[CategoryId],[Establishment])
	 VALUES ('Ustra fortress',90,7,'X'),
	        ('Karlanovo Pyramids',65 ,7 ,NULL),
			('The Tomb of Tsar Sevt',63,8,'V BC'),
			('Sinite Kamani Natural Park',17,1,NULL),
			('St. Petka of Bulgaria – Rupite',92,6,'1994')

-- PROBLEM 3

		UPDATE [Sites]
		   SET [Establishment] = '(not defined)'
		 WHERE [Establishment] IS NULL


-- PROBLEM 4

		SELECT [Id] 
		  FROM [BonusPrizes]
		 WHERE [Name] = 'Sleeping bag'

		DELETE
		  FROM [TouristsBonusPrizes]
		 WHERE [BonusPrizeId] = (
								 SELECT [Id] FROM [BonusPrizes]
								  WHERE [Name] = 'Sleeping bag'
								)
		DELETE 
		  FROM [BonusPrizes]
		 WHERE [Name] = 'Sleeping bag'

-- PROBLEM 5

		SELECT [Name]
			  ,[Age]
			  ,[PhoneNumber]
			  ,[Nationality]
		  FROM [Tourists]
	  ORDER BY [Nationality]
			  ,[Age] DESC
			  ,[Name]

-- PROBLEM 6

		SELECT [s].[Name] AS [Site]
			  ,[l].[Name] AS [Location]
			  ,[s].[Establishment]
			  ,[c].[Name] AS [Category]
		  FROM [Sites] AS [s]
	 LEFT JOIN [Locations] AS [l]
		    ON [l].[Id] = [s].[LocationId]
	 LEFT JOIN [Categories] AS [c]
		    ON [c].[Id] = [s].[CategoryId]
	  ORDER BY [c].[Name] DESC
	   		  ,[l].[Name]
			  ,[s].[Name]

-- PROBLEM 7


		SELECT [l].[Province]
			  ,[l].[Municipality]
			  ,[l].[Name] AS [Location]
			  ,COUNT([s].[Name]) AS [CountOfSites]
		  FROM [Locations] AS [l]
	      JOIN [Sites] AS [s]
		    ON [l].[Id] = [s].[LocationId]
		 WHERE [l].[Province] = 'Sofia'
	  GROUP BY [l].[Name]
			  ,[l].[Municipality]
			  ,[l].[Province]
	  ORDER BY [CountOfSites] DESC
	   		  ,[l].[Name]


-- PROBLEM 8


		SELECT [s].[Name] AS [Site]
			  ,[l].[Name] AS [Location]
			  ,[l].[Municipality]
			  ,[l].[Province]
			  ,[s].[Establishment]
		  FROM [Sites] AS [s]
		  JOIN [Locations] AS [l]
		    ON [l].[Id] = [s].[LocationId]
		 WHERE [l].[Name] NOT LIKE '[BMD]%' AND  [s].[Establishment] LIKE '%BC'
	  ORDER BY [s].[Name]

-- PROBLEM 9 

		SELECT [t].[Name]
			  ,[t].[Age]
			  ,[t].[PhoneNumber]
			  ,[t].[Nationality]
			  ,ISNULL([p].[Name],'(no bonus prize)')
		  FROM [Tourists] AS [t]
	 LEFT JOIN [TouristsBonusPrizes] [b]
	   	   ON [t].[Id] = [b].[TouristId]
	LEFT JOIN [BonusPrizes] AS [p]
		   ON [p].[Id] = [b].[BonusPrizeId]
	 ORDER BY [t].[Name]

-- PROBLEM 10

		SELECT DISTINCT SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name])) AS [LastName]
					   ,[t].[Nationality]
					   ,[t].[Age]
					   ,[t].[PhoneNumber]
				   FROM [Tourists] AS [t]
				   JOIN [SitesTourists] AS [st]
				     ON [st].[TouristId] = [t].[Id]
				   JOIN [Sites] AS [s]
				     ON [st].[SiteId] = [s].Id
				   JOIN [Categories] AS [c]
				     ON [s].[CategoryId] = [c].[Id]
				  WHERE [c].[Name] = 'History and archaeology'
			   ORDER BY [LastName]

-- PROBLEM 11
GO
	    CREATE FUNCTION [udf_GetTouristsCountOnATouristSite] (@Site VARCHAR(50))
			RETURNS INT
					 AS
				  BEGIN
					    DECLARE @countOfTourists INT = (				
													    SELECT COUNT([st].[TouristId])
													      FROM [Sites] AS [s]
													      JOIN [SitesTourists] AS [st]
													        ON [s].[Id] = [st].[SiteId]
													     WHERE [s].[Name] = @Site
													   )
						 RETURN @countOfTourists
					END

		SELECT [dbo].[udf_GetTouristsCountOnATouristSite] ('Gorge of Erma River')

-- PROBLEM 12
GO
CREATE OR ALTER PROCEDURE [usp_AnnualRewardLottery] @TouristName VARCHAR (50)
			  AS
		   BEGIN
			     IF(
						 SELECT COUNT([st].[TouristId])
						   FROM [Tourists] AS [t]
						   JOIN [SitesTourists] AS [st]
							 ON [t].[Id] = [st].[TouristId]
						  WHERE [t].[Name] = @TouristName
														  ) >=100
				    BEGIN
						 UPDATE [Tourists]
						    SET [Reward] = 'Gold badge'
						  WHERE [Name] = @TouristName
				      END
				 ELSE IF(
						 SELECT COUNT([st].[TouristId])
						   FROM [Tourists] AS [t]
						   JOIN [SitesTourists] AS [st]
						     ON [t].[Id] = [st].[TouristId]
						  WHERE [t].[Name] = @TouristName
															  )>=50
				   BEGIN
					     UPDATE [Tourists]
						    SET [Reward] = 'Silver badge'
						  WHERE [Name] = @TouristName
	    		     END
				 ELSE IF(
						 SELECT COUNT([st].[TouristId])
						   FROM [Tourists] AS [t]
						   JOIN [SitesTourists] AS [st]
						     ON [t].[Id] = [st].[TouristId]
						  WHERE [t].[Name] = @TouristName
															  )>=25
				   BEGIN
						 UPDATE [Tourists]
						    SET [Reward] = 'Bronze badge'
						  WHERE [Name] = @TouristName
				     END
				SELECT [Name]
					  ,[REWARD]
				  FROM [Tourists]
				 WHERE [Name] = @TouristName
		     END

EXEC [dbo].[usp_AnnualRewardLottery] 'Zac Walsh'