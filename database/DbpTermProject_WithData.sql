
--	PAD_INDEX = OFF, 
--		-- When on it creates empty indexes between leafs (collections of rows) 
--		-- to make insertion faster, uesfull for tables with >100'000 rows
--		-- Pad index is only useful with FillFactor. The lower the fillfactor the greater effect. 
--		-- https://stackoverflow.com/questions/6857007/what-is-the-purpose-of-pad-index-in-this-sql-server-constraint 
--	STATISTICS_NORECOMPUTE = OFF, 
--		-- During a index's creation or rebuild the entire database's statistics are updates. 
--		-- This toggles whether the index's statistics will be updated if a different table is rebuilt. 
--		-- This does not include column level statistics, only indexes. 
--		-- https://www.itprotoday.com/statisticsnorecompute-when-would-anyone-want-use-it
--	IGNORE_DUP_KEY = OFF, 
--		-- OFF = an error will be thrown if a key is duplicated. 
--	ALLOW_ROW_LOCKS = ON, 
--	ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--		-- Locks mean that a portion of data can't be checked out or edited by a second user. 
--		-- A row lock goes row by row
--		-- A page lock goes 8K worth of data at a time. 
--			-- This data amount can spill over outside your request, but not spill into other tables. 
--) ON [PRIMARY]
--	-- The default file group. File Groups control the directory the table is saved in. 

SET NOCOUNT ON;
GO

USE [master]
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'DbpTermProject2022')
	-- The N in front of strings stands for National Language in SQL-92 standard. 
	-- It converts them to unicode before becoming an nvarcahr
BEGIN
DROP DATABASE [DbpTermProject2022]
PRINT('DbpTermProject2022 Database Deleted')
END
GO

CREATE DATABASE [DbpTermProject2022]
GO

USE [DbpTermProject2022]
GO
PRINT('DbpTermProject2022 Database Created')
PRINT('-----------------------------' + CHAR(13)+CHAR(10))
GO


CREATE TABLE [dbo].[Fruits](
	[FruitsId] [int] IDENTITY(1,1) NOT NULL,
	[RegionsId] [int] NOT NULL,
	[FruitsName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Fruits] PRIMARY KEY CLUSTERED 
 -- Clustered ensures the primaray keys will be sorterd ASC
(
	[FruitsId] ASC
)WITH (
	PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] 
) ON [PRIMARY]
GO
PRINT('Table Fruits Created')
GO

CREATE TABLE [dbo].[Regions](
	[RegionsId] [int] IDENTITY(1,1) NOT NULL,
	[RegionsName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_RegionsId] PRIMARY KEY CLUSTERED 
(
	[RegionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Regions Created')
GO

--CREATE TABLE [dbo].[Months](
--	[MonthsId] [int] IDENTITY(1,1) NOT NULL,
--	[Months] [nvarchar](9) NOT NULL,
-- CONSTRAINT [PK_Months] PRIMARY KEY CLUSTERED 
--(
--	[MonthsId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--PRINT('Table Months Created')
--GO

CREATE TABLE [dbo].[Fruits_Regions](
	[Fruits_RegionsId] [int] IDENTITY(1,1) NOT NULL,
	[FruitsId] [int] NOT NULL,
	[RegionsId] [int] NOT NULL,
 CONSTRAINT [PK_Fruits_Oigin] PRIMARY KEY CLUSTERED 

(
	[Fruits_RegionsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Fruits_Regions Created')
GO

----CREATE TABLE [dbo].[Fruits_Months](
----	[Fruits_MonthsId] [int] IDENTITY(1,1) NOT NULL,
----	[FruitsId] [int] NOT NULL,
----	[MonthsId] [int] NOT NULL,
---- CONSTRAINT [PK_Fruits_Months] PRIMARY KEY CLUSTERED 

--(
--	[Fruits_MonthsId] ASC
--)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]
--GO
--PRINT('Table Fruits_Months Created')
--GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[isAdmin] [BIT] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 

(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Users Created')
PRINT('-----------------------------' + CHAR(13)+CHAR(10))
GO

SET IDENTITY_INSERT [dbo].[Fruits] ON 
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (1, 1, 'Apples')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (2, 37, 'Apricots')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (3, 6, 'Avocados')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (4, 5, 'Bananas')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (5, 5, 'Plantains')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (6, 18, 'Blueberries')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (7, 1, 'Cantaloupes')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (8, 31, 'Cherries')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (9, 1, 'Clementines')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (10, 42, 'Coconut')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (11, 18, 'Cranberries')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (12, 38, 'Dates')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (13, 31, 'Fig')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (14, 1, 'Grapefruit')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (15, 1, 'Grapes')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (16, 5, 'Guavas')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (17, 5, 'Papayas')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (18, 1, 'Honeydew')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (19, 1, 'Kiwis')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (20, 5, 'Kumquat')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (21, 5, 'Lemons')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (22, 5, 'Limes')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (23, 5, 'Mango')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (24, 39, 'Olives')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (25, 25, 'Passionfruit')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (26, 1, 'Peaches')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (27, 1, 'Pear')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (28, 43, 'Pineapples')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (29, 1, 'Plums')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (30, 30, 'Pomegranates')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (31, 40, 'Raspberries')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (32, 18, 'Strawberry')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (33, 1, 'Tomatoes')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (34, 1, 'Watermelon')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (35, 5, 'Tamarind')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (36, 11, 'Aki')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (37, 1, 'Squash')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (38, 1, 'Pumpkins')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (39, 1, 'Zucchini')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (40, 1, 'Peppers')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (41, 41, 'Dragon Fruits')
GO
INSERT [dbo].[Fruits] ([FruitsId], [RegionsId], [FruitsName]) VALUES (42, 1, 'Mandarin')
GO
SET IDENTITY_INSERT [dbo].[Fruits] OFF
GO

DECLARE @FruitsCount AS INT = -1;
SELECT @FruitsCount = COUNT(*) FROM Fruits;
PRINT(Convert(VARCHAR, @FruitsCount) + ' rows inserted into Fruitss');

SET IDENTITY_INSERT [dbo].[Regions] ON 
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (1, N'China')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (2, N'Kazakhstan')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (3, N'Kyrgyzstan')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (4, N'Armenia')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (5, N'India')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (6, N'Mexico')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (7, N'Indomalaya')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (8, N'Canada')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (9, N'Persia')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (10, N'Afghanistan')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (11, N'Jamaica')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (12, N'Central Europe')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (13, N'Algeria')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (14, N'Sri Lanka')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (15, N'Maldives')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (16, N'Philippines')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (17, N'Barbados')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (18, N'US')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (19, N'Iraq')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (20, N'Barbados')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (21, N'Middle East')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (22, N'Central South America')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (23, N'Southeast Asia')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (24, N'Italy')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (25, N'Brazil')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (26, N'Paraguay')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (27, N'Argentina')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (28, N'Eastern Europe')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (29, N'Caucasus Mountains')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (30, N'Iran')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (31, N'Turkey')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (32, N'France')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (33, N'Andes Mountains')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (34, N'Ethiopia ')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (35, N'Tropical Africa')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (36, N'Meso-America')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (37, N'Uzbekistan')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (38, N'Egypt')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (39, N'Spain')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (40, N'Russia')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (41, N'Vietnam')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (42, N'Indonesia')
GO
INSERT [dbo].[Regions] ([RegionsId], [RegionsName]) VALUES (43, N'Costa Rica')
GO
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO

DECLARE @RegionsCount AS INT = -1;
SELECT @RegionsCount = COUNT(*) FROM Regions;
PRINT(Convert(VARCHAR, @RegionsCount) + ' rows inserted into Regions');
GO

--SET IDENTITY_INSERT [dbo].[Months] ON 
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (1, N'January')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (2, N'February')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (3, N'March')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (4, N'April')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (5, N'May')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (6, N'June')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (7, N'July')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (8, N'August')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (9, N'September')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (10, N'October')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (11, N'November')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (12, N'December')
--GO
--INSERT [dbo].[Months] ([MonthsId], [Months]) VALUES (13, N'All')
--GO
--SET IDENTITY_INSERT [dbo].[Months] OFF
--GO

--DECLARE @MonthsCount AS INT = -1;
--SELECT @MonthsCount = COUNT(*) FROM [Months];
--PRINT(Convert(VARCHAR, @MonthsCount) + ' rows inserted into Months');
--GO

SET IDENTITY_INSERT [dbo].[Fruits_Regions] ON 
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (4, 2, 4)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (5, 2, 5)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (6, 2, 1)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (7, 3, 6)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (8, 4, 7)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (9, 5, 7)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (10, 6, 8)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (11, 7, 9)  -- 7 is Cantaloupes
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (12, 7, 10)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (13, 7, 4)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (14, 8, 12)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (15, 9, 13)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (16, 10, 14)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (17, 10, 15)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (18, 10, 16)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (19, 10, 42)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (20, 11, 8)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (21, 11, 18)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (22, 12, 19)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (23, 13, 19)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (24, 14, 20)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (25, 15, 21)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (26, 16, 6)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (27, 16, 22)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (28, 17, 6)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (29, 17, 22)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (30, 18, 13)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (31, 19, 1)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (32, 20, 23)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (33, 21, 5) -- 21 is lemons
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (34, 22, 23)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (35, 23, 23)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (36, 24, 24)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (37, 25, 25)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (38, 25, 26)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (39, 25, 27)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (40, 26, 1)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (41, 27, 1)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (42, 28, 25)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (43, 28, 26)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (44, 29, 28)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (45, 29, 29)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (46, 30, 30)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (47, 31, 31)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (48, 32, 32)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (49, 33, 33)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (50, 34, 34)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (51, 35, 35)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (52, 36, 35)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (53, 37, 36)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (54, 38, 36)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (55, 39, 36)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (56, 40, 36)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (57, 41, 36)
GO
INSERT [dbo].[Fruits_Regions] ([Fruits_RegionsId], [FruitsId], [RegionsId]) VALUES (58, 42, 1)
GO
SET IDENTITY_INSERT [dbo].[Fruits_Regions] OFF
GO

DECLARE @Fruits_RegionsCount AS INT = -1;
SELECT @Fruits_RegionsCount = COUNT(*) FROM Fruits_Regions;
PRINT(Convert(VARCHAR, @Fruits_RegionsCount) + ' rows inserted into Fruits_Regions');
GO

--SET IDENTITY_INSERT [dbo].[Fruits_Months] ON 
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (1, 1, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (2, 1, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (3, 1, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (4, 2, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (5, 2, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (6, 2, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (7, 3, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (8, 4, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (9, 5, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (10, 6, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (11, 6, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (12, 7, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (13, 7, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (14, 7, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (15, 8, 4)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (16, 8, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (17, 8, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (18, 8, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (19, 9, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (20, 9, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (21, 9, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (22, 9, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (23, 9, 4)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (24, 10, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (25, 11, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (26, 11, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (27, 11, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (28, 12, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (29, 12, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (30, 12, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (31, 12, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (32, 13, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (33, 13, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (34, 13, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (35, 13, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (36, 14, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (37, 14, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (38, 14, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (39, 14, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (40, 14, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (41, 15, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (42, 15, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (43, 15, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (44, 16, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (45, 16, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (46, 16, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (47, 17, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (48, 18, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (49, 18, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (50, 18, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (51, 19, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (52, 20, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (53, 20, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (54, 20, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (55, 20, 4)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (56, 21, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (57, 21, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (58, 21, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (59, 21, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (60, 21, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (61, 22, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (62, 22, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (63, 22, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (64, 22, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (65, 22, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (66, 23, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (67, 23, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (68, 23, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (69, 23, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (70, 23, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (71, 24, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (72, 24, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (73, 24, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (74, 24, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (75, 25, 13)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (76, 26, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (77, 26, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (78, 26, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (79, 26, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (80, 26, 9)  -- Peaches
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (81, 27, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (82, 27, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (83, 27, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (84, 27, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (85, 27, 1) -- Pear
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (86, 28, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (87, 28, 4)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (88, 28, 5)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (89, 28, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (90, 28, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (91, 29, 5)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (92, 29, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (93, 29, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (94, 29, 8)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (95, 29, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (96, 29, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (97, 30, 12)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (98, 30, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (99, 30, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (100, 30, 10)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (101, 30, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (102, 31, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (103, 31, 7)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (104, 31, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (105, 31, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (106, 31, 10)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (107, 31, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (108, 32, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (109, 32, 4)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (110, 32, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (111, 32, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (112, 32, 7)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (113, 32, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (114, 32, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (115, 32, 10)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (116, 32, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (117, 33, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (118, 33, 6)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (119, 33, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (120, 33, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (121, 33, 9)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (123, 33, 10)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (124, 34, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (125, 34, 7)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (126, 34, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (127, 35, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (128, 35, 2)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (129, 35, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (130, 36, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (131, 36, 2)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (132, 36, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (133, 36, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (134, 36, 7)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (135, 36, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (136, 37, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (137, 37, 1)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (138, 37, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (139, 37, 6)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (140, 37, 7)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (141, 37, 8)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (142, 38, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (143, 38, 10)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (144, 38, 11)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (145, 39, 5)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (146, 39, 6)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (147, 39, 7)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (148, 39, 8)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (149, 39, 9)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (150, 40, 13)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (151, 41, 1)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (152, 41, 2)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (153, 41, 3)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (154, 41, 4)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (155, 42, 12)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (156, 42, 1)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (157, 42, 2)
--GO
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (158, 42, 3)
--Go
--INSERT [dbo].[Fruits_Months] ([Fruits_MonthsId], [FruitsId], [MonthsId]) VALUES (159, 42, 11)
--GO
--SET IDENTITY_INSERT [dbo].[Fruits_Months] OFF
--GO

--DECLARE @Fruits_MonthsCount AS INT = -1;
--SELECT @Fruits_MonthsCount = COUNT(*) FROM Fruits_Months;
--PRINT(Convert(VARCHAR, @Fruits_MonthsCount) + ' rows inserted into Fruits_Months');
--GO

SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [isAdmin]) VALUES (1, N'jmurray', N'12345', 1)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [isAdmin]) VALUES (2, N'admin', N'admin', 1)
GO
INSERT [dbo].[Users] ([UserId], [Username], [Password], [isAdmin]) VALUES (3, N'user', N'user', 0)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO

DECLARE @UsersCount AS INT = -1;
SELECT @UsersCount = COUNT(*) FROM Users;
PRINT(Convert(VARCHAR, @UsersCount) + ' rows inserted into Users');
PRINT('-----------------------------' + CHAR(13)+CHAR(10))
GO

-- Fruits_Producer
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Producer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits]'))
ALTER TABLE [dbo].[Fruits]  WITH CHECK ADD  CONSTRAINT [FK_Fruits_Producer] FOREIGN KEY([RegionsId])
REFERENCES [dbo].[Regions] ([RegionsId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Producer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits]'))
ALTER TABLE [dbo].[Fruits] CHECK CONSTRAINT [FK_Fruits_Producer]
GO
PRINT('FK_Fruits_Producer Foreign Key Created')

-- Fruits_Regions
-- To Fruits ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Regions_Fruits]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Regions]'))
ALTER TABLE [dbo].[Fruits_Regions]  WITH CHECK ADD  CONSTRAINT [FK_Fruits_Regions_Fruits] FOREIGN KEY([FruitsId])
REFERENCES [dbo].[Fruits] ([FruitsId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Regions_Fruits]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Regions]'))
ALTER TABLE [dbo].[Fruits_Regions] CHECK CONSTRAINT [FK_Fruits_Regions_Fruits]
GO
PRINT('FK_Fruits_Regions_Fruits - FruitsID Foreign Key Created')

-- To Region ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Regions_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Regions]'))
ALTER TABLE [dbo].[Fruits_Regions]  WITH CHECK ADD  CONSTRAINT [FK_Fruits_Regions_Region] FOREIGN KEY([RegionsId])
REFERENCES [dbo].[Regions] ([RegionsId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Regions_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Regions]'))
ALTER TABLE [dbo].[Fruits_Regions] CHECK CONSTRAINT [FK_Fruits_Regions_Region]
GO
PRINT('FK_Fruits_Regions_Regions - RegionsId Foreign Key Created')


---- Fruits_Months
---- To Fruits ID
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Fruits]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Months]'))
--ALTER TABLE [dbo].[Fruits_Months]  WITH CHECK ADD  CONSTRAINT [FK_Fruits_Months_Fruits] FOREIGN KEY([FruitsId])
--REFERENCES [dbo].[Fruits] ([FruitsId])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Fruits]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruits_Months]'))
--ALTER TABLE [dbo].[Fruits_Months] CHECK CONSTRAINT [FK_Fruits_Months_Fruits]
--GO
--PRINT('FK_Fruits_Months_Fruits - FruitsID Foreign Key Created')


---- To Months ID
--IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Months]') AND parent_object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Months]'))
--ALTER TABLE [dbo].[Fruits_Months]  WITH CHECK ADD  CONSTRAINT [FK_Fruits_Months_Months] FOREIGN KEY([MonthsId])
--REFERENCES [dbo].[Months] ([MonthsId])
--GO
--IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Months]') AND parent_object_id = OBJECT_ID(N'[dbo].[FK_Fruits_Months_Months]'))
--ALTER TABLE [dbo].[Fruits_Months] CHECK CONSTRAINT [FK_Fruits_Months_Months]
--GO
--PRINT('FK_Fruits_Months_Months - MonthsId Foreign Key Created')


USE [master]
GO
ALTER DATABASE [DbpTermProject2022] SET READ_WRITE 
GO
