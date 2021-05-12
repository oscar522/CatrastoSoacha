using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class ctdepto_ConfiguracionEntidad : EntityTypeConfiguration<ctdepto>
    {
        public ctdepto_ConfiguracionEntidad()
        {
            ToTable("ctdepto");

            HasKey(s => s.id_ct_depto);

            Property(s => s.id_ct_depto)
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.id_ct_pais)
                    .IsRequired();

            Property(s => s.nombre)
                    .IsRequired();
        }
    }
}