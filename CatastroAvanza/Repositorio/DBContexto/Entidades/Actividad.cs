using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class Actividad
    {
        public int Id { get; set; }

        public string General_NumeroPredial { get; set; }

        public string General_Ejecutor { get; set; }

        public string General_Coordinador { get; set; }

        public DateTime General_Fecha { get; set; }

        public bool Geografica_Omision { get; set; }

        public bool Geografica_DuplicadoGeograficamente { get; set; }

        public int Geografica_NumeroDuplicados { get; set; }

        public bool Geografica_RequiereVisitaGeografica { get; set; }

        public string Geografica_Observacion { get; set; } 

        public bool Geografica_FmiDuplicados { get; set; }

        public int Geografica_NumeroFmiDuplicados { get; set; }

        public bool Geografica_VerificacionFmi { get; set; }

        public string Geografica_FmiCorrecto { get; set; }
       
        public bool Nomenclatura_NomenclaturaPredio { get; set; }

        public string Nomenclatura_NomenclaturaAActualizar { get; set; }

        public bool Tramite_PropietariosCorrectos { get; set; }

        public bool Tramite_Englobe { get; set; }

        public bool Tramite_Existe_Englobe_Con_Mejora { get; set; }

        public bool Tramite_Requiere_Actualizacion_Nomenclatura { get; set; }

        public bool Tramite_Desenglobe { get; set; }

        public int Tramite_Unidadestramite { get; set; }

        public bool Tramite_ReglamentoPH { get; set; }

        public int Tramite_UnidadesReglamento { get; set; }

        public bool Tramite_Linderos { get; set; }

        public string Tramite_LinderosFmi { get; set; }

        public bool Tramite_LinderosArcifinios { get; set; }

        public bool Tramite_LinderosEnEscritura { get; set; }

        public string Tramite_NumeroEscritura { get; set; }

        public bool Tramite_LinderosVerificablesTerreno { get; set; }

        public string Terreno_EscrituraLinderos { get; set; }

        public bool Terreno_TieneArea { get; set; }

        public decimal Terreno_AreaTerreno { get; set; }

        public string Terreno_UnidadArea { get; set; }

        public decimal Terreno_AreaTerrenoEnMetros { get; set; }

        public decimal Terreno_PorcentajeAreaJudicialAreaCatastral { get; set; }

        public bool Terreno_IdentificacionPredio { get; set; }

        public bool Terreno_RequiereVisita { get; set; }

        public bool Terreno_Predio_Requiere_Rectificacion_Area { get; set; }

        public string Terreno_ObservacionVisita { get; set; }

        public bool Construccion_Tiene_cubrimiento_orto { get; set; }

        public bool Construccion_Tiene_cubrimiento_visor { get; set; }

        public bool Construccion_IncorporacioArea { get; set; }

        public string Construccion_DetalleIncorporacionArea { get; set; }

        public bool Construccion_Uso { get; set; }

        public bool Construccion_Destino { get; set; }

        public string Construccion_ObservacionUsosDestino { get; set; }

        public bool Construccion_RequiereVisitaConstruccion { get; set; }

        public bool Construccion_TieneConstrucciones { get; set; }

        public bool Construccion_ConstruccionEsCorrecta { get; set; }

        public bool Construccion_AdicionaCancelaUnidades { get; set; }

        public bool Construccion_AdicionarConstrucciones { get; set; }

        public bool Construccion_ElminarConstrucciones { get; set; }

        public bool Construccion_AdicionarAnexos { get; set; }

        public bool Construccion_ElminarAnexos { get; set; }

        public string Construccion_Uso_Detalle { get; set; }

        public string Construccion_Destino_Detalle { get; set; }

        public int General_Departamento { get; set; }

        public int General_Municipio { get; set; }

        public string General_Comuna { get; set; }

        public string General_Vereda { get; set; }

        public string General_Barrio { get; set; }

        public string General_Direccion { get; set; }

        public string General_Direccion2 { get; set; }

        public int General_TipoDireccion { get; set; }

        public string General_Condicion { get; set; }

        public bool General_Mejoras { get; set; }

        public int General_Numero_Mejoras { get; set; }

        public string General_Destino { get; set; }

        public decimal General_AreaTerreno { get; set; }

        public decimal General_AreaConstruida { get; set; }

        public decimal General_Avaluo { get; set; }

        public string Arcvhivo_FotoFachada { get; set; }

        public string Arcvhivo_Fmi { get; set; }

        public string Arcvhivo_CertificadoNomenclatura { get; set; }

        public string Arcvhivo_FichaPredial { get; set; }

        public string Arcvhivo_Plano { get; set; }

        public string Arcvhivo_Escrituras { get; set; }

        public string Arcvhivo_Croquis { get; set; }

        public bool Economico_Requiere_Revision_Tipologias { get; set; }

        public bool Economico_Requiere_Revision_Zonas { get; set; }

        public string Economico_Observaciones { get; set; }

    }
}