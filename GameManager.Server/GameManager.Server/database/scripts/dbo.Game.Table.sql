USE [GameManager]
GO
/****** Object:  Table [dbo].[Game]    Script Date: 10/10/2025 4:38:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Game](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Year] [datetime] NOT NULL,
	[IdPublisher] [int] NOT NULL,
	[IdConsole] [int] NOT NULL,
	[IdGenre] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Juego] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Game] ON 

INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (2, N'GTA 6', CAST(N'2030-11-28T14:25:56.000' AS DateTime), 8, 2, 2, 1, 10000)
INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (3, N'sadsad', CAST(N'2021-11-03T14:30:00.000' AS DateTime), 7, 2, 1, 1, 2323)
INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (4, N'NetookJuego', CAST(N'2021-11-28T10:49:54.580' AS DateTime), 11, 4, 5, 10, 10)
INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (5, N'testmaterial', CAST(N'2021-11-28T17:21:46.643' AS DateTime), 12, 5, 6, 11, 1)
INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (6, N'amodif', CAST(N'2021-12-31T10:51:48.000' AS DateTime), 4, 6, 7, 12, 2)
INSERT [dbo].[Game] ([Id], [Name], [Year], [IdPublisher], [IdConsole], [IdGenre], [Quantity], [Price]) VALUES (7, N'pp3juego', CAST(N'2021-12-02T13:48:41.000' AS DateTime), 14, 7, 8, 150, 60)
SET IDENTITY_INSERT [dbo].[Game] OFF
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK__Juego__IdConsole__49C3F6B7] FOREIGN KEY([IdConsole])
REFERENCES [dbo].[Console] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK__Juego__IdConsole__49C3F6B7]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK__Juego__IdGenre__4AB81AF0] FOREIGN KEY([IdGenre])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK__Juego__IdGenre__4AB81AF0]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [FK__Juego__IdPublish__4BAC3F29] FOREIGN KEY([IdPublisher])
REFERENCES [dbo].[Publisher] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [FK__Juego__IdPublish__4BAC3F29]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [Juego_IdConsole_FK] FOREIGN KEY([IdConsole])
REFERENCES [dbo].[Console] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [Juego_IdConsole_FK]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [Juego_IdGenre_FK] FOREIGN KEY([IdGenre])
REFERENCES [dbo].[Genre] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [Juego_IdGenre_FK]
GO
ALTER TABLE [dbo].[Game]  WITH CHECK ADD  CONSTRAINT [Juego_IdPublisher_FK] FOREIGN KEY([IdPublisher])
REFERENCES [dbo].[Publisher] ([Id])
GO
ALTER TABLE [dbo].[Game] CHECK CONSTRAINT [Juego_IdPublisher_FK]
GO
