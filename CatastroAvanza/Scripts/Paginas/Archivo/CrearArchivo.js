var CrearArchivoJs = {
    urlObtenerArchivos: "",
    urlDescargarArchivo: "",
    urlCargarArchivo: "",
    urlComplertarCargarArchivo: "",
    Inicializar: function () {
        InicializarFileInputs();
        ListarArchivos();
    }
}

function InicializarFileInputs() {
    $(".archivosClass").fileinput({
        theme: "fa",
        language: "es",
        showUpload: true,
        dropZoneEnabled: false,
        hideThumbnailContent: true,
        mainClass: "input-group",
        uploadUrl: CrearArchivoJs.urlCargarArchivo,
        enableResumableUpload: true
    }).on('fileuploaded', function (event, previewId, index, fileId, data) {        
        console.log('File Uploaded', 'ID: ' + fileId + ', Thumb ID: ' + previewId);
        $.ajax({
            type: 'POST',
            url: CrearArchivoJs.urlComplertarCargarArchivo,
            dataType: 'json',
            data: { fileId: fileId },
            success: function (states) {
            },
            error: function (ex) {
                console.log(ex.responseText);
            }
        });

    }).on('fileuploaderror', function (event, previewId, index, fileId) {
        console.log('File Upload Error', 'ID: ' + fileId + ', Thumb ID: ' + previewId);
    }).on('filebatchuploadcomplete', function (event, preview, config, tags, extraData) {        
        console.log('File Batch Uploaded', preview, config, tags, extraData);
        alert("Todos los archivos fueron cargados");        
        window.location.reload();
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