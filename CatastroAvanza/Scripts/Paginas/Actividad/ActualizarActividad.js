ActualizarActividadJs = {    
    urlObtenerMunicipios: "",    
    archivosCargados: { FP: "", Plano : "", Esc : "", Fmi : "", Cn : "", Crq : "", Foto : "" },
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
        $("#Terreno_UnidadArea").change(CalcularTerrenoEnMetros);
        $("#Terreno_AreaTerreno").change(CalcularTerrenoEnMetros);
        $("#Terreno_AreaTerrenoEnMetros").change(CalcularPorcentajeJudicial);
        $("#Informacion_AreaTerreno").change(CalcularPorcentajeJudicial);

        ActividadEncontrada();
        InicializarFileInputs();
        ObtenerMunicipiosYSeleccionarUnValorDeterminado();
        BloqueadosPorDefecto();

        DesbloquearAdicionaCancelaUnidades();
        DesbloquearUnidadTramite();
        DesbloquearUnidadReglamento();
        DesbloquearLinderosFmi();
        DesbloquearNumeroEscritura();
        DesbloquearAreasTerreno();
        DesbloquearUso();
        DesbloquearDestino();
        ArchivosCargados('FP', this.archivosCargados.FP);
        ArchivosCargados('Plano', this.archivosCargados.Plano);
        ArchivosCargados('Esc', this.archivosCargados.Esc);
        ArchivosCargados('Fmi', this.archivosCargados.Fmi);
        ArchivosCargados('Cn', this.archivosCargados.Cn);
        ArchivosCargados('Crq', this.archivosCargados.Crq);
        ArchivosCargados('Foto', this.archivosCargados.Foto);
    },
    InicializarMunicipio: function (dep, mun) {
        ObtenerMunicipiosYSeleccionarUnValorDeterminado(dep, mun)
    }
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
        if ($(this).attr('id') ==  'Files_FotoFachada')
            $("#fotofachadaPreview").attr("src", reader.result);
    }).on('fileclear', function () {
        $('#' + $(this).attr('data-externalid') + 'I').addClass('fa-folder-open-o');
        $('#' + $(this).attr('data-externalid') + 'I').removeClass('fa-folder-o');
        $('#' + $(this).attr('data-externalid') + 'Tab').removeClass('text-success');
        $('#' + $(this).attr('data-externalid') + 'Archivo').html('');
        $('#' + $(this).attr('data-externalid') + 'Estado').html('<span class="badge badge-dark">No</span>');
        if ($(this).attr('id') == 'Files_FotoFachada')
            $("#fotofachadaPreview").attr("src", "/Images/casas_imgs/casa_1.png");
        
    });
}

function BloqueadosPorDefecto() {
    $(".bloqueado").attr('disabled', 'disabled')

}

function DesbloquearUnidadTramite() {
    if ($("#Tramite_Desenglobe").val() == "true")
        $("#Tramite_Unidadestramite").removeAttr('disabled');
    else {
        $("#Tramite_Unidadestramite").val("");
        $("#Tramite_Unidadestramite").attr('disabled', 'disabled');
    }
}

function DesbloquearUnidadReglamento() {
    if ($("#Tramite_ReglamentoPH").val() == "true")
        $("#Tramite_UnidadesReglamento").removeAttr('disabled');
    else {
        $("#Tramite_UnidadesReglamento").val("");
        $("#Tramite_UnidadesReglamento").attr('disabled', 'disabled');
    }
}

function DesbloquearLinderosFmi() {
    if ($("#Tramite_Linderos").val() == "true")
        $("#Tramite_LinderosFmi").removeAttr('disabled');
    else {
        $("#Tramite_LinderosFmi").val("");
        $("#Tramite_LinderosFmi").attr('disabled', 'disabled');
    }
}

function DesbloquearNumeroEscritura() {
    if ($("#Tramite_LinderosEnEscritura").val() == "true")
        $("#Tramite_NumeroEscritura").removeAttr('disabled');
    else {
        $("#Tramite_NumeroEscritura").val("");
        $("#Tramite_NumeroEscritura").attr('disabled', 'disabled');
    }
}

function DesbloquearAreasTerreno() {
    if ($("#Terreno_TieneArea").val() == "true") {
        $("#Terreno_AreaTerreno").removeAttr('disabled');
        $("#Terreno_UnidadArea").removeAttr('disabled');
    }
    else {
        $("#Terreno_AreaTerreno").attr('disabled', 'disabled');
        $("#Terreno_UnidadArea").attr('disabled', 'disabled');
        $("#Terreno_AreaTerreno").val("");
        $("#Terreno_UnidadArea").val("");
        $("#Terreno_AreaTerrenoEnMetros").val("");
        $("#Terreno_PorcentajeAreaJudicialAreaCatastral").val("");
    }
}

function CalcularTerrenoEnMetros() {
    var unidadesValor = $("#Terreno_UnidadArea").children("option:selected").attr("data-valorunidad")
    var areaTerreno = $("#Terreno_AreaTerreno").val();
    var areaTerrenoMetros = areaTerreno * unidadesValor
    var porcentajeAreaJudicial = (areaTerreno * unidadesValor) / $("#Informacion_AreaTerreno").val();
    $("#Terreno_AreaTerrenoEnMetros").val(areaTerrenoMetros);
    $("#Terreno_PorcentajeAreaJudicialAreaCatastral").val(porcentajeAreaJudicial);
}

function CalcularPorcentajeJudicial() {
    var unidadesValor = $("#Terreno_UnidadArea").children("option:selected").attr("data-valorunidad")
    var areaTerreno = $("#Terreno_AreaTerreno").val();
    var porcentajeAreaJudicial = (areaTerreno * unidadesValor) / $("#Informacion_AreaTerreno").val();
    $("#Terreno_PorcentajeAreaJudicialAreaCatastral").val(porcentajeAreaJudicial);
}

function DesbloquearUso() {
    if ($("#Construccion_Uso").val() == "true")
        $("#Construccion_UsoDetalle").removeAttr('disabled');
    else {
        $("#Construccion_UsoDetalle").val("");
        $("#Construccion_UsoDetalle").attr('disabled', 'disabled');
    }
}

function DesbloquearDestino() {
    if ($("#Construccion_Destino").val() == "true")
        $("#Construccion_DestinoDetalle").removeAttr('disabled');
    else {
        $("#Construccion_DestinoDetalle").val("");
        $("#Construccion_DestinoDetalle").attr('disabled', 'disabled');
    }
}

function DesbloquearAdicionaCancelaUnidades() {
    if ($("#Construccion_AdicionaCancelaUnidades").val() == "true")
        $(".Construccion_AdicionaCancelaUnidades").removeAttr('disabled');
    else {
        $(".Construccion_AdicionaCancelaUnidades").removeAttr("cheked");
        $(".Construccion_AdicionaCancelaUnidades").attr('disabled', 'disabled');
    }
}

function ActividadEncontrada()
{
    if ($('#Id').val() != 0) {
        $(".sectionToShow").removeClass("invisible");
        $("#saveUpBtn").removeAttr("disabled");
        $("#saveDownBtn").removeAttr("disabled");
    }        
}

function ObtenerMunicipios() {
    ObtenerMunicipiosYSeleccionarUnValorDeterminado($(this).val(), 0);
}

function ObtenerMunicipiosYSeleccionarUnValorDeterminado(depto, munSeleccionado) {

    $.post(ActualizarActividadJs.urlObtenerMunicipios, { IdDepartamento: depto }, function (data) {
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

function ArchivosCargados(nombre, value) {
    if (value != "") {
        $('#' + nombre + 'I').addClass('fa-folder-o');
        $('#' + nombre + 'I').removeClass('fa-folder-open-o');
        $('#' + nombre + 'Tab').addClass('text-success');
        $('#' + nombre + 'Archivo').html(value);
        $('#' + nombre + 'Estado').html('<span class="badge badge-success">Si</span>');        
    }

}