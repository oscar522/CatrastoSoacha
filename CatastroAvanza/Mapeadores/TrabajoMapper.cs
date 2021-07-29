using CatastroAvanza.Models;
using CatastroAvanza.Models.Trabajo;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Mapeadores
{
    public class TrabajoMapper : ITrabajoMapper
    {
        public TrabajoViewModel MapEntidadToViewModel(ActividadTrabajo model)
        {            

            if (model == null)
                return new TrabajoViewModel();

            TrabajoViewModel result = new TrabajoViewModel
            {
                Rol = model.Rol,
                Cantidad = model.Cantidad,
                CreadoPor = model.CreadoPor,
                FechaCreacion = model.FechaCreacion,
                Estado = model.Estado ? "Activo" : "Inactivo",
                PuntosEsfuerzo = model.PuntosEsfuerzo,
                UltimaModificacionPor = model.UltimaModificacionPor,
                FechaUltimaModificacion = model.FechaUltimaModificacion,
                Id = model.Id,
                Nombre = model.Nombre
            };

            return result;
        }

        public ActualizarTrabajoViewModel MapEntidadToActualizacionViewModel(ActividadTrabajo model)
        {
            if (model == null)
                return new ActualizarTrabajoViewModel();

            ActualizarTrabajoViewModel result = new ActualizarTrabajoViewModel
            {
                Rol = model.Rol,
                Cantidad = model.Cantidad,
                PuntosEsfuerzo = model.PuntosEsfuerzo,
                Id = model.Id,
                Nombre = model.Nombre
            };

            return result;
        }


        public AsignacionTrabajoViewModel MapEntidadToViewModel(AsociacionTrabajoActividadGestor model)
        {

            if (model == null)
                return new AsignacionTrabajoViewModel();

            AsignacionTrabajoViewModel result = new AsignacionTrabajoViewModel
            {
                CreadoPor = model.CreadoPor,
                FechaCreacion = model.FechaCreacion,
                Estado = model.Estado ? "Activo" : "Inactivo",
                FechaAsignacion = model.FechaAsignacion,
                FechaUltimaModificacion = model.FechaUltimaModificacion,
                Id = model.Id,
                IdActividad = model.IdActividad,
                UltimaModificacionPor = model.UltimaModificacionPor,
                UserAsignado = model.UserAsignado,
                UsuarioQueAsigno = model.UsuarioQueAsigno,
                FechaFinalizacionAsignacion = model.FechaEsperadaFinalizacionAsignacion
            };
            return result;
        }

        public GestionTrabajoViewModel MapEntidadToViewModel(ActividadTrabajoGestion model)
        {
            if (model == null)
                return new GestionTrabajoViewModel();

            GestionTrabajoViewModel result = new GestionTrabajoViewModel
            {
                IdAsignacion = model.IdAsignacion,
                EstadoGestion= model.EstadoGestion,
                EstadoRegistro= model.EstadoRegistro ? "Activo" : "Inactivo",
                CreadoPor = model.CreadoPor,
                FechaCreacion = model.FechaCreacion,
                FechaModificacionGestion = model.FechaModificacionGestion,
                FechaUltimaModificacion = model.FechaUltimaModificacion,
                Id = model.Id,
                Observacion = model.Observacion,
                UltimaModificacionPor = model.UltimaModificacionPor
            };

            return result;
        }

        public ICollection<TrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<ActividadTrabajo> model)
        {
            if (model == null)
                return new List<TrabajoViewModel>();

            ICollection<TrabajoViewModel> result = model.Select(m => new TrabajoViewModel
            {
                Rol = m.Rol,
                Cantidad = m.Cantidad,
                CreadoPor = m.CreadoPor,
                FechaCreacion = m.FechaCreacion,
                Estado = m.Estado ? "Activo" : "Inactivo",
                PuntosEsfuerzo = m.PuntosEsfuerzo,
                UltimaModificacionPor = m.UltimaModificacionPor,
                FechaUltimaModificacion = m.FechaUltimaModificacion,
                Id = m.Id,
                Nombre = m.Nombre
            }).ToList();

            return result;
        }

        public ICollection<AsignacionTrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<AsociacionTrabajoActividadGestor> model)
        {
            if (model == null)
                return new List<AsignacionTrabajoViewModel>();

            ICollection<AsignacionTrabajoViewModel> result = model.Select(m => new AsignacionTrabajoViewModel
            {
                CreadoPor = m.CreadoPor,
                FechaCreacion = m.FechaCreacion,
                Estado = m.Estado ? "Activo" : "Inactivo",
                FechaAsignacion = m.FechaAsignacion,
                FechaUltimaModificacion = m.FechaUltimaModificacion,
                Id = m.Id,
                IdActividad = m.IdActividad,
                UltimaModificacionPor = m.UltimaModificacionPor,
                UserAsignado = m.UserAsignado,
                UsuarioQueAsigno = m.UsuarioQueAsigno,
                FechaFinalizacionAsignacion = m.FechaEsperadaFinalizacionAsignacion
            }).ToList();

            return result;
        }

        public ICollection<GestionTrabajoViewModel> MapListaEntidadesToListaViewModel(ICollection<ActividadTrabajoGestion> model)
        {
            if (model == null)
                return new List<GestionTrabajoViewModel>();

            ICollection<GestionTrabajoViewModel> result = model.Select(m => new GestionTrabajoViewModel
            {
                IdAsignacion = m.IdAsignacion,
                EstadoGestion = m.EstadoGestion,
                EstadoRegistro = m.EstadoRegistro ? "Activo" : "Inactivo",
                CreadoPor = m.CreadoPor,
                FechaCreacion = m.FechaCreacion,
                FechaModificacionGestion = m.FechaModificacionGestion,
                FechaUltimaModificacion = m.FechaUltimaModificacion,
                Id = m.Id,
                Observacion = m.Observacion,
                UltimaModificacionPor = m.UltimaModificacionPor,                
            }).ToList();

            return result;
        }

        public ActividadTrabajo MapViewModelToEntidad(CrearTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            if (model == null)
                return new ActividadTrabajo();

            ActividadTrabajo result = new ActividadTrabajo
            {
                Cantidad = model.Cantidad,
                PuntosEsfuerzo = model.PuntosEsfuerzo,
                Nombre = model.Nombre,
                Rol = model.Rol,
                CreadoPor = auditoriaModel.CreadoPor,
                FechaCreacion = auditoriaModel.FechaCreacion,
                FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion,
                UltimaModificacionPor = auditoriaModel.UltimaModificacionPor,
                Estado = true
            };

            return result;

        }

        public ActividadTrabajo MapViewModelToEntidad(ActualizarTrabajoViewModel model, AuditoriaModel auditoriaModel, ActividadTrabajo entidad)
        {
            if (entidad == null)
                return new ActividadTrabajo();

            entidad.Cantidad = model.Cantidad;
            entidad.PuntosEsfuerzo = model.PuntosEsfuerzo;
            entidad.Nombre = model.Nombre;
            entidad.Rol = model.Rol;
            entidad.FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion;
            entidad.UltimaModificacionPor = auditoriaModel.UltimaModificacionPor;
            entidad.Estado = true;

            return entidad;
        }

        public AsociacionTrabajoActividadGestor MapViewModelToEntidad(CreaAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            if (model == null)
                return new AsociacionTrabajoActividadGestor();

            AsociacionTrabajoActividadGestor result = new AsociacionTrabajoActividadGestor
            {
                FechaAsignacion = model.FechaAsignacion,
                IdActividad = model.IdActividad,
                UserAsignado = model.UserAsignado,
                UsuarioQueAsigno = model.UsuarioQueAsigno,
                FechaEsperadaFinalizacionAsignacion = model.FechaFinalizacionEsperada,
                CreadoPor = auditoriaModel.CreadoPor,
                FechaCreacion = auditoriaModel.FechaCreacion,
                FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion,                
                UltimaModificacionPor = auditoriaModel.UltimaModificacionPor,
                Estado = true
            };

            return result;
        }

        public AsociacionTrabajoActividadGestor MapViewModelToEntidad(ActualizarAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel, AsociacionTrabajoActividadGestor entidad)
        {
            if (entidad == null)
                return new AsociacionTrabajoActividadGestor();

            entidad.FechaAsignacion = model.FechaAsignacion;
            entidad.IdActividad = model.IdActividad;
            entidad.UserAsignado = model.UserAsignado;
            entidad.UsuarioQueAsigno = model.UsuarioQueAsigno;
            entidad.FechaEsperadaFinalizacionAsignacion = model.FechaFinalizacionEsperada;
            entidad.FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion;
            entidad.UltimaModificacionPor = auditoriaModel.UltimaModificacionPor;
            entidad.Estado = true;

            return entidad;
        }

        public ActividadTrabajoGestion MapViewModelToEntidad(CrearGestionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            if (model == null)
                return new ActividadTrabajoGestion();

            ActividadTrabajoGestion result = new ActividadTrabajoGestion
            {
                EstadoGestion = model.EstadoGestion,
                EstadoRegistro = true,
                FechaModificacionGestion = model.FechaModificacionGestion,
                IdAsignacion = model.IdAsignacion,
                Observacion = model.Observacion,
                CreadoPor = auditoriaModel.CreadoPor,
                FechaCreacion = auditoriaModel.FechaCreacion,
                FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion,
                UltimaModificacionPor = auditoriaModel.UltimaModificacionPor,
            };

            return result;
        }

        public ActividadTrabajoGestion MapViewModelToEntidad(ActualizarGestionTrabajoViewModel model, AuditoriaModel auditoriaModel, ActividadTrabajoGestion entidad)
        {
            if (entidad == null)
                return new ActividadTrabajoGestion();

            entidad.EstadoGestion = model.EstadoGestion;            
            entidad.FechaModificacionGestion = model.FechaModificacionGestion;
            entidad.Observacion = model.Observacion;
            entidad.FechaUltimaModificacion = auditoriaModel.FechaUltimaModificacion;
            entidad.UltimaModificacionPor = auditoriaModel.UltimaModificacionPor;            

            return entidad;
        }

        public ActualizarGestionTrabajoViewModel MapEntidadToActualizarViewModel(ActividadTrabajoGestion model)
        {
            if (model == null)
                return new ActualizarGestionTrabajoViewModel();

            ActualizarGestionTrabajoViewModel result = new ActualizarGestionTrabajoViewModel
            {
                IdAsignacion = model.IdAsignacion,
                EstadoGestion = model.EstadoGestion,
                EstadoRegistro = model.EstadoRegistro ? "Activo" : "Inactivo",                
                FechaModificacionGestion = model.FechaModificacionGestion.Date,                
                Id = model.Id,
                Observacion = model.Observacion,                
            };

            return result;
        }
    }
}