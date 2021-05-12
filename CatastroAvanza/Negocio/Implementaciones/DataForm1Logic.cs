using CatastroAvanza.Mapeadores;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Negocio.Contratos;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System;
using System.Linq;

namespace CatastroAvanza.Negocio.Implementaciones
{
    public class DataForm1Logic : IDataForm1Logic
    {        
        public DataForm1Logic(IApplicationDbContext contexto, IMapeadoresApplicacion mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        private readonly IApplicationDbContext _contexto;
        private readonly IMapeadoresApplicacion _mapper;

        public DataForm1Model GetUsersById(string id)
        {
            var calculaMejora = id.Substring(0, 16);

            DataForm1Model dataform = new DataForm1Model();
            try
            {
                var predio = _contexto.R1202169295Predios
                .Where(x => x.NUMERO_DEL_PREDIO == id)                
                .FirstOrDefault();

                var cantidadMejora = _contexto.R1202169295Predios.Where(f => f.NUMERO_DEL_PREDIO.Contains(calculaMejora)).Count().ToString();

                var R1202169295Predios = _contexto.R1202169295Predios.Where(f => f.NUMERO_DEL_PREDIO == id).ToList();

                var R1202066069Predios = _contexto.R1202066069Predios.Where(f => f.NUMERO_DEL_PREDIO == id).ToList();

                var R2202169295Construcciones = _contexto.R2202169295Construcciones.Where(f => f.NUMERO_DEL_PREDIO == id).ToList();

                dataform = _mapper.MapDataAModel(predio, cantidadMejora, R1202169295Predios, R2202169295Construcciones, R1202066069Predios);

                dataform.R2_2021_69295_CONSTRUCCIONESModel?.ToList().ForEach(m =>
                {
                    m.nomDep = _contexto.Departamento.Where(d => d.id_ct_depto == m.dep)
                                        .Select(dn => dn.nombre).DefaultIfEmpty(string.Empty).FirstOrDefault();

                    m.nomMun = _contexto.Ciudad.Where(d => d.idctdepto == m.dep && d.idctmuncipio == m.mun)
                                        .Select(dn => dn.nombre).DefaultIfEmpty(string.Empty).FirstOrDefault();
                });

            }
            catch(Exception ex)
            {
                string message = ex.Message;

            }
                       
            return dataform;

        }

    }
}