
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


CREATE TABLE [dbo].[Fruit](
	[FruitId] [int] IDENTITY(1,1) NOT NULL,
	[ProducerId] [int] NOT NULL,
	[FruitName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Fruit] PRIMARY KEY CLUSTERED 
 -- Clustered ensures the primaray keys will be sorterd ASC
(
	[FruitId] ASC
)WITH (
	PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] 
) ON [PRIMARY]
GO
PRINT('Table Fruit Created')
GO

CREATE TABLE [dbo].[Regions](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RegionId] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Regions Created')
GO

CREATE TABLE [dbo].[Month](
	[MonthId] [int] IDENTITY(1,1) NOT NULL,
	[Month] [nvarchar](50) NOT NULL,
	[Abbreviation] [nvarchar](50) NULL,
 CONSTRAINT [PK_Month] PRIMARY KEY CLUSTERED 
(
	[MonthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Month Created')
GO

CREATE TABLE [dbo].[Fruit_Origin](
	[Fruit_OiginId] [int] IDENTITY(1,1) NOT NULL,
	[FruitId] [int] NOT NULL,
	[RegionId] [int] NOT NULL,
 CONSTRAINT [PK_Fruit_Oigin] PRIMARY KEY CLUSTERED 

(
	[Fruit_OiginId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Fruit_Origin Created')
GO

CREATE TABLE [dbo].[Fruit_Month](
	[Fruit_MonthId] [int] IDENTITY(1,1) NOT NULL,
	[FruitId] [int] NOT NULL,
	[MonthId] [int] NOT NULL,
 CONSTRAINT [PK_Fruit_Month] PRIMARY KEY CLUSTERED 

(
	[Fruit_MonthId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
PRINT('Table Fruit_Month Created')
PRINT('-----------------------------' + CHAR(13)+CHAR(10))
GO

SET IDENTITY_INSERT [dbo].[Fruit] ON 
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (1, 1, 'Apples')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (2, 37, 'Apricots')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (3, 6, 'Avocados')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (4, 5, 'Bananas')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (5, 5, 'Plantains')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (6, 18, 'Blueberries')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (7, 1, 'Cantaloupes')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (8, 31, 'Cherries')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (9, 1, 'Clementines')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (10, 42, 'Coconut')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (11, 18, 'Cranberries')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (12, 38, 'Dates')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (13, 31, 'Fig')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (14, 1, 'Grapefruit')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (15, 1, 'Grapes')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (16, 5, 'Guavas')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (17, 5, 'Papayas')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (18, 1, 'Honeydew')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (19, 1, 'Kiwis')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (20, 5, 'Kumquat')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (21, 5, 'Lemons')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (22, 5, 'Limes')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (23, 5, 'Mango')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (24, 39, 'Olives')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (25, 25, 'Passionfruit')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (26, 1, 'Peaches')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (27, 1, 'Pear')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (28, 43, 'Pineapples')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (29, 1, 'Plums')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (30, 30, 'Pomegranates')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (31, 40, 'Raspberries')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (32, 18, 'Strawberry')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (33, 1, 'Tomatoes')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (34, 1, 'Watermelon')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (35, 5, 'Tamarind')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (36, 44, 'Aki')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (37, 1, 'Squash')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (38, 1, 'Pumpkins')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (39, 1, 'Zucchini')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (40, 1, 'Peppers')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (41, 41, 'Dragon Fruit')
GO
INSERT [dbo].[Fruit] ([FruitId], [ProducerId], [FruitName]) VALUES (42, 1, 'Mandarin')
GO
SET IDENTITY_INSERT [dbo].[Fruit] OFF
GO

DECLARE @FruitCount AS INT = -1;
SELECT @FruitCount = COUNT(*) FROM Fruit;
PRINT(Convert(VARCHAR, @FruitCount) + ' rows inserted into Fruits');

SET IDENTITY_INSERT [dbo].[Regions] ON 
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (1, N'China')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (2, N'Kazakhstan')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (3, N'Kyrgyzstan')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (4, N'Armenia')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (5, N'India')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (6, N'Mexico')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (7, N'Indomalaya')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (8, N'Canada')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (9, N'Persia')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (10, N'Afghanistan')
GO
--------------------------------------------------------------------------------
-- AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH
--------------------------------------------------------------------------------

INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (12, N'Central Europe')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (13, N'Algeria')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (14, N'Sri Lanka')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (15, N'Maldives')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (16, N'Philippines')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (17, N'Barbados')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (18, N'US')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (19, N'Iraq')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (20, N'Barbados')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (21, N'Middle East')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (22, N'Central South America')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (23, N'Southeast Asia')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (24, N'Italy')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (25, N'Brazil')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (26, N'Paraguay')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (27, N'Argentina')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (28, N'Eastern Europe')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (29, N'Caucasus Mountains')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (30, N'Iran')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (31, N'Turkey')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (32, N'France')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (33, N'Andes Mountains')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (34, N'Ethiopia ')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (35, N'Tropical Africa')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (36, N'Meso-America')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (37, N'Uzbekistan')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (38, N'Egypt')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (39, N'Spain')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (40, N'Russia')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (41, N'Vietnam')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (42, N'Indonesia')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (43, N'Costa Rica')
GO
INSERT [dbo].[Regions] ([RegionId], [RegionName]) VALUES (44, N'Jamaica')
GO
SET IDENTITY_INSERT [dbo].[Regions] OFF
GO

DECLARE @RegionsCount AS INT = -1;
SELECT @RegionsCount = COUNT(*) FROM Regions;
PRINT(Convert(VARCHAR, @RegionsCount) + ' rows inserted into Regions');
GO

SET IDENTITY_INSERT [dbo].[Month] ON 
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (1, N'January')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (2, N'February')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (3, N'March')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (4, N'April')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (5, N'May')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (6, N'June')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (7, N'July')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (8, N'August')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (9, N'September')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (10, N'October')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (11, N'November')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (12, N'December')
GO
INSERT [dbo].[Month] ([MonthId], [Month]) VALUES (13, N'All')
GO
SET IDENTITY_INSERT [dbo].[Month] OFF
GO

DECLARE @MonthCount AS INT = -1;
SELECT @MonthCount = COUNT(*) FROM [Month];
PRINT(Convert(VARCHAR, @MonthCount) + ' rows inserted into Month');
GO

SET IDENTITY_INSERT [dbo].[Fruit_Origin] ON 
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (2, 1, 2)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (3, 1, 3)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (4, 2, 4)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (5, 2, 5)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (6, 2, 1)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (7, 3, 6)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (8, 4, 7)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (9, 5, 7)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (10, 6, 8)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (11, 7, 9)  -- 7 is Cantaloupes
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (12, 7, 10)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (13, 7, 4)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (14, 8, 12)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (15, 9, 13)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (16, 10, 14)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (17, 10, 15)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (18, 10, 16)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (19, 10, 42)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (20, 11, 8)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (21, 11, 18)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (22, 12, 19)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (23, 13, 19)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (24, 14, 20)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (25, 15, 21)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (26, 16, 6)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (27, 16, 22)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (28, 17, 6)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (29, 17, 22)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (30, 18, 13)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (31, 19, 1)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (32, 20, 23)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (33, 21, 5) -- 21 is lemons
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (34, 22, 23)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (35, 23, 23)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (36, 24, 24)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (37, 25, 25)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (38, 25, 26)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (39, 25, 27)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (40, 26, 1)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (41, 27, 1)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (42, 28, 25)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (43, 28, 26)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (44, 29, 28)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (45, 29, 29)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (46, 30, 30)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (47, 31, 31)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (48, 32, 32)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (49, 33, 33)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (50, 34, 34)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (51, 35, 35)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (52, 36, 35)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (53, 37, 36)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (54, 38, 36)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (55, 39, 36)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (56, 40, 36)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (57, 41, 36)
GO
INSERT [dbo].[Fruit_Origin] ([Fruit_OiginId], [FruitId], [RegionId]) VALUES (58, 42, 1)
GO
SET IDENTITY_INSERT [dbo].[Fruit_Origin] OFF
GO

DECLARE @Fruit_OriginCount AS INT = -1;
SELECT @Fruit_OriginCount = COUNT(*) FROM Fruit_Origin;
PRINT(Convert(VARCHAR, @Fruit_OriginCount) + ' rows inserted into Fruit_Origin');
GO

SET IDENTITY_INSERT [dbo].[Fruit_Month] ON 
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (1, 1, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (2, 1, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (3, 1, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (4, 2, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (5, 2, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (6, 2, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (7, 3, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (8, 4, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (9, 5, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (10, 6, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (11, 6, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (12, 7, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (13, 7, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (14, 7, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (15, 8, 4)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (16, 8, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (17, 8, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (18, 8, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (19, 9, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (20, 9, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (21, 9, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (22, 9, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (23, 9, 4)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (24, 10, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (25, 11, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (26, 11, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (27, 11, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (28, 12, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (29, 12, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (30, 12, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (31, 12, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (32, 13, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (33, 13, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (34, 13, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (35, 13, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (36, 14, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (37, 14, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (38, 14, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (39, 14, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (40, 14, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (41, 15, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (42, 15, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (43, 15, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (44, 16, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (45, 16, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (46, 16, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (47, 17, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (48, 18, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (49, 18, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (50, 18, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (51, 19, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (52, 20, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (53, 20, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (54, 20, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (55, 20, 4)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (56, 21, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (57, 21, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (58, 21, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (59, 21, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (60, 21, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (61, 22, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (62, 22, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (63, 22, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (64, 22, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (65, 22, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (66, 23, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (67, 23, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (68, 23, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (69, 23, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (70, 23, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (71, 24, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (72, 24, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (73, 24, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (74, 24, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (75, 25, 13)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (76, 26, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (77, 26, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (78, 26, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (79, 26, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (80, 26, 9)  -- Peaches
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (81, 27, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (82, 27, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (83, 27, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (84, 27, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (85, 27, 1) -- Pear
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (86, 28, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (87, 28, 4)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (88, 28, 5)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (89, 28, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (90, 28, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (91, 29, 5)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (92, 29, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (93, 29, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (94, 29, 8)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (95, 29, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (96, 29, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (97, 30, 12)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (98, 30, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (99, 30, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (100, 30, 10)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (101, 30, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (102, 31, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (103, 31, 7)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (104, 31, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (105, 31, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (106, 31, 10)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (107, 31, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (108, 32, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (109, 32, 4)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (110, 32, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (111, 32, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (112, 32, 7)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (113, 32, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (114, 32, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (115, 32, 10)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (116, 32, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (117, 33, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (118, 33, 6)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (119, 33, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (120, 33, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (121, 33, 9)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (123, 33, 10)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (124, 34, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (125, 34, 7)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (126, 34, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (127, 35, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (128, 35, 2)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (129, 35, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (130, 36, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (131, 36, 2)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (132, 36, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (133, 36, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (134, 36, 7)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (135, 36, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (136, 37, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (137, 37, 1)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (138, 37, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (139, 37, 6)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (140, 37, 7)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (141, 37, 8)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (142, 38, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (143, 38, 10)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (144, 38, 11)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (145, 39, 5)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (146, 39, 6)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (147, 39, 7)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (148, 39, 8)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (149, 39, 9)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (150, 40, 13)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (151, 41, 1)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (152, 41, 2)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (153, 41, 3)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (154, 41, 4)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (155, 42, 12)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (156, 42, 1)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (157, 42, 2)
GO
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (158, 42, 3)
Go
INSERT [dbo].[Fruit_Month] ([Fruit_MonthId], [FruitId], [MonthId]) VALUES (159, 42, 11)
GO
SET IDENTITY_INSERT [dbo].[Fruit_Month] OFF
GO

DECLARE @Fruit_MonthCount AS INT = -1;
SELECT @Fruit_MonthCount = COUNT(*) FROM Fruit_Month;
PRINT(Convert(VARCHAR, @Fruit_MonthCount) + ' rows inserted into Fruit_Month');
PRINT('-----------------------------' + CHAR(13)+CHAR(10))
GO

-- Fruit_Producer
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Producer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit]'))
ALTER TABLE [dbo].[Fruit]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_Producer] FOREIGN KEY([ProducerId])
REFERENCES [dbo].[Regions] ([RegionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Producer]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit]'))
ALTER TABLE [dbo].[Fruit] CHECK CONSTRAINT [FK_Fruit_Producer]
GO
PRINT('FK_Fruit_Producer Foreign Key Created')

-- Fruit_Origin
-- To Fruit ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Origin_Fruit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Origin]'))
ALTER TABLE [dbo].[Fruit_Origin]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_Origin_Fruit] FOREIGN KEY([FruitId])
REFERENCES [dbo].[Fruit] ([FruitId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Origin_Fruit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Origin]'))
ALTER TABLE [dbo].[Fruit_Origin] CHECK CONSTRAINT [FK_Fruit_Origin_Fruit]
GO
PRINT('FK_Fruit_Origin_Fruit - FruitID Foreign Key Created')

-- To Region ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Origin_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Origin]'))
ALTER TABLE [dbo].[Fruit_Origin]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_Origin_Region] FOREIGN KEY([RegionId])
REFERENCES [dbo].[Regions] ([RegionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Origin_Region]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Origin]'))
ALTER TABLE [dbo].[Fruit_Origin] CHECK CONSTRAINT [FK_Fruit_Origin_Region]
GO
PRINT('FK_Fruit_Origin_Regions - RegionId Foreign Key Created')


-- Fruit_Month
-- To Fruit ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Month_Fruit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Month]'))
ALTER TABLE [dbo].[Fruit_Month]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_Month_Fruit] FOREIGN KEY([FruitId])
REFERENCES [dbo].[Fruit] ([FruitId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Month_Fruit]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Month]'))
ALTER TABLE [dbo].[Fruit_Month] CHECK CONSTRAINT [FK_Fruit_Month_Fruit]
GO
PRINT('FK_Fruit_Month_Fruit - FruitID Foreign Key Created')


-- To Month ID
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Month_Month]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Month]'))
ALTER TABLE [dbo].[Fruit_Month]  WITH CHECK ADD  CONSTRAINT [FK_Fruit_Month_Month] FOREIGN KEY([MonthId])
REFERENCES [dbo].[Month] ([MonthId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Fruit_Month_Month]') AND parent_object_id = OBJECT_ID(N'[dbo].[Fruit_Month]'))
ALTER TABLE [dbo].[Fruit_Month] CHECK CONSTRAINT [FK_Fruit_Month_Month]
GO
PRINT('FK_Fruit_Month_Month - MonthId Foreign Key Created')


USE [master]
GO
ALTER DATABASE [DbpTermProject2022] SET READ_WRITE 
GO
