using System;

namespace CatastroAvanza.Models.Archivo
{
    public class ArchivoViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string NombreFisico { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}