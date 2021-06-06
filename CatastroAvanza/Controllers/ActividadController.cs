﻿using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models;
using CatastroAvanza.Models.ActividadViewModels;
using CatastroAvanza.Models.Dashboard;
using CatastroAvanza.Negocio.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
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
            model.Terreno.UnidadesArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.UnidadArea), "Value", "Text", 1);
            model.Informacion.TiposDireccion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.TipoDireccion), "Value", "Text", 1);
            model.Informacion.Departamentos = new SelectList(_catalogos.ObtenerDepartamentosPorIdPais(1), "Value", "Text", 1);
            model.Informacion.Municipios = new SelectList(new List<CatalogoViewModel>(), "Value", "Text", 1);
            model.Construccion.DetallesIncorporacionArea = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.DetalleIncorporacionArea), "Value", "Text", 1);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CrearActividad(ActividadPredioViewModel model)
        {            
            await _actividad.CrearActividad(model);
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

    }
}