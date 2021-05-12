using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ctpais_ConfiguracionEntidad : EntityTypeConfiguration<ctpais>
    {

        public ctpais_ConfiguracionEntidad()
        {
            ToTable("ctpais");

            HasKey(s => s.id_ct_pais);

            Property(s => s.id_ct_pais)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.nombre)
                    .IsRequired();
        }
        
    }
}