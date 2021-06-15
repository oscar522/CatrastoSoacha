using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class Uso_ConfiguracionEntidad : EntityTypeConfiguration<Uso>
    {
        public Uso_ConfiguracionEntidad()
        {
            ToTable("ctlusos");

            HasKey(s => s.Codigo);

            Property(s => s.Nombre)
                .HasMaxLength(128)
                .IsRequired();

            Property(s => s.Estado)
                .IsRequired();
        }
    }
}