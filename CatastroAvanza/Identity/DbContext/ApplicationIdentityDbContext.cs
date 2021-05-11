using CatastroAvanza.Identity.Model;
using Npgsql;
using PostgreSQL.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;

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
    ////internal class Configuration : DbConfiguration
    ////{
    ////    public Configuration()
    ////    {
    ////        SetMigrationSqlGenerator("Npgsql", () => new SqlGenerator());
    ////    }
    ////}

    //public class SqlGenerator : NpgsqlMigrationSqlGenerator
    //{
    //    private readonly string[] systemColumnNames = { "oid", "tableoid", "xmin", "cmin", "xmax", "cmax", "ctid" };

    //    protected override void Convert(CreateTableOperation createTableOperation)
    //    {
    //        var systemColumns = createTableOperation.Columns.Where(x => systemColumnNames.Contains(x.Name)).ToArray();
    //        foreach (var systemColumn in systemColumns)
    //            createTableOperation.Columns.Remove(systemColumn);
    //        base.Convert(createTableOperation);
    //    }
    //}
}