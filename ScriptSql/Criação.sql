create database DbDistancia
go
USE [DbDistancia]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Amigos(
	[Id] [int] primary key IDENTITY(1,1) NOT NULL ,
	[Nome] [nvarchar](max) NULL,
	)
CREATE TABLE DistanciaAmigos(
	[Id] [int] primary key IDENTITY(1,1) NOT NULL,
	[X] [real] NOT NULL,
	[Y] [real] NOT NULL,
	AmigoId int foreign key references Amigos
	)