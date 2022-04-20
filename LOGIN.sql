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
    