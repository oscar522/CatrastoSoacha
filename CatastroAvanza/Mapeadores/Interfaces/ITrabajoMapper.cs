using CatastroAvanza.Models;
using CatastroAvanza.Models.Trabajo;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;

namespace CatastroAvanza.Mapeadores
{
    public interface ITrabajoMapper
    {
        ActividadTrabajo MapViewModelToEntidad(CrearTrabajoViewModel model, AuditoriaModel auditoriaModel);

        ActividadTrabajo MapViewModelToEntidad(ActualizarTrabajoViewModel model, AuditoriaModel auditoriaModel, ActividadTrabajo entidad);

        ICollection<TrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<ActividadTrabajo> model);

        TrabajoViewModel MapEntidadToViewModel(ActividadTrabajo model);

        AsociacionTrabajoActividadGestor MapViewModelToEntidad(CreaAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        AsociacionTrabajoActividadGestor MapViewModelToEntidad(ActualizarAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel, AsociacionTrabajoActividadGestor entidad);

        ICollection<AsignacionTrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<AsociacionTrabajoActividadGestor> model);

        AsignacionTrabajoViewModel MapEntidadToViewModel(AsociacionTrabajoActividadGestor model);

        ActividadTrabajoGestion MapViewModelToEntidad(CrearGestionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        ActividadTrabajoGestion MapViewModelToEntidad(ActualizarGestionTrabajoViewModel model, AuditoriaModel auditoriaModel, ActividadTrabajoGestion entidad);

        ICollection<GestionTrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<ActividadTrabajoGestion> model);

        GestionTrabajoViewModel MapEntidadToViewModel(ActividadTrabajoGestion model);
    }
}