using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class Archivo_ConfiguracionEntidad : EntityTypeConfiguration<Archivo>
    {
        public Archivo_ConfiguracionEntidad()
        {
            ToTable("archivo");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.Nombre)
                .HasMaxLength(300)
                .IsRequired();

            Property(s => s.NombreFisico)
                .HasMaxLength(300)
                .IsRequired();

            Property(s => s.FechaCreacion)                
                .IsRequired();

            Property(s => s.CreadoPor)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}