var TrabajoDashboardJs = {
    urlObtenerTrabajos: "",
    urlVerGestionTrabajo: "",
    urlVolumenTrabajo: "",
    urlEstadoGestion: "",
    urlUsuarioGestion: "",
    Inicializar: function () {
        TrabajosBoard();
        VolumenBoard();
        EstadoBoard();
        UsuarioBoard();
    }
}

function TrabajosBoard() {
    $('#tbltrabajos').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: TrabajoDashboardJs.urlObtenerTrabajos,
        },
        dom: 'lfrtip',
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'Nombre',
                data: 'Nombre',
                title: 'Nombre',
                orderable: true
            }, {
                name: 'Estado',
                data: 'Estado',
                title: 'Estado',
                orderable: true
            }, {
                name: 'FechaUltimaModificacion',
                data: 'FechaUltimaModificacion',
                title: 'Fecha modificacion',
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
                    if (full.Estado == "Activo")
                        return "<a class='btn btn-outline-primary btn-sm' title='Agregar gestion' href='" + TrabajoDashboardJs.urlAgregarGestionTrabajo + "?idTrabajo=" + data + "'>Ver <i class='fa fa-chevron-right'></i></a>";
                    else
                        return "";
                }
            }
        ],
    });
}

function VolumenBoard() {
    $.post(TrabajoDashboardJs.urlVolumenTrabajo, function (data) {
        $('#creados').empty();
        $('#asignados').empty();
        $('#cerrados').empty();
        $('#gestiones').empty();
        
        $('#creados').append(data.TrabajosCreados);
        $('#asignados').append(data.TrabajosAsignados);
        $('#cerrados').append(data.TrabajosCerrados);
        $('#gestiones').append(data.GestionDiaria);
        
        $("#brCreados").height(300 * (data.TrabajosCreados / data.Total))
        $("#brAsignados").height(300 * (data.TrabajosAsignados / data.Total))
        $("#brCerrados").height(300 * (data.TrabajosCerrados / data.Total))
        $("#brGestiones").height(300 * (data.GestionDiaria / data.Total))

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
                title: 'NombreUsuario',
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