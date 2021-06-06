var ConsultarActividadJs = {
    urlObtenerActividades: "",
    Inicializar: function () {
        ListarActividades();
    }
}


function ListarActividades() {
    $('#table_User').DataTable({
        serverSide: true,
        processing: true,
        ajax: {
            dataType: 'json',
            type: "POST",
            url: ConsultarActividadJs.urlObtenerActividades,                     
        },
        pageLength: 10,
        lengthMenu: [5, 10, 25],
        columns: [
            {
                name: 'Id',
                data: 'Id',
                title: 'Id',
                orderable: true
            },
            {
                name: 'NumeroPredial',
                data: 'NumeroPredial',
                title: 'Numero Predial',
                orderable: true,
                searchable: true
            },
            {
                name: 'Departamento',
                data: 'Departamento',
                title: 'Departamento',
                orderable: true
            }, {
                name: 'Municipio',
                data: 'Municipio',
                title: 'Municipio',
                orderable: true
            }, {
                name: 'Fecha',
                data: 'Fecha',
                title: 'Fecha',
                orderable: true,
                render: function (data, type, full) {
                   var mDate = moment(data);
                   return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            }
        ],
    });
}