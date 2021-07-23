using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Trabajo;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class TrabajoLogic : ITrabajoLogic
    {
        public TrabajoLogic(IApplicationDbContext context, ITrabajoMapper mapper, ISecurityLogic security)
        {
            _contexto = context;
            _mapper = mapper;
            _security = security;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly ITrabajoMapper _mapper;
        private readonly ISecurityLogic _security;

        public async Task<int> CrearAsignacionTrabajo(CreaAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajo trabajo =  await _contexto.Trabajo.Where(m => m.Id == model.IdActividad).FirstOrDefaultAsync();

                if(trabajo == null)
                    return 0;

                if(!trabajo.Estado)
                    return 0;

                AsociacionTrabajoActividadGestor entidad = _mapper.MapViewModelToEntidad(model, auditoriaModel);

                _contexto.AsociacionTrabajoGestor.Add(entidad);


                await _contexto.SaveChangesAsync();

                return entidad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> CrearGestionTrabajo(CrearGestionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                AsociacionTrabajoActividadGestor trabajoGestion = await _contexto.AsociacionTrabajoGestor.Where(m => m.Id == model.IdAsignacion).FirstOrDefaultAsync();
                if (trabajoGestion == null)
                    return 0;

                if (!trabajoGestion.Estado)
                    return 0;

                ActividadTrabajo trabajo = await _contexto.Trabajo.Where(m => m.Id == trabajoGestion.IdActividad).FirstOrDefaultAsync();

                if (trabajo == null)
                    return 0;

                if (!trabajo.Estado)
                    return 0;

                ActividadTrabajoGestion entidad = _mapper.MapViewModelToEntidad(model, auditoriaModel);

                _contexto.TrabajoGestion.Add(entidad);

                await _contexto.SaveChangesAsync();

                return entidad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> CrearTrabajo(CrearTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajo entidad = _mapper.MapViewModelToEntidad(model, auditoriaModel);

                _contexto.Trabajo.Add(entidad);

                await _contexto.SaveChangesAsync();

                return entidad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> ActualizarAsignacionTrabajo(ActualizarAsignacionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajo trabajo = await _contexto.Trabajo.Where(m => m.Id == model.IdActividad).FirstOrDefaultAsync();

                if (trabajo == null)
                    return 0;

                if (!trabajo.Estado)
                    return 0;

                AsociacionTrabajoActividadGestor asignacion = await _contexto.AsociacionTrabajoGestor.Where(m => m.Id == model.Id).FirstOrDefaultAsync();

                if (asignacion == null)
                    return 0;

                if (!asignacion.Estado)
                    return 0;

                asignacion = _mapper.MapViewModelToEntidad(model, auditoriaModel, asignacion);

                await _contexto.SaveChangesAsync();

                return asignacion.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> ActualizarGestionTrabajo(ActualizarGestionTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                AsociacionTrabajoActividadGestor asignacion = await _contexto.AsociacionTrabajoGestor.Where(m => m.Id == model.IdAsignacion).FirstOrDefaultAsync();

                if (asignacion == null)
                    return 0;

                if (!asignacion.Estado)
                    return 0;

                ActividadTrabajoGestion trabajoGestion = await _contexto.TrabajoGestion.Where(m => m.Id == model.Id).FirstOrDefaultAsync();

                if (trabajoGestion == null)
                    return 0;

                if (!trabajoGestion.EstadoRegistro)
                    return 0;

                trabajoGestion = _mapper.MapViewModelToEntidad(model, auditoriaModel, trabajoGestion);                

                await _contexto.SaveChangesAsync();

                return trabajoGestion.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> ActualizarTrabajo(ActualizarTrabajoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajo trabajo = await _contexto.Trabajo.Where(m => m.Id == model.Id).FirstOrDefaultAsync();

                if (trabajo == null)
                    return 0;

                if (!trabajo.Estado)
                    return 0;

                trabajo = _mapper.MapViewModelToEntidad(model, auditoriaModel, trabajo);                

                await _contexto.SaveChangesAsync();

                return trabajo.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> EliminarAsignacionTrabajo(int idAsignacion, AuditoriaModel auditoriaModel)
        {
            try
            {
                AsociacionTrabajoActividadGestor asignacion = await _contexto.AsociacionTrabajoGestor.Where(m => m.Id == idAsignacion).FirstOrDefaultAsync();

                if (asignacion == null)
                    return 0;

                if (!asignacion.Estado)
                    return 0;

                asignacion.Estado=false;                

                await _contexto.SaveChangesAsync();

                return asignacion.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> EliminarGestionTrabajo(int idGestion, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajoGestion trabajoGestion = await _contexto.TrabajoGestion.Where(m => m.Id == idGestion).FirstOrDefaultAsync();

                if (trabajoGestion == null)
                    return 0;

                if (!trabajoGestion.EstadoRegistro)
                    return 0;

                trabajoGestion.EstadoRegistro = false;

                await _contexto.SaveChangesAsync();

                return trabajoGestion.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<int> EliminarTrabajo(int idTrabajo, AuditoriaModel auditoriaModel)
        {
            try
            {
                ActividadTrabajo trabajo = await _contexto.Trabajo.Where(m => m.Id == idTrabajo).FirstOrDefaultAsync();

                if (trabajo == null)
                    return 0;

                if (!trabajo.Estado)
                    return 0;

                trabajo.Estado = false;

                await _contexto.SaveChangesAsync();

                return trabajo.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<DataTablesResponse> ConsultarAsignaciones(IDataTablesRequest modelo)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                TrabajoAsignacionesColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(TrabajoAsignacionesColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (TrabajoAsignacionesColumnasOrdenables)Enum.Parse(typeof(TrabajoAsignacionesColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var asignaciones = _contexto.AsociacionTrabajoGestor.AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    asignaciones = asignaciones.Where(m => m.UserAsignado == modelo.Search.Value);
                }

                if (orderByDescending)
                    asignaciones = asignaciones.OrderBy(m => columnaOrdenar);
                else
                    asignaciones = asignaciones.OrderByDescending(m => columnaOrdenar);

                var listadoAsignaciones = asignaciones.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listaAsignaciones = _mapper.MapListaEntidadesToListaViewModel(listadoAsignaciones);

                var tabla = new DataTablesResponse(modelo.Draw, listaAsignaciones, _contexto.AsociacionTrabajoGestor.Count(), listadoAsignaciones.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<AsignacionTrabajoViewModel>(), 0, 0);
            }
        }

        public async Task<AsignacionTrabajoViewModel> ConsultarAsignacionPorId(int Id)
        {
            try
            {
                var asignacion = _contexto.AsociacionTrabajoGestor.Where(m => m.Id == Id)
                    .FirstOrDefault();

                if (asignacion == null)
                    return new AsignacionTrabajoViewModel();

                AsignacionTrabajoViewModel result = _mapper.MapEntidadToViewModel(asignacion);

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new AsignacionTrabajoViewModel();
            }
        }

        public async Task<DataTablesResponse> ConsultarGestiones(IDataTablesRequest modelo, int idAsignacion, string usuario)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                TrabajoGestionColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(TrabajoGestionColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (TrabajoGestionColumnasOrdenables)Enum.Parse(typeof(TrabajoGestionColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var gestiones = _contexto.TrabajoGestion.Where(m=> m.IdAsignacion  == idAsignacion && m.CreadoPor ==  usuario).AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    gestiones = gestiones.Where(m => m.EstadoGestion == modelo.Search.Value);
                }

                if (orderByDescending)
                    gestiones = gestiones.OrderBy(m => columnaOrdenar);
                else
                    gestiones = gestiones.OrderByDescending(m => columnaOrdenar);

                var listadoGestiones = gestiones.Skip(modelo.Start).Take(modelo.Length).ToList();

                
                var listaGestiones = _mapper.MapListaEntidadesToListaViewModel(listadoGestiones);

                foreach (var gestion in listaGestiones)
                {
                    int.TryParse(gestion.EstadoGestion, out int estadoId);
                    if(estadoId > 0)
                        gestion.EstadoGestion = _contexto.Catalogo.FirstOrDefault(m => m.Id == (int)estadoId)?.Nombre;
                }


                var tabla = new DataTablesResponse(modelo.Draw, listaGestiones, _contexto.AsociacionTrabajoGestor.Count(), listaGestiones.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<GestionTrabajoViewModel>(), 0, 0);
            }
        }

        public async Task<GestionTrabajoViewModel> ConsultarGestionPorId(int Id, string usuario)
        {
            try
            {
                var gestion = _contexto.TrabajoGestion.Where(m => m.Id == Id && m.CreadoPor == usuario)
                    .FirstOrDefault();

                if (gestion == null)
                    return new GestionTrabajoViewModel();

                GestionTrabajoViewModel result = _mapper.MapEntidadToViewModel(gestion);



                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new GestionTrabajoViewModel();
            }
        }

        public async Task<TrabajoViewModel> ConsultarTrabajoPorId(int Id)
        {
            try
            {
                var trabajo = _contexto.Trabajo.Where(m => m.Id == Id)
                    .FirstOrDefault();

                if (trabajo == null)
                    return new TrabajoViewModel();

                TrabajoViewModel result = _mapper.MapEntidadToViewModel(trabajo);

                result.RolNombre = _security.GetRolesById(result.Rol)?.Name;

                return result;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new TrabajoViewModel();
            }
        }

        public async Task<DataTablesResponse> ConsultarTrabajos(IDataTablesRequest modelo, string usuario)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                TrabajoColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(TrabajoColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (TrabajoColumnasOrdenables)Enum.Parse(typeof(TrabajoColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }
                
                

                var trabajos = _contexto.Trabajo.AsQueryable();

                trabajos = trabajos
                    .Join(_contexto.AsociacionTrabajoGestor, 
                        tr => tr.Id,
                        asi => asi.IdActividad,
                        (tr, asi) => new {
                            usuarioAsignado = asi.UserAsignado,
                            trabajo = tr
                        })
                    .Where(m => m.usuarioAsignado ==  usuario)
                    .Select(j=> j.trabajo);

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    trabajos = trabajos.Where(m => m.Nombre.ToUpper().Contains(modelo.Search.Value.ToUpper()));
                }

                if (orderByDescending)
                    trabajos = trabajos.OrderBy(m => columnaOrdenar);
                else
                    trabajos = trabajos.OrderByDescending(m => columnaOrdenar);

                var listadoGestiones = trabajos.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listaGestiones = _mapper.MapListaEntidadesToListaViewModel(listadoGestiones);

                foreach (var gestion in listaGestiones)
                {
                    gestion.RolNombre = _security.GetRolesById(gestion.Rol)?.Name;
                }

                var tabla = new DataTablesResponse(modelo.Draw, listaGestiones, _contexto.AsociacionTrabajoGestor.Count(), listadoGestiones.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<GestionTrabajoViewModel>(), 0, 0);
            }
        }

        public async Task<DataTablesResponse> ConsultarTrabajosAdministrador(IDataTablesRequest modelo)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                TrabajoColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(TrabajoColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (TrabajoColumnasOrdenables)Enum.Parse(typeof(TrabajoColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var trabajos = _contexto.Trabajo.AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    trabajos = trabajos.Where(m => m.Nombre.ToUpper().Contains(modelo.Search.Value.ToUpper()));
                }

                if (orderByDescending)
                    trabajos = trabajos.OrderBy(m => columnaOrdenar);
                else
                    trabajos = trabajos.OrderByDescending(m => columnaOrdenar);

                var listadoGestiones = trabajos.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listaGestiones = _mapper.MapListaEntidadesToListaViewModel(listadoGestiones);

                foreach (var gestion in listaGestiones)
                {
                    gestion.RolNombre = _security.GetRolesById(gestion.Rol)?.Name;
                }

                var tabla = new DataTablesResponse(modelo.Draw, listaGestiones, _contexto.AsociacionTrabajoGestor.Count(), listadoGestiones.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<GestionTrabajoViewModel>(), 0, 0);
            }
        }

        public async Task<AsignacionTrabajoViewModel> ConsultarAsignacionPorIdTrabajo(int Id, string usuario)
        {
            try
            {
                var asignacion = _contexto.AsociacionTrabajoGestor.Where(m => m.IdActividad == Id && m.UserAsignado ==  usuario)
                    .FirstOrDefault();

                if (asignacion == null)
                    return new AsignacionTrabajoViewModel();

                AsignacionTrabajoViewModel asignacionModel = _mapper.MapEntidadToViewModel(asignacion);


                asignacionModel.NombreActividad = _contexto.Trabajo.FirstOrDefault(m=> m.Id == asignacion.IdActividad)?.Nombre;                

                return asignacionModel;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new AsignacionTrabajoViewModel();
            }
        }

        public async Task<TrabajoVolumenViewModel> ConsultarVolumenDiario()
        {
            TrabajoVolumenViewModel volumen = new TrabajoVolumenViewModel();

            var fechaHoy = DateTime.Now.Date;
            
            volumen.TrabajosCreados = _contexto.Trabajo.Where(m => m.FechaCreacion >= fechaHoy).Count();
            volumen.TrabajosAsignados = _contexto.AsociacionTrabajoGestor.Where(m => m.Estado == true && m.FechaCreacion >= fechaHoy).Select(t=> t.IdActividad).Distinct().Count();
            volumen.TrabajosCerrados = _contexto.Trabajo.Where(m => m.Estado == false && m.FechaUltimaModificacion >= fechaHoy).Count();
            volumen.GestionDiaria = _contexto.TrabajoGestion.Where(m => m.FechaUltimaModificacion >= fechaHoy).Count();

            volumen.SetTotal();

            return volumen;
        }

        public async Task<TrabajoEstadoViewModel> ConsultarEstados()
        {
            try
            {
                var estadosGestion = _contexto.Catalogo.Where(m => m.Tipo == CatalogosEnum.EstadoGestion.ToString()).ToList();

                TrabajoEstadoViewModel result = new TrabajoEstadoViewModel();

                foreach (var estado in estadosGestion)
                {
                    var cuenta = 0;
                    string estadoId = estado.Id.ToString();
                    if (_contexto.TrabajoGestion.Any(m => m.EstadoGestion == estadoId))
                        cuenta = _contexto.TrabajoGestion.Where(m => m.EstadoGestion == estadoId).Count();

                    result.AddEstado(estado.Nombre, cuenta);                    
                }

                result.SetTotal();

                return result;

            }catch(Exception ex)
            {
                return new TrabajoEstadoViewModel();
            }

        }

        public async Task<DataTablesResponse> ConsultarUsuariosAsignaciones(IDataTablesRequest modelo)
        {
            try
            {
                ICollection<UsuarioTrabajoViewModel> asignacionesBoard = new List<UsuarioTrabajoViewModel>();
                var trabajos = _contexto.AsociacionTrabajoGestor.Select(m=> m.UserAsignado).Distinct().AsQueryable();

                trabajos = trabajos.OrderByDescending(m => m);

                var listadoasignaciones = trabajos.Skip(modelo.Start).Take(modelo.Length).ToList();
                

                foreach (var asignacion in listadoasignaciones)
                {
                    UsuarioTrabajoViewModel usuarioAsig = new UsuarioTrabajoViewModel();
                    usuarioAsig.NumeroAsignaciones = _contexto.AsociacionTrabajoGestor.Where(m=> m.UserAsignado == asignacion).Count();
                    usuarioAsig.NumeroGestiones = _contexto.AsociacionTrabajoGestor.Where(m => m.UserAsignado == asignacion).Count();
                    var usuario = await _security.GetUsuariosByName(asignacion);
                    if (!usuario.Any())
                        continue;

                    usuarioAsig.Usuario = usuario.FirstOrDefault().Email;
                    usuarioAsig.NombreUsuario = $"{usuario.FirstOrDefault().Nombres} {usuario.FirstOrDefault().Apellidos}";
                    
                    asignacionesBoard.Add(usuarioAsig);
                }

                var tabla = new DataTablesResponse(modelo.Draw, asignacionesBoard, _contexto.AsociacionTrabajoGestor.Select(m => m.UserAsignado).Distinct().Count(), asignacionesBoard.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<UsuarioTrabajoViewModel>(), 0, 0);
            }
        }
    }
}