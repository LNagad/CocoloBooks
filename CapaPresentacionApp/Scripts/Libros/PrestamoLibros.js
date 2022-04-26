let tablaData;
let tablita;
let filaSeleccionada;


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
                    "defaultContent": '<button type="button" class="btn-primary btn-sm btn-agregar" >Agregar</button>',
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

tablita = $("#tablaLibros").DataTable
    ({
        responsive: true,
        lengthMenu: [[5], [5]],
        ordering: false,
        "ajax": {
            url: '/Prestamos/ListarLibrosActivos', /*@Url.Action("ListarLibros", "Libros")*/
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
                    "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-seleccionar" ><i class="fas fa-pen me-1"></i></button>',
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

function reBuildTable() {

    tablita = $("#tablaLibros").DataTable
        ({
            responsive: true,
            lengthMenu: [[5], [5]],
            ordering: false,
            "ajax": {
                url: '/Prestamos/ListarLibrosActivos', /*@Url.Action("ListarLibros", "Libros")*/
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
                        "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-seleccionar" ><i class="fas fa-pen me-1"></i></button>',
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
}

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

function appendDiv(data) {

    let string = `
        <div class="row g-4" id="contenedorTemporal">
            <h2 class="mb-1 mt-5">Libro seleccionado: </h2>
            <div class= "d-flex">
                <div class="w-30 col-sm-2 d-flex justify-content-center">
                    <img class="card-img-top img_foto" style="width: 150px; " src="../Content/src/Books.png"  alt="..." />
                </div>
                <div class="d-flex flex-wrap justify-content-evenly">
                    <div class="col-sm-3 ms-1">
                        <label for="txtLibro" class="form-label">Nombre</label>
                        <input type="text" class="form-control" id="txtLibro" value="${data.Nombre}" readonly>

                    </div>
                    <div class="col-sm-3 ms-1">
                        <label for="txtFecha" class="form-label">Fecha</label>
                        <input type="text" class="form-control" id="txtFecha" value="${data.year}" readonly>

                    </div>
                    <div class="col-sm-3 ms-1">
                        <label for="txtISBN" class="form-label">ISBN</label>
                        <input type="email" class="form-control" id="txtISBN" value="${data.ISBN}" readonly>

                    </div>
                    <div class="col-sm-3 ms-1">
                        <label for="txtLibro" class="form-label">Idioma</label>
                        <input type="text" class="form-control" id="txtLibro" value="${data.Idioma}" readonly>

                    </div>
                    <div class="col-sm-3 ms-1">
                        <label for="txtFecha" class="form-label">Editora</label>
                        <input type="text" class="form-control" id="txtFecha" value="${data.Editora}" readonly>

                    </div>
                    <div class="col-sm-3 ms-1">
                        <label for="txtISBN" class="form-label">Ciencia</label>
                        <input type="email" class="form-control" id="txtISBN" value="${data.Ciencia}" readonly>

                    </div>
                </div>
            </div>
        </div>`

    $(string).appendTo(".modal-body")

}

function Guardar(data) {
    
    appendDiv(data)

}


////////////////////-----------------------------

$("#tablaUsuarios tbody").on("click", '.btn-agregar', function () {

    filaSeleccionada = $(this).closest("tr")

    let data = tablaData.row(filaSeleccionada).data()

    let table_length = tablita.data().count()

    /*$("#contenedorTemporal").hide()*/
    $("#contenedorTemporal").remove();
    if (table_length === 0) {
        reBuildTable()
        $("#tablaLibros").show()
        tablita.ajax.reload()
    }

    abrirModal(data)

})

$("#tablaLibros tbody").on("click", '.btn-seleccionar', function () {

    filaSeleccionada = $(this).closest("tr")

    let data = tablita.row(filaSeleccionada).data()

    tablita.clear().destroy();
    $("#tablaLibros").hide()

    Guardar(data)
    console.log(data)
})

