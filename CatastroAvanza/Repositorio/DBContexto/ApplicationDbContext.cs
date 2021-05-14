using CatastroAvanza.Repositorio.DBContexto.ConfiguracionEntidades;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using CatastroAvanza.Repositorio.DBContexto.Interface;
using System.Data.Entity;

namespace CatastroAvanza.Repositorio.DBContexto
{
    public class ApplicationDbContext : DbContext , IApplicationDbContext
    {
        /// <summary>Constructor por defecto.</summary>
        public ApplicationDbContext()
            : base("name=CatastroAvanzaPostgresDB")
        { }

        public DbSet<ctpais> Pais { get; set; }
        public DbSet<ctdepto> Departamento { get; set; }
        public DbSet<ctciudad> Ciudad { get; set; }
        public DbSet<ctcatalogo> Catalogo { get; set; }
        public DbSet<Actividad> Actividad { get; set; }
        public DbSet<R1_2020_66069_PREDIOS> R1202066069Predios { get; set; }
        public DbSet<R1_2021_69295_PREDIOS> R1202169295Predios { get; set; }
        public DbSet<R2_2021_69295_CONSTRUCCIONES> R2202169295Construcciones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ctpais_ConfiguracionEntidad());
            modelBuilder.Configurations.Add(new ctdepto_ConfiguracionEntidad());
            modelBuilder.Configurations.Add(new ctciudad_ConfiguracionEntidad());
            modelBuilder.Configurations.Add(new ctcatalogo_ConfiguracionEntidad());

            modelBuilder.Configurations.Add(new R1_2020_66069_PREDIOS_ConfiguracionEntidad());
            modelBuilder.Configurations.Add(new R1_2021_69295_PREDIOS_ConfiguracionEntidad());
            modelBuilder.Configurations.Add(new R2_2021_69295_CONSTRUCCIONES_ConfiguracionEntidad());

            base.OnModelCreating(modelBuilder);
        }
    }
}