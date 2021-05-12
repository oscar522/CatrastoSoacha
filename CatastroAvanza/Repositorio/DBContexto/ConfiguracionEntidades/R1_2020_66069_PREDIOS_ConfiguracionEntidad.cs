using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class R1_2020_66069_PREDIOS_ConfiguracionEntidad : EntityTypeConfiguration<R1_2020_66069_PREDIOS>
    {
        public R1_2020_66069_PREDIOS_ConfiguracionEntidad()
        {
            ToTable("R1_2020_66069_PREDIOS");

            HasKey(s => s.id);

            Property(s => s.id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }        
    }
}