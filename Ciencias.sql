use CocoBoLoBooks

CREATE TABLE Ciencias(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)
select * from Ciencias

Insert Ciencias(Name,Description) values ('Historia', 'Ciencia de Historia')

