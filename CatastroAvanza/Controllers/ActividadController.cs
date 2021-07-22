﻿using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Infraestructura;
using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Negocio.Contratos;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    [Authorize]
    public class ActividadController : BaseController
    {
        public ActividadController(ICatalogo catalogos, IActividadLogic actividad, IDataForm1Logic dataFormLogicService)
        {
            _catalogos = catalogos;
            _actividad = actividad;
            _dataFormLogicService = dataFormLogicService;
        }

        private readonly ICatalogo _catalogos;
        private readonly IActividadLogic _actividad;
        private readonly IDataForm1Logic _dataFormLogicService;
        // GET: Actividad
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> CrearActividad()
        {
            ActividadPredioViewModel model = new ActividadPredioViewModel();

            model.Ejecutores = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Ejecutor), "Value", "Text", 1);
            model.Coordinadores = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Coordinador), "Value", "Text", 1);
            model.Terreno.UnidadesArea = new SelectList(_catalogos.ObtenerUnidadArea(), "Value", "Text", 1);
            model.Terreno.UnidadesAreaList = _catalogos.ObtenerUnidadArea();
            model.Informacion.TiposDireccion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.TipoDireccion), "Value", "Text", 1);
            model.Informacion.Departamentos = new SelectList(_catalogos.ObtenerDepartamentosPorIdPais(1), "Value", "Text", 1);
            model.Informacion.Municipios = new SelectList(new List<CatalogoViewModel>(), "Value", "Text", 1);
            model.Construccion.DetallesIncorporacionArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.DetalleIncorporacionArea), "Value", "Text", 1);
            model.Construccion.Destinos = new SelectList(_catalogos.ObtenerDestino(), "Value", "Text", 1);
            model.Construccion.Usos = new SelectList(_catalogos.ObtenerUso(), "Value", "Text", 1);
            model.Ejecutor = HttpContext.User.Identity.Name;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearActividad(ActividadPredioViewModel model)
        {
            model.Ejecutor = HttpContext.User.Identity.Name;
            await _actividad.CrearActividad(model);
            return RedirectToAction(nameof(Index));                     
        }

        [HttpGet]
        public async Task<ActionResult> ActualizarActividad(int actividadId)
        {
            ActividadPredioViewModel model = await _actividad.ConsultarActividadPorId(actividadId);

            model.Coordinadores = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.Coordinador), "Value", "Text", model.Coordinador);
            model.Terreno.UnidadesArea = new SelectList(_catalogos.ObtenerUnidadArea(), "Value", "Text", model.Terreno.UnidadArea);
            model.Terreno.UnidadesAreaList = _catalogos.ObtenerUnidadArea();
            model.Informacion.TiposDireccion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.TipoDireccion), "Value", "Text", model.Informacion.TipoDireccion);
            model.Informacion.Departamentos = new SelectList(_catalogos.ObtenerDepartamentosPorIdPais(1), "Value", "Text", model.Informacion.Departamento);
            model.Informacion.Municipios = new SelectList(new List<CatalogoViewModel>(), "Value", "Text", model.Informacion.Municipio);
            model.Construccion.DetallesIncorporacionArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.DetalleIncorporacionArea), "Value", "Text", model.Construccion.DestinoDetalle);
            model.Construccion.Destinos = new SelectList(_catalogos.ObtenerDestino(), "Value", "Text", model.Construccion.Destino);
            model.Construccion.Usos = new SelectList(_catalogos.ObtenerUso(), "Value", "Text", model.Construccion.Uso);
            model.Ejecutor = model.Ejecutor;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ActualizarActividad(ActividadPredioViewModel model)
        {
            var result = await _actividad.ActualizarActividad(model, HttpContext.User.Identity.Name);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<JsonResult> ObternerMunicipios(int IdDepartamento)
        {
            var municipios = new SelectList(_catalogos.ObtenerMunicipiosPorIdDepartamento(IdDepartamento), "Value", "Text", 1);
            return Json(municipios, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> ObtenerActividades([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var actividades = await _actividad.ConsultarActividades(modelo);
            return Json(actividades, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ObtenerPredial(string noPredial)
        {
            DataForm1Model processModel = _dataFormLogicService.GetUsersById(noPredial);
            return Json(processModel, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<FileResult> ObtenerActividadesExcel()
        {
            var actividades =await _actividad.ConsultarActividadExcel();

            GeneracionExcel excel = new GeneracionExcel();

            var excelWorkBook = excel.GenerarArchivoExcelDiagnostico(actividades);

            var exportData = new MemoryStream();
            excelWorkBook.Write(exportData);
            exportData.Seek(0, SeekOrigin.Begin);
            return File(exportData, "application/vnd.ms-excel", "Diagnosticos.xls");
        }

    }
}