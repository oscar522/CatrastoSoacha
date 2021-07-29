var CrearArchivoJs = {
    urlObtenerArchivos: "",
    urlDescargarArchivo: "",
    Inicializar: function () {
        InicializarFileInputs();
        ListarArchivos();
    }
}

function InicializarFileInputs() {
    $(".archivosClass").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group",
    });
}


function ListarArchivos() {
    $('#archivosTbl').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: CrearArchivoJs.urlObtenerArchivos,
        },
        dom: 'lfrtip',
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
                name: 'CreadoPor',
                data: 'CreadoPor',
                title: 'CreadoPor',
                orderable: true
            }, {
                name: 'FechaCreacion',
                data: 'FechaCreacion',
                title: 'FechaCreacion',
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
                    return "<a class='btn btn-outline-primary' title='Actualizar' href='" + CrearArchivoJs.urlDescargarArchivo + "?archivoId=" + data + "'><i class='fa fa-download'></i></a>";
                }
            }
        ],
    });
}