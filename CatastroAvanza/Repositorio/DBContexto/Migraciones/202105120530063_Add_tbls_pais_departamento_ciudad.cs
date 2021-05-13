using System;
using System.Data.Entity.Migrations;

namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    public partial class Add_tbls_pais_departamento_ciudad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ctciudad",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idctpais = c.Int(nullable: false),
                        idctdepto = c.Int(nullable: false),
                        idctmuncipio = c.Int(nullable: false),
                        nombre = c.String(nullable: false),
                        estado = c.Int(nullable: false),
                        zonafocalizada = c.Boolean(nullable: false),
                        flagfocalizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ctdepto",
                c => new
                    {
                        id_ct_depto = c.Int(nullable: false, identity: true),
                        id_ct_pais = c.Int(nullable: false),
                        nombre = c.String(nullable: false),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_ct_depto);
            
            CreateTable(
                "dbo.ctpais",
                c => new
                    {
                        id_ct_pais = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_ct_pais);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ctpais");
            DropTable("dbo.ctdepto");
            DropTable("dbo.ctciudad");
        }
    }
}
