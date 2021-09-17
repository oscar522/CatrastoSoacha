var TrabajoDashboardJs = {    
    urlVerGestionTrabajo: "",
    urlVolumenTrabajo: "",
    urlEstadoGestion: "",
    urlUsuarioGestion: "",
    urlObtenerTrabajoPorId: "",
    urlObtenerListadoTrabajosPorId: "",
    urlObtenerActividadesPorEstado: "",
    urlObtenerActividadesPorEstadoYFecha:"",
    urlObtenerListadoTrabajos: "",
    urlObtenerUsuariosAsignadosProyecto: "",
    urlObtenerEstadoProyecto:"",
    Inicializar: function () {
        VolumenBoard();
        EstadoBoard();
        UsuarioBoard();
        ListarTrabajosPorIdPadres(0);
        ListarTrabajosPadres();
        $("#btnCargarGrafica").click(ObternerInformacionEstadoActividadPorFecha);
        ObternerEstadoProyecto();
        ObternerUsuariosAsignadosProyecto();
    }
}

function VolumenBoard() {
    $.post(TrabajoDashboardJs.urlVolumenTrabajo, function (data) {
        $('#vencidos').empty();
        $('#vencidoslargos').empty();
        $('#proximosavencer').empty();
        $('#finalizados').empty();
        
        $('#vencidos').append(data.AsignacionesVencidas);
        $('#vencidoslargos').append(data.AsignacionesVencidasMasde3Dias);
        $('#proximosavencer').append(data.AsignacionesProximasAVencerse);
        $('#finalizados').append(data.AsignacionesFinalizadas);
            
    });
}

function EstadoBoard() {
    $.post(TrabajoDashboardJs.urlEstadoGestion, function (data) {        
        $(data.EstadoGestion).each(function (index, element) {
            var ancho = 300 * (element.Value / data.TotalGestiones);
            $("#estadosls").append('<li>' + element.Key + ' <div id="brCreados" class="alert alert-primary bg-dark text-white" role="alert" style="width:' + ancho + 'px;">' +  element.Value + '</div ></li>');
        });


    });
}

function UsuarioBoard() {
    $('#tblusuarios').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: TrabajoDashboardJs.urlUsuarioGestion,
        },
        dom: 'ltip',
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'Usuario',
                data: 'Usuario',
                title: 'Usuario',
                orderable: true
            }, {
                name: 'NombreUsuario',
                data: 'NombreUsuario',
                title: 'Nombre Usuario',
                orderable: true
            }, {
                name: 'NumeroAsignaciones',
                data: 'NumeroAsignaciones',
                title: 'Total Asignaciones',
                orderable: true
            }, {
                name: 'NumeroGestiones',
                data: 'NumeroGestiones',
                title: 'Total Gestiones',
                orderable: true
            }
        ],
    });
}

function ListarTrabajosPorIdPadres(idPadre) {
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerListadoTrabajosPorId,
        dataType: 'json',
        data: { IdPadre: idPadre },
        success: function (data) {
            $('#tree').treeview({
                data: data,
                levels: 1000,
                expandIcon: "fa fa-plus",
                collapseIcon: "fa fa-minus",
                highlightSelected: true,
                showTags: true,
                onNodeSelected: function (event, data) {
                    VerTrabajo(data.IdTrabajo)
                }
            });
            $('#tree').treeview('collapseAll', { silent: true });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function VerTrabajo(id) {
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerTrabajoPorId,
        dataType: 'json',
        data: { id: id },
        success: function (data) {
            $('#NombreTrabajoTexto').empty();
            $('#NombreTrabajoTexto').html(data.Nombre);

            $('#RolTrabajoTexto').empty();
            $('#RolTrabajoTexto').html(data.RolNombre);

            $('#CantidadTrabajoTexto').empty();
            $('#CantidadTrabajoTexto').html(data.Cantidad);

            $('#PuntosTrabajoTexto').empty();
            $('#PuntosTrabajoTexto').html(data.PuntosEsfuerzo);

            $('#EstadoTrabajoTexto').empty();
            $('#EstadoTrabajoTexto').html(data.Estado);

            $('#FechaTrabajoTexto').empty();
            $('#FechaTrabajoTexto').html(data.Estado);

            $('#AsignadoTrabajoTexto').empty();
            $(data.AsignadoA).each(function (i) {
                $('#AsignadoTrabajoTexto').append(" - " + data.AsignadoA[i] + "<br />");
            });
            if (data.Estado == 'Activo') {
                $('#btn_asignar').attr('href', TrabajoJs.urlAsignarTrabajo + "?idTrabajo=" + data.Id);
                $('#btn_actualizar').attr('href', TrabajoJs.urlActualizarTrabajo + "?idTrabajo=" + data.Id);
                $('#btn_accion').removeClass('invisible');
                $("#IdEliminar").val(data.Id);
            } else {
                $('#btn_asignar').removeAttr('href');
                $('#btn_actualizar').removeAttr('href');
                $('#btn_eliminar').attr('disabled', 'disabled');
                $("#IdEliminar").val('');
                $('#btn_accion').addClass('invisible');
            }

        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function ObternerInformacionEstadoActividad(idActividad) {
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerActividadesPorEstado,
        dataType: 'json',
        data: { IdActividadPadre: idActividad },
        success: function (data) {
            ActividadesEstado(data);            
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function ActividadesEstado(dataSerie) {
    // Create the chart
    Highcharts.chart('container', {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Actividades por estado'
        },
        subtitle: {
            text: 'Seleccione una actividad'
        },

        accessibility: {
            announceNewData: {
                enabled: true
            },
            point: {
                valueSuffix: ''
            }
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}: {point.y}'
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> del total<br/>'
        },

        series: [dataSerie],
    });
}

function ListarTrabajosPadres() {
    $('#lsTrabajos').autocomplete(
        {
            minLength: 3,
            select: function (event, ui) {                
                $('#lsTrabajos').val(ui.item.Nombre);
                ObternerInformacionEstadoActividad(ui.item.Id)
                return false;
            },
            source: function (request, response) {
                $.ajax({
                    url: TrabajoDashboardJs.urlObtenerListadoTrabajos,
                    dataType: "json",
                    method: "Post",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response(data);
                    }
                });
            }
        }
    ).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<div>Trabajo :" + item.Nombre)
            .appendTo(ul);
    };

    $('#lsTrabajos2').autocomplete(
        {
            minLength: 3,
            select: function (event, ui) {
                $('#lsTrabajos2').val(ui.item.Nombre);
                $('#lsTrabajos2id').val(ui.item.Id);
                return false;
            },
            source: function (request, response) {
                $.ajax({
                    url: TrabajoDashboardJs.urlObtenerListadoTrabajos,
                    dataType: "json",
                    method: "Post",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response(data);
                    }
                });
            }
        }
    ).autocomplete("instance")._renderItem = function (ul, item) {
        return $("<li>")
            .append("<div>Trabajo :" + item.Nombre)
            .appendTo(ul);
    };1
}

function ObternerInformacionEstadoActividadPorFecha() {    
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerActividadesPorEstadoYFecha,
        dataType: 'json',
        data: { IdActividadPadre: $("#lsTrabajos2id").val(), fecha: $("#fechalsTrabajos2").val() },
        success: function (data) {
            ActividadesEstadoYFecha(data);
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function ActividadesEstadoYFecha(dataSerie) {
    // Create the chart
    Highcharts.chart('container2', {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Actividades por estado y fecha'
        },
        subtitle: {
            text: 'Seleccione una actividad y una fecha'
        },

        accessibility: {
            announceNewData: {
                enabled: true
            },
            point: {
                valueSuffix: ''
            }
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}: {point.y}'
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> del total<br/>'
        },

        series: [dataSerie],
    });
}

function ObternerUsuariosAsignadosProyecto() {
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerUsuariosAsignadosProyecto,
        dataType: 'json',        
        success: function (data) {
            UsuariosAsignadosProyecto(data);
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function UsuariosAsignadosProyecto(dataSerie) {
    // Create the chart
    Highcharts.chart('container3', {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Usuarios asignados a los proyectos'
        },
        subtitle: {
            text: 'Seleccione una actividad'
        },

        accessibility: {
            announceNewData: {
                enabled: true
            },
            point: {
                valueSuffix: ''
            }
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}: {point.y}'
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> del total<br/>'
        },

        series: [dataSerie],
    });
}

function ObternerEstadoProyecto() {
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerEstadoProyecto,
        dataType: 'json',
        success: function (data) {
            EstadoProyecto(data);
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function EstadoProyecto(dataSerie) {
    // Create the chart
    Highcharts.chart('container4', {
        chart: {
            type: 'pie'
        },
        title: {
            text: 'Estado asignaciones actividades proyecto'
        },
        subtitle: {
            text: ''
        },

        accessibility: {
            announceNewData: {
                enabled: true
            },
            point: {
                valueSuffix: ''
            }
        },

        plotOptions: {
            series: {
                dataLabels: {
                    enabled: true,
                    format: '{point.name}: {point.y}'
                }
            }
        },

        tooltip: {
            headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
            pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y}</b> del total<br/>'
        },

        series: [dataSerie],
    });
}