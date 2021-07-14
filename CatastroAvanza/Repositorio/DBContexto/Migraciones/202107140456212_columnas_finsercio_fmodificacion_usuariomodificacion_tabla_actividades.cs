namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnas_finsercio_fmodificacion_usuariomodificacion_tabla_actividades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actividad", "FInsercion", c => c.DateTime(nullable: false));
            AddColumn("dbo.actividad", "FUltimaModificacion", c => c.DateTime(nullable: false));
            AddColumn("dbo.actividad", "UsuarioUltimaModificacion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.actividad", "UsuarioUltimaModificacion");
            DropColumn("dbo.actividad", "FUltimaModificacion");
            DropColumn("dbo.actividad", "FInsercion");
        }
    }
}
