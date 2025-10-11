USE [GameManager]
GO
/****** Object:  Table [dbo].[Console]    Script Date: 10/10/2025 4:38:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Console](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Consola] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Console] ON 

INSERT [dbo].[Console] ([Id], [Name]) VALUES (1, N'Xbox One')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (2, N'Playstation 4')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (4, N'netbookConsola')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (5, N'Material test')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (6, N'a')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (7, N'pp3')
SET IDENTITY_INSERT [dbo].[Console] OFF
GO
