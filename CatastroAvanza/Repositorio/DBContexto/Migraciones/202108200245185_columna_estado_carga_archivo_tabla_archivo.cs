namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columna_estado_carga_archivo_tabla_archivo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.archivo", "EstadoCarga", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.archivo", "EstadoCarga");
        }
    }
}
