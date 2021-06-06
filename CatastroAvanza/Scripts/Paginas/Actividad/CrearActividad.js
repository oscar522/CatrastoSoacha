var ActividadJs = {
    urlObtenerMunicipios: "",
    urlObtenerPredial: "",    
    Inicializar: function () {
        $("#Informacion_Departamento").change(ObtenerMunicipios);
        $("#Tramite_Desenglobe").change(DesbloquearUnidadTramite);
        $("#Tramite_ReglamentoPH").change(DesbloquearUnidadReglamento); 
        $("#Tramite_Linderos").change(DesbloquearLinderosFmi); 
        $("#Tramite_LinderosEnEscritura").change(DesbloquearNumeroEscritura);
        $("#Terreno_TieneArea").change(DesbloquearAreasTerreno);
        $("#Construccion_Uso").change(DesbloquearUso); 
        $("#Construccion_Destino").change(DesbloquearDestino); 
        $("#Construccion_AdicionaCancelaUnidades").change(DesbloquearAdicionaCancelaUnidades); 
        $("#saveUpBtn").click(SaveForm);
        $("#saveDownBtn").click(SaveForm);
        $("#btnBuscar").click(ObtenerInfoByPredial);
        InicializarFileInputs();
        InicializarListas();
        BloqueadosPorDefecto();
    },   
}

function InicializarListas()
{
    $(".listas").val("");
}

function BloqueadosPorDefecto()
{
    $(".bloqueado").attr('disabled', 'disabled')
    
}

function InicializarFileInputs() {
    $(".archivosClass").fileinput({
        theme: "explorer-fa",
        language: "es",
        showUpload: false,
        dropZoneEnabled: false,
        mainClass: "input-group",
    }).on('fileloaded', function (event, file, previewId, fileId, index, reader) {
        $('#' + $(this).attr('data-externalid') + 'I').addClass('fa-folder-o');
        $('#' + $(this).attr('data-externalid') + 'I').removeClass('fa-folder-open-o');
        $('#' + $(this).attr('data-externalid') + 'Tab').addClass('text-success');
        $('#' + $(this).attr('data-externalid') + 'Archivo').html($(this)[0].files[0].name);
        $('#' + $(this).attr('data-externalid') + 'Estado').html('<span class="badge badge-success">Si</span>');
        $("#fotofachadaPreview").attr("src", reader.result);
    }).on('fileclear', function () {
        $('#' + $(this).attr('data-externalid') + 'I').addClass('fa-folder-open-o');
        $('#' + $(this).attr('data-externalid') + 'I').removeClass('fa-folder-o');
        $('#' + $(this).attr('data-externalid') + 'Tab').removeClass('text-success');
        $('#' + $(this).attr('data-externalid') + 'Archivo').html('');
        $('#' + $(this).attr('data-externalid') + 'Estado').html('<span class="badge badge-dark">No</span>');
    });
}

function DesbloquearUnidadTramite()
{
    if ($(this).val() == "true")
        $("#Tramite_Unidadestramite").removeAttr('disabled');
    else {
        $("#Tramite_Unidadestramite").val("");
        $("#Tramite_Unidadestramite").attr('disabled', 'disabled');
    }        
}

function DesbloquearUnidadReglamento() {
    if ($(this).val() == "true")
        $("#Tramite_UnidadesReglamento").removeAttr('disabled');
    else {
        $("#Tramite_UnidadesReglamento").val("");
        $("#Tramite_UnidadesReglamento").attr('disabled', 'disabled');
    }
}

function DesbloquearLinderosFmi() {
    if ($(this).val() == "true")
        $("#Tramite_LinderosFmi").removeAttr('disabled');
    else {
        $("#Tramite_LinderosFmi").val("");
        $("#Tramite_LinderosFmi").attr('disabled', 'disabled');
    }
}

function DesbloquearNumeroEscritura() {
    if ($(this).val() == "true")
        $("#Tramite_NumeroEscritura").removeAttr('disabled');
    else {
        $("#Tramite_NumeroEscritura").val("");
        $("#Tramite_NumeroEscritura").attr('disabled', 'disabled');
    }
}

function DesbloquearAreasTerreno() {
    if ($(this).val() == "true")
    {
        $("#Terreno_AreaTerreno").removeAttr('disabled');
        $("#Terreno_UnidadArea").removeAttr('disabled');
        $("#Terreno_AreaTerrenoEnMetros").removeAttr('disabled');
        $("#Terreno_PorcentajeAreaJudicialAreaCatastral").removeAttr('disabled');
    }        
    else {
        $("#Terreno_AreaTerreno").attr('disabled', 'disabled');
        $("#Terreno_UnidadArea").attr('disabled', 'disabled');
        $("#Terreno_AreaTerrenoEnMetros").attr('disabled', 'disabled');
        $("#Terreno_PorcentajeAreaJudicialAreaCatastral").attr('disabled', 'disabled');
        $("#Terreno_AreaTerreno").val("");        
        $("#Terreno_UnidadArea").val("");
        $("#Terreno_AreaTerrenoEnMetros").val("");
        $("#Terreno_PorcentajeAreaJudicialAreaCatastral").val("");
    }
}

function DesbloquearUso() {
    if ($(this).val() == "true")
        $("#Construccion_UsoDetalle").removeAttr('disabled');
    else {
        $("#Construccion_UsoDetalle").val("");
        $("#Construccion_UsoDetalle").attr('disabled', 'disabled');
    }
}

function DesbloquearDestino() {
    if ($(this).val() == "true")
        $("#Construccion_DestinoDetalle").removeAttr('disabled');
    else {
        $("#Construccion_DestinoDetalle").val("");
        $("#Construccion_DestinoDetalle").attr('disabled', 'disabled');
    }
}

function DesbloquearAdicionaCancelaUnidades() {
    if ($(this).val() == "true")
        $(".Construccion_AdicionaCancelaUnidades").removeAttr('disabled');
    else {
        $(".Construccion_AdicionaCancelaUnidades").removeAttr("cheked");
        $(".Construccion_AdicionaCancelaUnidades").attr('disabled', 'disabled');
    }
}


function SaveForm() {    
    if (!$("#frmActividad").valid())
        $('#liveToast').toast('show');
    else
        loadingModal();
}

function ObtenerInfoByPredial()
{
    $.post(ActividadJs.urlObtenerPredial, { noPredial: $("#NumeroPredial").val() }, function (data) {  
        if (data.NUMERO_DEL_PREDIO == null) {
            alert("Registro no encontrado");
            return false;
        }
        $("#NumeroPredial").val(data.NUMERO_DEL_PREDIO) 
        $("#Informacion_Departamento").val(data.dep)
        ObtenerMunicipiosYSeleccionarUnValorDeterminado(data.dep, data.mun)        
        $("#Informacion_Comuna").val(data.R1_2020_66069_PREDIOSModel[0].COMUNA);
        $("#Informacion_Destino").val(data.R1_2020_66069_PREDIOSModel[0].DESCRIPCION_DESTINO);
        $("#Informacion_AreaTerreno").val(data.R1_2020_66069_PREDIOSModel[0].AREA_TERRENO);
        $("#Informacion_Direccion").val(data.R1_2020_66069_PREDIOSModel[0].DIRECCION);
        $("#Informacion_AreaConstruida").val(data.R1_2020_66069_PREDIOSModel[0].AREA_CONSTRUIDA);
        $("#Informacion_Avaluo").val(data.R1_2020_66069_PREDIOSModel[0].AVALUO);        
        $("#Informacion_NumeroMejoras").val(data.CANTIDAD_MEJORA);
               
        if (data.CANTIDAD_MEJORA > 0)
            $("#Informacion_Mejoras").val("true");       

        $("#saveUpBtn").removeAttr("disabled");
        $("#saveDownBtn").removeAttr("disabled");
        $(".sectionToShow").removeClass("invisible");

    });
    return false;
}

function ObtenerMunicipios()
{    
    ObtenerMunicipiosYSeleccionarUnValorDeterminado($(this).val(), 0);
}

function ObtenerMunicipiosYSeleccionarUnValorDeterminado(depto, munSeleccionado) {

    $.post(ActividadJs.urlObtenerMunicipios, { IdDepartamento: depto }, function (data) {
        $('#Informacion_Municipio').empty();
        $.each(data, function (index, value) {
            $('#Informacion_Municipio').append($('<option/>', {
                value: value.Value,
                text: value.Text
            }));
        });
        if (munSeleccionado != 0)
            $("#Informacion_Municipio").val(munSeleccionado);
    });
}

