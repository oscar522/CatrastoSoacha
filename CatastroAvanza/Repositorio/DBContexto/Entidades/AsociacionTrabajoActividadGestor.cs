using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class AsociacionTrabajoActividadGestor
    {
        public int Id { get; set; }

        public string UserAsignado { get; set; }

        public int IdActividad { get; set; }

        public DateTime FechaAsignacion { get; set; }

        public string UsuarioQueAsigno { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

        public bool Estado { get; set; }

    }
}