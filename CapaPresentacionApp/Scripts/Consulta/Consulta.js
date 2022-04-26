///Editoras

let tabla = $("#tablaLibros").DataTable
    ({
        responsive: true,
        ordering: false,
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
            ],
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        }

    });

function consultar(val) {

    if (val == 1) { // 1 = Editora

        let id = $("#cbxEditoras").val()
        console.log(id)

        tabla.ajax.url('/Consulta/ConsultarPorEditora/'+id).load();
        
    }
    else if (val == 2) {
        let id = $("#cbxCiencias").val()
        console.log(id)
        tabla.ajax.url('/Consulta/ConsultarPorCiencias/' + id).load();
    }
    else if (val == 3) {
        let id = $("#cbxIdiomas").val()
        console.log(id)
        tabla.ajax.url('/Consulta/ConsultarPorIdiomas/' + id).load();
    }
    else if (val == 4) {
        let id = $("#cbxAutores").val()
        console.log(id)
        tabla.ajax.url('/Consulta/ConsultarPorAutores/' + id).load();
    }
    else if (val == 5) {
        let id = $("#cbxBibliografias").val()
        console.log(id)
        tabla.ajax.url('/Consulta/ConsultarPorBibliografias/' + id).load();
    }
}

////////////////////-----------------------------

$("#chkEditora").on("click",  function () {

    
    if ($('#chkEditora').prop('checked')) {
        $("#contenedorTemporal").remove();
        

        //$('#chkCiencias').attr({ "disabled": true }) // desactivamos los demas checkbox para no tener conflictos


        var miString = `
            <div class="container d-flex justify-content-evenly" id="contenedorTemporal">
                <div class="col-sm-6">
                    <label for="cbxEditoras" class="form-label">Editoras</label>
                    <select class="form-select" id="cbxEditoras">
                    </select>
                </div>
                <div class="d-flex align-items-end">
                    <button class="btn btn-primary" onclick="consultar(1)">Consultar</button> 
                </div>
            </div>`
        // le pasamos el valor 1 que significa que ejecutara el bloque concerniente a editoras
        
        jQuery.ajax({
            url: '/Mantenimiento/ListarEditoras', /*@Url.Action("ListarAutores", "Mantenimiento")*/
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                $("<option>").attr({ "value": "0", "selected": "true" }).text("Seleccionar").appendTo("#cbxEditoras");

                $.each(data.data, function (index, value) {

                    $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxEditoras");

                })
            },
            error: {

            }
        });

        $("#contenedor").append(miString);
    } else {
       /* $("#contenedor").append(miString);*/
        /*$('#chkCiencias').attr({ "disabled": false })*/
        /*$(".container").remove()*/
        $("#contenedorTemporal").remove();
    }
    
})

$("#chkCiencias").on("click", function () {

   /* alert('Clickeaste ciencias')*/


    if ($('#chkCiencias').prop('checked')) {

        $("#contenedorTemporal").remove();
        var miString = `
            <div class="container d-flex justify-content-evenly" id="contenedorTemporal">
                <div class="col-sm-6">
                    <label for="cbxCiencias" class="form-label">Ciencias</label>
                    <select class="form-select" id="cbxCiencias">
                    </select>
                </div>
                <div class="d-flex align-items-end">
                    <button class="btn btn-primary" onclick="consultar(2)">Consultar</button> 
                </div>
            </div>`
        // le pasamos el valor 1 que significa que ejecutara el bloque concerniente a editoras

        jQuery.ajax({
            url: '/Mantenimiento/ListarCiencias', /*@Url.Action("ListarAutores", "Mantenimiento")*/
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                $("<option>").attr({ "value": "0", "selected": "true" }).text("Seleccionar").appendTo("#cbxCiencias");

                $.each(data.data, function (index, value) {

                    $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxCiencias");

                })
            },
            error: {

            }
        });

        $("#contenedor").append(miString);


       /* $('#chkEditora').attr({ "disabled": true })*/ // desactivamos los demas checkbox para no tener conflictos

    } else {
    //    $('#chkEditora').attr({ "disabled": false })
    }
})
$("#chkIdiomas").on("click", function () {

    /* alert('Clickeaste ciencias')*/


    if ($('#chkIdiomas').prop('checked')) {

        $("#contenedorTemporal").remove();
        var miString = `
            <div class="container d-flex justify-content-evenly" id="contenedorTemporal">
                <div class="col-sm-6">
                    <label for="cbxIdiomas" class="form-label">Idiomas</label>
                    <select class="form-select" id="cbxIdiomas">
                    </select>
                </div>
                <div class="d-flex align-items-end">
                    <button class="btn btn-primary" onclick="consultar(3)">Consultar</button> 
                </div>
            </div>`
        // le pasamos el valor 1 que significa que ejecutara el bloque concerniente a editoras

        jQuery.ajax({
            url: '/Mantenimiento/ListarIdiomas', /*@Url.Action("ListarAutores", "Mantenimiento")*/
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                $("<option>").attr({ "value": "0", "selected": "true" }).text("Seleccionar").appendTo("#cbxIdiomas");

                $.each(data.data, function (index, value) {

                    $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxIdiomas");

                })
            },
            error: {

            }
        });

        $("#contenedor").append(miString);


        /* $('#chkEditora').attr({ "disabled": true })*/ // desactivamos los demas checkbox para no tener conflictos

    } else {
        //    $('#chkEditora').attr({ "disabled": false })
    }
})


$("#chkAutores").on("click", function () {

    /* alert('Clickeaste ciencias')*/


    if ($('#chkAutores').prop('checked')) {

        $("#contenedorTemporal").remove();
        var miString = `
            <div class="container d-flex justify-content-evenly" id="contenedorTemporal">
                <div class="col-sm-6">
                    <label for="cbxAutores" class="form-label">Autores</label>
                    <select class="form-select" id="cbxAutores">
                    </select>
                </div>
                <div class="d-flex align-items-end">
                    <button class="btn btn-primary" onclick="consultar(4)">Consultar</button> 
                </div>
            </div>`
        // le pasamos el valor 1 que significa que ejecutara el bloque concerniente a editoras

        jQuery.ajax({
            url: '/Mantenimiento/ListarAutores', /*@Url.Action("ListarAutores", "Mantenimiento")*/
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                $("<option>").attr({ "value": "0", "selected": "true" }).text("Seleccionar").appendTo("#cbxAutores");

                $.each(data.data, function (index, value) {

                    $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxAutores");

                })
            },
            error: {

            }
        });

        $("#contenedor").append(miString);


        /* $('#chkEditora').attr({ "disabled": true })*/ // desactivamos los demas checkbox para no tener conflictos

    } else {
        //    $('#chkEditora').attr({ "disabled": false })
    }
})



$("#chkBibliografias").on("click", function () {

    /* alert('Clickeaste ciencias')*/


    if ($('#chkBibliografias').prop('checked')) {

        $("#contenedorTemporal").remove();
        var miString = `
            <div class="container d-flex justify-content-evenly" id="contenedorTemporal">
                <div class="col-sm-6">
                    <label for="cbxBibliografias" class="form-label">Bibliografias</label>
                    <select class="form-select" id="cbxBibliografias">
                    </select>
                </div>
                <div class="d-flex align-items-end">
                    <button class="btn btn-primary" onclick="consultar(5)">Consultar</button> 
                </div>
            </div>`
        // le pasamos el valor 1 que significa que ejecutara el bloque concerniente a editoras

        jQuery.ajax({
            url: '/Mantenimiento/ListarBibliografias', /*@Url.Action("ListarAutores", "Mantenimiento")*/
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                $("<option>").attr({ "value": "0", "selected": "true" }).text("Seleccionar").appendTo("#cbxBibliografias");

                $.each(data.data, function (index, value) {

                    $("<option>").attr({ "value": value.Id }).text(value.Name).appendTo("#cbxBibliografias");

                })
            },
            error: {

            }
        });

        $("#contenedor").append(miString);


        /* $('#chkEditora').attr({ "disabled": true })*/ // desactivamos los demas checkbox para no tener conflictos

    } else {
        //    $('#chkEditora').attr({ "disabled": false })
    }
})