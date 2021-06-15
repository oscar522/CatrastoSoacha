using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores
{
    public interface IActividadMapper
    {
        Actividad MapModelAData(ActividadPredioViewModel model);

        Actividad MapModelAData(ActividadPredioViewModel model, Actividad result);

        ActividadPredioViewModel MapDataAModel(Actividad model);

        List<ActividadConsultaViewModel> MapDataAModel(List<Actividad> actividades, List<ctciudad> ciudad, List<ctdepto> dpto);
    }
}
