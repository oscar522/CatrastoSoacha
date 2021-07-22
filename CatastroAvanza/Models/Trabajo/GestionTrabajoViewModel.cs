using System;

namespace CatastroAvanza.Models.Trabajo
{
    public class GestionTrabajoViewModel
    {
        public int Id { get; set; }

        public int IdAsignacion { get; set; }

        public string UsuarioAsignado { get; set; }

        public string EstadoGestion { get; set; }

        public DateTime FechaModificacionGestion { get; set; }

        public string Observacion { get; set; }

        public string EstadoRegistro { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }
    }
}