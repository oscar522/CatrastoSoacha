var TrabajoAsignacionJs = {
    urlObtenerListadoUsuarios: "",
    urlActualizarTrabajo: "",
    urlEliminarTrabajo: "",
    urlAsignarTrabajo: "",
    Inicializar: function () {
        ListarUsuarios();
    }
}

function ListarUsuarios() {
    $('#usuarios').autocomplete(
        {
            minLength: 4,
            select: function (event, ui) {
                $('#UserAsignado').val(ui.item.Email);
                $('#usuarios').val(ui.item.Email);
                $('#usuariosnombres').val(ui.item.Nombres + " " + ui.item.Apellidos)
                return false;
            },
            source: function (request, response) {
                $.ajax({
                    url: TrabajoAsignacionJs.urlObtenerListadoUsuarios,
                    dataType: "json",
                    method: "Post",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response(data);
                    }
                });
            }
        }
    ).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<div>User :" + item.Email + "<br>Nombre: " + item.Nombres + " " + item.Apellidos + "</div>")
            .appendTo(ul);
    };

}
