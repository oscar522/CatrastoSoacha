using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Repositorio.DBContexto.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace CatastroAvanza.Mapeadores
{
    public class MapeadoresApplicacion : IMapeadoresApplicacion
    {
        public DataForm1Model MapDataAModel(R1_2021_69295_PREDIOS predio2021,
            string cantidadMejora,
            ICollection<R1_2021_69295_PREDIOS> predios2021,
            ICollection<R2_2021_69295_CONSTRUCCIONES> construcciones2021, 
            ICollection<R1_2020_66069_PREDIOS> predios2020)
        {
            if (predio2021 == null)
                return new DataForm1Model();

            DataForm1Model result = new DataForm1Model
            {
                id = predio2021.id,
                dep = predio2021.dep,
                mun = predio2021.mun,
                NUMERO_DEL_PREDIO = predio2021.NUMERO_DEL_PREDIO,
                Tipo_de_registro = predio2021.Tipo_de_registro,
                NUMERO_DE_ORDEN = predio2021.NUMERO_DE_ORDEN,
                TOTAL_REGISTROS = predio2021.TOTAL_REGISTROS,
                NOMBRE = predio2021.NOMBRE,
                TIPO_DOCUMENTO = predio2021.TIPO_DOCUMENTO,
                NUMERO_DOCUMENTO = predio2021.NUMERO_DOCUMENTO,
                DIRECCION = predio2021.DIRECCION,
                DESTINO_ECONOMICO = predio2021.DESTINO_ECONOMICO,
                AREA_TERRENO = predio2021.AREA_TERRENO,
                AREA_CONSTRUIDA = predio2021.AREA_CONSTRUIDA,
                AVALUO = predio2021.AVALUO,
                VIGENCIA = predio2021.VIGENCIA,
                NUMERO_PREDIAL_ANTERIOR= predio2021.NUMERO_PREDIAL_ANTERIOR,
                CANTIDAD_MEJORA = cantidadMejora,
                CANTIDAD_PROPIETARIOS = predios2021.Select(X => X.TIPO_DOCUMENTO + " - " + X.NUMERO_DOCUMENTO + " - " + X.NOMBRE).ToList(),
                R1_2020_66069_PREDIOSModel = predios2020.Select(t => new R1_2020_66069_PREDIOSModel
                {
                    id = t.id,
                    dep = t.dep,
                    mun = t.mun,
                    NUMERO_DEL_PREDIO = t.NUMERO_DEL_PREDIO,
                    TIPO_DEL_REGISTRO = t.TIPO_DEL_REGISTRO,
                    DIRECCION = t.DIRECCION,
                    COMUNA = t.COMUNA,
                    DESTINO_ECONOMICO = t.DESTINO_ECONOMICO,
                    DESCRIPCION_DESTINO = t.DESCRIPCION_DESTINO,
                    AREA_TERRENO = t.AREA_TERRENO,
                    AREA_CONSTRUIDA = t.AREA_CONSTRUIDA,
                    AVALUO = t.AVALUO,
                    VIGENCIA = t.VIGENCIA,
                    NUMERO_PREDIAL_ANTERIOR = t.NUMERO_PREDIAL_ANTERIOR,
                }).ToList(),
                R2_2021_69295_CONSTRUCCIONESModel = construcciones2021.Select(t => new R2_2021_69295_CONSTRUCCIONESModel
                {
                    id = t.id,
                    dep = t.dep,
                    //nomDep = context.ctdepto.Where(x => x.id_ct_depto == t.dep).FirstOrDefault().nombre,
                    mun = t.mun,
                    //nomMun = context.ctciudad.Where(x => x.idctdepto == t.dep && x.idctmuncipio == t.mun).FirstOrDefault().nombre,
                    NUMERO_DEL_PREDIO = t.NUMERO_DEL_PREDIO,
                    tipo_de_reg = t.tipo_de_reg,
                    Campo3 = t.Campo3,
                    Campo4 = t.Campo4,
                    FMI = t.FMI,
                    Campo6 = t.Campo6,
                    Campo7 = t.Campo7,
                    Campo8 = t.Campo8,
                    Campo9 = t.Campo9,
                    Campo10 = t.Campo10,
                    Campo11 = t.Campo11,
                    USO = t.USO,
                    Campo13 = t.Campo13,
                    AREA_CONSTRUIDA = t.AREA_CONSTRUIDA,
                    Campo15 = t.Campo15,
                    Campo16 = t.Campo16,
                    Campo17 = t.Campo17,
                    USO_2 = t.USO_2,
                    AREA_CONSTRUIDA_2 = t.AREA_CONSTRUIDA_2,
                    USO_3 = t.USO_3,
                    AREA_CONSTRUIDA_3 = t.AREA_CONSTRUIDA_3,
                }).ToList(),
            };

            return result;
        }

        public ICollection<CatalogoViewModel> MapDataAModel(ICollection<ctcatalogo> catalogos)
        {
            ICollection<CatalogoViewModel> result = catalogos
                .Select(m => new CatalogoViewModel { Value = m.Id, Text = m.Nombre })
                .ToList();

            return result;
        }

        public Actividad MapModelAData(ActividadGeneralViewModel model)
        {
            Actividad result = new Actividad();

            if (model != null)
            {
                result.NumeroPredial = model.NumeroPredial;
                result.Ejecutor = model.Ejecutor.ToString();
                result.Coordinador = model.Coordinador.ToString();
                result.Fecha = model.Fecha;
                result.PropietariosCorrectos = model.PropietariosCorrectos;
            }

            if (model.Geografica != null)
            {
                result.Omision = model.Geografica.Omision;
                result.DuplicadoGeograficamente = model.Geografica.DuplicadoGeograficamente;
                result.NumeroDuplicados = model.Geografica.NumeroDuplicados;
                result.RequiereVisitaGeografica = model.Geografica.RequiereVisitaGeografica;
                result.Observacion = model.Geografica.Observacion;
                
            }

            if (model.Construccion != null)
            {
                result.FotoFachada = model.Construccion.FotoFachada.FileName;
                result.IncorporacioArea = model.Construccion.IncorporacioArea;
                result.DetalleIncorporacionArea = model.Construccion.DetalleIncorporacionArea;
                result.Uso = model.Construccion.Uso;
                result.Destino = model.Construccion.Destino;
                result.ObservacionUsosDestino = model.Construccion.ObservacionUsosDestino;
                result.RequiereVisitaConstruccion = model.Construccion.RequiereVisitaConstruccion;
            }


            if (model.Folio != null)
            {
                result.Fmi = model.Folio.Fmi.FileName;
                result.FmiDuplicados = model.Folio.FmiDuplicados;
                result.NumeroFmiDuplicados = model.Folio.NumeroFmiDuplicados;
                result.VerificacionFmi = model.Folio.VerificacionFmi;
                result.FmiCorrecto = model.Folio.FmiCorrecto;
            }

            if (model.Nomenclatura != null)
            {
                result.CertificadoNomenclatura = model.Nomenclatura.CertificadoNomenclatura.FileName;
                result.NomenclaturaPredio = model.Nomenclatura.NomenclaturaPredio;
                result.NomenclaturaAActualizar = model.Nomenclatura.NomenclaturaAActualizar;
            }

            if (model.Tramite != null)
            {
                result.Englobe = model.Tramite.Englobe;
                result.Desenglobe = model.Tramite.Desenglobe;
                result.Unidadestramite = model.Tramite.Unidadestramite;
                result.ReglamentoPH = model.Tramite.ReglamentoPH;
                result.UnidadesReglamento = model.Tramite.UnidadesReglamento;
            }

            if(model.Terreno != null)
            {
                result.AreaTerreno = model.Terreno.AreaTerreno;
                result.Linderos = model.Terreno.Linderos;
                result.LinderosFmi = model.Terreno.LinderosFmi;
                result.LinderosArcifinios = model.Terreno.LinderosArcifinios;
                result.LinderosVerificablesTerreno = model.Terreno.LinderosVerificablesTerreno;
                result.EscrituraLinderos = model.Terreno.EscrituraLinderos;
                result.TieneArea = model.Terreno.TieneArea;
                result.AreaTerreno = model.Terreno.AreaTerreno;
                result.UnidadArea = model.Terreno.UnidadArea.ToString();
                result.AreaTerrenoEnMetros = model.Terreno.AreaTerrenoEnMetros;
                result.PorcentajeAreaJudicialAreaCatastral = model.Terreno.PorcentajeAreaJudicialAreaCatastral;
                result.IdentificacionPredio = model.Terreno.IdentificacionPredio;
                result.RequiereVisita = model.Terreno.RequiereVisita;
                result.ObservacionVisita = model.Terreno.ObservacionVisita;
            }

            return result;

        }
    }
}