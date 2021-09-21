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
                    VerTrabajo(data.IdTrabajo);
                    ObternerInformacionEstadoActividad(data.IdTrabajo);
                    ObternerInformacionEstadoActividadPorFecha(data.IdTrabajo);
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
            text: 'Actividad Seleccionada <strong>' + dataSerie.name + '</strong></br > estado de las asignaciones de la actividad'
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

function ObternerInformacionEstadoActividadPorFecha(idActividad) {    
    $.ajax({
        type: 'POST',
        url: TrabajoDashboardJs.urlObtenerActividadesPorEstadoYFecha,
        dataType: 'json',
        data: { IdActividadPadre: idActividad },
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
                    format: '#Usuarios: {point.y}'
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