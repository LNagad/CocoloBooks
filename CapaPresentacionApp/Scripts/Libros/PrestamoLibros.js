var tablaData;

var filaSeleccionada;

//@* jQuery.ajax({
//    url: '@Url.Action("ListarUsuarios", "Home")',
//    type: "GET",
//    dataType: "json",
//    contentType: "application/json; charset=utf-8",
//    success: function (data) {
//        /*        debugger; // para detener*/
//        var texto1 = "hola soy el texto 1"

//        console.log(data)
//    }
//}) *@

tablaData = $("#tablaUsuarios").DataTable
    ({
        responsive: true,
        ordering: false,
        "ajax": {
            url: '/Home/ListarUsuarios',  /*@Url.Action("ListarUsuarios", "Home")*/
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
                    "defaultContent": '<button type="button" class="btn btn-primary btn-sm btn-editar" >Gestionar Prestamos</button>' +
                        '<button type="button" class="btn btn-danger ms-2 btn-sm btn-eliminar"></i></button>', 
                        
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
    console.log(json)

    if (json != null) {

        $("#mensajeError").hide()
        $("#txtId").val(json.Id)
        $("#txtNombre").val(json.Nombre)
        $("#txtApellido").val(json.Apellido)
        $("#txtCorreo").val(json.Correo)
        $("#txtClave").hide()
        $("#lblClave").hide()
        $("#txtCedula").val(json.Cedula)
        $("#txtCarnet").val(json.NCarnet)
        $("#cbxPersona").val(json.TipoPersona)
        $("#cbxUsuario").val(json.TipoUsuario) /// ponerle el valro a esto
        $("#cbxActivo").val(json.Estado == true ? 1 : 0)


    } else {
        $("#lblClave").show()
        $("#txtClave").show()
        $("#txtId").val(0)
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

    if (validar($("#txtCorreo").val())) {

        var Usuario = {

            Id: $("#txtId").val(),
            Nombre: $("#txtNombre").val(),
            Apellido: $("#txtApellido").val(),
            Correo: $("#txtCorreo").val(),
            Clave: $("#txtClave").val(),
            TipoUsuario: $("#cbxUsuario").val(),
            Cedula: $("#txtCedula").val(),
            NCarnet: $("#txtCarnet").val(),
            TipoPersona: $("#cbxPersona").val(),
            Estado: $("#cbxActivo").val() == 1 ? true : false

        }

        jQuery.ajax({
            url: '/Home/GuardarUsuario', /*@Url.Action("GuardarUsuario", "Home")*/
            type: "POST",
            //JSON.stringify( {usuario: Usuario } ) formatea el json y debemos pasarle el objeto y de donde
            // los valores en este caso Usuario que es el objeto de arriba y usuario que es el parametro del controlador
            data: JSON.stringify({ usuario: Usuario }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario

                /*debugger;*/

                if (Usuario.Id == 0) { // si usuarioID = 0 es que se va a agregar

                    if (data.resultado != 0) {

                        /*Usuario.Ud = data.resultado;*/
                        tablaData.ajax.reload();
                        /*$('#example').DataTable().ajax.reload()*/
                        $("#FormModal").modal("hide");

                        Swal.fire(
                            '' + data.mensaje,
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

                        /*tablaData.row(filaSeleccionada).data(Usuario).draw(false);*/
                        tablaData.ajax.reload();
                        filaSeleccionada = null;
                        $("#FormModal").modal("hide");

                        Swal.fire(
                            '' + data.mensaje,
                            '',
                            'success'
                        )

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
    else {
        Swal.fire({

            title: 'Correo no bien escrito',
            text: 'Usted si es bruto hermano, escriba eso bien',
            icon: 'error',
            confirmButtonColor: '#157347'
        })
        console.log('correo sin arroba')

    }
}

function Eliminar(json) {

    var Usuario = {

        Id: json["Id"]

    }

    jQuery.ajax({
        url: '/Home/EliminarUsuario', /*@Url.Action("EliminarUsuario", "Home")*/
        type: "POST",
        //JSON.stringify( {usuario: Usuario } ) formatea el json y debemos pasarle el objeto y de donde
        // los valores en este caso Usuario que es el objeto de arriba y usuario que es el parametro del controlador
        data: JSON.stringify({ usuario: Usuario }), // parametro del metodo GuardarUsuario que es usuariox y se carga con el objeto Usuario
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) { //la data es lo que resivimos del url que viene del controlador metodo GuardarUsuario

            /*debugger;*/

            //USUARIO NUEVO
            if (Usuario.Id == 0) { // si usuarioID = 0 es que se va a agregar

                Swal.fire(
                    '' + data.mensaje,
                    '',
                    'error'
                )
            }
            else { // editar

                if (data.resultado) {

                    tablaData.ajax.reload()

                    /*tablaData.row(filaSeleccionada).draw(false);*/
                    filaSeleccionada = null;

                    Swal.fire(
                        '' + data.mensaje,
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


function Detalles(json) {

    console.log(json)
    if (json != null) {
        /*.find(":selected").text()*/

        $("#txtIdD").val(json.Id)
        $("#txtNombreD").val(json.Nombre)
        $("#txtApellidoD").val(json.Apellido)
        $("#txtCorreoD").val(json.Correo)
        $("#txtCedulaD").val(json.Cedula)
        $("#txtCarnetD").val(json.NCarnet)
        $("#cbxPersonaD").val(json.TipoPersona == 1 ? "Juridica" : "Fisica")
        $("#cbxUsuarioD").val(json.TipoUsuario == 1 ? "Usuario" : "Admin") /// ponerle el valro a esto
        $("#cbxActivoD").val(json.Estado == true ? "Activo" : "Inactivo")

        $("#ModalDetalles").modal("show");
    }
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