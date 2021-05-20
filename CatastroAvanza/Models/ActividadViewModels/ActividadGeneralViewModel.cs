using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ActividadGeneralViewModel
    {
        public ActividadGeneralViewModel()
        {
            Geografica = new GeograficaViewModel();
            Folio = new FolioViewModel();
            Nomenclatura = new NomenclaturaViewModel();
            Tramite = new TramiteViewModel();
            Terreno = new TerrenoViewModel();
            Construccion = new ConstruccionViewModel();
        }

        [DisplayName("Numero Predial")]
        [StringLength(30, ErrorMessage = "Numero predial no puede tener mas de 30 digitos")]        
        [Required(ErrorMessage = "Numero de predial es requerido.")]
        public string NumeroPredial { get; set; }

        [DisplayName("Ejecutor")]
        [Required(ErrorMessage = "Ejecutor es requerido.")]
        public int Ejecutor { get; set; }

        [DisplayName("Coordinador")]
        [Required(ErrorMessage = "Coordinador es requerido.")]
        public int Coordinador { get; set; }

        [DisplayName("¿Requiere actualizacion de propietarios?")]
        [Required(ErrorMessage = "Indicar si los propietarios son correctos requerido.")]
        public bool PropietariosCorrectos { get; set; }

        [DisplayName("Fecha")]
        [Required(ErrorMessage = "Fecha es requerido.")]
        public DateTime Fecha { get; set; }

        public GeograficaViewModel Geografica { get; set; }

        public FolioViewModel Folio { get; set; }

        public NomenclaturaViewModel Nomenclatura { get; set; }
        
        public TramiteViewModel Tramite { get; set; }

        public TerrenoViewModel Terreno { get; set; }

        public ConstruccionViewModel Construccion { get; set; }

        public SelectList Ejecutores { get; set; }

        public SelectList Coordinadores { get; set; }
    }
}