using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Trabajo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Contratos
{
    public interface ITrabajoLogic
    {
        Task<int> CrearTrabajo(CrearTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> ActualizarTrabajo(ActualizarTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> EliminarTrabajo(int idTrabajo, AuditoriaModel auditoriaModel);

        Task<DataTablesResponse> ConsultarTrabajosAdministrador(IDataTablesRequest modelo);

        Task<DataTablesResponse> ConsultarTrabajos(IDataTablesRequest modelo, string usuario);

        Task<TrabajoViewModel> ConsultarTrabajoPorId(int Id);

        Task<ActualizarTrabajoViewModel> ConsultarTrabajoPorIdParaActualizar(int Id);

        Task<int> CrearAsignacionTrabajo(CreaAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> ActualizarAsignacionTrabajo(ActualizarAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> EliminarAsignacionTrabajo(int idAsignacion, AuditoriaModel auditoriaModel);

        Task<DataTablesResponse> ConsultarAsignaciones(IDataTablesRequest modelo);

        Task<AsignacionTrabajoViewModel> ConsultarAsignacionPorId(int Id);

        Task<AsignacionTrabajoViewModel> ConsultarAsignacionPorIdTrabajo(int Id, string usuario);

        Task<int> CrearGestionTrabajo(CrearGestionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> ActualizarGestionTrabajo(ActualizarGestionTrabajoViewModel model, AuditoriaModel auditoriaModel);

        Task<int> EliminarGestionTrabajo(int idGestion, AuditoriaModel auditoriaModel);

        Task<DataTablesResponse> ConsultarGestiones(IDataTablesRequest modelo, int idAsignacion, string usuario);

        Task<GestionTrabajoViewModel> ConsultarGestionPorId(int Id, string usuario);

        Task<ActualizarGestionTrabajoViewModel> ConsultarGestionPorIdparaActualizar(int Id, string usuario);

        Task<TrabajoVolumenViewModel> ConsultarVolumenDiario();

        Task<TrabajoEstadoViewModel> ConsultarEstados();

        Task<DataTablesResponse> ConsultarUsuariosAsignaciones(IDataTablesRequest modelo);

        Task<ICollection<TrabajoViewModel>> ConsultarTrabajosPadres(string term);

        Task<ICollection<TrabajoJerarquia>> ConsultarTrabajosPorIdPadres(int IdPadre);

        Task<GraficaTrabajoViewModel> TraerConteoActividadesPorEstado(int IdPadre);

        Task<GraficaTrabajoViewModel> TraerConteoActividadesPorEstadoYFecha(int IdPadre, DateTime fecha);

        Task<GraficaTrabajoViewModel> TraerConteoUsuariosAsignadosActividad();

        Task<GraficaTrabajoViewModel> TraerConteoTotalProyecto();
    }
}