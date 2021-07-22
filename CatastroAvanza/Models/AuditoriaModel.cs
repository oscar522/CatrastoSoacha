using System;

namespace CatastroAvanza.Models
{
    public class AuditoriaModel
    {
        public AuditoriaModel(string usuarioEjecutaAccion)
        {
            CreadoPor = usuarioEjecutaAccion;
            UltimaModificacionPor = usuarioEjecutaAccion;
            FechaCreacion = DateTime.Now;
            FechaUltimaModificacion = DateTime.Now;
        }

        public string CreadoPor { get; }

        public DateTime FechaCreacion { get; }

        public string UltimaModificacionPor { get; }

        public DateTime FechaUltimaModificacion { get; }
    }
}