using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadesDiarias;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatastroAvanza.Mapeadores
{
    public class MapeadoresApplicacion : IMapeadoresApplicacion
    {
        public DataForm1Model MapDataAModel(R1_2021_69295_PREDIOS predio2021,
            string cantidadMejora,
            ICollection<R1_2021_69295_PREDIOS> predios2021,
            ICollection<R2_2021_69295_CONSTRUCCIONES> construcciones2021, 
            ICollection<R1_2020_66069_PREDIOS> predios2020)
        {
            if (predio2021 == null)
                return new DataForm1Model();

            DataForm1Model result = new DataForm1Model
            {
                id = predio2021.id,
                dep = predio2021.dep,
                mun = predio2021.mun,
                NUMERO_DEL_PREDIO = predio2021.NUMERO_DEL_PREDIO,
                Tipo_de_registro = predio2021.Tipo_de_registro,
                NUMERO_DE_ORDEN = predio2021.NUMERO_DE_ORDEN,
                TOTAL_REGISTROS = predio2021.TOTAL_REGISTROS,
                NOMBRE = predio2021.NOMBRE,
                TIPO_DOCUMENTO = predio2021.TIPO_DOCUMENTO,
                NUMERO_DOCUMENTO = predio2021.NUMERO_DOCUMENTO,
                DIRECCION = predio2021.DIRECCION,
                DESTINO_ECONOMICO = predio2021.DESTINO_ECONOMICO,
                AREA_TERRENO = predio2021.AREA_TERRENO,
                AREA_CONSTRUIDA = predio2021.AREA_CONSTRUIDA,
                AVALUO = predio2021.AVALUO,
                VIGENCIA = predio2021.VIGENCIA,
                NUMERO_PREDIAL_ANTERIOR= predio2021.NUMERO_PREDIAL_ANTERIOR,
                CANTIDAD_MEJORA = cantidadMejora,
                CANTIDAD_PROPIETARIOS = predios2021.Select(X => X.TIPO_DOCUMENTO + " - " + X.NUMERO_DOCUMENTO + " - " + X.NOMBRE).ToList(),
                R1_2020_66069_PREDIOSModel = predios2020.Select(t => new R1_2020_66069_PREDIOSModel
                {
                    id = t.id,
                    dep = t.dep,
                    mun = t.mun,
                    NUMERO_DEL_PREDIO = t.NUMERO_DEL_PREDIO,
                    TIPO_DEL_REGISTRO = t.TIPO_DEL_REGISTRO,
                    DIRECCION = t.DIRECCION,
                    COMUNA = t.COMUNA,
                    DESTINO_ECONOMICO = t.DESTINO_ECONOMICO,
                    DESCRIPCION_DESTINO = t.DESCRIPCION_DESTINO,
                    AREA_TERRENO = t.AREA_TERRENO,
                    AREA_CONSTRUIDA = t.AREA_CONSTRUIDA,
                    AVALUO = t.AVALUO,
                    VIGENCIA = t.VIGENCIA,
                    NUMERO_PREDIAL_ANTERIOR = t.NUMERO_PREDIAL_ANTERIOR,
                }).ToList(),
                R2_2021_69295_CONSTRUCCIONESModel = construcciones2021.Select(t => new R2_2021_69295_CONSTRUCCIONESModel
                {
                    id = t.id,
                    dep = t.dep,
                    //nomDep = context.ctdepto.Where(x => x.id_ct_depto == t.dep).FirstOrDefault().nombre,
                    mun = t.mun,
                    //nomMun = context.ctciudad.Where(x => x.idctdepto == t.dep && x.idctmuncipio == t.mun).FirstOrDefault().nombre,
                    NUMERO_DEL_PREDIO = t.NUMERO_DEL_PREDIO,
                    tipo_de_reg = t.tipo_de_reg,
                    Campo3 = t.Campo3,
                    Campo4 = t.Campo4,
                    FMI = t.FMI,
                    Campo6 = t.Campo6,
                    Campo7 = t.Campo7,
                    Campo8 = t.Campo8,
                    Campo9 = t.Campo9,
                    Campo10 = t.Campo10,
                    Campo11 = t.Campo11,
                    USO = t.USO,
                    Campo13 = t.Campo13,
                    AREA_CONSTRUIDA = t.AREA_CONSTRUIDA,
                    Campo15 = t.Campo15,
                    Campo16 = t.Campo16,
                    Campo17 = t.Campo17,
                    USO_2 = t.USO_2,
                    AREA_CONSTRUIDA_2 = t.AREA_CONSTRUIDA_2,
                    USO_3 = t.USO_3,
                    AREA_CONSTRUIDA_3 = t.AREA_CONSTRUIDA_3,
                }).ToList(),
            };

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctcatalogo> catalogos)
        {
            ICollection<CatalogoViewModel> result = catalogos
                .Select(m => new CatalogoViewModel { Value = m.Id, Text = m.Nombre })
                .ToList();

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctdepto> departamento)
        {
            ICollection<CatalogoViewModel> result = departamento
               .Select(m => new CatalogoViewModel { Value = m.id_ct_depto, Text = m.nombre })
               .ToList();

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctciudad> ciudades)
        {
            ICollection<CatalogoViewModel> result = ciudades
               .Select(m => new CatalogoViewModel { Value = m.idctmuncipio, Text = m.nombre })
               .ToList();

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<TipoActividad> tipoActividad)
        {
            ICollection<CatalogoViewModel> result = tipoActividad
               .Select(m => new CatalogoViewModel { Value = m.Id, Text = m.Actividad })
               .ToList();

            return result;
        }

        public List<ActividadConsultaViewModel> MapDataAModel(List<Actividad> actividades, List<ctciudad> ciudad, List<ctdepto> dpto)
        {             
            List<ActividadConsultaViewModel> aaData = actividades.Select(m => new ActividadConsultaViewModel
            {
                Coordinador = m.General_Coordinador,
                Departamento = dpto.Where(d=> d.id_ct_depto == m.General_Departamento).DefaultIfEmpty(new ctdepto()).FirstOrDefault().nombre,
                Ejecutor =m.General_Ejecutor,
                Fecha = m.General_Fecha,
                Id = m.Id,
                Municipio =ciudad.Where(c=> c.id ==  m.General_Municipio).DefaultIfEmpty(new ctciudad()).FirstOrDefault().nombre,
                NumeroPredial = m.General_NumeroPredial
            }).ToList();

            return aaData;
        }

        public Actividad MapModelAData(ActividadPredioViewModel model)
        {
            Actividad result = new Actividad();

            if (model != null)
            {
                result.General_NumeroPredial = model.NumeroPredial;
                result.General_Ejecutor = model.Ejecutor.ToString();
                result.General_Coordinador = model.Coordinador.ToString();
                result.General_Fecha = model.Fecha;                
            }

            if (model.Geografica != null)
            {
                result.Geografica_Omision = model.Geografica.Omision;
                result.Geografica_DuplicadoGeograficamente = model.Geografica.DuplicadoGeograficamente;
                result.Geografica_NumeroDuplicados = model.Geografica.NumeroDuplicados;
                result.Geografica_RequiereVisitaGeografica = model.Geografica.RequiereVisitaGeografica;
                result.Geografica_Observacion = model.Geografica.Observacion;
                result.Geografica_FmiDuplicados = model.Geografica.FmiDuplicados;
                result.Geografica_NumeroFmiDuplicados = model.Geografica.NumeroFmiDuplicados;
                result.Geografica_VerificacionFmi = model.Geografica.VerificacionFmi;
                result.Geografica_FmiCorrecto = model.Geografica.FmiCorrecto;

            }

            if (model.Construccion != null)
            {                
                //result.Construccion_IncorporacioArea = model.Construccion.IncorporacioArea;
                //result.Construccion_DetalleIncorporacionArea = model.Construccion.DetalleIncorporacionArea;
                result.Construccion_Uso = model.Construccion.Uso;
                result.Construccion_Destino = model.Construccion.Destino;
                result.Construccion_ObservacionUsosDestino = model.Construccion.ObservacionUsosDestino;
                result.Construccion_RequiereVisitaConstruccion = model.Construccion.RequiereVisitaConstruccion;
                result.Construccion_TieneConstrucciones = model.Construccion.TieneConstrucciones;
                result.Construccion_ConstruccionEsCorrecta = model.Construccion.ConstruccionEsCorrecta;
                result.Construccion_AdicionaCancelaUnidades = model.Construccion.AdicionaCancelaUnidades;
                result.Construccion_AdicionarConstrucciones = model.Construccion.AdicionarConstrucciones;
                result.Construccion_ElminarConstrucciones = model.Construccion.ElminarConstrucciones;
                result.Construccion_AdicionarAnexos = model.Construccion.AdicionarAnexos;
                result.Construccion_ElminarAnexos = model.Construccion.ElminarAnexos;
                result.Construccion_Uso_Detalle = model.Construccion.UsoDetalle;
                result.Construccion_Destino_Detalle = model.Construccion.DestinoDetalle;

            }


            if (model.Files != null)
            {
                result.Arcvhivo_FichaPredial = MapeaNombreDelArchivo(model.Files.FichaPredial);
                result.Arcvhivo_Plano = MapeaNombreDelArchivo(model.Files.Plano);
                result.Arcvhivo_Escrituras = MapeaNombreDelArchivo(model.Files.Escrituras);
                result.Arcvhivo_Fmi = MapeaNombreDelArchivo(model.Files.Fmi);
                result.Arcvhivo_CertificadoNomenclatura = MapeaNombreDelArchivo(model.Files.CertificadoNomenclatura);
                result.Arcvhivo_Croquis = MapeaNombreDelArchivo(model.Files.Croquis);
                result.Arcvhivo_FotoFachada = MapeaNombreDelArchivo(model.Files.FotoFachada);
                
            }

            if (model.Nomenclatura != null)
            {                
                result.Nomenclatura_NomenclaturaPredio = model.Nomenclatura.NomenclaturaPredio;
                result.Nomenclatura_NomenclaturaAActualizar = model.Nomenclatura.NomenclaturaAActualizar;
            }

            if (model.Tramite != null)
            {
                result.Tramite_Englobe = model.Tramite.Englobe;
                result.Tramite_Desenglobe = model.Tramite.Desenglobe;
                result.Tramite_Unidadestramite = model.Tramite.Unidadestramite;
                result.Tramite_ReglamentoPH = model.Tramite.ReglamentoPH;
                result.Tramite_UnidadesReglamento = model.Tramite.UnidadesReglamento;
                result.Tramite_LinderosFmi = model.Tramite.LinderosFmi;
                result.Tramite_LinderosArcifinios = model.Tramite.LinderosArcifinios;
                result.Tramite_LinderosVerificablesTerreno = model.Tramite.LinderosVerificablesTerreno;
                result.Tramite_LinderosEnEscritura = model.Tramite.LinderosEnEscritura;
                result.Tramite_NumeroEscritura = model.Tramite.NumeroEscritura;
                result.Tramite_PropietariosCorrectos = model.Tramite.PropietariosCorrectos;
                result.Tramite_Linderos = model.Tramite.Linderos;
            }

            if(model.Terreno != null)
            {                               
                //result.Terreno_EscrituraLinderos = model.Terreno.EscrituraLinderos;
                result.Terreno_TieneArea = model.Terreno.TieneArea;
                result.Terreno_AreaTerreno = model.Terreno.AreaTerreno;
                result.Terreno_UnidadArea = model.Terreno.UnidadArea.ToString();
                result.Terreno_AreaTerrenoEnMetros = model.Terreno.AreaTerrenoEnMetros;
                result.Terreno_PorcentajeAreaJudicialAreaCatastral = model.Terreno.PorcentajeAreaJudicialAreaCatastral;
                result.Terreno_IdentificacionPredio = model.Terreno.IdentificacionPredio;
                result.Terreno_RequiereVisita = model.Terreno.RequiereVisita;
                result.Terreno_ObservacionVisita = model.Terreno.ObservacionVisita;
            }

            if (model.Informacion != null)
            {
                result.General_AreaConstruida = model.Informacion.AreaConstruida;
                result.General_AreaTerreno = model.Informacion.AreaTerreno;
                result.General_Avaluo = model.Informacion.Avaluo;
                result.General_Barrio = model.Informacion.Barrio;
                result.General_Comuna = model.Informacion.Comuna;
                result.General_Condicion = model.Informacion.Condicion;
                result.General_Departamento = model.Informacion.Departamento;
                result.General_Destino = model.Informacion.Destino;
                result.General_Direccion = model.Informacion.Direccion;
                result.General_Direccion2 = model.Informacion.Direccion2;
                result.General_Mejoras = model.Informacion.Mejoras;
                result.General_Municipio = model.Informacion.Municipio;
                result.General_Numero_Mejoras = model.Informacion.NumeroMejoras;
                result.General_TipoDireccion = model.Informacion.TipoDireccion;
                result.General_Vereda = model.Informacion.Vereda;                

            }

            return result;
        }

        public ActividadDiaria MapModelAData(ActividadesDiariasViewModel modelo)
        {
            ActividadDiaria result = new ActividadDiaria
            {
                IdActividad = modelo.IdActividad,
                IdApsNetUser = modelo.IdApsNetUser,
                Cantidad = modelo.Cantidad,
                Estado = true,
                FechaActividad = DateTime.Now,
                FInsercion = DateTime.Now.Ticks,
                IdDepartamento = modelo.IdDepto,
                IdModalidad = modelo.IdModalidad,
                IdMunicipio = modelo.IdMuni,
                IdProceso = modelo.IdProceso,
                IdRol = modelo.IdRolActividad,
                Observacion = modelo.Observacion,
            };

            return result;
        }

        public List<ActividadesDiariasTablaModel> MapDataAModel(List<ActividadDiaria> actividades)
        {
            List<ActividadesDiariasTablaModel> result = actividades.Select(n=> new ActividadesDiariasTablaModel { 
                FechaActividadS = n.FechaActividad,
                Cantidad = n.Cantidad,
                Observacion = n.Observacion,
                NombreUsuario = n.IdApsNetUser,
                Id = n.Id,
            }).ToList();

            return result;
        }

        private string MapeaNombreDelArchivo(HttpPostedFileBase archivo)
        {
            if (archivo == null)
                return string.Empty;
            else
                return string.IsNullOrEmpty(archivo.FileName) ? string.Empty : archivo.FileName;
        }

        public ICollection<CatalogoExtendidoViewModel> MapDataAModel(ICollection<UnidadArea> unidades)
        {

            ICollection<CatalogoExtendidoViewModel> result = unidades
               .Select(m => new CatalogoExtendidoViewModel { Value = m.Id.ToString(), Text = m.Nombre, ValueExtended = m.Valor  })
               .ToList();

            return result;
        }

        public ICollection<CatalogoExtendidoViewModel> MapDataAModel(ICollection<Destino> destinos)
        {

            ICollection<CatalogoExtendidoViewModel> result = destinos
               .Select(m => new CatalogoExtendidoViewModel { Value = m.Codigo, Text = m.Nombre })
               .ToList();

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<Uso> usos)
        {

            ICollection<CatalogoViewModel> result = usos
               .Select(m => new CatalogoViewModel { Value = m.Codigo, Text = m.Nombre })
               .ToList();

            return result;
        }
    }
}