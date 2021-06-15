using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class Destino_ConfiguracionEntidad : EntityTypeConfiguration<Destino>
    {
        public Destino_ConfiguracionEntidad()
        {
            ToTable("ctldestinos");

            HasKey(s => s.Codigo);

            Property(s => s.Nombre)
                .HasMaxLength(128)
                .IsRequired();

            Property(s => s.Estado)
                .IsRequired();
        }
    }
}