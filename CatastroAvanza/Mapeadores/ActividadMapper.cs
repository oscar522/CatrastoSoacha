using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatastroAvanza.Mapeadores
{
    public class ActividadMapper : IActividadMapper
    {
        public ActividadPredioViewModel MapDataAModel(Actividad model)
        {
            ActividadPredioViewModel result = new ActividadPredioViewModel();
            result.Id = model.Id;

            result.NumeroPredial= model.General_NumeroPredial ;
            result.Ejecutor = model.General_Ejecutor;
            result.Coordinador = int.TryParse(model.General_Coordinador, out int value) ? value : 0;
            result.Fecha = model.General_Fecha ;

            result.Geografica.Omision = model.Geografica_Omision ;
            result.Geografica.DuplicadoGeograficamente = model.Geografica_DuplicadoGeograficamente;
            result.Geografica.NumeroDuplicados = model.Geografica_NumeroDuplicados;
            result.Geografica.RequiereVisitaGeografica = model.Geografica_RequiereVisitaGeografica;
            result.Geografica.Observacion = model.Geografica_Observacion;
            result.Geografica.FmiDuplicados = model.Geografica_FmiDuplicados;
            result.Geografica.NumeroFmiDuplicados = model.Geografica_NumeroFmiDuplicados;
            result.Geografica.VerificacionFmi = model.Geografica_VerificacionFmi;
            result.Geografica.FmiCorrecto = model.Geografica_FmiCorrecto;

            result.Construccion.Uso = model.Construccion_Uso;
            result.Construccion.Destino = model.Construccion_Destino ;
            result.Construccion.ObservacionUsosDestino = model.Construccion_ObservacionUsosDestino;
            result.Construccion.RequiereVisitaConstruccion= model.Construccion_RequiereVisitaConstruccion ;
            result.Construccion.TieneConstrucciones= model.Construccion_TieneConstrucciones;
            result.Construccion.ConstruccionEsCorrecta =model.Construccion_ConstruccionEsCorrecta;
            result.Construccion.AdicionaCancelaUnidades= model.Construccion_AdicionaCancelaUnidades;
            result.Construccion.AdicionarConstrucciones= model.Construccion_AdicionarConstrucciones;
            result.Construccion.ElminarConstrucciones=model.Construccion_ElminarConstrucciones;
            result.Construccion.AdicionarAnexos=model.Construccion_AdicionarAnexos;
            result.Construccion.ElminarAnexos=model.Construccion_ElminarAnexos;
            result.Construccion.UsoDetalle= model.Construccion_Uso_Detalle;
            result.Construccion.DestinoDetalle= model.Construccion_Destino_Detalle;

            result.ArchivosCargados.FichaPredial = model.Arcvhivo_FichaPredial;
            result.ArchivosCargados.Plano = model.Arcvhivo_Plano;
            result.ArchivosCargados.Escrituras = model.Arcvhivo_Escrituras;
            result.ArchivosCargados.Fmi = model.Arcvhivo_Fmi;
            result.ArchivosCargados.CertificadoNomenclatura = model.Arcvhivo_CertificadoNomenclatura;
            result.ArchivosCargados.Croquis = model.Arcvhivo_Croquis;
            result.ArchivosCargados.FotoFachada = model.Arcvhivo_FotoFachada;

            result.Nomenclatura.NomenclaturaPredio = model.Nomenclatura_NomenclaturaPredio;
            result.Nomenclatura.NomenclaturaAActualizar = model.Nomenclatura_NomenclaturaAActualizar;

            result.Tramite.Englobe = model.Tramite_Englobe;
            result.Tramite.Desenglobe = model.Tramite_Desenglobe;
            result.Tramite.Unidadestramite = model.Tramite_Unidadestramite;
            result.Tramite.ReglamentoPH = model.Tramite_ReglamentoPH;
            result.Tramite.UnidadesReglamento = model.Tramite_UnidadesReglamento;
            result.Tramite.LinderosFmi = model.Tramite_LinderosFmi;
            result.Tramite.LinderosArcifinios = model.Tramite_LinderosArcifinios;
            result.Tramite.LinderosVerificablesTerreno = model.Tramite_LinderosVerificablesTerreno;
            result.Tramite.LinderosEnEscritura = model.Tramite_LinderosEnEscritura;
            result.Tramite.NumeroEscritura = model.Tramite_NumeroEscritura;
            result.Tramite.PropietariosCorrectos = model.Tramite_PropietariosCorrectos;
            result.Tramite.Linderos = model.Tramite_Linderos;

            result.Terreno.TieneArea = model.Terreno_TieneArea;
            result.Terreno.AreaTerreno = model.Terreno_AreaTerreno;
            result.Terreno.UnidadArea = int.TryParse(model.Terreno_UnidadArea, out int valueUnidad) ? valueUnidad : 0;
            result.Terreno.AreaTerrenoEnMetros = model.Terreno_AreaTerrenoEnMetros;
            result.Terreno.PorcentajeAreaJudicialAreaCatastral = model.Terreno_PorcentajeAreaJudicialAreaCatastral;
            result.Terreno.IdentificacionPredio = model.Terreno_IdentificacionPredio;
            result.Terreno.RequiereVisita = model.Terreno_RequiereVisita;
            result.Terreno.ObservacionVisita = model.Terreno_ObservacionVisita;

            result.Informacion.AreaConstruida = model.General_AreaConstruida;
            result.Informacion.AreaTerreno = model.General_AreaTerreno;
            result.Informacion.Avaluo = model.General_Avaluo;
            result.Informacion.Barrio = model.General_Barrio;
            result.Informacion.Comuna = model.General_Comuna;
            result.Informacion.Condicion = model.General_Condicion;
            result.Informacion.Departamento = model.General_Departamento;
            result.Informacion.Destino = model.General_Destino;
            result.Informacion.Direccion = model.General_Direccion;
            result.Informacion.Direccion2 = model.General_Direccion2;
            result.Informacion.Mejoras = model.General_Mejoras;
            result.Informacion.Municipio = model.General_Municipio;
            result.Informacion.NumeroMejoras = model.General_Numero_Mejoras;
            result.Informacion.TipoDireccion = model.General_TipoDireccion;
            result.Informacion.Vereda = model.General_Vereda;

            return result;
        }

        public List<ActividadConsultaViewModel> MapDataAModel(List<Actividad> actividades, List<ctciudad> ciudad, List<ctdepto> dpto)
        {
            List<ActividadConsultaViewModel> aaData = actividades.Select(m => new ActividadConsultaViewModel
            {
                Coordinador = m.General_Coordinador,
                Departamento = dpto.Where(d => d.id_ct_depto == m.General_Departamento).DefaultIfEmpty(new ctdepto()).FirstOrDefault().nombre,
                Ejecutor = m.General_Ejecutor,
                Fecha = m.General_Fecha,
                Id = m.Id,
                Municipio = ciudad.Where(c => c.id == m.General_Municipio).DefaultIfEmpty(new ctciudad()).FirstOrDefault().nombre,
                NumeroPredial = m.General_NumeroPredial
            }).ToList();

            return aaData;
        }

        public Actividad MapModelAData(ActividadPredioViewModel model, Actividad result)
        {            
            if (model != null)
            {
                result.General_NumeroPredial = model.NumeroPredial;
                //result.General_Ejecutor = model.Ejecutor.ToString();
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
                result.Arcvhivo_FichaPredial =  string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.FichaPredial)) ? result.Arcvhivo_FichaPredial : MapeaNombreDelArchivo(model.Files.FichaPredial);
                result.Arcvhivo_Plano = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.Plano)) ? result.Arcvhivo_Plano : MapeaNombreDelArchivo(model.Files.Plano);
                result.Arcvhivo_Escrituras = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.Escrituras)) ? result.Arcvhivo_Escrituras : MapeaNombreDelArchivo(model.Files.Escrituras);
                result.Arcvhivo_Fmi = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.Fmi)) ? result.Arcvhivo_Fmi : MapeaNombreDelArchivo(model.Files.Fmi);
                result.Arcvhivo_CertificadoNomenclatura = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.CertificadoNomenclatura)) ? result.Arcvhivo_CertificadoNomenclatura : MapeaNombreDelArchivo(model.Files.CertificadoNomenclatura);
                result.Arcvhivo_Croquis = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.Croquis)) ? result.Arcvhivo_Croquis : MapeaNombreDelArchivo(model.Files.Croquis);
                result.Arcvhivo_FotoFachada = string.IsNullOrEmpty(MapeaNombreDelArchivo(model.Files.FotoFachada)) ? result.Arcvhivo_FotoFachada : MapeaNombreDelArchivo(model.Files.FotoFachada);

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

            if (model.Terreno != null)
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

            if (model.Terreno != null)
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

        private string MapeaNombreDelArchivo(HttpPostedFileBase archivo)
        {
            if (archivo == null)
                return string.Empty;
            else
                return string.IsNullOrEmpty(archivo.FileName) ? string.Empty : archivo.FileName;
        }
    }
}