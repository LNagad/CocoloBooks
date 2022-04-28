jQuery.ajax({
    url: '/Libros/ListarLibroSeleccionado', /*@Url.Action("ListarLibroSeleccionado", "Libros")*/
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        console.log(data)
        $("#isbn").append(data.data[0]["ISBN"])
        $("#titulo").append(data.data[0]["Nombre"])
        $("#descripcion").append(data.data[0]["Descripcion"])
        if (data.data[0]["NombreImagen"].length > 0) {
            $("#imgLibro").attr({"src": `../FOTOS_LIBROS/${data.data[0]["NombreImagen"]} `})
        }

        console.log(data)
    },
    error: {

    }
});
