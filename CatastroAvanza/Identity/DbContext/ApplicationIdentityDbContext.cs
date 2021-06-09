using CatastroAvanza.Identity.Model;
using PostgreSQL.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CatastroAvanza.Identity.DbContext
{
    //[DbConfigurationType(typeof(Configuration))]
    public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationIdentityDbContext()
           : base("CatastroAvanzaPostgresDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            

            // If you are letting EntityFrameowrk to create the database, 
            // it will by default create the __MigrationHisotry table in the dbo schema
            // Use HasDefaultSchema to specify alternative (i.e public) schema
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}