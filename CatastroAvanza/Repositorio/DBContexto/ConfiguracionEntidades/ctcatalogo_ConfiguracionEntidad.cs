using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ctcatalogo_ConfiguracionEntidad : EntityTypeConfiguration<ctcatalogo>
    {

        public ctcatalogo_ConfiguracionEntidad()
        {
            ToTable("ctcatalogo");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            Property(s => s.Tipo)
                .HasMaxLength(50)
                .IsRequired();

            Property(s => s.Estado)
                        .IsRequired();
        }
        
    }
}