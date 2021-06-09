using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class TipoActividad_ConfiguracionEntidad : EntityTypeConfiguration<TipoActividad>
    {
        public TipoActividad_ConfiguracionEntidad()
        {
            ToTable("tipoactividad");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.Actividad)
                .HasColumnName("actividad")
                .HasMaxLength(300)
                .IsRequired();

            Property(s => s.IdRol)
                .HasColumnName("rol")
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}