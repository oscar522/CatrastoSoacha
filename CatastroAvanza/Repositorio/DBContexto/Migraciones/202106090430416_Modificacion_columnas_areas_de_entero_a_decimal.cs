namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modificacion_columnas_areas_de_entero_a_decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.actividad", "Terreno_AreaTerreno", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.actividad", "Terreno_AreaTerrenoEnMetros", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.actividad", "Terreno_PorcentajeAreaJudicialAreaCatastral", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.actividad", "Terreno_PorcentajeAreaJudicialAreaCatastral", c => c.Int(nullable: false));
            AlterColumn("dbo.actividad", "Terreno_AreaTerrenoEnMetros", c => c.Int(nullable: false));
            AlterColumn("dbo.actividad", "Terreno_AreaTerreno", c => c.Int(nullable: false));
        }
    }
}
