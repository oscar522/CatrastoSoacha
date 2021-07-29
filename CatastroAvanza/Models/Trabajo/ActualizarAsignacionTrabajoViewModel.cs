using System;

namespace CatastroAvanza.Models.Trabajo
{
    public class ActualizarAsignacionTrabajoViewModel
    {
        public int Id { get; set; }

        public string UserAsignado { get; set; }

        public int IdActividad { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public DateTime FechaFinalizacionEsperada { get; set; }

        public string UsuarioQueAsigno { get; set; }
    }
}