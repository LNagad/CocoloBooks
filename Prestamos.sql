use CocoBoLoBooks


select;

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

exec sp_registrarRenta @IdLibro = 2, @IdUsuario = 10, @FechaEntrega = '2022-04-30', 
@ComisionEntregaTardia = 50, @Estado = 1, @Mensaje = ''

select * from Libros where estado = 1;
select * from USUARIOS where TipoUsuario = 1;
select * from RentasLibros


drop proc sp_registrarRenta;
