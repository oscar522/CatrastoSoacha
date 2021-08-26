using System.Collections.Generic;

namespace CatastroAvanza.Models.Trabajo
{
    public class TrabajoJerarquia
    {
        public string text { get; set; }

        public int IdTrabajo { get; set; }

        public ICollection<TrabajoHijos> nodes { get; set; }
    }
}