﻿var ConsultarActividadJs = {
    urlObtenerActividades: "",
    urlActualizarActividad: "",
    Inicializar: function () {
        ListarActividades();
    }
}


function ListarActividades() {
    $('#actividadesTbl').DataTable({
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
                    return "<a class='btn btn-outline-primary' title='Actualizar' href='" + ConsultarActividadJs.urlActualizarActividad + "?actividadId=" + data + "'><i class='fa fa-edit'></i></a>";
                }
            }
            , {
                name: 'Id',
                data: 'Id',
                title: '',
                width: "5%",
                render: function (data, type, full) {
                    return "<a class='btn btn-outline-danger' title='Eliminar' href='#'><i class='fa fa-trash'></i></a>";
                }
            }
        ],
    });
}