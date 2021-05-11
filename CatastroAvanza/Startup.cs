using CatastroAvanza.Identity.DbContext;
using Owin;
using System.Data.Entity;
using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(CatastroAvanza.Startup))]
namespace CatastroAvanza
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // CreateDatabaseIfNotExists is the default initializer if not specified
            Database.SetInitializer<ApplicationIdentityDbContext>(new CreateDatabaseIfNotExists<ApplicationIdentityDbContext>());

            // NullDatabaseInitializer will turn off migration. 
            // You need to manually create the data tables
            //Database.SetInitializer<ApplicationDbContext>(new NullDatabaseInitializer<ApplicationDbContext>());
        }
    }
}