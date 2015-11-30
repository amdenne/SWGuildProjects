USE [BaseballLeague]
GO

ALTER TABLE [dbo].[Player] DROP CONSTRAINT [FK_Player_Team]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 11/13/2015 10:49:59 AM ******/
DROP TABLE [dbo].[Player]
GO

/****** Object:  Table [dbo].[Player]    Script Date: 11/13/2015 10:49:59 AM ******/
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
	[BattingAverage] [decimal](6, 3) NULL,
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


