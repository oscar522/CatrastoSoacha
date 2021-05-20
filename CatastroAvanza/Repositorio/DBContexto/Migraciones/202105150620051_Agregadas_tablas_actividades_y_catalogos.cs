namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Agregadas_tablas_actividades_y_catalogos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPredial = c.String(),
                        Ejecutor = c.String(),
                        Coordinador = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Omision = c.Boolean(nullable: false),
                        DuplicadoGeograficamente = c.Boolean(nullable: false),
                        NumeroDuplicados = c.Int(nullable: false),
                        RequiereVisitaGeografica = c.Boolean(nullable: false),
                        Observacion = c.String(),
                        Fmi = c.String(),
                        FmiDuplicados = c.Boolean(nullable: false),
                        NumeroFmiDuplicados = c.Int(nullable: false),
                        VerificacionFmi = c.Boolean(nullable: false),
                        FmiCorrecto = c.String(),
                        CertificadoNomenclatura = c.String(),
                        NomenclaturaPredio = c.Boolean(nullable: false),
                        NomenclaturaAActualizar = c.String(),
                        PropietariosCorrectos = c.Boolean(nullable: false),
                        Englobe = c.Boolean(nullable: false),
                        Desenglobe = c.Boolean(nullable: false),
                        Unidadestramite = c.Int(nullable: false),
                        ReglamentoPH = c.Boolean(nullable: false),
                        UnidadesReglamento = c.Int(nullable: false),
                        Linderos = c.Boolean(nullable: false),
                        LinderosFmi = c.String(),
                        LinderosArcifinios = c.Boolean(nullable: false),
                        LinderosVerificablesTerreno = c.Boolean(nullable: false),
                        EscrituraLinderos = c.String(),
                        TieneArea = c.Boolean(nullable: false),
                        AreaTerreno = c.Int(nullable: false),
                        UnidadArea = c.String(),
                        AreaTerrenoEnMetros = c.Int(nullable: false),
                        PorcentajeAreaJudicialAreaCatastral = c.Int(nullable: false),
                        IdentificacionPredio = c.Boolean(nullable: false),
                        RequiereVisita = c.String(),
                        ObservacionVisita = c.String(),
                        FotoFachada = c.String(),
                        IncorporacioArea = c.Boolean(nullable: false),
                        DetalleIncorporacionArea = c.String(),
                        Uso = c.Boolean(nullable: false),
                        Destino = c.Boolean(nullable: false),
                        ObservacionUsosDestino = c.String(),
                        RequiereVisitaConstruccion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ctcatalogo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Tipo = c.String(nullable: false, maxLength: 50),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ctcatalogo");
            DropTable("dbo.Actividads");
        }
    }
}
