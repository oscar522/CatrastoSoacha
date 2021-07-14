ConsultarUsuariosJs = {
    urlListadoUsuarios: "",
    urlActualizarUsuario: "",
    Inicializar: function () {
        ListarUsuarios();
    }
}

function ListarUsuarios() {
    $('#usersTbl').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: ConsultarUsuariosJs.urlListadoUsuarios,
        },
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'rol',
                data: 'rol',
                title: 'Rol',
                orderable: true,
                searchable: true
            },
            {
                name: 'TipoDocumento',
                data: 'TipoDocumento',
                title: 'TipoDocumento',
                orderable: true
            },
            {
                name: 'TipoDocumento',
                data: 'TipoDocumento',
                title: 'TipoDocumento',
                orderable: true
            }, {
                name: 'Documento',
                data: 'Documento',
                title: 'Documento',
                orderable: true
            }, {
                name: 'Nombres',
                data: 'Nombres',
                title: 'Nombres',
                orderable: true                
            }, {
                name: 'Apellidos',
                data: 'Apellidos',
                title: 'Apellidos',
                orderable: true
            },
            {
                name: 'Telefono',
                data: 'Telefono',
                title: 'Telefono',
                orderable: true
            }, {
                name: 'Estado',
                data: 'Estado',
                title: 'Estado',
                orderable: true
            },
            {
                name: 'UserID',
                data: 'UserID',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    return "<a class='btn btn-outline-primary' title='Actualizar' href='" + ConsultarUsuariosJs.urlActualizarUsuario + "?userId=" + data + "'><i class='fa fa-edit'></i></a>";
                }
            }
            , {
                name: 'UserID',
                data: 'UserID',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    return "<a class='btn btn-outline-danger' title='Eliminar' href='#'><i class='fa fa-trash'></i></a>";
                }
            }
        ],
    });
}