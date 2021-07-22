using System;

namespace CatastroAvanza.Models.Trabajo
{
    public class ActualizarGestionTrabajoViewModel
    {
        public int Id { get; set; }

        public int IdAsignacion { get; set; }

        public string EstadoGestion { get; set; }

        public DateTime FechaModificacionGestion { get; set; }

        public string Observacion { get; set; }

        public string EstadoRegistro { get; set; }
    }
}