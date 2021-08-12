using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Infraestructura;
using CatastroAvanza.Infraestructura.ContratosServicios;
using CatastroAvanza.Mapeadores.Interfaces;
using CatastroAvanza.Models;
using CatastroAvanza.Models.Archivo;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class ArchivoLogic : IArchivoLogic
    {
        public ArchivoLogic(IApplicationDbContext context, IArchivoMapper mapper, ISecurityLogic security, IAlmacenamientoArchivos almacenamiento)
        {
            _contexto = context;
            _mapper = mapper;
            _security = security;
            _almacenamiento = almacenamiento;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IArchivoMapper _mapper;
        private readonly ISecurityLogic _security;
        private readonly IAlmacenamientoArchivos _almacenamiento;

        public async Task<DataTablesResponse> ConsultarArchivos(IDataTablesRequest modelo)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                ArchivoColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(ArchivoColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (ArchivoColumnasOrdenables)Enum.Parse(typeof(ArchivoColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var archivos = _contexto.Archivos.AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    archivos = archivos.Where(m => m.Nombre == modelo.Search.Value);
                }

                if (orderByDescending)
                    archivos = archivos.OrderBy(m => columnaOrdenar);
                else
                    archivos = archivos.OrderByDescending(m => columnaOrdenar);

                var listadoAsignaciones = archivos.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listaAsignaciones = _mapper.MapListaEntidadesToListaViewModel(listadoAsignaciones);

                var tabla = new DataTablesResponse(modelo.Draw, listaAsignaciones, _contexto.Archivos.Count(), listadoAsignaciones.Count);

                return tabla;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new DataTablesResponse(modelo.Draw, new List<ArchivoViewModel>(), 0, 0);
            }
        }

        public async Task<int> CrearArchivo(CrearArchivoViewModel model, AuditoriaModel auditoriaModel)
        {
            try
            {

                if (_contexto.Archivos.Where(m => m.Nombre == model.Nombre).Any())
                    return 0;

                Archivo entidad = _mapper.MapViewModelToEntidad(model, auditoriaModel);                

                _contexto.Archivos.Add(entidad);

                _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Archivo,"Archivo_General"));

                await _contexto.SaveChangesAsync();

                return entidad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }

        public async Task<ArchivoDescargaViewModel> DescargarArchivo(int ArchivoId)
        {
            try
            {

                Archivo entidad = await _contexto.Archivos.Where(m => m.Id == ArchivoId).FirstOrDefaultAsync();

                if (entidad == null)
                    return new ArchivoDescargaViewModel();

                FileStream archivo = _almacenamiento.TraerArchivoFisico(entidad.NombreFisico, "Archivo_General");

                return new ArchivoDescargaViewModel(entidad.NombreFisico, archivo);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new ArchivoDescargaViewModel();
            }
        }
    }
}