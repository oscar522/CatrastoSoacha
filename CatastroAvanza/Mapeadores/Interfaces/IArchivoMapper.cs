using CatastroAvanza.Models;
using CatastroAvanza.Models.Archivo;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores.Interfaces
{
    public interface IArchivoMapper
    {
        Archivo MapViewModelToEntidad(CrearArchivoViewModel model, AuditoriaModel auditoriaModel);

        ICollection<ArchivoViewModel> MapListaEntidadesToListaViewModel(ICollection<Archivo> model);
    }
}