using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ActividadTrabajo_ConfiguracionEntidad : EntityTypeConfiguration<ActividadTrabajo>
    {
        public ActividadTrabajo_ConfiguracionEntidad()
        {
            ToTable("Trabajos");

            HasKey(s => s.Id);

            Property(s => s.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.Nombre)
                .HasMaxLength(256)
                .IsRequired();

            Property(s => s.Cantidad)                
                .IsRequired();

            Property(s => s.PuntosEsfuerzo)
                .IsRequired();

            Property(s => s.CreadoPor)
                .HasMaxLength(256)
                .IsRequired();

            Property(s => s.UltimaModificacionPor)
                .HasMaxLength(256)
                .IsRequired();

            Property(s => s.FechaCreacion)
                .IsRequired();

            Property(s => s.FechaUltimaModificacion)
                .IsRequired();

            Property(s => s.Estado)
                .IsRequired();

        }
    }
}