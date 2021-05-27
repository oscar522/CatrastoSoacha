using CatastroAvanza.Infraestructura;
using CatastroAvanza.Infraestructura.ContratosServicios;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class ActividadLogic : IActividadLogic
    {
        public ActividadLogic(IApplicationDbContext contexto, IMapeadoresApplicacion mapper, IAlmacenamientoArchivos almacenamiento)
        {
            _contexto = contexto;
            _mapper = mapper;
            _almacenamiento = almacenamiento;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IMapeadoresApplicacion _mapper;
        private readonly IAlmacenamientoArchivos _almacenamiento;


        public async Task<int> CrearActividad(ActividadPredioViewModel model)
        {
            try
            {
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

        public async Task<List<ActividadConsultaViewModel>> ConsultarActividades()
        {
            try
            {
                var actividades = _contexto.Actividad.ToList();

                var listaActividades = _mapper.MapDataAModel(actividades, _contexto.Ciudad.ToList(), _contexto.Departamento.ToList());

                return listaActividades;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return new List<ActividadConsultaViewModel>();
            }
        }
    }
}