var tablaData;

var filaSeleccionada;


tablaData = $("#tablaUsuarios").DataTable
    ({
        responsive: true,
        ordering: false,
        "ajax": {
            url: '/Prestamos/ListarUsuariosClientes',  /*@Url.Action("ListarUsuarios", "Home")*/
            type: "GET",
            dataType: "json",
        },
        "columns":
            [
                { "data": "Nombre" },
                { "data": "Apellido" },
                { "data": "Correo" },
                /*{ "data": "TipoPersona" },*/

                {
                    "data": "TipoUsuario", "render": function (valor) {
                        if (valor == 1) {
                            return '<span style="margin-left: 25px;" class="badge bg-primary">Usuario</span>'
                        } else if (valor == 2) {
                            return '<span style="margin-left: 25px;" class="badge bg-danger">Admin</span>'
                        }
                    }
                },
                {
                    "data": "Estado", "render": function (valor) {
                        if (valor) {
                            return '<span style="margin-left: 20px;" class="badge bg-success">Si</span>'
                        } else {
                            return '<span style="margin-left: 20px;" class="badge bg-danger">No</span>'
                        }
                    }
                },
                {
                    "defaultContent": '<button type="button" class="btn-primary btn-sm btn-editar" >Agregar</button>',
                    "orderable": false,
                    "searchable": false,
                    "width": "105px",
                    "size": "20px"
                }
            ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }

    });

    $("#tablaLibros").DataTable
        ({
            responsive: true,
            lengthMenu: [[5],[5]],
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
                        "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-editar" ><i class="fas fa-pen me-1"></i></button>',
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

jQuery.ajax({
    url: '/Home/ListarUsuarios',
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        /*        debugger; // para detener*/

        console.log(data)
    }
})


function abrirModal(json) {

    if (json != null) {

        $("#mensajeError").hide()
        $("#txtId").val(json.Id)
        $("#txtNombre").val(json.Nombre)
        $("#txtApellido").val(json.Apellido)
        $("#txtCorreo").val(json.Correo)

        $("#cbxActivo").val(json.Estado == true ? 1 : 0)


    } else {

        $("#txtId").val(0)
        $("#lblClave").show()
        $("#txtClave").show()
        $("#txtNombre").val("")
        $("#txtApellido").val("")
        $("#txtCorreo").val("")
        $("#txtCarnet").val("")
        $("#txtCedula").val("")
        $("#cbxPersona").val("")
        $("#cbxUsuario").val("") /// ponerle el valro a esto
        $("#cbxActivo").val("")
        $("#mensajeError").hide()
    }

    $("#FormModal").modal("show");
}

function validar(texto) {

    for (x in texto) {

        if ("@" == texto[x]) {
            return true;
        }
    }

}

function Guardar() {


}



////////////////////-----------------------------

$("#tablaUsuarios tbody").on("click", '.btn-editar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    console.log(tablaData.row(filaSeleccionada).data())

    abrirModal(data)

})

$("#tablaUsuarios tbody").on("click", '.btn-eliminar', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()

    //console.log(tablaData.row(filaSeleccionada).data())

    Eliminar(data)

    tablaData.row(filaSeleccionada).remove();

})

$("#tablaUsuarios tbody").on("click", '.btn-info', function () {

    filaSeleccionada = $(this).closest("tr")

    var data = tablaData.row(filaSeleccionada).data()
    console.log(data)

    Detalles(data)

    //console.log(tablaData.row(filaSeleccionada).data())

    /*Eliminar(data)*/

    /*tablaData.row(filaSeleccionada).remove();*/

})