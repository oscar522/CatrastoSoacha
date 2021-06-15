namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevos_catalogos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ctldestinos",
                c => new
                    {
                        Codigo = c.String(nullable: false, maxLength: 128),
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
            CreateTable(
                "dbo.ctlunidadarea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ctlusos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ctlusos");
            DropTable("dbo.ctlunidadarea");
            DropTable("dbo.ctldestinos");
        }
    }
}
