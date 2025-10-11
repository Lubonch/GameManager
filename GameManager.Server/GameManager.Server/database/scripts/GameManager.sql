USE [master]
GO
/****** Object:  Database [GameManager]    Script Date: 7/29/2023 12:41:50 PM ******/
CREATE DATABASE [GameManager]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CrudWindowsForm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\GameManager.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CrudWindowsForm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\GameManager_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [GameManager] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GameManager].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GameManager] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [GameManager] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [GameManager] SET ARITHABORT OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [GameManager] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [GameManager] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [GameManager] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [GameManager] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [GameManager] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [GameManager] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [GameManager] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [GameManager] SET  DISABLE_BROKER 
GO
ALTER DATABASE [GameManager] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [GameManager] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [GameManager] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [GameManager] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [GameManager] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [GameManager] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [GameManager] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [GameManager] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [GameManager] SET  MULTI_USER 
GO
ALTER DATABASE [GameManager] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [GameManager] SET DB_CHAINING OFF 
GO
ALTER DATABASE [GameManager] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [GameManager] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [GameManager] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [GameManager] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'GameManager', N'ON'
GO
ALTER DATABASE [GameManager] SET QUERY_STORE = OFF
GO
USE [GameManager]
GO
/****** Object:  Table [dbo].[Console]    Script Date: 7/29/2023 12:41:50 PM ******/
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
/****** Object:  Table [dbo].[Game]    Script Date: 7/29/2023 12:41:50 PM ******/
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
/****** Object:  Table [dbo].[Genre]    Script Date: 7/29/2023 12:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Genero] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginTable]    Script Date: 7/29/2023 12:41:50 PM ******/
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
/****** Object:  Table [dbo].[People]    Script Date: 7/29/2023 12:41:50 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[age] [int] NOT NULL,
 CONSTRAINT [PK_people] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 7/29/2023 12:41:50 PM ******/
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
SET IDENTITY_INSERT [dbo].[Console] ON 

INSERT [dbo].[Console] ([Id], [Name]) VALUES (1, N'Xbox One')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (2, N'Playstation 4')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (4, N'netbookConsola')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (5, N'Material test')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (6, N'a')
INSERT [dbo].[Console] ([Id], [Name]) VALUES (7, N'pp3')
SET IDENTITY_INSERT [dbo].[Console] OFF
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
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([Id], [Name]) VALUES (1, N'RPG')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (2, N'Mundo Abierto')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (4, N'Aventura')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (5, N'NetbookGenero')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (6, N'material test')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (7, N'a')
INSERT [dbo].[Genre] ([Id], [Name]) VALUES (8, N'pp3')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[LoginTable] ON 

INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (1, N'hola', N'hola')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (2, N'admin', N'admin')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (3, N'adminnebook', N'adminnetbook')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (4, N'a', N'a')
INSERT [dbo].[LoginTable] ([Id], [username], [password]) VALUES (5, N'pp3', N'pp3')
SET IDENTITY_INSERT [dbo].[LoginTable] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

INSERT [dbo].[People] ([id], [name], [age]) VALUES (4, N'saSA', 0)
SET IDENTITY_INSERT [dbo].[People] OFF
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
USE [master]
GO
ALTER DATABASE [GameManager] SET  READ_WRITE 
GO
