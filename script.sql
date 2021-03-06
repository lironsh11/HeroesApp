USE [HeroesAppDb]
GO
/****** Object:  Table [dbo].[Heroes]    Script Date: 21-Mar-21 4:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Heroes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Abilty] [nvarchar](50) NULL,
	[GuideID] [int] NULL,
	[StartDate] [date] NULL,
	[SuiteColors] [nvarchar](50) NULL,
	[StartingPower] [decimal](18, 0) NULL,
	[CurrentPower] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Heroes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Trainers]    Script Date: 21-Mar-21 4:35:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Trainers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Trainers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Heroes] ON 

INSERT [dbo].[Heroes] ([ID], [Name], [Abilty], [GuideID], [StartDate], [SuiteColors], [StartingPower], [CurrentPower]) VALUES (1, N'Pikachu', N'Thunder', 134435, CAST(N'2021-03-20' AS Date), N'Yellow', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Heroes] ([ID], [Name], [Abilty], [GuideID], [StartDate], [SuiteColors], [StartingPower], [CurrentPower]) VALUES (2, N'Charmander', N'Fire', 13235, CAST(N'2021-03-21' AS Date), N'Red', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
INSERT [dbo].[Heroes] ([ID], [Name], [Abilty], [GuideID], [StartDate], [SuiteColors], [StartingPower], [CurrentPower]) VALUES (3, N'Squirtel', N'Water', 341345, CAST(N'2021-03-21' AS Date), N'string', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Heroes] OFF
SET IDENTITY_INSERT [dbo].[Trainers] ON 

INSERT [dbo].[Trainers] ([ID], [UserName], [Password]) VALUES (5, N'Liron', N'1Ll23da@34')
INSERT [dbo].[Trainers] ([ID], [UserName], [Password]) VALUES (6, N'Roni', N'134Ll2r@34')
INSERT [dbo].[Trainers] ([ID], [UserName], [Password]) VALUES (7, N'Chaim', N'134Ll2r@34')
SET IDENTITY_INSERT [dbo].[Trainers] OFF
