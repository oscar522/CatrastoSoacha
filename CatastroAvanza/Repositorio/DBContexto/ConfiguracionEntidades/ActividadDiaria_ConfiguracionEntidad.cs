using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ActividadDiaria_ConfiguracionEntidad : EntityTypeConfiguration<ActividadDiaria>
    {
        public ActividadDiaria_ConfiguracionEntidad()
        {
            ToTable("actividaddiaria");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.IdApsNetUser)
                .HasColumnName("idapsnetuser")
                .HasMaxLength(128)
                .IsRequired();

            Property(s => s.IdProceso)
                .HasColumnName("idproceso")
                .IsRequired();

            Property(s => s.IdModalidad)
                .HasColumnName("idmodalidad")
                .IsRequired();

            Property(s => s.IdRol)
                .HasColumnName("idrol")
                .HasMaxLength(128)
                .IsRequired();

            Property(s => s.IdActividad)
                .HasColumnName("idactividad")
                .IsRequired();

            Property(s => s.Cantidad)
                .HasColumnName("cantidad")
                .IsRequired();

            Property(s => s.IdDepartamento)
                .HasColumnName("iddepto")
                .IsRequired();

            Property(s => s.IdMunicipio)
                .HasColumnName("idmuni")
                .IsRequired();

        }
    }
}