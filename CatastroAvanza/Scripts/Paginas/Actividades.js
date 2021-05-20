$(document).ready(function () {
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

    $("#saveUpBtn").click(saveForm);
    $("#saveDownBtn").click(saveForm);
});

function saveForm() {    
    if (!$("#frmActividad").valid())
        $('#liveToast').toast('show');
    else
        loadingModal();
}

