using System;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ActividadGeneralViewModel
    {
        public string NumeroPredial { get; set; }

        public string Ejecutor { get; set; }

        public string Coordinador { get; set; }

        public DateTime Fecha { get; set; }

        public GeograficaViewModel Geografica { get; set; }

        public FolioViewModel Folio { get; set; }

        public NomenclaturaViewModel Nomenclatura { get; set; }

        public bool PropietariosCorrectos { get; set; }
        
        public TramiteViewModel Tramite { get; set; }

        public TerrenoViewModel Terreno { get; set; }

        public ConstruccionViewModel Construccion { get; set; }

        public SelectList Ejecutores { get; set; }

        public SelectList Coordinadores { get; set; }
    }
}