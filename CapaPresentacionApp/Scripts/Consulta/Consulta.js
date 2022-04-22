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
}

////////////////////-----------------------------

$("#chkEditora").on("click",  function () {

    
    if ($('#chkEditora').prop('checked')) {
    

        $('#chkCiencias').attr({ "disabled": true }) // desactivamos los demas checkbox para no tener conflictos


        var miString = `
            <div class="container d-flex justify-content-evenly">
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
        $("#contenedor").append(miString);
        $('#chkCiencias').attr({ "disabled": false })
    }
    
})

$("#chkCiencias").on("click", function () {

    alert('Clickeaste ciencias')


    if ($('#chkCiencias').prop('checked')) {


        $('#chkEditora').attr({ "disabled": true }) // desactivamos los demas checkbox para no tener conflictos

    } else {
        $('#chkEditora').attr({ "disabled": false })
    }
})