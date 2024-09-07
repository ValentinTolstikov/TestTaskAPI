USE [TestDB]
GO
/****** Object:  Table [dbo].[Doctors]    Script Date: 07.09.2024 19:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctors](
	[IdDoctor] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Patronumic] [nvarchar](max) NOT NULL,
	[IdSpec] [int] NOT NULL,
	[IdSection] [int] NULL,
 CONSTRAINT [PK_Doctors] PRIMARY KEY CLUSTERED 
(
	[IdDoctor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 07.09.2024 19:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patients](
	[IdPatient] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Surname] [nvarchar](max) NOT NULL,
	[Patronumic] [nvarchar](max) NOT NULL,
	[Adres] [nvarchar](max) NOT NULL,
	[DateBorn] [date] NOT NULL,
	[Pol] [nchar](1) NOT NULL,
	[IdSection] [int] NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[IdPatient] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sections]    Script Date: 07.09.2024 19:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sections](
	[IdSection] [int] IDENTITY(1,1) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED 
(
	[IdSection] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Specializations]    Script Date: 07.09.2024 19:07:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specializations](
	[IdSpecification] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Specializations] PRIMARY KEY CLUSTERED 
(
	[IdSpecification] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doctors] ON 

INSERT [dbo].[Doctors] ([IdDoctor], [Name], [Surname], [Patronumic], [IdSpec], [IdSection]) VALUES (1, N'Анатолий', N'Сидоров', N'Иванович', 1, 1)
SET IDENTITY_INSERT [dbo].[Doctors] OFF
GO
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([IdPatient], [Name], [Surname], [Patronumic], [Adres], [DateBorn], [Pol], [IdSection]) VALUES (1, N'testPut', N'test', N'test', N'test 1123', CAST(N'2000-01-01' AS Date), N'м', 1)
INSERT [dbo].[Patients] ([IdPatient], [Name], [Surname], [Patronumic], [Adres], [DateBorn], [Pol], [IdSection]) VALUES (2, N'Иван', N'Петров', N'Петрович', N'ул. Вторая 2', CAST(N'2001-11-11' AS Date), N'м', 2)
INSERT [dbo].[Patients] ([IdPatient], [Name], [Surname], [Patronumic], [Adres], [DateBorn], [Pol], [IdSection]) VALUES (1002, N'Анатолий', N'Бенедиктов', N'Иванович', N'ул. Третья 3', CAST(N'2000-11-11' AS Date), N'м', 1)
INSERT [dbo].[Patients] ([IdPatient], [Name], [Surname], [Patronumic], [Adres], [DateBorn], [Pol], [IdSection]) VALUES (1003, N'test', N'test', N'test', N'test 123', CAST(N'2000-01-01' AS Date), N'м', 1)
SET IDENTITY_INSERT [dbo].[Patients] OFF
GO
SET IDENTITY_INSERT [dbo].[Sections] ON 

INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (1, 1)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (2, 2)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (3, 3)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (4, 4)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (5, 5)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (6, 6)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (7, 7)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (8, 8)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (9, 9)
INSERT [dbo].[Sections] ([IdSection], [Number]) VALUES (10, 10)
SET IDENTITY_INSERT [dbo].[Sections] OFF
GO
SET IDENTITY_INSERT [dbo].[Specializations] ON 

INSERT [dbo].[Specializations] ([IdSpecification], [Name]) VALUES (1, N'Кардиолог')
INSERT [dbo].[Specializations] ([IdSpecification], [Name]) VALUES (2, N'Генетик')
INSERT [dbo].[Specializations] ([IdSpecification], [Name]) VALUES (3, N'Педиатр')
SET IDENTITY_INSERT [dbo].[Specializations] OFF
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Sections] FOREIGN KEY([IdSection])
REFERENCES [dbo].[Sections] ([IdSection])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Sections]
GO
ALTER TABLE [dbo].[Doctors]  WITH CHECK ADD  CONSTRAINT [FK_Doctors_Specializations] FOREIGN KEY([IdSpec])
REFERENCES [dbo].[Specializations] ([IdSpecification])
GO
ALTER TABLE [dbo].[Doctors] CHECK CONSTRAINT [FK_Doctors_Specializations]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Sections] FOREIGN KEY([IdSection])
REFERENCES [dbo].[Sections] ([IdSection])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Sections]
GO
