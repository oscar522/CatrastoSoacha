using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class Actividad
    {
        public int Id { get; set; }

        public string NumeroPredial { get; set; }

        public string Ejecutor { get; set; }

        public string Coordinador { get; set; }

        public DateTime Fecha { get; set; }

        public bool Omision { get; set; }

        public bool DuplicadoGeograficamente { get; set; }

        public int NumeroDuplicados { get; set; }

        public bool RequiereVisitaGeografica { get; set; }

        public string Observacion { get; set; }

        public string Fmi { get; set; }

        public bool FmiDuplicados { get; set; }

        public int NumeroFmiDuplicados { get; set; }

        public bool VerificacionFmi { get; set; }

        public string FmiCorrecto { get; set; }

        public string CertificadoNomenclatura { get; set; }

        public bool NomenclaturaPredio { get; set; }

        public string NomenclaturaAActualizar { get; set; }

        public bool PropietariosCorrectos { get; set; }

        public bool Englobe { get; set; }

        public bool Desenglobe { get; set; }

        public int Unidadestramite { get; set; }

        public bool ReglamentoPH { get; set; }

        public int UnidadesReglamento { get; set; }

        public bool Linderos { get; set; }

        public string LinderosFmi { get; set; }

        public bool LinderosArcifinios { get; set; }

        public bool LinderosVerificablesTerreno { get; set; }

        public string EscrituraLinderos { get; set; }

        public bool TieneArea { get; set; }

        public int AreaTerreno { get; set; }

        public string UnidadArea { get; set; }

        public int AreaTerrenoEnMetros { get; set; }

        public int PorcentajeAreaJudicialAreaCatastral { get; set; }

        public bool IdentificacionPredio { get; set; }

        public string RequiereVisita { get; set; }

        public string ObservacionVisita { get; set; }

        public string FotoFachada { get; set; }

        public bool IncorporacioArea { get; set; }

        public string DetalleIncorporacionArea { get; set; }

        public bool Uso { get; set; }

        public bool Destino { get; set; }

        public string ObservacionUsosDestino { get; set; }

        public bool RequiereVisitaConstruccion { get; set; }



    }
}