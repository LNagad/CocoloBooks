CREATE database CocoBoLoBooks;

use  CocoBoLoBooks;

------------------------------------TABLA
CREATE TABLE Editoras(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)

select * from Editoras;


UPDATE Editoras SET Name = 'asdasd' where id = 1

Insert Editoras(Name,Description) values ('SRL MUSIC', 'UNA VAINA DE STDG')

select Id, Name, Description, Estado from Editoras

------------------------------------TABLA
CREATE TABLE Autores(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)

insert into Autores(Name,Description) values('Deivi', 'Back to back')

------------------------------------TABLA
CREATE TABLE Libros(
	Id int primary key IDENTITY NOT NULL,
	[SignaturaTopografica] nvarchar(75) NOT NULL,
	[Nombre] nvarchar(75) NOT NULL,
	[ISB] decimal NOT NULL,
	[BibliografiaId] int references Bibliografias(Id) NOT NULL,
	[Autores] nvarchar(75) NOT NULL,
	[Descripcion] nvarchar(75) NOT NULL,
	[Ciencia] nvarchar(75) NOT NULL,
	[Editora] nvarchar(75) NOT NULL,
	[Estado] int default 1 NOT NULL,
	[Idioma] nvarchar(75) NOT NULL,
	[year] date NOT NULL
)

------------------------------------TABLA
create view vw_libros
as
select t1.Id, t1.SignaturaTopografica, t1.Nombre, t1.ISB, t1.BibliografiaId, t2.Name as Bibliografia, t1.Autores, t1.Descripcion,t1.Ciencia,t1.Editora
,t1.Estado, t1.Idioma, t1.year
from Libros t1 INNER JOIN Bibliografias t2 ON (t1.BibliografiaId = t2.Id)







select * from vw_libros;

INSERT INTO Bibliografias(Name,Description)
VALUES ('Paulo Cojelo', 'Paulo pero cogelo')

select * from Libros;










alter table Libros drop column year

alter table libros add year datetime

INSERT INTO Libros  (SignaturaTopografica, Nombre, ISB, BibliografiaId, Autores, Descripcion, Ciencia, Editora, Estado,Idioma, year)
VALUES 
('99', 'Penelowao', 21, 1, 'Paulo x', 'Un libro para todos', 'Ficcion', 'SRL venezuela', 1, 'spanish', '2022');




