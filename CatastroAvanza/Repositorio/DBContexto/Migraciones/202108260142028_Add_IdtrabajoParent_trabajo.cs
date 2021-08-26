namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_IdtrabajoParent_trabajo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trabajos", "IdTrabajoPadre", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trabajos", "IdTrabajoPadre");
        }
    }
}
