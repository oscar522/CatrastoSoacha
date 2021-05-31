namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregadas_columnas_para_nombre_archivos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividad", "Arcvhivo_FichaPredial", c => c.String());
            AddColumn("dbo.actividad", "Arcvhivo_Plano", c => c.String());
            AddColumn("dbo.actividad", "Arcvhivo_Escrituras", c => c.String());
            AddColumn("dbo.actividad", "Arcvhivo_Croquis", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividad", "Arcvhivo_Croquis");
            DropColumn("dbo.actividad", "Arcvhivo_Escrituras");
            DropColumn("dbo.actividad", "Arcvhivo_Plano");
            DropColumn("dbo.actividad", "Arcvhivo_FichaPredial");
        }
    }
}
