using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class ActividadTrabajo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string  Rol { get; set; }

        public int  Cantidad { get; set; }

        public int PuntosEsfuerzo { get; set; }

        public bool Estado { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }
    }
}