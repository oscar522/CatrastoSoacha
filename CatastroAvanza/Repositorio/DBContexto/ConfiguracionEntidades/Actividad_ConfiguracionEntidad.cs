using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades
{
    public class Actividad_ConfiguracionEntidad : EntityTypeConfiguration<Actividad>
    {
        public Actividad_ConfiguracionEntidad()
        {
            ToTable("actividad");

            HasKey(s => s.Id);

            Property(s => s.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(s => s.General_NumeroPredial)
                .HasMaxLength(30)
                .IsRequired();

            Property(s => s.Geografica_Observacion)
                .HasMaxLength(300);

            Property(s => s.Tramite_LinderosFmi)
                .HasMaxLength(300);

            Property(s => s.Geografica_FmiCorrecto)
                .HasMaxLength(300);

            Property(s => s.Nomenclatura_NomenclaturaAActualizar)
                .HasMaxLength(300);

            Property(s => s.Terreno_EscrituraLinderos)
                .HasMaxLength(300);

            Property(s => s.Construccion_ObservacionUsosDestino)
                .HasMaxLength(300);

            Property(s => s.Construccion_Destino_Detalle)
                .HasMaxLength(300);

            Property(s => s.Construccion_Uso_Detalle)
            .HasMaxLength(300);

            Property(s => s.Economico_Observaciones)
            .HasMaxLength(300);
        }
    }
}