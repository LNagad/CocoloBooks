use CocoBoLoBooks;

select * from Bibliografias

alter table Bibliografias
ADD Estado bit default 1;

create proc sp_registrarBiibliografia
(
@Name varchar(100),
@Description varchar(100),
@Estado bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as 
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM Bibliografias WHERE Description = @Description)
		begin
			INSERT INTO Bibliografias (Name, Description,Estado) VALUES
			(@Name, @Description, @Estado) 

			--esto lo que hace es que inmediatamente se inserte se guarde el id del usuario en resultado
			SET @Resultado = SCOPE_IDENTITY() 
		end
	else
		SET @Mensaje = 'Esta bibliografia ya existe'	
end


create proc sp_editarBibliografia
(
@IdBibliografia int,
@Name varchar(100),
@Description varchar(100),
@Estado bit,
@Mensaje varchar(500) output,
@Resultado int output
)
as 
begin
	SET @Resultado = 0
	begin
		UPDATE top (1) Bibliografias SET --update al primer usuario que encuentre con ese Id
		Name = @Name,
		Description = @Description,
		Estado = @Estado
		WHERE Id = @IdBibliografia

		set @Resultado = 1
		set @Mensaje = 'Bibliografia actualizada'
	end
end


create proc sp_eliminarBibliografia (
@IdBibliografia int,
@Mensaje varchar(500) output,
@Resultado int output
)
as 
begin
	SET @Resultado = 0
	IF NOT EXISTS (SELECT * FROM LIBROS T1
	INNER JOIN Bibliografias T2 ON T1.BibliografiaId = T2.Id) 
	begin
		DELETE TOP (1) FROM Bibliografias WHERE Id = @IdBibliografia
		SET @Resultado = 1
	end
	else
	SET @Mensaje = 'La bibliiografia se encuentra relacionada a un libro'
end