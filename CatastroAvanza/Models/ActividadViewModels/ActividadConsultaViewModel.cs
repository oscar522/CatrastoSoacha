using System;

namespace CatastroAvanza.Models.ActividadViewModels
{
    public class ActividadConsultaViewModel
    {
        public int Id { get; set; }
        public string NumeroPredial { get; set; }

        public string Ejecutor { get; set; }

        public string Coordinador { get; set; }

        public DateTime Fecha { get; set; }

        public string Departamento { get; set; }

        public String Municipio { get; set; }
    }
}