CREATE database CocoBoLoBooks;

use  CocoBoLoBooks;

------------------------------------TABLA
CREATE TABLE Editoras(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)
------------------------------------TABLA
CREATE TABLE Autores(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1,
	paisOrigen varchar(50),
	IdiomaNativo varchar(50) 
)
CREATE TABLE Ciencias(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)
CREATE TABLE Idiomas(
	[Id] int primary key IDENTITY NOT NULL,
	[Name] nvarchar(25) NOT NULL,
	[Description] nvarchar(75) NOT NULL,
	Estado bit default 1
)

CREATE TABLE USUARIOS (
Id int primary key identity,
Nombre varchar (100) not null,
Apellido varchar (100) not null,
Correo varchar (100) not null,
Clave varchar (150) not null,
TipoUsuario int not null,
Cedula varchar (11) unique  not null,
NCarnet int unique not null,
TipoPersona int not null,
Estado bit default 1 not null,
FechaRegistro date default getdate()not null
)
INSERT INTO USUARIOS (Nombre, Apellido, Correo, Clave, TipoUsuario, Cedula, NCarnet, TipoPersona, Estado)
VALUES('Maycol', 'Perez', 'maycolx@gmail.com',
'b221d9dbb083a7f33428d7c2a3c3198ae925614d70210e28716ccaa7cd4ddb79', 2, 4444, 12, 1, 1)

select * from USUARIOS;
CREATE TABLE Empleados (
Id int primary key identity,
Nombre varchar (100) not null,
Cedula varchar (11) unique not null,
TandaLabor varchar (100) not null,
PorcientoComision varchar (150) not null,
FechaIngreso nvarchar (50),
Estado bit default 1 not null,
)
------------------------------------TABLA
CREATE TABLE Libros(
	Id int primary key IDENTITY NOT NULL,
	[SignaturaTopografica] nvarchar(75) NOT NULL,
	[Nombre] VARCHAR(500) NOT NULL,
	[ISBN] decimal NOT NULL,
	[Descripcion] nvarchar(500) NOT NULL,
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


------------------------------------views
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

---STORED PROCEDURES

create proc sp_ValidarUsuario(
@Correo varchar(100),
@Clave varchar(500)
)
as
begin
    if(exists(select * from USUARIOS where Correo = @Correo and Clave = @Clave))
    	select Id from USUARIOS where Correo = @Correo and Clave = @Clave
    else
        select '0'
end

--sp registrar para el register

create proc sp_RegistrarUsuario(
@Nombre varchar(100),
@Apellido varchar(100),
@Correo varchar(100),
@Clave varchar(500),
@Cedula varchar(11),
@NCarnet int,
@Registrado bit output,
@Mensaje varchar(100) output
)
as
begin
    if(not exists(select * from USUARIOS where Correo = @Correo))
    begin
    	insert into USUARIOS(Nombre, Apellido, Correo, Clave, TipoUsuario, Cedula, NCarnet, TipoPersona, Estado) values(@Nombre, @Apellido, @Correo, @Clave, 1, @Cedula, @NCarnet, 1, 1)
        set @Registrado = 1
	set @Mensaje = 'Usuario registrado correctamente.'
    end
    else
    begin
	set @Registrado = 0
	set @Mensaje = 'Usuario ya registrado, Intente de nuevo.'
    end
end
    

---COMANDOS DE TESTEOS, NO SON NECESARIOS EJECUTAR, CUIDADO

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



