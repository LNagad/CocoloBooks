use CocoBoLoBooks

CREATE TABLE Idiomas(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)
select * from Idiomas

Insert Idiomas(Name,Description) values ('Alan', 'Yoel')

