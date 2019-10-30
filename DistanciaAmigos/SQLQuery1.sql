create database DbNovo;
GO
use DbNovo;
Create table Amigo
 
(
    Id int IDENTITY(1,1) primary key,
    Nome nvarchar(max)NULL,
	X real,
	Y real
);
 