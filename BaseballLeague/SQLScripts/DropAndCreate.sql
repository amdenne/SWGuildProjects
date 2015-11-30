USE [master]
GO

/****** Object:  Database [BaseballLeague]    Script Date: 11/9/2015 10:58:48 AM ******/
DROP DATABASE [BaseballLeague]
GO

/****** Object:  Database [BaseballLeague]    Script Date: 11/9/2015 10:58:48 AM ******/
CREATE DATABASE [BaseballLeague]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BaseballLeague', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BaseballLeague.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BaseballLeague_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BaseballLeague_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [BaseballLeague] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BaseballLeague].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BaseballLeague] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BaseballLeague] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BaseballLeague] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BaseballLeague] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BaseballLeague] SET ARITHABORT OFF 
GO

ALTER DATABASE [BaseballLeague] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BaseballLeague] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BaseballLeague] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BaseballLeague] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BaseballLeague] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BaseballLeague] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BaseballLeague] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BaseballLeague] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BaseballLeague] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BaseballLeague] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BaseballLeague] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BaseballLeague] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BaseballLeague] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BaseballLeague] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BaseballLeague] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BaseballLeague] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BaseballLeague] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BaseballLeague] SET  MULTI_USER 
GO

ALTER DATABASE [BaseballLeague] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BaseballLeague] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BaseballLeague] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BaseballLeague] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [BaseballLeague] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BaseballLeague] SET  READ_WRITE 
GO

USE [BaseballLeague]
GO

/****** Object:  Table [dbo].[Team]    Script Date: 11/9/2015 10:57:58 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

USE [BaseballLeague]
GO

/****** Object:  Table [dbo].[League]    Script Date: 11/9/2015 10:59:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[League](
	[LeagueID] [tinyint] IDENTITY(1,1) NOT NULL,
	[LeagueName] [varchar](50) NULL,
 CONSTRAINT [PK_League] PRIMARY KEY CLUSTERED 
(
	[LeagueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[Team](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[LeagueID] [tinyint] NOT NULL,
	[TeamName] [varchar](50) NOT NULL,
	[Manager] [varchar](50) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_League] FOREIGN KEY([LeagueID])
REFERENCES [dbo].[League] ([LeagueID])
GO

ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_League]
GO

USE [BaseballLeague]
GO

ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_Player_Team]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 11/9/2015 10:59:27 AM ******/
DROP TABLE [dbo].[Player]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 11/9/2015 10:59:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Player](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[PlayerName] [varchar](50) NULL,
	[JerseyNumber] [tinyint] NULL,
	[Position] [varchar](25) NULL,
	[BattingAverage] [decimal](3, 0) NULL,
	[YearsPlayed] [tinyint] NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Player]  WITH CHECK ADD  CONSTRAINT [FK_Player_Team] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Team] ([TeamID])
GO

ALTER TABLE [dbo].[Player] CHECK CONSTRAINT [FK_Player_Team]
GO



