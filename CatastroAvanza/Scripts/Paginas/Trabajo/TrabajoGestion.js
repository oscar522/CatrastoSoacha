var TrabajoGestionJs = {
    urlObtenerGestiones: "",
    urlActualizarGestion: "",
    urlEliminarGestion:"",
    Inicializar: function () {
        ListarGestion();
    }
}

function ListarGestion() {
    $('#tblgestion').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: TrabajoGestionJs.urlObtenerGestiones,
            data: { idAsignacion: $("#IdAsignacion").val() }
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
                name: 'EstadoGestion',
                data: 'EstadoGestion',
                title: 'Estado Gestion',
                orderable: true
            }, {
                name: 'FechaModificacionGestion',
                data: 'FechaModificacionGestion',
                title: 'Fecha Gestion',
                orderable: true,
                width: "10%",
                render: function (data, type, full) {
                    var mDate = moment(data);
                    return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            },
            {
                name: 'Observacion',
                data: 'Observacion',
                title: 'Observacion',
                orderable: true
            }, {
                name: 'EstadoRegistro',
                data: 'EstadoRegistro',
                title: 'EstadoRegistro',
                orderable: true
            }, {
                name: 'CreadoPor',
                data: 'CreadoPor',
                title: 'CreadoPor',
                orderable: true
            }, {
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
            }, {
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
                    return "<a class='btn btn-outline-primary' title='Actualizar' href='" + TrabajoGestionJs.urlActualizarGestion + "?actividadId=" + data + "'><i class='fa fa-edit'></i> Actualizar</a>";
                }
            }
            , {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    if (full.EstadoRegistro == "Activo")
                        return "<a class='btn btn-outline-danger' title='Eliminar' href='" + TrabajoGestionJs.urlEliminarGestion + "?actividadId=" + data + "'><i class='fa fa-trash'></i> Eliminar</a>";
                    else
                        return "";
                }
            }
        ],
    });
}