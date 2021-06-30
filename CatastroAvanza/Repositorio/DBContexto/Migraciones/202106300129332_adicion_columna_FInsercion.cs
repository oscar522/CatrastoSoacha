namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicion_columna_FInsercion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividaddiaria", "FInsercion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividaddiaria", "FInsercion");
        }
    }
}
