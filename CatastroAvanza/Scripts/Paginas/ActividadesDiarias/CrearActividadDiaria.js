var ActividadDiariaJs = {
    urlRolActividad: "",
    urlRolList: "",
    urlProcesoList: "",
    urlModalidadList: "",
    urlListDepto: "",
    urlListMunicipios: "",
    urlObtenerActividades:"",
    Inicializar: function () {
        InicializaElementos();
        GetRoles();
        GetProcessList();
        GetModalidadList();
        GetDepartamentos();
        GetDataInfo();
        $("#IdRolActividad").change(GetActividadesByRol);
        $("#IdDepto").change(GetMunicipios);
    }
}


function InicializaElementos() {
    $("#FechaActividad").val("");
    $("#Cantidad").val("");
}

function GetRoles()
{
    $.ajax({
        type: 'POST',
        url: ActividadDiariaJs.urlRolList, 
        dataType: 'json',
        success: function (states) {            
            $.each(states, function (i, state) {                
                $("#IdRolActividad").append('<option value="' + state.Value + '">' + state.Text + '</option>');
            });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function GetProcessList()
{
    $.ajax({
        type: 'POST',
        url: ActividadDiariaJs.urlProcesoList, 
        dataType: 'json',
        success: function (states) {            
            $.each(states, function (i, state) {                
                $("#IdProceso").append('<option value="' + state.Value + '">' + state.Text + '</option>');
            });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function GetModalidadList()
{
    $.ajax({
        type: 'POST',
        url: ActividadDiariaJs.urlModalidadList, 
        dataType: 'json',
        success: function (states) {            
            $.each(states, function (i, state) {                
                $("#IdModalidad").append('<option value="' + state.Value + '">' + state.Text + '</option>');
            });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function GetDepartamentos()
{
    $.ajax({
        type: 'POST',
        url: ActividadDiariaJs.urlListDepto,
        dataType: 'json',
        success: function (states) {
            $.each(states, function (i, state) {                
                if ('@Model.IdDepto' == state.Value) {
                    $("#IdDepto").append('<option value="' + state.Value + '" selected>' + state.Text + '</option>');
                } else {
                    $("#IdDepto").append('<option value="' + state.Value + '">' + state.Text + '</option>');
                }
            });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function GetActividadesByRol() {    
    $("#IdActividad").empty();
    $.ajax({
        type: 'POST',
        url: ActividadDiariaJs.urlRolActividad,
        dataType: 'json',
        data: { RolId: $("#IdRolActividad").val() },
        success: function (states) {
            $.each(states, function (i, state) {    
                $("#IdActividad").append('<option value="' + state.Value + '">' + state.Text + '</option>');
            });
        },
        error: function (ex) {
            console.log(ex.responseText);
        }
    });
}

function GetMunicipios()
{
    $("#IdMuni").empty();
    if ($(this).val() != '0') {
        $.ajax({
            type: 'POST',
            url: ActividadDiariaJs.urlListMunicipios,
            dataType: 'json',
            data: { IdDepartamento: $(this).val() },
            success: function (states) {                
                $.each(states, function (i, state) {                    
                    $("#IdMuni").append('<option value="' + state.Value + '">' + state.Text + '</option>');
                });
            },
            error: function (ex) {
                console.log(ex.responseText);
            }
        });
    } 
}

function GetDataInfo()
{
    $('#table_User').DataTable({
        serverSide: true,
        processing: true,
        responsive:true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: ActividadDiariaJs.urlObtenerActividades,
        },
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'Id',
                data: 'Id',
                title: 'Id',
                orderable: true,
                responsivePriority: 1,
                targets: 0 
            },
            {
                name: 'FechaActividadS',
                data: 'FechaActividadS',
                title: 'Fecha',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
                render: function (data, type, full) {
                    var mDate = moment(data);
                    return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            },
            {
                name: 'DepartamentoMunicipio',
                data: 'DepartamentoMunicipio',
                title: 'Dpto - Municipio',
                orderable: true,
                searchable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'NombreProceso',
                data: 'NombreProceso',
                title: 'Nombre Proceso',
                orderable: true,
                searchable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'NombreModalidad',
                data: 'NombreModalidad',
                title: 'Nombre Modalidad',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'NombreRolActividad',
                data: 'NombreRolActividad',
                title: 'Rol',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            }, {
                name: 'RolUsuario',
                data: 'RolUsuario',
                title: 'Rol Usuario',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'NombreUsuario',
                data: 'NombreUsuario',
                title: 'nombre Usuario',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'NombreActividad',
                data: 'NombreActividad',
                title: 'Actividad',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'Cantidad',
                data: 'Cantidad',
                title: 'Cantidad',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            },
            {
                name: 'Observacion',
                data: 'Observacion',
                title: 'Observacion',
                orderable: true,
                responsivePriority: 2,
                targets: -1,
            }
        ],
    });
}