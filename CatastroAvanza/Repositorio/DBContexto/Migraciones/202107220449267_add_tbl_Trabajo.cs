namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl_Trabajo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionGestor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAsignado = c.String(nullable: false, maxLength: 256),
                        IdActividad = c.Int(nullable: false),
                        FechaAsignacion = c.DateTime(nullable: false),
                        UsuarioQueAsigno = c.String(nullable: false),
                        CreadoPor = c.String(nullable: false, maxLength: 256),
                        FechaCreacion = c.DateTime(nullable: false),
                        UltimaModificacionPor = c.String(nullable: false, maxLength: 256),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabajos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 256),
                        Rol = c.String(),
                        Cantidad = c.Int(nullable: false),
                        PuntosEsfuerzo = c.Int(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        CreadoPor = c.String(nullable: false, maxLength: 256),
                        FechaCreacion = c.DateTime(nullable: false),
                        UltimaModificacionPor = c.String(nullable: false, maxLength: 256),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrabajoGestionRealizada",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdAsignacion = c.Int(nullable: false),
                        EstadoGestion = c.String(nullable: false, maxLength: 256),
                        FechaModificacionGestion = c.DateTime(nullable: false),
                        Observacion = c.String(nullable: false),
                        EstadoRegistro = c.Boolean(nullable: false),
                        CreadoPor = c.String(nullable: false, maxLength: 256),
                        FechaCreacion = c.DateTime(nullable: false),
                        UltimaModificacionPor = c.String(nullable: false, maxLength: 256),
                        FechaUltimaModificacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TrabajoGestionRealizada");
            DropTable("dbo.Trabajos");
            DropTable("dbo.AsignacionGestor");
        }
    }
}
