using CatastroAvanza.Models.ActividadesDiarias;
using CatastroAvanza.Models.ActividadViewModels;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.HPSF;
using System.IO;
using System.Web.Security;
using System.Collections.Generic;
using IronXL;

namespace CatastroAvanza.Infraestructura
{
    public class GeneracionExcel
    {

        public HSSFWorkbook GenerarArchivoExcelActividadesDiarias(IEnumerable<ActividadesDiariasExcelModel> actividades)
        {           
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Actividades diarias");

            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);            
            row.CreateCell(0).SetCellValue("Id");
            row.CreateCell(1).SetCellValue("FechaActividadS");
            row.CreateCell(2).SetCellValue("IdProceso");
            row.CreateCell(3).SetCellValue("NombreProceso");
            row.CreateCell(4).SetCellValue("IdModalidad?");
            row.CreateCell(5).SetCellValue("NombreModalidad");

            row.CreateCell(6).SetCellValue("RolUsuario");
            row.CreateCell(7).SetCellValue("IdRolActividad");
            row.CreateCell(8).SetCellValue("NombreRolActividad");
            row.CreateCell(9).SetCellValue("IdActividad");
            row.CreateCell(10).SetCellValue("NombreActividad");
            row.CreateCell(11).SetCellValue("Cantidad");
            row.CreateCell(12).SetCellValue("Observacion");
            row.CreateCell(13).SetCellValue("IdDepartamento");

            row.CreateCell(14).SetCellValue("Departamento");
            row.CreateCell(15).SetCellValue("IdMunicipio");
            row.CreateCell(16).SetCellValue("Municipio");            
            row.CreateCell(17).SetCellValue("Estado");
            row.CreateCell(18).SetCellValue("FechaInsercion");
            rowIndex++;           

            foreach (var actividad in actividades)
            {
                row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue(actividad.Id.ToString());
                row.CreateCell(1).SetCellValue(actividad.FechaActividadS);
                row.CreateCell(2).SetCellValue(actividad.IdProceso);
                row.CreateCell(3).SetCellValue(actividad.NombreProceso);
                row.CreateCell(4).SetCellValue(actividad.IdModalidad);
                row.CreateCell(5).SetCellValue(actividad.NombreModalidad);
                row.CreateCell(6).SetCellValue(actividad.RolUsuario);
                row.CreateCell(7).SetCellValue(actividad.IdRolActividad);
                row.CreateCell(8).SetCellValue(actividad.NombreRolActividad);
                row.CreateCell(9).SetCellValue(actividad.IdActividad);
                row.CreateCell(10).SetCellValue(actividad.NombreActividad);
                row.CreateCell(11).SetCellValue(actividad.Cantidad);
                row.CreateCell(12).SetCellValue(actividad.Observacion);
                row.CreateCell(13).SetCellValue(actividad.IdDepartamento);
                row.CreateCell(14).SetCellValue(actividad.Departamento);
                row.CreateCell(15).SetCellValue(actividad.IdMunicipio);
                row.CreateCell(16).SetCellValue(actividad.Municipio);
                row.CreateCell(17).SetCellValue(actividad.Estado);
                row.CreateCell(18).SetCellValue(actividad.FechaInsercion.ToString());
                rowIndex++;
            }

            foreach (var cell in row.Cells)
            {
                sheet.AutoSizeColumn(cell.ColumnIndex);
            }

            return workbook;            
        }


        public HSSFWorkbook GenerarArchivoExcelDiagnostico(IEnumerable<ActividadExcelModel> diagnosticos)
        {
            var workbook = new HSSFWorkbook();
            var sheet = workbook.CreateSheet("Actividades diarias");

            var rowIndex = 0;
            var row = sheet.CreateRow(rowIndex);
            row.CreateCell(0).SetCellValue("Id");
            row.CreateCell(1).SetCellValue("General_NumeroPredial");
            row.CreateCell(2).SetCellValue("General_Ejecutor");
            row.CreateCell(3).SetCellValue("General_Coordinador");
            row.CreateCell(4).SetCellValue("General_CoordinadorNombre");
            row.CreateCell(5).SetCellValue("General_Fecha");
            row.CreateCell(6).SetCellValue("General_Departamento");
            row.CreateCell(7).SetCellValue("General_DepartamentoNombre");
            row.CreateCell(8).SetCellValue("General_Municipio");
            row.CreateCell(9).SetCellValue("General_MunicipioNombre");
            row.CreateCell(10).SetCellValue("General_Comuna");
            row.CreateCell(11).SetCellValue("General_Vereda");
            row.CreateCell(12).SetCellValue("General_Barrio");
            row.CreateCell(13).SetCellValue("General_Direccion");
            row.CreateCell(14).SetCellValue("General_Direccion2");
            row.CreateCell(15).SetCellValue("General_TipoDireccion");
            row.CreateCell(16).SetCellValue("General_Condicion");
            row.CreateCell(17).SetCellValue("General_Mejoras");
            row.CreateCell(18).SetCellValue("General_Numero_Mejoras");
            row.CreateCell(19).SetCellValue("General_Destino");
            row.CreateCell(20).SetCellValue("General_AreaTerreno");
            row.CreateCell(21).SetCellValue("General_AreaConstruida");
            row.CreateCell(22).SetCellValue("General_Avaluo");

            row.CreateCell(23).SetCellValue("Geografica_Omision");
            row.CreateCell(24).SetCellValue("Geografica_DuplicadoGeograficamente");
            row.CreateCell(25).SetCellValue("Geografica_NumeroDuplicados");
            row.CreateCell(26).SetCellValue("Geografica_RequiereVisitaGeografica");
            row.CreateCell(27).SetCellValue("Geografica_Observacion");
            row.CreateCell(28).SetCellValue("Geografica_FmiDuplicados");
            row.CreateCell(29).SetCellValue("Geografica_NumeroFmiDuplicados");
            row.CreateCell(30).SetCellValue("Geografica_VerificacionFmi");
            row.CreateCell(31).SetCellValue("Geografica_FmiCorrecto");

            row.CreateCell(32).SetCellValue("Tramite_PropietariosCorrectos");
            row.CreateCell(33).SetCellValue("Tramite_Englobe");
            row.CreateCell(34).SetCellValue("Tramite_Desenglobe");
            row.CreateCell(35).SetCellValue("Tramite_Unidadestramite");
            row.CreateCell(36).SetCellValue("Tramite_ReglamentoPH");
            row.CreateCell(37).SetCellValue("Tramite_UnidadesReglamento");
            row.CreateCell(38).SetCellValue("Tramite_Linderos");
            row.CreateCell(39).SetCellValue("Tramite_LinderosFmi");
            row.CreateCell(40).SetCellValue("Tramite_LinderosArcifinios");
            row.CreateCell(41).SetCellValue("Tramite_LinderosEnEscritura");
            row.CreateCell(42).SetCellValue("Tramite_NumeroEscritura");
            row.CreateCell(43).SetCellValue("Tramite_LinderosVerificablesTerreno");
            row.CreateCell(44).SetCellValue("Tramite_Existe_Englobe_Con_Mejora");
            row.CreateCell(45).SetCellValue("Tramite_Requiere_Actualizacion_Nomenclatura");

            row.CreateCell(46).SetCellValue("Terreno_EscrituraLinderos");
            row.CreateCell(47).SetCellValue("Terreno_TieneArea");
            row.CreateCell(48).SetCellValue("Terreno_AreaTerreno");
            row.CreateCell(49).SetCellValue("Terreno_UnidadArea");
            row.CreateCell(50).SetCellValue("Terreno_AreaTerrenoEnMetros");
            row.CreateCell(51).SetCellValue("Terreno_PorcentajeAreaJudicialAreaCatastral");
            row.CreateCell(52).SetCellValue("Terreno_IdentificacionPredio");
            row.CreateCell(53).SetCellValue("Terreno_ObservacionVisita");

            row.CreateCell(54).SetCellValue("Construccion_IncorporacioArea");
            row.CreateCell(55).SetCellValue("Construccion_DetalleIncorporacionArea");
            row.CreateCell(56).SetCellValue("Construccion_Uso");
            row.CreateCell(57).SetCellValue("Construccion_Destino");
            row.CreateCell(58).SetCellValue("Construccion_ObservacionUsosDestino");
            row.CreateCell(59).SetCellValue("Construccion_RequiereVisitaConstruccion");
            row.CreateCell(60).SetCellValue("Construccion_TieneConstrucciones");
            row.CreateCell(61).SetCellValue("Construccion_ConstruccionEsCorrecta");
            row.CreateCell(62).SetCellValue("Construccion_AdicionaCancelaUnidades");
            row.CreateCell(63).SetCellValue("Construccion_AdicionarConstrucciones");
            row.CreateCell(64).SetCellValue("Construccion_ElminarConstrucciones");
            row.CreateCell(65).SetCellValue("Construccion_AdicionarAnexos");
            row.CreateCell(66).SetCellValue("Construccion_ElminarAnexos");
            row.CreateCell(67).SetCellValue("Construccion_Tiene_cubrimiento_orto");
            row.CreateCell(68).SetCellValue("Construccion_Tiene_cubrimiento_visor");
            row.CreateCell(69).SetCellValue("Construccion_Uso_Detalle");
            row.CreateCell(70).SetCellValue("Construccion_Destino_Detalle");

            row.CreateCell(71).SetCellValue("Arcvhivo_FotoFachada");
            row.CreateCell(72).SetCellValue("Arcvhivo_Fmi");
            row.CreateCell(72).SetCellValue("Arcvhivo_CertificadoNomenclatura");
            row.CreateCell(74).SetCellValue("Arcvhivo_FichaPredial");
            row.CreateCell(75).SetCellValue("Arcvhivo_Plano");
            row.CreateCell(76).SetCellValue("Arcvhivo_Escrituras");
            row.CreateCell(77).SetCellValue("Arcvhivo_Croquis");

            row.CreateCell(78).SetCellValue("Economico_Requiere_Revision_Tipologias");
            row.CreateCell(79).SetCellValue("Economico_Requiere_Revision_Zonas");
            row.CreateCell(80).SetCellValue("Economico_Observaciones");
            rowIndex++;

            foreach (var diagnostico in diagnosticos)
            {
                row = sheet.CreateRow(rowIndex);
                row.CreateCell(0).SetCellValue(diagnostico.Id);
                row.CreateCell(1).SetCellValue(diagnostico.General_NumeroPredial);
                row.CreateCell(2).SetCellValue(diagnostico.General_Ejecutor);
                row.CreateCell(3).SetCellValue(diagnostico.General_Coordinador);
                row.CreateCell(4).SetCellValue(diagnostico.General_CoordinadorNombre);
                row.CreateCell(5).SetCellValue(diagnostico.General_Fecha.ToString());
                row.CreateCell(6).SetCellValue(diagnostico.General_Departamento);
                row.CreateCell(7).SetCellValue(diagnostico.General_DepartamentoNombre);
                row.CreateCell(8).SetCellValue(diagnostico.General_Municipio);
                row.CreateCell(9).SetCellValue(diagnostico.General_MunicipioNombre);
                row.CreateCell(10).SetCellValue(diagnostico.General_Comuna);
                row.CreateCell(11).SetCellValue(diagnostico.General_Vereda);
                row.CreateCell(12).SetCellValue(diagnostico.General_Barrio);
                row.CreateCell(13).SetCellValue(diagnostico.General_Direccion);
                row.CreateCell(14).SetCellValue(diagnostico.General_Direccion2);
                row.CreateCell(15).SetCellValue(diagnostico.General_TipoDireccion);
                row.CreateCell(16).SetCellValue(diagnostico.General_Condicion);
                row.CreateCell(17).SetCellValue(diagnostico.General_Mejoras);
                row.CreateCell(18).SetCellValue(diagnostico.General_Numero_Mejoras);
                row.CreateCell(19).SetCellValue(diagnostico.General_Destino);
                row.CreateCell(20).SetCellValue(diagnostico.General_AreaTerreno.ToString());
                row.CreateCell(21).SetCellValue(diagnostico.General_AreaConstruida.ToString());
                row.CreateCell(22).SetCellValue(diagnostico.General_Avaluo.ToString());

                row.CreateCell(23).SetCellValue(diagnostico.Geografica_Omision);
                row.CreateCell(24).SetCellValue(diagnostico.Geografica_DuplicadoGeograficamente);
                row.CreateCell(25).SetCellValue(diagnostico.Geografica_NumeroDuplicados);
                row.CreateCell(26).SetCellValue(diagnostico.Geografica_RequiereVisitaGeografica);
                row.CreateCell(27).SetCellValue(diagnostico.Geografica_Observacion);
                row.CreateCell(28).SetCellValue(diagnostico.Geografica_FmiDuplicados);
                row.CreateCell(29).SetCellValue(diagnostico.Geografica_NumeroFmiDuplicados);
                row.CreateCell(30).SetCellValue(diagnostico.Geografica_VerificacionFmi);
                row.CreateCell(31).SetCellValue(diagnostico.Geografica_FmiCorrecto);

                row.CreateCell(32).SetCellValue(diagnostico.Tramite_PropietariosCorrectos);
                row.CreateCell(33).SetCellValue(diagnostico.Tramite_Englobe);
                row.CreateCell(34).SetCellValue(diagnostico.Tramite_Desenglobe);
                row.CreateCell(35).SetCellValue(diagnostico.Tramite_Unidadestramite);
                row.CreateCell(36).SetCellValue(diagnostico.Tramite_ReglamentoPH);
                row.CreateCell(37).SetCellValue(diagnostico.Tramite_UnidadesReglamento);
                row.CreateCell(38).SetCellValue(diagnostico.Tramite_Linderos);
                row.CreateCell(39).SetCellValue(diagnostico.Tramite_LinderosFmi);
                row.CreateCell(40).SetCellValue(diagnostico.Tramite_LinderosArcifinios);
                row.CreateCell(41).SetCellValue(diagnostico.Tramite_LinderosEnEscritura);
                row.CreateCell(42).SetCellValue(diagnostico.Tramite_NumeroEscritura);
                row.CreateCell(43).SetCellValue(diagnostico.Tramite_LinderosVerificablesTerreno);
                row.CreateCell(44).SetCellValue(diagnostico.Tramite_Existe_Englobe_Con_Mejora);
                row.CreateCell(45).SetCellValue(diagnostico.Tramite_Requiere_Actualizacion_Nomenclatura);

                row.CreateCell(46).SetCellValue(diagnostico.Terreno_EscrituraLinderos);
                row.CreateCell(47).SetCellValue(diagnostico.Terreno_TieneArea);
                row.CreateCell(48).SetCellValue(diagnostico.Terreno_AreaTerreno.ToString());
                row.CreateCell(49).SetCellValue(diagnostico.Terreno_UnidadArea);
                row.CreateCell(50).SetCellValue(diagnostico.Terreno_AreaTerrenoEnMetros.ToString());
                row.CreateCell(51).SetCellValue(diagnostico.Terreno_PorcentajeAreaJudicialAreaCatastral.ToString());
                row.CreateCell(52).SetCellValue(diagnostico.Terreno_IdentificacionPredio);
                row.CreateCell(53).SetCellValue(diagnostico.Terreno_ObservacionVisita);

                row.CreateCell(54).SetCellValue(diagnostico.Construccion_IncorporacioArea);
                row.CreateCell(55).SetCellValue(diagnostico.Construccion_DetalleIncorporacionArea);
                row.CreateCell(56).SetCellValue(diagnostico.Construccion_Uso);
                row.CreateCell(57).SetCellValue(diagnostico.Construccion_Destino);
                row.CreateCell(58).SetCellValue(diagnostico.Construccion_ObservacionUsosDestino);
                row.CreateCell(59).SetCellValue(diagnostico.Construccion_RequiereVisitaConstruccion);
                row.CreateCell(60).SetCellValue(diagnostico.Construccion_TieneConstrucciones);
                row.CreateCell(61).SetCellValue(diagnostico.Construccion_ConstruccionEsCorrecta);
                row.CreateCell(62).SetCellValue(diagnostico.Construccion_AdicionaCancelaUnidades);
                row.CreateCell(63).SetCellValue(diagnostico.Construccion_AdicionarConstrucciones);
                row.CreateCell(64).SetCellValue(diagnostico.Construccion_ElminarConstrucciones);
                row.CreateCell(65).SetCellValue(diagnostico.Construccion_AdicionarAnexos);
                row.CreateCell(66).SetCellValue(diagnostico.Construccion_ElminarAnexos);
                row.CreateCell(67).SetCellValue(diagnostico.Construccion_Tiene_cubrimiento_orto);
                row.CreateCell(68).SetCellValue(diagnostico.Construccion_Tiene_cubrimiento_visor);
                row.CreateCell(69).SetCellValue(diagnostico.Construccion_Uso_Detalle);
                row.CreateCell(70).SetCellValue(diagnostico.Construccion_Destino_Detalle);

                row.CreateCell(71).SetCellValue(diagnostico.Arcvhivo_FotoFachada);
                row.CreateCell(72).SetCellValue(diagnostico.Arcvhivo_Fmi);
                row.CreateCell(72).SetCellValue(diagnostico.Arcvhivo_CertificadoNomenclatura);
                row.CreateCell(74).SetCellValue(diagnostico.Arcvhivo_FichaPredial);
                row.CreateCell(75).SetCellValue(diagnostico.Arcvhivo_Plano);
                row.CreateCell(76).SetCellValue(diagnostico.Arcvhivo_Escrituras);
                row.CreateCell(77).SetCellValue(diagnostico.Arcvhivo_Croquis);

                row.CreateCell(78).SetCellValue(diagnostico.Economico_Requiere_Revision_Tipologias);
                row.CreateCell(79).SetCellValue(diagnostico.Economico_Requiere_Revision_Zonas);
                row.CreateCell(80).SetCellValue(diagnostico.Economico_Observaciones);
            }

            foreach (var cell in row.Cells)
            {
                sheet.AutoSizeColumn(cell.ColumnIndex);
            }

            return workbook;
        }
      
    }
}