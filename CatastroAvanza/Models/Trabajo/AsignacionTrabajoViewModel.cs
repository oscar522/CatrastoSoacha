using System;

namespace CatastroAvanza.Models.Trabajo
{
    public class AsignacionTrabajoViewModel
    {
        public int Id { get; set; }

        public string UserAsignado { get; set; }

        public int IdActividad { get; set; }

        public string NombreActividad { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public string UsuarioQueAsigno { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public string Estado { get; set; }
    }
}