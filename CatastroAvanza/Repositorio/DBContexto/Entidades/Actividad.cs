using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class Actividad
    {
        public int Id { get; set; }

        public string General_NumeroPredial { get; set; }//ok

        public string General_Ejecutor { get; set; }//ok

        public string General_Coordinador { get; set; }//ok

        public DateTime General_Fecha { get; set; }//ok

        public bool Geografica_Omision { get; set; }//ok

        public bool Geografica_DuplicadoGeograficamente { get; set; }//ok

        public int Geografica_NumeroDuplicados { get; set; }//ok

        public bool Geografica_RequiereVisitaGeografica { get; set; }//ok

        public string Geografica_Observacion { get; set; }//ok        

        public bool Geografica_FmiDuplicados { get; set; }//ok

        public int Geografica_NumeroFmiDuplicados { get; set; }//ok

        public bool Geografica_VerificacionFmi { get; set; }//ok

        public string Geografica_FmiCorrecto { get; set; }//ok
       
        public bool Nomenclatura_NomenclaturaPredio { get; set; }//ok

        public string Nomenclatura_NomenclaturaAActualizar { get; set; }//ok

        public bool Tramite_PropietariosCorrectos { get; set; }//ok

        public bool Tramite_Englobe { get; set; }//ok

        public bool Tramite_Desenglobe { get; set; }//ok

        public int Tramite_Unidadestramite { get; set; }//ok

        public bool Tramite_ReglamentoPH { get; set; }//ok

        public int Tramite_UnidadesReglamento { get; set; }//ok

        public bool Tramite_Linderos { get; set; }//ok

        public string Tramite_LinderosFmi { get; set; }//ok

        public bool Tramite_LinderosArcifinios { get; set; }//ok

        public bool Tramite_LinderosEnEscritura { get; set; }//ok

        public string Tramite_NumeroEscritura { get; set; }//ok

        public bool Tramite_LinderosVerificablesTerreno { get; set; }//ok

        public string Terreno_EscrituraLinderos { get; set; }//ok

        public bool Terreno_TieneArea { get; set; }//ok

        public int Terreno_AreaTerreno { get; set; }//ok

        public string Terreno_UnidadArea { get; set; }//ok

        public int Terreno_AreaTerrenoEnMetros { get; set; }//ok

        public int Terreno_PorcentajeAreaJudicialAreaCatastral { get; set; }//ok

        public bool Terreno_IdentificacionPredio { get; set; }//ok

        public string Terreno_RequiereVisita { get; set; }//ok

        public string Terreno_ObservacionVisita { get; set; }//ok

        public bool Construccion_IncorporacioArea { get; set; }//ok

        public string Construccion_DetalleIncorporacionArea { get; set; }//ok

        public bool Construccion_Uso { get; set; }//ok

        public bool Construccion_Destino { get; set; }//ok

        public string Construccion_ObservacionUsosDestino { get; set; }//ok

        public bool Construccion_RequiereVisitaConstruccion { get; set; }//ok

        public bool Construccion_TieneConstrucciones { get; set; }//ok

        public bool Construccion_ConstruccionEsCorrecta { get; set; }//ok

        public bool Construccion_AdicionaCancelaUnidades { get; set; }//ok

        public bool Construccion_AdicionarConstrucciones { get; set; }//ok

        public bool Construccion_ElminarConstrucciones { get; set; }//ok

        public bool Construccion_AdicionarAnexos { get; set; }//ok

        public bool Construccion_ElminarAnexos { get; set; }//ok

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

        public string Arcvhivo_FotoFachada { get; set; }//ok

        public string Arcvhivo_Fmi { get; set; }//ok

        public string Arcvhivo_CertificadoNomenclatura { get; set; }//ok
    }
}