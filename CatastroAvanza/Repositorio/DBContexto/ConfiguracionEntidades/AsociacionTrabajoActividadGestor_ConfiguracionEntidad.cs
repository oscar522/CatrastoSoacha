using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class AsociacionTrabajoActividadGestor_ConfiguracionEntidad : EntityTypeConfiguration<AsociacionTrabajoActividadGestor>
    {

        public AsociacionTrabajoActividadGestor_ConfiguracionEntidad()
        {
            ToTable("AsignacionGestor");

            HasKey(s => s.Id);

            Property(s => s.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.UserAsignado)
                .HasMaxLength(256)
                .IsRequired();

            Property(s => s.FechaAsignacion)
                .IsRequired();

            Property(s => s.UsuarioQueAsigno)
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