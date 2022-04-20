use CocoBoLoBooks;

SELECT * FROM sys.tables; --Para mirar las tablas creadas

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

drop table USUARIOS;

select Id, Nombre, Apellido, Correo, Clave,TipoUsuario, Cedula, NCarnet, TipoPersona, Estado, FechaRegistro  from USUARIOS;

use CocoBoLoBooks

insert into USUARIOS (Nombre, Apellido, Correo, Clave,TipoUsuario, Cedula, NCarnet, TipoPersona, Estado) 
values ('MaycolTest', 'Perez', 'hola@gmail.com', 'test123', 2, '40135479674', 123, 1, 1)

