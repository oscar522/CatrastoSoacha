using System;

namespace CatastroAvanza.Models.ActividadesDiarias
{
    public class ActividadesDiariasTablaModel
    {
        public long Id { get; set; }
        public DateTime FechaActividadS { get; set; }
        public string NombreProceso { get; set; }
        public string NombreModalidad { get; set; }
        public string RolUsuario { get; set; }
        public string NombreUsuario { get; set; }        
        public string NombreRolActividad { get; set; }
        public string NombreActividad { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public string DepartamentoMunicipio { get; set; }
    }
}