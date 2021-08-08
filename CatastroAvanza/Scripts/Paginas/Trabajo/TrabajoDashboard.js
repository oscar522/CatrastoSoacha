var TrabajoDashboardJs = {    
    urlVerGestionTrabajo: "",
    urlVolumenTrabajo: "",
    urlEstadoGestion: "",
    urlUsuarioGestion: "",
    Inicializar: function () {
        VolumenBoard();
        EstadoBoard();
        UsuarioBoard();
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