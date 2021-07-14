ConsultarUsuariosJs = {
    urlListadoUsuarios: "",
    urlActualizarUsuario: "",
    urlBloquearUsuario: "",
    Inicializar: function () {
        ListarUsuarios();
        $('#btn-confirm').click(function () {
            if ($("#Id").val() != '')
                BloquearUsuario();
        });
    }
}

function ListarUsuarios() {
    $('#usersTbl').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: ConsultarUsuariosJs.urlListadoUsuarios            
        },
        initComplete: function () {
            $(".btnElimnarUsuario").click(EstablecerIdABloquear);
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
                name: 'Email',
                data: 'Email',
                title: 'Email',
                orderable: true
            },
            {
                name: 'TipoDocumentoNombre',
                data: 'TipoDocumentoNombre',
                title: 'Tipo Documento',
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
                    return "<a class='btn btn-outline-danger btnElimnarUsuario' title='Eliminar' href='#' data-toggle='modal' data-target='#confirmacionModal' data-id='" + data + "'><i class='fa fa-trash' ></i></a>";
                }
            }
        ],
    });
}

function EstablecerIdABloquear() {    
    $("#Id").val($(this).attr("data-id"));
}

function BloquearUsuario()
{
    $.ajax({
        type: 'POST',
        url: ConsultarUsuariosJs.urlBloquearUsuario,
        dataType: 'json',
        data: { id: $("#Id").val() },
        success: function (states) {
            if (states == "Ok")
                window.location.reload();
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}