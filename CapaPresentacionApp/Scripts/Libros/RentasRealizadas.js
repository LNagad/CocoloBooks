let table;
let filaSeleccionada;

table = $("#tablaRentas").DataTable
    ({
        responsive: true,
        lengthMenu: [[5], [5]],
        ordering: false,
        "ajax": {
            url: '/Prestamos/ListarRentas', /*@Url.Action("ListarLibros", "Libros")*/
            type: "GET",
            dataType: "json",
        },
        "columns":
            [
                { "data": "IdRenta" },
                { "data": "LibroNombre" },
                { "data": "FechaEntrega" },
                { "data": "ComisionEntregaTardia" },
                { "data": "fechaRenta" },
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

function abrirModal(data) {

    $("#txtId").val(data.IdRenta)

    $("#mensajeError").hide();
    $("#FormModal").modal("show");
}

function Guardar() {

    let RentaEstado = {
        IdRenta: $("#txtId").val(),
        Estado: $("#cbxActivo").val()
    }

    if (RentaEstado.Estado == 1) {
        RentaEstado.Estado = true;
    } else {
        RentaEstado.Estado = false;
    }

    console.log(RentaEstado)

    jQuery.ajax({
        url: '/Prestamos/ActualizarRenta',
        type: "POST",
        data: JSON.stringify({ datosRenta: RentaEstado }),
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado == 1) {

                Swal.fire(data.mensaje, 'El libro ha sido devuelto exitosamente', 'success')
                table.ajax.reload()
            } else {

                Swal.fire(data.mensaje, '', 'error')
            }

            $("#FormModal").modal("hide");
        }
    })

}

$("#tablaRentas tbody").on("click", '.btn-editar', function () {

    filaSeleccionada = $(this).closest("tr")

    let data = table.row(filaSeleccionada).data()

    abrirModal(data);
    console.log(data)
})

