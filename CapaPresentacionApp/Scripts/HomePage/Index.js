
function test(value) {

    jQuery.ajax
        ({
            url: '/HomePage/CargarLibro', /*@Url.Action("CargarLibro", "HomePage")*/
            type: "GET",
            data: { Id: value },
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.data) {
                    window.location.href = '/HomePage/DetalleLibro' /*@Url.Action("DetalleLibro", "HomePage")*/
                }
            }
        });
}

jQuery.ajax({
    url: '/Libros/ListarLibros',/*@Url.Action("ListarLibros", "Libros")*/
    type: "GET",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    success: function (data) {

        //$("<option>").attr({ "value": "0", "disabled": "true" }).text("Seleccionar").appendTo("#cbxBibliografia");

        /*`<h1>${value.Nombre}</h1>`*/

        $.each(data.data, function (index, value) {

            var miString = `<div class= "col mb-5" >` +
                `<div class="card h-100">` +
                `<img class="card-img-top img_foto border rounded mx-auto d-block img-fluid" style="width: 158px; height: 239px; object-fit: cover;" src="../FOTOS_LIBROS/${value.NombreImagen}"  alt="..." />` +
                `<div class="card-body p-4">` +
                `<div class="text-center" >` +
                `<input type="text" id="inputId" value="${value.Id}" hidden/>` +
                `<h5 class="fw-bolder" style="text-transform: capitalize;">${value.Nombre}</h5 >`+
                `</div>` +
                `</div >` +
                `<!-- Product actions-->` +
                `<div class="card-footer p-4 pt-0 border-top-0 bg-transparent" >` +
                `<div class="text-center">
                                        <button class="btn btn-outline-dark mt-auto"  onclick="test(${value.Id})" > Ver detalles</button>

                                        </div>`+
                `</div >`

            console.log(value)
            /*console.log(miString)*/

            $("#contenedor").append(miString);
        })
    },
    error: {

    }
});