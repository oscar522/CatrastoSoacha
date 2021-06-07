using System;

namespace CatastroAvanza.Models.ActividadesDiarias
{
    public class ActividadesDiariasViewModel
    {
        public long Id { get; set; }
        public string IdApsNetUser { get; set; }
        public string NombreUsuario { get; set; }
        public string RolUsuario { get; set; }
        public string IdRolUsuario { get; set; }
        public DateTime FechaActividad { get; set; }
        public string IdRolActividad { get; set; }
        public int IdActividad { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public int IdProceso { get; set; }
        public int IdModalidad { get; set; }
        public int IdDepto { get; set; }
        public int IdMuni { get; set; }
    }
}