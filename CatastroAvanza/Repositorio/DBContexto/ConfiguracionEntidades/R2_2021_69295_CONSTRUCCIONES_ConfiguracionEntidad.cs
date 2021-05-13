using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class R2_2021_69295_CONSTRUCCIONES_ConfiguracionEntidad : EntityTypeConfiguration<R2_2021_69295_CONSTRUCCIONES>
    {
        public R2_2021_69295_CONSTRUCCIONES_ConfiguracionEntidad()
        {
            ToTable("R2_2021_69295_CONSTRUCCIONES");

            HasKey(s => s.id);

            Property(s => s.id)
               .IsRequired()
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}