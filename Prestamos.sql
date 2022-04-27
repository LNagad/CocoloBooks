use CocoBoLoBooks


use CocoBoLoBooks;

CREATE TABLE RentasLibros (
	IdRenta int primary key identity,
	IdLibro int references LIBROS(Id) NOT NULL,
	IdUsuario int references USUARIOS(Id) NOT NULL,
	FechaEntrega date NOT NULL,
	ComisionEntregaTardia int NOT NULL,
	FechaRenta date default getdate(),
	Estado bit default 1 NOT NULL
);

create proc sp_registrarRenta
(
	@IdLibro int,
	@IdUsuario int,
	@FechaEntrega date,
	@ComisionEntregaTardia int,
	@Estado bit,
	@Mensaje nvarchar (500)output
)
as 
begin
	IF NOT EXISTS (SELECT * FROM RentasLibros WHERE IdLibro = @IdLibro)
		begin
			INSERT INTO RentasLibros (IdLibro, IdUsuario, FechaEntrega, ComisionEntregaTardia, Estado) 
			VALUES (@IdLibro, @IdUsuario, @FechaEntrega, @ComisionEntregaTardia, @Estado);
	
			--Cuando se registra un prestamo se desactiva el libro de manera que indica
			--que esta prestado o no esta en disponibilidad por el momento, una vez que se 
			--devuelva, este volvera a activar su estado
			UPDATE Libros set Estado = 0 
			WHERE Id = @IdLibro;

			SET @Mensaje = 'Renta registrada con exito'
		end
	else
		SET @Mensaje = 'Este libro ya se encuentra rentado'	
end

truncate table RentasLibros;
UPDATE Libros set estado = 1;


exec sp_registrarRenta @IdLibro = 2, @IdUsuario = 10, @FechaEntrega = '2022-04-30', 
@ComisionEntregaTardia = 50, @Estado = 1, @Mensaje = ''


create proc sp_ActualizarRenta
(
	@IdRenta int,
	@IdLibro int
)
as 
begin
	IF EXISTS (SELECT * FROM RentasLibros WHERE IdRenta = @IdRenta)
		begin
			SET @IdLibro = (SELECT IdLibro from RentasLibros Where IdRenta = @IdRenta);
			
			Delete RentasLibros 
			WHERE IdRenta = @IdRenta;

			UPDATE Libros set Estado = 1 
			WHERE Id = @IdLibro;
		end
end

drop proc sp_ActualizarRenta;


select * from Libros where estado = 1;
select * from USUARIOS where TipoUsuario = 1;

drop view Rentas_view;
select * from vw_rentas;

CREATE VIEW vw_rentas
	as
		SELECT t1.IdRenta, t1.IdLibro, t2.Nombre as LibroNombre, t1.IdUsuario, t3.Nombre +' '+ t3.Apellido 
		as UsuarioNombre, t1.FechaEntrega, t1.ComisionEntregaTardia, t1.FechaRenta, t1.Estado 
		FROM RentasLibros t1
		INNER JOIN Libros t2 ON (t1.IdLibro = t2.Id)
		INNER JOIN USUARIOS t3 ON (t1.IdUsuario = t3.Id);
