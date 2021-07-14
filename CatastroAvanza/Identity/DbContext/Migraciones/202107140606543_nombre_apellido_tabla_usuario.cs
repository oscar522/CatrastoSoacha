namespace CatastroAvanza.Identity.DbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombre_apellido_tabla_usuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.AspNetUsers", "Nombres", c => c.String());
            AddColumn("public.AspNetUsers", "Apellidos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.AspNetUsers", "Apellidos");
            DropColumn("public.AspNetUsers", "Nombres");
        }
    }
}
