using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ctciudad_ConfiguracionEntidad : EntityTypeConfiguration<ctciudad>
    {
        public ctciudad_ConfiguracionEntidad()
        {
            ToTable("ctciudad");

            HasKey(s => s.id);

            Property(s => s.id)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.idctdepto)
                    .IsRequired();

            Property(s => s.idctmuncipio)
                    .IsRequired();

            Property(s => s.idctpais)
                    .IsRequired();

            Property(s => s.nombre)
                    .IsRequired();
        }
    }
}