namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Columnas_Economico_Agregadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividad", "Economico_Requiere_Revision_Tipologias", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Economico_Requiere_Revision_Zonas", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Economico_Observaciones", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividad", "Economico_Observaciones");
            DropColumn("dbo.actividad", "Economico_Requiere_Revision_Zonas");
            DropColumn("dbo.actividad", "Economico_Requiere_Revision_Tipologias");
        }
    }
}
