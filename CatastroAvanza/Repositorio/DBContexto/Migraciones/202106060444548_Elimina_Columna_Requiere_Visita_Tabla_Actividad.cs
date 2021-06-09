namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Elimina_Columna_Requiere_Visita_Tabla_Actividad : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.actividad", "Terreno_RequiereVisita");
        }
        
        public override void Down()
        {
            AddColumn("dbo.actividad", "Terreno_RequiereVisita", c => c.String(maxLength: 300));
        }
    }
}
