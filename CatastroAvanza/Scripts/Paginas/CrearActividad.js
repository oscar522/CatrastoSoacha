var ActividadJs = {
    urlObtenerMunicipios :"",
    Inicializar: function () {
        $("#Informacion_Departamento").change(ObtenerMunicipios);
        $("#saveUpBtn").click(saveForm);
        $("#saveDownBtn").click(saveForm);
    },   
}

function InicializarFileInputs() {
    $("#Folio_Fmi").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group"
    });

    $("#Nomenclatura_CertificadoNomenclatura").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group"
    });

    $("#Construccion_FotoFachada").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group"
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

