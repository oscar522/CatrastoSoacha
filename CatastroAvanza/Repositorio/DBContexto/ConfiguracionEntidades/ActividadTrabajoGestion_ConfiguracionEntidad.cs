using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ActividadTrabajoGestion_ConfiguracionEntidad : EntityTypeConfiguration<ActividadTrabajoGestion>
    {

        public ActividadTrabajoGestion_ConfiguracionEntidad()
        {
            ToTable("TrabajoGestionRealizada");

            HasKey(s => s.Id);

            Property(s => s.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.FechaModificacionGestion)
               .IsRequired();

            Property(s => s.IdAsignacion)
                .IsRequired();

            Property(s => s.Observacion)
                .IsRequired();

            Property(s => s.EstadoGestion)
                .HasMaxLength(256)
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

            Property(s => s.EstadoRegistro)
                .IsRequired();           
        }
    }
}