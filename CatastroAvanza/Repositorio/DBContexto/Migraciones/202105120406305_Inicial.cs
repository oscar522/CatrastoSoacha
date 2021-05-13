namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.R1_2020_66069_PREDIOS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dep = c.Int(nullable: false),
                        mun = c.Int(nullable: false),
                        NUMERO_DEL_PREDIO = c.String(),
                        TIPO_DEL_REGISTRO = c.String(),
                        DIRECCION = c.String(),
                        COMUNA = c.String(),
                        DESTINO_ECONOMICO = c.String(),
                        DESCRIPCION_DESTINO = c.String(),
                        AREA_TERRENO = c.String(),
                        AREA_CONSTRUIDA = c.String(),
                        AVALUO = c.String(),
                        VIGENCIA = c.String(),
                        NUMERO_PREDIAL_ANTERIOR = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.R1_2021_69295_PREDIOS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dep = c.Int(nullable: false),
                        mun = c.Int(nullable: false),
                        NUMERO_DEL_PREDIO = c.String(),
                        Tipo_de_registro = c.Int(nullable: false),
                        NUMERO_DE_ORDEN = c.String(),
                        TOTAL_REGISTROS = c.String(),
                        NOMBRE = c.String(),
                        TIPO_DOCUMENTO = c.String(),
                        NUMERO_DOCUMENTO = c.String(),
                        DIRECCION = c.String(),
                        DESTINO_ECONOMICO = c.String(),
                        AREA_TERRENO = c.String(),
                        AREA_CONSTRUIDA = c.String(),
                        AVALUO = c.String(),
                        VIGENCIA = c.String(),
                        NUMERO_PREDIAL_ANTERIOR = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.R2_2021_69295_CONSTRUCCIONES",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dep = c.Int(nullable: false),
                        mun = c.Int(nullable: false),
                        NUMERO_DEL_PREDIO = c.String(),
                        tipo_de_reg = c.String(),
                        Campo3 = c.String(),
                        Campo4 = c.String(),
                        FMI = c.String(),
                        Campo6 = c.String(),
                        Campo7 = c.String(),
                        Campo8 = c.String(),
                        Campo9 = c.String(),
                        Campo10 = c.String(),
                        Campo11 = c.String(),
                        USO = c.String(),
                        Campo13 = c.String(),
                        AREA_CONSTRUIDA = c.String(),
                        Campo15 = c.String(),
                        Campo16 = c.String(),
                        Campo17 = c.String(),
                        USO_2 = c.String(),
                        AREA_CONSTRUIDA_2 = c.String(),
                        USO_3 = c.String(),
                        AREA_CONSTRUIDA_3 = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.R2_2021_69295_CONSTRUCCIONES");
            DropTable("dbo.R1_2021_69295_PREDIOS");
            DropTable("dbo.R1_2020_66069_PREDIOS");
        }
    }
}
