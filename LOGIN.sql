use CocoBoLoBooks;

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
    





    