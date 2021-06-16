using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CatastroAvanza.Models.ActividadesDiarias
{
    public class ActividadesDiariasViewModel
    {

        public long Id { get; set; }
        public string IdApsNetUser { get; set; }
        public string NombreUsuario { get; set; }
        public string RolUsuario { get; set; }
        public string IdRolUsuario { get; set; }

        [DisplayName("Fecha")]        
        [Required(ErrorMessage = "Fecha es requerido.")]
        public DateTime FechaActividad { get; set; }
        [DisplayName("Rol")]
        [Required(ErrorMessage = "Rol es requerido.")]
        public string IdRolActividad { get; set; }
        [DisplayName("Actividad")]
        [Required(ErrorMessage = "Actividad es requerido.")]
        public int IdActividad { get; set; }
        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Cantidad es requerido.")]
        public int Cantidad { get; set; }
        [DisplayName("Observiacion")]
        [Required(ErrorMessage = "Observiacion es requerido.")]
        public string Observacion { get; set; }

        [DisplayName("Proceso")]
        [Required(ErrorMessage = "Proceso es requerido.")]
        public int IdProceso { get; set; }
        [DisplayName("Modalidad")]
        [Required(ErrorMessage = "Modalidad es requerido.")]
        public int IdModalidad { get; set; }
        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Departamento es requerido.")]
        public int IdDepto { get; set; }
        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Municipio es requerido.")]
        public int IdMuni { get; set; }
    }
}