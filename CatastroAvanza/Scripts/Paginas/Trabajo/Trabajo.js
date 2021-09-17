var TrabajoJs = {
    urlObtenerTrabajosAdministrador: "",
    urlActualizarTrabajo: "",
    urlEliminarTrabajo: "",
    urlAsignarTrabajo: "",
    urlObtenerListadoTrabajos: "",
    urlObtenerListadoTrabajosPorId: "",
    urlObtenerTrabajoPorId: "",
    Inicializar: function () {
        /*ListarTrabajos();*/
        ListarTrabajosPadres();
        $('#btn-confirm').click(function () {
            if ($("#IdEliminar").val() != '')
                EliminarTrabajo();
        });
        ListarTrabajosPorIdPadres(0);

    }
}

function ListarTrabajos() {
    var dtable =$('#tbltrabajos').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: TrabajoJs.urlObtenerTrabajosAdministrador,
        },        
        initComplete: function () {
            bindEventlink();
        },
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'Id',
                data: 'Id',
                title: 'Id',
                orderable: true,
                searchable: true
            },
            {
                name: 'Nombre',
                data: 'Nombre',
                title: 'Nombre',
                orderable: true
            }, {
                name: 'RolNombre',
                data: 'RolNombre',
                title: 'Rol',
                orderable: true
            },
            {
                name: 'Cantidad',
                data: 'Cantidad',
                title: 'Cantidad',
                orderable: true
            }, {
                name: 'PuntosEsfuerzo',
                data: 'PuntosEsfuerzo',
                title: 'Puntos Esfuerzo',
                orderable: true
            }, {
                name: 'Estado',
                data: 'Estado',
                title: 'Estado',
                orderable: true
            }, {
                name: 'CreadoPor',
                data: 'CreadoPor',
                title: 'CreadoPor',
                orderable: true
            },{
                name: 'FechaCreacion',
                data: 'FechaCreacion',
                title: 'Fecha Creacion',
                orderable: true,
                width: "10%",
                render: function (data, type, full) {
                    var mDate = moment(data);
                    return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            }, {
                name: 'UltimaModificacionPor',
                data: 'UltimaModificacionPor',
                title: 'Modificado por',
                orderable: true
            },{
                name: 'FechaUltimaModificacion',
                data: 'FechaUltimaModificacion',
                title: 'Fecha modificacion',
                orderable: true,
                width: "10%",
                render: function (data, type, full) {
                    var mDate = moment(data);
                    return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            }, {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    if (full.Estado == "Activo")
                        return "<a class='btn btn-outline-primary' title='Actualizar' href='" + TrabajoJs.urlActualizarTrabajo + "?IdTrabajo=" + data + "'><i class='fa fa-edit'></i> Actualizar</a>";
                    else
                        return "-";
                }
            }
            , {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    if (full.Estado == "Activo")                        
                        return "<a class='btn btn-outline-danger btnElimnarTrabajo' title='Eliminar' href='#' data-toggle='modal' data-target='#confirmacionModal' data-id='" + data + "'><i class='fa fa-trash' ></i> Eliminar</a>";
                    else
                        return "-";
                }
            }, {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    if (full.Estado == "Activo")
                        return "<a class='btn btn-outline-primary' title='Agregar asignacion' href='" + TrabajoJs.urlAsignarTrabajo + "?idTrabajo=" + data + "'><i class='fa fa-child'></i> Asignar</a>";                  
                    else
                        return "-";
                }
            }
        ],
    });

    dtable.on('responsive-display', function (e, datatable, row, showHide, update) {
        bindEventlink();
    });
}

function bindEventlink() {    
    $('.btnElimnarTrabajo').unbind('click');    

    $('.btnElimnarTrabajo').on('click', EstablecerIdAEliminar);
}

function EstablecerIdAEliminar() {
    $("#IdEliminar").val($(this).attr("data-id"));
}

function EliminarTrabajo() {
    $.ajax({
        type: 'POST',
        url: TrabajoJs.urlEliminarTrabajo,
        dataType: 'json',
        data: { idTrabajo: $("#IdEliminar").val() },
        success: function (states) {
            if (states == "Ok")
                window.location.reload();
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function ListarTrabajosPadres() {
    $('#lsTrabajos').autocomplete(
        {
            minLength: 3,
            select: function (event, ui) {
                $('#IdTrabajoPadre').val(ui.item.Id);
                $('#lsTrabajos').val(ui.item.Nombre);
                return false;
            },
            source: function (request, response) {
                $.ajax({
                    url: TrabajoJs.urlObtenerListadoTrabajos,
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
            .append("<div>Trabajo :" + item.Nombre)
            .appendTo(ul);
    };

}

function ListarTrabajosPorIdPadres(idPadre) {
    $.ajax({
        type: 'POST',
        url: TrabajoJs.urlObtenerListadoTrabajosPorId,
        dataType: 'json',
        data: { IdPadre: idPadre },
        success: function (data) {
            $('#tree').treeview({
                data: data,
                levels: 1000,
                expandIcon: "fa fa-plus",
                collapseIcon: "fa fa-minus",                
                highlightSelected: true,
                showTags: true,
                onNodeSelected: function (event, data) {
                    VerTrabajo(data.IdTrabajo)
                }
            });
            $('#tree').treeview('collapseAll', { silent: true });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });    
}

function VerTrabajo(id) {
    $.ajax({
        type: 'POST',
        url: TrabajoJs.urlObtenerTrabajoPorId,
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            $('#NombreTrabajoTexto').empty();
            $('#NombreTrabajoTexto').html(data.Nombre);

            $('#RolTrabajoTexto').empty();
            $('#RolTrabajoTexto').html(data.RolNombre);

            $('#CantidadTrabajoTexto').empty();
            $('#CantidadTrabajoTexto').html(data.Cantidad);

            $('#PuntosTrabajoTexto').empty();
            $('#PuntosTrabajoTexto').html(data.PuntosEsfuerzo);

            $('#EstadoTrabajoTexto').empty();
            $('#EstadoTrabajoTexto').html(data.Estado);
            
            $('#FechaTrabajoTexto').empty();
            $('#FechaTrabajoTexto').html(data.Estado);

            $('#AsignadoTrabajoTexto').empty();
            $(data.AsignadoA).each(function (i) {
                $('#AsignadoTrabajoTexto').append(" - "+  data.AsignadoA[i] + "<br />");
            });
            if (data.Estado == 'Activo') {
                $('#btn_asignar').attr('href', TrabajoJs.urlAsignarTrabajo + "?idTrabajo=" + data.Id);
                $('#btn_actualizar').attr('href', TrabajoJs.urlActualizarTrabajo + "?idTrabajo=" + data.Id);
                $('#btn_accion').removeClass('invisible');
                $("#IdEliminar").val(data.Id);
            } else {
                $('#btn_asignar').removeAttr('href');
                $('#btn_actualizar').removeAttr('href');
                $('#btn_eliminar').attr('disabled', 'disabled');
                $("#IdEliminar").val('');
                $('#btn_accion').addClass('invisible');
            }
            
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}