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

            Property(s => s.NumeroPredial)
                .HasMaxLength(30)
                .IsRequired();

            Property(s => s.Observacion)
                .HasMaxLength(300);

            Property(s => s.LinderosFmi)
                .HasMaxLength(300);

            Property(s => s.LinderosFmi)
                .HasMaxLength(300);

            Property(s => s.FmiCorrecto)
                .HasMaxLength(300);

            Property(s => s.NomenclaturaAActualizar)
                .HasMaxLength(300);

            Property(s => s.EscrituraLinderos)
                .HasMaxLength(300);

            Property(s => s.RequiereVisita)
                .HasMaxLength(300);

            Property(s => s.ObservacionUsosDestino)
                .HasMaxLength(300);
        }
    }
}