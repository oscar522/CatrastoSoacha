namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nueva_tabla_archivo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.archivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 300),
                        NombreFisico = c.String(nullable: false, maxLength: 300),
                        CreadoPor = c.String(nullable: false, maxLength: 256),
                        FechaCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AsignacionGestor", "FechaEsperadaFinalizacionAsignacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AsignacionGestor", "FechaEsperadaFinalizacionAsignacion");
            DropTable("dbo.archivo");
        }
    }
}
