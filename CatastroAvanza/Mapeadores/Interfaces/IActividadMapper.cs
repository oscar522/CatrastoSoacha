using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores
{
    public interface IActividadMapper
    {
        Actividad MapModelAData(ActividadPredioViewModel model);

        Actividad MapModelAData(ActividadPredioViewModel model, Actividad result, string usuarioModificacion);

        ActividadPredioViewModel MapDataAModel(Actividad model);

        List<ActividadConsultaViewModel> MapDataAModel(List<Actividad> actividades, List<ctciudad> ciudad, List<ctdepto> dpto);

        List<ActividadExcelModel> MapDataIntoModel(List<Actividad> actividades);
    }
}
