namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevas_columnas_tabla_actividades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividad", "Tramite_Existe_Englobe_Con_Mejora", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Tramite_Requiere_Actualizacion_Nomenclatura", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Terreno_Predio_Requiere_Rectificacion_Area", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Construccion_Tiene_cubrimiento_orto", c => c.Boolean(nullable: false));
            AddColumn("dbo.actividad", "Construccion_Tiene_cubrimiento_visor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividad", "Construccion_Tiene_cubrimiento_visor");
            DropColumn("dbo.actividad", "Construccion_Tiene_cubrimiento_orto");
            DropColumn("dbo.actividad", "Terreno_Predio_Requiere_Rectificacion_Area");
            DropColumn("dbo.actividad", "Tramite_Requiere_Actualizacion_Nomenclatura");
            DropColumn("dbo.actividad", "Tramite_Existe_Englobe_Con_Mejora");
        }
    }
}
