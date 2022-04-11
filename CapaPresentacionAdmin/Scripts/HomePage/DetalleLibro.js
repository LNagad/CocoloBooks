jQuery.ajax({
    url: '/Libros/ListarLibroSeleccionado', /*@Url.Action("ListarLibroSeleccionado", "Libros")*/
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {

        $("#isbn").append(data.data[0]["ISB"])
        $("#titulo").append(data.data[0]["Nombre"])
        $("#descripcion").append(data.data[0]["Descripcion"])

        console.log(data)
    },
    error: {

    }
});
