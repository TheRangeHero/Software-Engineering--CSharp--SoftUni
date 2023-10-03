CREATE DATABASE [Airport]

GO
USE [Airport]
GO

CREATE TABLE [Passengers]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [FullName] VARCHAR(100) UNIQUE NOT NULL,			 
			 [Email] VARCHAR(50) UNIQUE NOT NULL,			 
			 )

CREATE TABLE [Pilots]
		     (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [FirstName] VARCHAR(30) UNIQUE NOT NULL,				
			 [LastName] VARCHAR(30) UNIQUE NOT NULL,			
			 [Age] TINYINT NOT NULL CHECK ([Age] BETWEEN 21 AND 62),
			 [Rating] FLOAT NULL CHECK([Rating]>=0.0 AND [Rating]<=10.0),			 
			 )

CREATE TABLE [AircraftTypes]
			 (
			 [Id]  INT PRIMARY KEY IDENTITY,
			 [TypeName] VARCHAR(30) UNIQUE NOT NULL,			
			 )

CREATE TABLE [Aircraft]
		     (
			 [Id]  INT PRIMARY KEY IDENTITY,
			 [Manufacturer] VARCHAR(25) NOT NULL,
			 [Model] VARCHAR(30) NOT NULL,
			 [Year] INT NOT NULL,
			 [FlightHours] INT,
			 [Condition] CHAR(1) NOT NULL,
			 [TypeId] INT FOREIGN KEY REFERENCES [AircraftTypes]([Id]) NOT NULL,
			 )

CREATE TABLE [PilotsAircraft]
		     (
			 [AircraftId] INT FOREIGN KEY REFERENCES [Aircraft]([Id]) NOT NULL,
			 [PilotId] INT FOREIGN KEY REFERENCES [Pilots]([Id]) NOT NULL,
			 PRIMARY KEY ([AircraftId],[PilotId])
			 )

CREATE TABLE [Airports]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [AirportName] VARCHAR(70) UNIQUE NOT NULL,			 
			 [Country] VARCHAR(100) UNIQUE NOT NULL,			 
			 )

CREATE TABLE [FlightDestinations]
			 (
			 [Id] INT PRIMARY KEY IDENTITY,
			 [AirportId] INT FOREIGN KEY REFERENCES [Airports]([Id]) NOT NULL,
			 [Start] DATETIME,
			 [AircraftId] INT FOREIGN KEY REFERENCES [Aircraft]([Id]) NOT NULL,
			 [PassengerId] INT FOREIGN KEY REFERENCES [Passengers]([Id]) NOT NULL,
			 [TicketPrice] DECIMAL(18,2) DEFAULT(15.0) NOT NULL,
			 )


-- PROBLEM 2

		INSERT INTO [Passengers]([FullName],[Email])
			 SELECT CONCAT([FirstName],' ',[LastName])
				   ,CONCAT([FirstName],[LastName],'@gmail.com')
			   FROM [Pilots]
			WHERE [Id]>=5 AND [Id]<=15

-- PROBLEM 3

		UPDATE Aircraft
		   SET Condition = 'A'
		 WHERE(Condition = 'B' OR Condition = 'C')
		   AND
			  (FlightHours IS NULL OR FlightHours <=100)
		   AND
			   [YEAR]>=2013
   
--PROBLEM 4

DELETE FROM Passengers 
      WHERE LEN(FullName) <=10

-- PROBLEM 5

	SELECT Manufacturer
		  ,Model
		  ,FlightHours
		  ,Condition
	  FROM Aircraft
  ORDER BY FlightHours DESC

-- PROBLEM 6

		SELECT P.FirstName
			  ,P.LastName
			  ,a.Manufacturer
			  ,a.Model
			  ,a.FlightHours
		  FROM Pilots AS p
		  JOIN PilotsAircraft AS pa
			ON p.Id = pa.PilotId
		  JOIN Aircraft AS a
			ON a.Id = pa.AircraftId
		 WHERE a.FlightHours IS NOT NULL AND a.FlightHours < 304
	  ORDER BY A.FlightHours DESC
			  ,p.FirstName

-- PROBLEM 7

		SELECT
		TOP 20 fd.Id AS DestinationId
			  ,fd.[Start]
			  ,a.AirportName
			  ,fd.TicketPrice
		  FROM FlightDestinations AS fd
		  JOIN Airports AS a
		    ON a.Id = fd.AirportId
		  JOIN Passengers AS p
		    ON fd.PassengerId = p.Id
		 WHERE DATEPART(DAY,fd.[Start]) % 2 = 0
	  ORDER BY FD.TicketPrice DESC
			  ,a.AirportName

-- PROBLEM 8

		SELECT a.Id AS AircraftId
			  ,a.Manufacturer
			  ,a.FlightHours
			  ,COUNT(fd.Id) AS FlightDestinationsCount
			  ,ROUND(AVG(fd.TicketPrice),2) AS AvgPrice
		  FROM Aircraft AS a
		  JOIN FlightDestinations AS fd
		    ON a.Id = fd.AircraftId
	  GROUP BY a.Id, a.Manufacturer, A.FlightHours
	    HAVING COUNT(fd.Id)>=2
	  ORDER BY FlightDestinationsCount DESC
			  ,AircraftId

-- PROBLEM 9 

		SELECT p.FullName
			  ,COUNT(a.Id) AS CountOfAircraft
			  ,SUM(fd.TicketPrice) AS TotalSum
		  FROM Passengers AS p
		  JOIN FlightDestinations AS fd
		    ON fd.PassengerId = p.Id
		  JOIN Aircraft AS a
		    ON fd.AircraftId = a.Id
		 WHERE SUBSTRING(p.FullName,2,1) = 'a' 
	  GROUP BY p.Id,P.FullName
		HAVING COUNT(a.Id)>1
	  ORDER BY p.FullName

-- PROBLEM 10

		SELECT ap.AirportName
			  ,fd.[Start] AS DayTime
			  ,fd.TicketPrice
			  ,p.FullName
			  ,a.Manufacturer
			  ,a.Model
		  FROM FlightDestinations AS fd
		  JOIN Passengers AS p
		    ON p.Id = fd.PassengerId
		  JOIN Aircraft AS a
		    ON fd.AircraftId = a.Id
		  JOIN Airports AS ap
		    ON ap.Id = fd.AirportId
		 WHERE CAST(fd.[Start] AS TIME) BETWEEN '06:00' AND '20:00'
		   AND fd.TicketPrice >2500
	  ORDER BY a.Model

-- PROBLEM 11

		CREATE FUNCTION udf_FlightDestinationsByEnail (@email VARCHAR(50))
			RETURNS INT
					 AS
				  BEGIN
						DECLARE @destinationsCount INT
							SET @destinationsCount = (
													  SELECT COUNT(fd.Id)
														FROM FlightDestinations AS fd
														JOIN Passengers AS p
														  ON fd.PassengerId = p.Id
													   WHERE p.Email = @email
													GROUP BY p.Id
													 )
						   IF (@destinationsCount) IS NULL
						BEGIN
							 SET @destinationsCount = 0
						  END
				  
					   RETURN @destinationsCount
					END

			SELECT [dbo].udf_FlightDestinationsByEnail '...'

-- PROBLEM 12

		CREATE PROCEDURE usp_SearchByAirportName @airportName VARCHAR(70)
					  AS
				   BEGIN
						 SELECT a.AirportName
							   ,p.FullName
							   ,CASE
									WHEN fd.TicketPrice <= 400 THEN 'Low'
									WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium'
									ELSE 'High' 
									 END 
									  AS LevelOfTicketPrice				
							   ,ac.Manufacturer
							   ,ac.Condition
							   ,t.TypeName
						   FROM Airports AS a
						   JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
						   JOIN Passengers AS p ON fd.PassengerId = p.Id
						   JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
						   JOIN AircraftTypes AS t ON t.Id = ac.TypeId
						  WHERE a.AirportName = @airportName
					   ORDER BY ac.Manufacturer
							   ,p.FullName
					 END

		EXEC [dbo].usp_SearchByAirportName