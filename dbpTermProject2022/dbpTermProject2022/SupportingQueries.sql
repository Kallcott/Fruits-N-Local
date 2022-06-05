--USE master
USE DbpTermProject2022;
GO

SELECT * FROM Users
SELECT * FROM Users WHERE Username = 'jmurray' AND [Password]= '12345';

SELECT * FROM Fruits;

SELECT * FROM Fruits INNER JOIN Country;

SELECT Count(*) FROM Users WHERE Username = 'admin' AND Password = 'admin';

SELECT * FROM Fruits;

SELECT * FROM Regions;
SELECT RegionId, RegionName FROM Regions ORDER BY RegionName ASC

SELECT * FROM Fruits_Regions;
SELECT * FROM Fruits_Regions WHERE FruitsId = '1';


SELECT 
        RegionsName AS 'Region Name'
FROM Fruits_Regions
INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.RegionsId
INNER JOIN Regions ON Regions.RegionsId = Fruits_Regions.RegionsId
WHERE Fruits_Regions.FruitsId = '1'
ORDER BY [Region Name];


SELECT * FROM Fruits_Regions ORDER BY RegionsId;

SELECT 
        Fruits_Regions.Fruits_RegionsId,  Fruits.FruitsName AS 'Fruit Name'
FROM Fruits_Regions 
    INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.FruitsId
    INNER JOIN Regions ON Regions.RegionsId = Fruits_Regions.RegionsId
WHERE Fruits_Regions.RegionsId = '1'
ORDER BY [Fruit Name];

SELECT COUNT(*) AS 'Fruits Connections' FROM Fruits WHERE RegionsId = '46';
SELECT * FROM Fruits;

SELECT COUNT(*) AS 'Fruits Connections' FROM Fruits WHERE RegionsId = '26';

SELECT 
(
    SELECT TOP(1) Fruits_RegionsId as FirstFruits_RegionsId FROM Fruits_Regions ORDER BY Fruits_RegionsId ASC
) as FirstFruits_RegionsId,
q.PreviousFruits_RegionsId,
q.NextFruits_RegionsId,
(
    SELECT TOP(1) Fruits_RegionsId as LastFruits_RegionsId FROM Fruits_Regions ORDER BY Fruits_RegionsId Desc
) as LastFruits_RegionsId,
q.RowNumber
FROM
(
    SELECT Fruits_RegionsId,
    LEAD(Fruits_RegionsId) OVER(ORDER BY Fruits_RegionsId) AS NextFruits_RegionsId,
    LAG(Fruits_RegionsId) OVER(ORDER BY Fruits_RegionsId) AS PreviousFruits_RegionsId,
    ROW_NUMBER() OVER(ORDER BY Fruits_RegionsId) AS 'RowNumber'
    FROM Fruits_Regions
) AS q
WHERE q.Fruits_RegionsId = '1'
ORDER BY q.Fruits_RegionsId

SELECT FruitsID, Fruitsname FROM Fruits ORDER BY Fruitsname ASC
SELECT RegionsID, Regionsname FROM Regions ORDER BY Regionsname ASC

WITH FruitsOrder AS
SELECT 
        Fruits_Regions.Fruits_RegionsId,  Fruits.FruitsName AS 'Fruit Name'
FROM Fruits_Regions 
    INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.FruitsId
WHERE Fruits_Regions.FruitsId = '1'
ORDER BY [Fruit Name];

    SELECT UserId, UserName,
    LEAD(UserId) OVER(ORDER BY UserName) AS NextUserId,
    LAG(UserId) OVER(ORDER BY UserName) AS PreviousUserId,
    ROW_NUMBER() OVER(ORDER BY UserName) AS 'RowNumber'
    FROM Users


    SELECT Fruits_RegionsId,
    LEAD(Fruits_RegionsId) OVER(ORDER BY FruitsId) AS NextFruits_RegionsId,
    LAG(Fruits_RegionsId) OVER(ORDER BY FruitsId) AS PreviousFruits_RegionsId,
    ROW_NUMBER() OVER(ORDER BY FruitsId) AS 'RowNumber'
    FROM Fruits_Regions

	      INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.FruitsId
    ORDER BY [Fruit Name]

    SELECT Fruits_Regions.Fruits_RegionsId, Fruits.FruitsName AS 'Fruit Name',
    LEAD(Fruits_Regions.FruitsId) OVER(ORDER BY Fruits_RegionsId) AS NextFruits_RegionsId,
    LAG(Fruits_Regions.FruitsId) OVER(ORDER BY Fruits_RegionsId) AS PreviousFruits_RegionsId,
    ROW_NUMBER() OVER(ORDER BY Fruits.FruitsName) AS 'RowNumber'
    FROM Fruits_Regions
        INNER JOIN Fruits ON Fruits.FruitsId = Fruits_Regions.FruitsId
    ORDER BY [Fruit Name]


