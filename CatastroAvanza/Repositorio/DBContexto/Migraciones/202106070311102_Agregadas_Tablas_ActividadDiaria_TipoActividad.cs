namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregadas_Tablas_ActividadDiaria_TipoActividad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actividaddiaria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        idapsnetuser = c.String(nullable: false, maxLength: 128),
                        idproceso = c.Int(nullable: false),
                        idmodalidad = c.Int(nullable: false),
                        idrol = c.String(nullable: false, maxLength: 128),
                        FechaActividad = c.DateTime(nullable: false),
                        idactividad = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        Observacion = c.String(),
                        Estado = c.Boolean(nullable: false),
                        FInsercion = c.Long(nullable: false),
                        iddepto = c.Int(nullable: false),
                        idmuni = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tipoactividad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        actividad = c.String(nullable: false, maxLength: 300),
                        Estado = c.Boolean(nullable: false),
                        rol = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tipoactividad");
            DropTable("dbo.actividaddiaria");
        }
    }
}
