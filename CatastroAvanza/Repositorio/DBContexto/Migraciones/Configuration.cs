using System.Data.Entity.Migrations;

namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    /// <summary>
    /// Migration configurarion
    /// Para activar las migraciones (Solo la primera vez)
    /// Enable-Migrations -ContextTypeName CatastroAvanza.Repositorio.DBContexto.ApplicationDbContext -MigrationsDirectory Repositorio\DBContexto\Migrations
    /// Para realizar modificaciones en la estructura de la base de datos
    /// Add-Migration {Nombre de la nueva migracion} -ConfigurationTypeName CatastroAvanza.Repositorio.DBContexto.Migraciones.Configuration -ProjectName CatastroAvanza.Site
    /// Para actualizar la estructura de la base de datos
    /// Update-Database -ConfigurationTypeName CatastroAvanza.Repositorio.DBContexto.Migraciones.Configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<CatastroAvanza.Repositorio.DBContexto.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Repositorio\DBContexto\Migraciones";
        }

        protected override void Seed(CatastroAvanza.Repositorio.DBContexto.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
