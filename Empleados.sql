use CocoBoLoBooks

CREATE TABLE Empleados (
Id int primary key identity,
Nombre varchar (100) not null,
Cedula varchar (11) unique not null,
TandaLabor varchar (100) not null,
PorcientoComision varchar (150) not null,
FechaIngreso nvarchar (50),
Estado bit default 1 not null,
)
drop table Empleados
select *from Empleados
sp_help libros;