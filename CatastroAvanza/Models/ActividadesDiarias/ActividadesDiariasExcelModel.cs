using System;

namespace CatastroAvanza.Models.ActividadesDiarias
{
    public class ActividadesDiariasExcelModel
    {
        public long Id { get; set; }
        public string NombreUsuario { get; set; }        
        public int IdProceso { get; set; }
        public string NombreProceso { get; set; }
        public int IdModalidad { get; set; }
        public string NombreModalidad { get; set; }        
        public string RolUsuario { get; set; }
        public DateTime FechaActividadS { get; set; }
        public string IdRolActividad { get; set; }
        public string NombreRolActividad { get; set; }
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; }
        public int Cantidad { get; set; }
        public string Observacion { get; set; }
        public int IdDepartamento { get; set; }
        public int IdMunicipio { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public DateTime FechaInsercion { get; set; }
    }
}