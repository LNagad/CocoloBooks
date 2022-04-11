﻿
var tablaData;

var filaSeleccionada;

//@* jQuery.ajax({
//    url: '/Home/ListarUsuarios', /*@Url.Action("ListarUsuarios", "Home")*/
//    type: "GET",
//    dataType: "json",
//    contentType: "application/json; charset=utf-8",
//    success: function (data) {
//        /*        debugger; // para detener*/
        
//        console.log(data)
//    }
//}) *@

tablaData = $("#tablaLibros").DataTable
    ({
        responsive: true,
        ordering: false,
        "ajax": {
            url: '/Libros/ListarLibros', /*@Url.Action("ListarLibros", "Libros")*/
            type: "GET",
            dataType: "json",
        },
        "columns":
            [
                { "data": "Nombre" },
                { "data": "Bibliografia" },
                { "data": "Autores" },
                { "data": "Ciencia" },
                { "data": "Editora" },
                { "data": "Idioma" },
                {
                    "data": "Estado", "render": function (valor) {
                        if (valor) {
                            return '<span class="badge bg-success">Si</span>'
                        } else {
                            return '<span class="badge bg-danger">No</span>'
                        }
                    }
                },
                {
                    "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-editar" ><i class="fas fa-pen me-1"></i></button>' +
                        '<button type="button" class="btn btn-danger ms-2 btn-sm btn-eliminar"><i class="fas fa-trash me-1"></i></button>' +
                        '<button type="button" class="btn btn-warning ms-2 btn-sm btn-info" > <i class= fas fa-info me-1" style="weight: bold;"></i> </button>',

                    "orderable": false,
                    "searchable": false,
                    "width": "120px",
                    "size": "20px"
                }
            ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }

    });

///bibliografias
jQuery.ajax({
    url: '/Mantenimiento/ListarBibliografias', /*@Url.Action("ListarBibliografias", "Mantenimiento")*/
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {

        $("<option>").attr({ "value": "0", "disabled": "true" }).text("Seleccionar").appendTo("#cbxBibliografia");

        $.each(data.data, function (index, value) {

            console.log(value)

            $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxBibliografia");

        })

        console.log(data)
    },
    error: {

    }
});

///Autores
jQuery.ajax({
    url: '/Mantenimiento/ListarAutores', /*@Url.Action("ListarAutores", "Mantenimiento")*/
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {

        $("<option>").attr({ "value": "0", "disabled": "true" }).text("Seleccionar").appendTo("#cbxAutores");

        $.each(data.data, function (index, value) {
            console.log(value)

            $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxAutores");

        })

        console.log(data)
    },
    error: {

    }
});


function abrirModal(json) {

    console.log(json)

    if (json != null) {
        $("#mensajeError").hide()
        $("#txtId").val(json.Id)
        $("#txtSignaturaTopografica").val(json.SignaturaTopografica)
        $("#txtNombre").val(json.Nombre)
        $("#txtDesc").val(json.Descripcion)
        $("#txtISB").val(json.ISB)
        $("#txtBibliografiaId").val(json.BibliografiaId)

        /*$("#cbxBibliografia").val(json.xb)*/

        $("#txtAutores").val(json.Autores)
        $("#txtCiencia").val(json.Ciencia)
        $("#txtEditora").val(json.Editora)
        $("#txtIdioma").val(json.Idioma)
        $("#txtYear").val(json.year)
        $("#cbxActivo").val(json.Estado == true ? 1 : 0)


    } else {

        $("#mensajeError").hide()
        $("#txtId").val(0)
        $("#txtSignaturaTopografica").val("")
        $("#txtDesc").val("")
        $("#txtNombre").val("")
        $("#txtISB").val("")
        $("#txtBibliografiaId").val("")

        /*$("#cbxBibliografia").val(json.xb)*/

        $("#txtAutores").val("")
        $("#txtCiencia").val("")
        $("#txtEditora").val("")
        $("#txtIdioma").val("")
        $("#txtYear").val("")
        $("#cbxActivo").val("")
    }

    $("#FormModal").modal("show");
}

function Guardar() {

    var Libro = {

        Id: $("#txtId").val(),
        SignaturaTopografica: $("#txtSignaturaTopografica").val(),
        Nombre: $("#txtNombre").val(),
        ISB: $("#txtISB").val(),
        BibliografiaId: $("#cbxBibliografia").val(),
        Bibliografia: $("#cbxBibliografia").find(":selected").text(),
        Autores: $("#txtAutores").val(),
        Descripcion: $("#txtDesc").val(),
        Ciencia: $("#txtCiencia").val(),
        Editora: $("#txtEditora").val(),
        Estado: $("#cbxActivo").val() == 1 ? true : false,
        Idioma: $("#txtIdioma").val(),
        year: $("#txtYear").val()

    }

    jQuery.ajax({
        url: '/Libros/GuardarLibro', /*@Url.Action("GuardarLibro", "Libros")*/
        type: "POST",
        data: JSON.stringify({ libro: Libro }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario

            /*debugger;*/

            //USUARIO NUEVO
            if (Libro.Id == 0) { // si usuarioID = 0 es que se va a agregar

                if (data.resultado != 0) {

                    /*Libro.Id = data.resultado;*/
                    tablaData.ajax.reload();
                    /*$('#example').DataTable().ajax.reload()*/
                    $("#FormModal").modal("hide");

                    Swal.fire(
                        'Todo nitido',
                        '',
                        'success'
                    )

                } else {
                    //$("#mensajeError").text(data.mensaje);
                    //$("#mensajeError").show();

                    Swal.fire(
                        '' + data.mensaje,
                        '',
                        'error'
                    )
                }
            }
            else { // editar

                if (data.resultado) {

                    tablaData.row(filaSeleccionada).data(Libro).draw(false);
                    filaSeleccionada = null;
                    $("#FormModal").modal("hide");

                    Swal.fire(
                        'Todo nitido',
                        '',
                        'success'
                    )

                } else {
                    //$("#mensajeError").text(data.mensaje);

                    //$("#mensajeError").show();

                    Swal.fire(
                        '' + data.mensaje,
                        '',
                        'error'
                    )
                }
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        }
    });

    $("#FormModal").modal("hide");
}


function Eliminar(json) {

    var Libro = {

        Id: json["Id"]

    }

    jQuery.ajax({
        url: '/Libros/EliminarLibro', /*@Url.Action("EliminarLibro", "Libros")*/
        type: "POST",
        data: JSON.stringify({ id: Libro.Id }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario

            /*debugger;*/

            if (data.resultado) {

                tablaData.row(filaSeleccionada).draw(false);
                filaSeleccionada = null;

                Swal.fire(
                    'Borrado',
                    '',
                    'success'
                )

            } else {
                $("#mensajeError").text(data.mensaje);

                $("#mensajeError").show();
                Swal.fire(
                    'se jodio' + data.mensaje,
                    '',
                    'error'
                )
            }
        },
        error: function (error) {
            console.log(error)
        },
    });

    $("#FormModal").modal("hide");
}

function Detalles(json) {

    console.log(json)

    if (json != null) {

        $("#mensajeError").hide()
        $("#txtIdD").val(json.Id)
        $("#txtSignaturaTopograficaD").val(json.SignaturaTopografica)
        $("#txtNombreD").val(json.Nombre)
        $("#txtDescD").val(json.Descripcion)
        $("#txtISBD").val(json.ISB)
        $("#cbxBibliografiaD").val(json.Bibliografia)

        /*$("#cbxBibliografia").val(json.xb)*/

        $("#txtAutoresD").val(json.Autores)
        $("#txtCienciaD").val(json.Ciencia)
        $("#txtEditoraD").val(json.Editora)
        $("#txtIdiomaD").val(json.Idioma)
        $("#txtYearD").val(json.year)
        $("#cbxActivoD").val(json.Estado == true ? "Si" : "No")




        $("#ModalDetalles").modal("show");
    }
}

////////////////////-----------------------------

$("#tablaLibros tbody").on("click", '.btn-editar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    console.log(tablaData.row(filaSeleccionada).data())

    abrirModal(data)

})

$("#tablaLibros tbody").on("click", '.btn-eliminar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    //console.log(tablaData.row(filaSeleccionada).data())

    Eliminar(data)

    tablaData.row(filaSeleccionada).remove();

})

$("#tablaLibros tbody").on("click", '.btn-info', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    Detalles(data)

    //console.log(tablaData.row(filaSeleccionada).data())

    /*Eliminar(data)*/

    /*tablaData.row(filaSeleccionada).remove();*/

})