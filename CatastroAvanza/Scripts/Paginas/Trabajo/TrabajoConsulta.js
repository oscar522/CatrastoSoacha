var TrabajoConsultaJs = {
    urlObtenerTrabajos: "",
    urlAgregarGestionTrabajo: "",
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
            url: TrabajoConsultaJs.urlObtenerTrabajos,
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
                    if (full.Estado == "Activo")
                        return "<a class='btn btn-outline-primary' title='Agregar gestion' href='" + TrabajoConsultaJs.urlAgregarGestionTrabajo + "?idTrabajo=" + data + "'><i class='fa fa-chevron-right'></i> Gestionar</a>";
                    else
                        return "";
                }
            }
        ],
    });
}