using System.Data.Entity.Migrations;

namespace CatastroAvanza.Identity.DbContext
{
    /// <summary>
    /// Migration configurarion
    /// Para activar las migraciones (Solo la primera vez)
    /// Enable-Migrations -ContextTypeName CatastroAvanza.Identity.DbContext.ApplicationIdentityDbContext -MigrationsDirectory Identity\DbContext 
    /// Para realizar modificaciones en la estructura de la base de datos
    /// Add-Migration {Nombre de la nueva migracion} -ConfigurationTypeName CatastroAvanza.Identity.DbContext.Configuration -ProjectName CatastroAvanza.Site
    /// Para actualizar la estructura de la base de datos
    /// Update-Database -ConfigurationTypeName CatastroAvanza.Identity.DbContext.Configuration
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Identity\DbContext\Migraciones";
        }

        protected override void Seed(ApplicationIdentityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
