using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores
{
    public interface IMapeadoresApplicacion
    {
        DataForm1Model MapDataAModel(
            R1_2021_69295_PREDIOS predio2021, string cantidadMejora,
            ICollection<R1_2021_69295_PREDIOS> predios2021,
            ICollection<R2_2021_69295_CONSTRUCCIONES> construcciones2021, 
            ICollection<R1_2020_66069_PREDIOS> predios2020);

        ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctcatalogo> catalogos);

        ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctdepto> departamento);

        ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctciudad> ciudades);

        Actividad MapModelAData(ActividadPredioViewModel model);
    }
}
