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
	[ISBN] decimal NOT NULL,
	[Descripcion] nvarchar(75) NOT NULL,
	[AutorId] int references Autores(Id) NOT NULL,
	[BibliografiaId] int references Bibliografias(Id) NOT NULL,
	[CienciaId] int references Ciencias(Id) NOT NULL,
	[EditoraId] int references Editoras(Id) NOT NULL,
	[IdiomaId] int references Idiomas(Id) NOT NULL,
	RutaImagen nvarchar(100),
	NombreImagen nvarchar (100),
	[year] nvarchar (75) NOT NULL,
	[Estado] int default 1 NOT NULL,
)
Use CocoBoLoBooks;
drop table Libros;

alter table libros add 
RutaImagen nvarchar(100),
NombreImagen nvarchar (100);

select * from Libros;
------------------------------------TABLA
CREATE VIEW vw_libros
AS
	SELECT t1.Id, t1.SignaturaTopografica, t1.Nombre, t1.ISBN, t1.Descripcion, t1.BibliografiaId, t2.Name as Bibliografia, 
		t1.CienciaId,t7.Name as Ciencia, t1.AutorId, t3.Name as Autor , t1.EditoraId, t4.Name as Editora, 
		t1.IdiomaId, t5.Name as Idioma, t1.year ,t1.Estado, t1.RutaImagen, t1.NombreImagen 
	FROM Libros t1 
		INNER JOIN Bibliografias t2 ON (t1.BibliografiaId = t2.Id)
		INNER JOIN Ciencias t7 ON (t1.CienciaId = t7.Id)
		INNER JOIN Autores t3 ON (t1.AutorId = t3.Id)
		INNER JOIN Editoras t4 ON (t1.EditoraId = t4.Id)
		INNER JOIN Idiomas t5 ON (t1.IdiomaId = t5.Id);

select * from vw_libros;


INSERT INTO Libros 
VALUES --tirara error en la fecha porque es datetime
('99E', 'Skratch', 123113, 'Un libro para todos', 2, 5, 1, 1, 4, 1, '2022-02-01');

INSERT INTO Libros ( SignaturaTopografica, Nombre, ISBN, Descripcion, AutorId , 
BibliografiaId, CienciaId, EditoraId, IdiomaId, year,Estado)
VALUES ('99E', 'pampi', 123113, 'Un libro para todos', 2, 5, 1, 1, 4, '2022-02-01',1)
SELECT Idx=SCOPE_IDENTITY();

sp_help libros;

truncate table libros;

select * from libros;



