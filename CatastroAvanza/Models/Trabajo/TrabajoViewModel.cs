using System;

namespace CatastroAvanza.Models.Trabajo
{
    public class TrabajoViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Rol { get; set; }

        public string RolNombre { get; set; }

        public int Cantidad { get; set; }

        public int PuntosEsfuerzo { get; set; }

        public string Estado { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UltimaModificacionPor { get; set; }

        public DateTime FechaUltimaModificacion { get; set; }
    }
}