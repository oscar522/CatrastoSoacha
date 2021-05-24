using CatastroAvanza.Infraestructura.ContratosServicios;
using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
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
                    _almacenamiento.GuardarArchivoFisico(model.Files.Fmi);
                    _almacenamiento.GuardarArchivoFisico(model.Files.CertificadoNomenclatura);
                    _almacenamiento.GuardarArchivoFisico(model.Files.FotoFachada);
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
    }
}