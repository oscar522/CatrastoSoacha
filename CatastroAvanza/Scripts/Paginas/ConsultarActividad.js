var ConsultarActividadJs = {
    urlObtenerActividades: "",
    Inicializar: function () {
        ListarActividades();
    }
}


function ListarActividades() {
    $('#actividadesTbl').DataTable({
        serverSide: true,
        processing: true,
        "ajax": {
            dataType: 'json',
            type: "POST",
            url: ConsultarActividadJs.urlObtenerActividades,
            dataSrc: 'Result',
        },
        'aoColumns': [
            { mDataProp: 'Id', title: 'Id' },
            { mDataProp: 'NumeroPredial', title: 'Numero Predial' },
            { mDataProp: 'Departamento', title: 'Departamento' },
            { mDataProp: 'Municipio', title: 'Municipio' },
            {
                mDataProp: 'Fecha', title: 'Fecha', render: function (data, type, full) {
                    var mDate = moment(data);
                    return (mDate && mDate.isValid()) ? mDate.format('YYYY-MM-DD') : '';
                }
            },
        ]
    });
}