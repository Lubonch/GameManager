USE [GameManager]
GO
/****** Object:  Table [dbo].[LoginTable]    Script Date: 10/10/2025 4:38:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LoginTable] ON 

INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (1, N'hola', N'hola')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (2, N'admin', N'admin')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (3, N'adminnebook', N'adminnetbook')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (4, N'a', N'a')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (5, N'pp3', N'pp3')
SET IDENTITY_INSERT [dbo].[LoginTable] OFF
GO
