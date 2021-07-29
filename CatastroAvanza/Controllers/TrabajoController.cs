using CatastroAvanza.Enumerations;
using CatastroAvanza.Helpers.DataTableHelper;
using CatastroAvanza.Models.Trabajo;
using CatastroAvanza.Negocio.Contratos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CatastroAvanza.Controllers
{
    [Authorize]
    public class TrabajoController : BaseController
    {
        public TrabajoController(ICatalogo catalogos, ITrabajoLogic trabajo, ISecurityLogic securityManager)
        {
            _catalogos = catalogos;
            _trabajo = trabajo;
            _securityManager = securityManager;
        }

        private readonly ICatalogo _catalogos;
        private readonly ISecurityLogic _securityManager;
        private readonly ITrabajoLogic _trabajo;

        public ActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "administrator")]
        [HttpGet]
        public async Task<ActionResult> CrearTrabajo()
        {
            CrearTrabajoViewModel model = new CrearTrabajoViewModel();

            var roles = _securityManager.GetRoles();
            model.Roles = new SelectList(roles, "Id", "Name", 1);
            return View(model);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> CrearTrabajo(CrearTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result= await _trabajo.CrearTrabajo(model, new Models.AuditoriaModel(GetUserName()));
                if (result != 0)
                    return RedirectToAction(nameof(CrearTrabajo));
            }

            var roles = _securityManager.GetRoles();
            model.Roles = new SelectList(roles, "Id", "Name", 1);
            return View(nameof(CrearTrabajo), model);            
        }

        [Authorize(Roles = "administrator")]
        [HttpGet]
        public async Task<ActionResult> ActualizarTrabajo(int idTrabajo)
        {
            ActualizarTrabajoViewModel model =await _trabajo.ConsultarTrabajoPorIdParaActualizar(idTrabajo);

            if (model.Id == 0)
                RedirectToAction(nameof(CrearTrabajo));

            var roles = _securityManager.GetRoles();
            model.Roles = new SelectList(roles, "Id", "Name", 1);
            return View(model);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> ActualizarTrabajo(ActualizarTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result = await _trabajo.ActualizarTrabajo(model, new Models.AuditoriaModel(GetUserName()));
                if (result != 0)
                    return RedirectToAction(nameof(CrearTrabajo));
            }

            var roles = _securityManager.GetRoles();
            model.Roles = new SelectList(roles, "Id", "Name", 1);
            return View(nameof(ActualizarTrabajo), model);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> EliminarTrabajo(int idTrabajo)
        {
            
            int result = await _trabajo.EliminarTrabajo(idTrabajo, new Models.AuditoriaModel(GetUserName()));
            if (result != 0)
                return Json("Ok", JsonRequestBehavior.AllowGet);
            
            return Json("Error", JsonRequestBehavior.AllowGet);
        }


        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> ConsultarTrabajosAdministrador([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var tabla = await _trabajo.ConsultarTrabajosAdministrador(modelo);
            return Json(tabla, JsonRequestBehavior.AllowGet);           
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarTrabajos([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            if (UserIsInRol("administrator"))
            {
                var tabla = await _trabajo.ConsultarTrabajosAdministrador(modelo);
                return Json(tabla, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var tabla = await _trabajo.ConsultarTrabajos(modelo, GetUserName());
                return Json(tabla, JsonRequestBehavior.AllowGet);
            }
        }

        [Authorize(Roles = "administrator")]
        [HttpGet]
        public async Task<ActionResult> CrearAsignacionTrabajo(int idTrabajo)
        {
            var trabajo = await _trabajo.ConsultarTrabajoPorId(idTrabajo);

            CreaAsignacionTrabajoViewModel model = new CreaAsignacionTrabajoViewModel { 
                IdActividad = trabajo.Id,
                NombreActividad = trabajo.Nombre,
                FechaAsignacion = System.DateTime.Now,
                UsuarioQueAsigno = GetUserName()
            };

            return View(model);
        }

        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> CrearAsignacionTrabajo(CreaAsignacionTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.FechaAsignacion = System.DateTime.Now;
                model.UsuarioQueAsigno = GetUserName();

                int result = await _trabajo.CrearAsignacionTrabajo(model, new Models.AuditoriaModel(GetUserName()));
                if (result != 0)
                    return RedirectToAction(nameof(CrearTrabajo));
            }

            model.UsuarioQueAsigno = GetUserName();
            return View(nameof(CrearAsignacionTrabajo), model);
        }


        [Authorize(Roles = "administrator")]
        [HttpPost]
        public async Task<ActionResult> ConsultarUsuarios(string term)
        {
            var usuarios=await _securityManager.GetUsuariosByName(term);

            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ListaTrabajos()
        {
            return View();
        }



        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarTrabajosUsuarios([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var tabla = await _trabajo.ConsultarTrabajos(modelo, GetUserName());
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GestionarTrabajo(int idTrabajo)
        {
            var trabajoAsignacion = await _trabajo.ConsultarAsignacionPorIdTrabajo(idTrabajo, GetUserName());

            CrearGestionTrabajoViewModel model = new CrearGestionTrabajoViewModel
            {
                EstadosGestion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.EstadoGestion), "Value", "Text", 1),
                IdAsignacion = trabajoAsignacion.Id,
                IdTrabajo = trabajoAsignacion.IdActividad,
                NombreTrabajo = trabajoAsignacion.NombreActividad
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> GestionarTrabajo(CrearGestionTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {                
                int result = await _trabajo.CrearGestionTrabajo(model, new Models.AuditoriaModel(GetUserName()));
                if (result != 0)
                    return RedirectToAction(nameof(GestionarTrabajo),new { idTrabajo = model.IdTrabajo });
            }

            var trabajoAsignacion = await _trabajo.ConsultarAsignacionPorIdTrabajo(model.IdTrabajo, GetUserName());

            CrearGestionTrabajoViewModel modelnew = new CrearGestionTrabajoViewModel
            {
                EstadosGestion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.EstadoGestion), "Value", "Text", 1),
                IdAsignacion = trabajoAsignacion.Id,
                IdTrabajo = trabajoAsignacion.IdActividad,
                NombreTrabajo = trabajoAsignacion.NombreActividad
            };

            return View(nameof(GestionarTrabajo), model);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> ActualizarGestionTrabajo(int idGestion)
        {
            ActualizarGestionTrabajoViewModel model = await _trabajo.ConsultarGestionPorIdparaActualizar(idGestion, GetUserName());

            if (model.Id == 0)
                RedirectToAction(nameof(GestionarTrabajo));

            model.EstadosGestion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.EstadoGestion), "Value", "Text", 1);
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ActualizarGestionTrabajo(ActualizarGestionTrabajoViewModel model)
        {
            if (ModelState.IsValid)
            {
                int result = await _trabajo.ActualizarGestionTrabajo(model, new Models.AuditoriaModel(GetUserName()));
                if (result != 0)
                    return RedirectToAction(nameof(GestionarTrabajo), new { idTrabajo  = model.IdTrabajo});
            }

            model.EstadosGestion = new SelectList(_catalogos.ObtenerCatalogoPorTipo(CatalogosEnum.EstadoGestion), "Value", "Text", 1);
            return View(nameof(ActualizarGestionTrabajo), model);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarGestion([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo, int idAsignacion)
        {
            var tabla = await _trabajo.ConsultarGestiones(modelo, idAsignacion, GetUserName());
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarVolumen()
        {
            var tabla = await _trabajo.ConsultarVolumenDiario();
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarEstado()
        {
            var tabla = await _trabajo.ConsultarEstados();
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }


        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConsultarGestionAsignacionUsuarios([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest modelo)
        {
            var tabla = await _trabajo.ConsultarUsuariosAsignaciones(modelo);
            return Json(tabla, JsonRequestBehavior.AllowGet);
        }
    }
}