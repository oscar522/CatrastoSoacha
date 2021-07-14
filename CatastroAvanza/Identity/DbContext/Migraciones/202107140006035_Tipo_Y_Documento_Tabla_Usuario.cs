namespace CatastroAvanza.Identity.DbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tipo_Y_Documento_Tabla_Usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.AspNetUsers", "Documento", c => c.String(maxLength: 256));
            AddColumn("public.AspNetUsers", "TipoDocumento", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("public.AspNetUsers", "TipoDocumento");
            DropColumn("public.AspNetUsers", "Documento");
        }
    }
}
