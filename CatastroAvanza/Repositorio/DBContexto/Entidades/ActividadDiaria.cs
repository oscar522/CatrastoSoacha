using System;

namespace CatastroAvanza.Repositorio.DBContexto.Entidades
{
    public class ActividadDiaria
    {
        public int Id { get; set; }

        public string IdApsNetUser { get; set; }

        public int IdProceso { get; set; }

        public int IdModalidad { get; set; }

        public string IdRol { get; set; }

        public DateTime FechaActividad { get; set; }

        public int IdActividad { get; set; }

        public int Cantidad { get; set; }

        public string Observacion { get; set; }

        public bool Estado { get; set; }

        public long FInsercion { get; set; }

        public int IdDepartamento { get; set; }

        public int IdMunicipio { get; set; }
    }
}