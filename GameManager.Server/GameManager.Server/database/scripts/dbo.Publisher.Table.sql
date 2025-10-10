USE [GameManager]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 10/10/2025 4:38:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Publisher] ON 

INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (3, N'Ubisoft')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (4, N'Xbox')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (5, N'Nintendo')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (6, N'Namco')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (7, N'Bethesda')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (8, N'Rockstar Games')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (9, N'Sega')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (10, N'Sony Interactive Entertainment')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (11, N'NetbookPublisher')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (12, N'Material test')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (13, N'a')
INSERT [dbo].[Publisher] ([Id], [Name]) VALUES (14, N'pp3')
SET IDENTITY_INSERT [dbo].[Publisher] OFF
GO
