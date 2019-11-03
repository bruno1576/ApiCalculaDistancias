create database DbDistancia
go
USE [DbDistancia]
GO
/****** Object:  Table [dbo].[Amigos]    Script Date: 03/11/2019 19:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amigos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
 CONSTRAINT [PK_Amigos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DistanciaAmigos]    Script Date: 03/11/2019 19:11:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DistanciaAmigos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[X] [real] NOT NULL,
	[Y] [real] NOT NULL,
	[AmigoId] [int] NOT NULL,
 CONSTRAINT [PK_DistanciaAmigos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DistanciaAmigos]  WITH CHECK ADD  CONSTRAINT [FK_DistanciaAmigos_Amigos_AmigoId] FOREIGN KEY([AmigoId])
REFERENCES [dbo].[Amigos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DistanciaAmigos] CHECK CONSTRAINT [FK_DistanciaAmigos_Amigos_AmigoId]
GO
