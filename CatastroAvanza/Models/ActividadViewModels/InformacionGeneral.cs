using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class InformacionGeneral
    {
        [DisplayName("Departamento")]        
        [Required(ErrorMessage = "Departamento es requerido.")]
        public int Departamento { get; set; }

        [DisplayName("Municipio")]        
        [Required(ErrorMessage = "Municipio es requerido.")]
        public int Municipio { get; set; }

        [DisplayName("Comuna")]        
        [Required(ErrorMessage = "Comuna es requerido.")]
        public string Comuna { get; set; }

        [DisplayName("Vereda")]        
        [Required(ErrorMessage = "Vereda es requerido.")]
        public string Vereda { get; set; }

        [DisplayName("Barrio")]        
        [Required(ErrorMessage = "Barrio es requerido.")]
        public string Barrio { get; set; }

        [DisplayName("Direccion")]        
        [Required(ErrorMessage = "Direccion es requerido.")]
        public string Direccion { get; set; }

        [DisplayName("Direccion2")]        
        [Required(ErrorMessage = "Direccion2 es requerido.")]
        public string Direccion2 { get; set; }

        [DisplayName("Urban/Rral")]        
        [Required(ErrorMessage = "Urban/Rral es requerido.")]
        public int TipoDireccion { get; set; }

        [DisplayName("Condicion")]        
        [Required(ErrorMessage = "Condicion es requerido.")]
        public string Condicion { get; set; }

        [DisplayName("Mejoras")]        
        [Required(ErrorMessage = "Mejoras es requerido.")]
        public bool Mejoras { get; set; }

        [DisplayName("Numero mejoras")]
        [Required(ErrorMessage = "Numero mejoras es requerido.")]
        public int NumeroMejoras { get; set; }

        [DisplayName("Destino")]        
        [Required(ErrorMessage = "Destino es requerido.")]
        public string Destino { get; set; }

        [DisplayName("Area Terreno")]        
        [Required(ErrorMessage = "Area terreno es requerido.")]
        public decimal AreaTerreno { get; set; }

        [DisplayName("Area construida")]        
        [Required(ErrorMessage = "Area construida es requerido.")]
        public decimal AreaConstruida { get; set; }

        [DisplayName("Avaluo")]        
        [Required(ErrorMessage = "Avaluo es requerido.")]
        public decimal Avaluo { get; set; }

        public SelectList Municipios { get; set; }

        public SelectList Departamentos { get; set; }

        public SelectList TiposDireccion { get; set; }

    }
}