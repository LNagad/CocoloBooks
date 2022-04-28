﻿
var tablaData;

var filaSeleccionada;

tablaData = $("#tablaLibros").DataTable
    ({
        responsive: true,
        ordering: false,
        "ajax": {
            url: '/Mantenimiento/ListarEditoras', //@Url.Action("ListarEditoras", "Mantenimiento")
            type: "GET",
            dataType: "json",
        },
        "columns":
            [
                { "data": "Name" },
                { "data": "Description" },
                {
                    "data": "Estado", "render": function (valor) {
                        if (valor == 1) {
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
    url: '@Url.Action("ListarEditoras", "Mantenimiento")',
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {


        console.log(data)
    },
    error: {

    }
});


function abrirModal(json) {

    if (json != null) {

        $("#mensajeError").hide()
        $("#txtId").val(json.Id)
        $("#txtNombre").val(json.Name)
        $("#txtDescripcion").val(json.Description)
        $("#cbxActivo").val(json.Estado == true ? 1 : 0)

    } else {
        $("#mensajeError").hide()
        $("#txtId").val(0)
        $("#txtNombre").val("")
        $("#txtDescripcion").val("")
        $("#cbxActivo").val("")
    }

    $("#FormModal").modal("show");
}

function Guardar() {

    var Editoras = {
        Id: $("#txtId").val(),
        Name: $("#txtNombre").val(),
        Description: $("#txtDescripcion").val(),
        Estado: $("#cbxActivo").val() == 1 ? true : false
    }

    jQuery.ajax({
        url: '/Mantenimiento/GuardarEditoras', //@Url.Action("GuardarEditoras", "Mantenimiento")
        type: "POST",
        data: JSON.stringify({ editora: Editoras }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario
            console.log(data)
            //BIBLIOGRAFIA NUEVA
            debugger

            if (Editoras.Id == 0) { // si usuarioID = 0 es que se va a agregar

                if (data.resultado != 0) {

                    tablaData.ajax.reload();

                    $("#FormModal").modal("hide");

                    Swal.fire(' '+ data.mensaje, 'Agregado de manera exitosa')

                } else {
                    //error
                    Swal.fire(
                        '' + data.mensaje,
                        '',
                        'error'
                    )
                }
            }
            else { // editar

                if (data.resultado) {

                    tablaData.row(filaSeleccionada).data(Editoras).draw(false);
                    filaSeleccionada = null;
                    $("#FormModal").modal("hide");

                    Swal.fire(''+ data.mensaje, 'Editado de manera exitosa')
                } else {
                    $("#mensajeError").text(data.mensaje);
                    $("#mensajeError").show();
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

    var Editora = {
        Id: json["Id"]
    }

    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
      }).then((result) => {
        if (result.isConfirmed) {
            jQuery.ajax({
                url: '/Mantenimiento/EliminarEditoras', //@Url.Action("EliminarEditoras", "Mantenimiento")
                type: "POST",
                data: JSON.stringify({ id: Editora.Id }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario
        
                    if (data.resultado) {
        
                        tablaData.row(filaSeleccionada).draw(false);
                        filaSeleccionada = null;
        
                        Swal.fire(
                            ' ' +
                            data.mensaje,
                            'Eliminado de manera exitosa'
                        )
        
                    } else {
                        $("#mensajeError").text(data.mensaje);
        
                        $("#mensajeError").show();
                        Swal.fire(
                            ' ' + data.mensaje,
                            '',
                            'error'
                        )
                    }
                },
                error: function (error) {
                    console.log(error)
                }
            });
        }
      })

    

    $("#FormModal").modal("hide");
}

function Detalles(json) {

    console.log(json)

    if (json != null) {
        $("#mensajeError").hide()
        $("#txtIdD").val(json.Id)
        $("#txtNombreD").val(json.Name)
        $("#txtDescripcionD").val(json.Description)
        $("#cbxActivoD").val(json.Estado == true ? 'Si' : 'No')

        $("#ModalDetalles").modal("show");
    }
}
////////////////////-----------------------------

$("#tablaLibros tbody").on("click", '.btn-editar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    abrirModal(data)

})

$("#tablaLibros tbody").on("click", '.btn-eliminar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    //console.log(tablaData.row(filaSeleccionada).data())

    Eliminar(data)
})

$("#tablaLibros tbody").on("click", '.btn-info', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    Detalles(data)

})
