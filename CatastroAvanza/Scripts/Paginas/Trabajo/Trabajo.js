var TrabajoJs = {
    urlObtenerTrabajosAdministrador: "",
    urlActualizarTrabajo: "",
    urlEliminarTrabajo: "",
    urlAsignarTrabajo:"",
    Inicializar: function () {
        ListarTrabajos();
    }
}

function ListarTrabajos() {
    $('#tbltrabajos').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: TrabajoJs.urlObtenerTrabajosAdministrador,
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
                    return "<a class='btn btn-outline-primary' title='Actualizar' href='" + TrabajoJs.urlActualizarTrabajo + "?actividadId=" + data + "'><i class='fa fa-edit'></i> Actualizar</a>";
                }
            }
            , {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    if (full.Estado == "Activo")
                        return "<a class='btn btn-outline-danger' title='Eliminar' href='" + TrabajoJs.urlEliminarTrabajo + "?actividadId=" + data + "'><i class='fa fa-trash'></i> Eliminar</a>";
                    else
                        return "";
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
                        return "";
                }
            }
        ],
    });
}