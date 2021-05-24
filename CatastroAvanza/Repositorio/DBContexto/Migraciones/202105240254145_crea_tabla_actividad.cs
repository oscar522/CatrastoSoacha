namespace CatastroAvanza.Repositorio.DBContexto.Migraciones
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crea_tabla_actividad : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actividad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        General_NumeroPredial = c.String(nullable: false, maxLength: 30),
                        General_Ejecutor = c.String(),
                        General_Coordinador = c.String(),
                        General_Fecha = c.DateTime(nullable: false),
                        Geografica_Omision = c.Boolean(nullable: false),
                        Geografica_DuplicadoGeograficamente = c.Boolean(nullable: false),
                        Geografica_NumeroDuplicados = c.Int(nullable: false),
                        Geografica_RequiereVisitaGeografica = c.Boolean(nullable: false),
                        Geografica_Observacion = c.String(maxLength: 300),
                        Geografica_FmiDuplicados = c.Boolean(nullable: false),
                        Geografica_NumeroFmiDuplicados = c.Int(nullable: false),
                        Geografica_VerificacionFmi = c.Boolean(nullable: false),
                        Geografica_FmiCorrecto = c.String(maxLength: 300),
                        Nomenclatura_NomenclaturaPredio = c.Boolean(nullable: false),
                        Nomenclatura_NomenclaturaAActualizar = c.String(maxLength: 300),
                        Tramite_PropietariosCorrectos = c.Boolean(nullable: false),
                        Tramite_Englobe = c.Boolean(nullable: false),
                        Tramite_Desenglobe = c.Boolean(nullable: false),
                        Tramite_Unidadestramite = c.Int(nullable: false),
                        Tramite_ReglamentoPH = c.Boolean(nullable: false),
                        Tramite_UnidadesReglamento = c.Int(nullable: false),
                        Tramite_Linderos = c.Boolean(nullable: false),
                        Tramite_LinderosFmi = c.String(maxLength: 300),
                        Tramite_LinderosArcifinios = c.Boolean(nullable: false),
                        Tramite_LinderosEnEscritura = c.Boolean(nullable: false),
                        Tramite_NumeroEscritura = c.String(),
                        Tramite_LinderosVerificablesTerreno = c.Boolean(nullable: false),
                        Terreno_EscrituraLinderos = c.String(maxLength: 300),
                        Terreno_TieneArea = c.Boolean(nullable: false),
                        Terreno_AreaTerreno = c.Int(nullable: false),
                        Terreno_UnidadArea = c.String(),
                        Terreno_AreaTerrenoEnMetros = c.Int(nullable: false),
                        Terreno_PorcentajeAreaJudicialAreaCatastral = c.Int(nullable: false),
                        Terreno_IdentificacionPredio = c.Boolean(nullable: false),
                        Terreno_RequiereVisita = c.String(maxLength: 300),
                        Terreno_ObservacionVisita = c.String(),
                        Construccion_IncorporacioArea = c.Boolean(nullable: false),
                        Construccion_DetalleIncorporacionArea = c.String(),
                        Construccion_Uso = c.Boolean(nullable: false),
                        Construccion_Destino = c.Boolean(nullable: false),
                        Construccion_ObservacionUsosDestino = c.String(maxLength: 300),
                        Construccion_RequiereVisitaConstruccion = c.Boolean(nullable: false),
                        Construccion_TieneConstrucciones = c.Boolean(nullable: false),
                        Construccion_ConstruccionEsCorrecta = c.Boolean(nullable: false),
                        Construccion_AdicionaCancelaUnidades = c.Boolean(nullable: false),
                        Construccion_AdicionarConstrucciones = c.Boolean(nullable: false),
                        Construccion_ElminarConstrucciones = c.Boolean(nullable: false),
                        Construccion_AdicionarAnexos = c.Boolean(nullable: false),
                        Construccion_ElminarAnexos = c.Boolean(nullable: false),
                        General_Departamento = c.Int(nullable: false),
                        General_Municipio = c.Int(nullable: false),
                        General_Comuna = c.String(),
                        General_Vereda = c.String(),
                        General_Barrio = c.String(),
                        General_Direccion = c.String(),
                        General_Direccion2 = c.String(),
                        General_TipoDireccion = c.Int(nullable: false),
                        General_Condicion = c.String(),
                        General_Mejoras = c.Boolean(nullable: false),
                        General_Numero_Mejoras = c.Int(nullable: false),
                        General_Destino = c.String(),
                        General_AreaTerreno = c.Decimal(nullable: false, precision: 18, scale: 2),
                        General_AreaConstruida = c.Decimal(nullable: false, precision: 18, scale: 2),
                        General_Avaluo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Arcvhivo_FotoFachada = c.String(),
                        Arcvhivo_Fmi = c.String(),
                        Arcvhivo_CertificadoNomenclatura = c.String(),
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
            DropTable("dbo.actividad");
        }
    }
}
