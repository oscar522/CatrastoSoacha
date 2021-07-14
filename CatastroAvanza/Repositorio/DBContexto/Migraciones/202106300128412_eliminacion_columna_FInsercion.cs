namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminacion_columna_FInsercion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.actividaddiaria", "FInsercion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.actividaddiaria", "FInsercion", c => c.Long(nullable: false));
        }
    }
}
