create database DbDistancia;
GO
use DbDistancia;
Create table Amigo
 
(
    Id int IDENTITY(1,1) primary key,
    Nome nvarchar(max)NULL,
	X real,
	Y real
);
 