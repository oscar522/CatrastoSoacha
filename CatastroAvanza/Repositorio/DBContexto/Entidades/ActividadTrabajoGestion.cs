using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class ActividadTrabajoGestion
    {
        public int Id { get; set; }

        public int IdAsignacion { get; set; }

        public string EstadoGestion { get; set; }

        public DateTime FechaModificacionGestion { get; set; }

        public string Observacion { get; set; }

        public bool EstadoRegistro { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }

    }
}