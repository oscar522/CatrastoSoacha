using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.ActividadesDiarias;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class ActividadDiariaLogic : IActividadDiariaLogic
    {
        public ActividadDiariaLogic(IApplicationDbContext contexto, IMapeadoresApplicacion mapper, ISecurityLogic security)
        {
            _contexto = contexto;
            _mapper = mapper;
            _security = security;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IMapeadoresApplicacion _mapper;
        private readonly ISecurityLogic _security;

        public async Task<int> CrearActividad(ActividadesDiariasViewModel modelo)
        {
            try 
            {
                ActividadDiaria actividadDiaria = _mapper.MapModelAData(modelo);
               
                _contexto.ActividadDiaria.Add(actividadDiaria);

                await _contexto.SaveChangesAsync();

                return actividadDiaria.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }            
        }

        public async Task<DataTablesResponse> GetActividadesCreadas(IDataTablesRequest modelo)
        {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                ActividadesColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(ActividadesColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (ActividadesColumnasOrdenables)Enum.Parse(typeof(ActividadesColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var actividades = _contexto.ActividadDiaria.AsQueryable();
                int actividadesTotales = _contexto.ActividadDiaria.Count();

                if (orderByDescending)
                    actividades = actividades.OrderBy(m => columnaOrdenar);
                else
                    actividades = actividades.OrderByDescending(m => columnaOrdenar);

                var listadoActividades = actividades.Skip(modelo.Start).Take(modelo.Length).ToList();
               
                var listaActividades = _mapper.MapDataAModel(listadoActividades);

                listaActividades.ForEach(m => {

                    var actividad = listadoActividades.FirstOrDefault(la => la.Id == m.Id);
                    var municipio = _contexto.Ciudad.FirstOrDefault(c => c.idctmuncipio == actividad.IdMunicipio);
                    var departamento = _contexto.Departamento.FirstOrDefault(c => c.id_ct_depto == actividad.IdDepartamento);

                    m.NombreActividad = _contexto.TipoActividad.Where(a => a.Id == actividad.IdActividad).FirstOrDefault()?.Actividad;
                    m.NombreModalidad = _contexto.Catalogo.Where(a => a.Id == actividad.IdModalidad).FirstOrDefault()?.Nombre;
                    m.NombreProceso = _contexto.Catalogo.Where(a => a.Id == actividad.IdProceso).FirstOrDefault()?.Nombre;
                    m.NombreRolActividad = _security.GetRolesById(actividad.IdRol)?.Name;
                    m.RolUsuario = _security.GetRolesByUserId(actividad.IdApsNetUser)?.Name;
                    m.DepartamentoMunicipio = $"{departamento?.nombre}-{municipio?.nombre}";
                    
                });

                var tabla = new DataTablesResponse(modelo.Draw, listaActividades, actividadesTotales, listadoActividades.Count);

                return tabla;
        }

        public async Task<IEnumerable<ActividadesDiariasExcelModel>> GetActividadesDiarias()
        {
            var actividades = _contexto.ActividadDiaria.AsQueryable();

            var listadoActividades = actividades.ToList();

            var listaActividadesMapeadas = _mapper.MapDataIntoModel(listadoActividades);

            listaActividadesMapeadas.ForEach(m => {

                var actividad = listadoActividades.FirstOrDefault(la => la.Id == m.Id);
                var municipio = _contexto.Ciudad.FirstOrDefault(c => c.idctmuncipio == actividad.IdMunicipio);
                var departamento = _contexto.Departamento.FirstOrDefault(c => c.id_ct_depto == actividad.IdDepartamento);

                m.NombreActividad = _contexto.TipoActividad.Where(a => a.Id == actividad.IdActividad).FirstOrDefault()?.Actividad;
                m.NombreModalidad = _contexto.Catalogo.Where(a => a.Id == actividad.IdModalidad).FirstOrDefault()?.Nombre;
                m.NombreProceso = _contexto.Catalogo.Where(a => a.Id == actividad.IdProceso).FirstOrDefault()?.Nombre;
                m.NombreRolActividad = _security.GetRolesById(actividad.IdRol)?.Name;
                m.RolUsuario = _security.GetRolesByUserId(actividad.IdApsNetUser)?.Name;
                m.Departamento = departamento?.nombre;
                m.Municipio = municipio?.nombre;

            });

            return listaActividadesMapeadas;
        }
    }
}