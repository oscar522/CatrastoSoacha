using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class Archivo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string NombreFisico { get; set; }

        public string CreadoPor { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string EstadoCarga { get; set; } 
    }
}