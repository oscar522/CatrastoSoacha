namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agrega_Nuevas_Columnas_Tabla_Actividad : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividad", "Terreno_RequiereVisita", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Construccion_Uso_Detalle", c => c.String(maxLength: 300));
            AddColumn("dbo.actividad", "Construccion_Destino_Detalle", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividad", "Construccion_Destino_Detalle");
            DropColumn("dbo.actividad", "Construccion_Uso_Detalle");
            DropColumn("dbo.actividad", "Terreno_RequiereVisita");
        }
    }
}
