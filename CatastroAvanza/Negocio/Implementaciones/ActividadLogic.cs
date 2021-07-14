using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Infraestructura;
using CatastroAvanza.Infraestructura.ContratosServicios;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.ActividadViewModels;
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
    public class ActividadLogic : IActividadLogic
    {
        public ActividadLogic(IApplicationDbContext contexto, IActividadMapper mapper, IAlmacenamientoArchivos almacenamiento)
        {
            _contexto = contexto;
            _mapper = mapper;
            _almacenamiento = almacenamiento;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IActividadMapper _mapper;
        private readonly IAlmacenamientoArchivos _almacenamiento;


        public async Task<int> CrearActividad(ActividadPredioViewModel model)
        {
            try
            {
                if (model.Terreno.TieneArea)
                {
                    var unidad = _contexto.UnidadArea.Where(m => m.Id == model.Terreno.UnidadArea).FirstOrDefault();
                    if (unidad == null)
                        return 0;
                    
                    model.Terreno.AreaTerrenoEnMetros = unidad.Valor * model.Terreno.AreaTerreno;
                    decimal areaTerrenoInformacion = 0;                    
                    model.Terreno.PorcentajeAreaJudicialAreaCatastral = (model.Terreno.AreaTerrenoEnMetros * 100) / model.Informacion.AreaTerreno;
                }

                Actividad actividad = _mapper.MapModelAData(model);


                _contexto.Actividad.Add(actividad);

                if(model.Files != null)
                {
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Fmi, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.CertificadoNomenclatura, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.FotoFachada, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Croquis, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Escrituras, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.FichaPredial, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Plano, actividad.General_NumeroPredial));                    
                }                

                await _contexto.SaveChangesAsync();

                return actividad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }            
        }

        public async Task<int> ActualizarActividad(ActividadPredioViewModel model)
        {
            try
            {                

                if (model.Terreno.TieneArea)
                {
                    var unidad = _contexto.UnidadArea.Where(m => m.Id == model.Terreno.UnidadArea).FirstOrDefault();
                    if (unidad == null)
                        return 0;

                    model.Terreno.AreaTerrenoEnMetros = unidad.Valor * model.Terreno.AreaTerreno;
                    decimal areaTerrenoInformacion = 0;
                    model.Terreno.PorcentajeAreaJudicialAreaCatastral = (model.Terreno.AreaTerrenoEnMetros * 100) / model.Informacion.AreaTerreno;
                }

                Actividad actividad = await _contexto.Actividad.Where(m=> m.Id == model.Id).SingleOrDefaultAsync();

                if (actividad == null)
                    return 0;

                actividad = _mapper.MapModelAData(model, actividad);

                var resultado = await _contexto.SaveChangesAsync();

                if (model.Files != null)
                {
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Fmi, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.CertificadoNomenclatura, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.FotoFachada, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Croquis, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Escrituras, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.FichaPredial, actividad.General_NumeroPredial));
                    _almacenamiento.GuardarArchivoFisico(new InformationDocumento(model.Files.Plano, actividad.General_NumeroPredial));
                }
                
                return actividad.Id;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return 0;
            }
        }


        public async Task<ActividadPredioViewModel> ConsultarActividadPorId(int Id)
        {
            try {
                var actividad = _contexto.Actividad.Where(m => m.Id == Id)                                        
                    .FirstOrDefault();
                
                if (actividad == null)
                    return new ActividadPredioViewModel();

                ActividadPredioViewModel result = _mapper.MapDataAModel(actividad);

                return result;
            } 
            catch (Exception ex) 
            {
                return new ActividadPredioViewModel();
            }
        }

        public async Task<DataTablesResponse> ConsultarActividades(IDataTablesRequest modelo)
        {
            try
            {
                var sortedColumn = modelo.Columns.GetSortedColumns().Where(x => x.OrderNumber == 0).FirstOrDefault();
                ActividadesColumnasOrdenables? columnaOrdenar = null;
                bool orderByDescending = false;
                if (sortedColumn != null && Enum.GetNames(typeof(ActividadesColumnasOrdenables)).Contains(sortedColumn.Name))
                {
                    columnaOrdenar = (ActividadesColumnasOrdenables)Enum.Parse(typeof(ActividadesColumnasOrdenables), sortedColumn.Name);
                    orderByDescending = sortedColumn.SortDirection == Column.OrderDirection.Descendant;
                }

                var actividades = _contexto.Actividad.AsQueryable();

                if (!string.IsNullOrEmpty(modelo.Search.Value))
                {
                    actividades = actividades.Where(m => m.General_NumeroPredial == modelo.Search.Value);
                }

                if (orderByDescending)
                    actividades = actividades.OrderBy(m=> columnaOrdenar);
                else
                    actividades = actividades.OrderByDescending(m => columnaOrdenar);

                var listadoActividades= actividades.Skip(modelo.Start).Take(modelo.Length).ToList();

                var listaActividades = _mapper.MapDataAModel(listadoActividades, _contexto.Ciudad.ToList(), _contexto.Departamento.ToList());

                var tabla = new DataTablesResponse(modelo.Draw, listaActividades, _contexto.Actividad.Count(), listadoActividades.Count);

                return tabla;

            }
            catch (Exception ex)
            {
                string message = ex.Message;                
                return new DataTablesResponse(modelo.Draw, new List<ActividadConsultaViewModel>(), 0, 0); 
            }
        }

        public async Task<List<ActividadExcelModel>> ConsultarActividadExcel()
        {
            var actividades = _contexto.Actividad.AsQueryable();

            var listadoActividades = actividades.ToList();

            var listadoActividadesExcel = _mapper.MapDataIntoModel(listadoActividades);

            listadoActividadesExcel.ForEach(m => {
                var municipio = _contexto.Ciudad.FirstOrDefault(c => c.idctmuncipio == m.General_Municipio);
                var departamento = _contexto.Departamento.FirstOrDefault(c => c.id_ct_depto == m.General_Departamento);
                int coordinador = 0;
                int.TryParse(m.General_Coordinador, out coordinador);
                var coordinadorInfo = _contexto.Catalogo.FirstOrDefault(c => c.Id == coordinador);

                m.General_CoordinadorNombre = coordinadorInfo?.Nombre;
                m.General_DepartamentoNombre = departamento?.nombre;
                m.General_MunicipioNombre = municipio?.nombre;
            });

            return listadoActividadesExcel;
        }
    }
}