var ActividadJs = {
    urlObtenerMunicipios :"",
    Inicializar: function () {
        $("#Informacion_Departamento").change(ObtenerMunicipios);
        $("#saveUpBtn").click(saveForm);
        $("#saveDownBtn").click(saveForm);
        InicializarFileInputs();
    },   
}

function InicializarFileInputs() {
    $(".archivosClass").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group",
        //filedeleted: function () {
        //    alert('Hola mundo');
        //    setTimeout(function () {
        //        window.alert('File deletion was successful! ' + krajeeGetCount('file-5'));
        //    }, 900);
        //}
    }).on('fileloaded', function (event, file, previewId, fileId, index, reader) {
        $('#' + $(this).attr('data-externalid') + 'I').addClass('fa-folder-o');
        $('#' + $(this).attr('data-externalid') + 'I').removeClass('fa-folder-open-o');

        $('#' + $(this).attr('data-externalid') + 'Tab').addClass('text-success');

        $('#' + $(this).attr('data-externalid') + 'Archivo').html($(this)[0].files[0].name);

        $('#' + $(this).attr('data-externalid') + 'Estado').html('<span class="badge badge-success">Si</span>');
    }).on('fileclear', function () {
        $('#' + $(this).attr('data-externalid') + 'I').addClass('fa-folder-open-o');
        $('#' + $(this).attr('data-externalid') + 'I').removeClass('fa-folder-o');

        $('#' + $(this).attr('data-externalid') + 'Tab').removeClass('text-success');

        $('#' + $(this).attr('data-externalid') + 'Archivo').html('');

        $('#' + $(this).attr('data-externalid') + 'Estado').html('<span class="badge badge-dark">No</span>');
    });
}


function saveForm() {    
    if (!$("#frmActividad").valid())
        $('#liveToast').toast('show');
    else
        loadingModal();
}


function ObtenerMunicipios()
{    
    $.post(ActividadJs.urlObtenerMunicipios, { IdDepartamento: $(this).val() }, function (data) {
        $('#Informacion_Municipio').empty();
        $.each(data, function (index, value) {
            $('#Informacion_Municipio').append($('<option/>', {
                value: value.Value,
                text: value.Text
            }));
        });  
    });
}

