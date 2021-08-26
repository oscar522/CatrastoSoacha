var TrabajoDashboardJs = {    
    urlVerGestionTrabajo: "",
    urlVolumenTrabajo: "",
    urlEstadoGestion: "",
    urlUsuarioGestion: "",
    urlObtenerTrabajoPorId: "",
    urlObtenerListadoTrabajosPorId:"",
    Inicializar: function () {
        VolumenBoard();
        EstadoBoard();
        UsuarioBoard();
        ListarTrabajosPorIdPadres(0);
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