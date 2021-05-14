namespace CatastroAvanza.Models.ActividadViewModels
{
    public class TerrenoViewModel
    {
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
    }
}